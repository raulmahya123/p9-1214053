using p_1214053_madep.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_1214053_madep.controller
{
     class Nilai
    {
        Koneksi koneksi = new Koneksi();

        public bool Insert(M_nilai nilai)
        {

            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("INSERT INTO t_nilai(matkul, kategori, npm, nilai) VALUES('" + nilai.Matkul + "', '" +
                nilai.Kategori + "','" + nilai.Npm + "','" + nilai.Nilai + "')");
                status = true;
                MessageBox.Show("Data berhasil ditambahkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Update(M_nilai nilai ,string id)
        {

            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("UPDATE t_nilai SET matkul='" + nilai.Matkul + "'," +
                "kategori='" + nilai.Kategori + "'," + "npm='" + nilai.Npm + "',"
                + "nilai='" + nilai.Nilai + "' WHERE id_nilai='" + id + "'");
                status = true;
                MessageBox.Show("Data berhasil diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Delete(string id)
        {

            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("DELETE FROM t_nilai WHERE id_nilai='" + id + "'");
                status = true;
                MessageBox.Show("Data berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        internal void Update(M_barang m_Barang, string id)
        {
            throw new NotImplementedException();
        }

        internal void Insert(M_barang m_Barang)
        {
            throw new NotImplementedException();
        }

        internal void Insert(M_transaksi m_t)
        {
            throw new NotImplementedException();
        }
    }
}

