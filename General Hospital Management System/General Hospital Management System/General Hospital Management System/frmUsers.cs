using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace General_Hospital_Management_System
{
    
    public partial class frmUsers : Form
    {
        ClsSelect selectClass = new ClsSelect();
        ClsInsert varinsert = new ClsInsert();
        ErrorProvider err = new ErrorProvider();
        frmLogin login = new frmLogin();
        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            clearAll();
            tbUsername.Text = tbEmpName.Text.Trim();

        }
       // METHOD FOR ERROR HANDLING//
       void validatePass(Control contrl)
        {
            if(tbPassword.Text.Trim().Length > 0)
            {
                err.SetError(tbPassword, string.Empty);
            }
            else
            {
                err.SetError(tbPassword, "Please enter a value");
                return;
            }
        }
   // VALIDATE CONFIRM PASSWORD//
       void validateConfirmPassword(Control contrl)
        {
            if(tbConfirmPass.Text.Trim().Length > 0)
            {
                err.SetError(tbConfirmPass, string.Empty);
            }
            else
            {
                err.SetError(tbConfirmPass, "Please enter a value");
                return;
            }
        }
                  //RESET ALL CONTROL//
                  void clearAll()
        {
            selectClass.getEmployeeCode(cbEmpID);
            cbLevel.SelectedIndex = 0;
            tbPassword.ResetText();
            tbConfirmPass.ResetText();
        }

        private void cbEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectClass.getDetails(cbEmpID);
            tbDepartment.Text = selectClass.Dept;
            tbContactNo.Text = selectClass.Contact;
            tbDesignation.Text = selectClass.Designation;
            tbUsername.Text = tbEmpName.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validatePass(tbPassword);
            validateConfirmPassword(tbConfirmPass);
            if(err.GetError(tbPassword).Length != 0)
            {
                err.SetError(tbPassword, "Please enter a value");
                return;
            }
            else if(err.GetError(tbConfirmPass).Length != 0)
            {
                err.SetError(tbConfirmPass, "Please enter a value");
                return;
            }
            //PASWWORD AND CONFIRM PASSWORD FAILED//
            else
            {
                if(tbPassword.Text.Trim() == tbConfirmPass.Text.Trim())
                {
                    PassAuthentication.HashPassword(tbPassword.Text);
                    
                    ValiInput(cbEmpID);
                    
                   
                }
                else
                {
                    MessageBox.Show("Password Mismatch !","Error-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //INSERT into user Table//
        public void ValiInput(ComboBox cbUser)
        {
            try
            {
                SqlConnection con = new SqlConnection(selectClass.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select empCode from Users where empCode = @empCode", con);
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@empCode", cbEmpID.SelectedItem.ToString());
                adapter.Fill(dset);
                con.Close();
                int count = dset.Tables[0].Rows.Count;
                //If count is eqaull to 1 meaning user already exist//
                if (count == 1)
                {
                    MessageBox.Show("User Already Exist", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    varinsert.insertIntoUsers(cbEmpID, tbUsername.Text, tbPassword.Text, cbLevel);
                    clearAll();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

         private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            validatePass((Control)sender);
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            validatePass((Control)sender);
        }

        private void tbConfirmPass_TextChanged(object sender, EventArgs e)
        {
            validateConfirmPassword((Control)sender);

        }

        private void tbConfirmPass_Leave(object sender, EventArgs e)
        {
            validateConfirmPassword((Control)sender);

        }
    }
}
