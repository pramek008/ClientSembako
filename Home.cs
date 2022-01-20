using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSembako
{
    public partial class Home : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produk admin = new Produk();
            this.Hide();
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User();
            this.Hide();
            user.Show();
        }
    }
}
