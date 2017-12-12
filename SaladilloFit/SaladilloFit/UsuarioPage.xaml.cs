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
        UsuarioViewModel usuarioViewModel;

        public UsuarioPage(Usuarios usuario)
        {
            InitializeComponent();
            usuarioViewModel = new UsuarioViewModel(usuario);
            BindingContext = usuarioViewModel;
            btnCerrarSesion.Clicked += CerrarSesion;
        }

        private void CerrarSesion(object sender, EventArgs e)
        {
            usuarioViewModel.CerrarSesion();
        }
    }
}