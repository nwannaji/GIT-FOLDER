using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Utility;
using CameraDriver1;

namespace General_Hospital_Management_System
{
    public partial class frmPatientVitals : Form
    {
        CameraWin cam;
        public string sqlconnection = "Data Source = localhost; Initial Catalog = dbGHMS; Integrated Security = True";
        
        ClsUpdate update = new ClsUpdate();
        DateTimePicker sysDate = new DateTimePicker();
        SqlDataReader reader;
        

        public frmPatientVitals()
        {
            InitializeComponent();
        }
        ClsInsert insert = new ClsInsert();
        ClsSelect select = new ClsSelect();
        byte[] cPhoto;
        Image _Photo;
        public void Camera_PictureAquired(Object sender, PhotoAcquiredEventArgs e)
        {
            picImage.Image = (e.normalPhoto);
            cPhoto = Utility.Util.ImageToByteArray(e.resizedPhoto);
            _Photo = e.normalPhoto;

        }

                   // Clear all Textboxes//
                  //====================//

        void ClearAll()
        {
         
            tbPatHeight.ResetText();
            tbBloodPressure.ResetText();
            tbWeight.ResetText();
            tbTemperature.ResetText();
            picImage.Image = Properties.Resources.index1;
         }
        private void tbWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int isnumber;
            //e.Handled = !int.TryParse(e.KeyChar.ToString(), out isnumber);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchPatient_Click_1(object sender, EventArgs e)
        {
            string searchQuery = "SELECT height,weight, pressure, temperature FROM tblPatientVitals WHERE PatId = '" + tbPatId.Text.Trim() + "'";
            try
            {
                ClearAll();
                select.selectImage(tbPatId.Text, picImage);
                select.selectname(tbPatId.Text);
                tbPatName.Text = select.fullName;
                SqlConnection con = new SqlConnection(sqlconnection);
                con.Open();
                SqlCommand cmd = new SqlCommand(searchQuery, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tbPatHeight.Text = reader["height"].ToString();
                    tbWeight.Text = reader["weight"].ToString();
                    tbTemperature.Text = reader["temperature"].ToString();
                    tbBloodPressure.Text = reader["pressure"].ToString();

                }
                reader.Close();
                con.Close();

                tbPatId.Enabled = false;
                tbPatName.Enabled = false;
                tbPatHeight.Enabled = false;
                tbWeight.Enabled = false;
                tbTemperature.Enabled = false;
                tbPatBMI.Enabled = false;
                tbBloodPressure.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbPatId.Text = string.Empty;
            tbPatName.Text = string.Empty;
            tbPatHeight.Text = string.Empty;
            tbWeight.Text = string.Empty;
            tbTemperature.Text = string.Empty;
            tbBloodPressure.Text = string.Empty;
            picImage.Image = Properties.Resources.index1;
            tbPatId.Enabled = true;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {

            cam = new CameraWin();
            cam.PictureAcquired += new PhotoAcquiredEventHandler(Camera_PictureAquired);
            cam.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (tbPatId.Text == string.Empty || tbPatName.Text == string.Empty || tbPatHeight.Text == string.Empty || tbWeight.Text == string.Empty || tbTemperature.Text == string.Empty || tbBloodPressure.Text == string.Empty || checkBox1.Checked == false)
            {
                MessageBox.Show("Please fill all fields and make sure that compute BMI is checked", "Error-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            insert.insertIntoPatientVitals(tbPatId.Text, tbPatName.Text, tbPatHeight.Text, tbWeight.Text, double.Parse(tbTemperature.Text), double.Parse(tbPatBMI.Text), tbBloodPressure.Text, sysDate, sysDate);
            ClearAll();
            tbPatName.Text = "";
            tbPatBMI.Text = "";
            checkBox1.Checked = false;
            tbPatId.Text = "";
            picImage.Image = Properties.Resources.index1;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            double Height, Weight;
            if (checkBox1.Checked)
            {
                if (double.TryParse(tbPatHeight.Text, out Height) == true && double.TryParse(tbWeight.Text, out Weight) == true)
                {
                    tbPatBMI.Text = select.calBMI(Convert.ToDouble(tbPatHeight.Text), Convert.ToDouble(tbWeight.Text)).ToString();
                }
                else
                {
                    checkBox1.CheckState = 0;
                    MessageBox.Show("Either Height or Weight is not Numeric" + Environment.NewLine + " Please check the values", "Error-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (!checkBox1.Checked)
            {
                tbPatBMI.Text = "";
            }
        }
    }
}
