using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Models.LocalDBModels;
using Xamarin.Forms;
using Prototipo1_Lyfr.ViewModels.Services;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.ViewModels
{
    public class ListaPesquisaViewModel : BaseViewModel
    {
        private Lazy<Cache> cache = new Lazy<Cache>();
        private string _SearchBar_Text;
        private PesquisaCache _SelectedItemPesquisa;
        private List<PesquisaCache> _Lista_Pesquisa;
        private List<Livros> _Resultado_Pesquisa;
        private bool _ListaPesquisaIsVisible;
        private bool _ResultadoPesquisaIsVisible;
        private Livros _SelectedLivroResultado;
        private Cliente _cliente;

        public ICommand SearchBar_Command { get; private set; }
        public ICommand SelectionChangedOnLivros_Command { get; private set; }
        public ICommand SelectionChangedOnPesquisa_Command { get; private set; }

        public string SearchBar_Text
        {
            get => _SearchBar_Text;
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
                    {
                        SetProperty(ref _SearchBar_Text, value, nameof(SearchBar_Text));
                        Lista_Pesquisa = cache.Value.GetPesquisaCache().Where(x => x.ItemPesquisado.ToLower().StartsWith(value.ToLower())).ToList();
                        ResultadoPesquisa = new List<Livros>();
                        ListaPesquisaIsVisible = true;
                        ResultadoPesquisaIsVisible = false;
                    }
                    else
                    {
                        ResultadoPesquisa = new List<Livros>();
                        ListaPesquisaIsVisible = true;
                        ResultadoPesquisaIsVisible = false;
                        SetProperty(ref _SearchBar_Text, value, nameof(SearchBar_Text));
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensagem.Mostrar("ERRO > " + ex.Message);
                }
            }
        }
        public PesquisaCache SelectedItemPesquisa
        {
            get => _SelectedItemPesquisa;
            set => SetProperty(ref _SelectedItemPesquisa, value, nameof(SelectedItemPesquisa));
        }
        public List<PesquisaCache> Lista_Pesquisa
        {
            get => _Lista_Pesquisa;
            set => SetProperty(ref _Lista_Pesquisa, value, nameof(Lista_Pesquisa));
        }
        public List<Livros> ResultadoPesquisa
        {
            get => _Resultado_Pesquisa;
            set => SetProperty(ref _Resultado_Pesquisa, value, nameof(ResultadoPesquisa));
        }
        public bool ListaPesquisaIsVisible
        {
            get => _ListaPesquisaIsVisible;
            set => SetProperty(ref _ListaPesquisaIsVisible, value, nameof(ListaPesquisaIsVisible));
        }
        public bool ResultadoPesquisaIsVisible
        {
            get => _ResultadoPesquisaIsVisible;
            set => SetProperty(ref _ResultadoPesquisaIsVisible, value, nameof(ResultadoPesquisaIsVisible));
        }
        public Livros SelectedLivroResultado
        {
            get => _SelectedLivroResultado;
            set => SetProperty(ref _SelectedLivroResultado, value, nameof(SelectedLivroResultado));
        }
        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value, nameof(Cliente));
        }

        public ListaPesquisaViewModel()
        {
            ListaPesquisaIsVisible = true;
            ResultadoPesquisaIsVisible = false;
            SearchBar_Command = new Command(GuardarHistorico);
            SelectionChangedOnLivros_Command = new Command(OpenInfoLivro);
            SelectionChangedOnPesquisa_Command = new Command(SetValueInSearchBar);
        }
        private async void GuardarHistorico()
        {
            try
            {
                PesquisaCache p = new PesquisaCache
                {
                    ItemPesquisado = SearchBar_Text,
                    DataPesquisa = DateTime.Now.ToString("dd/MM/yyyy")
                };
                cache.Value.InserirPequisaCache(p);
                ListaPesquisaIsVisible = false;
                ResultadoPesquisaIsVisible = true;
                Lazy<ConexaoAPI> con = new Lazy<ConexaoAPI>();
                ResultadoPesquisa = await con.Value.SearchLivros(SearchBar_Text, GerarToken.GetTokenFromCache());
            }
            catch (Exception ex)
            {
                MostrarMensagem.Mostrar("ERRO -> " + ex.Message);
            }
        }
        private void OpenInfoLivro()
        {
            DependencyService.Get<INavigationService>().NavigateToInfoLivro(SelectedLivroResultado, Cliente);
        }
        private void SetValueInSearchBar()
        {
            var a = SelectedItemPesquisa as PesquisaCache;
            SearchBar_Text = a.ItemPesquisado;
            GuardarHistorico();
        }
    }
}
