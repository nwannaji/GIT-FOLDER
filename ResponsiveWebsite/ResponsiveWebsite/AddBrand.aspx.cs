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

public partial class AddBrand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBrandRepeater();
        }

    }

    private void BindBrandRepeater()
    {
        String cs = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands",con))
            {
                using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable BrandTable = new DataTable();
                    sda.Fill(BrandTable);
                    BrandRepeater.DataSource = BrandTable;
                    BrandRepeater.DataBind();
                }

            }
        }

        }

    protected void btnAddBrandName_Click(object sender, EventArgs e)
    {
        String cs = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using(SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tblBrands VALUES('"+tbAddBrandName.Text+"') ",con);
            con.Open();
            cmd.ExecuteNonQuery();
            tbAddBrandName.Text = string.Empty;
            lblmsg.Text = "Success";
            lblmsg.ForeColor = Color.Green;

        }
        
         
    }
    
}