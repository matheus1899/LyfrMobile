using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.ViewModels;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPesquisa : ContentPage
    {
        private Cache cache = new Cache();
        public ListaPesquisa(Cliente c)
        {
            try
            {
                InitializeComponent();
                ListaPesquisaViewModel bind = this.BindingContext as ListaPesquisaViewModel;
                bind.Cliente = c;
                NavigationPage.SetHasNavigationBar(this, false);
                searchbar.Focus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERRO -> " + ex.Message);
                MostrarMensagem.Mostrar(ex.Message);
            }
        }

        private async void btnImageVoltar(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void Searchbar_Focused(object sender, FocusEventArgs e)
        {
            lista_Pesquisa.ItemsSource = cache.GetPesquisaCache();
        }
    }
}