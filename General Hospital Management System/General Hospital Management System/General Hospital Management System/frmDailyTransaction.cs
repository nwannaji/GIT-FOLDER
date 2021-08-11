using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class frmDailyTransaction : Form
    {
        ClsSelect selectClass = new ClsSelect();
        ClsInsert varInsert = new ClsInsert();
        public frmDailyTransaction()
        {
            InitializeComponent();
        }

        private void frmDailyTransaction_Load(object sender, EventArgs e)
        {
            selectClass.viewDailTransact(DgridView);
            lblTotal.Text = "Total Number of Transaction: " + DgridView.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(tbPatientFName.Text.Trim() != "")
            {
                SqlConnection con = new SqlConnection(selectClass.connectionString);
                con.Open();
                string query = "SELECT ReceiptNo as [Receipt Number],PatientName as [Patient Number],TransactionDate as [Transaction Date],TransactionTime as [Transaction Time],Amts as [Amount Paid],AmtBalance as [Balance],TransactedBy as [Transaction By] FROM DailyTransaction WHERE PatientName like '%"+tbPatientFName.Text.Trim()+"%'";
                SqlCommand cmd = new SqlCommand(query,con);
                DataSet dset = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dset,query);
                DgridView.DataSource = dset;
                DgridView.DataMember = query;
                MessageBox.Show(DgridView.RowCount.ToString()+" Record(s) found","Search Result-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Record(s) not found","Search Rseult-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmap = new Bitmap(this.DgridView.Width, this.DgridView.Height);
            DgridView.DrawToBitmap(bmap, new Rectangle(0, 0, this.DgridView.Width, this.DgridView.Height));
            e.Graphics.DrawImage(bmap, 0, 0);
        }
    }
}
