using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SaladilloFit.Tables
{
    /// <summary>
    /// Esta clase representa la Tabla de Usuario que se nos creará.
    /// </summary>
    [Table("Usuarios")]
    public class Usuarios
    {
        /// <summary>
        /// Clave primaria del Usuario, su DNI
        /// </summary>
        [PrimaryKey, MaxLength(9)]
        public string Dni { get; set; }
        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        [MaxLength(20), NotNull]
        public string Nombre { get; set; }
        /// <summary>
        /// Contraseña del Usuario
        /// </summary>
        [MaxLength(9), NotNull]
        public string Password { get; set; }
        /// <summary>
        /// Horario del Usuario
        /// </summary>
        public int Horario { get; set; }
        /// <summary>
        /// Edad del Usuario
        /// </summary>
        public int Edad { get; set; }
        /// <summary>
        /// Altura del Usuario
        /// </summary>
        public int Altura { get; set; }
        /// <summary>
        /// Peso del Usuario
        /// </summary>
        public float Peso { get; set; }
        /// <summary>
        /// Imc del Usuario
        /// </summary>
        public float Imc { get; set; }
        /// <summary>
        /// Objetivo del Usuario
        /// </summary>
        public int Objetivo { get; set; }
        /// <summary>
        /// Tipo del Usuario
        /// </summary>
        [MaxLength(7)]
        public string Tipo { get; set; }
  
    }
}
