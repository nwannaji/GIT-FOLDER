using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class frmViewPatient : Form
    {
        ClsSelect select = new ClsSelect();
        public frmViewPatient()
        {
            InitializeComponent();
        }

        private void frmViewPatient_Load(object sender, EventArgs e)
        {
            select.viewPatient(dataGridView1);
        }

        private void btnViewPatient_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string firstname, surname, middlename;
             if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                label9.Text = row.Cells[0].Value.ToString();
                select.selectImage(label9.Text, picBoxVpat);
                firstname = row.Cells[1].Value.ToString();
                surname = row.Cells[2].Value.ToString();
                middlename = row.Cells[3].Value.ToString();
                tbpatFullname.Text = firstname + " " + middlename + " " + surname;
                tbOccupation.Text = row.Cells[5].Value.ToString();
                tbResidenceAd.Text = row.Cells[7].Value.ToString();
                tbCountry.Text = row.Cells[8].Value.ToString();
                tbpatPhoneNumber.Text = row.Cells[9].Value.ToString();
                tbEmailAddress.Text = row.Cells[10].Value.ToString();
                tbRefName.Text = row.Cells[13].Value.ToString();
                tbRefPhone.Text = row.Cells[14].Value.ToString();
                //Disable the TextBoxes//
                tbpatFullname.Enabled = false;
                tbOccupation.Enabled = false;
                tbResidenceAd.Enabled = false;
                tbCountry.Enabled = false;
                tbpatPhoneNumber.Enabled = false;
                tbEmailAddress.Enabled = false;
                tbRefName.Enabled = false;
                tbRefPhone.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnViewPatVitals_Click(object sender, EventArgs e)
        {
            frmPatientVitals frmpatvitals = new frmPatientVitals();
            frmpatvitals.Show();
        }

        private void btnupdatePat_Click(object sender, EventArgs e)
        {
            frmUpdatePatient frmupdatePat = new frmUpdatePatient();
            frmupdatePat.Show();
        }
    }
}
