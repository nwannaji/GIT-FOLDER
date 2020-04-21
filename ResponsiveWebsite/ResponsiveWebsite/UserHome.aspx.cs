using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["USERNAME"] != null)
        {
            lblSuccess.Text = "Login Success, Welcome " + Session["USERNAME"].ToString()+"";
            // = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold);
        }
        else
        {
            Response.Redirect("~/Sign In.aspx");
        }
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["USERNAME"] = string.Empty;
        Response.Redirect("~/Default.aspx");
    }
}