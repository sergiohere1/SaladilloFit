using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SaladilloFit.Tables
{
    /// <summary>
    /// Clase que representará la tabla Horario
    /// </summary>
    [Table("Horarios")]
    public class Horarios
    {
        /// <summary>
        /// Clave primaria, la Id del Horario
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// String que representa el Horario (Tarde, mañana...)
        /// </summary>
        [MaxLength(15), Unique, NotNull]
        public string Horario { get; set; }

        /// <summary>
        /// ToString sobreescrito para evitar que en los Pickers aparezca Tables.Horario en lugar
        /// del correspondiente valor del horario
        /// </summary>
        /// <returns></returns>
        override
        public string ToString()
        {
            return Horario;
        }
    }
}
