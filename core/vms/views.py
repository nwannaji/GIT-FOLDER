from datetime import datetime
from django.http import HttpResponse, JsonResponse
from django.shortcuts import get_object_or_404, redirect, render
from django.urls import reverse
from django.contrib import messages
import pytz
from django.db.models import Count
from django.utils.timezone import now
from django.contrib.auth.decorators import login_required
from django.views.decorators.csrf import csrf_protect
from .utils import send_employee_whatsApp_message, send_visitor_whatsApp_message, reject_visit, send_approved_or_decline_visit, generate_qr_code, upload_qr_code_to_firebase
from .models import CheckIn_Visitor, Pending_Visitor, Visitor, Employee

@login_required(login_url='/admin/login/')
def dashboard(request):
    """Displays all visitors with associated employees and departments."""
    visitors = Visitor.objects.all().order_by('-visitor_id')
    
    visitor_data_list = [
        {
            'visitor_name': visitor.visitor_name,
            'organization': visitor.organization,
            'employee_names': ', '.join([employee.employee_name for employee in visitor.whom_to_see.all()]),
            'dept_names': ', '.join([employee.dept_name for employee in visitor.whom_to_see.all()]),
            'is_official': visitor.is_official,
            'is_invited': visitor.is_invited,
            'first_timer': visitor.first_timer,
            'date_of_visit': visitor.date_of_visit or now().date(),
        }
        for visitor in visitors
    ]
    
    context = {'visitor_data_list': visitor_data_list}
    return render(request, 'dashboard.html', context)

def fetch_employees(request):
    query = request.GET.get('q', '')
    if query:
        # Filter employees based on the search query
        employees = Employee.objects.filter(employee_name__icontains=query).values('employee_name', 'dept_name')
        employee_list = [{'name': emp['employee_name'], 'dept': emp['dept_name']} for emp in employees]
        return JsonResponse(employee_list, safe=False)
    return JsonResponse([], safe=False)

@csrf_protect
def get_department_data(request):
    """Fetches visitor count per department."""
    data = Visitor.objects.values('dept').annotate(count=Count('visitor_id')).order_by('dept')
    department_data = {item['dept']: item['count'] for item in data}
    return JsonResponse(department_data)

@csrf_protect
@login_required(login_url='/admin/login/')
def schedule_visit(request):
    """Handles visitor scheduling, QR generation, and pending approval."""
    if request.method == 'POST':
        is_official = request.POST.get('is_official') == 'on'
        is_invited = request.POST.get('invited') == 'on'
        first_timer = request.POST.get('first_timer') == 'on'
        
        get_employee_name = request.POST.get('whom_to_see')
        employee = get_object_or_404(Employee, employee_name=get_employee_name)

        visitor_data = {
            'visitor_name': request.POST.get('visitor_name'),
            'phone_number': request.POST.get('phone_number'),
            'email_address': request.POST.get('email_address'),
            'qr_code': request.POST.get('qr_code'),
            'otp': request.POST.get('otp'),
            'organization': request.POST.get('organization'),
            'dept': request.POST.get('dept'),
            'is_official': is_official,
            'comments': request.POST.get('comments'),
            'is_invited': is_invited,
            'first_timer': first_timer,
            'date_of_visit': request.POST.get('date_of_visit'),
        }

        visitor = Visitor.objects.create(**visitor_data)
        visitor.whom_to_see.add(employee)
        visitor.date_of_visit = visitor.date_of_visit or now()

        qr_code_path = generate_qr_code(visitor, employee.employee_name)
        qr_code_url = upload_qr_code_to_firebase(qr_code_path, qr_code_path)

        send_visitor_whatsApp_message(visitor)
        send_employee_whatsApp_message(employee, visitor)

        Pending_Visitor.objects.create(name=visitor, status='PENDING')

        messages.success(request, 'Visitor successfully created.')
        return redirect(reverse('dashboard'))
    
    return render(request, 'schedule_visit.html')

@csrf_protect
@login_required(login_url='/admin/login/')
def check_in(request):
    """Manages visitor check-in actions (approve, checkout, decline)."""
    if request.method == 'POST':
        visitor_id = request.POST.get('visitor_id')
        action = request.POST.get('action')
        visitor = get_object_or_404(Visitor, pk=visitor_id)
        pending_visit = Pending_Visitor.objects.filter(name=visitor).first()
        check_in, _ = CheckIn_Visitor.objects.get_or_create(visitor_name=visitor)
        
        if pending_visit:
            if action == 'approve':
                pending_visit.status = 'APPROVED'
                check_in.is_approved = True
                check_in.is_pending = False
                messages.success(request, f"Visitor {visitor.visitor_name}'s visit has been approved.")
            elif action == 'checkout':
                pending_visit.status = 'CHECKOUT'
                check_in.is_pending = False
                check_in.time_out = now()  # Set time_out during checkout
                messages.success(request, f"Visitor {visitor.visitor_name} has checked out.")
            elif action == 'decline':
                pending_visit.status = 'DECLINED'
                check_in.is_approved = False
                check_in.is_pending = False
                messages.warning(request, f"Visitor {visitor.visitor_name}'s visit has been declined.")
            
            pending_visit.save()
            check_in.save()
            return redirect('checkIn')
    
    context = {
        'approved_visitors': Pending_Visitor.objects.filter(status='APPROVED'),
        'pending_visitors': Pending_Visitor.objects.filter(status='PENDING'),
        'checkout_visitors': Pending_Visitor.objects.filter(status='CHECKOUT'),
    }
    return render(request, 'check_in.html', context)

@csrf_protect
@login_required(login_url='/admin/login/')
def update_checkin_visitor_model(request):
    """Updates the CheckIn_Visitor model with timestamps."""
    dt = datetime.now(pytz.timezone('Africa/Lagos'))
    formatted_time_in = dt.strftime('%I:%M %p')
    formatted_time_out = dt.strftime('%I:%M %p')

    pending_approval = Pending_Visitor.objects.first()
    if pending_approval:
        visitor = pending_approval.name
        is_pending = pending_approval.status == 'PENDING'
        is_approved = pending_approval.status == 'APPROVED'
        approved_by = Employee.objects.first()

        if visitor and approved_by:
            CheckIn_Visitor.objects.create(
                visitor_name=visitor,
                time_In=formatted_time_in,
                time_Out=formatted_time_out,
                is_pending=is_pending,
                is_approved=is_approved,
                approved_by=approved_by
            )

    return redirect('check_in')

@login_required(login_url='/admin/login/')
def approve_decline_visit(request):
    """Allows admin to approve, decline, or check out a visitor."""
    visit_requests = Pending_Visitor.objects.filter(status='PENDING')

    if request.method == 'POST':
        visitor_id = request.POST.get('visitor_id')
        action = request.POST.get('action')
        visit_request = get_object_or_404(Pending_Visitor, id=visitor_id)
        
        if action == 'approved':
            visit_request.status = 'APPROVED'
        elif action == 'decline':
            visit_request.status = 'DECLINED'
        elif action == 'checkout':
            visit_request.status = 'CHECKOUT'
        
        visit_request.approved_by = request.user
        visit_request.save()
        return HttpResponse(f"Visit request by {visit_request.name.visitor_name} has been {action}.")
    
    return render(request, 'check_in.html', {'visit_requests': visit_requests})

@csrf_protect
def draw_chart(request):
    """Displays the chart page."""
    return render(request, 'my_chart.html')

@csrf_protect
def contact_page(request):
    """Renders the contact page."""
    return render(request, 'contact_us.html')

    

