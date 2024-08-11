using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using CameraDriver1;

namespace General_Hospital_Management_System
{
    public partial class frmUpdateEmployee : Form
    {
        ClsSelect _select = new ClsSelect();
        ClsInsert _insert = new ClsInsert();
        CameraWin cam;
        Bitmap upDateImage;
        byte[] ByteImage;
        ErrorProvider err = new ErrorProvider();
        public frmUpdateEmployee()
        {
            InitializeComponent();
        }

        private void frmUpdateEmployee_Load(object sender, EventArgs e)
        {
            RESETTING();
        }
        void RESETTING()
        {
            _select.getDepartment(cbDept);
            cbGender.SelectedIndex = 0;
            cbNationality.SelectedIndex = 0;
            tbSurname.ResetText();
            tbFirstname.ResetText();
            tbMiddlename.ResetText();
            tbAge.ResetText();
            tbContact.ResetText();
            tbQualification.ResetText();
            tbDeignate.ResetText();
            tbAddress.ResetText();
            tbEmail.ResetText();
            tbRefNumber.ResetText();
            tbRefNumber.ResetText();
            dtpDateOfBirth.ResetText();
            dtpDateJoined.ResetText();
            picUpdateEmployee.Image = Properties.Resources.index1;
           
                
        }
                     //GET EMPLOYEE DETAILS//
                    //===================//
        public void selectEmployeeDetails()
        {
            try
            {
                //string sqlConnection = "Data Source = localhost; Initial Catalog = dbGHMS; Integrated Security = True";
                string queryDb = "SELECT empSurname,empFirstname,empMiddlename,empDOB,empGender,empContact,empEmail,empNationality,empDateOfEmplo,empDept,empDesignation,empQualification,empResidenceAddress,empReferenceName,empReferenceContact,epmPhoto FROM tblEmployees WHERE empCode = '"+tbEmployeeId.Text.Trim()+"'";
                SqlConnection con = new SqlConnection(_select.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(queryDb,con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    tbSurname.Text = rd["empSurname"].ToString();
                    tbFirstname.Text = rd["empFirstname"].ToString();
                    tbMiddlename.Text = rd["empMiddlename"].ToString();
                    dtpDateOfBirth.Text = rd["empDOB"].ToString();
                    cbGender.SelectedItem = rd["empGender"].ToString();
                    tbContact.Text = rd["empContact"].ToString();
                    tbEmail.Text = rd["empEmail"].ToString();
                    cbNationality.SelectedItem = rd["empNationality"].ToString();
                    dtpDateJoined.Text = rd["empDateOfEmplo"].ToString();
                    cbDept.SelectedItem = rd["empDept"].ToString();
                    tbDeignate.Text = rd["empDesignation"].ToString();
                    tbQualification.Text = rd["empQualification"].ToString();
                    tbAddress.Text = rd["empResidenceAddress"].ToString();
                    tbRefName.Text = rd["empReferenceName"].ToString();
                    tbRefNumber.Text = rd["empReferenceContact"].ToString();

                    MemoryStream ms = new MemoryStream((byte[]) rd["epmPhoto"]);
                    picUpdateEmployee.Image = new Bitmap(ms);


                }
                else
                {
                    tbSurname.Text = string.Empty;
                    tbFirstname.Text = string.Empty;
                    tbMiddlename.Text = string.Empty;
                    dtpDateOfBirth.Text = string.Empty;
                    cbGender.SelectedItem = string.Empty;
                    tbContact.Text = string.Empty;
                    tbEmail.Text = string.Empty;
                    cbNationality.SelectedItem = string.Empty;
                    dtpDateJoined.Text = string.Empty;
                    tbDeignate.Text = string.Empty;
                    tbQualification.Text = string.Empty;
                    tbAddress.Text = string.Empty;
                    tbRefName.Text = string.Empty;
                    tbRefNumber.Text = string.Empty;
                    picUpdateEmployee.Image = Properties.Resources.index1;

                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker sysdate = new DateTimePicker();
            sysdate.Value = DateTime.Now;
            tbAge.Text = (sysdate.Value.Year - dtpDateOfBirth.Value.Year).ToString();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            cam = new CameraWin();
            cam.PictureAcquired += new PhotoAcquiredEventHandler(Camera_PictureAcquired);
            cam.ShowDialog();
        }
        public void Camera_PictureAcquired(object sender, PhotoAcquiredEventArgs e)
        {
            picUpdateEmployee.Image = (e.normalPhoto);
            ByteImage = Utility.Util.ImageToByteArray(e.resizedPhoto);
            upDateImage = e.normalPhoto;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            _select.ImageUpload(picUpdateEmployee);
        }
                 // SAVING THE UPDATED EMPLOYEE'S DETAILS//
                 //=====================================//
        void SavingUpdatedDetails()
        {
            try
            {
              updatEmployeeDetails(tbSurname.Text.Trim(), tbFirstname.Text.Trim(), tbMiddlename.Text.Trim(), dtpDateOfBirth, cbGender, tbContact.Text.Trim(), tbEmail.Text.Trim(), cbNationality,dtpDateJoined,cbDept,tbDeignate.Text.Trim(),tbQualification.Text.Trim(),tbAddress.Text.Trim(),tbRefName.Text.Trim(),tbRefNumber.Text.Trim(),picUpdateEmployee) ;

            }
            catch (Exception ex)
            {

            }

        }
        // UPDATE EMPLOYEE'S DETAILS//
        //==========================//
        void updatEmployeeDetails(string empSurname, string empFirstname, string empMiddlename, DateTimePicker empDOB, ComboBox empGender, string empContact, string empEmail, ComboBox empNationality, DateTimePicker empDateOfEmplo, ComboBox empDept, string empDesignation, string empQualification, string empResidenceAddress, string empReferenceName, string empReferenceContact, PictureBox empPhoto)
        {
            string updateBillString;
            SqlConnection con;
            try
            {
                con = new SqlConnection(_select.connectionString);
                con.Open();
                updateBillString = "UPDATE tblEmployees set empSurname = @empSurname, empFirstname =@empFirstname,empMiddlename = @empMiddlename,empDOB= @empDOB, empGender = @empGender,empContact = @empContact, empEmail = @empEmail,empNationality = @empNationality,empDateOfEmplo = @empDateOfEmplo,empDept = @empDept, empDesignation = @empDesignation,empQualification = @empQualification,empResidenceAddress = @empResidenceAddress,empReferenceName = @empReferenceName,empReferenceContact = @empReferenceContact,epmPhoto = @epmPhoto WHERE empCode = '"+tbEmployeeId.Text.Trim()+"'";
                SqlCommand cmd = new SqlCommand(updateBillString,con);
                cmd.Parameters.AddWithValue("@empSurname", empSurname.Trim());
                cmd.Parameters.AddWithValue("@empFirstname",empFirstname.Trim());
                cmd.Parameters.AddWithValue("@empMiddlename", empMiddlename.Trim());
                cmd.Parameters.AddWithValue("@empDOB",empDOB.Value.Date);
                cmd.Parameters.AddWithValue("@empGender",empGender.SelectedItem);
                cmd.Parameters.AddWithValue("@empContact",empContact.Trim());
                cmd.Parameters.AddWithValue("@empEmail",empEmail.Trim());
                cmd.Parameters.AddWithValue("@empNationality",empNationality.SelectedItem);
                cmd.Parameters.AddWithValue("@empDateOfEmplo",empDateOfEmplo.Value.Date) ;
                cmd.Parameters.AddWithValue("@empDept", empDept.SelectedItem);
                cmd.Parameters.AddWithValue("@empDesignation",empDesignation.Trim());
                cmd.Parameters.AddWithValue("@empQualification", empQualification.Trim());
                cmd.Parameters.AddWithValue("@empResidenceAddress",empResidenceAddress.Trim());
                cmd.Parameters.AddWithValue("@empReferenceName",empReferenceName.Trim());
                cmd.Parameters.AddWithValue("@empReferenceContact",empReferenceContact.Trim());
                // INSERTION OF UPDATED PHOTO OF THE EMPLOYEE//
                byte[] image = Utility.Util.ImageToByteArray(empPhoto.Image);
                SqlParameter param = new SqlParameter("@epmPhoto",System.Data.SqlDbType.Image);
                param.Value = image;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee's record updated successfully","INFO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                con.Close();

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            validateEmployeeID(tbEmployeeId);
            validatetbSurname(tbSurname);
            validateFirstname(tbFirstname);
            validateMiddlename(tbMiddlename);
            validateContact(tbContact);
            validateQualification(tbQualification);
            validateDesignation(tbDeignate);
            validateEmail(tbEmail);
            validateResidenceAddress(tbAddress);
            validateReferenceName(tbRefName);
            validateReferenceNumber(tbRefNumber);
            
             if(err.GetError(tbSurname).Length != 0)
            {
                err.SetError(tbFirstname,"Please provide firstname!");
            }else if(err.GetError(tbMiddlename).Length != 0)
            {
                err.SetError(tbMiddlename, string.Empty);
            }else if(err.GetError(tbContact).Length != 0)
            {
                err.SetError(tbContact,"Please provide a valid phone number");
            }else if(err.GetError(tbQualification).Length != 0)
            {
                err.SetError(tbQualification, "Provide a value please");
            }else if(err.GetError(tbDeignate).Length != 0)
            {
                err.SetError(tbDeignate,"Please provide your rank!");
            }else if (err.GetError(tbRefName).Length != 0)
            {
                err.SetError(tbRefName,"Please provide the name of the person looking after the patient!");
            }else if(err.GetError(tbRefNumber).Length != 0)
            {
                err.SetError(tbRefNumber,"Please provide the care giver phone number!");
            }
            else
            {
                if(err.GetError(tbEmployeeId).Length == 0)
                {
                    SavingUpdatedDetails();
                    RESETTING();
                    clearAllErrorProviderIcons();
                }
                else
                {
                    // Do nothing
                }
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                       // VALIDATION OF TEXTBOXES//
                      //=======================//
        void validatetbSurname(Control contrl)
        {
            if (string.IsNullOrEmpty(tbSurname.Text))
            {
                err.SetError(tbSurname, "Please provide your surname!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbSurname.Text))
            {
                err.SetError(tbSurname, "Null or Space not allowed between character!");
                return;
            }
            else
            {
                err.SetError(tbSurname,string.Empty);
            }

        }
        void validateFirstname(Control contrl)
        {
            if (string.IsNullOrEmpty(tbFirstname.Text))
            {
                err.SetError(tbFirstname, "please provide your first name!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbFirstname.Text))
            {
                err.SetError(tbFirstname, "Null or Space not allowed between character!");
            }
            else
            {
                err.SetError(tbFirstname, string.Empty);
            }
        }
        void validateMiddlename(Control contrl)
        {
            if (string.IsNullOrEmpty(tbMiddlename.Text) || string.IsNullOrWhiteSpace(tbMiddlename.Text))
            {
                err.SetError(tbMiddlename, string.Empty);
                return;
            }
            else
            {
               // Do Nothing
             }

        }
        void validateContact(Control contrl)
        {
            if(string.IsNullOrEmpty(tbContact.Text)|| string.IsNullOrWhiteSpace(tbContact.Text))
            {
                err.SetError(tbContact, "Please provide a valid phone number!");
                return;
            }
            else
            {
                err.SetError(tbContact, string.Empty);
            }
        }
        void validateQualification(Control contrl)
        {
            if (string.IsNullOrEmpty(tbQualification.Text) || string.IsNullOrWhiteSpace(tbQualification.Text))
            {
                err.SetError(tbQualification, "Please provide a valid Qualification!");
                return;
            }
            else
            {
                err.SetError(tbQualification, string.Empty);
            }
            

        }
        void  validateDesignation(Control contrl)
        {
            if(string.IsNullOrEmpty(tbDeignate.Text) || string.IsNullOrWhiteSpace(tbDeignate.Text))
            {
                err.SetError(tbDeignate, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbDeignate, string.Empty);
            }
        }
         void validateResidenceAddress(Control contrl)
        {
            if(string.IsNullOrEmpty(tbAddress.Text) || string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                err.SetError(tbAddress, "Please provide a valid Residence Address!");
                return;
            }
            else
            {
                err.SetError(tbAddress, string.Empty);
            }
        }
        void validateReferenceName(Control contrl)
        {
            if(string.IsNullOrEmpty(tbRefName.Text) || string.IsNullOrWhiteSpace(tbRefName.Text))
            {
                err.SetError(tbRefName, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbRefName, string.Empty);
            }
        }
        void validateReferenceNumber(Control contrl)
        {
            if(string.IsNullOrEmpty(tbRefNumber.Text)|| string.IsNullOrWhiteSpace(tbRefNumber.Text))
            {
                err.SetError(tbRefNumber, "Please provide a valid phone number!");
                return;
            }
            else
            {
                err.SetError(tbRefNumber,string.Empty);
            }
            
        }
        void validateEmployeeID(Control contrl)
        {
            if(string.IsNullOrWhiteSpace(tbEmployeeId.Text)|| string.IsNullOrWhiteSpace(tbEmployeeId.Text))
            {
                err.SetError(tbEmployeeId, "Please provide a value");
                return;
            }
            else
            {
                err.SetError(tbEmployeeId, string.Empty);
            }
        }
        bool validateEmail(Control email)
        {
            try
            {
                var mail = new MailAddress(email.ToString());
                bool isValidEmail = mail.Host.Contains(".");
               // bool isvalidEmail = mail.Host.Contains("@");
                

                if (!isValidEmail)
                {
                    err.SetError(tbEmail, "Please provide a valid email");
                   
                
                }
                else
                {
                    err.SetError(tbEmail, string.Empty);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

       

        private void tbSurname_TextChanged(object sender, EventArgs e)
        {
            validatetbSurname((Control)sender);
        }
        private void tbSurname_Leave(object sender, EventArgs e)
        {
            validatetbSurname((Control)sender);
        }

        private void tbMiddlename_TextChanged(object sender, EventArgs e)
        {
            validateMiddlename((Control)sender);
        }

        private void tbMiddlename_Leave(object sender, EventArgs e)
        {
            validateMiddlename((Control)sender);
        }


        private void tbContact_TextChanged(object sender, EventArgs e)
        {
            validateContact((Control)sender);
        }

        private void tbContact_Leave(object sender, EventArgs e)
        {
            validateContact((Control)sender);
        }

        private void tbQualification_TextChanged(object sender, EventArgs e)
        {
            validateQualification((Control)sender);
        }

        private void tbQualification_Leave(object sender, EventArgs e)
        {
            validateQualification((Control)sender);
        }

        private void tbDesinage_TextChanged(object sender, EventArgs e)
        {
            validateDesignation((Control)sender);
        }

        private void tbDesinage_Leave(object sender, EventArgs e)
        {
            validateDesignation((Control)sender);
        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            validateResidenceAddress((Control)sender);
        }

        private void tbAddress_Leave(object sender, EventArgs e)
        {
            validateResidenceAddress((Control)sender);
        }

        private void tbRefName_TextChanged(object sender, EventArgs e)
        {
            validateReferenceName((Control)sender);
        }
        private void tbRefName_Leave(object sender, EventArgs e)
        {
            validateReferenceName((Control)sender);
        }

        private void tbRefNumber_TextChanged(object sender, EventArgs e)
        {
            validateReferenceNumber((Control)sender);
        }
        private void tbRefNumber_Leave(object sender, EventArgs e)
        {
            validateReferenceNumber((Control)sender);
        }
        private void tbEmployeeId_TextChanged(object sender, EventArgs e)
        {
              validateEmployeeID ((Control)sender);
            selectEmployeeDetails();
        }
        private void tbEmployeeId_Leave(object sender, EventArgs e)
        {
            validateEmployeeID((Control)sender);
        }

        // DESTROY ALL ERROR PROVIDER ICONS// 
        //================================//
        void clearAllErrorProviderIcons()
        {
            err.SetError(tbEmployeeId, string.Empty);
            err.SetError(tbSurname, string.Empty);
            err.SetError(tbFirstname, string.Empty);
            err.SetError(tbMiddlename,string.Empty);
            err.SetError(tbContact, string.Empty);
            err.SetError(tbQualification, string.Empty);
            err.SetError(tbDeignate, string.Empty);
            err.SetError(tbEmail, string.Empty);
            err.SetError(tbAddress, string.Empty);
            err.SetError(tbRefName, string.Empty);
            err.SetError(tbRefNumber, string.Empty);
        }
    }

    
}
