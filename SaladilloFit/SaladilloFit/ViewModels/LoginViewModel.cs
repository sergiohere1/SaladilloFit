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
        public string usuario;
        public string password;
        public string mensajeError;
        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
