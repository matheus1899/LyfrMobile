using System;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.Models;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Prototipo1_Lyfr.Models.LocalDBModels;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage(Cliente cliente)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Children.Add(new Generos(cliente));
            this.Children.Add(new Home(cliente));
            this.Children.Add(new Perfil(cliente));
            CurrentPage = this.Children[1];
        }

        public MainPage(ClienteLocal usuario)           
        {
            Cliente cliente = new Cliente()
            {
                IdCliente = usuario.IdCliente,
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Email = usuario.Email,
                Cpf = usuario.Cpf,
                Cep = usuario.Cep,
                Cidade = usuario.Cidade,
                DataNasc = usuario.DataNasc,
                Data_Cadastro = usuario.Data_Cadastro,
                Estado = usuario.Estado,
                Numero = usuario.Numero,
                Rua = usuario.Rua,
                Telefone = usuario.Telefone
            };
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Children.Add(new Generos(cliente));
            this.Children.Add(new Home(cliente));
            this.Children.Add(new Perfil(cliente));
            CurrentPage = this.Children[1];
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            NavigationPage.SetHasNavigationBar(this, false);
            Debug.WriteLine(CurrentPage.GetType().Name);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}