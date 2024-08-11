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

public partial class AddCategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        BindCategoryRepeater();

        }

    }

    private void BindCategoryRepeater()
    {
        String cs = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategory", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable CatTable = new DataTable();
                    sda.Fill(CatTable);
                    CategoryRepeater.DataSource = CatTable;
                    CategoryRepeater.DataBind();

                }
            }

        }
    }

    protected void btnAddCategories_Click(object sender, EventArgs e)
    {
        String cs = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tblCategory VALUES('" + tbAddCategories.Text + "') ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            tbAddCategories.Text = string.Empty;
            lblmsg.Text = "Success";
            lblmsg.ForeColor = Color.Green;

        }

    }

   
}