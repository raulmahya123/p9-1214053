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
    public partial class Form3 : Form
    {
        Koneksi koneksi = new Koneksi();
        M_mahasiswa m_mhs = new M_mahasiswa();
        string id;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void DataMahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = DataMahasiswaa.Rows[e.RowIndex].Cells[0].Value.ToString();
            npm.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[0].Value.ToString();
            nama.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[1].Value.ToString();
            angkatan.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[2].Value.ToString();
            alamat.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[3].Value.ToString();
            email.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[4].Value.ToString();
            nohp.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
        public void tampil()
        {
            DataMahasiswaa.DataSource = koneksi.ShowData("SELECT * FROM t_mahasiswa");

            DataMahasiswaa.Columns[0].HeaderText = "NPM";
            DataMahasiswaa.Columns[1].HeaderText = "NAMA";
            DataMahasiswaa.Columns[2].HeaderText = "ANGKATAN";
            DataMahasiswaa.Columns[3].HeaderText = "ALAMAT";
            DataMahasiswaa.Columns[4].HeaderText = "EMAIL";
            DataMahasiswaa.Columns[5].HeaderText = "NO hp";

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tampil();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (npm.Text == "" || nama.Text == "" || angkatan.SelectedIndex == -1 || alamat.Text == "" || email.Text == "" || nohp.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Mahasiswa mhs = new Mahasiswa();
                m_mhs.Npm = npm.Text;
                m_mhs.Nama = nama.Text;
                m_mhs.Angkatan = angkatan.Text;
                m_mhs.Alamat = alamat.Text;
                m_mhs.Email = email.Text;
                m_mhs.Nohp = nohp.Text;

                mhs.Insert(m_mhs);

                npm.Text = "";
                nama.Text = "";
                angkatan.Text = "";
                alamat.Text = "";
                email.Text = "";
                nohp.Text = "";
                tampil();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (npm.Text == "" || nama.Text == "" || angkatan.SelectedIndex == -1 || alamat.Text == "" || email.Text == "" || nohp.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                Mahasiswa mhs = new Mahasiswa();
                m_mhs.Npm = npm.Text;
                m_mhs.Nama = nama.Text;
                m_mhs.Angkatan = angkatan.Text;
                m_mhs.Alamat = alamat.Text;
                m_mhs.Email = email.Text;
                m_mhs.Nohp = nohp.Text;

                mhs.Update(m_mhs, id);

                npm.Text = "";
                nama.Text = "";
                angkatan.Text = "";
                alamat.Text = "";
                email.Text = "";
                nohp.Text = "";
                tampil();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("apakah yakin anda ?", "perhatikan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                Mahasiswa mhs = new Mahasiswa();
                mhs.Delete(id);

            }
        }

        private void tbCariData_TextChanged(object sender, EventArgs e)
        {
            DataMahasiswaa.DataSource = koneksi.ShowData("SELECT * FROM t_mahasiswa WHERE npm LIKE '%' '" + tbCariData.Text + "' '%' OR nama LIKE '%' '" + tbCariData.Text + "' '%'");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void npm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
