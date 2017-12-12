using SaladilloFit.Tables;
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
        #region Campos
        /// <summary>
        /// Campo referente al nombre del Usuario que vamos a crear
        /// </summary>
        private string nombreUsuario;
        /// <summary>
        /// Campo referente al Dni del usuario que vamos a crear
        /// </summary>
        private string dniUsuario;
        /// <summary>
        /// Campo referente al índice elegido en el picker
        /// </summary>
        private int indiceHorario;
        /// <summary>
        /// Campo referente a la edad del usuario
        /// </summary>
        private int edadUsuario;
        /// <summary>
        /// Campo referente a la altura del usuario
        /// </summary>
        private int alturaUsuario;
        /// <summary>
        /// Campo referente al peso del usuario
        /// </summary>
        private float pesoUsuario;
        /// <summary>
        /// Campo referente al índice del Objetivo
        /// </summary>
        private int indiceObjetivo;
        /// <summary>
        /// Campo referente a la Lista de Usuarios de nuestra base de Datos
        /// </summary>
        private List<Usuarios> listaUsuarios;
        /// <summary>
        /// Campo referente a los Horarios de nuestra base de Datos
        /// </summary>
        private List<Horarios> listaHorarios;
        /// <summary>
        /// Campo referente a la lita de Objetivos de nuestra base de Datos.
        /// </summary>
        private List<Objetivos> listaObjetivos;
        /// <summary>
        /// Campo referente al mensaje de Error que podrá ver el gerente.
        /// </summary>
        private string mensajeError;
        /// <summary>
        /// Campo implementado por la interfaz de INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public GerenteViewModel()
        {
            CargarDatos();

        }
        #endregion

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

        #region Métodos
        /// <summary>
        /// Método encargado de cargar los datos principales (Pickers, la lista de usuarios,
        /// etc)
        /// </summary>
        private async void CargarDatos()
        {
            ListaUsuarios = new List<Usuarios>(await App.UsuarioRepo.ObtenerTodosLosUsuarios());
            ListaHorarios = new List<Horarios>(await App.HorarioRepo.ObtenerTodosLosHorarios());
            ListaObjetivos = new List<Objetivos>(await App.ObjetivoRepo.ObtenerTodosLosObjetivos());
            IndiceHorario = -1;
            IndiceObjetivo = -1;
        }
        /// <summary>
        /// Método encargado de cerrar sesión
        /// </summary>
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

        /// <summary>
        /// Método encargado de validar los datos escritos por el gerente , y en caso de que alguno
        /// fuese inválido, se impediría su creación.
        /// </summary>
        /// <returns></returns>
        public bool ValidarDatosEscritos()
        {
            bool datosValidados = true;
            Usuarios usuarioBusqueda;

            if(string.IsNullOrEmpty(NombreUsuario) || string.IsNullOrEmpty(DniUsuario) || IndiceHorario == -1 ||
                string.IsNullOrEmpty(EdadUsuario.ToString()) || string.IsNullOrEmpty(AlturaUsuario.ToString()) ||
                    string.IsNullOrEmpty(PesoUsuario.ToString()) || IndiceObjetivo == -1){
                MensajeError = "Por favor, revise los datos";
                datosValidados = false;
            }else if (DniUsuario.Length != 9 || NombreUsuario.Length > 20 || EdadUsuario < 0 || AlturaUsuario < 0 ||
                PesoUsuario < 0)
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

        /// <summary>
        /// Método encargado de calcular el IMC
        /// </summary>
        /// <returns>Devuelve el valor del Imc</returns>
        public float CalcularImc()
        {
            float resultado = 0;
            resultado = (PesoUsuario/(float)(AlturaUsuario / 100)*2);
            return resultado;
        }

        #endregion

    }
}
