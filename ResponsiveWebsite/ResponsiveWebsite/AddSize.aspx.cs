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

public partial class AddSize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBrand();
            BindMainCategory();
            BindGender();
            BindAddSizesRepeater();
        }

    }

    private void BindAddSizesRepeater()
    {
        String conn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblSize", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtAddSizes = new DataTable();
            sda.Fill(dtAddSizes);
            AddSizesRepeater.DataSource = dtAddSizes;
            AddSizesRepeater.DataBind();
        }
    }

    private void BindGender()
    {
        String conn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblGender", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlGender.DataSource = dt;
                ddlGender.DataTextField = "GenderName";
                ddlGender.DataValueField = "GenderID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("-select-", "0"));
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
            if (dt.Rows.Count != 0)
            {
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-select-", "0"));
            }

        }
    }

    private void BindBrand()
    {
        String conn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlBrand.DataSource = dt;
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-select-", "0"));
            }

        }
    }

    protected void btnAddSizes_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using(SqlConnection connection = new SqlConnection(CS))
        {
            SqlCommand command = new SqlCommand("INSERT INTO tblSize VALUES('"+tbSizeName.Text+"','"+ddlBrand.SelectedItem.Value+"','"+ddlCategory.SelectedItem.Value+"','"+ddlSubCat.SelectedItem.Value+"','"+ddlGender.SelectedItem.Value+"')",connection);
            connection.Open();
            command.ExecuteNonQuery();
            tbSizeName.Text = string.Empty;
            ddlBrand.ClearSelection();
            ddlBrand.Items.FindByValue("0").Selected = true;
            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue("0").Selected = true;
            ddlSubCat.ClearSelection();
            ddlSubCat.Items.FindByValue("0").Selected = true;
            ddlGender.ClearSelection();
            ddlGender.Items.FindByValue("0").Selected = true;

            lblAddSizes.Text = "Success";
            lblAddSizes.ForeColor = Color.Green;
        }
        BindAddSizesRepeater();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

        String conn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategory WHERE MainCategoryID = '"+ddlCategory.SelectedItem.Value+"'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlSubCat.DataSource = dt;
                ddlSubCat.DataTextField = "SubCategoryName";
                ddlSubCat.DataValueField = "SubCategoryID";
                ddlSubCat.DataBind();
                ddlSubCat.Items.Insert(0, new ListItem("-select-", "0"));
            }

        }

    }
}