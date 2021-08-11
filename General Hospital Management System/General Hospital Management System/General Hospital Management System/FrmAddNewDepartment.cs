using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class FrmAddNewDepartment : Form
    {
        ClsInsert varInsert = new ClsInsert();
        SqlDataReader reader;
        ErrorProvider err = new ErrorProvider();
        public FrmAddNewDepartment()
        {
            InitializeComponent();
        }

        private void btnNewDept_Click(object sender, EventArgs e)
        {
            validateDepartment(tbAddNewDept);
            if(err.GetError(tbAddNewDept).Length != 0)
            {
                err.SetError(tbAddNewDept, "Please enter a value");
                return;
            }
            else
            {
                tbAddNewDept.Refresh();
                valiInput(tbAddNewDept.Text);
            }
        }
        private void txtDept_TextChanged(object sender, EventArgs e)
        {
            validateDepartment((Control)sender);
        }

        private void txtDept_Leave(object sender, EventArgs e)
        {
            validateDepartment((Control)sender);
        }

                 //VALIDATE DEPARTMENT//
        void validateDepartment(Control ctrl)
        {
            if (string.IsNullOrEmpty(tbAddNewDept.Text))
            {
                err.SetError(tbAddNewDept, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbAddNewDept.Text))
            {
                err.SetError(tbAddNewDept, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(tbAddNewDept, string.Empty);
            }
        }
// Valid Input//
         public void valiInput(string dept)
        {
            try
            {
                SqlConnection con = new SqlConnection(varInsert.connectionString);
                string sql = "select deptName from tblDepartment where deptName = '"+tbAddNewDept.Text.Trim()+"'";
                SqlCommand cmd = new SqlCommand(sql,con);
                con.Open();
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue(tbAddNewDept.Text.Trim(),dept);
                adapter.Fill(dset);
                con.Close();
                int count = dset.Tables[0].Rows.Count;
                //If count is equal to 1, then the department exist
                if(count == 1)
                {
                    MessageBox.Show("Department Already Exist","Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    varInsert.InsertToDept(tbAddNewDept.Text);
                    tbAddNewDept.ResetText();
                }



            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }


    }
}
