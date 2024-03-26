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
    public partial class HomeInvontory2 : Form
    {
        public HomeInvontory2()
        {
            InitializeComponent();
        }
        private SqlConnection conn; // Declare the connection object as a class-level variable
        public void conne()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-7Q1DRIK;Initial Catalog=accountSysdb;Integrated Security=True");
            conn.Open();
        }

        private void HomeInvontory2_Load(object sender, EventArgs e)
        {
            LoadHomeReport();
        }
        private void LoadHomeReport()
        {
            conne();
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select *from bound_recive", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                // Set the connection for the SelectCommand
                da.SelectCommand.Connection = connection;

                da.Fill(table);
                homeDataGridView.DataSource = table;
            }
        }

        private void a_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
