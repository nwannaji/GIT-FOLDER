
from django.urls import path
from .import views



urlpatterns =[
    path('', views.dashboard, name='dashboard'),
    # path('create_visitor/', views.create_visitor, name='create_visitor'),

]