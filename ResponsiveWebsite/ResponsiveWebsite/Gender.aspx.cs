using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Gender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGenderRepeater();
        }

    }

    private void BindGenderRepeater()
    {

        String conn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblGender", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GenderRepeater.DataSource = dt;
            GenderRepeater.DataBind();
        }
    }

    protected void btnAddGender_Click(object sender, EventArgs e)
    {
        String cs = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand(" INSERT INTO tblGender VALUES('" + tbGender.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            lblGender.Text = "Success";
            lblGender.ForeColor = Color.Green;
            tbGender.Text = string.Empty;
        }
        BindGenderRepeater();

    }
}