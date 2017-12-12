using SaladilloFit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaladilloFit
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Viewmodel que usaremos para nuestra página.
        /// </summary>
        LoginViewModel loginViewModel = new LoginViewModel();

        /// <summary>
        /// Contructor de nuestra página.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            BindingContext = loginViewModel;
            btnIniciarSesion.Clicked += IniciarSesion;
        }

        /// <summary>
        /// Método que se encargará de iniciar sesión, ya sea como cliente o vendedor.
        /// </summary>
        /// <param name="sender">Objeto que hace que se de lugar a este evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void IniciarSesion(object sender, EventArgs e)
        {
            loginViewModel.IniciarSesion(this);
        }
    }
}
