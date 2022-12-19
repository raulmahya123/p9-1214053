using p_1214053_madep.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_1214053_madep.controller
{
    internal class transaksi
    {
        Koneksi koneksi = new Koneksi();

        public bool Insert(M_transaksi transaksi)
        {

            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("INSERT INTO t_transaksi  (id_transaksi, id_barang, qyt, total) VALUES('" + transaksi.Id_transaksi + "', '" + transaksi.Id_barang + "','" + transaksi.Qyt + "','" + transaksi.Total + "')");
                status = true;
                MessageBox.Show("Data berhasil ditambahkan", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Update(M_transaksi transaksi, string id)
        {

            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("UPDATE t_transaksi SET npm='" + transaksi.Id_transaksi + "'," + "nama='" + transaksi.Id_barang + "'," + "angkatan='" + transaksi.Qyt + "'," + "alamat='" + transaksi.Total + "'," +  "'");
                status = true;
                MessageBox.Show("berasil di ubah", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Delete(string id)
        {

            Boolean status = false;
            try
            {

                koneksi.OpenConnection();
                koneksi.ExecuteQuery("DELETE FROM t_transaksi WHERE id_transaksi='" + id + "'");
                status = true;
                MessageBox.Show("Data berasil di hapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
    }
}
