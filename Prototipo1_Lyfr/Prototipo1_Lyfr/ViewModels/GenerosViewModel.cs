using System;
using Xamarin.Forms;
using System.Windows.Input;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using System.Collections.Generic;
using Prototipo1_Lyfr.ViewModels.Services;
using Prototipo1_Lyfr.Views;

namespace Prototipo1_Lyfr.ViewModels
{
    public class GenerosViewModel:BaseViewModel
    {
        private Lazy<ConexaoAPI> con = new Lazy<ConexaoAPI>();
        private List<Genero> _listaGeneros;
        private Genero _itemSelected;
        private Cliente _cliente;

        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value, nameof(Cliente));
        }
        public Genero ItemSelected
        {
            get => _itemSelected;
            set => SetProperty(ref _itemSelected, value, nameof(ItemSelected));
        }
        public List<Genero> ListaGeneros
        {
            get => _listaGeneros;
            set => SetProperty(ref _listaGeneros, value, nameof(ListaGeneros));
        }

        public ICommand SelectedItemOnListaCommand { get; private set; }

        public GenerosViewModel()
        {
            SetListaGeneros();
            SelectedItemOnListaCommand = new Command(SelectedItem); 
        }
        private async void SelectedItem()
        {
            if(ItemSelected == null)
            {
                return;
            }
            else
            {
                List<Livros> lista = await con.Value.GetLivrosByGenero(ItemSelected.Nome,GerarToken.GetTokenFromCache());
                App.Current.MainPage.Navigation.PushAsync(new ListaLivros(lista, Cliente));
            }
        }
        private async void SetListaGeneros()
        {
            ListaGeneros = await con.Value.GetAllGeneros(GerarToken.GetTokenFromCache());
        }
        public void SetSelectedItemToNull()
        {
            ItemSelected = null;
        }
    }
}
