from urllib import request
from django.shortcuts import render
from django.views.decorators.csrf import csrf_exempt
from rest_framework.parsers import JSONParser
from django.http.response import JsonResponse
from django.core.files.storage import default_storage

from EmployeeApp.models import Departments,Employees
from EmployeeApp.serializers import DepartmentSerializer,EmployeeSerializer

# Create your views here.
#Let write our Api method for department screen. The Api method will receive an optional Id
# which we will be using in delete method to delete a record based on Id.
@csrf_exempt
def departmentApi(request,id=0):
    if request.method=='GET':
        departments = Departments.objects.all()
        departments_serializer = DepartmentSerializer(departments,many=True)
        return JsonResponse(departments_serializer.data, safe=False)

    elif request.method=='POST':
        department_data=JSONParser().parse(request)
        department_serializer = DepartmentSerializer(data=department_data)
        if department_serializer.is_valid():
           department_serializer.save()
           return JsonResponse("Added Successfully",safe=False) 
        return JsonResponse("Failed to Add.",safe=False)
    elif request.method == 'PUT':
        department_data = JSONParser().parse(request)
        department = Departments.objects.get(DepartmentId = department_data['DepartmentId'])
        department_serializer = DepartmentSerializer(department, data = department_data)
        if department_serializer.is_valid():
            department_serializer.save()
            return JsonResponse("Updated Successfully",safe=False)
        else:
            return JsonResponse("Failed to Update record.", safe=False)   
    elif request.method =='DELETE':
        department = Departments.objects.get(DepartmentId=id)
        department.delete()
        return JsonResponse("Record Successfully Deleted.", safe=False)       

@csrf_exempt
def employeeApi(request,id=0):
    if request.method=='GET':
        employees = Employees.objects.all()
        employees_serializer = EmployeeSerializer(employees,many=True)
        return JsonResponse(employees_serializer.data, safe=False)

    elif request.method =='POST':
        employee_data = JSONParser().parse(request)
        employee_serializer = EmployeeSerializer(data=employee_data)
        if employee_serializer.is_valid():
           employee_serializer.save()
           return JsonResponse("Added Successfully",safe=False)
        else:    
            return JsonResponse("Failed to Add.",safe=False)
            
    elif request.method == 'PUT':
        employee_data = JSONParser().parse(request)
        employee = Employees.objects.get(EmployeeId=employee_data['EmployeeId'])
        employee_serializer = EmployeeSerializer(employee, data = employee_data)
        if employee_serializer.is_valid():
            employee_serializer.save()
            return JsonResponse("Updated Successfully",safe=False)
        else:
            return JsonResponse("Failed to Update record.", safe=False)   
    elif request.method =='DELETE':
        employee = Employees.objects.get(EmployeeId=id)
        employee.delete()
        return JsonResponse("Record Successfully Deleted.", safe=False)   

@csrf_exempt
def SaveFile(request):
    file = request.FILES['myFile']
    file_name = default_storage.save(file.name,file)

    return JsonResponse(file_name,safe=False)

