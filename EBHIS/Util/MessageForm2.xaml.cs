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
    public partial class MessageForm2 : Window
    {
        public MessageForm2()
        {
            InitializeComponent();
        }

        public MessageForm2(string Message)
        {
            InitializeComponent();
            this.txtBlcMessage.Text = Message;
            SoundPlayer sound = new SoundPlayer(Properties.Resources.Warning1);//("..\\..\\Sounds\\sfx_stars_collect_6.wav");
            sound.Play();
        }


        public MessageBoxResult ShowMessage() 
        {
            this.ShowDialog();
            return ret;
        }

        
        
        MessageBoxResult ret;
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            ret = MessageBoxResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            ret = MessageBoxResult.No;
            this.Close();            
        }
                
    }
}
