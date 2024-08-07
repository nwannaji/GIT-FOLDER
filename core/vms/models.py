from datetime import datetime
from django.db import models

# Create your models here.
class Employee(models.Model):
    employee_Id = models.IntegerField(primary_key=True,blank=False,null=False, unique=True)
    employee_name = models.CharField(max_length=200,blank=False,null=False, verbose_name='Employee Name')
    dept_name = models.CharField(max_length=100,blank=False,null=False)
    unit = models.CharField(max_length=100, blank=True, null=True)
    date_of_employment = models.DateTimeField(blank=True,null=True)
    email_address = models.CharField(max_length=150,unique=True,blank=False,null=False, help_text='Please use your official email address.')
    phone_number = models.CharField(max_length=15,unique=True,blank=False, null=False, help_text='Please type your mobile number.')
    is_Admin = models.BooleanField(default=False)
    is_contract_staff = models.BooleanField(default=False, blank=True, null=True, verbose_name='Contract staff')

    def __str__(self) -> str:
        return self.employee_name
    
    def save(self, *args, **kwargs):
        if(self.date_of_employment is None):
            self.date_of_employment = datetime.now()
            formatted_time = self.date_of_employment.strftime("%Y/%m/%d %H:%M:%S")

        super(Employee, self).save(*args,**kwargs)


