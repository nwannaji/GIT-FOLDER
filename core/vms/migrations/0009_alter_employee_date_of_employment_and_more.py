# Generated by Django 4.2.11 on 2024-08-07 22:34

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('vms', '0008_alter_employee_date_of_employment'),
    ]

    operations = [
        migrations.AlterField(
            model_name='employee',
            name='date_of_employment',
            field=models.DateTimeField(blank=True, null=True, verbose_name='Date of Emplyment'),
        ),
        migrations.AlterField(
            model_name='employee',
            name='dept_name',
            field=models.CharField(max_length=100, verbose_name='Department Name'),
        ),
        migrations.AlterField(
            model_name='employee',
            name='email_address',
            field=models.CharField(help_text='Please use your official email address.', max_length=150, unique=True, verbose_name='Email Address'),
        ),
        migrations.AlterField(
            model_name='employee',
            name='is_Admin',
            field=models.BooleanField(default=False, verbose_name='Is Admin?'),
        ),
        migrations.AlterField(
            model_name='employee',
            name='is_contract_staff',
            field=models.BooleanField(blank=True, default=False, null=True, verbose_name='Contract staff ?'),
        ),
        migrations.CreateModel(
            name='Visitor',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('visitor_name', models.CharField(max_length=150, verbose_name='Visitor Name')),
                ('phone_number', models.CharField(help_text="Visitor's phone number", max_length=15, unique=True, verbose_name="Visitor's phone number")),
                ('email_address', models.EmailField(help_text='Please provide a valid email address', max_length=200, unique=True, verbose_name='Email Address')),
                ('qr_code', models.CharField(blank=True, max_length=250, null=True, verbose_name='QR Code')),
                ('otp', models.IntegerField(blank=True, default=0, null=True)),
                ('organization', models.CharField(blank=True, max_length=250, null=True)),
                ('whom_To_see', models.CharField(blank=True, max_length=150, null=True, verbose_name='Employee(s) To See')),
                ('is_Official', models.BooleanField(default=False, verbose_name='Official?')),
                ('comments', models.TextField(blank=True, null=True)),
                ('is_Invited', models.BooleanField(blank=True, default=False, null=True, verbose_name='Invited?')),
                ('first_timer', models.BooleanField(blank=True, default=False, null=True, verbose_name='First Timer?')),
                ('date_of_visit', models.DateField(blank=True, null=True)),
                ('dept', models.ManyToManyField(blank=True, null=True, to='vms.employee', verbose_name='Dept(s) To Visit')),
            ],
        ),
    ]