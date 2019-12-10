using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.ViewModels;
using Prototipo1_Lyfr.ViewModels.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        Cliente _cliente;
        Cache cache = new Cache();

        public Perfil()
        {
            InitializeComponent();
        }
        public Perfil(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
            this.BindingContext = new PerfilViewModel(_cliente);
        }
        
        private void GoTo_AlterEmail(object sender, EventArgs e)
        {
            DependencyService.Get<INavigationService>().NavigateToAlterarEmail(_cliente);
        }
        private void GoTo_AlterSenha(object sender, EventArgs e)
        {
            DependencyService.Get<INavigationService>().NavigateToAlterarSenha(_cliente);
        }
        private void GoTo_LoginPage(object sender, EventArgs e)
        {
            cache.DeleteClienteLocal();
            DependencyService.Get<INavigationService>().SetLoginMainPage();
        }

        private void edt_Unfocused(object sender, FocusEventArgs e)
        {
            HasNavigationBar.SetHasNavigationBar("");
        }
    }
}