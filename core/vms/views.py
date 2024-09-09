from datetime import datetime
from django.http import HttpResponse, JsonResponse
from django.shortcuts import get_object_or_404, redirect, render
from django.urls import reverse
from django.contrib import messages
import pytz
from django.db.models import Count
from django.utils.timezone import now
from django.contrib.auth.decorators import login_required
from django.views.decorators.csrf import csrf_exempt
from .utils import  send_employee_whatsApp_message, send_visitor_whatsApp_message,reject_visit, send_approved_or_decline_visit,generate_qr_code,upload_qr_code_to_firebase
from .models import CheckIn_Visitor, Pending_Visitor, Visitor,Employee

@csrf_exempt
def dashboard(request):
    # Retrieve all visitors
    visitors = Visitor.objects.all().order_by('-visitor_id')
    
    visitor_data_list = []
    for visitor in visitors:
        # Retrieve the employees the visitor wants to see
        employees_to_see = visitor.whom_to_see.all()
        employee_names = ', '.join([employee.employee_name for employee in employees_to_see])
        dept_names = ', '.join([employee.dept_name for employee in employees_to_see])
        
        visitor_data_list.append({
            'visitor_name': visitor.visitor_name,
            'organization':visitor.organization,
            'employee_names': employee_names,
            'dept_names': dept_names,
            'is_official':visitor.is_official,
            'is_invited':visitor.is_invited,
            'first_timer':visitor.first_timer,
            'date_of_visit':visitor.date_of_visit or now().date()
        })
    # Pass the visitor data to the template
    context = {
        'visitor_data_list': visitor_data_list,
    }
    return render(request, 'dashboard.html', context)

@csrf_exempt
def get_department_data(request):
    data =(
        Visitor.objects.values('dept').annotate(count=Count('visitor_id'))
        .order_by('dept')
    )
    # Convert the data to a dictionary
    department_data = {item['dept']: item['count'] for item in data}
    return JsonResponse(department_data)


@csrf_exempt
def schedule_visit(request):
    if request.method == 'POST':
        # Retrieve and convert checkbox values to boolean
        is_official = request.POST.get('is_official') == 'on'
        is_invited = request.POST.get('invited') == 'on'
        first_timer = request.POST.get('first_timer') == 'on'
                
            # Get the name of the employee the visitor wants to see
        get_employee_name = request.POST.get('whom_to_see')
        
        # Retrieve the employee object based on the employee name
        employee = Employee.objects.get(employee_name=get_employee_name)

        visitor_data = {
            'visitor_name': request.POST.get('visitor_name'),
            'phone_number': request.POST.get('phone_number'),
            'email_address': request.POST.get('email_address'),
            'qr_code': request.POST.get('qr_code'),
            'otp': request.POST.get('otp'),
            'organization': request.POST.get('organization'),
            'dept': request.POST.get('dept'),
            'is_official': request.POST.get('is_official') == 'on',
            'comments': request.POST.get('comments'),
            'is_invited': request.POST.get('invited') == 'on',
            'first_timer': request.POST.get('first_timer') == 'on',
            'date_of_visit': request.POST.get('date_of_visit'),
        }

        # Create the visitor instance
        visitor = Visitor.objects.create(**visitor_data)

        # Add the employee to the whom_to_see relationship
        visitor.whom_to_see.add(employee)  # Add the employee object directly

        # Save the visitor instance
        visitor.save()


        # Generate QR code, upload to Firebase, and send WhatsApp message
        qr_code_path = generate_qr_code(visitor,employee.employee_name)
        qr_code_url = upload_qr_code_to_firebase(qr_code_path, qr_code_path)
        send_visitor_whatsApp_message(visitor, qr_code_url)
        send_employee_whatsApp_message(employee,visitor)

        # Save visitor information in Pending_Approval_List
        Pending_Visitor.objects.create(
            name=visitor,
            status='PENDING'
        )

        messages.success(request, 'Visitor successfully created.')
        return redirect(reverse('dashboard'))
    else:
         return render(request,"error_page.html")

@csrf_exempt
def error_message_page(request):
    return render(request,'error_page.html')

@csrf_exempt
@login_required(login_url='admin:login')
def checkIn(request):
    context = {}

    if request.method == 'POST':
        visitor_id = request.POST.get('visitor_id')
        action = request.POST.get('action')
        visitor = Visitor.objects.filter(pk=visitor_id).first()

        if visitor:
            pending_visit = Pending_Visitor.objects.filter(name=visitor).first()

            if pending_visit:
                if pending_visit.status == 'PENDING' and request.POST.get('action'):
                    pending_visit.status = 'APPROVED'
                    pending_visit.save()
                elif pending_visit.status == 'APPROVED' and request.POST.get('action'):
                    pending_visit.status = 'CHECK-OUT'
                    pending_visit.save()
                    context = {'name':visitor.visitor_name}
                    return redirect('checkIn')  # Refresh the page
        else:
            context['messages'] = 'Visitor not found.'

    # Fetch all visitors based on their status
    context['approved_visitors'] = Pending_Visitor.objects.filter(status='APPROVED')
    context['pending_visitors'] = Pending_Visitor.objects.filter(status='PENDING')
    context['checkout_visitors'] = Pending_Visitor.objects.filter(status='CHECK-OUT')

    return render(request, 'check_In.html', context)

    
@csrf_exempt
@login_required(login_url='admin:login')
def update_checkin_visitorModel(request):
    dt = datetime.now(pytz.timezone('Africa/Lagos'))
    formatted_time_in = dt.strftime('%I:%M %p')
    formatted_time_out = dt.strftime('%I:%M %p')

    # Fetch the first pending approval record
    pending_approval = Pending_Visitor.objects.first()

    if pending_approval:
        visitor = pending_approval.name  # Accessing the Visitor instance
        is_pending = pending_approval.status == 'PENDING'
        is_approved = pending_approval.status == 'APPROVED'
    else:
        visitor = None
        is_pending = False
        is_approved = False

    # Fetch the first employee who approved
    approved_by = Employee.objects.first()

    # Update CheckIn_Visitor model only if a visitor is found and an employee is present
    if visitor and approved_by:
        CheckIn_Visitor.objects.create(
            visitor_name=visitor,
            time_In=formatted_time_in,
            time_Out=formatted_time_out,
            is_pending=is_pending,
            is_approved=is_approved,
            approved_by=approved_by
        )

    # Redirect to refresh the page
    return redirect('checkIn')

@login_required(login_url='/admin/login/')  # Redirect to Django admin login if not logged in
def approve_decline_visit(request):
    visit_requests = Pending_Visitor.objects.filter(status='PENDING')
    if request.method == 'POST':
        visit_id = request.POST.get('visit_id')
        action = request.POST.get('action')
        visit_request = get_object_or_404(Pending_Visitor, id=visit_id)
        if action == 'approve':
            visit_request.status = 'APPROVED'
            visit_request.approved_by = request.user
            visit_request.save()
            return HttpResponse(f"Visit request by {visit_request.visitor.name} has been approved.")
        elif action == 'decline':
            visit_request.status = 'DECLINED'
            visit_request.approved_by = request.user
            visit_request.save()
            return HttpResponse(f"Visit request by {visit_request.visitor.name} has been declined.")
        elif action == 'checkout':
            visit_request.status = 'CHECK-OUT'
            visit_request.approved_by = request.user
            visit_request.save()
            return HttpResponse(f"This visitor by name {visit_request.visitor.name} has been checked-out.")
    return render(request,'check_In.html',{'visit_requests': visit_requests})

@csrf_exempt
def draw_chart(request):
    return render(request, 'my_chart.html')

@csrf_exempt
def contact_page(request):
    return render(request, 'contact_us.html')
    

