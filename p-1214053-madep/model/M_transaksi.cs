using p_1214053_madep.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_1214053_madep.model
{
     class M_transaksi
        
    {
        string id_transaksi, id_barang, qyt, total;
        public M_transaksi()
    {

    }
        public M_transaksi(string id_transaksi, string id_barang, string qyt, string total)
        {
            this.Id_transaksi = id_transaksi;
            this.Id_barang = id_barang;
            this.Qyt = qyt;
            this.Total = total;
        }
        public string Id_transaksi { get => id_transaksi; set => id_transaksi = value; }
        public string Id_barang { get => id_barang; set => id_barang = value; }
        public string Qyt { get => qyt; set => qyt = value; }
        public string Total { get => total; set => total = value; }
    }
}
