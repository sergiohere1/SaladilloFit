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
        public string MensajeDeEstado { get; set; }
        private SQLiteAsyncConnection conn;

        public RepositorioHorario(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Horarios>().Wait();
        }

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
