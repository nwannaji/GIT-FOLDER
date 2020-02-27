using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EBHIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

       

        private void Login_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "henrykenechukwu")
            {
                if (tbPassword.Text == "nigcomsatltd")
                {
                    MessageBox.Show("You have Login in Successfully");
                    Main_window window = new Main_window();
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please try again");
                }
            }
            else { MessageBox.Show("Please contact System Administrator Or Either your Username or Password is wrong!."); }

        
        }

    }
}
