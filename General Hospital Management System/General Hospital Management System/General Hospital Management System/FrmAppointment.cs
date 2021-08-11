using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class FrmAppointment : Form
    {
        ClsInsert varInsert = new ClsInsert();
        ClsSelect selectClass = new ClsSelect();
        DateTimePicker sys = new DateTimePicker();
        DateTimePicker syss = new DateTimePicker();
        ErrorProvider err = new ErrorProvider();
        public FrmAppointment()
        {
            InitializeComponent();
        }

        private void FrmAppointment_Load(object sender, EventArgs e)
        {
            selectClass.SelectEmployeesname(cbName);
            clearAll();
        }




        void clearAll()
        {
            cbCategory.SelectedIndex = 0;
            txtNote.Text = "";
            tbSubject.Text = "";
            dtpStartDate.Value = sys.Value.Date;
            dtpEndDate.Value = Convert.ToDateTime(syss.Value.ToShortTimeString());
            dtpStartTime.Value = sys.Value.Date;
            dtpEndTime.Value = Convert.ToDateTime(syss.Value.ToShortTimeString());

        }
              // Save//
       
            

                  //txtNote   VALIDATION//
        void validateNote(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtNote.Text))
            {
                err.SetError(txtNote, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                err.SetError(txtNote, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtNote, string.Empty);
            }

        }


        //tbSubject VALIDATION//
        void validateSubj(Control ctrl)
        {

            if (string.IsNullOrEmpty(tbSubject.Text))
            {
                err.SetError(tbSubject, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbSubject.Text))
            {
                err.SetError(tbSubject, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(tbSubject, string.Empty);
            }
        }
        private void txtSubj_Leave(object sender, EventArgs e)
        {
            validateSubj((Control)sender);
        }

        private void txtNote_Leave(object sender, EventArgs e)
        {
            validateNote((Control)sender);
        }

        
        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            validateNote((Control)sender);
        }

        private void txtSubj_TextChanged(object sender, EventArgs e)
        {
            validateSubj((Control)sender);
        }

        private void tbSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
                validateSubj(tbSubject);
                validateNote(txtNote);
                if (err.GetError(tbSubject).Length != 0)
                {
                    err.SetError(tbSubject, "Please enter a value");
                }
                else if (err.GetError(txtNote).Length != 0)
                {
                    err.SetError(txtNote, "Please enter a value");
                }
                else
                {

                    if (dtpStartTime.Value.Date >= dtpStartDate.Value.Date)
                    {

                        varInsert.insertIntoSchedule(cbName.SelectedItem.ToString(), tbSubject.Text, cbCategory, dtpStartDate, dtpEndDate, dtpStartTime, dtpEndTime, txtNote.Text);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Date Ended cannot be less than Date Started", "Error-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }

            }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

