using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;
using System.Net;

public partial class ForgotPassword : System.Web.UI.Page
{
    static string Encrypt(string values)
    {
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] data = md5.ComputeHash(utf8.GetBytes(values));
            return Convert.ToBase64String(data);
        }
    }
    String conn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
    public void Page_Load(object sender, EventArgs e)
    {
        //Timer Timer1 = new Timer();
        //Timer1.Enabled = true;
        //lblSent.Text = "Success";
        //Timer1.Interval = 2000;

    }
    

    protected void btnPassRec_Click(object sender, EventArgs e)
    {
        
        using (SqlConnection sqlconn = new SqlConnection(conn))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = '"+tbemailAddress.Text+"'",sqlconn);
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                String myGUID = Guid.NewGuid().ToString();
                int uid = Convert.ToInt32(dt.Rows[0][0].ToString());
                SqlCommand command = new SqlCommand("INSERT INTO ForgotPasswordRequest VALUES('"+ myGUID + "','"+uid+"',getdate())",sqlconn);
                command.ExecuteNonQuery();

                //send an Email
                String ToEmailAddress = dt.Rows[0][3].ToString();
                String Username = dt.Rows[0][1].ToString();
                String Emailbody = "Hi "+Username+ ",<br/><br/> Click the link below to reset your password <br/><br/> http://localhost:55531/RecoverPassword.aspx?uid="+myGUID;
                MailMessage passwordRecoverymail = new MailMessage("edenwannaji1980@gmail.com", ToEmailAddress);
                passwordRecoverymail.Body = Emailbody;
                passwordRecoverymail.IsBodyHtml = true;
                passwordRecoverymail.Subject = "Reset your password";

                SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                SMTP.Credentials = new NetworkCredential()
                {
                    UserName = "edenwannaji1980@gmail.com",
                    Password = "nwannaji1980"
                };
                SMTP.EnableSsl = true;
                SMTP.Send(passwordRecoverymail);

                lblSent.Text = "Check your email to reset your password.";
                lblSent.ForeColor = Color.Green;
            }
            else
            {
                lblSent.Text = "OOPS This email does not exist in the Database.!";
                lblSent.ForeColor = Color.Red;
            }
        }
        tbemailAddress.Text = string.Empty;
        
    }
}