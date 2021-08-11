using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Utility;

namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.PopulateDataGridView();
        }
        private DataTable PopulateDataGridView()
        {
            string query = "SELECT CustomerID,Name,Country FROM Customers";
            string ConString = @"Data Source = localhost; Initial Catalog =TestDB;Integrated Security = True";
            using(SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        private DataTable FilterDataGridView()
        {
            string query = "SELECT CustomerID, Name, Country FROM Customers WHERE Country LIKE '% @Country %'";
            string ConString = @"Data Source = localhost; Initial Catalog =TestDB;Integrated Security = True";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Country", tbName.Text.Trim());
                   // cmd.Parameters.AddWithValue("@Country",cbCountry.SelectedItem.ToString());
                    using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
                
            }
          
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ConString = @"Data Source = localhost;Initial Catalog = TestDB;Integrated Security = True";
            using(SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"INSERT INTO Customers (Name, Country) VALUES('{tbName.Text.Trim()}','{cbCountry.SelectedItem.ToString()}')", con))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Saved Successfully","Data Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    
                }
                con.Close();
                tbName.ResetText();
                cbCountry.ResetText();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.PopulateDataGridView();
            DataTable filterdt = FilterDataGridView();
            for (int i = 0; i < dataGridView1.Rows.Count; i++ )
            {
                //    int Id = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString().Trim());
                 //string country = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                //    DataRow[] dr = filterdt.Select("CustomerID = " + Id + "AND Country = '" + Country + "'");
                //    if (dr.Length > 0)
                //    {
                //        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                //        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                //    }


                //}

                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Country ='{0}'", tbName.Text);
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
