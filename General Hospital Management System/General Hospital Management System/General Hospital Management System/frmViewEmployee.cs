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
    public partial class frmViewEmployee : Form
    {
        ClsSelect select = new ClsSelect();
        public frmViewEmployee()
        {
            InitializeComponent();
        }

        private void frmViewEmployee_Load(object sender, EventArgs e)
        {
            select.viewEmployee(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Surname, Firstname, Middlename;

            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                label1.Text = row.Cells[0].Value.ToString();
                select.SelectImageFromEmployee(label1.Text, picViewEmployee);

                Surname = row.Cells[1].Value.ToString();
                Firstname = row.Cells[2].Value.ToString();
                Middlename = row.Cells[3].Value.ToString();
                tbFullname.Text = Firstname + " " + Middlename + " " + Surname;
                tbPhoneNumber.Text = row.Cells[6].Value.ToString();
                tbEmailAddress.Text = row.Cells[7].Value.ToString();
                tbDept.Text = row.Cells[10].Value.ToString();
                tbQualification.Text = row.Cells[12].Value.ToString();
                tbResidenceAd.Text = row.Cells[13].Value.ToString();
                tbReferenceName.Text = row.Cells[14].Value.ToString();
                tbReferencePhoneNumber.Text = row.Cells[15].Value.ToString();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
