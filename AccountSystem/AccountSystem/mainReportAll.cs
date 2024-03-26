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

namespace AccountSystem
{
    public partial class mainReportAll : Form
    {
        public mainReportAll()
        {
            InitializeComponent();
        }
        private SqlConnection conn; // Declare the connection object as a class-level variable
        public void conne()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-7Q1DRIK;Initial Catalog=accountSysdb;Integrated Security=True");
            conn.Open();
        }

        private void mainReportAll_Load(object sender, EventArgs e)
        {
            LoadHomeReport();
        }
        private void LoadHomeReport()
        {
            conne();
            string accountId = AccountIdTextBox.Text;
            string query = @"SELECT 'Expense Voucher' AS [Transaction Type], [amount] AS [amount], [boundDate] AS [boundDate]
                           FROM [bound_exch]
                           WHERE [boundName] = @boundId UNION ALL
                           SELECT 'Receipt Voucher' AS [Transaction Type], [amount] AS [amount], [boundDate] AS [boundDate]
                           FROM [bound_recive] WHERE [boundName] = @boundId UNION ALL
                           SELECT 'Sales Invoice' AS [Transaction Type], [Total] AS [Price_Unite], [Date_tb] AS [Date_tb]
                           FROM [invoice_sales] WHERE [AccountName] = @Invoice_number UNION ALL
                           SELECT 'Purchase Invoice' AS [Transaction Type], [Total] AS [Amount], [Date] AS [Date]
                           FROM [PurchaseInvoices] WHERE [AccountName] = @AccountId ORDER BY [Date]";

            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AccountId", accountId);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable table = new DataTable();
                //// Set the connection for the SelectCommand
                //da.SelectCommand.Connection = connection;

                //da.Fill(table);
                //main_dataGridView.DataSource = table;

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Display the account statement in a DataGridView
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    main_dataGridView.DataSource = dataTable;

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void main_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
