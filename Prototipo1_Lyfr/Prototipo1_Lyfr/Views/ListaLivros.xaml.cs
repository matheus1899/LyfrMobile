using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.Models;
using System.Collections.Generic;
using Prototipo1_Lyfr.ViewModels;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaLivros : ContentPage
    {
        ListaLivrosViewModel bind;
        public ListaLivros(List<Livros> lista, Cliente cliente, string Genero)
        {
            InitializeComponent();
            bind = this.BindingContext as ListaLivrosViewModel;
            bind.SetListaLivros(lista);
            bind.Cliente = cliente;
            bind.NomeGenero = Genero;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            bind.SetSelectedItemToNull();
        }
    }
}