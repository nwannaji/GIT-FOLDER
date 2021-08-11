using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class frmLogin : Form
    {
        ClsSelect selectClass = new ClsSelect();
        ClsInsert varInsert = new ClsInsert();
       public string Name;
        public frmLogin()
        {
            InitializeComponent();
        }
        
                  //LOGIN USERNAME//
                 //=============//
        void Logins(string Username, string Password, ComboBox comLevels)
        {
            try
            {
                SqlConnection con = new SqlConnection(varInsert.connectionString);
                string sql = "select empCode, Username,Password,Levels from Users where Username=@Username and Levels=@Levels";
                SqlCommand cmd = new SqlCommand(sql,con);
                con.Open();
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Username",Username.Trim());
                cmd.Parameters.AddWithValue("@Levels",comLevels.SelectedItem.ToString());
                var match = false;
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var password = reader.GetString(2);
                    match = PassAuthentication.VerifyPassword(tbPassword.Text.Trim(), password);
                    
                }
                con.Close();
                if (match)
                {
                    adapter.Fill(dset);
                    int count = dset.Tables[0].Rows.Count;
                    if(count == 1)
                    {
                        frmParent fm = new frmParent();
                        this.Hide();
                        fm.getEmpCodes.Text = Username;
                        //COMBOBOX SELECTED IS AN ADMINISTRATOR//
                        if (comboBox1.SelectedIndex == 0)
                        {


                        }
                        //COMBOX SELECTED IS CASHIER
                        else if (comboBox1.SelectedIndex == 1)
                        {
                            fm.cashierToolStripMenuItem.Enabled = true;
                            fm.administratorToolStripMenuItem.Enabled = true;
                            fm.doctorsToolStripMenuItem.Enabled = true;
                            fm.nursesWardToolStripMenuItem.Enabled = true;
                            fm.pharmacistToolStripMenuItem.Enabled = true;
                        }

                        //COMBOX SELECTED IS DOCTOR
                        else if (comboBox1.SelectedIndex == 2)
                        {
                            fm.doctorsToolStripMenuItem.Enabled = true;
                            fm.administratorToolStripMenuItem.Enabled = false;
                            fm.cashierToolStripMenuItem.Enabled = false;
                            fm.nursesWardToolStripMenuItem.Enabled = false;
                            fm.pharmacistToolStripMenuItem.Enabled = false;

                        }
                        //COMBOX SELECTED IS NURSE
                        else if (comboBox1.SelectedIndex == 3)
                        {
                            fm.nursesWardToolStripMenuItem.Enabled = true;
                            fm.administratorToolStripMenuItem.Enabled = false;
                            fm.doctorsToolStripMenuItem.Enabled = false;
                            fm.pharmacistToolStripMenuItem.Enabled = false;
                            fm.cashierToolStripMenuItem.Enabled = false;
                        }
                        //COMBOX SELECTED IS PHARMACIST
                        else if (comboBox1.SelectedIndex == 4)
                        {
                            fm.pharmacistToolStripMenuItem.Enabled = true;
                            fm.administratorToolStripMenuItem.Enabled = false;
                            fm.doctorsToolStripMenuItem.Enabled = false;
                            fm.cashierToolStripMenuItem.Enabled = false;
                            fm.nursesWardToolStripMenuItem.Enabled = false;
                        }

                        fm.Show();

                    }
                    else
                    {

                    }
                }
                
                else
                {
                    MessageBox.Show("Invalid Username or Password or Privilege", "Error -GHMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string LoginUser { get; set; }

       

        private void frmLogin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(5000, "Acknowledgement", "Product from Training,Innovation and Development Dept", ToolTipIcon.Info);
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnCancel_Click_1(sender, e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            selectClass = new ClsSelect();
            selectClass.username = tbUsername.Text.Trim();
            LoginUser = tbUsername.Text.Trim();
            Logins(tbUsername.Text, tbPassword.Text, comboBox1);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
