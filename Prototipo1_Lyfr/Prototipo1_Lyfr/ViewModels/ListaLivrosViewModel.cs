using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.ViewModels.Services;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ViewModels
{
    public class ListaLivrosViewModel:BaseViewModel
    {
        private List<Livros> _lista;
        private Livros _itemSelected;
        private Cliente _cliente;

        public List<Livros> ListaLivros
        {
            get => _lista;
            set => SetProperty(ref _lista, value, nameof(ListaLivros));
        }

        public Livros ItemSelected
        {
            get => _itemSelected;
            set => SetProperty(ref _itemSelected, value, nameof(ItemSelected));
        }
        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value, nameof(Cliente));
        }

        public ListaLivrosViewModel()
        {
            SelectionChangedOnLivros_Command = new Command(OpenInfoLivro);
        }

        public ICommand SelectionChangedOnLivros_Command { get; private set; }

        public void SetListaLivros(List<Livros> lista)
        {
            ListaLivros = lista;
        }
        private void OpenInfoLivro()
        {
            DependencyService.Get<INavigationService>().NavigateToInfoLivro(ItemSelected, Cliente);
        }
    }
}
