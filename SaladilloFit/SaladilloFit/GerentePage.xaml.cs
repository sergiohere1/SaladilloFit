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
    public partial class GerentePage : ContentPage
    {
        GerenteViewModel gerenteViewModel = new GerenteViewModel();
        public GerentePage()
        {
            InitializeComponent();
            BindingContext = gerenteViewModel;
            btnCerrarSesion.Clicked += CerrarSesion;
            btnAniadirUsuario.Clicked += AniadirUsuario;
        }
        /// <summary>
        /// Método para cerrar sesión.
        /// </summary>
        /// <param name="sender">Objeto que hace que se de lugar a este evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void CerrarSesion(object sender, EventArgs e)
        {
            gerenteViewModel.CerrarSesion();
        }

        /// <summary>
        /// Método para añadir un nuevo usuario a la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que hace que se de lugar a este evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void AniadirUsuario(object sender, EventArgs e)
        {
            gerenteViewModel.CrearUsuario(this);
        }
    }
}