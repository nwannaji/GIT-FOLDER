# Generated by Django 4.2.11 on 2024-08-13 17:17

from django.db import migrations, models
import django.db.models.deletion
import django.utils.timezone


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Employee',
            fields=[
                ('employee_id', models.AutoField(primary_key=True, serialize=False)),
                ('employee_name', models.CharField(max_length=200, verbose_name='Employee Name')),
                ('dept_name', models.CharField(max_length=100, verbose_name='Department Name')),
                ('unit', models.CharField(blank=True, max_length=100, null=True)),
                ('date_of_employment', models.DateTimeField(blank=True, default=django.utils.timezone.now, null=True, verbose_name='Date of Employment')),
                ('email_address', models.EmailField(help_text='Please use your official email address.', max_length=150, unique=True, verbose_name='Email Address')),
                ('phone_number', models.CharField(help_text='Please type your mobile number.', max_length=15, unique=True)),
                ('is_Admin', models.BooleanField(default=False, verbose_name='Is Admin?')),
                ('is_contract_staff', models.BooleanField(blank=True, default=False, null=True, verbose_name='Contract staff?')),
            ],
        ),
        migrations.CreateModel(
            name='Visitor',
            fields=[
                ('visitor_id', models.AutoField(primary_key=True, serialize=False)),
                ('visitor_name', models.CharField(max_length=150, verbose_name='Visitor Name')),
                ('phone_number', models.CharField(help_text='Phone number', max_length=15, unique=True, verbose_name='Phone Number')),
                ('email_address', models.EmailField(help_text='Please provide a valid email address', max_length=200, unique=True, verbose_name='Email Address')),
                ('qr_code', models.CharField(blank=True, max_length=250, null=True, verbose_name='QR Code')),
                ('otp', models.IntegerField(blank=True, default=0, null=True)),
                ('organization', models.CharField(blank=True, max_length=250, null=True)),
                ('dept', models.CharField(blank=True, max_length=150, verbose_name='Department(s) to Visit')),
                ('is_official', models.BooleanField(default=False, verbose_name='Official?')),
                ('comments', models.TextField(blank=True, null=True)),
                ('is_invited', models.BooleanField(blank=True, default=False, null=True, verbose_name='Invited?')),
                ('first_timer', models.BooleanField(blank=True, default=False, null=True, verbose_name='First Timer?')),
                ('date_of_visit', models.DateTimeField(blank=True, default=django.utils.timezone.now, verbose_name='Date of Appointment')),
                ('whom_to_see', models.ManyToManyField(related_name='visitor', to='vms.employee')),
            ],
        ),
        migrations.CreateModel(
            name='Pending_Visitor',
            fields=[
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('status', models.CharField(choices=[('PENDING', 'Pending Approval'), ('APPROVED', 'Approved')], default='PENDING', max_length=10)),
                ('name', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='Pending_Visitor', to='vms.visitor')),
            ],
        ),
        migrations.CreateModel(
            name='CheckIn_Visitor',
            fields=[
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('time_In', models.DateTimeField()),
                ('time_Out', models.DateTimeField()),
                ('is_pending', models.BooleanField(default=True)),
                ('is_approved', models.BooleanField(default=False)),
                ('approved_by', models.CharField(blank=True, max_length=150)),
                ('visitor_name', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='Visitor_To_CheckIn', to='vms.visitor')),
            ],
        ),
    ]
