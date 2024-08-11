using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class frmWard : Form
    {
        ClsSelect selectClass = new ClsSelect();
        ClsInsert varInsert = new ClsInsert();
        SqlDataReader reader;
        public frmWard()
        {
            InitializeComponent();
        }

        private void frmWard_Load(object sender, EventArgs e)
        {

        }

        private void cbWardName_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbWardName.SelectedIndex)
            {
                case 1:
                    femaleward();
                    break;
                case 2:
                    maleward();
                    break;
            }
        }
             // MALE WARD AND PRICE//
             //===================//
        public void femaleward()
        {
            try
            {
                string query = $"SELECT Bill, NumOfPeople from tblFemaleWard WHERE femaleward ='{cbWardName.SelectedItem.ToString()}'";
                SqlConnection con = new SqlConnection(selectClass.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tbNOpatients.Text = double.Parse(reader["Bill"].ToString()).ToString();
                    tbValues.Text = double.Parse(reader["NumOfPeople"].ToString()).ToString();
                }
                con.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void maleward()
        {
            string _query = $"SELECT Bill, NumOfPeople from tblmaleWard WHERE maleWard ='{cbWardName.SelectedItem.ToString()}'";

            try
            {
                SqlConnection con = new SqlConnection(selectClass.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(_query,con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tbNOpatients.Text = double.Parse(reader["Bill"].ToString()).ToString();
                    tbValues.Text = double.Parse(reader["NumOfPeople"].ToString()).ToString();
                }
                con.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (cbWardName.SelectedIndex)
            {
                case 1:
                    updateMaleWard();
                    break;
                case 2:
                    updateFemaleWard();
                    break;
            }
        }

                        //UPDATE FEMALE WARD//
                       //=================//
         void updateMaleWard()
        {
            string updateBillString;
            SqlConnection con;
            try
            {
                con = new SqlConnection(selectClass.connectionString);
                con.Open();
                updateBillString = $"UPDATE tblMaleWard SET NumOfPeople = '{double.Parse(tbNOpatients.Text)}', bill = '{double.Parse(tbValues.Text)}' WHERE maleWard = '{cbWardName.SelectedItem.ToString()}'";
                SqlCommand cmd = new SqlCommand(updateBillString,con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Male Ward updated successfully","GHMS Save-Data",MessageBoxButtons.OK,MessageBoxIcon.Information);
                con.Close();
            }
          
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void updateFemaleWard()
        {
            string _updateBillString;
            SqlConnection con;
            try
            {
                _updateBillString = $"UPDATE tblFemaleWard SET NumOfPeople = '{double.Parse(tbNOpatients.Text)}', bill = '{double.Parse(tbValues.Text)}' WHERE FemaleWard = '{cbWardName.SelectedItem.ToString()}'";
                con = new SqlConnection(selectClass.connectionString);
                SqlCommand cmd = new SqlCommand(_updateBillString, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Female Ward updated successfully","GHMS Save-Data",MessageBoxButtons.OK,MessageBoxIcon.Information);
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
