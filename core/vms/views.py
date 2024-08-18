from datetime import datetime
from django.shortcuts import get_object_or_404, redirect, render
from django.urls import reverse
from django.contrib import messages
import pytz
from django.views.decorators.csrf import csrf_exempt
from .utils import sendWhatApps_message,generate_qr_code,upload_qr_code_to_firebase
from .models import CheckIn_Visitor, Pending_Visitor, Visitor,Employee

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
            'date_of_visit':visitor.date_of_visit.date
        })
    # Pass the visitor data to the template
    context = {
        'visitor_data_list': visitor_data_list,
    }
    return render(request, 'dashboard.html', context)
@csrf_exempt
def schedule_visit(request):
    if request.method == 'POST':
        # Retrieve and convert checkbox values to boolean
        is_official = request.POST.get('is_official') == 'on'
        is_invited = request.POST.get('invited') == 'on'
        first_timer = request.POST.get('first_timer') == 'on'
        
        # Retrieve the employee object whom the visitor wants to see
        whom_to_see = request.POST.get('whom_to_see')
        try:
            employee_to_see = get_object_or_404(Employee,employee_name=whom_to_see)
        except Employee.DoesNotExist:
            messages.error(request, 'Employee not found.')
            return render(request,'error_page.html')

        # Create the Visitor object
        visitor_data = {
            'visitor_name': request.POST.get('visitor_name'),
            'phone_number': request.POST.get('phone_number'),
            'email_address': request.POST.get('email_address'),
            'qr_code': request.POST.get('qr_code'),
            'otp': request.POST.get('otp'),
            'organization': request.POST.get('organization'),
            'dept': request.POST.get('dept'),
            'is_official': is_official,
            'comments':request.POST.get('comments'),
            'is_invited': is_invited,
            'first_timer': first_timer,
            'date_of_visit': request.POST.get('date_of_visit'),
        }

        # Create and save the Visitor
        visitor = Visitor.objects.create(**visitor_data)
        visitor.whom_to_see.add(employee_to_see)
        visitor.save()

        # Generate QR code, upload to Firebase, and send WhatsApp message
        qr_code_path = generate_qr_code(visitor)
        qr_code_url = upload_qr_code_to_firebase(qr_code_path, qr_code_path)
        sendWhatApps_message(visitor, qr_code_url)

        # Save visitor information in Pending_Approval_List
        Pending_Visitor.objects.create(
            name=visitor,
            status='PENDING'
        )

        messages.success(request, 'Visitor successfully created.')
        return redirect(reverse('dashboard'))
    else:
        return render(reverse('error_page'))

@csrf_exempt
def error_message_page(request):
    return render(request,'error_page.html')


@csrf_exempt        
def checkIn(request):
    if request.method == 'POST':
        visitor_id = request.POST.get('visitor_id')
        visitor = Visitor.objects.filter(pk=visitor_id).first()
        if visitor:
            # Check if visitor is already in pending approval list
            pending_visit = Pending_Visitor.objects.filter(name_id=visitor)
            if pending_visit.exists() and pending_visit.first().status == 'PENDING' and request.POST.get('resubmitted'):
                pending_visit.update(status='APPROVED')
            elif pending_visit.exists() and pending_visit.first().status == 'APPROVED' and request.POST.get('resubmitted'):
                pending_visit.update(status='CHECK-OUT')
                return redirect('CHECK-IN')  # Redirect to refresh the page
        else:
            return render(request, 'check_In.html', {'messages': 'Visitor not found.'})
    # Fetch all approved, pending, and checked out visitors
    approved_visitors = Pending_Visitor.objects.filter(status='APPROVED')
    pending_visitors = Pending_Visitor.objects.filter(status='PENDING')
    checkout_visitors = Pending_Visitor.objects.filter(status='CHECK-OUT')
    return render(request, 'check_In.html', {'approved_visitors': approved_visitors, 'pending_visitors': pending_visitors, 'checkout_visitors': checkout_visitors})

@csrf_exempt
def update_checkin_visitorModel(request):
    dt = datetime.now(pytz.timezone('Africa/Lagos'))
    formatted_time = dt.strftime('%Y-%m-%d %H:%M:%S %z')

    # Fetch the status, visitor name, and approved by from the related models
    pending_approval_list = Pending_Visitor.objects.first()  # Fetching the first pending approval record for demonstration
    if pending_approval_list:
        visitor = pending_approval_list.name  # Accessing the VisitorsTable instance
    else:
        status = False
        visitor = None
    
    # Assuming EmployeeTable has only one record
    approvedBy = Employee.objects.first().employee_name  
    is_pending = Pending_Visitor.objects.filter(status='PENDING').exists()
    is_approved = Pending_Visitor.objects.filter(status='APPROVED').exists()
    # is_checkout = Pending_Visitor.objects.filter(status='APPROVED').exists()

    # Update CheckIn_visitor model
    if visitor:
        checkin_visitor = CheckIn_Visitor.objects.create(
            time_In=formatted_time,
            time_Out=formatted_time,
            is_pending=is_pending,
            is_approved=is_approved,
            next_visit=False,
            approved_by=approvedBy,
            is_active=False,
            v_name=visitor  # Assign the visitor instance directly
        )
        checkin_visitor.save()
    else:
        # Handle the case when there's no visitor
        pass
    return redirect('check_In')  # Redirect to refresh the page

