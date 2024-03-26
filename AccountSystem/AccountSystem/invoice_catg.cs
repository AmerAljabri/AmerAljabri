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
    public partial class invoice_catg : Form
    {
        public invoice_catg()
        {
            InitializeComponent();
        }
        private SqlConnection conn;
        private void invoice_catg_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
            LoadProductCatalogue();
        }
        private void ConnectToDatabase()
        {   
            //try
            //{
                string connectionString = @"Data Source=DESKTOP-7Q1DRIK;Initial Catalog=accountSysdb;Integrated Security=True";
                conn = new SqlConnection(connectionString);
                conn.Open();
            //    MessageBox.Show("Connected to the database.");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error connecting to the database: " + ex.Message);
            //}
        }
        private void LoadProductCatalogue()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM account_catg", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    ListViewItem item = new ListViewItem(row["Product_number"].ToString());
                    item.SubItems.Add(row["Product_name"].ToString());
                    item.SubItems.Add(row["Unite"].ToString());
                    // Add more subitems as needed

                    listView1.Items.Add(item);
                }
            }
            else
            {
                // Handle case when no products available
            }
        }

        private void butt_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textprId.Text) || string.IsNullOrEmpty(textprod.Text) ||
               string.IsNullOrEmpty(textunit.Text))
                return;

            string productNum = textprId.Text;
            string productName = textprod.Text;
            string unite = textunit.Text;

            // Add the item to the ListView
            ListViewItem item = new ListViewItem(productNum);
            item.SubItems.Add(productName);
            item.SubItems.Add(unite);
            listView1.Items.Add(item);

            // Insert the data into the database
            InsertProductIntoDatabase(productNum, productName, unite);

            // Clear input fields
            //textProductNum.Clear();
            //textProductName.Clear();
            //textUnite.Clear();
            //textAccountNum.Clear();
            //textProductNum.Focus()
        }
        private void InsertProductIntoDatabase(string productNum, string productName, string unite)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO account_catg (Product_number, Product_name, Unite, ) VALUES (@Product_number, @Product_name, @Unite, )", conn);
                cmd.Parameters.AddWithValue("@Product_number", productNum);
                cmd.Parameters.AddWithValue("@Product_name", productName);
                cmd.Parameters.AddWithValue("@Unite", unite);
                cmd.ExecuteNonQuery();
                MessageBox.Show(".تم إدراج المنتج في قاعدة البيانات");
            }
            catch (Exception ex)
            {
                MessageBox.Show(":حدث خطأ أثناء إدخال المنتج في قاعدة البيانات " + ex.Message);
            }
        }

        private void butt_delet_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string productNum = selectedItem.SubItems[0].Text;

                // Show confirmation message box
                DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف حساب: ؟", "متأكد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove the item from the ListView
                    listView1.Items.Remove(selectedItem);

                    // Delete the corresponding record from the database
                    DeleteProductFromDatabase(productNum);
                }
            }
                    
        }
        private void DeleteProductFromDatabase(string productNum)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM account_catg WHERE Product_number = @Product_number", conn);
                cmd.Parameters.AddWithValue("@Product_number", productNum);
                cmd.ExecuteNonQuery();
                MessageBox.Show(".تم حذف الحساب من قاعدة البيانات ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" :حدث خطأ أثناء حذف المنتج من قاعدة البيانات  " + ex.Message);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textprod_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
