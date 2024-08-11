using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CameraDriver;
using GFPSupremaFingerprint;
using ChinaReaderMifareLibrary;
using MifareLibrary;
using Utility;
using System.IO.Ports;
using System.Globalization;
using System.Data.SqlClient;



namespace EBHIS
{
    public partial class Main_window : Form
    {

        SqlConnection con = new SqlConnection("Data Source = localhost; Database = EBHIS; User Id = NhisUser; Password = admin");
        SqlCommand cmd;
        
        MifareService SVC;
        int _port = 3;
        private ushort deviceid;
        private string cardSN;

        public Main_window()
        {
            InitializeComponent();
        }

        Bitmap bioImage;
        byte[] bioTemplate;
        GFPSupremaFpApi bioService = null;

        private void btnCapture_Click(object sender, EventArgs e)
        {
            CameraWin camera = new CameraWin();
            camera.PictureAcquired += new PhotoAcquiredEventHandler(camera_PictureAquired);
            camera.ShowDialog();

        }
        Bitmap cPhoto;
        byte[] bioDbImage;
        byte[] Photo;

        public void camera_PictureAquired(object Sender, PhotoAcquiredEventArgs e)
        {

            picBoxPhoto.Image = (e.normalPhoto);
            Photo = Utility.Util.ImageToByteArray(e.resizedPhoto);
            cPhoto = e.normalPhoto;
        }

        private void btnFinger_Click(object sender, EventArgs e)
        {
            try
            {
                bioService = new GFPSupremaFpApi(512, 5000, 5);
                bioTemplate = bioService.ExtractTemplate(ref bioImage);
                picBoxFinger.Image = bioImage;

            }
            catch (Exception ex)
            {
                if (ex.Message == "object reference not set to an instance of an object.")
                {
                    System.Windows.Forms.MessageBox.Show("Biometric Scanner not detected");
                }
                else
                    System.Windows.Forms.MessageBox.Show("Time out. Please try again.");

            }
        }





        private bool EstablishConnectionToReader()
        {

            SVC = new MifareService(new S70(new ChinaReaderMifareLibrary.ChinaReaderMifareDll()));

            try
            {
                if (connectReader(_port, BaudRate) == false)
                {
                    EBHIS.Messgae.DisplayStatusMessageWarning("The reader connot be detected. Make sure the reader is pluged in correctly to the PC and try again," +
                         "Otherwise contact system administrator for assistance.");


                }
                else if (IsS70Tag())
                {
                    byte len = 0;
                    cardSN = SVC.GetTagSerialNumber(deviceid, ref len);
                    SVC.Select(deviceid, cardSN, len);
                    cardSN = cardSN.Substring(0, len * 2);
                    SVC = new MifareService(new S70(new ChinaReaderMifareLibrary.ChinaReaderMifareDll()));
                    return true;



                }
            }
            catch (Exception ex)
            {
                EBHIS.Messgae.DisplayStatusMessageWarning(ex.Message);
            }
            return false;
        }

        

        
        private bool connectReader(int _port, int BaudRate)
        {
            try
            {
                SVC.Connect(_port, BaudRate);
                return true;
            }
            catch { return false; }

        }
        private bool IsS70Tag()
        {

            TagType type = TagType.None;
            type = SVC.GetTagType(deviceid, Mode.RequstAllCards);
            if (type == TagType.None)
                EBHIS.Messgae.DisplayStatusMessageWarning("The tag/document cannot be detected. Make sure tag/documemt is placed correctly on the reader and try again." +
                    "if the problem persist please contact the system administrator for assistance.");

            else if (type != TagType.S70) EBHIS.Messgae.DisplayStatusMessageWarning("Tag is not S70");
            else
                return true;
            return false;

        }

        Image photoExp = null;

       private bool LoadDetails()
        {
            tbFirstname.Text = tbFirstname.Text;
            tbOthernames.Text = tbOthernames.Text;
            tbSurname.Text = tbSurname.Text;
            cbSex.Text = cbSex.Text;
            cbBG.Text = cbBG.Text.Trim();
            cbGenotype.Text = cbGenotype.Text.Trim();
            tbAddress.Text = tbAddress.Text.Trim();
            tb_PhoneNo.Text = tb_PhoneNo.Text.Trim();
            tbPhoneNo.Text = tbPhoneNo.Text.Trim();
            tbLocalGovt.Text = tbLocalGovt.Text.Trim();
            tbPatientNOK.Text = tbPatientNOK.Text.Trim();
            tbContactAddress.Text = tbContactAddress.Text.Trim();
                SqlConnection con = new SqlConnection("Data Source = localhost; Database =EBHIS; User Id = NhisUser; Password = admin");
                string query = "SELECT PATIENTPHOTO,PATIENTFINGERPRINT FROM PATIENT_DATATABLE WHERE FOLDERID = '" + tbNHISN0.Text + "'";

                
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    byte[] imgData = new byte[0];
                    imgData = (byte[])((byte[])reader["PATIENTFINGERPRINT"]);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(imgData);
                    picBoxFinger.Image = System.Drawing.Image.FromStream(stream);

                    byte[] photobyte = new byte[0];
                    photobyte = (byte[])((byte[])reader["PATIENTPHOTO"]);
                    System.IO.MemoryStream mstearm = new System.IO.MemoryStream(photobyte);
                    picBoxPhoto.Image = System.Drawing.Image.FromStream(mstearm);


                }
                con.Close();
                return true;    
           
               
            //      }
            return true;
        }


       // bool WriteDataToTag;

        private void btnReadTag_Click(object sender, EventArgs e)
        {
            if (EstablishConnectionToReader())
            {
                if (ReadDataFromTag())
                    
                {
                    LoadDetails();
                    
                    
                }
            }
           
            
        }

        byte[] patientPhoto = new byte[0];
        byte[] patientfingerprint = new byte[0];

       public void WritePatientDatabase()
        {
            try
            {
                con.Open();
                string query = "INSERT into PATIENT_DATATABLE(FOLDERID,FIRSTNAME,MIDDLENAME,SURNAME,SEX,BLOODGROUP,GENOTYPE,ADDRESS,PHONENUMBER,LOCALGOVT,PATIENTNEXTOFKIN,NEXTOFKINADDRESS,NEXTOFKINPHONENUMBER,PATIENTPHOTO,PATIENTFINGERPRINT)" +
                                "VALUES(@FOLDERID,@FIRSTNAME,@MIDDLENAME,@SURNAME,@SEX,@BLOODGROUP,@GENOTYPE,@ADDRESS,@PHONENUMBER,@LOCALGOVT,@PATIENTNEXTOFKIN,@NEXTOFKINADDRESS,@NEXTOFKINPHONENUMBER,@PATIENTPHOTO,@PATIENTFINGERPRINT)";

                cmd = new SqlCommand(query,con);
                cmd.Parameters.Add("@FOLDERID", SqlDbType.VarChar).Value = tbNHISN0.Text.Trim();
                cmd.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = tbFirstname.Text.Trim();
                cmd.Parameters.Add("@MIDDLENAME", SqlDbType.VarChar).Value = tbOthernames.Text.Trim();
                cmd.Parameters.Add("@SURNAME", SqlDbType.VarChar).Value = tbSurname.Text.Trim();
                cmd.Parameters.Add("@SEX", SqlDbType.VarChar).Value = cbSex.Text.Trim();
                cmd.Parameters.Add("@BLOODGROUP", SqlDbType.VarChar).Value = cbBG.Text.Trim();
                cmd.Parameters.Add("@GENOTYPE", SqlDbType.VarChar).Value = cbGenotype.Text.Trim();
                cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = tbAddress.Text.Trim();
                cmd.Parameters.Add("@PHONENUMBER", SqlDbType.BigInt).Value = tbPhoneNo.Text.Trim();
                cmd.Parameters.Add("@LOCALGOVT", SqlDbType.VarChar).Value = tbLocalGovt.Text.Trim();
                cmd.Parameters.Add("@PATIENTNEXTOFKIN", SqlDbType.VarChar).Value = tbPatientNOK.Text.Trim();
                cmd.Parameters.Add("@NEXTOFKINADDRESS", SqlDbType.VarChar).Value = tbContactAddress.Text.Trim();
                cmd.Parameters.Add("@NEXTOFKINPHONENUMBER", SqlDbType.BigInt).Value = tb_PhoneNo.Text.Trim();
                patientPhoto = Utility.Util.ImageToByteArray(picBoxPhoto.Image);
                cmd.Parameters.Add("@PATIENTPHOTO", SqlDbType.Binary).Value = patientPhoto;
                patientfingerprint = Utility.Util.ImageToByteArray(picBoxFinger.Image);
                cmd.Parameters.Add("@PATIENTFINGERPRINT", SqlDbType.Binary).Value = patientfingerprint;
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            
        }
        
         private void btnWriteTag_Click(object sender, EventArgs e)
        {
            if (CheckDataInAllFieldsForCard())
            {
                if (EstablishConnectionToReader())
                    if (WriteDataToCard())
                    {
                        WritePatientDatabase();
                        System.Windows.Forms.MessageBox.Show("Operation Successful", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                    else
                    {
                        EBHIS.Messgae.DisplayStatusMessageWarning("Could not write to the Card!");

                    }
            }
            else
            {
                EBHIS.Messgae.DisplayStatusMessageWarning("Please ensure all fields contain data including Photo and Fingerprint");
            }
             }



              private bool CheckDataInAllFieldsForCard()
             {

            foreach (Control cont in this.Controls)
            {
                if (cont is PictureBox)
                {
                    if ((cont as PictureBox).Image == null)
                        return false;
                }
                else if (cont is TextBox)
                {

                    if ((cont as TextBox).Text == string.Empty)
                        return false;
                }
                else if (cont is ComboBox)
                {

                    if ((cont as ComboBox).Name != "cbPort")
                    {
                        if ((cont as ComboBox).Text == string.Empty)
                            return false;
                    }
                }
            }
            return true;
        }
        void ClearDetails()
        {
            foreach (Control cont in this.Controls)
            {
                if (cont is PictureBox)
                {
                    if ((cont as PictureBox).Name != "PicBoxPhoto" && (cont as PictureBox).Name != "coatOfArm")
                    {
                        (cont as PictureBox).Image = null; 
                    }
                    else if (cont is TextBox) { (cont as TextBox).Text = string.Empty; }
                }
                else if (cont is ComboBox)
                {
                    if ((cont as ComboBox).Name != "cbPort") { (cont as ComboBox).Text = string.Empty; }
                }
                else
                {
                    if ((cont as PictureBox).Name != "PicBoxPhoto" && (cont as PictureBox).Name != "coatOfArm") {ClearDetails() ;} 
                }

            }


        }
        private string[] SplitData(string data, int blocklength, int numOfBlocks)
        {
            string[] SplitData = new string[numOfBlocks];
            int MaxNumOfChars = numOfBlocks * blocklength;

            if (data.Length > MaxNumOfChars)
                data = data.Substring(0, MaxNumOfChars);
            else
                data = data.PadRight(MaxNumOfChars,' ');
            for (int index = 0; index < numOfBlocks; index++)
            {
                SplitData[index] = data.Substring(index*blocklength, blocklength);
            }
            return SplitData;


        }  
        
        string[] data = new string[10];
        readonly int Blocklength = 16;
        readonly ushort deviceId = 0;
        byte[] key = new byte[] { 0Xff, 0xff, 0xff, 0xff, 0xff, 0xff }; //{ 0x61, 0x6B, 0x70, 0x75, 0x67, 0x6F };

        readonly int BaudRate = 115200;
        private string cardSerialNumba = string.Empty;
        private byte startIndex;


         private bool WriteDataToCard()
        {
            string[] data = new string[12];
            this.Cursor = Cursors.WaitCursor;

            try
            {     //Write Firstname to Tag.
                data = SplitData(tbFirstname.Text, Blocklength, 2);
                SVC.Write(deviceId, (byte)BlockEnum.Block.Five, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);
                SVC.Write(deviceId, (byte)BlockEnum.Block.Six, Encoding.ASCII.GetBytes(data[1]), KeyType.KeyA, key);

               // Write Othernsnames to the Tag
                data = SplitData(tbOthernames.Text, Blocklength, 2);
                SVC.Write(deviceId, (byte)BlockEnum.Block.Eight, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);
                SVC.Write(deviceId, (byte)BlockEnum.Block.Nine, Encoding.ASCII.GetBytes(data[1]), KeyType.KeyA, key);

                ////Write Surname to the Tag.
                data = SplitData(tbSurname.Text, Blocklength, 2);
                SVC.Write(deviceId, (byte)BlockEnum.Block.Ten, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);
                SVC.Write(deviceId, (byte)BlockEnum.Block.Ninty, Encoding.ASCII.GetBytes(data[1]), KeyType.KeyA, key);

                ////Write BloodGroup to the Tag.
                data = SplitData(cbBG.Text, Blocklength, 1);
                SVC.Write(deviceId, (byte)BlockEnum.Block.SixtyNine, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);


                ////Write GenoType to the Tag.
                data = SplitData(cbGenotype.Text, Blocklength, 1);
                SVC.Write(deviceId, (byte)BlockEnum.Block.Seventy, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);

                ////Write Patients Sex to the Tag.
                data = SplitData(cbSex.Text, Blocklength, 1);
                SVC.Write(deviceId, (byte)BlockEnum.Block.SixtyEight, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);


                ////Write Address to the Tag.
                data = SplitData(tbAddress.Text, Blocklength, 4);
                SVC.Write(deviceId, (byte)BlockEnum.Block.Sixty, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);
                SVC.Write(deviceId, (byte)BlockEnum.Block.SixtyOne, Encoding.ASCII.GetBytes(data[1]), KeyType.KeyA, key);
                SVC.Write(deviceId, (byte)BlockEnum.Block.SixtyTwo, Encoding.ASCII.GetBytes(data[2]), KeyType.KeyA, key);
               // SVC.Write(deviceId, (byte)BlockEnum.Block.SixtyFour, Encoding.ASCII.GetBytes(data[3]), KeyType.KeyA, key);

                ////Write Patients LocalGovt.
                data = SplitData(tbLocalGovt.Text, Blocklength, 2);
                SVC.Write(deviceId, (byte)BlockEnum.Block.FiftySeven, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);
                SVC.Write(deviceId, (byte)BlockEnum.Block.FiftyEight, Encoding.ASCII.GetBytes(data[1]), KeyType.KeyA, key);

                ////Write patients PhoneNumber.
                data = SplitData(tbPhoneNo.Text, Blocklength, 1);
                SVC.Write(deviceId, (byte)BlockEnum.Block.SixtyFour, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);

                ////Write patient's Next of Kin to Tag.
                data = SplitData(tbPatientNOK.Text, Blocklength, 2);
                SVC.Write(deviceId, (byte)BlockEnum.Block.Eighty, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);
                SVC.Write(deviceId, (byte)BlockEnum.Block.EightyOne, Encoding.ASCII.GetBytes(data[1]), KeyType.KeyA, key);

                ////Next of kin Contact address to the Tag.

                data = SplitData(tbContactAddress.Text, Blocklength, 2);
                SVC.Write(deviceId, (byte)BlockEnum.Block.FiftyTwo, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);
                SVC.Write(deviceId, (byte)BlockEnum.Block.FiftyFour, Encoding.ASCII.GetBytes(data[1]), KeyType.KeyA, key);

                ////Write Next of Kin Telephone to the Tag.

                data = SplitData(tb_PhoneNo.Text, Blocklength, 1);
                SVC.Write(deviceId, (byte)BlockEnum.Block.SeventyTwo, Encoding.ASCII.GetBytes(data[0]), KeyType.KeyA, key);

                ////Write Patients Photo.

                int size = Photo.Length;
                SVC.Write(deviceid, (byte)BlockEnum.Block.One, Utility.Util.ConvertIntToBytes(size, 16), KeyType.KeyA, key);
                string msg = string.Empty;
                Write(size, SVC, Photo, 128, 255, ref msg);

                //Write Patients FingerPrint.
                //write size of fingerprint & data to card/tag.

                SVC.Write(0, 2, Utility.Util.ConvertIntToBytes(512, 16), KeyType.KeyA, key);
                Write(512, SVC, bioTemplate, 12, 127, ref msg);


                this.Cursor = Cursors.Default;

                return true;

             }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void Write (int size, MifareService service, byte[] buffer, byte startIndex, byte upperBoundary, ref string msg)
         {
             int index = 0;
             bool isDone = false;
             byte[] data = new byte[16];

             for (byte henrybyte = startIndex; henrybyte < upperBoundary && !isDone; henrybyte++)
             {
                 data = new byte[16];
                 for (int nwatu = 0; nwatu < 16; nwatu++)
                 {
                     if (index < size)
                         data[nwatu] = buffer[index++];
                     else
                     {
                         isDone = true;
                         break;
                     }
                 }

                 try { service.Write(0, henrybyte, data, KeyType.KeyA, key); }
                 catch
                 {

                     try { service.Write(0, ++henrybyte, data, KeyType.KeyA, key); }
                     catch (Exception ex)
                     {
                         msg = "Error Writing Fingerprint data to the Card. \n\n" + ex.Message;
                         break;
                     }

                 }
             }

         }


         private bool ReadDataFromTag()
         {
             //this.Cursor = Cursors.WaitCursor;
             try
             {
                 tbFirstname.Text = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Five, KeyType.KeyA, key)) +
                     Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Six, KeyType.KeyA, key)).Trim();

                 tbOthernames.Text = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Eight, KeyType.KeyA, key)) +
                   Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Nine, KeyType.KeyA, key)).Trim();

                 tbSurname.Text = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Ten, KeyType.KeyA, key)) +
                    Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Ninty, KeyType.KeyA, key)).Trim();

                 cbSex.SelectedItem= Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.SixtyEight, KeyType.KeyA, key)).TrimEnd();
                 //Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.EightyOne, KeyType.KeyA, key)).TrimEnd();

                 cbBG.SelectedItem = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.SixtyNine, KeyType.KeyA, key)).TrimEnd();
                 //Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Six, KeyType.KeyA, key)).Trim();

                 cbGenotype.SelectedItem = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Seventy, KeyType.KeyA, key)).TrimEnd();
                 // Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Six, KeyType.KeyA, key))

                 tbAddress.Text = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Sixty, KeyType.KeyA, key)) +
                     Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.SixtyOne, KeyType.KeyA, key)) +
                     Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.SixtyTwo, KeyType.KeyA, key)).Trim();
                     //Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.SixtyFour, KeyType.KeyA, key)).TrimEnd();

                 tbPatientNOK.Text = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.Eighty, KeyType.KeyA, key)) +
                     Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.EightyOne, KeyType.KeyA, key)).Trim();

                tb_PhoneNo.Text = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.SeventyTwo, KeyType.KeyA, key)).TrimEnd();

                tbPhoneNo.Text = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.SixtyFour, KeyType.KeyA, key)).TrimEnd();
                
                 tbLocalGovt.Text = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.FiftySeven, KeyType.KeyA, key)) +
                 Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.FiftyEight, KeyType.KeyA, key)).Trim();


                 tbContactAddress.Text = Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.FiftyTwo, KeyType.KeyA, key))+
                   Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.FiftyFour, KeyType.KeyA, key)).Trim();
                 //Encoding.ASCII.GetString(SVC.Read(deviceId, (byte)BlockEnum.Block.FiftyFour, KeyType.KeyA, key)).Trim().Trim();



                 byte[] photobyte = ReadS70BySectors(32, 39);
                 System.IO.MemoryStream ms = new System.IO.MemoryStream(photobyte);
                 picBoxPhoto.Image = Image.FromStream(ms);
                 

                 this.Cursor = Cursors.Default;


                 //Read Fingerprint
                 byte[] finger = ReadS70BySectors(3, 14);
                 byte[] fingerImage = new byte[512];
                 Array.Copy(finger, fingerImage, 512);


                 try
                 {
                     Bitmap map = new Bitmap(180, 320);
                     bioService = new GFPSupremaFpApi(512, 5000, 2);
                     if (bioService.Verify(bioTemplate, bioService.ExtractTemplate(ref map)))
                     {
                       
                         System.Windows.Forms.MessageBox.Show("Operation Successful", "Success");
                     }

                 }
                 catch (Exception ex) { }

             }
             catch (Exception ex) { }

             return true;
         }
             
            
                           

              
         private byte[] ReadS70BySectors(byte startSectorAddress, byte endSectorAddress)
         {
             ulong lengthOfData = 0;
             byte [] buffer = new byte[3440];
             byte[] lowerSectors = new byte[48];
             byte[] higherSectors = new byte[240];
             int count = 0;

             for (byte i = startSectorAddress; i < endSectorAddress + 1; i++)
             {
                 if (i < 32)
                 {
                     SVC.ReadS70BySector(0, 0, startSectorAddress++, 0x60, key, ref lowerSectors, ref lengthOfData);
                     for (int j = 0; j < lowerSectors.Length; j++)
                     {
                         buffer[count++] = lowerSectors[j];
                     }


                 }
                 else
                 {
                     SVC.ReadS70BySector(0, 1, i, 0x60, key, ref higherSectors, ref lengthOfData);
                     for (int k = 0; k < higherSectors.Length; k++)
                     {
                         buffer[count]= higherSectors[k];
                     }
                 }
             }
             return buffer;

         }

         private void btnClear_Click(object sender, EventArgs e)
         {
             ClearPatientDetails(); 
         }

         void ClearPatientDetails() 
         {
             foreach (Control cont in this.Controls) 
             {
                 if (cont is PictureBox) 
                 {
                     if ((cont as PictureBox).Image != null) 
                     {
                         picBoxPhoto.Image = EBHIS.Properties.Resources.Human_Silhoute;
                         picBoxFinger.Image = EBHIS.Properties.Resources.ThumpPrint;
                     }
                 }
                 if (cont is TextBox) 
                 {
                     if ((cont as TextBox).Text != string.Empty) 
                     {
                         tbFirstname.Text = string.Empty;
                         tbOthernames.Text = string.Empty;
                         tbSurname.Text = string.Empty;
                         tbPhoneNo.Text = string.Empty;
                         tbPatientNOK.Text = string.Empty;
                         tbNHISN0.Text = string.Empty;
                         tbLocalGovt.Text = string.Empty;
                         tbContactAddress.Text = string.Empty;
                         tbAddress.Text = string.Empty;
                         tb_PhoneNo.Text = string.Empty;
                     }
                     if(cont is ComboBox)
                     {
                         if ((cont as ComboBox).SelectedItem  != null) 
                         {
                             cbSex.SelectedItem = null; 
                             cbBG.SelectedItem = null;
                             cbGenotype.SelectedItem = null;
                         }
                     }
                 }
             }
         
         }

      }
   
   }


