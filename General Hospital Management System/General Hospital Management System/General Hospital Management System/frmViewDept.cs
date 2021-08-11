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
    public partial class frmViewDept : Form
    {
        ClsSelect select = new ClsSelect();
        public frmViewDept()
        {
            InitializeComponent();
        }

        private void btnViewDept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewDept_Load(object sender, EventArgs e)
        {
            select.viewDepartments(dataGridView1);
        }
    }
}
