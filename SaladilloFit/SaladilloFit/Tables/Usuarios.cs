using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SaladilloFit.Tables
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [PrimaryKey, MaxLength(9)]
        public string Dni { get; set; }
        [MaxLength(20), NotNull]
        public string Nombre { get; set; }
        [MaxLength(9), NotNull]
        public string Password { get; set; }
        public int Horario { get; set; }
        public int Edad { get; set; }
        public int Altura { get; set; }
        public float Peso { get; set; }
        public float Imc { get; set; }
        public int Objetivo { get; set; }
        [MaxLength(7)]
        public string Tipo { get; set; }
  
    }
}
