using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace General_Hospital_Management_System
{
    public partial class frmFemaleWard : Form
    {
        ClsInsert varInsert = new ClsInsert();
        ClsSelect select = new ClsSelect();
        ErrorProvider err = new ErrorProvider();
        public frmFemaleWard()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ValidateNumberOfFemalePatient(tbNOFpatients);
            validatePatientStatus(tbfpBill);
            if(err.GetError(tbNOFpatients).Length != 0)
            {
                err.SetError(tbNOFpatients,"Please provide a value");
            }
            else if(err.GetError(tbfpBill).Length != 0)
            {
                    err.SetError(tbfpBill,"Please provide a value!");
            }
            else
            {
            varInsert.InsertIntoFemaleWard(tbpatId.Text.Trim(), cbWardName.Text.Trim(), tbNOFpatients.Text.Trim(),Convert.ToDecimal(tbfpBill.Text.Trim(),CultureInfo.CurrentCulture));

            }


        }
        void ValidateNumberOfFemalePatient(Control ctrl)
        {
            if (string.IsNullOrEmpty(tbNOFpatients.Text) || string.IsNullOrWhiteSpace(tbNOFpatients.Text))
            {
                err.SetError(tbNOFpatients, "Please provide patient Height");
                return;
            }
            else
            {
                err.SetError(tbNOFpatients, string.Empty);
            }
        }
        void validatePatientStatus(Control sender)
        {
            if (string.IsNullOrEmpty(tbfpBill.Text) || string.IsNullOrWhiteSpace(tbfpBill.Text))
            {
                err.SetError(tbfpBill, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbfpBill, string.Empty);
            }
        }

        private void tbNOpatients_TextChanged(object sender, EventArgs e)
        {
            ValidateNumberOfFemalePatient((Control)sender);
        }

        private void tbNOpatients_Leave(object sender, EventArgs e)
        {
            ValidateNumberOfFemalePatient((Control)sender);
        }

        private void frmFemaleWard_Load(object sender, EventArgs e)
        {
           
        }

        private void btnReadWard_Click(object sender, EventArgs e)
        {
            ReadFemaleWard();
        }
        public void ReadFemaleWard()
        {
             string connectionString = @"Data Source =localhost;Initial Catalog =dbGHMS; Integrated Security = True";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("select patID,WardName,NumOfPeople,Bill from tblFemaleWard where patID = "+tbpatId.Text.Trim()+"", con))
                {
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        tbpatId.Text = rd["patID"].ToString();
                        cbWardName.Text = rd["WardName"].ToString();
                        tbNOFpatients.Text = rd["NumOfPeople"].ToString();
                        tbfpBill.Text = rd["Bill"].ToString();
                    }
                }
            }
        }
    }
}
