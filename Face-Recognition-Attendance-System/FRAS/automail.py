import yagmail
import os
import datetime
date = datetime.date.today().strftime("%B %d, %Y")
path = 'Attendance'
os.chdir(path)
files = sorted(os.listdir(os.getcwd()), key=os.path.getmtime)
newest = files[-1]
filename = newest
sub = "Attendance Report for " + str(date)
# mail information
yag = yagmail.SMTP("edenwannaji1980@gmail.com", "oglwzsztfjhomdeo")

# sent the mail
yag.send(
    to="edenwannaji1980@gmail.com",
    subject="Wife Tracking You", # email subject
    contents="Your wife employ the services of the FBI to track you. Be careful",  # email body
    attachments= "C:\\Users\\Henrio\\Pictures\\Saved Pictures\\pix_henry.jpg"  # file attached
)
print("Email Sent!")
