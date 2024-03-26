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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SqlConnection conn; // Declare the connection object as a class-level variable
        public void conne()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-7Q1DRIK;Initial Catalog=accountSysdb;Integrated Security=True");
            conn.Open();
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            conne();  // Invoke the connection method to establish the connection

            SqlCommand cmd = new SqlCommand("Select * from invoice_purch",conn);
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
            txt_total.Text = total.ToString();

            SqlCommand cmd = new SqlCommand("insert into invoice_purch(invoice_num,date,pay,invoice_name,product,unite,quantity,price_unite,total,Account_number)values(@invoice_num,@date,@pay,@invoice_name,@product,@unite,@quantity,@price_unite,@total,@Account_number) ", conn);
            cmd.Parameters.AddWithValue("@invoice_num",int.Parse(invo_numtext.Text));
            cmd.Parameters.AddWithValue("@date",(text_date.Text));
            cmd.Parameters.AddWithValue("@invoice_name", (textBox3.Text));
            cmd.Parameters.AddWithValue("@product", (textBox4.Text));
            cmd.Parameters.AddWithValue("@unite", (textBox5.Text));
            cmd.Parameters.AddWithValue("@quantity", (quantity));
            cmd.Parameters.AddWithValue("@price_unite",(priceUnit));
            cmd.Parameters.AddWithValue("@total", (total));
            cmd.Parameters.AddWithValue("@Account_number", int.Parse(numId.Text));
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM invoice_purch", conn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(":حدث خطأ أثناء الإضافة   " + ex.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            conne();
            SqlCommand cmd = new SqlCommand("Select * from invoice_purch where invoice_num=@invoice_num", conn);
            cmd.Parameters.AddWithValue("@invoice_num", int.Parse(invo_numtext.Text));
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
                txt_total.Text = total.ToString();
            }
            else
            {
                txt_total.Text = string.Empty;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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

        private void text_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cash_CheckedChanged(object sender, EventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txt_unite_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
