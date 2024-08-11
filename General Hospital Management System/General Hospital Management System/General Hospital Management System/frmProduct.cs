using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Guna.UI2.WinForms;

namespace General_Hospital_Management_System
{
    public partial class frmProduct : Form
    {

        ClsInsert varInsert = new ClsInsert();
        ClsUpdate theUpdates = new ClsUpdate();
        DateTimePicker sysdate = new DateTimePicker();

        ClsSelect selectClass = new ClsSelect();
        DateTimePicker dt = new DateTimePicker();
        ErrorProvider err = new ErrorProvider();
        public string empName;
        public frmProduct()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            clearAll();
            selectClass.viewPatient(dataGridView2);
            selectClass.GetSupplier(cbSuppliedBy);
            selectClass.GetSupplier(cbUpdateSuppliedBy);
            selectClass.SelectDrugName(cbLoadDrugsName);
            //int quantity = Convert.ToInt32(tbQuantity.Text.Trim());
            tbQuantity.Text = "1";
            
           
        }
        void clearAll()
        {
            selectClass.callProductsDetails(dataGridView1);
            tbItemName.ResetText();
            tbItemDetails.ResetText();
            tbItemPrice.ResetText();
            tbItemQuantity.ResetText();
            tbItemLocation.ResetText();
            dtpExpiryDate.ResetText();
            dtpManufactureDate.ResetText();
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            //Validate//
            validateItemName(tbItemName);
            validatePriceItem(tbItemPrice);
            validateItemQty(tbItemQuantity);
            validateItemDetails(tbItemDetails);
            validateItemLoc(tbItemLocation);
            if(err.GetError(tbItemName).Length != 0)
            {
                err.SetError(tbItemName, "Please provide a value!");
                return;
            }else if(err.GetError(tbItemPrice).Length != 0)
            {
                err.SetError(tbItemPrice,"Please provide price of the Item!");
                return;
            }else if(err.GetError(tbItemQuantity).Length != 0)
            {
                err.SetError(tbItemQuantity,"Please provide Item quantity");
                return;
            }else if(err.GetError(tbItemDetails).Length != 0)
            {
                err.SetError(tbItemDetails,"Please provide a value!");
                return;
            }else if(err.GetError(tbItemLocation).Length != 0)
            {
                err.SetError(tbItemLocation,"Please provide Item location");
                return;
            }
            else
            {
                if(dtpManufactureDate.Value.Date > dtpExpiryDate.Value.Date)
                {
                    MessageBox.Show("Item is Expired", "Expire Product-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                varInsert.insertIntoProduct(tbItemName.Text.Trim(), cbSuppliedBy.SelectedItem.ToString(), tbItemLocation.Text.Trim(),double.Parse(tbItemPrice.Text),double.Parse(tbItemQuantity.Text),dtpManufactureDate,dtpExpiryDate,tbItemDetails.Text.Trim());
                tbItemName.ResetText();
                tbItemDetails.ResetText();
                tbItemPrice.ResetText();
                tbItemQuantity.ResetText();
                tbItemLocation.ResetText();
                dtpManufactureDate.ResetText();
                dtpExpiryDate.ResetText();
            }
           
        }
        void validateItemName(Control cntrl)
        {
            if (tbPatName.Text.Trim().Length > 0)
            {
                err.SetError(tbPatName, string.Empty);
            }
            else
            {
                err.SetError(tbPatName, "Please provide a value!");
                return;
            }
        }
        void validatePriceItem(Control cntrl)
        {
            if(tbItemPrice.Text.Trim().Length > 0)
            {
                err.SetError(tbItemPrice, string.Empty);
            }
            else
            {
                err.SetError(tbItemPrice, "Please provide a value!");
                return;
            }
        }

        void validateItemQty(Control cntrl)
        {
            if (tbItemQuantity.Text.Trim().Length > 0)
            {
                err.SetError(tbItemQuantity, string.Empty);
            }
            else
            {
                err.SetError(tbItemQuantity, "Please provide a value!");
                return;
            }
        }

        void validateItemDetails(Control cntrl)
        {
            if (tbItemDetails.Text.Trim().Length > 0)
            {
                err.SetError(tbItemDetails, string.Empty);
            }
            else
            {
                err.SetError(tbItemDetails, "Please provide a value!");
                return;
            }
        }

        void validateItemLoc(Control cntrl)
        {
            if (tbItemLocation.Text.Trim().Length > 0)
            {
                err.SetError(tbItemLocation, string.Empty);
            }
            else
            {
                err.SetError(tbItemLocation, "Please provide a value!");
                return;
            }
        }

        private void tbItemName_TextChanged(object sender, EventArgs e)
        {
            validateItemName((Control)sender);
        }

        private void tbItemName_Leave(object sender, EventArgs e)
        {
            validateItemName((Control)sender);

        }

        private void tbItemPrice_TextChanged(object sender, EventArgs e)
        {
            validatePriceItem((Control)sender);
        }

        private void tbItemPrice_Leave(object sender, EventArgs e)
        {
            validatePriceItem((Control)sender);

        }

        private void tbItemQuantity_TextChanged(object sender, EventArgs e)
        {
            validateItemQty((Control)sender);
        }

        private void tbItemQuantity_Leave(object sender, EventArgs e)
        {
            validateItemQty((Control)sender);

        }

        private void tbItemDetails_TextChanged(object sender, EventArgs e)
        {
            validateItemDetails((Control)sender);
        }

        private void tbItemDetails_Leave(object sender, EventArgs e)
        {
            validateItemDetails((Control)sender);

        }
        private void tbItemLocation_TextChanged_1(object sender, EventArgs e)
        {
            validateItemLoc((Control)sender);
        }



        private void tbItemLocation_Leave(object sender, EventArgs e)
        {
            validateItemLoc((Control)sender);

        }

        private void tbUpdateProID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int isNum;
            //e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNum);
            
        }

        private void tbUpdateProID_TextChanged(object sender, EventArgs e)
        {
            if(tbUpdateProID.Text.Trim().Length > 0)
            {
                selectClass.getProductsDetails(Convert.ToInt16(tbUpdateProID.Text));
                tbUpdateProName.Text = selectClass.prosName;
                selectClass.prosSuppliedBy = cbSuppliedBy.Text;
                tbUpdateProPrice.Text = selectClass.prosPrice;
                tbUpdateProQ.Text = selectClass.prosQty;
                tbUpdateProDetails.Text = selectClass.prosDetails;
                dtpUpManDate.Text =  selectClass.prosManDate;
                tbUpdateProLocation.Text = selectClass.prosLocation;
                dtpUpExpiryDate.Text =  selectClass.prosExpiryDate;
            }
            else
            {
                MessageBox.Show("Item Number", "Error - GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
          
        }
        void updateProduct()
        {
            try
            {
                string UpdateQuery = "UPDATE tblProduct set proName=@proName,proSupplier=@proSupplier,proLocation=@proLocation,proPrice=@proPrice,proQty=@proQty,proDateOfManuf=@proDateOfManuf,proExpiryDate=@proExpiryDate,proDescription=@proDescription WHERE proCode ='"+int.Parse(tbUpdateProID.Text.Trim())+"'";

                SqlConnection con = new SqlConnection(selectClass.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(UpdateQuery, con);
                cmd.Parameters.AddWithValue("@proName", tbUpdateProName.Text.Trim());
                cmd.Parameters.AddWithValue("@proSupplier", cbUpdateSuppliedBy.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@proLocation", tbUpdateProLocation.Text.Trim());
                cmd.Parameters.AddWithValue("@proPrice", double.Parse(tbUpdateProPrice.Text));
                cmd.Parameters.AddWithValue("@proQty",int.Parse( tbUpdateProQ.Text));
                cmd.Parameters.AddWithValue("@proDateOfManuf",dtpUpManDate.Value.Date);
                cmd.Parameters.AddWithValue("@proExpiryDate",dtpUpExpiryDate.Value.Date);
                cmd.Parameters.AddWithValue("@proDescription",tbUpdateProDetails.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Updated Successfully","Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


          //SET CONTROLS TO FORMER STATE
        void ClearAllUpdate()
        {
            tbUpdateProID.Text = string.Empty;
            tbUpdateProName.Text = string.Empty;
            cbUpdateSuppliedBy.SelectedIndex = 0;
            tbUpdateProPrice.Text = null;
            tbUpdateProQ.Text = null;
            tbUpdateProDetails.Text = string.Empty;
            dtpUpManDate.Text = sysdate.Value.Date.ToString();
            tbUpdateProLocation.Text = null;
            dtpUpExpiryDate.Text = sysdate.Value.Date.ToString();


        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if(tbUpdateProID.Text.Length > 0)
            {
                updateProduct();
                ClearAllUpdate();
            }
            else
            {
                MessageBox.Show("Item Number","Error-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }

        private void tbUpdateProPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.ToString(), "\\d+"))
            {
                e.Handled = true;
            }
            else if (tbItemPrice.Text.Contains("."))
            {
                tbItemPrice.Text += ".";
            }
        }

        private void tbUpdateProQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if(tbUpdateProID.Text.Length > 0)
            {
                theUpdates.deleteDrugsById(int.Parse(tbUpdateProID.Text.Trim()));
                tbUpdateProID.ResetText();
                tbUpdateProName.ResetText();
                cbUpdateSuppliedBy.ResetText();
                tbUpdateProPrice.ResetText();
                tbUpdateProQ.ResetText();
                tbUpdateProDetails.ResetText();
                dtpUpManDate.Text = dt.Value.Date.ToString();
                tbUpdateProLocation.ResetText();
                dtpUpExpiryDate.Text = dt.Value.Date.ToString();

            }
            else
            {
                MessageBox.Show("Item Number","GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }

       
        void updateBalance()
        {
            string UpdateBillQuery;
            SqlConnection con;

            selectClass.selectPatientDetailsFromBill(tbPatID.Text);
            double PatBill = selectClass._patientBills;
            double patientCurrentBill = PatBill + double.Parse(tbTotal.Text);
            // sql command
            try
            {
                 con = new SqlConnection(selectClass.connectionString);
                con.Open();
                UpdateBillQuery = $"UPDATE tblPatientBill set Amts = '{patientCurrentBill}' WHERE patID = '{tbPatID.Text}'AND patName = '{tbPatName.Text}' ";
                SqlCommand cmd = new SqlCommand(UpdateBillQuery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment Updated Successfully","Save-Data",MessageBoxButtons.OK,MessageBoxIcon.Information);
                con.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        
        private void cbLoadDrugsName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            selectClass.SelectDrug(cbLoadDrugsName.SelectedItem.ToString());
            tbPrice.Text = selectClass._drugPrice.ToString();
            selectClass.selectDrugQty(cbLoadDrugsName.SelectedItem.ToString());
            getQty.Text = selectClass._drugQty.ToString();
        }
       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            frmMedication md = new frmMedication();
            if(checkBox1.Checked == true)
            {
                selectClass.selectPatMedication(this.tbPatID.Text);
                md.tbMedication.Text = selectClass.Treatment + Environment.NewLine + selectClass.Medications;
                md.Show();
            }
        }

        private void tbPatID_TextChanged(object sender, EventArgs e)
        {
            selectClass.selectname(tbPatID.Text.Trim());
            tbPatName.Text = selectClass.fullName;
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = 0;
                if (int.TryParse(tbQuantity.Text.Trim(), out value))
                {
                    double price = value * double.Parse(tbPrice.Text.Trim());
                    tbTotal.Text = price.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = 0;
                if(int.TryParse(tbQuantity.Text.Trim(), out value)){
                    double price = value * double.Parse(tbPrice.Text.Trim());
                    tbTotal.Text = price.ToString();
                }
                //double Price = (int.Parse(tbQuantity.Text.Trim()) * double.Parse(tbPrice.Text.Trim()));
                //tbTotal.Text = Price.ToString();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCheckout_Click_1(object sender, EventArgs e)
        {
            string query = $"SELECT PatientName,Item,Amts FROM ItemsBills WHERE patID ='{tb_PatID.Text.Trim()}'";
            try
            {
                SqlConnection con = new SqlConnection(selectClass.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet dset = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dset, query);
                dataGridView3.DataSource = dset;
                dataGridView3.DataMember = query;
                cmd = new SqlCommand($"SELECT SUM(Amts) from ItemsBills where patID = '{tb_PatID.Text.Trim()}'");
                cmd.Connection = con;
                object sum = cmd.ExecuteScalar();
                lblTotal.Text = '#' + sum.ToString() + " Naira.";
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void processInput()
        {
            int proQty = int.Parse(getQty.Text) - int.Parse(tbQuantity.Text);
            if (proQty < 0)
            {
                MessageBox.Show("Quantity in stock is less than quantity requested", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            theUpdates.UpdateProductQty(cbLoadDrugsName.SelectedItem.ToString(), proQty);
            updateBalance();
            varInsert.ItemsBills(tbPatID.Text, tbPatName.Text, sysdate, sysdate, cbLoadDrugsName.SelectedItem.ToString(), double.Parse(tbTotal.Text), empName);
        }

        private void tbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
        //    int isNumber;
        //    e.Handled = !int.TryParse(, out isNumber);
        }

        private void btnItem_Sold_Click(object sender, EventArgs e)
        {
            if ((tbPatID.Text.Length != 0) && (tbPatName.Text.Length != 0))
            {
                processInput();
            }
            else
            {
                MessageBox.Show("Invalid patient ID", "Error-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
