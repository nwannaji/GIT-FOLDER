using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace Utility
{
    /// <summary>
    /// Interaction logic for MessageForm.xaml
    /// </summary>
    public partial class MessageForm : Window
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        public MessageForm(string Message, MessageBoxImage success)
        {
            InitializeComponent();
            this.txtBlcMessage.Text = Message;
            imgMessageBoxImage.Source = Util.ConvertBitmapToImageSource(Properties.Resources.Warning);
            SoundPlayer sound = new SoundPlayer(Properties.Resources.Success);//("..\\..\\Sounds\\sfx_stars_collect_6.wav");
            sound.Play();
        }

        public MessageForm(string Message)
        {
            InitializeComponent();
            
            this.txtBlcMessage.Text = Message;
            SoundPlayer sound = new SoundPlayer(Properties.Resources.Warning1);//("..\\..\\Sounds\\sfx_stars_collect_6.wav");
            sound.Play();
        }

       
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
