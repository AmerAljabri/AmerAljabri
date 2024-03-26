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
    public partial class home3_purch : Form
    {
        public home3_purch()
        {
            InitializeComponent();
        }
        private SqlConnection conn; // Declare the connection object as a class-level variable
        public void conne()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-7Q1DRIK;Initial Catalog=accountSysdb;Integrated Security=True");
            conn.Open();
        }

        private void home3_purch_Load(object sender, EventArgs e)
        {
            LoadHomeReport();
        }
        private void LoadHomeReport()
        {
            conne();
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select *from invoice_purch", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                // Set the connection for the SelectCommand
                da.SelectCommand.Connection = connection;

                da.Fill(table);
                homeDataGridView.DataSource = table;
            }
        }
    }
}
