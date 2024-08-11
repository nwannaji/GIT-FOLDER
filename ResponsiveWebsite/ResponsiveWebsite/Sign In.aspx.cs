using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.Data;
using System.Text;

public partial class Sign_In : System.Web.UI.Page
{
    static string Encrypt(string values)
    {
        using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] data = md5.ComputeHash(utf8.GetBytes(values));
            return Convert.ToBase64String(data);
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.Cookies["UNAME"] != null && Request.Cookies["PWD"]!= null)
            {
                Username.Text = Request.Cookies["UNAME"].Value;
                password.Attributes["Value"] = Request.Cookies["PWD"].Value;
                CheckBox1.Checked = true;
            }
        }

    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(password.Text))
        {
            password.Text = Encrypt(password.Text);
             
        }
     String conn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Usename = '" + Username.Text + "' and Password = '" + password.Text + "'",con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count != 0)
            {
                if (CheckBox1.Checked)
                {
                    Response.Cookies["UNAME"].Value = Username.Text;
                    Response.Cookies["PWD"].Value = password.Text;

                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(15);
                }
                else
                {
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(-1);
                }
                string Utype;
                Utype = dt.Rows[0][5].ToString().Trim();
                if (Utype == "U")
                {

                    Session["USERNAME"] = Username.Text;
                    Response.Redirect("~/UserHome.aspx");
                }
                if (Utype == "A")
                {

                    Session["USERNAME"] = Username.Text;
                    Response.Redirect("~/AdminHome.aspx");
                }



            }
            else
            {
                lblErrorMsg.Text = "Invalid Username or Password!";
            }
        }

    }

    }