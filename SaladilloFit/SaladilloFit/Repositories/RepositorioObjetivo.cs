using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SaladilloFit.Tables;

namespace SaladilloFit.Repositories
{
    public class RepositorioObjetivo
    {
        public string MensajeDeEstado { get; set; }
        private SQLiteAsyncConnection conn;

        public RepositorioObjetivo(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Objetivos>().Wait();
        }

        public async Task<List<Objetivos>> ObtenerTodosLosObjetivos()
        {
            List<Objetivos> listaObjetivos = new List<Objetivos>();

            try
            {
                listaObjetivos = await conn.Table<Objetivos>().ToListAsync();
            }
            catch (Exception ex)
            {
                MensajeDeEstado = string.Format("Error al recuperar datos, {0}", ex.ToString());
            }
            return listaObjetivos;
        }


    }
}
