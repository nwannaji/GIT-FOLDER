using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProducts : System.Web.UI.Page
{
    public static String cs = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBrands();
            BindCategory();
            BindGender();
        }

    }

    private void BindGender()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblGender", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlGender.DataSource = dt;
            ddlGender.DataTextField = "GenderName";
            ddlGender.DataValueField = "GenderID";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0,new ListItem("-select-", "0"));
        }
    }

    private void BindCategory()
    {
        using (SqlConnection con = new SqlConnection(cs))
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

    private void BindBrands()
    {
        using(SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands",con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                ddlBrands.DataSource = dt;
                ddlBrands.DataTextField = "BrandName";
                ddlBrands.DataValueField = "BrandID";
                ddlBrands.DataBind();
                ddlBrands.Items.Insert(0, new ListItem("-select-", "0"));

            }

        }
      
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

        String conn = ConfigurationManager.ConnectionStrings["eBoutiqueDBConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategory WHERE MainCategoryID = '" + ddlCategory.SelectedItem.Value + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlSub_Category.DataSource = dt;
                ddlSub_Category.DataTextField = "SubCategoryName";
                ddlSub_Category.DataValueField = "SubCategoryID";
                ddlSub_Category.DataBind();
                ddlSub_Category.Items.Insert(0, new ListItem("-select-", "0"));
            }

        }


    }

    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblSize WHERE BrandID = '" + ddlBrands.SelectedItem.Value + "'and SubCategoryID ='" + ddlSub_Category.SelectedItem.Value+ "'and GenderID ='" + ddlGender.SelectedItem.Value +"'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                cblSizes.DataSource = dt;
                cblSizes.DataTextField = "SizeName";
                cblSizes.DataValueField = "SizeID";
                cblSizes.DataBind();
               
            }

        }


    }
}