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
    public partial class frmViewAppointment : Form
    {
        ClsSelect select = new ClsSelect();
        public frmViewAppointment()
        {
            InitializeComponent();
        }

        private void frmViewAppointment_Load(object sender, EventArgs e)
        {
            select.callSchedule(dataGridView1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
