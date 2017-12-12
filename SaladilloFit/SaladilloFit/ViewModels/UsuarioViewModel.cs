using SaladilloFit.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaladilloFit.Repositories;

namespace SaladilloFit.ViewModels
{
    class UsuarioViewModel : INotifyPropertyChanged
    {
        #region Campos
        /// <summary>
        /// Campo del mensaje de Bienvenida
        /// </summary>
        public string mensaje;
        /// <summary>
        /// Campo del Dni del Usuario
        /// </summary>
        public string dniUsuario;
        /// <summary>
        /// Campo para el Horario del usuario
        /// </summary>
        public string horarioUsuario;
        /// <summary>
        /// Campo para el objetivo del Usuario
        /// </summary>
        public string objetivoUsuario;
        /// <summary>
        /// Campo para la edad del Usuario
        /// </summary>
        public int edadUsuario;
        /// <summary>
        /// Campo para la edad del Usuario
        /// </summary>
        public int alturaUsuario;
        /// <summary>
        /// Campo para el peso del Usuario
        /// </summary>
        public float pesoUsuario;
        /// <summary>
        /// Campo para el ImC del Usuario
        /// </summary>
        private float imcUsuario;
        /// <summary>
        /// Campo implementado por la propiedad INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la Viewmodel
        /// </summary>
        /// <param name="usuario">Usuario que se loguea</param>
        public UsuarioViewModel(Usuarios usuario)
        {
            CargarDatos(usuario);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Mensaje de bienvenida para el Usuario
        /// </summary>
        public string Mensaje
        {
            get
            {
                return mensaje;
            }
            set
            {
                if (mensaje != value)
                {
                    mensaje = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Mensaje"));
                    }
                }
            }
        }
        /// <summary>
        /// Propiedad referente al Imc Del Usuario
        /// </summary>
        public float ImcUsuario
        {
            get
            {
                return imcUsuario;
            }
            set
            {
                if (imcUsuario!= value)
                {
                    imcUsuario = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ImcUsuario"));
                    }
                }
            }
        }
        /// <summary>
        /// Dni del Usuario
        /// </summary>
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
        /// <summary>
        /// Horario del Usuario
        /// </summary>
        public string HorarioUsuario
        {
            get
            {
                return horarioUsuario;
            }
            set
            {
                if (horarioUsuario != value)
                {
                    horarioUsuario = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("HorarioUsuario"));
                    }
                }
            }
        }
        /// <summary>
        /// Objetivo del Usuario
        /// </summary>
        public string ObjetivoUsuario
        {
            get
            {
                return objetivoUsuario;
            }
            set
            {
                if (objetivoUsuario != value)
                {
                    objetivoUsuario = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("HorarioUsuario"));
                    }
                }
            }
        }
        /// <summary>
        /// Edad del usuario
        /// </summary>
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
                    edadUsuario = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("EdadUsuario"));
                    }
                }
            }
        }
        /// <summary>
        /// Altura del Usuario
        /// </summary>
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
        /// <summary>
        /// Peso del usuario
        /// </summary>
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
        #endregion

        #region Metodos
        /// <summary>
        /// Método encargado de cargar los datos en los correspondientes Labels, para ello,
        /// pillamos el usuario que pillamos por constructor y le asignamos los respectivos
        /// valores a cada propiedad.
        /// </summary>
        /// <param name="usuario">Usuario que se conecta</param>
        private async void CargarDatos(Usuarios usuario)
        {
            List<Horarios> horarios = new List<Horarios>(await App.HorarioRepo.ObtenerTodosLosHorarios());
            List<Objetivos> objetivos = new List<Objetivos>(await App.ObjetivoRepo.ObtenerTodosLosObjetivos());
            string horario = horarios.Single(h => h.Id == usuario.Horario).Horario;
            string objetivo = objetivos.Single(o => o.Id == usuario.Objetivo).Objetivo;

            DniUsuario = usuario.Dni;
            HorarioUsuario = horario;
            ObjetivoUsuario = objetivo;
            EdadUsuario = usuario.Edad;
            AlturaUsuario = usuario.Altura;
            PesoUsuario = usuario.Peso;
            ImcUsuario = usuario.Imc;
            Mensaje = usuario.Nombre;

        }


        /// <summary>
        /// Método para cerrar sesión y volver a la página principal
        /// </summary>
        public void CerrarSesion()
        {
            App.Current.MainPage = new MainPage();
        }

        #endregion
    }
}
