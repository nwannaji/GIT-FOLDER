using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Credit To: '{Environment.NewLine}' Engr.Amalu Ikechukwu '{Environment.NewLine}'Mrs.Maureen Nzekwe'{Environment.NewLine}'Mrs.Ogochukwu Anita Nnaemego ", "CreditBox", MessageBoxButtons.OK, MessageBoxIcon.Information); 

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http//mailto:agbenuwisdom@gmail.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
