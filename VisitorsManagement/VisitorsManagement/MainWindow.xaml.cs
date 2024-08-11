using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MifareLibrary;
using System.Drawing;
using ChinaReaderMifareLibrary;
using System.IO.Ports;
using CameraDriver1;
using Utility;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using Brushes = System.Windows.Media.Brushes;

namespace VisitorsManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String cs = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        System.Windows.Controls.Image img = new System.Windows.Controls.Image();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        MifareService ms;
        private string cardSN = string.Empty;
        readonly int BaudRate = 19200;
       // readonly int BlockLength = 16;
        int _Port = 3;
        byte[] dbPhoto;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbPort.ItemsSource = SerialPort.GetPortNames();
            if(cbPort.SelectedIndex != -1)
            {
                btnConnect.IsEnabled = false;
            }
        }

        private void CbPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          if(cbPort.SelectedIndex != -1)
            {
                btnConnect.IsEnabled = true;
            }
            try
            {
                string v = cbPort.SelectedItem.ToString();
                _Port = int.Parse(v.Substring(3, 1));
            }
            catch( Exception ex)
            {
                _Port = 3;
            }
        }
      
        

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            string msg = string.Empty;
            if (EstablishConnectionToReader(ref msg))
            {
                tbVisitorId.Text = "";
                lblConnectionStatus.Foreground = Brushes.Green;
                lblConnectionStatus.Content = "Connected";
            }
            else
            {
                lblConnectionStatus.Content = msg;

            }

            TagType type = ms.GetTagType(0, Mode.RequestNonHaltCard);
            if(type == TagType.None)
            {
                Utility.Messages.DisplayCustomStatusMessageWarning("Smart Card not detected");
            }
            else if(type != TagType.S70)
            {
                Utility.Messages.DisplayCustomStatusMessageWarning("Wrong Card");
            }
            byte len = 0;
            try
            {
                cardSN = ms.GetTagSerialNumber(0, ref len);
                tbVisitorId.Text = cardSN;
            }
            catch(Exception ex) { }
        }
        private bool EstablishConnectionToReader(ref string message)
        {
            ms = new MifareService(new S70(new ChinaReaderMifareLibrary.ChinaReaderMifareDll()));
            try
            {
                Error status = ConnectReader(_Port, BaudRate);
                if (status == Error.NotConnected)
                {
                    lblConnectionStatus.Foreground = Brushes.Red;
                    message = "The reader cannot be detected. Make sure the reader is plugged in correctly to the PC and try again.";
                    //return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;//DisplayStatusMessage(ex.Message);
            }

            return false;
        }
        private Error ConnectReader(int port, int baud)
        {
            try
            {
                ms.Connect(port, baud);
                return Error.Connected;
            }
            catch { return Error.NotConnected; }
            
        }

        private void BtnCapture_Click(object sender, RoutedEventArgs e)
        {
            CameraWin cam = new CameraWin();
            cam.PictureAcquired += new PhotoAcquiredEventHandler(cam_PictureAcquired);
            cam.ShowDialog();

        }
        Byte[] cphoto;
        public void cam_PictureAcquired(object sender, PhotoAcquiredEventArgs e)
        {
            ImgPhoto.Source = e.ImageSource;
            cphoto = e.resizedBMPbyte;
            dbPhoto = e.normalPhotobyte;
        }
        
        private void Btnsave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblVisitorsTable(VISITORID,FIRSTNAME,MIDDLENAME,LASTNAME,VISITOR_ORG,WHOMTOSEE,HOST_DEPT,VISITOR_STATUS,DAY_VISITED,PHOTO) VALUES(@VisitorId,@firstname,@middlename,@lastname,@Visitor_Org,@whomToSee,@Host_Dept,@Visitor_Status,@Day_Visited,@photo)",conn);
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new SqlParameter("VISITORID",tbVisitorId.Text));
                    cmd.Parameters.Add(new SqlParameter("FIRSTNAME", tbFirstName.Text.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("MIDDLENAME", tbMiddleName.Text.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("LASTNAME", tbLastName.Text.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("VISITOR_ORG",tbOrganization.Text.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("WHOMTOSEE",tbWhomToSee.Text.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("HOST_DEPT",cbHostDept.Text.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("VISITOR_STATUS",cbStatus.Text.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("DAY_VISITED", dpDayVisited.Text.Trim()));
                    
                    BitmapImage img = (BitmapImage)ImgPhoto.Source;
                    byte[] imgbyte = Util.ImageToByteArray(img);
                        cmd.Parameters.Add(new SqlParameter("PHOTO", imgbyte));
                    int result = cmd.ExecuteNonQuery();
                    if(result == 1)
                    {
                        MessageBox.Show("Saved successfully.","Data Message");
                        tbVisitorId.Text = string.Empty;

                        
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            tbVisitorId.Text = string.Empty;
            tbFirstName.Text = string.Empty;
            tbMiddleName.Text = string.Empty;
            tbLastName.Text = string.Empty;
            tbOrganization.Text = string.Empty;
            tbWhomToSee.Text = string.Empty;
            cbHostDept.Text = string.Empty;
            cbStatus.Text = string.Empty;
            dpDayVisited.Text = string.Empty;
            ImgPhoto.Source = null;
        }
        //// Convert a BitmapImage into a byte array.
        //private byte[] ImageToByteArray(System.Drawing.Image image)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        image.Save(ms, image.RawFormat);
        //        return ms.ToArray();
        //    }


        //}
    }
    enum Error
    {
        ReadError,
        WriteError,
        Connected,
        NotConnected,
        CardNotS50,
        CardDetected,
        CardNotDetected,
        FingerNotDetected,
        FingerprintMatchUnsuccessful
    }

    enum State
    {
        WriteSuccess,
        WriteError,
        WriteBlockSuccess,
        WritingDone,
        Connected,
        NotConnected,
        CardNotS70,
        AlreadyVoted,
        CardDetected,
        CardNotDetected,
        VoterAuthenticated,
        VoterNotAuthenticated,
        FingerNotDetected,
        FingerprintMatchUnsuccessful
    }

}
