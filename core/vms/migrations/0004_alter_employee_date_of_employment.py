# Generated by Django 4.2.11 on 2024-08-07 12:59

import datetime
from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('vms', '0003_rename_is_admin_employee_is_admin_and_more'),
    ]

    operations = [
        migrations.AlterField(
            model_name='employee',
            name='date_of_employment',
            field=models.DateTimeField(blank=True, default=datetime.datetime(2024, 8, 7, 12, 59, 38, 539706, tzinfo=datetime.timezone.utc), null=True),
        ),
    ]