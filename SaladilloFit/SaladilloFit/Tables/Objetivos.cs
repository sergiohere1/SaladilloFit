using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SaladilloFit.Tables
{
    /// <summary>
    /// Clase que representará la Tabla de Objetivo
    /// </summary>
    [Table("Objetivos")]
    public class Objetivos
    {
        /// <summary>
        /// Id del Objetivo
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// La cadena con el objetivo en sí (Adelgazar, Definir..)
        /// </summary>
        [MaxLength(20), Unique, NotNull]
        public string Objetivo { get; set; }

        /// <summary>
        /// Método ToString sobreescrito para evitar que en los Pickers nos aparezca
        /// Tables.Objetivos
        /// </summary>
        /// <returns></returns>
        override
        public string ToString()
        {
            return Objetivo;
        }
    }
}
