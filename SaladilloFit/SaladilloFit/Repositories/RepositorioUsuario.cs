﻿using SaladilloFit.Tables;
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
        public string MensajeDeEstado { get; set; }
        private SQLiteAsyncConnection conn;

        public RepositorioUsuario(string dbPath) {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Usuario>().Wait();
        }

        public async Task<List<Usuario>> ObtenerTodosLosUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                listaUsuarios = await conn.Table<Usuario>().ToListAsync();
            }catch(Exception ex)
            {
                MensajeDeEstado = string.Format("Error al recuperar datos, {0}", ex.ToString());
            }
            return listaUsuarios;
        }

        public async Task AniadirNuevoUsuario(string dniUser, string nombreUser, string passwordUser, int horarioUser, int edadUser, 
            int alturaUser, float pesoUser, float imcUser, int objetivoUser, string tipoUser)
        {
            int resultado = 0;

            try
            {
                resultado = await conn.InsertAsync(new Usuario
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