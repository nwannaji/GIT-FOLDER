using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Security.Cryptography;

namespace General_Hospital_Management_System             
{
    class ClsInsert
    {
       public string connectionString = @"Data Source = localhost; Initial Catalog = dbGHMS; Integrated Security = True";
        public void insertToPatient(string patID, string pSurname, string pFirstname, string pMiddlename, ComboBox pGender, string pOccupation, DateTimePicker pDOB, string pResidenceAddress, ComboBox pNationality, string pContact, string pEmail, DateTimePicker pDateAdmitted, DateTimePicker pTimeAdmitted, string pGuardianName, string pGuardianPhone, string pGuardianRelationship, PictureBox pPhoto, string Height,string Weight,string BloodPressure, string Temp )
        { //string connectionString = "DataSource = localhodt; Initial Calog =dbGHMS; Integrated Security = True";
            try
            {
                string sql = "Insert into tblPatient (patID,pSurname,pFirstname,pMiddlename,pGender,pOccupation,pDOB,pResidenceAddress,pNationality,pContact,pEmail,pDateAdmitted,pTimeAdmitted,pGuardianName,pGuardianPhone,pGuardianRelationship,pPhoto, Height,Weight,Blood_Pressure,Temperature) " +
                              "VALUES (@patID,@pSurname,@pFirstname,@pMiddlename,@pGender,@pOccupation,@pDOB,@pResidenceAddress,@pNationality,@pContact,@pEmail,@pDateAdmitted,@pTimeAdmitted,@pGuardianName,@pGuardianPhone,@pGuardianRelationship,@pPhoto,@Height,@Weight,@Blood_Pressure,@Temperature)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@patID", patID.Trim());
                cmd.Parameters.AddWithValue("@pSurname", pSurname.Trim());
                cmd.Parameters.AddWithValue("@pFirstname", pFirstname.Trim());
                cmd.Parameters.AddWithValue("@pMiddlename", pMiddlename.Trim());
                cmd.Parameters.AddWithValue("@pGender", pGender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pOccupation", pOccupation.Trim());
                cmd.Parameters.AddWithValue("@pDOB", pDOB.Value.Date);
                cmd.Parameters.AddWithValue("@pResidenceAddress", pResidenceAddress.Trim());
                cmd.Parameters.AddWithValue("@pNationality", pNationality.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pContact", pContact.Trim());
                cmd.Parameters.AddWithValue("@pEmail", pEmail.Trim());
                cmd.Parameters.AddWithValue("@pDateAdmitted", pDateAdmitted.Value.Date);
                cmd.Parameters.AddWithValue("@pTimeAdmitted", pTimeAdmitted.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@pGuardianName", pGuardianName.Trim());
                cmd.Parameters.AddWithValue("@pGuardianPhone", pGuardianPhone.Trim());
                cmd.Parameters.AddWithValue("@pGuardianRelationship", pGuardianRelationship.Trim());
                byte[] ImageByte = Utility.Util.ImageToByteArray(pPhoto.Image);
                SqlParameter param = new SqlParameter("@pPhoto", System.Data.SqlDbType.Image);
                param.Value = ImageByte;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Height",Height.Trim());
                cmd.Parameters.AddWithValue("@Weight",Weight.Trim());
                cmd.Parameters.AddWithValue("@Blood_Pressure",BloodPressure.Trim());
                cmd.Parameters.AddWithValue("@Temperature", Temp.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Patient Data saved successfully","Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }
                  // iNSERT Department//
                  //=================//
                  public void InsertToDept(string name)
        {
            try
            {
                { //string connectionString = "DataSource = localhodt; Initial Calog =dbGHMS; Integrated Security = True";
                    string sql = "insert into tblDepartment (deptName) VALUES (@deptName)";
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@deptName", name.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Successfully Saved", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ///<summary>
        ///INSERT TO TABLE EMPLOYEE
        ///</summary>
        public void insertToEmployee(string empCode, string empSurname, string empFirstname, string empMiddlename, DateTimePicker empDOB, string empGender, string empContact, string empEmail, string empNationality, DateTimePicker empDateOFEmplo, string empDept, string empDesignation, string empQualification, string empResidenceAddress, string empReferenceName, string empReferenceContact, PictureBox epmPhoto)
        {
            try
            {
                // string connectionString = "Data Source =localhost; Initial Catlog = dbGHMS; Integrated Security = True";
                SqlConnection con = new SqlConnection(connectionString);
                string sql = "insert into tblEmployees (empCode,empSurname, empFirstname, empMiddlename,empDOB,empGender,empContact, empEmail,empNationality,empDateOFEmplo,empDept,empDesignation,empQualification,empResidenceAddress,empReferenceName, empReferenceContact,epmPhoto) " +
                    "VALUES( @empCode, @empSurname,@empFirstname,@empMiddlename,@empDOB,@empGender,@empContact,@empEmail,@empNationality,@empDateOFEmplo,@empDept,@empDesignation,@empQualification,@empResidenceAddress,@empReferenceName,@empReferenceContact,@epmPhoto)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@empCode", empCode.Trim());
                cmd.Parameters.AddWithValue("@empSurname", empSurname.Trim());
                cmd.Parameters.AddWithValue("@empFirstname", empFirstname.Trim());
                cmd.Parameters.AddWithValue("@empMiddlename", empMiddlename.Trim());
                cmd.Parameters.AddWithValue("@empDOB", empDOB.Value.Date);
                cmd.Parameters.AddWithValue("@empGender", empGender.Trim());
                cmd.Parameters.AddWithValue("@empContact", empContact.Trim());
                cmd.Parameters.AddWithValue("@empEmail", empEmail.Trim());
                cmd.Parameters.AddWithValue("@empNationality", empNationality.Trim());
                cmd.Parameters.AddWithValue("@empDateOFEmplo", empDateOFEmplo.Value.Date);
                cmd.Parameters.AddWithValue("@empDept", empDept.Trim());
                cmd.Parameters.AddWithValue("@empDesignation", empDesignation.Trim());
                cmd.Parameters.AddWithValue("@empQualification", empQualification.Trim());
                cmd.Parameters.AddWithValue("@empResidenceAddress", empResidenceAddress.Trim());
                cmd.Parameters.AddWithValue("@empReferenceName", empReferenceName.Trim());
                cmd.Parameters.AddWithValue("@empReferenceContact", empReferenceContact.Trim());
                //ADDING PHOTO AND SIGNATURE//
                byte[] InsertIamge = Utility.Util.ImageToByteArray(epmPhoto.Image);
                SqlParameter param = new SqlParameter("@epmPhoto", System.Data.SqlDbType.Image);
                param.Value = InsertIamge;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Successfully Saved", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
          
        }
                //Insert to Gen ID Table Employee//
                //==============================//
                public void insertToGenEmployeeNo(string num)
        {
            // string connectionString = "Data Source =localhost; Initial Catlog = dbGHMS; Integrated Security = True";
            try 
            {
                string sql = "insert into GenEmployeeNo (numNo) values(@numNo)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@numNo",num);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }
                    /// <summary>
                    /// Insert To Gen ID Table Supplier
                    /// </summary>
                   public void insertIntoGenSupplierNo(string num)
        {
            try
            {
                //string connectionString = "Data Source = localhost; Initial Catalog = dbGHMS; Integrated Security = True";
                SqlConnection con = new SqlConnection(connectionString);
                string sql = "Insert into GenSupNo (genNum) values(@genNum)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@genNum",num);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            }
        }
                          ///<summary>
                         /// Insert To Gen ID Table GenPatientNo
                        ///</summary>
                public void insertToGenPatientNo(string num)
        {
            //string connectionString = "Data Source = localhost; Initial Catalog = dbGHMS; Integrated Security = True";
            try
            {
                string sql = "Insert into GenPatientNo (num) values(@num)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@num",num);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
                  // Insert Into Users Table//
                  //=======================//
       public void insertIntoUsers(ComboBox empCode,string Username,string Password, ComboBox Levels)
        {
            //string connectionString = "Data Source = localhost; Initial Catalog = dbGHMS; Integrated Security = True";
            try
            {
              
                
                frmLogin login = new frmLogin();
                SqlConnection con = new SqlConnection(connectionString);
                string sql = "Insert into Users (empCode, Username, Password, Levels) values(@empCode,@Username,@Password,@Levels)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@empCode",empCode.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Username", Username.Trim());
                cmd.Parameters.AddWithValue("@Password", PassAuthentication.HashPassword(Password.Trim()));
                cmd.Parameters.AddWithValue("@Levels",Levels.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Account Successfully Added","Saved Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Save Data-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }

        //INSERT TO PRODUCT TABLE //
        public void insertIntoProduct(string proName, string proSupplier, string proLocation, double proPrice, double proQty, DateTimePicker proDateOfManuf, DateTimePicker proExpiryDate, string proDescription)
        {

            try
            {

                // string dbPath = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "Insert into tblProduct (proName, proSupplier,proLocation, proPrice, proQty , proDateOfManuf, proExpiryDate, proDescription) values(@proName, @proSupplier,@proLocation, @proPrice, @proQty , @proDateOfManuf, @proExpiryDate, @proDescription)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@proName", proName.Trim());
                cmd.Parameters.AddWithValue("@proSupplier", proSupplier.Trim());
                cmd.Parameters.AddWithValue("@proLocation", proLocation.Trim());
                cmd.Parameters.AddWithValue("@proPrice", proPrice);
                cmd.Parameters.AddWithValue("@proQty ", proQty);
                cmd.Parameters.AddWithValue("@proDateOfManuf", proDateOfManuf.Value.Date);
                cmd.Parameters.AddWithValue("@proExpiryDate", proExpiryDate.Value.Date);
                cmd.Parameters.AddWithValue("@proDescription", proDescription.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product successfully added", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
        }
        //EMPLOYEE DAILY SCHEDULES
        public void insertIntoSchedule(string empCode, string subj, Guna2ComboBox categ, Guna2DateTimePicker dateCreated, Guna2DateTimePicker timeCreated, Guna2DateTimePicker dateEnded, Guna2DateTimePicker timeEnded, string appNote)
        {
            try
            {

                //  string dbPath = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "insert into tblSchedule (empCode,subj,categ,dateCreated,timeCreated,dateEnded, timeEnded,appNote) values(@empCode,@subj,@categ,@dateCreated,@timeCreated,@dateEnded,@timeEnded,@appNote)";

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@empCode", empCode.Trim());
                cmd.Parameters.AddWithValue("@subj", subj.Trim());
                cmd.Parameters.AddWithValue("@categ", categ.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@dateCreated", dateCreated.Value.Date);
                cmd.Parameters.AddWithValue("@timeCreated", timeCreated.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@dateEnded", dateEnded.Value.Date);
                cmd.Parameters.AddWithValue("@timeEnded", timeEnded.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@appNote", appNote.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Schedules book successfully", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                           //DOCTORS CONSULTATION//
                           //===================//
        public void insertIntoConsultation(ComboBox patID, string DocCode, DateTimePicker consultDate, DateTimePicker consultTime, string diagnoseDetails, string Treatment, string medication, PictureBox testImage)
        {
            try
            {

                // string dbPath = @"Data Source=localhost;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "insert into tblConsultation(patID,DocCode,consultDate,consultTime,diagnoseDetails,Treatment,medication,testImage) " +
                              "values(@patID, @DocCode,@consultDate,@consultTime,@diagnoseDetails,@Treatment,@medication,@testImage)";

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@patID", patID.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@DocCode", DocCode.Trim());
                cmd.Parameters.AddWithValue("@consultDate", consultDate.Value.Date);
                cmd.Parameters.AddWithValue("@consultTime", consultTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@diagnoseDetails", diagnoseDetails.Trim());
                cmd.Parameters.AddWithValue("@Treatment", Treatment.Trim());
                cmd.Parameters.AddWithValue("@medication", medication.Trim());

                //ADDING PHOTO AND SIGNATURE
             
                byte[] InsertIamge = Utility.Util.ImageToByteArray(testImage.Image);
                SqlParameter param = new SqlParameter("@testImage", System.Data.SqlDbType.Image);
                param.Value = InsertIamge;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Consultation record successfully added", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }

        }
                            //HOSPITAL SUPPLIERS//
                            //=================//
        public void insertIntoSupplier(string supCode, string supName, string supContact, ComboBox supType, string supPersonInCharge, string supContactPersonInCharge, ComboBox supCountry, string supEmail, string supAddress, DateTimePicker supAgreementDate)
        {
            try
            {

                // string dbPath = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "insert into tblSupplier(supCode, supName, supContact,supType,supPersonInCharge,supContactPersonInCharge,supCountry, supEmail, supAddress, supAgreementDate) " +
                              "values(@supCode, @supName, @supContact,@supType,@supPersonInCharge,@supContactPersonInCharge,@supCountry, @supEmail, @supAddress, @supAgreementDate)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@supCode", supCode.Trim());
                cmd.Parameters.AddWithValue("@supName", supName.Trim());
                cmd.Parameters.AddWithValue("@supContact", supContact.Trim());
                cmd.Parameters.AddWithValue("@supType", supType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@supPersonInCharge", supPersonInCharge.Trim());
                cmd.Parameters.AddWithValue("@supContactPersonInCharge", supContactPersonInCharge.Trim());
                cmd.Parameters.AddWithValue("@supCountry", supCountry.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@supEmail", supEmail.Trim());
                cmd.Parameters.AddWithValue("@supAddress", supAddress.Trim());
                cmd.Parameters.AddWithValue("@supAgreementDate", supAgreementDate.Value.Date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Supplier record successfully added", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
                          //PATIENT WEIGHT AND HEIGHT//
        public void insertIntoPatientVitals(string patID, string patName,string height, string weight, double temperature, double bmi, string pressure, DateTimePicker dateMeasured, DateTimePicker timeMeasured)
        {

            try
            {
                string sql = "insert into tblPatientVitals (patID, patName, height, weight, temperature,bmi, pressure, dateMeasure, timeMeasure) values(@patID, @patName, @height, @weight, @temperature, @bmi,@pressure, @dateMeasure,@timeMeasure)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@patID", patID.Trim());
                cmd.Parameters.AddWithValue("@patName", patName.Trim());
                cmd.Parameters.AddWithValue("@height",height.Trim());
                cmd.Parameters.AddWithValue("@weight",weight.Trim());
                cmd.Parameters.AddWithValue("@temperature", temperature);
                cmd.Parameters.AddWithValue("@bmi", bmi);
                cmd.Parameters.AddWithValue("@pressure", pressure.Trim());
                cmd.Parameters.AddWithValue("@dateMeasure", dateMeasured.Value.Date);
                cmd.Parameters.AddWithValue("@timeMeasure", timeMeasured.Value.ToShortTimeString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully added", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
                        //INSERT INTO TABLE GenRECEIPT//
        public void insertIntoGenReceiptNo(string num)
        {

            try
            {
                string sql = "insert into Genreceipt (genReceiptNo) values(@genReceiptNo)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@genReceiptNo", num);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
                        //INSERT INTO DAILY TRANSACTION//
        public void insertIntoDailyTransaction(string ReceiptNo, string patID, string PatientName, DateTimePicker TransactionDate, DateTimePicker TransactionTime, double Amts, double AmtBalance, string TransactedBy)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string sql = "Insert into DailyTransaction (ReceiptNo,patID,PatientName,TransactionDate,TransactionTime,Amts,AmtBalance,TransactedBy) values(@ReceiptNo,@patID,@PatientName,@TransactionDate,@TransactionTime,@Amts,@AmtBalance,@TransactedBy)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo.Trim());
                cmd.Parameters.AddWithValue("@patID", patID.Trim());
                cmd.Parameters.AddWithValue("@PatientName", PatientName.Trim());
                cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate.Value.Date);
                cmd.Parameters.AddWithValue("@TransactionTime", TransactionTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@Amts", Amts);
                cmd.Parameters.AddWithValue("@AmtBalance", AmtBalance);
                cmd.Parameters.AddWithValue("@TransactedBy", TransactedBy.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transaction successfully saved", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }
                            //INSERT INTO ITEM BILL//
        public void ItemsBills(string patID, string PatientName, DateTimePicker TransactionDate, DateTimePicker TransactionTime, string Item, double Amts, string TransactedBy)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string sql = "insert into ItemsBills (patID,PatientName,TransactionDate,TransactionTime,Item,Amts,TransactedBy) values (@patID,@PatientName,@TransactionDate,@TransactionTime,@Item,@Amts,@TransactedBy)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@patID", patID.Trim());
                cmd.Parameters.AddWithValue("@PatientName", PatientName.Trim());
                cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate.Value.Date);
                cmd.Parameters.AddWithValue("@TransactionTime", TransactionTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@Item", Item);
                cmd.Parameters.AddWithValue("@Amts", Amts);
                cmd.Parameters.AddWithValue("@TransactedBy", TransactedBy.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill successfully taken", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
                          //INSERT INTO  TBL PATIENTBILL//
        public void patientBill(string patID, string patName, double Amts)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string sql = "insert into tblPatientBill (patID,patName,Amts) values (@patID,@patName,@Amts)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@patID", patID.Trim());
                cmd.Parameters.AddWithValue("@patName", patName.Trim());
                cmd.Parameters.AddWithValue("@Amts", Amts);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill record successfully taken", "Save Data-GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

                            //INSERT INTO MALEWARD//
                           //===================//
        public void InserIntoMaleWard(string Id, string mWard,string numberOfPatient,decimal bill)
        {
            try
            {
                string insertQuery = "INSERT INTO tblMaleWard(patID,maleWard,NumOfPeople,Bill)VALUES(@patID,@maleWard,@NumOfPeople,@Bill)";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(insertQuery,con);
                con.Open();
                cmd.Parameters.AddWithValue("@patID", Id.Trim());
                cmd.Parameters.AddWithValue("@maleWard",mWard.Trim());
                cmd.Parameters.AddWithValue("@NumOfPeople",numberOfPatient.Trim());
                cmd.Parameters.AddWithValue("@Bill",bill);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data successfully Saved","DATA SAVE GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //INSERT INTO FEMALEWARD//
        //=====================//
        public void InsertIntoFemaleWard(string Id,string fWard,string numberOfPatient,decimal bill)
        {
            try
            {
                string insertQuery = "INSERT INTO tblFemaleWard(patID,WardName,NumOfPeople,Bill)VALUES(@patID,@WardName,@NumOfPeople,@Bill)";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                con.Open();
                cmd.Parameters.AddWithValue("@patID",Id.Trim());
                cmd.Parameters.AddWithValue("@WardName", fWard.Trim());
                cmd.Parameters.AddWithValue("@NumOfPeople", numberOfPatient.Trim());
                cmd.Parameters.AddWithValue("@Bill", bill);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data successfully Saved", "DATA SAVE GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }







    }
}
