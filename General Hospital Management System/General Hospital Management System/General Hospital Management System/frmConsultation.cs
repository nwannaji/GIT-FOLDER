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

    public partial class frmConsultation : Form
    {
        public string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";


        ClsSelect selectClass = new ClsSelect();
        ClsInsert varInsert = new ClsInsert();
        DateTimePicker sysdate = new DateTimePicker();
        double consultBills = 40; //consultation bill
        double AddBill = 0;
        ErrorProvider err = new ErrorProvider();
        public string docName;
        public frmConsultation()
        {
            InitializeComponent();
        }

          //Void Update//
        void updateBalance()
        {
            string updateBill;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
// ADD CONSULTATION FEE WHEN IGNORE CONSULTATION FEE IS UNCHECKED//
              if(chkNoCharge.Checked == false){
                    try
                    {
                        selectClass.Selectname(cbPatCode);
                        AddBill = consultBills + selectClass._patientBills;
                        updateBill = "update tblPatientBill set Amts = '" + AddBill.ToString() + "' where patID = '" + cbPatCode.SelectedItem.ToString() + "'And  patName= '" + tbPatientName.Text + "'";

                        con.Open();
                        SqlCommand cmd = new SqlCommand(updateBill, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bill Successfully Updated","Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                    con.Close();
                }
        //IF THE IGNORE CONSULTATION BILL IS CHECKED
                else
                {
                    try
                    {
                        selectClass.Selectname(cbPatCode);
                        AddBill = selectClass._patientBills;
                        updateBill = "update tblPatient set Amts ='"+AddBill+"'where patID = '"+cbPatCode+"'And patName'= "+tbPatientName.Text+"'";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(updateBill, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bill is Successfully Updated","Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    con.Close();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
                    //Validate Diagnosis//
        void validateDiagnosis(Control contrl)
        {
            if(tbDiagnosis.Text.Trim() == string.Empty)
            {
                err.SetError(tbDiagnosis, "Field cannot be empty");
                return;
            }
            else
            {
                err.SetError(tbDiagnosis, string.Empty);
            }
        }
                   // Validate Treatment//
     void validateTreatment(Control contrl)
        {
            if(tbTreatment.Text.Trim() == string.Empty)
            {
                err.SetError(tbTreatment, "Field cannot be empty");
                return;
            }
            else
            {
                err.SetError(tbTreatment, string.Empty);
            }
        }
             // Validate Medications//
        void validateMedications(Control cotrl)
        {
          if(tbMedication.Text.Trim() == string.Empty)
            {
                err.SetError(tbMedication, "Field cannot be empty");
                return;
            }
            else
            {
                err.SetError(tbMedication, string.Empty);
            }
        }

        private void tbMedication_Leave(object sender, EventArgs e)
        {
            validateMedications((Control)sender);
        }
                        //Treatment//
        private void tbTreatment_TextChanged(object sender, EventArgs e)
        {
            validateTreatment((Control)sender);
        }

        private void tbTreatment_Leave(object sender, EventArgs e)
        {
            validateTreatment((Control)sender);
        }

        private void tbDiagnosis_TextChanged(object sender, EventArgs e)
        {
            validateDiagnosis((Control)sender);
        }

        private void tbDiagnosis_Leave(object sender, EventArgs e)
        {
            validateDiagnosis((Control)sender);
        }

        private void cbPatCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectClass.selectname(cbPatCode.SelectedItem.ToString());
            tbPatientName.Text = selectClass.fullName;
        }
                         //CLEAR ALL
        void clearAll()
        {
            selectClass.SelectIdForName(cbPatCode);
            cbFor.SelectedIndex = 0;
            cbPatCode.SelectedIndex = 0;
            tbDiagnosis.ResetText();
            tbTreatment.ResetText();
            tbMedication.ResetText();
            pictureBox1.Image = Properties.Resources.labs;

        }
                          // Save //
        private void btnSave_Click(object sender, EventArgs e)
        {
            validateDiagnosis(tbDiagnosis);
            validateTreatment(tbTreatment);
            validateMedications(tbMedication);
            if(err.GetError(tbDiagnosis).Length != 0)
            {
                err.SetError(tbDiagnosis, "Please this field cannot be empty");
               
            }
            else if(err.GetError(tbTreatment).Length != 0)
            {
                err.SetError(tbTreatment, "Please this field cannot be empty");
            }
            else if(err.GetError(tbMedication).Length != 0)
            {
                err.SetError(tbMedication, "Please this field cannot be empty");
            }
            else
            {
                try
                {
                    updateBalance();
                    varInsert.insertIntoConsultation(cbPatCode, tbDocName.Text.ToString(), sysdate, sysdate, tbDiagnosis.Text, tbTreatment.Text, tbMedication.Text + " " + cbFor.SelectedItem.ToString(), pictureBox1);
                    varInsert.ItemsBills(cbPatCode.SelectedItem.ToString(), tbPatientName.Text, sysdate, sysdate, "Consultation", consultBills, tbDocName.Text);
                    cbPatCode.SelectedIndex = 0;
                    selectClass.SelectIdForName(cbPatCode);
                    cbFor.SelectedIndex = 0;
                    tbDiagnosis.ResetText();
                    tbTreatment.ResetText();
                    tbMedication.ResetText();
                    pictureBox1.Image = Properties.Resources.labs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectClass.ImageUpload(pictureBox1);
        }

        private void frmConsultation_Load(object sender, EventArgs e)
        {
            clearAll();
        }

        private void tbMedication_TextChanged(object sender, EventArgs e)
        {
            validateMedications((Control)sender);
        }

        private void tbDocName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
