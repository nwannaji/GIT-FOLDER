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
    public partial class frmUpdatePassword : Form
    {
        ClsSelect _select = new ClsSelect();
        ClsInsert varInsert = new ClsInsert();
        ErrorProvider err = new ErrorProvider();
        public frmUpdatePassword()
        {
            InitializeComponent();
        }


                 //VALIDATE USER ID//
                //=======================//
        void validateUserID(Control contrl)
        {
            if (string.IsNullOrEmpty(tbEmpID.Text))
            {
                err.SetError(tbEmpID, "Please provide a User ID!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbEmpID.Text))
                {
                err.SetError(tbEmpID, "Please provide a User ID!");
                return;

                 }
            else
            {
                err.SetError(tbEmpID, string.Empty);
            }
        }
                 // VALIDATE  USERNAME//
                 //==========================//
     void validateUserName(Control contrl)
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                err.SetError(tbUsername, "Please provide a Username!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                err.SetError(tbUsername, "Please provide a Username!");
                return;
            }
            else
            {
                err.SetError(tbUsername, string.Empty);
            }
        }
                 // VALIDATE USER CURRENT PASSWORD//
                //===================================//
                void validateCurrentPassword(Control contrl)
        {
            if (string.IsNullOrEmpty(tbCurrentPass.Text))
            {
                err.SetError(tbCurrentPass, "Please provide your current password!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbCurrentPass.Text))
            {
                err.SetError(tbCurrentPass, "Please provide your current password!");
                return;
            }
            else
            {
                err.SetError(tbCurrentPass, string.Empty);
            }
        }

                // VALIDATE USER NEW PASSWORD//
               //===================================//
        void validateNewPassword(Control contrl)
        {
            if (string.IsNullOrEmpty(tbNewPass.Text))
            {
                err.SetError(tbNewPass, "Please enter a new password!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbNewPass.Text))
            {
                err.SetError(tbNewPass, "Please enter a new password!");
                return;
            }
            else
            {
                err.SetError(tbNewPass, string.Empty);
            }
        }

              // VALIDATE USER REPEAT PASSWORD//
             //=============================//
             void validateRepeatPassword(Control contrl)
        {
            if (string.IsNullOrEmpty(tbRepeatPass.Text))
            {
                err.SetError(tbRepeatPass, "Please repeat the entered password!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbRepeatPass.Text))
            {
                err.SetError(tbRepeatPass, "Please repeat the entered password!");
                return;
            }
            else
            {
                err.SetError(tbRepeatPass, string.Empty);
            }
        }

        private void tbEmpID_Leave(object sender, EventArgs e)
        {
            validateUserID((Control)sender);
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            validateUserName((Control)sender);
        }

        private void tbCurrentPass_Leave(object sender, EventArgs e)
        {
            validateCurrentPassword((Control)sender);
        }

        private void tbNewPass_Leave(object sender, EventArgs e)
        {
            validateNewPassword((Control)sender);
        }

        private void tbRepeatPass_Leave(object sender, EventArgs e)
        {
            validateRepeatPassword((Control)sender);
        }
        void clearAll()
        {
            tbEmpID.ResetText();
            tbUsername.ResetText();
            tbCurrentPass.ResetText();
            tbNewPass.ResetText();
            tbRepeatPass.ResetText();
        }

        private void frmUpdatePassword_Load(object sender, EventArgs e)
        {
            clearAll();
        }
        //CLEAR PASSWORD ERROR PROVIDER ICON//
        //=================================//
        void clearErrorProviderIcon()
        {
            err.SetError(tbEmpID, string.Empty);
            err.SetError(tbUsername, string.Empty);
            err.SetError(tbCurrentPass, string.Empty);
            err.SetError(tbNewPass, string.Empty);
            err.SetError(tbRepeatPass, string.Empty);

         }


        //SELECT USERS FROM tblUsers Table//
        //===============================//
        void selectUsers()
        {
            SqlConnection con = new SqlConnection(_select.connectionString);
            try
            {//string connectionString = "Data Source = localhost; Initial Calaog = dbGHMS;Integrated Security = True";
                string sql = "select Username,empCode, Password from Users where Username =@Username and empCode =@empCode";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Username",tbUsername.Text.Trim());
                //cmd.Parameters.AddWithValue("@Password",tbCurrentPass.Text.Trim());
                cmd.Parameters.AddWithValue("@empCode",tbEmpID.Text.Trim());
                var matched = false;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                        var password = reader.GetString(2);
                        matched = PassAuthentication.VerifyPassword(tbNewPass.Text.Trim(), password);
                   
                }
                con.Close();
                if (matched)
                {
                    adapter.Fill(dset);
                    int count = dset.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                       // updateUser();
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password or ID", "Error -GHMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
               
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
                      //UPDATE USER//
                      //==========//
        void updateUser()
        {
            string updatepasswordString;
            SqlConnection con;
            try
            {
                con = new SqlConnection(_select.connectionString);
                con.Open();
                updatepasswordString = "update Users set password ='"+PassAuthentication.HashPassword(tbNewPass.Text.Trim()) + "'where empCode = '"+tbEmpID.Text.Trim()+"'";
                SqlCommand cmd = new SqlCommand(updatepasswordString, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully","Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                con.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdatePass_Click_1(object sender, EventArgs e)
        {

            validateUserID(tbEmpID);
            validateUserName(tbUsername);
            validateCurrentPassword(tbCurrentPass);
            validateNewPassword(tbNewPass);
            validateRepeatPassword(tbRepeatPass);
            if (err.GetError(tbEmpID).Length != 0)
            {
                err.SetError(tbEmpID, "Please provide a value!");
            }
            else if (err.GetError(tbUsername).Length != 0)
            {
                err.SetError(tbUsername, "Please provide a value!");
            }
            else if (err.GetError(tbCurrentPass).Length != 0)
            {
                err.SetError(tbCurrentPass, "Please provide a value!");
            }
            else if (err.GetError(tbNewPass).Length != 0)
            {
                err.SetError(tbNewPass, "Please provide a value!");
            }
            else if (err.GetError(tbRepeatPass).Length != 0)
            {
                err.SetError(tbRepeatPass, "Please provide a value!");
            }
            else
            {
                if (tbNewPass.Text.Trim() == tbRepeatPass.Text.Trim())
                {
                    updateUser();
                    selectUsers();
                    clearErrorProviderIcon();
                }
            }
        }
    }
}
