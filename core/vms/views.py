from django.shortcuts import get_object_or_404, redirect, render
from django.urls import reverse
from django.contrib import messages
from .models import Visitor,Employee

# def fetch_visitors(request):
#     visitor_data_list =[]
#     visitors = Visitor.objects.all().order_by('-visitor_id')[:5]
#     for visitor in visitors:
#         visitor_data = {
#             'visitor_id': visitor.visitor_id,  # Renamed to plural for clarity
#             'visitor_name':visitor.visitor_name,
#             'phone_number':visitor.phone_number,
#             'email_address':visitor.email_address,
#             'qr_code':visitor.qr_code,
#             'otp':visitor.otp,
#             'organization':visitor.organization,
#             'dept':visitor.dept,
#             'whom_to_see':visitor.whom_to_see,
#             'is_official':visitor.is_official,
#             'first_timer':visitor.first_timer,
#             'date_of_visit':visitor.date_of_visit    
#         }
#         visitor_data_list.append(visitor_data)
#         if visitor_data_list:
#             context = {
#                 'visitors':visitor_data_list,
#             }
#         return render(request, 'dashboard.html', context)

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

