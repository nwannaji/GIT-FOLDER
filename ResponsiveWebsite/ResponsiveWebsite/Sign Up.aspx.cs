using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Drawing;



public partial class Sign_Up : System.Web.UI.Page
{
    //Paswword Encryption Algorithm
   static string Encrypt(string value){
     using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] data = md5.ComputeHash(utf8.GetBytes(value));
            return Convert.ToBase64String(data);
        }
    }
    // Button sign-up and Database connection algorithm
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbpassword.Text) || (tbUsername.Text != string.Empty && tbpassword.Text !=string.Empty && tbcPassword.Text !=string.Empty && tbName.Text != string.Empty && tb_eMail.Text != string.Empty))
        {
            if (tbpassword.Text == tbcPassword.Text)
            {
                tbpassword.Text = Encrypt(tbpassword.Text);

                if (CheckBoxAdmin.Checked)
                {
                    String stringConn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(stringConn))
                    {
                        SqlCommand cmd = new SqlCommand("Insert into Users values('" + tbUsername.Text + "','" + tbpassword.Text + "','" + tb_eMail.Text + "','" + tbName.Text + "','A')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Label.Text = "Data Saved successfully";
                        Label.ForeColor = Color.Green;
                        Response.Redirect("~/Sign In.aspx");
                        //response.redirect("~/Sign In.aspx")
                    }

                }
                else
                {
                    String CS = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        CheckBoxAdmin.Visible = false;
                        SqlCommand cmd = new SqlCommand("Insert into Users values('" + tbUsername.Text + "','" + tbpassword.Text + "','" + tb_eMail.Text + "','" + tbName.Text + "','U')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Label.Text = "Data Saved successfully";
                        Label.ForeColor = Color.Green;
                        Response.Redirect("~/Sign In.aspx");
                        //response.redirect("~/Sign In.aspx")
                    }
                }

                
            }
            else
            {
                Label.Text = "Password do not match";
                Label.ForeColor = Color.Red;
            }
            
        }
        else
        {
            Label.Text = "All fields are mandatory";
            Label.ForeColor = Color.Red;
        }
  // Clear Sign-up forms after data is saved in the database
        tbUsername.Text =string.Empty;
        tbpassword.Text = string.Empty;
        tb_eMail.Text = string.Empty;
        tbcPassword.Text = string.Empty;
        tbName.Text = string.Empty;
     
    }

}
