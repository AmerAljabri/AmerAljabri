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
    public partial class invoice_sale : Form
    {
        public invoice_sale()
        {
            InitializeComponent();
        }
        private SqlConnection conn; // Declare the connection object as a class-level variable
        public void conne()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-7Q1DRIK;Initial Catalog=accountSysdb;Integrated Security=True");
            conn.Open();
        }
        private void invoice_sale_Load_1(object sender, EventArgs e)
        {      
            conne();  // Invoke the connection method to establish the connection

            SqlCommand cmd = new SqlCommand("Select * from invoice_sales", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void butt_add_Click(object sender, EventArgs e)
        {
            try
            {
                string pay = "";

                conne();

                // Calculate the total
                int quantity = int.Parse(txt_unite.Text);
                int priceUnit = int.Parse(txt_price.Text);
                int total = quantity * priceUnit;

                // Assign the calculated total to textBox8
                textBox8.Text = total.ToString();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO invoice_sales (Invoice_number, Date_tb, pay, Invoice_Name, Unite, Quantity, Price_Unite, Total, product, FK_Account_number)
                                       VALUES (@Invoice_number, @Date_tb, @pay, @Invoice_Name, @Unite, @Quantity, @Price_Unite, @Total, @product, @FK_Account_number)", conn);
                cmd.Parameters.AddWithValue("@Invoice_number", int.Parse(invo_numtext.Text));
                cmd.Parameters.AddWithValue("@Date_tb", text_date.Text);
                cmd.Parameters.AddWithValue("@Invoice_Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@Unite", textBox5.Text);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Price_Unite", priceUnit);
                cmd.Parameters.AddWithValue("@Total", total);
                cmd.Parameters.AddWithValue("@product", int.Parse(numIdProduct.Text));
                cmd.Parameters.AddWithValue("@FK_Account_number", int.Parse(numIdFK.Text));

                // Check the selected value of the pay option (cash or yield) and assign the appropriate value
                if (cash.Checked)
                {
                    pay = "cash";
                }
                else if (yield.Checked)
                {
                    pay = "yield";
                }

                cmd.Parameters.AddWithValue("@pay", pay);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("إضافة ناجحة");

                // Reload data and bind to the dataGridView1
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM invoice_sales", conn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(":حدث خطأ أثناء الإضافة   " + ex.Message);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            conne();
            SqlCommand cmd = new SqlCommand("Select * from invoice_sales where Invoice_number=@Invoice_number", conn);
            cmd.Parameters.AddWithValue("@Invoice_number", int.Parse(invo_numtext.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void CalculateTotal()
        {
            if (int.TryParse(txt_unite.Text, out int quantity) && int.TryParse(txt_price.Text, out int priceUnit))
            {
                int total = quantity * priceUnit;
                textBox8.Text = total.ToString();
            }
            else
            {
                textBox8.Text = string.Empty;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cash_CheckedChanged_1(object sender, EventArgs e)
        {
            cash.ForeColor = System.Drawing.Color.Green;
            yield.ForeColor = System.Drawing.Color.Gray;
        }
        private void yield_CheckedChanged(object sender, EventArgs e)
        {
            cash.ForeColor = System.Drawing.Color.Gray;
            yield.ForeColor = System.Drawing.Color.Green;
        }

        private void invo_numtext_TextChanged(object sender, EventArgs e)
        {

        }


        private void txt_price_TextChanged_1(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txt_unite_TextChanged_1(object sender, EventArgs e)
        {
            CalculateTotal();
        }     

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void text_date_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }

        
       
    }
}
