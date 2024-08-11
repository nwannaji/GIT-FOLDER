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


namespace MembershipCard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(MemberData.MemberData memberData) 
        {
            InitializeComponent();
            LoadCardDetails(memberData);
        }

        private void LoadCardDetails(MemberData.MemberData data)
        {

            string title = data.Title;//lblSurname.Content = data.Surname;
            string firstName = data.FirstName;//lblOtherNames.Content = data.Othernames;
            string middleName = data.MiddleName;
            string lastName = data.LastName;
            string regNo = data.RegNo;
            string membershipGrade = data.Rank;
            iMemberPhoto.Source = Utility.Util.ConvertByteToImage(data.Photo);
            if (middleName != string.Empty)
              tblkTitleNames.Text = title + " " + firstName + " " + middleName + " " + lastName;
            else tblkTitleNames.Text = title + " " + firstName + " " + lastName;
            lblMembershipGrade.Content = membershipGrade;
            lblRegNo.Content = regNo;
            
        }
        
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
                dialog.PrintVisual(_printCanvas, "Voter Registration Details");
        }
    }
}
