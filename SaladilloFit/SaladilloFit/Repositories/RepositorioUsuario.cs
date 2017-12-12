using SaladilloFit.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Repositories
{
    public class RepositorioUsuario
    {
        /// <summary>
        /// Mensaje de Estado por si nos ocurriese algún error al insertar/obtener los usuarios
        /// </summary>
        public string MensajeDeEstado { get; set; }
        /// <summary>
        /// La conexión asíncrona que se conectará a nuestra base de datos.
        /// </summary>
        private SQLiteAsyncConnection conn;

        public RepositorioUsuario(string dbPath) {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Usuarios>().Wait();
        }

        /// <summary>
        /// Método con el que obtendremos todos los usuarios que haya registrados en 
        /// nuestra base de datos.
        /// </summary>
        /// <returns>Lista con todos los usuarios</returns>
        public async Task<List<Usuarios>> ObtenerTodosLosUsuarios()
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();

            try
            {
                listaUsuarios = await conn.Table<Usuarios>().ToListAsync();
            }catch(Exception ex)
            {
                MensajeDeEstado = string.Format("Error al recuperar datos, {0}", ex.ToString());
            }
            return listaUsuarios;
        }

        /// <summary>
        /// Método encargado de añadir un nuevo usuario a nuestra base de datos.
        /// </summary>
        /// <param name="dniUser">Dni del Usuario que crearemos.</param>
        /// <param name="nombreUser">Nombre del usuario que crearemos.</param>
        /// <param name="passwordUser">Contraseña del usuario que crearemos.</param>
        /// <param name="horarioUser">Horario que tiene el usuario que crearemos.</param>
        /// <param name="edadUser">Edad que tiene el usuario que crearemos.</param>
        /// <param name="alturaUser">Altura que tiene el usuario que crearemos.</param>
        /// <param name="pesoUser">Peso del usuario que crearemos.</param>
        /// <param name="imcUser">Imc del usuario que crearemos.</param>
        /// <param name="objetivoUser">Objetivo del usuario que crearemos.</param>
        /// <param name="tipoUser">Tipo del usuario que crearemos.</param>
        /// <returns>Devuelve un nueo usuario que inserta en la base de datos.</returns>
        public async Task AniadirNuevoUsuario(string dniUser, string nombreUser, string passwordUser, int horarioUser, int edadUser, 
            int alturaUser, float pesoUser, float imcUser, int objetivoUser, string tipoUser)
        {
            int resultado = 0;

            try
            {
                resultado = await conn.InsertAsync(new Usuarios
                {
                    Dni = dniUser,
                    Nombre = nombreUser,
                    Password = passwordUser,
                    Horario = horarioUser,
                    Edad = edadUser,
                    Altura = alturaUser,
                    Peso = pesoUser,
                    Imc = imcUser,
                    Objetivo = objetivoUser,
                    Tipo = tipoUser
                });
            }
            catch (Exception ex)
            {
                MensajeDeEstado = string.Format("Error al insertar datos, {0}", ex.ToString());
            }
        }       
    }
}
