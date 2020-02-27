using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnWriteTag_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["rfidDBConnectionString1"].ConnectionString;
        try
        {
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblRFIDTag VALUES('" + tbFirstname.Text + "','" + tbMiddlename.Text + "','" + tbLastname.Text + "','" + DropDownListSex.SelectedItem.Text + "','" + tbRFIDTag.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMsg.Text = "Record Saved Succssfully";
                lblMsg.ForeColor = Color.Green;
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }



    protected void btnClearForm_Click(object sender, EventArgs e)
    {
        tbFirstname.Text = string.Empty;
        tbMiddlename.Text = string.Empty;
        tbLastname.Text = string.Empty;
       // DropDownListSex.Text = string.Empty;
        tbRFIDTag.Text = string.Empty;
        lblMsg.Text = string.Empty;
    }

    

    protected void btnReadTag_Click(object sender, EventArgs e)
    {

        string connectionString = ConfigurationManager.ConnectionStrings["rfidDBConnectionString1"].ConnectionString;
        SqlConnection con1 = new SqlConnection(connectionString);
        con1.Open();
        string query = "SELECT Firstname,Middlename,Lastname,Sex,RFIDTag from tblRFIDTag";
        SqlCommand myCommand = new SqlCommand(query, con1);
       // SqlDataReader myReader = null;
        SqlDataReader myReader = myCommand.ExecuteReader();
        while (myReader.Read())
        {
            tbFirstname.Text = (myReader["Firstname"].ToString());
            tbMiddlename.Text = (myReader["Middlename"].ToString());
            tbLastname.Text = (myReader["Lastname"].ToString());
            DropDownListSex.SelectedItem.Text = (myReader["Sex"].ToString());
            tbRFIDTag.Text = (myReader["RFIDTag"].ToString());

            //myReader.Close();




        }
        myReader.Close();
        con1.Close();
    }
}