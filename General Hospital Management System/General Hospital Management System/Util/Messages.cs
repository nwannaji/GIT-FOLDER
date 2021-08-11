using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Utility
{
    public static class Messages
    {

        public static void DisplayStatusMessageWarning(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void DisplayStatusMessageError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void DisplayStatusMessageSuccess(string msg)
        {
            MessageBox.Show(msg, "Operation Successful", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void DisplayMessage(string Message, string Type)
        {
            switch (Type)
            {
                case "Success":
                    MessageBox.Show(Message, Type, MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case "Warning":
                   MessageBox.Show(Message, Type, MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case "Error":
                    MessageBox.Show(Message, Type, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        /********************************************************************************************************/
          //customized message box

        public static void DisplayCustomStatusMessageWarning(string msg)
        {
            new MessageForm(msg).ShowDialog();
        }

        public static void DisplayCustomStatusMessageSuccess(string msg)
        {
            new MessageForm(msg,MessageBoxImage.Hand).ShowDialog();
        }

        public static MessageBoxResult DisplayCustomStatusMessageWarningYesNo(string msg)
        {
            return new MessageForm2(msg).ShowMessage();
        }

        /**********************************************************************************************************/
        
        public static string GetErrorMsg(int errorNumber, string methodName)
        {
            switch (errorNumber)
            {
                case 4060:
                    return "Unable to open the database, the database is either detached or unavailable: login failed;" + methodName;
                case 53:
                    return "unable to locate the Server: check your network;" + methodName;
                case 2:
                    return "The sql Server service on the Server machine is not running or responding: restart the service;" + methodName;
                case -2:
                    return "Timeout expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.";
                default:
                    return "$error$;" + methodName;
            }
        }
    }
}
