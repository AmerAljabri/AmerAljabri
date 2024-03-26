using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void butt_invoice1_Click(object sender, EventArgs e)
        {
            Form1 formInfo = new Form1();
            formInfo.Show();
        }

        private void buttExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butt_invoice2_Click(object sender, EventArgs e)
        {
            invoice_sale invoice = new invoice_sale();
            invoice.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            account_dire accountInfo = new account_dire();
            accountInfo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            invoice_catg accountInfo = new invoice_catg();
            accountInfo.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bound_recive accountInfo = new bound_recive();
            accountInfo.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bound_exch accountInfo = new bound_exch();
            accountInfo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void butt_invor_rep_Click(object sender, EventArgs e)
        {
            InventoryRepo accountInfo = new InventoryRepo();
            accountInfo.Show();
        }

        private void butt_acco_report_Click(object sender, EventArgs e)
        {
            mainReport accountInfo = new mainReport();
            accountInfo.Show();
        }

        private void view_group_Enter(object sender, EventArgs e)
        {

        }
    }
}
