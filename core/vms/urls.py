
from django.urls import path
from .import views



urlpatterns =[
    path('', views.dashboard, name='dashboard'),
    path('schedule_visit/', views.schedule_visit, name='schedule_visit'),
    path('checkIn/', views.check_in , name='checkIn'),
    path('chart/', views.draw_chart, name='chart'),
    path('contact/', views.contact_page, name='contact'),
    path('department-data/', views.get_department_data, name='department_data'),
    path('update-checkIn/', views.update_checkin_visitor_model, name='update_checkIn'),
    path('approve-decline-visit/', views.approve_decline_visit, name='approve_decline'),
    path('fetch_employees/', views.fetch_employees, name='fetch_employees'),
    

]