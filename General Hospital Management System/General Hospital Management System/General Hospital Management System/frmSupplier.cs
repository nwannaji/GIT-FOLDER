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
    
    public partial class frmSupplier : Form
    {
        ClsSelect select = new ClsSelect();
        ClsInsert insert = new ClsInsert();
        ErrorProvider err = new ErrorProvider();
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            clearAll();
            select.callSuppierData(dataGridView1);
            label13.Text = "Total Number: " + dataGridView1.RowCount.ToString();
        }




        // Clear ALL//
        void clearAll()
        {
            DateTimePicker sysDate = new DateTimePicker();
            tbSupID.Text = "supcode-"+select.GenSupplierNo().ToString();
            cbSupCountry.SelectedIndex = 0;
            cbSupType.SelectedIndex = 0;
            tbSupName.ResetText();
            tbSupContact.ResetText();
            tbPersonIncharge.ResetText();
            tbPersonIncharegContact.ResetText();
            tbSupEmail.ResetText();
            tbSupAddress.ResetText();
            dtpSupplierAgreemtDate.Value = sysDate.Value;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            select.callSuppierData(dataGridView1);
        }

                     //VALIDATION OF TEXTBOXES//
                    //======================//
                    void validateSupplierName(Control contrl)
        {
            if (string.IsNullOrEmpty(tbSupName.Text) || string.IsNullOrWhiteSpace(tbSupName.Text))
            {
                err.SetError(tbSupName, "Please provide Supplier name!");
                return;
            }
            else
            {
                err.SetError(tbSupName, string.Empty);
            }
            
        }

        void validateSupplierContact(Control contrl)
        {
            if (string.IsNullOrEmpty(tbSupContact.Text) || string.IsNullOrWhiteSpace(tbSupContact.Text))
            {
                err.SetError(tbSupContact, "Please provide Supplier's Phone Number!");
                return;
            }
            else
            {
                err.SetError(tbSupContact, string.Empty);
            }
        }
        void validateSupplierIncharge(Control contrl)
        {
            if (string.IsNullOrEmpty(tbPersonIncharge.Text) || string.IsNullOrWhiteSpace(tbPersonIncharge.Text))
            {
                err.SetError(tbPersonIncharge, "Please provide the person In charge!");
                return;
            }
            else
            {
                err.SetError(tbPersonIncharge, string.Empty);
            }
        }
        void validateSupPeronContact(Control contrl)
        {
            if (string.IsNullOrEmpty(tbPersonIncharegContact.Text) || string.IsNullOrWhiteSpace(tbPersonIncharegContact.Text))
            {
                err.SetError(tbPersonIncharegContact, "Please provide the phone number of person In charge!");
                return;
            }
            else
            {
                err.SetError(tbPersonIncharegContact, string.Empty);
            }
        }
        void validateSupplierAddress(Control contrl)
        {
            if (string.IsNullOrEmpty(tbSupAddress.Text) || string.IsNullOrWhiteSpace(tbSupAddress.Text))
            {
                err.SetError(tbSupAddress, "Please provide Supplier Address!");
                return;
            }
            else
            {
                err.SetError(tbSupAddress, string.Empty);
            }
        }

        private void tbSupContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);

        }

        private void tbSupContact_Leave(object sender, EventArgs e)
        {
            validateSupplierContact((Control)sender);
        }

        private void tbSupContact_TextChanged(object sender, EventArgs e)
        {
            validateSupplierContact((Control)sender);

        }

        private void tbSupName_TextChanged(object sender, EventArgs e)
        {
            validateSupplierName((Control)sender);
        }

        private void tbSupName_Leave(object sender, EventArgs e)
        {
            validateSupplierName((Control)sender);

        }

        private void tbPersonIncharge_TextChanged(object sender, EventArgs e)
        {
            validateSupplierIncharge((Control)sender);
        }

        private void tbPeronIncharge_Leave(object sender, EventArgs e)
        {
            validateSupplierIncharge((Control)sender);

        }

        private void tbPeronInchargeContact_TextChanged(object sender, EventArgs e)
        {
            validateSupPeronContact((Control)sender); 
        }

        private void tbPersonInchargeContact_Leave(object sender, EventArgs e)
        {
            validateSupPeronContact((Control)sender);

        }

        private void tbSupAddress_TextChanged(object sender, EventArgs e)
        {
            validateSupplierAddress((Control)sender);
        }

        private void tbSupAddress_Leave(object sender, EventArgs e)
        {
            validateSupplierAddress((Control)sender);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
                    // DESTROY ALL ERROR PROVIDER ICONS AFTER USE//
                   //==========================================//
                   void clearAllErrorProviderIcons()
        {
            err.SetError(tbSupName, string.Empty);
            err.SetError(tbSupContact, string.Empty);
            err.SetError(tbPersonIncharge, string.Empty);
            err.SetError(tbPersonIncharegContact, string.Empty);
            err.SetError(tbSupAddress, string.Empty);


        }

        private void btnSreachSupllierID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbId.Text) || string.IsNullOrWhiteSpace(tbId.Text))
            {
                err.SetError(tbId, "Please supplier Id");
                return;
            }
             else if(tbId.Text != "")
            {
                err.SetError(tbId, string.Empty);
                SqlConnection con = new SqlConnection(select.connectionString);
                con.Open();
                // string sql = $" select* from tblSupplier where supCode = {tbId.Text.Trim()}";
                string sql = "select * from tblSupplier where supCode ='"+tbId.Text.Trim()+"'";
                SqlCommand cmd = new SqlCommand(sql,con);
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dset, sql);
                dataGridView1.DataSource = dset;
                dataGridView1.DataMember = sql;
                MessageBox.Show(dataGridView1.RowCount.ToString() + " Record(s) found", "Search Result - GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.Thread.Sleep(5000);
                tbId.ResetText();

            }
            else
            {
                MessageBox.Show("No Record was found.","Search GHMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void btnAddSuppier_Click(object sender, EventArgs e)
        {
            validateSupplierName(tbSupName);
            validateSupplierContact(tbSupContact);
            validateSupplierIncharge(tbPersonIncharge);
            validateSupPeronContact(tbPersonIncharegContact);
            validateSupplierAddress(tbSupAddress);
            if(err.GetError(tbSupName).Length != 0)
            {
                err.SetError(tbSupName, "Please provide Supplier's name!");
               
            }
            else if (err.GetError(tbSupContact).Length != 0)
            {
                err.SetError(tbSupContact, "Please provide Supplier's phone number!");
            } else if(err.GetError(tbPersonIncharge).Length != 0)
            {
                err.SetError(tbPersonIncharge, "Plesae provide the person in chaerge!");
            }else if(err.GetError(tbPersonIncharegContact).Length != 0)
            {
                err.SetError(tbPersonIncharegContact, "Please provide the person in charge phone number!");
            }else if(err.GetError(tbSupAddress).Length != 0)
            {
                err.SetError(tbSupAddress, "Please provide Supplier's Address!");
            }
            else
            {
                insert.insertIntoSupplier(tbSupID.Text, tbSupName.Text, tbSupContact.Text, cbSupType, tbPersonIncharge.Text,tbPersonIncharegContact.Text, cbSupCountry, tbSupEmail.Text, tbSupAddress.Text, dtpSupplierAgreemtDate);
                insert.insertIntoGenSupplierNo(select.GenSupplierNo().ToString());
                clearAll();
                clearAllErrorProviderIcons();
            }
        }
    }
}
