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
    public partial class Form6 : Form
    {
        Koneksi koneksi = new Koneksi();
        M_barang M_Barang = new M_barang();
        string id;
        public Form6()
        {
            InitializeComponent();
        }

        private void btnRefreshh_Click(object sender, EventArgs e)
        {
            namabarang.Text = "";
            harga.Text = "";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (namabarang.Text == "" || harga.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Nilai nilai = new Nilai();
                M_Barang.Nama_barang = namabarang.Text;
                M_Barang.Harga = harga.Text;



                nilai.Insert(M_Barang);

                namabarang.Text = "";
                harga.Text = "";
                

                tampil();
            }
            
        }
        public void tampil()
        {
            DataMahasiswaa.DataSource = koneksi.ShowData("SELECT * FROM t_barang");
            DataMahasiswaa.Columns[0].HeaderText = "ID";
            DataMahasiswaa.Columns[1].HeaderText = "nama";
            DataMahasiswaa.Columns[2].HeaderText = "kategori";
            
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (namabarang.Text == "" || harga.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Nilai nilai = new Nilai();
                M_Barang.Nama_barang = namabarang.Text;
                M_Barang.Harga = harga.Text;



                nilai.Update(M_Barang, id);

                namabarang.Text = "";
                harga.Text = "";


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

        private void DataMahasiswaa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void namabarang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
