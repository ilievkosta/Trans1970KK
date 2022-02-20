using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Trans1970KK
{
    class Cord

    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string CordX { get; set; }
        public string CordY { get; set; }
        public string CordName { get; set; }
        public string CordType { get; set; }

        public Cord(string X, string Y, string name ,string type)
        {
            CordX = X;
            CordY = Y;
            CordName = name;
            CordType = type;
        }
        public Cord()
        {

        }

    }
}