using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Data.SqlClient;

namespace General_Hospital_Management_System
{
    public partial class frmViewBills : Form
    {
        ClsSelect selectClass = new ClsSelect();
        ClsInsert varInsert = new ClsInsert();
        Guna2DateTimePicker dtpAppointment = new Guna2DateTimePicker();
        public frmViewBills()
        {
            InitializeComponent();
        }

        private void frmViewBills_Load(object sender, EventArgs e)
        {
            selectClass.viewBills(DataGridView2);
            selectClass.selectPatientname(cbSearchPatient);
            
        }

        public void selectBills()
        {
            if(dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("(From Date) cannot be greater than to (ToDate)","Error-GHMS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                string query = $"SELECT patID as [Patient ID],Patientname as [Patient Name],TransactionDate as [Transaction Date],TransactionTime as [Transaction Time],Item,Amts as [Price N],TransactedBy as [Server] from ItemsBills where PatientName = '{cbSearchPatient.SelectedItem}' AND TransactionDate >='{dtpFrom.Value.Date}' AND TransactionDate <='{dtpTo.Value.Date}'";
                SqlConnection con = new SqlConnection(selectClass.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                DataSet dset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dset, query);
                DataGridView2.DataSource = dset;
                DataGridView2.DataMember = query;
               
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            selectBills();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
