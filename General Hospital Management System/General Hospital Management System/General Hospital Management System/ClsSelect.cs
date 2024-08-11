using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using Guna.UI2.WinForms;
using System.Configuration;

namespace General_Hospital_Management_System
{
   public class ClsSelect
    {
        
      public  string connectionString =  @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";

        double BMI;
        int getNum;
        int getEmpNum;
        int getSupNum;
        int getReceiptNum;
        SqlDataReader reader;

        public int _drugQty;
        public double patBill;
        private string _user;
        public string fullName;
        private string _dept;
        private string _contact;
        private string _designate;
        public double _patientBills;
        private string _medication;
        private string _treatment;
        public double _drugPrice;
       // private double _myBillTotal;

        
        
        
        public string username
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    System.Windows.Forms.MessageBox.Show("Please provide your login details");
                }
                this._user = value;
            }
            get
            {
                return string.IsNullOrEmpty(this._user)? "No Name" : this._user;
            }
        }
        public string Dept
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Department Cannot be null or empty please", "Dept", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                this._dept = value;

            }
            get
            {
                return string.IsNullOrEmpty(this._dept) ? "No Dept" : this._dept;
            }
        }
        public string Contact
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("You must have a Contact", "Info", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                this._contact = value;

            }
            get
            {
                return string.IsNullOrEmpty(this._contact) ? "Info" : this._contact;
            }
        }
        public string Designation
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Please provide your rank", "Info", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                this._designate = value;

            }
            get
            {
                return string.IsNullOrEmpty(this._designate) ? "No Rank" : this._designate;
            }
        }
       
        public string Medications
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Needed to provide details of Medications taken if any", "Info", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                this._medication = value;

            }
            get
            {
                return string.IsNullOrEmpty(this._medication) ? " Needed Medications Taken" : this._medication;
            }
        }
        public string Treatment
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Please provide treatment given if any", "Info", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                this._treatment = value;

            }
            get
            {
                return string.IsNullOrEmpty(this._treatment) ? "Info" : this._treatment;
            }
        }
       
       
        //======================================//
        //           PRODUCTS INFO              //
        //====================================//

        public string prosName;
        public string prosSuppliedBy;
        public string prosPrice;
        public string prosQty;
        public string prosDetails;
        public string prosManDate;
        public string prosLocation;
        public string prosExpiryDate;

       
       
        
       

                  // Generate Receipt Number//
                 //=======================//
        public int GenerateReceiptNumber()
        {
            try
            {
               // string connectionString  =  ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                //string connectionString @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "select genReceiptNo from GenReceipt where genReceiptNo = (select max(genReceiptNo) from GenReceipt)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getReceiptNum = Int16.Parse(reader["genReceiptNo"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getReceiptNum += 1;
        }

        //=====================//
        // UPLOADING PICTURE  //   
        //===================//
        public void ImageUpload(PictureBox pix)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Choose Pic...";
                ofd.InitialDirectory = @"C:\Pictures";
                if (ofd.ShowDialog() != DialogResult.Cancel)
                {
                    pix.Image = System.Drawing.Image.FromFile(ofd.FileName);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
                    // Generate Patient Identity Number//
                   //================================//
      public int generatePatientNo()
        {
            try
            {
                string sql = "SELECT num From GenPatientNo where num = (select max(num) from GenPatientNo)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                reader =   cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    getNum = Int16.Parse(reader["num"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getSupNum += 1;
        } 
                           // Generate Employee Id//
                          //=====================//
          public int GenEmployeeNo()
            {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "select numNo from GenEmployeeNo where numNo = (select max(numNo) from GenEmployeeNo)";

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getEmpNum = Int16.Parse(reader["numNo"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
             }
            return getEmpNum += 1;

        }
                         // Supplier Identity//
                        //==================//
      public int GenSupplierNo()
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = " select genNum from GenSupNo where genNum = (select max(genNum) from GenSupNo)";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getSupNum = Int16.Parse(reader["genNum"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getSupNum += 1;
        }
                      // CALL DEPARTMENT//
                     //================//
     public void getDepartment( ComboBox comDept)
        {
            //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
            try
            {
                string sql = "select deptName from tblDepartment";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comDept.Items.Add(reader["deptName"]);
                }
                comDept.SelectedIndex = 0;
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                             // Call Get EmployeeCode//
                            //======================//
      public void getEmployeeCode(ComboBox comEmpCode)
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "select empCode from tblEmployees";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comEmpCode.Items.Add(reader["empCode"]);
                }
                comEmpCode.SelectedIndex = 0;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       }
                         //Call Employee Details//
                        //=====================//
     public void getDetails(ComboBox comEmpDetails)
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "select empSurname +' '+ empFirstname +' '+ empMiddlename as fullname, empContact, empDept,empDesignation from tblEmployees where empCode = '"+comEmpDetails.Text+"'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    fullName = (reader[0].ToString());
                    Contact = (reader[1].ToString());
                    Dept = (reader[2].ToString());
                    Designation = (reader[3].ToString());
                }
                else
                {
                    fullName = "";
                    Contact = "";
                    Dept = "";
                    Designation = "";
                    MessageBox.Show("Employee not found","Search-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                     //GET Product Details//
                    //===================//

        public void getProductsDetails(int Id)
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "select proName,proSupplier,proLocation,proPrice,proQty,proDateOfManuf,proExpiryDate,proDescription from tblProduct where proCode ='"+Id+"'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    prosName = reader["proName"].ToString();
                    prosSuppliedBy = reader["proSupplier"].ToString();
                    prosLocation = reader["proLocation"].ToString();
                    prosPrice = reader["proPrice"].ToString();
                    prosQty = reader["proQty"].ToString();
                    prosManDate = reader["proDateOfManuf"].ToString();
                    prosExpiryDate = reader["proExpiryDate"].ToString();
                    prosDetails = reader["proDescription"].ToString();
                    
                }
                else
                {
                   
                }
                
                con.Close();

            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);

            }
            
        }
                        // View Drugs
                       //===========
     public void viewDrugs()
        {
            //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
         }
        public void selectImage(string id, PictureBox pics)
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "select pPhoto from tblPatient where patID = '" + id + "'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MemoryStream ms = new MemoryStream((byte[])reader["pPhoto"]);
                    pics.Image = new Bitmap(ms);
                }
                else
                {
                    pics.Image = Properties.Resources.human_silhouette;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                   //Select Name //
                  //============//
    public void selectname(string id)
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "select pSurname+' '+pFirstname+' '+pMiddlename as fullname from tblPatient where patID = '"+id+"'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    fullName = (reader["fullname"].ToString());
                }
                else
                {
                    fullName = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                                   // Get Patient Name//
                                  //=================//
      public void SelectIdForName(ComboBox id)
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select patID from tblPatient",con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id.Items.Add(reader["patID"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
                    //CALCULATE BMI//
                   //=============//
        public double calBMI(double heightInCm, double weightInKg)
        {
            //height in meter
            BMI = ((weightInKg) / (System.Math.Pow(heightInCm, 2))) * 10000;

            return Math.Round(BMI,2);
            

          
        }
                       //View Products//
                      //=============//
     public void callProductsDetails(DataGridView dgv)
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "select proCode as [Product No], proName as [Product Name], proSupplier as [Supplier], proLocation as [Product Location], proPrice as [Price], proQty as [Quantity], proDateOfManuf as [Manufacturing Date], proExpiryDate as [Expiry Date], proDescription as [Description] from tblProduct";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dset = new DataSet();
                //DataTable dtb = new DataTable();
                SqlDataAdapter dt = new SqlDataAdapter(sql, con);
                dt.Fill(dset, sql);
                dgv.DataSource = dset;
                dgv.DataMember = sql;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                 //View Supplier  //
                //===============//
     public void callSuppierData(DataGridView dgv)
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "select supCode as [Supplier ID], supName as [Name], supContact as [Contact], suptype as [Items], supPersonInCharge as [Sales Person], supContactPersonInCharge as [Phone Sale Person], supCountry as [Country], supEmail as [supplier Email], supAddress as [Location], supAgreementDate as [Contract On] from tblSupplier";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dset = new DataSet();
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(dset, sql);
                dgv.DataSource = dset;
                dgv.DataMember = sql;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                 //Select Levels  //
                //===============//
       public void GetLevels(ComboBox comLevels)
        {
            try
            {
                //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Levels from Users", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comLevels.Items.Add(reader["Levels"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                    // Select patient details from Bill//
                   //==================================//
     public void selectPatientDetailsFromBill(string id)
        {
            //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select patName,Amts from tblPatientBill where patID = '" + id + "'", con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    fullName = (reader["patName"].ToString());
                    patBill = double.Parse(reader["Amts"].ToString());
                }
                else
                {
                    fullName = "";
                    patBill = 0;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
            // View Patients Appointment/Schedule  //
           //======================================//
            public void callSchedule(DataGridView dgv)
             {
            //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
            try
            {
                string sql = " select empCode as [Employee], subj as [Subject],categ as [Category],dateCreated as [Date Created On] , timeCreated as [ Time Created On],dateEnded as [Date End On], timeEnded as [Time End On],appNote as [Description] from tblSchedule";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dset, sql);
                dgv.DataSource = dset;
                dgv.DataMember = sql;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
                     // View Patient Weight  //
                    // =====================//
      public void callPatientWeight(DataGridView dgv)
        {
            try
            {
             //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                string sql = "SELECT    patID  as [ID], patName as [Patient Name], bmi as [BMI], pressure as [Pressure], temperature as [Temperature],dateMeasured as [Date],timeMeasured as [Time] from PatientWeight";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dset, sql);
                dgv.DataSource = dset;
                dgv.DataMember = sql;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
               //Get Patient Bills and Update //
              //==============================//
              public void Selectname(ComboBox id)
        {
            //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Amts from tblPatientBill where patID = '"+id.SelectedItem.ToString()+"'",con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    _patientBills = double.Parse(rd["Amts"].ToString());
                }
                else
                {
                    _patientBills = 0;
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                 //Select Levels//
                 //============//
      public void GetSupplier(ComboBox comLevels)
        {
            //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select supName from tblSupplier",con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comLevels.Items.Add(reader["supName"].ToString());
                }
                comLevels.SelectedIndex = 0;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         }
                //Get Employees Name//
               //===============//
        public void SelectEmployeesname(ComboBox EmpFullname)
        {
            //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
            try
            {
                string sql = "select EmpSurname+' '+EmpFirstname+' '+EmpMiddlename as [fullname] from tblEmployees";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmpFullname.Items.Add(reader["fullname"].ToString());
                }
                EmpFullname.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
                  //Get Employee Image By Id//
                 //=======================//
    public void SelectImageFromEmployee(string Id, PictureBox Pics)
        {
            //  string connectionString = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select epmPhoto from tblEmployees where empCode = '" + Id + "'", con);
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //DataSet dset = new DataSet();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MemoryStream ms = new MemoryStream((byte[])reader["epmPhoto"]);
                    Pics.Image = new Bitmap(ms);

                }
                else
                {
                    Pics.Image = null;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
                   //Select Patients Medication//
                   //================//
        public void selectPatMedication(string id)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Treatment,medication from tblConsultation where patID = '" + id + "' and id = (select max(id) from tblConsultation)", con);


                // SqlCommand cmd = new SqlCommand("select Treatment,medication from tblConsultation where patID = '" + id + "'and consultDate = '" + dt.Value.Date +"'", con);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Treatment = reader["Treatment"].ToString();
                    Medications = reader["medication"].ToString();
                   

                }
                else
                {
                    Treatment = "";
                    Medications = "";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
                    //View Tables//
                    //==========//
           public void viewUsers(DataGridView dgv)
            {
            try
            {
                string sql = "select empCode as [Employee ID], Username as [Username], Levels as [Levels] from Users";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
                adapter.Fill(dset,sql);
                dgv.DataSource = dset;
                dgv.DataMember = sql;
            }
            catch(Exception ex)
            {

            }
        }
                     //View Patient//
                     //===========//
      public void viewPatient(DataGridView dgv)
        {
            try
            {
            string sql = "select  patID as [Patient ID], pSurname as [Surname], pFirstname as [Firstname], pMiddlename as [Middlename], pGender as [Gender], pOccupation as [Occupation], pDOB  as [Date-Of-Birth], pResidenceAddress as [Residence Address], pNationality as [Country],pContact as [Phone N0],pEmail as [Email],pDateAdmitted as [Admission Date], pTimeAdmitted as [Admission Time], pGuardianName as [Reference Name], pGuardianPhone as [Reference Phone],pGuardianRelationship as [Guardian Relate To As] from tblPatient";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql,con);
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dset, sql);
                dgv.DataSource = dset;
                dgv.DataMember = sql;


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // View Transaction Details//
        //========================//
        public void viewDailTransact(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);

                string sql = "select ReceiptNo as [Receipt Number], PatientName as [Patient Name],TransactionDate as [Transaction Date], TransactionTime as [Transaction Time],Amts as [Amount Paid],AmtBalance as [Balance], TransactedBy as [Transaction By] from DailyTransaction";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dset, sql);
                dgv.DataSource = dset;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //View Depatments//
        //===============//
        public void viewDepartments(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);

                string sql = "select id as [No], deptName as [Department] from tblDepartment";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;
                }
             catch (Exception ex)
            {

            }

        }
                                //View Bills//
                               //=========//
        public void viewBills(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);

                string sql = "select patID as [Patience ID],patName as [Patient Name],Amts as [Balance N] from tblPatientBill";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dset, sql);
                dgv.DataSource = dset;
                dgv.DataMember = sql;


            }

            catch (Exception ex)
            {

            }

        }
                              //View Employee//
                             //============//
        public void viewEmployee(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select  empCode as [Employee ID], empSurname as [Surname], empFirstname as [Firstname], empMiddlename as [Middlename], empDOB as [Date-ofBirth], empGender as [Gender], empContact  as [Phone], empEmail as [Email], empNationality as [Country],empDateOfEmplo as [Employed On],empDept as [Department],empDesignation as [Designation], empQualification as [Qualification], empResidenceAddress as [Residence], empReferenceName as [Reference Name],empReferenceContact as [Reference Contact] from tblEmployees";
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet dsd = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsd, query);
                dgv.DataSource = dsd;
                dgv.DataMember = query;
                con.Close();
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
                     //GET PATIENT BILL AND UPDATE//
                     //==========================//
            public void selectDocName(ComboBox Levels)
             {
              try
              {
                //string dbPath = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);

                string sql = "select Username from Users where Levels ='" + "Doctor" + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                 Levels.Items.Add(reader["Username"].ToString());
                }
                Levels.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
                       //Select Drugs//
                      //===========//
        public void SelectDrug(string Drug)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                string sql = "select proPrice from tblProduct where proName ='" + Drug.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    _drugPrice = double.Parse(reader["proPrice"].ToString());
                }
                else
                {
                    
                    _drugPrice = 0;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                  // Select Drugs Name//
                 //=================//
        public void SelectDrugName(ComboBox Drug)
        {
            try
            {


                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                string sql = "select proName from tblProduct";
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                  Drug.Items.Add(reader["proName"].ToString());
                }
                Drug.SelectedIndex = 0;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                           //Select Consultation//
                          //===================//
        public void selectConsultation(DataGridView dgv)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string sql = "select patID as [Patient ID], DocCode as [Doctor], consultDate as [Date], consultTime as [Time], diagnoseDetails  as [Diagnose],  Treatment as [Treatment], medication as [Medication] from tblConsultation";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;


            }

            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
                           //Select Country Image//
                           //===================//

        public void selectConImage(string id, PictureBox pics)
        {

            try
            {
                // string dbPath = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select testImage from tblConsultation where patID = '" + id + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MemoryStream ms = new MemoryStream((byte[])reader["testImage"]);
                    pics.Image = new Bitmap(ms);
                }
                else
                {
                    pics.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
                      //View Item Bills//
                      //==============//
        public void viewItemBills(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);

                string sql = "select patID as [Patient ID], PatientName as [Patient Name], TransactionDate as [Transaction Date], TransactionTime as [Transaction Time], Item , Amts as [Price N], TransactedBy[Server] from ItemsBills";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dst = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dst, sql);
                dgv.DataSource = dst;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {

            }

        }
                         //GET PATIENT NAME//
                         //===============//
        public void selectPatientname(ComboBox names)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("select pSurname + ' ' + pFirstname + ' ' +  pMiddlename as [fullname] from tblPatient", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    names.Items.Add(reader["fullname"].ToString());

                }
                names.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
                            //Select Product Qty//
                            //=================//
        public void selectDrugQty(string proName)
        {
          try
            {
                // string dbPath = @"Data Source=localhost;Initial Catalog=dbGHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select proQty from tblProduct where proName = '" + proName + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                  _drugQty = int.Parse (reader["proQty"].ToString());
                }
                else
                {
                    _drugQty = 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

                        //SUM UP TOTAL BILL//
                        //================//
        public void calcBilling(Guna2HtmlLabel lab)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("select SUM(Amts) as total from tblPatientBill", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    patBill = double.Parse(reader["total"].ToString());

                }


                lab.Text = "Total Amount : N " + patBill.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


    }




}

