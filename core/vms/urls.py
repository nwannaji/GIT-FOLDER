
from django.urls import path
from .import views



urlpatterns =[
    path('', views.dashboard, name='dashboard'),
    path('schedule_visit/', views.schedule_visit, name='schedule_visit'),
    path('checkIn/', views.checkIn , name='checkIn'),
    # path('error_page/', views.error_message_page , name='error_page'),
    

]