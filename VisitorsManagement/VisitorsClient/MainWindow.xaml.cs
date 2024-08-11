using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Drawing.Printing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.IO.Ports;
using System.Configuration;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChinaReaderMifareLibrary;
using CameraDriver1;
using MifareLibrary;
using Utility;
using System.IO;


namespace VisitorsClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MifareService svc;
        int BuadReate = 19200;
        private string CardSN;
        public MainWindow()
        {
            svc = new MifareService(new S70(new ChinaReaderMifareLibrary.ChinaReaderMifareDll()));
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }
        public void timer_Tick(object sender, EventArgs e)
        {
            lblTimeCount.Content = DateTime.Now.ToLongTimeString();
        }


            int Port = 3;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbReaderPort.ItemsSource = SerialPort.GetPortNames();
            if(cbReaderPort.SelectedIndex != -1)
            {
                btnConnect.IsEnabled = false;
            }
        }


        private void CbReaderPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbReaderPort.SelectedIndex != -1)
            {
                cbReaderPort.IsEnabled = true;
            }
            try
            {
                string v = cbReaderPort.SelectedItem.ToString();
                Port = int.Parse(v.Substring(3,1));

            }
            catch(Exception ex) { Port = 3; }
            
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            string msg = string.Empty;
            if(EstablishConnectionToReader(ref msg))
            {
                lblConnect.Foreground = Brushes.Green;
                lblConnect.Content = "Mifare Reader Connected";
            }
            else
            {
                lblConnect.Content = msg;
            }
        }
        private bool EstablishConnectionToReader( ref string message)
        {
            svc = new MifareService(new S70(new ChinaReaderMifareLibrary.ChinaReaderMifareDll()));
            try
            {
                Error status = ConnectReader(Port, BuadReate);
                if (status == Error.NotConnected)
                {
                    lblConnect.Foreground = Brushes.Red;
                    message = "The reader cannot be detected.";
                }
                else
                    return true;
               

            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            return false;
        }

        private Error ConnectReader(int port, int baudRate)
        {
            try
            {
                svc.Connect(port, BuadReate);
                return Error.Connected;

            }
            catch{ return Error.NotConnected; }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            String cs = "Data Source=localhost;Initial Catalog=VisitorsDB;Integrated Security=True";
            string sqlconn = "SELECT * FROM tblVisitorsTable";
            using(SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(sqlconn,conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("tblVisitorsTable");
                    sda.Fill(dt);
                    VisitorsGrid.ItemsSource = dt.DefaultView;

                }
                
            }
        }
        byte len = 0;
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TagType type = svc.GetTagType(0, Mode.RequestNonHaltCard);
                if (type == TagType.None)
                {
                    Utility.Messages.DisplayCustomStatusMessageWarning("Smart Card not detected");
                }
                else if (type != TagType.S70)
                {
                    Utility.Messages.DisplayCustomStatusMessageWarning("Wrong Card");
                }
                byte len = 0;
                try
                {
                    tbCardSN.Text = svc.GetTagSerialNumber(0, ref len);
                  
                }
                catch (Exception ex) { }

            }
            catch(Exception ex) {}
            String cs = "Data Source=localhost;Initial Catalog=VisitorsDB;Integrated Security=True";
            string sqlconn = "SELECT * FROM tblVisitorsTable WHERE VISITORID = '"+tbCardSN.Text+"'";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                using(SqlCommand cmd = new SqlCommand(sqlconn, conn))
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("tblVisitorsTable");
                    sda.Fill(dt);
                    VisitorsGrid.ItemsSource = dt.DefaultView;

                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        byte[] imgByte = new byte[0];
                        imgByte = (byte[])((byte[])rd["PHOTO"]);
                        ImgPhoto.Source = Util.ConvertByteToImage(imgByte); // System.Drawing.Image.FromStream(ms)
                        
                    }

                   
                        //conn.Close();

                }


            }

        }

        private void BtnUpdateDB_Click(object sender, RoutedEventArgs e)
        {
           
            if(tbCardSN.Text == svc.GetTagSerialNumber(0,ref len))
            {
                lblTimeCount.Content = DateTime.Now.ToLongTimeString();
                String cs = "Data Source=localhost;Initial Catalog=VisitorsDB;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblVisitorsTable(Time_In) VALUES('"+lblTimeCount.Content+"')",conn);
                    cmd.Connection = conn;
                        cmd.Parameters.Add("Time_In",SqlDbType.DateTime).Value = lblTimeCount.Content;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Time-In Saved Sucessfully.");
                    


                }

            }

        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {

        }
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
