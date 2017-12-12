using SaladilloFit.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SaladilloFit
{
    public partial class App : Application
    {
        public static RepositorioUsuario UsuarioRepo {get; set;}
        public static RepositorioHorario HorarioRepo { get; set; }
        public static RepositorioObjetivo ObjetivoRepo { get; set; }

        public App(string filename)
        {
            InitializeComponent();
            UsuarioRepo = new RepositorioUsuario(filename);
            HorarioRepo = new RepositorioHorario(filename);
            ObjetivoRepo = new RepositorioObjetivo(filename);
            MainPage = new SaladilloFit.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
