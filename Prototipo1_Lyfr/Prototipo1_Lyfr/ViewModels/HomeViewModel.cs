using System.Collections.ObjectModel;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Models.LocalDBModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Prototipo1_Lyfr.ViewModels.Services;
using System.Diagnostics;

namespace Prototipo1_Lyfr.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        Lazy<CacheLiteDB> _cacheLite = new Lazy<CacheLiteDB>();
        Lazy<ConexaoAPI> con = new Lazy<ConexaoAPI>();


        #region Propertys
        private Cliente _cliente;
        private List<Livros> _MinhaLista;
        private List<Livros> _LivrosNovos;
        private List<Livros> _ListaAventura;
        private Livros _MinhaListaItemSelected;
        private Livros _LivrosNovosItemSelected;
        private Livros _LivrosAventuraItemSelected;
        private string _TextMinhaListaEmpty; 
        public string TextMinhaListaEmpty
        {
            get => _TextMinhaListaEmpty;
            set => SetProperty(ref _TextMinhaListaEmpty, value, nameof(TextMinhaListaEmpty));
        }
        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value, nameof(Cliente));
        }
        public List<Livros> LivrosNovos
        {
            get => _LivrosNovos;
            set => SetProperty(ref _LivrosNovos, value, nameof(LivrosNovos));
        }
        public List<Livros> MinhaLista
        {
            get => _MinhaLista;
            set => SetProperty(ref _MinhaLista, value, nameof(MinhaLista));
        }
        public List<Livros> ListaAventura
        {
            get => _ListaAventura;
            set => SetProperty(ref _ListaAventura, value, nameof(ListaAventura));
        }
        public Livros LivrosNovosItemSelected
        {
            get => _LivrosNovosItemSelected;
            set => SetProperty(ref _LivrosNovosItemSelected, value, nameof(LivrosNovosItemSelected));
        }
        public Livros MinhaListaItemSelected
        {
            get => _MinhaListaItemSelected;
            set => SetProperty(ref _MinhaListaItemSelected, value, nameof(MinhaListaItemSelected));
        }
        public Livros LivrosAventuraItemSelected
        {
            get => _LivrosAventuraItemSelected;
            set => SetProperty(ref _LivrosAventuraItemSelected, value, nameof(LivrosAventuraItemSelected));
        }
        #endregion

        public void SetAllListSelectedItems()
        {
            Task.Delay(4000);
            MinhaListaItemSelected = null;
            LivrosNovosItemSelected = null;
            LivrosAventuraItemSelected = null;
        }

        public HomeViewModel()
        {
            TextMinhaListaEmpty = "Não há itens na Sua Lista \nEscolha um livro e adicione";
            MinhaListaSelectedChanged_Command = new Command(SelectedLivroOnMinhaLista);
            LivrosNovosSelectedChanged_Command = new Command(SelectedLivroOnLivroNovos);
            ListaAventuraSelectedChanged_Command = new Command(SelectedLivroOnListaAventura);
            SaibaMais_Command = new Command(async () =>
            {
                try
                {
                    var con = new ConexaoAPI();
                    Livros livro = await con.GetLivroByTituloWithoutFile("Arte da Guerra", GerarToken.GetTokenFromCache());
                    await DependencyService.Get<INavigationService>().NavigateToInfoLivro(livro, Cliente);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("ERRO -> " + ex.Message);
                    return;
                }
            });
        }

        private async void SelectedLivroOnMinhaLista()
        {
            try
            {
                if (MinhaListaItemSelected != null)
                {
                    await DependencyService.Get<INavigationService>().NavigateToInfoLivro(MinhaListaItemSelected, Cliente);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERRO -> " + ex.Message);
                return;
            }
        }
        private async void SelectedLivroOnLivroNovos()
        {
            try
            {
                if (LivrosNovosItemSelected != null)
                {
                    await DependencyService.Get<INavigationService>().NavigateToInfoLivro(LivrosNovosItemSelected, Cliente);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERRO -> " + ex.Message);
                return;
            }
        }
        private async void SelectedLivroOnListaAventura()
        {
            try
            {
                if (LivrosAventuraItemSelected != null)
                {
                    await DependencyService.Get<INavigationService>().NavigateToInfoLivro(LivrosAventuraItemSelected, Cliente);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERRO -> " + ex.Message);
                return;
            }
        }
        public async void SetList()
        {
            MinhaLista = await MinhaListaViewModelAsync();
            LivrosNovos = await LivrosNovosViewModelAsync();
            ListaAventura = await LivrosAventuraViewModelAsync();
        }
        public ICommand SaibaMais_Command { get; private set; }
        public ICommand MinhaListaSelectedChanged_Command { get; private set; }
        public ICommand LivrosNovosSelectedChanged_Command { get; private set; }
        public ICommand ListaAventuraSelectedChanged_Command { get; private set; }

        public async Task<List<Livros>> LivrosNovosViewModelAsync()
        {
            return await con.Value.GetAllLivros(GerarToken.GetTokenFromCache(), 7);
        }
        public async Task<List<Livros>> MinhaListaViewModelAsync()
        {
            return await con.Value.GetLivrosByCliente(Cliente.IdCliente, GerarToken.GetTokenFromCache());
        }
        public async Task<List<Livros>> LivrosAventuraViewModelAsync()
        {
            return await con.Value.GetLivrosByGenero("Aventura", GerarToken.GetTokenFromCache());
        }
    }
}
