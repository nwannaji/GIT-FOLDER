using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if(Request.Cookies["Uname"]!= null && Request.Cookies["PWD  "]!= null)
            {
                tbUsername.Text = Request.Cookies["Uname"].Value;
                tbPassword.Attributes["value"] = Request.Cookies["PWD"].Value;
                CheckBox1.Checked = true;
            }
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["BootiqueDatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Bootique WHERE Username = '" + tbUsername.Text + "'and Password ='" + tbPassword.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                if (CheckBox1.Checked)
                {
                    Response.Cookies["Uname"].Value = tbUsername.Text;
                    Response.Cookies["PWD"].Value = tbPassword.Text;
                    Response.Cookies["Uname"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(15);

                    
                }
                else
                {
                    Response.Cookies["Uname"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(-1);
                }
                Session["USERNAME"] = tbUsername.Text;
                Response.Redirect("~/userHome.aspx");
            }
            else
            {
                lblError.Text = "Invalid Username or Password";
            }
        }
    }
}