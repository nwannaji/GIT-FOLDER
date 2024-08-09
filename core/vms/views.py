from django.shortcuts import render
from django.http import HttpResponse
from vms.models import Visitor
from vms.models import Employee

# Create your views here.

def index(request):
    return HttpResponse('About to implement front-end')




