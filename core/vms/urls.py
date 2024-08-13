
from django.urls import path
from .import views



urlpatterns =[
    path('', views.dashboard, name='dashboard'),
    path('schedule_visitor/', views.schedule_visit, name='schedule_visit'),

]