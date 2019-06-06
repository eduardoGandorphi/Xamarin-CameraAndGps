using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camera
{
    public class Foto_MD
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        [NotNull]
        public byte[] Foto{ get; set; }

        [NotNull]
        public string InternalPath { get; set; }

        [NotNull]
        public string ExternalPath { get; set; }
    }
}
