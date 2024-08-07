from datetime import datetime, date
from django.db import models

# Create your models here.
class Employee(models.Model):
    employee_Id = models.IntegerField(primary_key=True,blank=False,null=False, unique=True)
    employee_name = models.CharField(max_length=200,blank=False,null=False, verbose_name='Employee Name')
    dept_name = models.CharField(max_length=100,blank=False,null=False, verbose_name='Department Name')
    unit = models.CharField(max_length=100, blank=True, null=True)
    date_of_employment = models.DateTimeField(blank=True,null=True, verbose_name='Date of Emplyment')
    email_address = models.CharField(max_length=150,unique=True,blank=False,null=False, verbose_name='Email Address', help_text='Please use your official email address.')
    phone_number = models.CharField(max_length=15,unique=True,blank=False, null=False, help_text='Please type your mobile number.')
    is_Admin = models.BooleanField(default=False, verbose_name='Is Admin?')
    is_contract_staff = models.BooleanField(default=False, blank=True, null=True, verbose_name='Contract staff ?')

    def __str__(self) -> str:
        return self.employee_name
    
    def save(self, *args, **kwargs):
        if(self.date_of_employment is None):
            self.date_of_employment = datetime.now()
            formatted_time = self.date_of_employment.strftime("%Y/%m/%d %H:%M:%S")

        super(Employee, self).save(*args,**kwargs)

class Visitor(models.Model):
    visitor_name = models.CharField(max_length=150, blank=False, null=False, verbose_name='Visitor Name')
    phone_number = models.CharField(max_length=15,blank=False,null=False,unique=True,help_text="Visitor's phone number", verbose_name="Visitor's phone number")
    email_address = models.CharField(max_length=200,unique=True,blank=False, null=False, verbose_name='Email Address',
                                       help_text='Please provide a valid email address')
    qr_code = models.CharField(max_length=250,blank=True,null=True, verbose_name='QR Code')
    otp = models.IntegerField(default=0,blank=True,null=True)
    organization = models.CharField(max_length=250, null=True, blank=True)
    dept = models.CharField(max_length=150, blank=True, verbose_name='Dept(s) To Visit')
    whom_To_see = models.ManyToManyField(Employee,blank=True,null=True, verbose_name='Employee(s) To See')
    is_Official = models.BooleanField(default=False, blank=False, null=False, verbose_name='Official?')
    comments = models.TextField(blank=True, null=True)
    is_Invited = models.BooleanField(default=False, blank=True, null=True, verbose_name="Invited?")
    first_timer = models.BooleanField(default=False, blank=True, null=True, verbose_name='First Timer?')
    date_of_visit = models.DateField(auto_now=True, blank=True, null=True)

    def __str__(self) -> str:
        return '{} requested to visit {} in {}'.format(self.visitor_name, Employee.employee_name, Employee.dept_name)
    
    def save(self, *args, **kwargs):
        if(self.date_of_visit is None):
            self.date_of_visit = datetime.now()
            formatted_time = self.date_of_visit.strftime("%Y/%m/%d %H:%M:%S")

            super(Visitor, self).save(*args, **kwargs)


