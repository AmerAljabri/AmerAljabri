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
    public partial class account_dire : Form
    {
        public account_dire()
        {
            InitializeComponent();

        }
        private SqlConnection conn;
        private void account_dire_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
            SqlCommand cmd = new SqlCommand("Select * from account_dir", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);

           if(table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    ListViewItem item = new ListViewItem(row["Account_number"].ToString());
                    item.SubItems.Add(row["Account_name"].ToString());
                    item.SubItems.Add(row["Account_type"].ToString());
                    // Add more subitems as needed

                    listView1.Items.Add(item);
                }
            }
            else
            {
               
            }

           
        }
        private void ConnectToDatabase()
        {
            
                string connectionString = @"Data Source=DESKTOP-7Q1DRIK;Initial Catalog=accountSysdb;Integrated Security=True";
                conn = new SqlConnection(connectionString);
                conn.Open();
               // MessageBox.Show("Connected to the database.");
           

        }

        private void butt_dele_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string accountId = selectedItem.SubItems[0].Text;

                // Show confirmation message box
                DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف حساب: ؟", "متأكد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove the item from the ListView
                    if (result == DialogResult.Yes)
                    {
                        // Remove the item from the ListView
                        listView1.Items.Remove(selectedItem);

                        // Delete the corresponding record from the database
                        DeleteAccountFromDatabase(accountId);
                    }
                }
            }
           
        }
        private void DeleteAccountFromDatabase(string accountId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM account_dir WHERE Account_number = @Account_number", conn);
                cmd.Parameters.AddWithValue("@Account_number", accountId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حذف الحساب من قاعدة البيانات");
            }
            catch (Exception ex)
            {
                MessageBox.Show(":حدث خطأ أثناء حذف المنتج من قاعدة البيانات " + ex.Message);
            }
        }

        private void butt_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textId.Text) || string.IsNullOrEmpty(textName.Text) || string.IsNullOrEmpty(textType.Text))
                return;

            string accountId = textId.Text;
            string accountName = textName.Text;
            string accountType = textType.Text;

            // Add the item to the ListView
            ListViewItem item = new ListViewItem(accountId);
            item.SubItems.Add(accountName);
            item.SubItems.Add(accountType);
            listView1.Items.Add(item);

            // Insert the data into the database
            InsertAccountIntoDatabase(accountId, accountName, accountType);

            //textId.Clear();
            //textName.Clear();
            //textType.Clear();
            //textId.Focus();
        }
        private void InsertAccountIntoDatabase(string accountId, string accountName, string accountType)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO account_dir (Account_number, Account_name, Account_type) VALUES (@Account_number, @Account_name, @Account_type)", conn);
                cmd.Parameters.AddWithValue("@Account_number", accountId);
                cmd.Parameters.AddWithValue("@Account_name", accountName);
                cmd.Parameters.AddWithValue("@Account_type", accountType);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account inserted into the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting account into the database: " + ex.Message);
            }
        }
        private void butt_back_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void textId_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
