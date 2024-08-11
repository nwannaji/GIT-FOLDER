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

public partial class SubCategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMainCategory();
            BindSubCatRepeater();
        }

    }

    private void BindSubCatRepeater()
    {
        String cs = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.* FROM tblSubCategory A inner join tblCategory B on B.CategoryID = A.MainCategoryID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable SubCatTable = new DataTable();
                    sda.Fill(SubCatTable);
                    SubCategoryRepeater.DataSource = SubCatTable;
                    SubCategoryRepeater.DataBind();

                }
            }
        }
    }
    private void BindMainCategory()
    {
        String conn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategory", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-select-", "0"));
            }

        }
    }

        protected void btnSubCategories_Click(object sender, EventArgs e)
    {
        String cs = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using(SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tblSubCategory VALUES('"+tbSubCategories.Text+"','"+ddlCategory.SelectedItem.Value+"')",con);
            con.Open();
            cmd.ExecuteNonQuery();
            tbSubCategories.Text = string.Empty;
            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue("0").Selected = true;
            lblmsg.Text = "Success";
            lblmsg.ForeColor = Color.Green;

        }
        BindSubCatRepeater();
    }
}