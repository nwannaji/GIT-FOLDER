# Generated by Django 4.2.11 on 2024-08-08 23:06

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('vms', '0006_rename_employees_employee_whom_to_see'),
    ]

    operations = [
        migrations.RemoveField(
            model_name='employee',
            name='whom_to_see',
        ),
        migrations.RemoveField(
            model_name='visitor',
            name='whom_to_see',
        ),
        migrations.AddField(
            model_name='visitor',
            name='whom_to_see',
            field=models.ManyToManyField(related_name='visitor', to='vms.employee'),
        ),
    ]