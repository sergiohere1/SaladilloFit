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

        private void CerrarSesion(object sender, EventArgs e)
        {
            gerenteViewModel.CerrarSesion();
        }

        private void AniadirUsuario(object sender, EventArgs e)
        {
            gerenteViewModel.CrearUsuario(this);
        }
    }
}