from django.shortcuts import render
from vms.models import Visitor
from vms.models import Employee

# Create your views here.

def index(request):

    emp = Employee.objects.all()
    context = {
        'emp':emp,
    }
    return render(request,"base.html", context)




