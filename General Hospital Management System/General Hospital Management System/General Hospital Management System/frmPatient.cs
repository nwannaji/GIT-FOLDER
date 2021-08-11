using System;
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
    public partial class frmPatient : Form
    {
        ClsSelect _selectClass = new ClsSelect();
        ClsInsert _InsertData = new ClsInsert();
        DateTimePicker sysDate = new DateTimePicker();
        const double folderBill = 15.00;
        ErrorProvider err = new ErrorProvider();
        public string nurseName;

        public frmPatient()
        {
            InitializeComponent();
        }
        //Clear
        void ClearAll()
        {
            patID.Text = "Patience: " + _selectClass.generatePatientNo();
            tbHeight.ResetText();
            tbWeight.ResetText();
            tbBP.ResetText();
            tbTemp.ResetText();
            pGender.SelectedIndex = 0;
            pNationalty.SelectedIndex = 0;
            pFirstname.ResetText();
            pSurname.ResetText();
            pMiddlename.ResetText();
            pAge.ResetText();
            pOccupation.ResetText();
            pContact.ResetText();
            pResidentAd.ResetText();
            pEmail.ResetText();
            gFirstname.ResetText();
            gSurname.ResetText();
            gContact.ResetText();
            gRelationship.ResetText();
            pDoB.ResetText();
            dtSysDate.ResetText();
            pPhoto.Image = null;


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker sysDat = new DateTimePicker();
            sysDat.Value = System.DateTime.Now;
            pAge.Text = (sysDat.Value.Year - pDoB.Value.Year).ToString();
        }
        byte[] cPhoto;
        Bitmap _Photo;

        private void btnCaptureImage_Click(object sender, EventArgs e)
        {
            CameraWin cam = new CameraWin();
            cam.PictureAcquired += new PhotoAcquiredEventHandler(Camera_PictureAquired);
            cam.ShowDialog();


        }
        public void Camera_PictureAquired(Object sender, PhotoAcquiredEventArgs e)
            {
            pPhoto.Image = (e.normalPhoto);
            cPhoto = Utility.Util.ImageToByteArray(e.resizedPhoto);
            _Photo = e.normalPhoto;
            }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            _selectClass.ImageUpload(pPhoto);
        }

        private void form1_Load(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // VALIDATION OF THE TEXTBOxes 

        void Validate_PatientId(Control ctrl)
        {
            if (string.IsNullOrEmpty(patID.Text))
            {
                err.SetError(patID, "Patient Hospital Number is Needed. ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(patID.Text))
            {
                err.SetError(patID, "Patient Hospital Number is Needed");
                return;
            }
            else
            {
                err.SetError(patID, string.Empty);
            }
        }
        void ValidatePatientHeight(Control ctrl)
        {
            if (string.IsNullOrEmpty(tbHeight.Text) || string .IsNullOrWhiteSpace(tbHeight.Text))
            {
                err.SetError(tbHeight, "Please provide patient Height");
                return;
            }
            else
            {
                err.SetError(tbHeight, string.Empty);
            }
        }
        void ValidatePatientWeight(Control ctrl)
        {
            if (string.IsNullOrEmpty(tbWeight.Text) || string.IsNullOrWhiteSpace(tbWeight.Text))
            {
                err.SetError(tbWeight, "Please provide patient Height");
                return;
            }
            else
            {
                err.SetError(tbWeight, string.Empty);
            }
        }
        void ValidateBloodPressure(Control ctrl)
        {
            if (string.IsNullOrEmpty(tbBP.Text) || string.IsNullOrWhiteSpace(tbBP.Text))
            {
                err.SetError(tbBP, "Please provide patient Height");
                return;
            }
            else
            {
                err.SetError(tbBP, string.Empty);
            }
        }
        void validatePatientTemp(Control ctrl)
        {
            if (string.IsNullOrEmpty(tbTemp.Text) || string.IsNullOrWhiteSpace(tbTemp.Text))
            {
                err.SetError(tbTemp, "Please provide patient Temperature");
                return;
            }
            else
            {
                err.SetError(tbTemp, string.Empty);
            }
        }
        void Validate_Firstname(Control ctrl)
        {
            if (string.IsNullOrEmpty(pFirstname.Text))
            {
                err.SetError(pFirstname, "Please enter a value ");
                return;
            }
            else if(string.IsNullOrWhiteSpace(pSurname.Text))
            {
                err.SetError(pFirstname, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(pFirstname, string.Empty);
            }
        }
        void Validate_Middlename(Control ctrl)
        {
            if (string.IsNullOrEmpty(pMiddlename.Text))
            {
                err.SetError(pMiddlename, "Please enter a value ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(pMiddlename.Text))
            {
                err.SetError(pMiddlename, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(pMiddlename, string.Empty);
            }
        }
        void Validate_Surname(Control ctrl)
        {
            if (string.IsNullOrEmpty(pSurname.Text))
            {
                err.SetError(pSurname, "Please enter a value ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(pSurname.Text))
            {
                err.SetError(pSurname, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(pSurname, string.Empty);
            }
        }
        void Validate_Contact(Control ctrl)
        {
            if (string.IsNullOrEmpty(pContact.Text))
            {
                err.SetError(pContact, "Please enter a value ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(pContact.Text))
            {
                err.SetError(pContact, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(pContact, string.Empty);
            }
        }
        void Validate_Occupation(Control ctrl)
        {
            if (string.IsNullOrEmpty(pOccupation.Text))
            {
                err.SetError(pOccupation, "Please enter a value ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(pOccupation.Text))
            {
                err.SetError(pOccupation, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(pOccupation, string.Empty);
            }
        }
        void Validate_Nationality(Control ctrl)
        {
            if (string.IsNullOrEmpty(pNationalty.SelectedItem.ToString()))
            {
                err.SetError(pNationalty, "Patient must have a Country ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(pNationalty.SelectedItem.ToString()))
            {
                err.SetError(pNationalty, "Patient must have a Country");
                return;
            }
            else
            {
                err.SetError(pNationalty, string.Empty);
            }
        }

        void Validate_ResidenceAddress(Control ctrl)
        {
            if (string.IsNullOrEmpty(pResidentAd.Text))
            {
                err.SetError(pResidentAd, "Please enter a value ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(pResidentAd.Text))
            {
                err.SetError(pResidentAd, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(pResidentAd, string.Empty);
            }
        }
        void ValidateGuardian_Firstname(Control ctrl)
        {
            if (string.IsNullOrEmpty(gFirstname.Text))
            {
                err.SetError(gFirstname, "Please enter a value ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(gFirstname.Text))
            {
                err.SetError(gFirstname, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(gFirstname, string.Empty);
            }
        }
        void ValidateGuardian_Surname(Control ctrl)
        {
            if (string.IsNullOrEmpty(gSurname.Text))
            {
                err.SetError(gSurname, "Please enter a value ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(gSurname.Text))
            {
                err.SetError(gSurname, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(gSurname, string.Empty);
            }
        }
        void ValidateGuardian_Contact(Control ctrl)
        {
            if (string.IsNullOrEmpty( gContact.Text))
            {
                err.SetError(gContact, "Please enter a numeric  value of 11 digits long ");
                return;
            }
            else
            {
                err.SetError(gContact, string.Empty);
            }
        }
        void ValidateGuardian_Relationship(Control ctrl)
        {
            if (string.IsNullOrEmpty(gRelationship.Text))
            {
                err.SetError(gRelationship, "Please enter a value ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(gRelationship.Text))
            {
                err.SetError(gRelationship, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(gRelationship, string.Empty);
            }
        }
        private void  patID_TextChanged(object sender, EventArgs e)
        {
            Validate_PatientId((Control)sender);
        }
        private void patID_Leave(object sender, EventArgs e)
        {
            Validate_PatientId((Control)sender);
        }


        private void pFirstName_TextChanged(object sender, EventArgs e)
        {
            Validate_Firstname((Control)sender);
        }
        private void pFirstName_Leave(object sender, EventArgs e)
        {
            Validate_Firstname((Control)sender);
        }
        private void pSurname_TextChanged(object sender, EventArgs e)
        {
            Validate_Surname((Control)sender);
        }

        private void pSurname_Leave(object sender, EventArgs e)
        {
            Validate_Surname((Control)sender);
        }

        private void pOccupation_TextChanged(object sender, EventArgs e)
        {
            Validate_Occupation((Control)sender);
        }

        private void pOccupation_Leave(object sender, EventArgs e)
        {
            Validate_Occupation((Control)sender);
        }
        private void pNationality_TextChanged(object sender, EventArgs e)
        {
            Validate_Nationality((Control)sender);
        }
        private void pNationality_Leave(object sender, EventArgs e)
        {
            Validate_Nationality((Control)sender);
        }
        private void pContact_TextChanged(object sender, EventArgs e)
        {
            Validate_Contact((Control)sender);
        }

        private void pContact_Leave(object sender, EventArgs e)
        {
            Validate_Contact((Control)sender);
        }
        private void pResAddress_TextChanged(object sender, EventArgs e)
        {
            Validate_ResidenceAddress((Control)sender);
        }

        private void pResAddress_Leave(object sender, EventArgs e)
        {
            Validate_ResidenceAddress((Control)sender);
        }
        private void txtGuardianFirstname_TextChanged(object sender, EventArgs e)
        {
            ValidateGuardian_Firstname((Control)sender);
        }

        private void txtGuardSurname_Leave(object sender, EventArgs e)
        {
            ValidateGuardian_Surname((Control)sender);
        }
        private void txtGuardianSurname_TextChanged(object sender, EventArgs e)
        {
            ValidateGuardian_Surname((Control)sender);
        }

        private void txtGuardianSurame_Leave(object sender, EventArgs e)
        {
            ValidateGuardian_Surname((Control)sender);
        }
        private void txtGuardianContact_TextChanged(object sender, EventArgs e)
        {
            ValidateGuardian_Contact((Control)sender);
        }

        private void txtGuardianContact_Leave(object sender, EventArgs e)
        {
            ValidateGuardian_Contact((Control)sender);
        }
        private void txtGuardianRelationship_TextChanged(object sender, EventArgs e)
        {
            ValidateGuardian_Relationship((Control)sender);
        }

        private void txtGuardianRelationship_Leave(object sender, EventArgs e)
        {
            ValidateGuardian_Relationship((Control)sender);
        }
        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        //DESTROY ERROR PROVIDER ICONS AFTER SAVING
        void ClearErrorProvider()
        {
            err.SetError(patID, string.Empty);
            err.SetError(tbHeight,string.Empty);
            err.SetError(tbWeight, string.Empty);
            err.SetError(tbBP,string.Empty);
            err.SetError(tbTemp, string.Empty);
            err.SetError(pFirstname, string.Empty);
            err.SetError(pSurname, string.Empty);
            err.SetError(pOccupation, string.Empty);
            err.SetError(pContact, string.Empty);
            err.SetError(pResidentAd, string.Empty);
            err.SetError(gFirstname, string.Empty);
            err.SetError(gSurname, string.Empty);
            err.SetError(gContact, string.Empty);
            err.SetError(gRelationship, string.Empty);
        }

        private void btnSaveDetails_Click(object sender, EventArgs e)
        {
            Validate_PatientId(patID);
            ValidatePatientHeight(tbHeight);
            ValidatePatientWeight(tbWeight);
            ValidateBloodPressure(tbBP);
            validatePatientTemp(tbTemp);
            Validate_Surname(pSurname);
            Validate_Firstname(pFirstname);
           // Validate_Middlename(pTbMiddlename);
            Validate_Contact(pContact);
            Validate_Occupation(pOccupation);
            Validate_Nationality(pNationalty);
            Validate_ResidenceAddress(pResidentAd);
            ValidateGuardian_Firstname(gFirstname);
            ValidateGuardian_Surname(gSurname);
            ValidateGuardian_Contact(gContact);
            ValidateGuardian_Relationship(gRelationship);

            string fullname = gFirstname.Text.Trim() + " " + gSurname.Text.Trim();

            if (err.GetError(patID).Length != 0)
            {
                err.SetError(patID, "Patient Hospital Number is Needed.");
            } else if (err.GetError(tbHeight).Length != 0)
            {
                err.SetError(tbHeight, "Please provide patient height");
            } else if (err.GetError(tbWeight).Length != 0)
            {
                err.SetError(tbWeight, "Please provide patient weight");
            } else if (err.GetError(tbBP).Length != 0)
            {
                err.SetError(tbBP, "Please provide patient BP");
            }else if(err.GetError(tbTemp).Length != 0)
            {
                err.SetError(tbTemp, "Please provide patient Temperature");
            }
           else if(err.GetError(pFirstname).Length != 0)
            {
                err.SetError(pFirstname, "Please enter a value"); 
            }else if(err.GetError(pSurname).Length != 0)
            {
                err.SetError(pSurname, "Please enter a value");
            }else if(err.GetError(pContact).Length != 0)
            {
                err.SetError(pContact, "Please enter a numeric value of 11 digits long.");

            }else if (err.GetError(pOccupation).Length != 0)
            {
                err.SetError(pOccupation, "Please enter a value");
            }else if(err.GetError(pResidentAd).Length != 0)
            {
                err.SetError(pResidentAd, "Please enter a value");
            } else if(err.GetError(gFirstname).Length != 0)
            {
                err.SetError(gFirstname, "Please enter a value");
            }else if(err.GetError(gSurname).Length != 0)
            {
                err.SetError(gSurname, "Please enter a value");
            }else if (err.GetError(gContact).Length != 0)
            {
                err.SetError(gContact, "Please enter a numeric value of 11 digits long.");
            }else if(err.GetError(gRelationship).Length != 0)
            {
                err.SetError(gRelationship, "Please enter a value");
            }
            else
            {
                string fullName = pSurname.Text + " " + pFirstname.Text + "" + pMiddlename.Text;
                //_InsertData.ItemsBills(patID.Text, fullName, sysDate, sysDate, "Folder Bill", folderBill, nurseName);
                // _InsertData.tblpatientBill(patID.Text, fullName, folderBill);
                _InsertData.insertToPatient(patID.Text, pSurname.Text, pFirstname.Text, pMiddlename.Text, pGender, pOccupation.Text, pDoB, pResidentAd.Text, pNationalty, pContact.Text, pEmail.Text, dtSysDate, dtSysDate, fullname, gContact.Text, gRelationship.Text, pPhoto,tbHeight.Text,tbWeight.Text,tbBP.Text,tbTemp.Text);

              // _InsertData.insertToGenPatientNo(_selectClass.generatePatientNo().ToString());
                ClearAll();
                ClearErrorProvider();


            }


        }
        private void txtGContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }
        private void dtDOB_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker sysDat = new DateTimePicker();
            sysDat.Value = System.DateTime.Now;
            pAge.Text = (sysDat.Value.Year - pDoB.Value.Year).ToString();
        }

        private void tbHeight_TextChanged(object sender, EventArgs e)
        {
            ValidatePatientHeight((Control)sender);
        }

        private void tbHeight_Leave(object sender, EventArgs e)
        {
            ValidatePatientHeight((Control)sender);
        }

        private void tbWeight_TextChanged(object sender, EventArgs e)
        {
            ValidatePatientWeight((Control)sender);
        }

        private void tbWeight_Leave(object sender, EventArgs e)
        {
            ValidatePatientWeight((Control)sender);
        }

        private void tbBP_TextChanged(object sender, EventArgs e)
        {
            ValidateBloodPressure((Control)sender);
        }

        private void tbBP_Leave(object sender, EventArgs e)
        {
            ValidateBloodPressure((Control)sender);
        }

        private void tbTemp_TextChanged(object sender, EventArgs e)
        {
            validatePatientTemp((Control)sender);
        }

        private void tbTemp_Leave(object sender, EventArgs e)
        {
            validatePatientTemp((Control)sender);

        }

        private void btnviewPatVit_Click(object sender, EventArgs e)
        {
            frmPatientVitals frmPatVitals = new frmPatientVitals();
            frmPatVitals.Show();
        }

        private void btnUpdatePat_Click(object sender, EventArgs e)
        {
            frmUpdatePatient frmupdatePat = new frmUpdatePatient();
            frmupdatePat.Show();
        }

        private void btnViewPat_Click(object sender, EventArgs e)
        {
            frmViewPatient frmViewPat = new frmViewPatient();
            frmViewPat.Show();
        }

        
    }
}
