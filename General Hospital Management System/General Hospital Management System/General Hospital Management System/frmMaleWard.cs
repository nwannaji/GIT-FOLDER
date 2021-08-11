using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class frmMaleWard : Form
    {
        ClsInsert varInsert = new ClsInsert();
        ClsSelect select = new ClsSelect();
        ClsUpdate update = new ClsUpdate();
        ErrorProvider err = new ErrorProvider();

        public frmMaleWard()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validateNumberOfMalePatients(tbNOMpatients);
            validateMalePatientBill(tbmalePbill);
            varInsert.InserIntoMaleWard(tbpatID.Text.Trim(), cbWardName.Text.Trim(), tbNOMpatients.Text.Trim(),Convert.ToDecimal(tbmalePbill.Text.Trim(), CultureInfo.CurrentCulture));
            clearAllControls();
            clearErrorProviderIcon();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void validateNumberOfMalePatients(Control contrl)
        {
            if (string.IsNullOrEmpty(tbNOMpatients.Text.Trim()) || string.IsNullOrWhiteSpace(tbNOMpatients.Text.Trim()))
            {
                err.SetError(tbNOMpatients, "select a value!");
                return;
            }
            else
            {
                err.SetError(tbNOMpatients, string.Empty);
            }
        }
        void validateMalePatientBill(Control contrl)
        {
            if (string.IsNullOrEmpty(tbmalePbill.Text.Trim()) || string.IsNullOrWhiteSpace(tbmalePbill.Text.Trim()))
            {
                err.SetError(tbmalePbill, "select a value!");
                return;
            }
            else
            {
                err.SetError(tbmalePbill, string.Empty);
            }
        }

        private void tbNOMpatients_TextChanged(object sender, EventArgs e)
        {
            validateNumberOfMalePatients((Control)sender);
        }

        private void tbNOMpatients_Leave(object sender, EventArgs e)
        {
            validateNumberOfMalePatients((Control)sender);
        }

        private void tbmalePbill_TextChanged(object sender, EventArgs e)
        {
            validateMalePatientBill((Control)sender);

        }

        private void tbmalePbill_Leave(object sender, EventArgs e)
        {
            validateMalePatientBill((Control)sender);
        }

        void clearAllControls()
        {
            tbpatID.ResetText();
            cbWardName.ResetText();
            tbNOMpatients.ResetText();
            tbmalePbill.ResetText();
        }
       void clearErrorProviderIcon()
        {
            err.SetError(tbpatID, string.Empty);
            err.SetError(cbWardName, string.Empty);
            err.SetError(tbNOMpatients, string.Empty);
            err.SetError(tbmalePbill, string.Empty);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ReadMaleWard();
        }
        public void ReadMaleWard()
        {
            string connectionString = @"Data Source =localhost;Initial Catalog =dbGHMS; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select patID,maleWard,NumOfPeople,Bill from tblMaleWard where patID = " + tbpatID.Text.Trim() + "", con))
                {
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        tbpatID.Text = rd["patID"].ToString();
                        cbWardName.Text = rd["maleWard"].ToString();
                        tbNOMpatients.Text = rd["NumOfPeople"].ToString();
                        tbmalePbill.Text = rd["Bill"].ToString();
                    }
                }
            }
        }
    }

}
