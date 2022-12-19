using p_1214053_madep.controller;
using p_1214053_madep.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_1214053_madep.view
{
    public partial class Form7 : Form
    {
        Koneksi koneksi = new Koneksi();
        M_transaksi M_t = new M_transaksi();
        string id;
        public Form7()
        {
            InitializeComponent();
        }

        private void DataMahasiswaa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void cari_TextChanged(object sender, EventArgs e)
        {

        }
        public void tampil()
        {
            DataMahasiswaa.DataSource = koneksi.ShowData("SELECT * FROM t_transaksi");
            DataMahasiswaa.Columns[0].HeaderText = "ID Barang";
            DataMahasiswaa.Columns[0].HeaderText = "Nama Barang";
            DataMahasiswaa.Columns[1].HeaderText = "Harga";
            DataMahasiswaa.Columns[2].HeaderText = "QTY";
            DataMahasiswaa.Columns[3].HeaderText = "TOTAL HARGA";


        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (idbarang.Text == "" || namabarang.Text == "" || namaharga.Text == "" || namaquantity.Text == "" || namatotal.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Nilai nilai = new Nilai();
                M_t.Id_barang = idbarang.Text;
                M_t.Id_barang = namabarang.Text;
                M_t.Qyt = namaharga.Text;
                M_t.Total = namatotal.Text;




                nilai.Insert(M_t);

                idbarang.Text = "";
                namabarang.Text = "";
                namaharga.Text = "";
                namatotal.Text ="";


                tampil();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (idbarang.Text == "" || namabarang.Text == "" || namaharga.Text == "" || namaquantity.Text == "" || namatotal.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Nilai nilai = new Nilai();
                M_t.Id_barang = idbarang.Text;
                M_t.Id_barang = namabarang.Text;
                M_t.Qyt = namaharga.Text;
                M_t.Total = namatotal.Text;




                nilai.Insert(M_t);

                idbarang.Text = "";
                namabarang.Text = "";
                namaharga.Text = "";
                namatotal.Text = "";


                tampil();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Apakah Yakin Ingin Menghapus?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                Nilai nilai = new Nilai();
                nilai.Delete(id);
                tampil();
            }
        }
    }
}
