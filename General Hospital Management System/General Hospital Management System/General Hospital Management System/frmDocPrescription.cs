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
    public partial class frmDocPrescription : Form
    {
        ClsSelect select = new ClsSelect();
        public frmDocPrescription()
        {
            InitializeComponent();
        }

        private void frmDocPrescription_Load(object sender, EventArgs e)
        {
            select.selectConsultation(dataGridView1);
            PatID.Text = dataGridView1.CurrentCell.Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            PatID.Text = dataGridView1.CurrentCell.Value.ToString();
            select.selectConImage(PatID.Text, pictureBox1);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[4].ToString();
                textBox3.Text = row.Cells[5].ToString();
                textBox2.Text = row.Cells[6].ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PatID.Text = dataGridView1.CurrentCell.Value.ToString();
            select.selectConImage(PatID.Text,pictureBox1);
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[4].ToString();
                textBox3.Text = row.Cells[5].ToString();
                textBox2.Text = row.Cells[6].ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
