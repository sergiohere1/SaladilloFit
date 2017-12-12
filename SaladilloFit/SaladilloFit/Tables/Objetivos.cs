using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SaladilloFit.Tables
{
    [Table("Objetivos")]
    public class Objetivos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20), Unique, NotNull]
        public string Objetivo { get; set; }

        override
        public string ToString()
        {
            return Objetivo;
        }
    }
}
