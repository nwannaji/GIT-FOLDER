using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace General_Hospital_Management_System
{
                //INHERITS FROM CLSINSERT
    class ClsUpdate : ClsInsert
    {
     public  string sql = "Data Source = localhost; Initial Catalog = dbGHMS; Integrated Security = True";
                //Delete Drugs from Table By Id
public void deleteDrugsById(int ID)
        {
            //string DeleteDrugsFromTable;
            SqlConnection con;
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblProduct where proCode = @proCode", con);
                try
                {
                    cmd.Parameters.AddWithValue("proCode", ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted Successfuly","Delete Product=GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Error-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                }
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
                    // Create Database Backup//
       public void Backup()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);

                     //Create Directory If not exist//
                if (!Directory.Exists(@"C:\dbBACKUP_GHMS"))
                {
                    Directory.CreateDirectory(@"C:\dbBACKUP_GHMS");
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "BACKUP DATABASE dbGHMS TO DISK = 'C:\\dbBACKUO_GHMS\\dbGHMS.BAK'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(@"database backup successfully to C:\dbBACKUP_GHMS\dbGHMS.BAK", "Backup Database - dbGHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "BACKUP DATABASE dbGHMS TO DISK = 'C:\\dbBACKUP_GHMS\\dbGHMS.BAK'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(@"database backup successfully to C:\dbBACKUP_GHMS\dbGHMS.BAK", "Backup Database -GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch(Exception ex)
            {
            MessageBox.Show(ex.Message + Environment.NewLine + "Please contact the developer", " Database Backup Error- GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
                    // Update the Product Quantity//
                   //============================//
        public void UpdateProductQty(string names, int qty)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string sql = "Update tblProduct set  proQty = @proQty where proName = @proName";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@proName", names.Trim());
                cmd.Parameters.AddWithValue("@proQty", qty);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
        }

                           // UPDATE PATIENT VITALS//
                          //=====================//
        public void updatePatientVitals(string Id, string patientName, string Height, string Weight, string Temperature, string BMI, string BloodPressure)
        {
            string query = "UPDATE tblPatientVitals SET patName = @patName,Height=@Height, Weight = @Weight, Temperature=@Temperature,BMI=@BMI,Pressure=@Pressure where PatId = @PatId";
            SqlConnection con = new SqlConnection(sql);
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@patId",Id.Trim());
            cmd.Parameters.AddWithValue("@PatName",patientName.Trim());
            cmd.Parameters.AddWithValue("@Height",Height);
            cmd.Parameters.AddWithValue("@Weight", Weight);
            cmd.Parameters.AddWithValue("@Temperature", Temperature);
            cmd.Parameters.AddWithValue("@BMI", BMI);
            cmd.Parameters.AddWithValue("@Pressure",BloodPressure);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record updated successfully", "Patient-Vitals", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

        }

                      // DONT SAVE PATIENT BMI//
                     //=====================//

        public void updatePatientWithoutBMI(string Id, string patientName, string Height, string Weight, string Temperature, string BloodPressure)
        {
            string query = "UPDATE tblPatientVitals SET patName = @patName,Height=@Height, Weight = @Weight, Temperature=@Temperature,Pressure=@Pressure where PatId = @PatId";
            SqlConnection con = new SqlConnection(sql);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@patId", Id.Trim());
            cmd.Parameters.AddWithValue("@PatName", patientName.Trim());
            cmd.Parameters.AddWithValue("@Height", Height);
            cmd.Parameters.AddWithValue("@Weight", Weight);
            cmd.Parameters.AddWithValue("@Temperature", Temperature);
            cmd.Parameters.AddWithValue("@Pressure", BloodPressure);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record updated successfully", "Patient-Vitals", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

        }
    }
}
