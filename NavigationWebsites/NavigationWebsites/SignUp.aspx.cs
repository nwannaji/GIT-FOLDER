using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsignUp_Click(object sender, EventArgs e)
    {
        if (tbUsername.Text != "" & tbPassword.Text != "" & tbConfirmPassword.Text != "" & tbEmail.Text != "" & tbName.Text != "")
        {
            if (tbPassword.Text == tbConfirmPassword.Text)
            {
                String cs = ConfigurationManager.ConnectionStrings["BootiqueDatabaseConnectionString1"].ConnectionString;
                try {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("insert into tbl_Bootique values('" + tbUsername.Text + "','" + tbPassword.Text + "','" + tbEmail.Text + "','" + tbConfirmPassword.Text + "','" + tbName.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Text = "Record saved successfully";
                    lblMsg.ForeColor = Color.Green;
                    Response.Redirect("~/SignIn.aspx");
                   
                }
                }
                catch (Exception ex) {  }

            }
            else {

                lblMsg.Text = "Password do not match";
                lblMsg.ForeColor = Color.Red;
            }
        }
        else
        {
            
            lblMsg.Text = "All field are mandatory";
            lblMsg.ForeColor = Color.Red;
        }
    }
}