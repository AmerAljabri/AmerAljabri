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
    public partial class mainReport : Form
    {
        public mainReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeReport accountInfo = new HomeReport();
            accountInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeInvontory2 accountInfo = new HomeInvontory2();
            accountInfo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            home3_purch accountInfo = new home3_purch();
            accountInfo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home_sales home = new home_sales();
            home.Show();
        }
    }
}
