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
    public partial class frmViewUsers : Form
    {
        ClsSelect select = new ClsSelect();
        public frmViewUsers()
        {
           
            InitializeComponent();
        }

        private void frmViewUsers_Load(object sender, EventArgs e)
        {
            select.viewUsers(dataGridView1);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
