using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SaladilloFit.Tables;

namespace SaladilloFit.Repositories
{
    public class RepositorioHorario
    {
        /// <summary>
        /// Mensaje de estado en caso de error.
        /// </summary>
        public string MensajeDeEstado { get; set; }
        /// <summary>
        /// Conexión asíncrona para nuestra base de datos.
        /// </summary>
        private SQLiteAsyncConnection conn;

        public RepositorioHorario(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Horarios>().Wait();
        }
        /// <summary>
        /// Método con el que obtendremos todos los horarios de nuestra base de datos.
        /// </summary>
        /// <returns>Lista con todos los horarios que tengamos en la base de datos.</returns>
        public async Task<List<Horarios>> ObtenerTodosLosHorarios()
        {
            List<Horarios> listaHorarios = new List<Horarios>();

            try
            {
                listaHorarios = await conn.Table<Horarios>().ToListAsync();
            }
            catch (Exception ex)
            {
                MensajeDeEstado = string.Format("Error al recuperar datos, {0}", ex.ToString());
            }
            return listaHorarios;
        }

    }
}
