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
    public partial class frmPatientBills : Form
    {
        ClsSelect seleClass = new ClsSelect();
        public frmPatientBills()
        {
            InitializeComponent();
        }

        private void frmPatientBills_Load(object sender, EventArgs e)
        {
            seleClass.viewBills(DGridView1);
            seleClass.calcBilling(lblTotal);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
