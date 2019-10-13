using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPesquisa : ContentPage
    {
        public ListaPesquisa()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            searchbar.Focus();
        }

        private async void btnImageVoltar(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void PesquisaItem_Tapped(object sender, ItemTappedEventArgs e)
        {
            var book = e.Item as Models.Livro;
            //depois ocorre o metodo que chamará
            // a pagina de informações do livro
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Requisitará uma lista de livros com base no que foi escrito
        }
    }
}