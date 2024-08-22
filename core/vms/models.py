
from django .utils.timezone import now
from django.db import models

class Employee(models.Model):
    employee_id = models.AutoField(primary_key=True)
    employee_name = models.CharField(max_length=200, verbose_name='Employee Name')
    dept_name = models.CharField(max_length=100, verbose_name='Department Name')
    unit = models.CharField(max_length=100, blank=True, null=True)
    date_of_employment = models.DateTimeField(default=now, blank=True, null=True, verbose_name='Date of Employment')
    email_address = models.EmailField(max_length=150, unique=True, verbose_name='Email Address', help_text='Please use your official email address.')
    phone_number = models.CharField(max_length=15, unique=True, help_text='Please type your mobile number.')
    is_Admin = models.BooleanField(default=False, verbose_name='Is Admin?')
    is_contract_staff = models.BooleanField(default=False, blank=True, null=True, verbose_name='Contract staff?')

    # def __str__(self) -> str:
    #     return self.employee_name

    def list_employees(self):
        return ', '.join([employee.employee_name for employee in self.employees.all()])

class Visitor(models.Model):
    visitor_id = models.AutoField(primary_key=True)
    visitor_name = models.CharField(max_length=150, verbose_name='Visitor Name')
    phone_number = models.CharField(max_length=15, unique=True, verbose_name="Phone Number", help_text="Phone number")
    email_address = models.EmailField(max_length=200, unique=True, verbose_name='Email Address', help_text='Please provide a valid email address')
    qr_code = models.CharField(max_length=250, blank=True, null=True, verbose_name='QR Code')
    otp = models.IntegerField(default=0, blank=True, null=True)
    organization = models.CharField(max_length=250, blank=True, null=True)
    dept = models.CharField(max_length=150, blank=True, verbose_name='Department(s) to Visit')
    whom_to_see = models.ManyToManyField(Employee, related_name='visitor')
    is_official = models.BooleanField(default=False, verbose_name='Official?')
    comments = models.TextField(blank=True, null=True)
    is_invited = models.BooleanField(default=False, blank=True, null=True, verbose_name="Invited?")
    first_timer = models.BooleanField(default=False, blank=True, null=True, verbose_name='First Timer?')
    date_of_visit = models.DateField(default=now, blank=True, null=False, verbose_name='Date of Visit')

    # def __str__(self) -> str:
    #     return self.visitor_name
    
    # Retrieve the names of employees the visitor wants to see.
    def get_employee_name(self):
         return ','.join([ employee.employee_name for employee in self.whom_to_see.all()])
    
    # Retrieve the departments of employees the visitor wants to see.
    def get_department_name(self):
         return ', '.join([employee.dept for employee in self.whom_to_see.all()])

    
class Pending_Visitor(models.Model):
    id = models.AutoField(primary_key=True)
    name = models.ForeignKey(Visitor, on_delete=models.CASCADE, related_name='Pending_Visitor')
    status_choices = [
        ('PENDING', 'Pending Approval'),
        ('APPROVED', 'Approved'),
    ]
    status = models.CharField(max_length=10, choices=status_choices, default='PENDING')


    def __str__(self) -> str:
        return self.name

class CheckIn_Visitor(models.Model):
    id = models.AutoField(primary_key=True)
    visitor_name = models.ForeignKey(Visitor, on_delete=models.CASCADE, related_name='Visitor_To_CheckIn')
    time_In = models.DateTimeField()
    time_Out = models.DateTimeField()
    is_pending = models.BooleanField(default=True)
    is_approved = models.BooleanField(default=False)
    approved_by = models.CharField(max_length=150,blank=True,null=False)

