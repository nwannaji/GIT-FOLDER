using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Utility;

namespace General_Hospital_Management_System
{
    public partial class frmUpdatePatient : Form
    {
        ClsSelect selectClass = new ClsSelect();
        ClsInsert varInsert = new ClsInsert();
        ClsUpdate varUpdate = new ClsUpdate();
        ErrorProvider err = new ErrorProvider();
        public frmUpdatePatient()
        {
            InitializeComponent();
        }

        private void frmUpdatePatient_Load(object sender, EventArgs e)
        {
            cbGender.SelectedIndex = 0;
            cbNationality.SelectedIndex = 0;
        }

        private void tbpatID_TextChanged(object sender, EventArgs e)
        {
            if (tbpatID.Text.Trim().Length != 0)
            {
                selectPatientDetails();
            }
        }

        //SELECT PATIENT NAME//
        //===================//
        public void selectPatientDetails()
        {
            try
            {
                string query = $"SELECT pSurname,pFirstname, pMiddlename,pGender,pOccupation,pDOB,pResidenceAddress,pNationality,pContact,pEmail,pGuardianName,pGuardianPhone,pGuardianRelationship,pPhoto from tblPatient where patID ='{tbpatID.Text.Trim()}'";

                SqlConnection con = new SqlConnection(varUpdate.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    tbSurname.Text = rd["pSurname"].ToString();
                    tbFirstname.Text = rd["pFirstname"].ToString();
                    tbMiddlename.Text = rd["pMiddlename"].ToString();
                    cbGender.SelectedItem = rd["pGender"].ToString();
                    tbOccupation.Text = rd["pOccupation"].ToString();
                    dtpDateOfBirth.Text = rd["pDOB"].ToString();
                    tbResidentAd.Text = rd["pResidenceAddress"].ToString();
                    cbNationality.Text = rd["pNationality"].ToString();
                    tbContact.Text = rd["pContact"].ToString();
                    tbEmail.Text = rd["pEmail"].ToString();
                    tbgFullname.Text = rd["pGuardianName"].ToString();
                    tbgContact.Text = rd["pGuardianPhone"].ToString();
                    tbgRelationship.Text = rd["pGuardianRelationship"].ToString();

                    MemoryStream ms = new MemoryStream((byte[])rd["pPhoto"]);
                    picUdateDetails.Image = new Bitmap(ms);


                }
                else
                {
                    tbSurname.ResetText();
                    tbFirstname.ResetText();
                    tbMiddlename.ResetText();
                    cbGender.SelectedIndex = 0;
                    tbOccupation.ResetText();
                    tbResidentAd.ResetText();
                    cbNationality.SelectedIndex = 0;
                    tbContact.ResetText();
                    tbEmail.ResetText();
                    tbgFullname.ResetText();
                    tbgContact.ResetText();
                    tbgRelationship.ResetText();
                    picUdateDetails.Image = Properties.Resources.index1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            selectClass.ImageUpload(picUdateDetails);
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            Guna2DateTimePicker sysDate = new Guna2DateTimePicker();
            sysDate.Value = System.DateTime.Now;
            tbAge.Text = (sysDate.Value.Year - dtpDateOfBirth.Value.Year).ToString();
        }
        // VALIDATION OF THE TEXTBOXES//
        //===========================//
        void validateSurname(Control contrl)
        {
            if (string.IsNullOrEmpty(tbSurname.Text) || string.IsNullOrWhiteSpace(tbSurname.Text))
            {
                err.SetError(tbSurname, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(tbSurname, string.Empty);
            }
        }
        void validateFirstname(Control ctrl)
        {
            if (string.IsNullOrEmpty(tbFirstname.Text))
            {
                err.SetError(tbFirstname, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbFirstname.Text))
            {
                err.SetError(tbFirstname, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(tbFirstname, string.Empty);
            }
        }
        void validateContact(Control contrl)
        {
            if (tbContact.Text.Trim().Length != 11)
            {
                err.SetError(tbContact, "Please provide a numeric value of 11 digits long");
                return;
            }
            else
            {
                err.SetError(tbContact, string.Empty);
            }
        }
        void validateOccupation(Control contrl)
        {
            if (string.IsNullOrEmpty(tbOccupation.Text) || string.IsNullOrWhiteSpace(tbOccupation.Text))
            {
                err.SetError(tbOccupation, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(tbOccupation, string.Empty);
            }
        }
        void validateAddress(Control contrl)
        {
            if (string.IsNullOrEmpty(tbResidentAd.Text) || string.IsNullOrWhiteSpace(tbResidentAd.Text))
            {
                err.SetError(tbResidentAd, "Please enter your Residential Address");
                return;
            }
            else
            {
                err.SetError(tbResidentAd, string.Empty);
            }
        }
        void validateGuardianFullname(Control contrl)
        {
            if (string.IsNullOrEmpty(tbgFullname.Text) || string.IsNullOrWhiteSpace(tbgFullname.Text))
            {
                err.SetError(tbgFullname, "Please provide your guardian fullname");
                return;
            }
            else
            {
                err.SetError(tbgFullname, string.Empty);
            }
        }
        void validateGuardianPhoneNumber(Control contrl)
        {
            if (string.IsNullOrEmpty(tbgContact.Text) || string.IsNullOrWhiteSpace(tbgContact.Text))
            {
                err.SetError(tbgContact, "Please provide a numeric value of 11 digits");
                return;
            }
            else
            {
                err.SetError(tbgContact, string.Empty);
            }
        }
        void validateGuardianRelationship(Control contrl)
        {
            if (string.IsNullOrEmpty(tbgRelationship.Text) || string.IsNullOrWhiteSpace(tbgRelationship.Text))
            {
                err.SetError(tbgRelationship, "Please provide a value");
                return;
            }
            else
            {
                err.SetError(tbgRelationship, string.Empty);
            }
        }



        private void tbFirstname_TextChanged(object sender, EventArgs e)
        {
            validateFirstname((Control)sender);

        }
        private void tbFirstname_Leave(object sender, EventArgs e)
        {
            validateFirstname((Control)sender);
        }


        private void tbSurname_Leave(object sender, EventArgs e)
        {
            validateSurname((Control)sender);
        }

        private void tbOccupation_TextChanged(object sender, EventArgs e)
        {
            validateOccupation((Control)sender);
        }

        private void tbOccupation_Leave(object sender, EventArgs e)
        {
            validateOccupation((Control)sender);

        }

        private void tbContact_TextChanged(object sender, EventArgs e)
        {
            validateContact((Control)sender);
        }

        private void tbContact_Leave(object sender, EventArgs e)
        {
            validateContact((Control)sender);

        }

        private void tbResidentAd_TextChanged(object sender, EventArgs e)
        {
            validateAddress((Control)sender);
        }

        private void tbgFullname_TextChanged(object sender, EventArgs e)
        {
            validateGuardianFullname((Control)sender);
        }

        private void tbgFullname_Leave(object sender, EventArgs e)
        {
            validateGuardianFullname((Control)sender);

        }

        private void tbgContact_TextChanged(object sender, EventArgs e)
        {
            validateGuardianPhoneNumber((Control)sender);
        }

        private void tbgContact_Leave(object sender, EventArgs e)
        {
            validateGuardianPhoneNumber((Control)sender);

        }

        private void tbgRelationship_TextChanged(object sender, EventArgs e)
        {
            validateGuardianRelationship((Control)sender);
        }

        private void tbgRelationship_Leave(object sender, EventArgs e)
        {
            validateGuardianRelationship((Control)sender);

        }

        private void tbgContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void tbContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(),out isNumber);
        }

        //DESTROY ERROR PROVIDER ICONS AFTER SAVING
        void ClearErrorProvider()
        {
            err.SetError(tbFirstname, string.Empty);
            err.SetError(tbSurname, string.Empty);
            err.SetError(tbOccupation, string.Empty);
            err.SetError(tbContact, string.Empty);
            err.SetError(tbResidentAd, string.Empty);
            err.SetError(tbgFullname, string.Empty);
            err.SetError(tbgContact, string.Empty);
            err.SetError(tbgRelationship, string.Empty);
        }

        private void tbSurname_TextChanged(object sender, EventArgs e)
        {
            validateSurname((Control)sender);
        }

        private void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            validateSurname(tbSurname);
            validateFirstname(tbFirstname);
            validateContact(tbContact);
            validateOccupation(tbOccupation);
            validateAddress(tbResidentAd);
            validateGuardianFullname(tbgFullname);
            validateGuardianPhoneNumber(tbgContact);
            validateGuardianRelationship(tbgRelationship);

            if (err.GetError(tbSurname).Length !=0)  {
                err.SetError(tbSurname, "Please enter a value");
               }
            else if (err.GetError(tbFirstname).Length !=0) {
                err.SetError(tbFirstname, "Please enter a value");
             }
            else if (err.GetError(tbContact).Length !=0) {
                err.SetError(tbContact, "Please enter a numeric value of 11 digits long");
                 }
            else if (err.GetError(tbOccupation).Length !=0) {
                err.SetError(tbOccupation, "Please enter a value");
                  }
          else if(err.GetError(tbResidentAd).Length !=0) 
                 {

                err.SetError(tbResidentAd, "Please enter a value");
              }

            else if(err.GetError(tbgFullname).Length !=0){

                err.SetError(tbgFullname, "Please enter a value");  
            }

            else if(err.GetError(tbgContact).Length !=0){
                err.SetError(tbgContact, "Please enter a numeric value of 11 digits long");
            
            }

            else if (err.GetError(tbgRelationship).Length != 0)
            {
                err.SetError(tbgRelationship, "Please enter a value");
            }
            else
            {
                if (tbpatID.Text.Length > 0)
                {
                    updatePatient(tbSurname.Text.Trim(), tbFirstname.Text.Trim(), tbMiddlename.Text.Trim(), cbGender, tbOccupation.Text, dtpDateOfBirth, tbResidentAd.Text, cbNationality, tbContact.Text, tbEmail.Text, tbgFullname.Text.Trim(), tbgContact.Text, tbgRelationship.Text, picUdateDetails);
                    ClearErrorProvider();
                }
                else
                {
                    MessageBox.Show("Please enter enter patient id");
                }

            }
        }
        void updatePatient(string pSurname, string pFirstname, string pMiddlename,Guna2ComboBox Gender,string pOccupation,Guna2DateTimePicker pDOB,string pResidentAddress,Guna2ComboBox pNationality,string pContact,string Email,string pGuardianFullname,string pGuardianPhone,string pGuardianRelations,Guna2CirclePictureBox pPhoto)
        {
            string updateBillsString;
            SqlConnection con;
            try
            {
                updateBillsString = $"UPDATE tblPatient SET pSurname =@pSurname, pFirstname=@pFirstname,pMiddlename=@pMiddlename,pGender=@pGender,pOccupation=@pOccupation,pDOB=@pDOB,pResidenceAddress=@pResidenceAddress,pNationality=@pNationality,pContact=@pContact,pEmail=@pEmail,pGuardianName=@pGuardianName,pGuardianPhone=@pGuardianPhone," +
                $"pGuardianRelationship=@pGuardianRelationship,pPhoto=@pPhoto WHERE patID = '{tbpatID.Text.Trim()}'" ;
                con = new SqlConnection(varUpdate.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(updateBillsString,con);
                cmd.Parameters.AddWithValue("@pSurname",pSurname.Trim());
                cmd.Parameters.AddWithValue("@pFirstname",pFirstname.Trim());
                cmd.Parameters.AddWithValue("@pMiddlename", pMiddlename.Trim());
                cmd.Parameters.AddWithValue("@pGender",Gender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pOccupation",pOccupation.Trim());
                cmd.Parameters.AddWithValue("@pDOB",pDOB.Value.Date);
                cmd.Parameters.AddWithValue("pResidenceAddress",pResidentAddress.Trim());
                cmd.Parameters.AddWithValue("pNationality",pNationality.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("pContact",pContact.Trim());
                cmd.Parameters.AddWithValue("pEmail",Email.Trim());
                cmd.Parameters.AddWithValue("pGuardianName",pGuardianFullname.Trim());
                cmd.Parameters.AddWithValue("pGuardianPhone",pGuardianPhone.Trim());
                cmd.Parameters.AddWithValue("pGuardianRelationship",pGuardianRelations.Trim());
                //Save Patient Photo in the DB//
                byte[] updatedImage = Utility.Util.ImageToByteArray(pPhoto.Image);
                SqlParameter param = new SqlParameter("@pPhoto", SqlDbType.Image);
                param.Value = updatedImage;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Successfully Updated","Save-Data GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                con.Close();
             }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
