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
        LoginViewModel loginViewModel = new LoginViewModel();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = loginViewModel;

            btnIniciarSesion.Clicked += IniciarSesion;

        }

        private void IniciarSesion(object sender, EventArgs e)
        {
            loginViewModel.IniciarSesion(this);
        }
    }
}
