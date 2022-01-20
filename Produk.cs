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
    public partial class Produk : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Produk()
        {
            InitializeComponent();
            TampilData();
        }

        private void Produk_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int IdProduct = int.Parse(textBoxIdProduk.Text);
            string namaProduct = textBoxNamaProduk.Text;
            int harga = int.Parse(textBoxHarga.Text);
            int stok = int.Parse(textBoxStok.Text);
            string deskripsi = textBoxDeskripsi.Text;

            var a = service.product(IdProduct, namaProduct, harga, stok, deskripsi);
            MessageBox.Show(a);

            Clear();
        }

        public void Clear()
        {
            textBoxIdProduk.Clear();
            textBoxNamaProduk.Clear();
            textBoxHarga.Clear();
            textBoxStok.Clear();
            textBoxDeskripsi.Clear();

            textBoxStok.Enabled = true;
            textBoxIdProduk.Enabled = true;

            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void TampilData()
        {
            var List = service.Products();
            dgvProduk.DataSource = List;
        }

        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxIdProduk.Text = Convert.ToString(dgvProduk.Rows[e.RowIndex].Cells[0].Value);
            textBoxNamaProduk.Text = Convert.ToString(dgvProduk.Rows[e.RowIndex].Cells[3].Value);
            textBoxHarga.Text = Convert.ToString(dgvProduk.Rows[e.RowIndex].Cells[2].Value);
            textBoxStok.Text = Convert.ToString(dgvProduk.Rows[e.RowIndex].Cells[4].Value);
            textBoxDeskripsi.Text = Convert.ToString(dgvProduk.Rows[e.RowIndex].Cells[1].Value);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }
    }
}
