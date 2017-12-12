using SaladilloFit.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaladilloFit.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Campos
        /// <summary>
        /// Usuario que hemos escrito
        /// </summary>
        public string usuario;
        /// <summary>
        /// Contraseña que hemos escrito
        /// </summary>
        public string password;
        /// <summary>
        /// Campo para los diferentes mensajes de errores a la hora de validar
        /// </summary>
        public string mensajeError;
        /// <summary>
        /// Campo implementado por la propiedad INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad para el nombre del Usuario
        /// </summary>
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                if (usuario != value)
                {
                    usuario = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Usuario"));
                    }
                }
            }
        }
        /// <summary>
        /// Propiedad para la contraseña
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                    }
                }
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método encargado de Iniciar sesión y de validar los campos introducidos para 
        /// ver si se ha producido algún error a la hora de insertar en los datos, si el
        /// usuario no existe, etc.
        /// </summary>
        /// <param name="currentPage">Página actual para poder lanzar un DisplayAlert</param>
        public async void IniciarSesion(Page currentPage)
        {
            if (ValidarDatosInsertados())
            {
                Usuarios usuarioBusqueda;
                ObservableCollection<Usuarios> usuarios = new ObservableCollection<Usuarios>(await App.UsuarioRepo.ObtenerTodosLosUsuarios());

                usuarioBusqueda = usuarios.SingleOrDefault(usuario => usuario.Dni == Usuario && usuario.Password == Password);

                if(usuarioBusqueda != null)
                {
                    switch (usuarioBusqueda.Tipo)
                    {
                        case "USUARIO":
                            App.Current.MainPage = new UsuarioPage(usuarioBusqueda);
                            break;
                        case "GERENTE":
                            App.Current.MainPage = new GerentePage();
                            break;
                    }
                }
                else
                {
                    mensajeError = "Los datos introducidos no se encuentran en la base de Datos";
                    await currentPage.DisplayAlert("Error", mensajeError, "Aceptar");
                }

            }
            else
            {
                await currentPage.DisplayAlert("Error", mensajeError, "Aceptar");
            }
        }
        /// <summary>
        /// Método encargado de realizar las diferentes validaciones a los valores introducidos
        /// para comprobar si se exceden caracteres , etc.
        /// </summary>
        /// <returns></returns>
        public bool ValidarDatosInsertados()
        {
            bool datosValidos = true;

            if (string.IsNullOrEmpty(Usuario) && string.IsNullOrEmpty(Password))
            {
                mensajeError = "Los campos de usuario y contraseña están vacíos";
                datosValidos = false;
            }else if (string.IsNullOrEmpty(Usuario))
            {
                mensajeError = "El campo de Usuario está vacío";
                datosValidos = false;
            }else if (string.IsNullOrEmpty(Password))
            {
                mensajeError = "El campo de Contraseña está vacío";
                datosValidos = false;
            }else if (Usuario.Length > 9 && Password.Length > 9)
            {
                mensajeError = "La longitud de los campos Usuario y Contraseña excede la cantidad de caracteres permitida.";
                datosValidos = false;
            }else if (Usuario.Length > 9)
            {
                mensajeError = "La longitud del campo Usuario excede la cantidad de caracteres permitida";
                datosValidos = false;
            }else if (Password.Length > 9)
            {
                mensajeError = "La longitud del campo Contraseña excede la cantidad de caracteres permitida";
                datosValidos = false;
            }

            return datosValidos;
        }

        #endregion
    }
}
