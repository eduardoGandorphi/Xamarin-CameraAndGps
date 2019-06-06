using SQLite;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Camera
{
    internal class Foto_BL
    {

        SQLiteConnection conn = Conexao.GetConn();
        internal bool TemFoto()
        {
            var foto = conn.Table<Foto_MD>().LastOrDefault();

            return foto != null;
        }

        internal ImageSource PegarFoto()
        {
            return LastOrDefault().Foto.ToImageSource();
        }

        internal void Insert(Foto_MD md)
        {
            SQLiteConnection connInsert = Conexao.GetConn();
            connInsert.BeginTransaction();
            connInsert.Insert(md);
            connInsert.Commit();
            connInsert.Close();
        }

        internal Foto_MD LastOrDefault()
        {
            return conn.Table<Foto_MD>().LastOrDefault();
        }
    }
}