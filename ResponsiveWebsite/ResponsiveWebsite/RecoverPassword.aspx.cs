using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Drawing;

public partial class RecoverPassword : System.Web.UI.Page
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


    String cs = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
    String GUIDValue;
    DataTable dt = new DataTable();
    int Uid;

    protected void Page_Load(object sender, EventArgs e)
    {
        using(SqlConnection conn = new SqlConnection(cs))
        {
            GUIDValue = Request.QueryString["uid"];
             if (GUIDValue != null)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ForgotPasswordRequest WHERE id = '" + GUIDValue + "'", conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                Uid = Convert.ToInt32(dt.Rows[0][1]);

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        if (!IsPostBack)
        {
            if(dt.Rows.Count != 0)
            {
                tbResetPassword.Visible = true;
                tbConfirmPassword.Visible = true;
                lblResetpassword.Visible = true;
                lblConfirmPassword.Visible = true;
                btnRecPass.Visible = true;
                
            }
            else
            {
                lblMsg.Text = "Your password is Expired or Invlid!";
                lblMsg.ForeColor = Color.Red;
            }
        }

    }

    protected void btnRecPass_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbResetPassword.Text))
        {
            tbResetPassword.Text = Encrypt(tbResetPassword.Text);
        }
        using(SqlConnection connection = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("Update Users set password = '"+tbResetPassword.Text+"' where Id ='"+Uid+"'",connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            lblResetMsg.Text = "Reset done.";
            lblResetMsg.ForeColor = Color.Red;
        }

    }
}