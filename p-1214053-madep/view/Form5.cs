using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace p_1214053_madep.view
{
    public partial class Form5 : Form
    {
        Koneksi koneksi = new Koneksi();
        M_nilai m_nilai = new M_nilai();
        string id;
       

        public Form5()
        {
            InitializeComponent();
        }

        private void DataMahasiswaa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }
        public void tampil()
        {
            DataMahasiswaa.DataSource = koneksi.ShowData("SELECT " + "id_nilai, matkul, kategori, t_nilai.npm, nama, nilai " +
                "FROM t_nilai JOIN t_mahasiswa ON t_mahasiswa.npm = t_nilai.npm");
            DataMahasiswaa.Columns[0].HeaderText = "ID";
            DataMahasiswaa.Columns[1].HeaderText = "Matkul";
            DataMahasiswaa.Columns[2].HeaderText = "Kategori";
            DataMahasiswaa.Columns[3].HeaderText = "NPM";
            DataMahasiswaa.Columns[4].HeaderText = "Nama";
            DataMahasiswaa.Columns[5].HeaderText = "Nilai";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            if (cbmatkul.SelectedIndex == -1 || cbkategori.SelectedIndex == -1 || cbnpm.SelectedIndex == -1 || tbnilai.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Nilai mhs = new Nilai();
                m_nilai.Matkul = cbmatkul.Text;
                m_nilai.Kategori = cbkategori.Text;
                m_nilai.Npm = cbnpm.Text;
                m_nilai.Nilai = tbnilai.Text;


                mhs.Insert(m_nilai);

                cbmatkul.Text = "";
                cbkategori.Text = "";
                cbnpm.Text = "";
                tbnilai.Text = "";
                tampil();
            }
        }

        private void tbCariData_TextChanged(object sender, EventArgs e)
        {
            DataMahasiswaa.DataSource = koneksi.ShowData("SELECT * FROM t_nilai WHERE kategori LIKE '%' '" + tbCariData.Text + "' '%' OR npm LIKE '%' '" + tbCariData.Text + "' '%' OR  WHERE kategori LIKE '%' '" + tbCariData.Text + "' '%'");
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (cbmatkul.SelectedIndex == -1 || cbkategori.SelectedIndex == -1 || cbnpm.SelectedIndex == -1 || tbnilai.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                Nilai mhs = new Nilai();
                m_nilai.Matkul = cbmatkul.Text;
                m_nilai.Kategori = cbkategori.Text;
                m_nilai.Npm = cbnpm.Text;
                m_nilai.Nilai = tbnilai.Text;


                mhs.Update(m_nilai,id);

                cbmatkul.Text = "";
                cbkategori.Text = "";
                cbnpm.Text = "";
                tbnilai.Text = "";
                tampil();

            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("apakah yakin anda ?", "perhatikan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                Nilai mhs = new Nilai();
                mhs.Delete(id);
                tampil();
            }
        }

        private void btnRefreshh_Click(object sender, EventArgs e)
        {

            cbmatkul.SelectedIndex= -1;
            tampil();
        }

        private void tbnilai_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pencarian_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            tampil();
            GetDataMhs();
        }

        private void DataMahasiswaa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = DataMahasiswaa.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbmatkul.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbkategori.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbnpm.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbnilai.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        
        public void GetDataMhs()
        {
            //ambil data NPM dari table (t_mahasiswa) untuk mengisi data pada combobox NPM
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT * FROM t_mahasiswa");
            while (reader.Read())
            {
                cbnpm.Items.Add(reader.GetString("npm"));
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        private void cbnpm_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataMhs();
            
        }

        private void DataMahasiswaa_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            id = DataMahasiswaa.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbmatkul.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbkategori.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbnpm.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbnilai.Text = DataMahasiswaa.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
