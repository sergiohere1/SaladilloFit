﻿using SaladilloFit.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaladilloFit.ViewModels
{
    public class GerenteViewModel : INotifyPropertyChanged
    {
        private string nombreUsuario;
        private string dniUsuario;
        private int indiceHorario;
        private int edadUsuario;
        private int alturaUsuario;
        private float pesoUsuario;
        private int indiceObjetivo;
        private List<Usuarios> listaUsuarios;
        private List<Horarios> listaHorarios;
        private List<Objetivos> listaObjetivos;
        private string mensajeError;
        public event PropertyChangedEventHandler PropertyChanged;

        public GerenteViewModel()
        {
            CargarDatos();

        }

        #region Propiedades
        public string NombreUsuario
        {
            get
            {
                return nombreUsuario;
            }
            set
            {
                if (nombreUsuario != value)
                {
                    nombreUsuario = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("NombreUsuario"));
                    }
                }
            }
        }

            public string DniUsuario
            {
                get
                {
                    return dniUsuario;
                }
                set
                {
                    if (dniUsuario != value)
                    {
                        dniUsuario = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("DniUsuario"));
                        }
                    }
                }
            }

            public int IndiceHorario
            {
                get
                {
                    return indiceHorario;
                }
                set
                {
                    if (indiceHorario != value)
                    {
                        indiceHorario = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("IndiceHorario"));
                        }
                    }
                }
            }

            public int EdadUsuario
            {
                get
                {
                    return edadUsuario;
                }
                set
                {
                    if (edadUsuario != value)
                    {
                        edadUsuario= value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("EdadUsuario"));
                        }
                    }
                }
            }

            public int AlturaUsuario
            {
                get
                {
                    return alturaUsuario;
                }
                set
                {
                    if (alturaUsuario != value)
                    {
                        alturaUsuario = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("AlturaUsuario"));
                        }
                    }
                }
            }

            public float PesoUsuario
            {
                get
                {
                    return pesoUsuario;
                }
                set
                {
                    if (pesoUsuario != value)
                    {
                        pesoUsuario = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("PesoUsuario"));
                        }
                    }
                }
            }

            public int IndiceObjetivo
            {
                get
                {
                    return indiceObjetivo;
                }
                set
                {
                    if (indiceObjetivo != value)
                    {
                        indiceObjetivo = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("IndiceObjetivo"));
                        }
                    }
                }
            }

            public List<Usuarios> ListaUsuarios
            {
                get
                {
                    return listaUsuarios;
                }
                set
                {
                    if (listaUsuarios != value)
                    {
                        listaUsuarios = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("ListaUsuarios"));
                        }
                    }
                }
            }

            public List<Horarios> ListaHorarios
            {
                get
                {
                    return listaHorarios;
                }
                set
                {
                    if (listaHorarios != value)
                    {
                        listaHorarios = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("ListaHorarios"));
                        }
                    }
                }
            }

            public List<Objetivos> ListaObjetivos
            {
                get
                {
                    return listaObjetivos;
                }
                set
                {
                    if (listaObjetivos != value)
                    {
                        listaObjetivos = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("ListaObjetivos"));
                        }
                    }
                }
            }

            public string MensajeError
            {
                get
                {
                    return mensajeError;
                }
                set
                {
                    if (mensajeError != value)
                    {
                        mensajeError = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("MensajeError"));
                        }
                    }
                }
            }
        #endregion

        private async void CargarDatos()
        {
            ListaUsuarios = new List<Usuarios>(await App.UsuarioRepo.ObtenerTodosLosUsuarios());
            ListaHorarios = new List<Horarios>(await App.HorarioRepo.ObtenerTodosLosHorarios());
            ListaObjetivos = new List<Objetivos>(await App.ObjetivoRepo.ObtenerTodosLosObjetivos());
            IndiceHorario = -1;
            IndiceObjetivo = -1;
        }

        public void CerrarSesion()
        {
            App.Current.MainPage = new MainPage();
        }
        /// <summary>
        /// Método que, una vez validados los datos que haya introducido el gerente, se encargará de crear el
        /// nuevo Usuario e insertarlo en la base de Datos.
        /// </summary>
        /// <param name="currentPage"></param>
        public async void CrearUsuario(Page currentPage)
        {
            if (ValidarDatosEscritos())
            {
                await App.UsuarioRepo.AniadirNuevoUsuario(DniUsuario, NombreUsuario, DniUsuario, IndiceHorario+1, 
                    EdadUsuario, AlturaUsuario, PesoUsuario, CalcularImc(),  IndiceObjetivo+1, "USUARIO");
                MensajeError = "";
                await currentPage.DisplayAlert("", "El usuario fue creado satisfactoriamente", "Aceptar");
                App.Current.MainPage = new GerentePage();
            }
            
        }

        public bool ValidarDatosEscritos()
        {
            bool datosValidados = true;
            Usuarios usuarioBusqueda;

            if(string.IsNullOrEmpty(NombreUsuario) || string.IsNullOrEmpty(DniUsuario) || IndiceHorario == -1 ||
                string.IsNullOrEmpty(EdadUsuario.ToString()) || string.IsNullOrEmpty(AlturaUsuario.ToString()) ||
                    string.IsNullOrEmpty(PesoUsuario.ToString()) || IndiceObjetivo == -1){
                MensajeError = "Por favor, revise los datos";
                datosValidados = false;
            }else if (DniUsuario.Length != 9 || NombreUsuario.Length > 20)
            {
                datosValidados = false;
                MensajeError = "Por favor, revise los datos";
            }
            else
            {
                // Los datos introducidos son válidos, comprobamos que el DNI no se encuentre ya en la base de datos.
                usuarioBusqueda = ListaUsuarios.SingleOrDefault(usuario => usuario.Dni == DniUsuario);
                if(usuarioBusqueda != null) { 
                    MensajeError = "El usuario ya existe";
                    datosValidados = false;
                }
            }

            return datosValidados;
        }

        public float CalcularImc()
        {
            float resultado = 0;
            resultado = (PesoUsuario/(float)(AlturaUsuario / 100)*2);
            return resultado;
        }

    }
}
