using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CameraDriver1;
using Utility;

namespace General_Hospital_Management_System
{
    public partial class frmEmployee : Form
    {
        ClsSelect selectClass = new ClsSelect();
        ClsInsert varinsert = new ClsInsert();
        ErrorProvider err = new ErrorProvider();
        DateTimePicker today = new DateTimePicker();
        
        public frmEmployee()
        {
            InitializeComponent();
        }

       

        private void dtpDoB_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = new DateTimePicker();
            dtp.Value = System.DateTime.Now;
            tbAge.Text = (dtp.Value.Year - dtpDoB.Value.Year).ToString();
        }
                // VALIDATION OF SURNAME//
                //=====================//
           void validateSurname(Control contrl)
           {
            if (string.IsNullOrEmpty(tbSurname.Text))
            {
                err.SetError(tbSurname, "Please provide a value!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbSurname.Text))
            {
                err.SetError(tbSurname, "please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbSurname, string.Empty);
            }
        }

                   // VALIDATION OF FIRSTNAME//
                  //========================//
            void validateFirstname(Control contrl)
           {
            if (string.IsNullOrEmpty(tbFirstname.Text))
            {
                err.SetError(tbFirstname, "Please provide a value!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbFirstname.Text))
            {
                err.SetError(tbFirstname, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbFirstname, string.Empty);
            }
        }

        // VALIDATION OF MIDDLENAME//
        //========================//
        void validateMiddleName(Control contrl)
        {
            if (string.IsNullOrEmpty(tbMiddlename.Text))
            {
                err.SetError(tbMiddlename, "Please provide a value!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbMiddlename.Text))
            {
                err.SetError(tbMiddlename, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbMiddlename, string.Empty);
            }
        }

                     // VALIDATION OF CONTACT//
                     //=====================//
        void validateContact(Control contrl)
           {
            if (string.IsNullOrEmpty(tbContact.Text))
            {
                err.SetError(tbContact, "Please provide a value!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbContact.Text))
            {
                err.SetError(tbContact,"Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbContact, string.Empty);
            }
        }

                  // VALIDATION OF QUALIFICATION//
                 //============================//
             void validateQualification(Control contrl)
            {
            if (string.IsNullOrEmpty(tbQualification.Text))
            {
                err.SetError(tbQualification, "Please provide a value!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbQualification.Text))
            {
                err.SetError(tbQualification, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbQualification, string.Empty);
            }
        }

               // VALIDATION OF Designation//
              //==========================//
           void validateDesignation(Control contrl)
            {
            if (string.IsNullOrEmpty(tbDesignation.Text)){
                err.SetError(tbDesignation, "Please provide a value!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbDesignation.Text))
            {
                err.SetError(tbDesignation, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbDesignation, string.Empty);
            }
        }

                 // VALIDATION OF RESIDENCE ADDRESS//
                //================================//
           void validateResAddress(Control contrl)
            {
            if (string.IsNullOrEmpty(tbResidence.Text))
            {
                err.SetError(tbResidence, "Please provide a value!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbResidence.Text))
            {
                err.SetError(tbResidence, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbResidence, string.Empty);
            }
        }

                      // VALIDATION REFERENCE NAME //
                     //===========================//
            void validateReferenceName(Control contrl)
            {
            if (string.IsNullOrEmpty(tbReferenceName.Text))
            {
                err.SetError(tbReferenceName, "Please provide a value!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbReferenceName.Text))
            {
                err.SetError(tbReferenceName, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbReferenceName, string.Empty);
            }
                
        }

                      // VALIDATION REFERENCE CONTACT //
                     //===========================//
             void validateReferenceContact(Control contrl)
            {
            if (string.IsNullOrEmpty(tbReferenceContact.Text))
            {
                err.SetError(tbReferenceContact, "Please provide a value!");
                return;
            }else if (string.IsNullOrWhiteSpace(tbReferenceContact.Text))
            {
                err.SetError(tbReferenceContact, "Please provide a value!");
                return;
            }
            else
            {
                err.SetError(tbReferenceContact, string.Empty);
            }
        }

                   // VALIDATION EMAIL ADDRESS //
                  //===========================//
        bool validateEmail(Control email)
        {
            try
            {
                var mail = new MailAddress(email.ToString());
                bool isValidEmail = mail.Host.Contains(".");
                //bool isValidemail = mail.Host.Contains("@");

                if (!isValidEmail)
                {
                    err.SetError(tbEmail, "Please provide a valid email");
                }    
                else
                {
                    err.SetError(tbEmail, string.Empty);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            selectClass.ImageUpload(picImage);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validateSurname(tbSurname);
            validateFirstname(tbFirstname);
            validateMiddleName(tbMiddlename);
            validateContact(tbContact);
            validateQualification(tbQualification);
            validateDesignation(tbDesignation);
            validateResAddress(tbResidence);
            validateReferenceName(tbReferenceName);
            validateReferenceContact(tbReferenceContact);
            validateEmail(tbEmail);
            if(err.GetError(tbSurname).Length != 0)
            {
                err.SetError(tbSurname , "Please provide a value!");
            }
            else if(err.GetError(tbFirstname).Length !=0)
            {
                err.SetError(tbFirstname, "Please provide a value");
            }else if(err.GetError(tbMiddlename).Length != 0)
            {
                err.SetError(tbMiddlename, "Please provide a value");
            }else if (err.GetError(tbContact).Length != 0)
            {
                err.SetError(tbContact, "Please provide a value");
            }else if(err.GetError(tbQualification).Length != 0)
            {
                err.SetError(tbQualification, "Please provide a value");
            }else if(err.GetError(tbDesignation).Length != 0)
            {
                err.SetError(tbDesignation, "Please provide a value");
            }else if(err.GetError(tbResidence).Length != 0)
            {
                err.SetError(tbResidence, "Please provide a value");
            }else if(err.GetError(tbReferenceName).Length != 0)
            {
                err.SetError(tbReferenceName, "Please provide a value");
            }else if(err.GetError(tbReferenceContact).Length != 0)
            {
                err.SetError(tbReferenceContact, "Please provide a numeric value of 11 digits long");
            }
            else
            {
                varinsert.insertToEmployee(tbUserId.Text, tbSurname.Text, tbFirstname.Text, tbMiddlename.Text, dtpDoB, cbGender.SelectedItem.ToString(), tbContact.Text, tbEmail.Text.ToLower(), cbNationality.SelectedItem.ToString(), dtpDateEmployed, cbDepartment.SelectedItem.ToString(), tbDesignation.Text, tbQualification.Text, tbResidence.Text, tbReferenceName.Text, tbReferenceContact.Text, picImage);
                varinsert.insertToGenEmployeeNo(selectClass.GenEmployeeNo().ToString());
                RESETTING();
                ClearAllErrorProviderIcons();


            }

        }
        void RESETTING()
        {
            selectClass.getDepartment(cbDepartment);
            cbGender.SelectedIndex = 0;
            cbNationality.SelectedIndex = 0;
            tbUserId.Text = "00" + selectClass.GenEmployeeNo().ToString();
            tbMiddlename.ResetText();
            tbSurname.ResetText();
            tbFirstname.ResetText();
            tbAge.ResetText();
            tbContact.ResetText();
            tbQualification.ResetText();
            tbDesignation.ResetText();
            tbResidence.ResetText();
            tbEmail.ResetText();
            tbReferenceName.ResetText();
            tbReferenceContact.ResetText();
            dtpDoB.ResetText();
            dtpDateEmployed.ResetText();
            picImage.Image = Properties.Resources.index1;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            RESETTING();
        }
        //DETROY ERROR PROVIDER ICONS
        void ClearAllErrorProviderIcons()
        {
            err.SetError(tbFirstname, string.Empty);
            err.SetError(tbSurname, string.Empty);
            err.SetError(tbContact, string.Empty);
            err.SetError(tbQualification, string.Empty);
            err.SetError(tbDesignation, string.Empty);
            err.SetError(tbResidence, string.Empty);
            err.SetError(tbReferenceName, string.Empty);
            err.SetError(tbReferenceContact, string.Empty);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            CameraWin cam = new CameraWin();
            cam.PictureAcquired += new PhotoAcquiredEventHandler(Camera_PictureAquired);
            cam.ShowDialog();

        }
        byte[] cPhoto;
        Bitmap _Photo;
        public void Camera_PictureAquired(Object sender, PhotoAcquiredEventArgs e)
        {
            picImage.Image = (e.normalPhoto);
            cPhoto = Utility.Util.ImageToByteArray(e.resizedPhoto);
            _Photo = e.normalPhoto;
            
        }

        
    }
}
