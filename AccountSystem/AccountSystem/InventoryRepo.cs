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
    public partial class InventoryRepo : Form
    {
        private SqlConnection conn; // Declare the connection object as a class-level variable
        public void conne()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-7Q1DRIK;Initial Catalog=accountSysdb;Integrated Security=True");
            conn.Open();
        }
        public InventoryRepo()
        {
            InitializeComponent();
        }

        private void InventoryRepo_Load(object sender, EventArgs e)
        {
            LoadInventoryReport();
        }
        private void LoadInventoryReport()
        {
            conne();
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
           {

                SqlCommand cmd = new SqlCommand("SELECT product, SUM(quantity) AS PurchasedQuantity, 0 AS SoldQuantity, SUM(quantity) AS Inventory FROM invoice_purch GROUP BY product UNION SELECT product, 0 AS PurchasedQuantity, SUM(Quantity) AS SoldQuantity, -SUM(Quantity) AS Inventory FROM invoice_sales GROUP BY product", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                // Set the connection for the SelectCommand
                 da.SelectCommand.Connection = connection;

                 da.Fill(table);
                 inventoryDataGridView.DataSource = table;


                // inventoryDataGridView.DataSource = dataTable;
            }
        }

        private void inventoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
