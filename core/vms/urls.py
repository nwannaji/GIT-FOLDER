
from django.urls import path
from .import views



urlpatterns =[
    path('', views.dashboard, name='dashboard'),
    path('schedule_visit/', views.schedule_visit, name='schedule_visit'),
    path('checkIn/', views.checkIn , name='checkIn'),
    path('chart/', views.draw_chart, name='chart'),
       path('contact/', views.contact_page, name='contact'),
    path('department-data/', views.get_department_data, name='department_data'),
    

]