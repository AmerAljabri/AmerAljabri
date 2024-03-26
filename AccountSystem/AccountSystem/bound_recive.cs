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
//using Twilio;
//using Twilio.Rest.Api.V2010;


namespace AccountSystem
{
    public partial class bound_recive : Form
    {
        public bound_recive()
        {
            InitializeComponent();
        }

        private SqlConnection conn;
        private void bound_recive_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
            LoadBoundRecive();
        }
        private void ConnectToDatabase()
        {
            string connectionString = @"Data Source=DESKTOP-7Q1DRIK;Initial Catalog=accountSysdb;Integrated Security=True";
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        private void LoadBoundRecive()
        {
            SqlCommand cmd = new SqlCommand("Select * from bound_recive", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    ListViewItem item = new ListViewItem(row["boundId"].ToString());
                    item.SubItems.Add(row["boundName"].ToString());
                    item.SubItems.Add(row["boundDate"].ToString());
                    item.SubItems.Add(row["phone"].ToString());
                    item.SubItems.Add(row["amount"].ToString());
                    item.SubItems.Add(row["FK_Account_number"].ToString());
                    item.SubItems.Add(row["note"].ToString());
                    // Add more subitems as needed

                    listview.Items.Add(item);
                }
            }
        }      

        private void butt_add_Click(object sender, EventArgs e)
        {
            string boundName = namebound.Text;
            string boundDate = textdate.Text;
            string phone = textBox1.Text;
            decimal amount = decimal.Parse(textmeny.Text);
            int accountNumber = int.Parse(txtnumId.Text);
            string note = textnote.Text;

            // Insert the new record into the bound_recive table
            SqlCommand cmd = new SqlCommand("INSERT INTO bound_recive (boundName, boundDate, phone, amount, FK_Account_number, note) " +
                "VALUES (@boundName, @boundDate, @phone, @amount, @accountNumber, @note)", conn);
            cmd.Parameters.AddWithValue("@boundName", boundName);
            cmd.Parameters.AddWithValue("@boundDate", boundDate);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
            cmd.Parameters.AddWithValue("@note", note);
            cmd.ExecuteNonQuery();

            // Refresh the listview to display the newly added record
            listview.Items.Clear();
            LoadBoundRecive();
        }

        private void butt_delet_Click(object sender, EventArgs e)
        {
            if (listview.SelectedItems.Count > 0)
            {
                string boundId = listview.SelectedItems[0].Text;

                // Show confirmation message box
                DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف السجل؟", "متأكد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the selected record from the bound_recive table
                    SqlCommand cmd = new SqlCommand("DELETE FROM bound_recive WHERE boundId = @boundId", conn);
                    cmd.Parameters.AddWithValue("@boundId", boundId);
                    cmd.ExecuteNonQuery();

                    // Refresh the listview to reflect the deletion
                    listview.Items.Clear();
                    LoadBoundRecive();
                }
                   
            }
        }
            
        private void butt_send_messeg_Click(object sender, EventArgs e)
        {
            if (listview.SelectedItems.Count > 0)
            {
                string phone = listview.SelectedItems[0].SubItems[3].Text; // Phone number
                decimal amount = decimal.Parse(listview.SelectedItems[0].SubItems[4].Text); // Amount

                // Send a message to the customer regarding their amount
                string message = $" يرجى تسديد المبلغ في أقرب وقت ممكن.{amount}:عزيزي العميل، المبلغ المستحق عليك هو";

                // Send the message using the Twilio API
                string accountSid = "YOUR_TWILIO_ACCOUNT_SID";
                string authToken = "YOUR_TWILIO_AUTH_TOKEN";
                string fromPhoneNumber = "YOUR_TWILIO_PHONE_NUMBER";

                //var twilio = new TwilioRestClient(accountSid, authToken);
                //var messageOptions = new MessageOptions
                //{
                //    From = new PhoneNumber(fromPhoneNumber),
                //    To = new PhoneNumber(phone),
                //    Body = message
                //};
                //var messageResponse = twilio.SendMessage(messageOptions);

                //// Check for successful message sending
                //if (messageResponse.RestException != null)
                //{
                //    MessageBox.Show("Failed to send message: " + messageResponse.RestException.Message, "Message Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    MessageBox.Show("Message sent to the customer successfully.", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }

        private void butt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
