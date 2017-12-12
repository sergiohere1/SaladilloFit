using SaladilloFit.Tables;
using SaladilloFit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaladilloFit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioPage : ContentPage
    {
        /// <summary>
        /// Viewmodel de nuestra página.
        /// </summary>
        UsuarioViewModel usuarioViewModel;

        /// <summary>
        /// Constructor de nuestra página.
        /// </summary>
        /// <param name="usuario">Usuario que se ha logueado.</param>
        public UsuarioPage(Usuarios usuario)
        {
            InitializeComponent();
            usuarioViewModel = new UsuarioViewModel(usuario);
            BindingContext = usuarioViewModel;
            btnCerrarSesion.Clicked += CerrarSesion;
        }

        /// <summary>
        /// Método para cerrar sesión, que en realidad llamará al método cerrar sesión
        /// del viewmodel y que realizará toda la lógica.
        /// </summary>
        /// <param name="sender">Objeto que hace que se de lugar a este evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void CerrarSesion(object sender, EventArgs e)
        {
            usuarioViewModel.CerrarSesion();
        }
    }
}