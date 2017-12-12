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
        public string mensaje;
        public string dniUsuario;
        public string horarioUsuario;
        public string objetivoUsuario;
        public int edadUsuario;
        public int alturaUsuario;
        public float pesoUsuario;
        private float imcUsuario;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public UsuarioViewModel(Usuarios usuario)
        {
            cargarDatos(usuario);
        }

        private async void cargarDatos(Usuarios usuario)
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

        public void CerrarSesion()
        {
            App.Current.MainPage = new MainPage();
        }

        
    }
}
