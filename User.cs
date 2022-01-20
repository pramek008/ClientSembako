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

    public partial class User : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public User()
        {
            InitializeComponent();
            TampilData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            int IdOrder = int.Parse(textBoxIdOrder.Text);
            string namaPembeli = textBoxNama.Text;
            string alamat = textBoxAlamat.Text;
            int jmlPesanan = int.Parse(textBoxJml.Text);
            int totalHarga = int.Parse(textBoxTotal.Text);
            int idProduct = int.Parse(textBoxIdProduk.Text);

            var a = service.order(IdOrder, namaPembeli, alamat, jmlPesanan, totalHarga, idProduct);
            MessageBox.Show(a);

        }

        public void TampilData()
        {
            var List = service.Orders();
            dataGridView1.DataSource = List;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxIdOrder.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            textBoxNama.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            textBoxAlamat.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            textBoxJml.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            textBoxTotal.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            textBoxIdProduk.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }
    }
}
