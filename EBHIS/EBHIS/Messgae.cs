using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EBHIS
{
   static class Messgae
    {
       public static void DisplayStatusMessageWarning(string msg)
       {
           MessageBox.Show(msg, "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

       }

       public static void DisplayStatusMessageError(string msg)
       {
           MessageBox.Show(msg, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
       }

       public static void DisplayStatusMessageSuccess(string msg)
       {
           MessageBox.Show(msg, "Operation Successful", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
       }
       public static void DisplayStatusMessage(string Message, string Type)
       {
           switch (Type)
           {
               case "Success":
                   MessageBox.Show(Message,Type,MessageBoxButtons.OK,MessageBoxIcon.Information);
                   break;

               case "Error":
                   MessageBox.Show(Message,Type,MessageBoxButtons.OK,MessageBoxIcon.Error);

                   break;

               case "Warning":
                   MessageBox.Show(Message,Type,MessageBoxButtons.OK,MessageBoxIcon.Warning);

                   break;

                  
           }
       }
      
      
      
          
    }
}
