
import os
import json
from urllib.error import HTTPError
from django.http import HttpResponse
from django.shortcuts import get_object_or_404, redirect
import qrcode
import random
import string
import logging
import requests
import pyrebase
from core import settings
from setuptools.command.build import build


# from vms.myViews import test_api_request
from .models import Employee, Visitor
from django.conf import settings

from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText
from email.mime.image import MIMEImage
import base64

# from googleapiclient.discovery import build
from httplib2 import Http
from oauth2client.service_account import ServiceAccountCredentials


# sg = sendgrid.SendGridAPIClient(api_key=os.environ.get(settings.vms_api))
# Initialize Firebase
firebase = pyrebase.initialize_app(settings.FIREBASE_CONFIG)
storage = firebase.storage()
logger = logging.getLogger(__name__)

def get_chart():
     
        # Retrieve all visitors
        visitors = Visitor.objects.all()       
        # Calculate visitor count per department
        department_counts = {}
        total_visitors = 0
        for visitor in visitors:
            dept_name = visitor.get_dept_name()
            if dept_name in department_counts:
                department_counts[dept_name] += 1
            else:
                department_counts[dept_name] = 1
            total_visitors += 1
        
        # Calculate percentage of visitors to each department
        department_percentages = {}
        for dept_name, count in department_counts.items():
            percentage = (count / total_visitors) * 100
            department_percentages[dept_name] = round(percentage, 2)

        # Serialize department_percentages to JSON
        department_percentages_json = json.dumps(department_percentages)
        return department_percentages_json

def generate_qr_code(visitor,name):
    # Generate QR code content based on visitor information
    qr_code_content = (
        f"Name: {visitor.visitor_name}\n"
        f"Mobile: {visitor.phone_number}\n"
        f"Email: {visitor.email_address}\n"
        f"Host Employee: {Employee.objects.get(employee_name=name)}\n"  # Come back to fix this
        f"Department: {visitor.dept}\n"
        f"Organization: {visitor.organization}"
    )  
    # Create a QR code image
    qr = qrcode.QRCode(
        version=1,
        error_correction=qrcode.constants.ERROR_CORRECT_L,
        box_size=10,
        border=4,
    )
    qr.add_data(qr_code_content)
    qr.make(fit=True)

    # Generate QR code image file name
    qr_code_file_name = f"{visitor.visitor_name}_qr_code.png"

    # Define the directory to save QR codes
    qr_code_directory = "static/qr_codes/"
    
    # Ensure the directory exists, create if it doesn't
    os.makedirs(qr_code_directory, exist_ok=True)

    # Generate the file path to save the QR code
    qr_code_path = os.path.join(qr_code_directory, qr_code_file_name)

    # Save the QR code image
    qr.make_image(fill_color="black", back_color="white").save(qr_code_path)

    return qr_code_path

def generate_otp(visitor):
    # Generate a random OTP
    otp = ''.join(random.choices(string.ascii_letters + string.digits, k=6))
    return otp

# Assuming credentials are stored securely (e.g., Django settings)
def get_credentials():
  """Fetches authorized credentials for Gmail API."""
  scopes = ['https://www.googleapis.com/auth/gmail.send']
  credentials_file = "vms\\credentials.json"
  credentials = ServiceAccountCredentials.from_json_keyfile_name(credentials_file, scopes)
  return credentials

def build_email_message(sender_email, visitor, subject, body):
  """Constructs a MIME message object for sending email with QR code attachment."""
  message = MIMEMultipart()
  message['From'] = sender_email
  message['To'] = visitor.mobile
  message['Subject'] = subject
  message.attach(MIMEText(body, 'plain'))  # Set content type as plain text

  # Generate QR code (assuming visitor data is available)
  qr_code_path = generate_qr_code(visitor)  # Replace 'visitor' with your visitor data access

  # Check if QR code was generated successfully
  if qr_code_path:
    # Read QR code image data
    with open(qr_code_path, 'rb') as f:
      qr_code_data = f.read()

    # Prepare attachment data
    attachment_data = {
      'content_type': 'image/png',  # Set content type for PNG image
      'data': qr_code_data,
      'encoding': 'base64'  # Assuming base64 encoding for image data
    }

    # Attach QR code image
    image_part = MIMEImage(attachment_data['data'], attachment_data['content_type'], attachment_data['encoding'])
    image_part.add_header('Content-Disposition', 'attachment; filename="qr_code.png"')
    message.attach(image_part)

  return message.as_string().encode('utf-8')
    
    
def upload_qr_code_to_firebase(img_name, img_data):
    try:
        # Define the path for the image in Firebase Storage
        image_path = f'qr_Code_Images/{img_name}'

        # Upload the image data to Firebase Storage
        path = storage.child(image_path).put(img_data)

        # Get the public URL of the uploaded image
        public_url = storage.child(image_path).get_url(None)
        global URL 
        URL =public_url
    except Exception as e:
        # Handle any exceptions and raise them
        raise e

def send_visitor_whatsApp_message(visitor,path):
   # Replace with your eBulkSMS credentials
    username = "tidnigcomsat@gmail.com"  
    api_key = "d017cf5340ae6c0b2a0db7cc04a6252f905abc3c"
    # Recipient phone number (including country code)
    recipient = visitor.phone_number

    # Subject (not shown to recipient)
    subject = "Visitors Mgt Team"
    qr_code_path = URL
    if qr_code_path:
        # Your message content (up to 4000 characters)
        message = f"""
        Dear {visitor.visitor_name},
        This email is sent to you because you have indicated your interest to visit {visitor.dept} of NigComSat LTD.
        A QR Code image embedded with your basic details is available at the following link:{qr_code_path}\n.
        Please make sure that the image is available for scan at the entrance of your host.
        Thanks,
        NigComSat Visitors Mgt Team.
        """
        # Construct the JSON data
        data ={"WA": {
        "auth":{
            "username": username,
            "apikey": api_key,
            },
            "message":{
                "subject": subject,
                "messagetext": message,
            },
            "recipients":[
                recipient
            ]     
            }
            }
            # Set the headers
        headers = {"Content-Type": "application/json"}
        # Send the POST request
        url = "https://api.ebulksms.com/sendwhatsapp.json"
        response = requests.post(url, headers=headers, json=data)
        # Check for successful response
        if response.status_code == 200:
            print("Message sent successfully!")
        else:
            print(f"Error sending message: {response.text}")

def send_employee_whatsApp_message(employee, visitor):
    # Replace with your eBulkSMS credentials
    username = "tidnigcomsat@gmail.com"
    api_key = "d017cf5340ae6c0b2a0db7cc04a6252f905abc3c"

    # Recipient phone number (including country code)
    recipient = employee.phone_number

    # Subject (not shown to recipient)
    subject = "Visitor Request Notification"

    # Your message content
    msg = f"""
    Dear, {employee.employee_name}
    This is to inform you that {visitor.visitor_name} with mobile number { visitor.phone_number } from {visitor.organization} has requested to visit you in the {employee.dept_name} department.
    Please, if this visit is convenient for you, log into the VMS portal: 127.0.0.1:8000/checkIn/ to approve it by inserting and submitting the visitor's ID in the page below. 
    Else, click on the Decline button below to reject the visit.
    Thanks,
    NigComSat Visitors Mgt Team.
    """
    # Construct the JSON data
    data = {
        "WA": {
            "auth": {
                "username": username,
                "apikey": api_key, 
            },
            "message": {
                "subject": subject,
                "messagetext": msg,
            },
            "recipients": [
                recipient
            ]
        }
    }

    # Set the headers
    headers = {"Content-Type": "application/json"}

    # Send the POST request
    url = "https://api.ebulksms.com/sendwhatsapp.json"
    response = requests.post(url, headers=headers, json=data)

    # Check for successful response
    if response.status_code == 200:
        print("Message sent successfully!")
    else:
        print(f"Error sending message: {response.text}")

def reject_visit(request, visitor_id):
    # Fetch the visitor details based on visitor_id
    visitor = get_object_or_404(Visitor, id=visitor_id)
    
    # Send decline message
    send_approved_or_decline_visit(visitor, 'DECLINED')
    
    return HttpResponse("Your visit has been declined.")

def send_approved_or_decline_visit(visitor,visit_status):
      # Replace with your eBulkSMS credentials
    username = "tidnigcomsat@gmail.com"
    api_key = "d017cf5340ae6c0b2a0db7cc04a6252f905abc3c"

    recipient = visitor.phone_number
     # Subject (not shown to recipient)
    subject = "Visitors Mgt Team"

    # Determine message content based on visit status
    if visit_status.upper() == 'APPROVED':
        message = f"""Dear {visitor.visitor_name},\n\nYour visit to {visitor.dept} of NigComSat LTD has been approved.\n\nPlease ensure that you follow all necessary protocols.\n\nThanks,\nNigComSat Visitors Mgt Team"""
    elif visit_status.upper() == 'DELINED':
        message = f"""Dear {visitor.visitor_name},\n\nWe regret to inform you that your visit to {visitor.dept} of NigComSat LTD has been declined.\n\nIf you believe this is a mistake, please contact us.\n\nThanks,\nNigComSat Visitors Mgt Team"""
    else:
        raise ValueError('Invalid visit status. Must be "APPROVED" or "DECLINED".')
    
    # Construct the JSON data
    data = {
        "WA": {
            "auth": {
                "username": username,
                "apikey": api_key,
            },
            "message": {
                "subject": subject,
                "messagetext": message,
            },
            "recipients": [
                recipient
            ]
        }
    }
    # Set the headers
    headers = {"Content-Type": "application/json"}

    # Send the POST request
    url = "https://api.ebulksms.com/sendwhatsapp.json"
    response = requests.post(url, headers=headers, json=data)

    # Check for successful response
    if response.status_code == 200:
        print(f"Message sent successfully to {recipient}!")
    else:
        print(f"Error sending message to {recipient}: {response.text}")
    




