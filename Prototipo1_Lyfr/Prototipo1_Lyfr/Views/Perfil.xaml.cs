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
        private void GoTo_AlterTelefone(object sender, EventArgs e)
        {
            DependencyService.Get<INavigationService>().NavigateToAlterarTelefone(_cliente);
        }
        private void GoTo_AlterEndereco(object sender, EventArgs e)
        {
            DependencyService.Get<INavigationService>().NavigateToAlterarEndereco(_cliente);
        }
        private void GoTo_LoginPage(object sender, EventArgs e)
        {
            DependencyService.Get<INavigationService>().SetLoginMainPage();
        }
    }
}