using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SaladilloFit.Tables
{
    [Table("Horarios")]
    public class Horarios
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(15), Unique, NotNull]
        public string Horario { get; set; }

        override
        public string ToString()
        {
            return Horario;
        }
    }
}
