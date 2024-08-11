using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class frmPayments : Form
    {
        ClsSelect selectClass = new ClsSelect();
        double costChange;
        ClsInsert varinsert = new ClsInsert();
        public string cashierName;
        //SqlConnection con;
        //SqlCommand cmd;
        DateTimePicker sysDate = new DateTimePicker();
        // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";

        public frmPayments()
        {
            InitializeComponent();
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            clearAll(); 
        }
        void clearAll()
        {
            tbReceiptNo.Text = selectClass.generatePatientNo().ToString();
            tbPatID.ResetText();
            tbFullname.ResetText();
            tbPayment.ResetText();
            tbBalance.ResetText();
            tbAmountOwe.ResetText();
        }

        private void tbReceiptNo_TextChanged(object sender, EventArgs e)
        {
            if(tbPatID.Text != "")
            {
                if(tbPatID.Text.Length >= 4)
                {
                    selectClass.selectPatientDetailsFromBill(tbPatID.Text);
                    tbFullname.Text = selectClass.fullName;
                    tbAmountOwe.Text = selectClass.patBill.ToString();
                }
            }
        }
        private void tbPayment_TextChanged(object sender, EventArgs e)
        {
            double paymentValue;
            if(tbPayment.Text != "")
            {
                if(double.TryParse(tbPayment.Text.Trim(),out paymentValue))
                {
                    tbBalance.Text = (double.Parse(tbAmountOwe.Text.Trim()) - paymentValue).ToString();
                }
                else
                {
                    tbBalance.Text = "E";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tbBalance.Text == "E")
            {
                MessageBox.Show("Invalid Transaction");
                return;
            }
            else
            {
                CalPatientBills();
            }
        }
        void CalPatientBills()
        {
            try
            {
                if (tbPatID.Text != "")
                {
                    if (tbAmountOwe.Text == "0")
                    {
                        tbBalance.Text = "0";
                        MessageBox.Show("Patient owes no debt", "Save-Data GHMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        if (double.Parse(tbBalance.Text) < 0.00)
                        {
                            costChange = double.Parse(tbPayment.Text) - double.Parse(tbAmountOwe.Text);
                            tbBalance.Text = 0.0.ToString();
                            if (MessageBox.Show("Do you want to continue this transaction?" + Environment.NewLine + "Balance of: " + "# " + costChange, "CONFIRM TRANSACTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                updateBalance();
                                varinsert.insertIntoDailyTransaction(tbReceiptNo.Text, tbPatID.Text, tbFullname.Text, sysDate, sysDate, double.Parse(tbPayment.Text), double.Parse(tbBalance.Text), cashierName);
                                varinsert.insertIntoGenReceiptNo(selectClass.GenerateReceiptNumber().ToString());

                                printDocument1.Print();
                                tbReceiptNo.Text = "GHMS Receipt N0: " + selectClass.GenerateReceiptNumber().ToString();
                                clearAll();
                            }

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        void updateBalance()
        {
            string BillUpdate;
            SqlConnection con;
            try
            {
                con = new SqlConnection(varinsert.connectionString);
                con.Open();
                BillUpdate = $"UPDATE tblPatientBill SET Amts = '{double.Parse(tbBalance.Text)}' WHERE patID = '{tbPatID.Text}' AND patName = '{tbFullname.Text}'";
                SqlCommand cmd = new SqlCommand(BillUpdate,con);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payment Successfull Updated","Save-Data",MessageBoxButtons.OK,MessageBoxIcon.Information);


                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font pfont;
            DateTime mydate = new DateTime();
            int StartXpos = 0, StartYpos = 0, offset = 40;
            mydate = DateTime.Now;

            pfont = new Font("Times New Roman", 10);
            e.Graphics.DrawString("General Hospital Management Solution" + Environment.NewLine, pfont, Brushes.Black, StartXpos, StartYpos);
            e.Graphics.DrawString("PMB 202 East West Road TransEkulu, Enugu,Tel:+234909996662-4" + Environment.NewLine, new Font("Times New Roman", 10), Brushes.Black, 0, 30);
            e.Graphics.DrawString(mydate.ToString("F") + Environment.NewLine, new Font("Times New Roman", 10), Brushes.Black, 0, 50);
            e.Graphics.DrawString("Receipt No.: " + tbReceiptNo.Text.PadRight(30) + Environment.NewLine, new Font("Times New Roman", 10), new SolidBrush(Color.Black), 0, 70 + offset);
            e.Graphics.DrawString("Patient Fullname.: " + tbFullname.Text.PadRight(30) + Environment.NewLine, new Font("Times New Roman", 10), new SolidBrush(Color.Black), 0,90 + offset);
            e.Graphics.DrawString("Patient ID.: " + tbPatID.Text.PadRight(30) + Environment.NewLine, new Font("Times New Roman", 10), new SolidBrush(Color.Black), 0, 110 + offset);
            e.Graphics.DrawString("Amount Owed (#): " + tbAmountOwe.Text, new Font("Times New Roman", 10), new SolidBrush(Color.Black), 0, 130 + offset);
            e.Graphics.DrawString("Amount Paid (#): " + tbPayment.Text.PadRight(30) + Environment.NewLine, new Font("Times New Roman", 10), new SolidBrush(Color.Black), 0, 150 + offset);
            e.Graphics.DrawString("Change: " + costChange.ToString().PadRight(30) + Environment.NewLine, new Font("Times New Roman", 10), new SolidBrush(Color.Black), 0, 170 + offset);
            e.Graphics.DrawString("Outstanding Balance: " + tbBalance.Text.PadRight(30) + Environment.NewLine, new Font("Times New Roman", 10), new SolidBrush(Color.Black), 0, 190 + offset);
            e.Graphics.DrawString("Thanks for your patronage. We wish you good health, Your were served by: " + cashierName + Environment.NewLine, new Font("Times New Roman", 10), new SolidBrush(Color.Black), 0, 120 + offset); ;
        }

        
    }
}
