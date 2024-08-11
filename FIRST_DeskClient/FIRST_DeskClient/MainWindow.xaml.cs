using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using RfidApiLib;
using System.IO.Ports;
using System.Drawing;
using System.Windows.Threading;
using CameraDriver1;
using Utility;
using System.IO;



namespace FIRST_DeskClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RfidApi Api = new RfidApi();
        public int TagCnt = 0;
        public MainWindow()
        {
            InitializeComponent();
            txtTagNo.Text = "";
            int status;
            string ComPort = "COM3";           
            byte v1 = 0;
            byte v2 = 0;
            string s = "";          

            status = Api.OpenCommPort(ComPort);
            if (status != 0)
            {
                MessageBox.Show("Open COM3 Port Failed!", "COM Port");
                return;
                
            }
            status = Api.GetFirmwareVersion(ref v1, ref v2);
            if (status != 0)
            {
                MessageBox.Show("Cannot Connect with reader");
                Api.CloseCommPort();
                return;
            }
           // MessageBox.Show("Connection to reader is successful");
            s = string.Format("The reader's firmware version is:V{0:d2}.{1:d2}", v1, v2);
           // MessageBox.Show(s);
            imgFetchTagNo.IsEnabled = true;
            imgFetchUserDetails.IsEnabled = true;
            btnOk.IsEnabled = true;
            this.bRfQuery_Click(null, null);
            this.bAntQuery_Click(null, null);           
        }

        
        private void bRfQuery_Click(object sender, EventArgs e)
        {
            byte pwr = 0;
            byte freq = 0;

            int status;

            status = Api.GetRf(ref pwr, ref freq);
            if (status != 0)
            {
                MessageBox.Show("Get Rf settings failed!");               
                return;
            }
            RfSet();
           // MessageBox.Show("Get Rf settings success!");
        }
        private void RfSet()
        {
            byte pwr = 0;
            byte freq = 0;

            int status;
            pwr = (byte)(1);
            freq = (byte)(0);
            status = Api.SetRf(pwr, freq);
            if (status != 0)
            {
                MessageBox.Show("Set Rf settings failed!");
                return;
            }
            //lInfo.Items.Add("Set Rf settings success!");
        }

        private void bAntQuery_Click(object sender, EventArgs e)
        {
            byte ant_sel = 0;

            int status;

            status = Api.GetAnt(ref ant_sel);
            if (status != 0)
            {
                MessageBox.Show("Get Ant settings failed!");
                return;
            }
           // MessageBox.Show("Get Ant settings success!");           
        }

       
        private void imgFetchTagNo_MouseUp(object sender, MouseButtonEventArgs e)
        {            
            Api.ClearIdBuf();
            txtTagNo.Text = "";
            TagCnt = 0;
            DispatcherTimer dispatcherTimer2 = new DispatcherTimer();
            dispatcherTimer2.Tick += new EventHandler(dispatcherTimer2_Tick);
            dispatcherTimer2.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer2.Start();
            DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
            dispatcherTimer1.Tick += new EventHandler(dispatcherTimer1_Tick);
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer1.Start();

        }
        private void dispatcherTimer1_Tick(object sender, EventArgs e)
        {
            Api.ClearIdBuf();
        }
        private void dispatcherTimer2_Tick(object sender, EventArgs e)
        {
            int status;
            int i, j;
            byte[,] IsoBuf = new byte[100, 12];
            byte tag_cnt = 0;
            string s = "";
            string s1 = "";
            byte tag_flag = 0;

            status = Api.EpcMultiTagIdentify(ref IsoBuf, ref tag_cnt, ref tag_flag);

            if (tag_cnt > 0)
            {
                for (i = 0; i < tag_cnt; i++)
                {
                   // s1 = string.Format("NO.{0:D}: ", TagCnt + 1);
                    for (j = 0; j < 12; j++)
                    {
                        s = string.Format("{0:X2} ", IsoBuf[i, j]);
                        s1 += s;
                    }                    
                    txtTagNo.Text = s1;
                    TagCnt++;                    
                    Api.ClearIdBuf();
                }
            }
        }

        public void IdentifyVehicle(string s)
        {            
            if ((s != null || s != string.Empty) && s.StartsWith("N"))
            {
                s = s.Remove(s.IndexOf('N'), s.IndexOf(": ") + 2);
                s = s.TrimEnd(new char[] { ' ' });

            }
        }
        private void imgFetchUserDetails_MouseUp(object sender, MouseButtonEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=localhost;Initial Catalog=FIRSTProject;Integrated Security=True";
                try
                {
                    conn.Open();
                    SqlCommand command3 = new SqlCommand("SELECT Laptop.SerialNumber, Laptop.LaptopModel,Laptop.LaptopMaker," +
                        " Laptop.TagID, USERrecords.FirstName, USERrecords.MiddleName,USERrecords.Photo, USERrecords.LastName, " +
                        "USERrecords.LaptopID FROM Laptop INNER JOIN USERrecords ON" +
                        " Laptop.LaptopID = USERrecords.LaptopID where UserID ='" + txtStaffId.Text.Trim() + "'", conn);
                    SqlDataReader reader = command3.ExecuteReader();
                    
                    if (reader.Read())

                    {

                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtMiddleName.Text = reader["MiddleName"].ToString();
                        txtManufacturer.Text = reader["LaptopMaker"].ToString();
                        txtModel.Text = reader["LaptopModel"].ToString();
                        txtSN.Text = reader["SerialNumber"].ToString();
                        txtTagNo.Text = reader["TagID"].ToString();
                        if ((reader["Photo"] != System.DBNull.Value))
                        {
                            imgStaffPhoto.Source = Util.ConvertByteToImage((byte[])reader["Photo"]);
                        }
                        else
                            imgStaffPhoto.Source = new BitmapImage(new Uri("/FIRST_DeskClient;component/Images/silhouette.png", UriKind.Relative));
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Error Occured " + ex.Message);
                }
                finally
                {
                    conn.Close();

                }
            }
        }

       
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string IsActive;
            if (chbDeactivateTag.IsChecked == true)
            {
                IsActive = "False";

            }
            else if (chbDeactivateTag.IsChecked == false)
            {
                IsActive = "True";

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=localhost;Initial Catalog=FIRSTProject;Integrated" +
                        " Security=True";
                    try
                    {
                        conn.Open();
                        //MessageBox.Show("Connection Open ! ");

                        SqlCommand command1 = new SqlCommand("INSERT INTO Laptop (LaptopID, SerialNumber, LaptopModel," +
                            " LaptopMaker, IsActive,TagID)VALUES(@LaptopID, @SerialNo, @LaptopModel, @LaptopMaker," +
                            " @IsActive,@TagID)", conn);
                        
                        command1.Parameters.AddWithValue("@SerialNo", txtSN.Text);
                        command1.Parameters.AddWithValue("@LaptopModel", txtModel.Text);
                        command1.Parameters.AddWithValue("@LaptopMaker", txtManufacturer.Text);
                        command1.Parameters.AddWithValue("@IsActive", IsActive);
                        command1.Parameters.AddWithValue("@TagID", txtTagNo.Text);
                        command1.Parameters.AddWithValue("@LaptopID", txtModel.Text + txtSN.Text);

                        //int AffectedRows;
                        //AffectedRows = command1.ExecuteNonQuery();
                        //MessageBox.Show(AffectedRows + " rows inserted!");
                        command1.ExecuteNonQuery();

                        SqlCommand command2 = new SqlCommand("INSERT INTO USERrecords (UserID, FirstName, MiddleName, " +
                            "LastName, Photo,LaptopID) VALUES (@StaffID, @FirstName, @MiddleName, @LastName, @Photo, @LaptopID)", conn);                        
                        command2.Parameters.AddWithValue("@StaffID", txtStaffId.Text);
                        command2.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command2.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        command2.Parameters.AddWithValue("@LastName", txtLastName.Text);                        
                        command2.Parameters.AddWithValue("@LaptopID", txtModel.Text + txtSN.Text);
                        command2.Parameters.AddWithValue("@Photo", _dbPhoto);
                        command2.ExecuteNonQuery();
                        MessageBox.Show("Details Added");                        
                    }
                    catch (SqlException ex)
                    {                       
                        MessageBox.Show("Error Occured " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();

                    }
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Api.ClearIdBuf();
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtManufacturer.Text = "";
            txtMiddleName.Text = "";
            txtModel.Text = "";
            txtSN.Text = "";
            txtStaffId.Text = "";
            txtTagNo.Text = "";
            imgStaffPhoto.Source = new BitmapImage(new Uri("/FIRST_DeskClient;component/Images/silhouette.png", UriKind.Relative));//Bitmap("../Images/silhouette.png"));
        }

        private void btnStartReading_Click(object sender, RoutedEventArgs e)
        {
            Api.ClearIdBuf();
            txtTagNo.Text = "";
            TagCnt = 0;
            DispatcherTimer dispatcherTimer3 = new DispatcherTimer();
            dispatcherTimer3.Tick += new EventHandler(dispatcherTimer3_Tick);
            dispatcherTimer3.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer3.Start();
            DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
            dispatcherTimer1.Tick += new EventHandler(dispatcherTimer1_Tick);
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer1.Start();
        }

        private void dispatcherTimer3_Tick (object sender, EventArgs e)
        {
            int status;
            int i, j;
            byte[,] IsoBuf = new byte[100, 12];
            byte tag_cnt = 0;
            string s = "";
            string s1 = "";
            byte tag_flag = 0;

            status = Api.EpcMultiTagIdentify(ref IsoBuf, ref tag_cnt, ref tag_flag);

            if (tag_cnt > 0)
            {
                for (i = 0; i < tag_cnt; i++)
                {                    
                    for (j = 0; j < 12; j++)
                    {
                        s = string.Format("{0:X2} ", IsoBuf[i, j]);
                        s1 += s;
                    }
                                      
                    Identify(s1);
                    
                    TagCnt++;
                    
                   // Api.ClearIdBuf();
                }
            }
        }
        private void Identify(string s)
        {
           
            String status = null;
            String StatusID = null;
            String LaptopID = null;
            if ((s != null || s != string.Empty) )
            {
               // s = s.Remove(s.IndexOf('N'), s.IndexOf(": ") + 2);
                s = s.TrimEnd(new char[] { ' ' });
               
                //if (s == "E2 00 90 06 38 0D 01 77 25 70 12 36" ^ s == "E2 00 90 06 38 0D 02 02 17 90 5F 90"
                //    ^ s == "E2 00 90 06 38 0D 01 76 12 20 9D 07" ^ s == "E2 00 90 06 38 0D 01 85 12 50 97 A2")
                {


                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = "Data Source=localhost;Initial Catalog=FIRSTProject;Integrated Security=True";
                        try
                        {
                            conn.Open();
                          
                            SqlCommand command1 = new SqlCommand("SELECT Laptop.LaptopID, Laptop.SerialNumber, " +
                                "Laptop.LaptopModel, Laptop.LaptopMaker, Laptop.TagID, USERrecords.UserID, " +
                                "USERrecords.FirstName, USERrecords.MiddleName, USERrecords.Photo,USERrecords.LastName FROM " +
                                "Laptop INNER JOIN USERrecords ON Laptop.LaptopID = USERrecords.LaptopID  " +
                                "where Laptop.TagID = '" + s + "' ", conn);
                            using (SqlDataReader reader = command1.ExecuteReader())
                            {

                                if (reader.Read())
                                {

                                    lblStaffId.Content = reader["UserID"].ToString();
                                    lblFirstName.Content = reader["FirstName"].ToString();
                                    lblLastName.Content = reader["LastName"].ToString();
                                    lblMiddleName.Content = reader["MiddleName"].ToString();
                                    lblSN.Content = reader["SerialNumber"].ToString();
                                    lblManufacturer.Content = reader["LaptopMaker"].ToString();
                                    lblModel.Content = reader["LaptopModel"].ToString();
                                    if ((reader["Photo"] != System.DBNull.Value))
                                    { 
                                        image1.Source = Util.ConvertByteToImage((byte[])reader["Photo"]);
                                    }
                                    else
                                        image1.Source = new BitmapImage(new Uri("/FIRST_DeskClient;component/Images/silhouette.png", UriKind.Relative));
                                    LaptopID = reader["LaptopID"].ToString();                                                              
                                    
                                  //  MessageBox.Show("command1 executed");
                                    reader.Close();

                                    SqlCommand command2 = new SqlCommand("SELECT TOP (1) Status FROM EventLog" +
                                        " where LaptopID='" + LaptopID + "'  order by Timestamp desc", conn);
                                    using (SqlDataReader reader2 = command2.ExecuteReader())
                                    {

                                        if (reader2.Read())
                                        {

                                            status = reader2["Status"].ToString();
                                            //MessageBox.Show(status);
                                            if (status == "True")
                                            {
                                                label24.Content = "OUT";
                                                StatusID = "0";
                                            }
                                            if (status == "False")
                                            {
                                                label24.Content = "IN";
                                                StatusID = "1";
                                            }
                                           
                                        }
                                        
                                        reader2.Close();
                                    }
                                           

                                    SqlCommand command3 = new SqlCommand("INSERT INTO EventLog (LaptopID, Status, TimeStamp) VALUES (@LaptopID, @Status, @TimeStamp)", conn);
                                    command3.Parameters.AddWithValue("@LaptopID", LaptopID);
                                    if (StatusID == null)
                                    {
                                        StatusID = "0";
                                        label24.Content = "OUT";
                                    }

                                    command3.Parameters.AddWithValue("@Status", StatusID);
                                    command3.Parameters.AddWithValue("@TimeStamp", DateTime.Now);
                                    command3.ExecuteNonQuery();
                                   // MessageBox.Show("command3 successful");
                                    command3.Dispose();
                                    command1.Dispose();

                                }
                            }
                        }

                        catch (SqlException ex)
                        {
                            MessageBox.Show("Error Occured " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();

                        }
                    }
                }
            }
        }

        private void btnStopReading_Click(object sender, RoutedEventArgs e)
        {
            Api.CloseCommPort();

        }

        private void btnTakePhoto_Click(object sender, RoutedEventArgs e)
        {
            CameraWin cam = new CameraWin();
            cam.PictureAcquired += new PhotoAcquiredEventHandler(cam_PictureAcquired);
            cam.ShowDialog();
        }
        byte[] cPhoto;
        byte[] _dbPhoto;
        public void cam_PictureAcquired(object sender, PhotoAcquiredEventArgs e)
        {
            imgStaffPhoto.Source = e.ImageSource;//Util.ConvertBitmapToImageSource(e.normalPhoto);
            cPhoto = e.resizedBMPbyte;//Util.ConvertBitmapToByte(e.resizedPhoto);
            //dbPhoto = e.normalPhoto;
            _dbPhoto = e.normalPhotobyte;
        }


        public byte[] ImageSourceToBytes(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();              
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
             using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=localhost;Initial Catalog=FIRSTProject;Integrated" +
                        " Security=True";
                    try
                    {
                        conn.Open();
                        //MessageBox.Show("Connection Open ! ");

                        SqlCommand command1 = new SqlCommand(string.Format("Update Laptop set LaptopID ='{0}', SerialNumber='{1}'," +
                            "LaptopModel='{2}', LaptopMaker='{3}', TagID='{4}' where laptopid='{5}'", txtModel.Text + txtSN.Text, txtSN.Text,
                            txtModel.Text, txtManufacturer.Text, txtTagNo.Text, txtModel.Text + txtSN.Text), conn);                         
                                              
                        command1.ExecuteNonQuery();

                        SqlCommand command2 = new SqlCommand("UPDATE USERrecords SET UserID=@StaffID, FirstName= @FirstName, MiddleName=@MiddleName, " +
                            "LastName=@LastName, Photo=@Photo,LaptopID=@LaptopID where userid=@StaffID", conn);                        
                        command2.Parameters.AddWithValue("@StaffID", txtStaffId.Text);
                        command2.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command2.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        command2.Parameters.AddWithValue("@LastName", txtLastName.Text);                        
                        command2.Parameters.AddWithValue("@LaptopID", txtModel.Text + txtSN.Text);
                        command2.Parameters.AddWithValue("@Photo", ImageSourceToBytes(imgStaffPhoto.Source  as BitmapImage));
                        command2.ExecuteNonQuery();
                        MessageBox.Show("Details Added");                        
                    }
                    catch (SqlException ex)
                    {                       
                        MessageBox.Show("Error Occured " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();

                    }
                }
            }
        }
    }
