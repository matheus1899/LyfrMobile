using System;
using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.ViewModels.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.ViewModels
{
    public class InfoLivroViewModel:BaseViewModel
    {
        private Livros _livro;
        private List<Livros> _minha_lista;
        private Cliente _cliente;
        private string _AddRemoveMinhaListaText;
        Lazy<ConexaoAPI> conexao = new Lazy<ConexaoAPI>();


        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value, nameof(Cliente));
        }
        public ICommand AddLivroToMyList { get; private set; }
        public ICommand GoToReadBook { get; private set; }
        public string AddRemoveMinhaListaText
        {
            get => _AddRemoveMinhaListaText;
            set => SetProperty(ref _AddRemoveMinhaListaText, value, nameof(AddRemoveMinhaListaText));
        }
        public Livros Livro
        {
            get => _livro;
            set => SetProperty<Livros>(ref _livro, value, nameof(Livro));
        }
        private List<Livros> MinhaLista
        {
            get => _minha_lista;
            set
            {
                SetProperty(ref _minha_lista, value, nameof(MinhaLista));
                SetHasAddOrRemoveFromMyList();
            }
        }
        public InfoLivroViewModel()
        {
            AddLivroToMyList = new Command(AddRemoveToMinhaLista);
            GoToReadBook = new Command(GoToLerLivro);
        }
        public async void SetMinhaLista()
        {
            MinhaLista = await conexao.Value.GetLivrosByCliente(Cliente.IdCliente, GerarToken.GetTokenFromCache());
        }
        private async void GoToLerLivro()
        {
            var livro = await conexao.Value.GetLivroByTituloWithoutFile(Livro.Titulo, GerarToken.GetTokenFromCache());
            DependencyService.Get<INavigationService>().GoBackModal();
            DependencyService.Get<INavigationService>().NavigateToMenuCapitulos(livro);          
        }
        private async void AddRemoveToMinhaLista()
        {
            try
            {
                await Task.Delay(1000);
                Favoritos favoritos = new Favoritos() { FkIdLivro = Livro.IdLivro, FkIdCliente = Cliente.IdCliente };
                if (MinhaLista == null)
                {
                    List<Livros> v = new List<Livros>();
                    v = MinhaLista;
                    v.Add(Livro);
                    MinhaLista = v;
                    MostrarMensagem.Mostrar("Livro adicionado na sua lista!");
                    await conexao.Value.AddToMyList(favoritos, GerarToken.GetTokenFromCache());
                }
                int c = MinhaLista.Where(x => x.Titulo == Livro.Titulo).Count();
                if (c > 0)
                {
                    List<Livros> v = new List<Livros>();
                    v = MinhaLista;
                    v.Remove(Livro);
                    MinhaLista = v;
                    MostrarMensagem.Mostrar("Livro removido da sua lista!");
                    await conexao.Value.RemoveFromMyList(favoritos, GerarToken.GetTokenFromCache());
                }
                else
                {
                    List<Livros> v = new List<Livros>();
                    v = MinhaLista;
                    v.Add(Livro);
                    MinhaLista = v;
                    MostrarMensagem.Mostrar("Livro adicionado na sua lista!");
                    await conexao.Value.AddToMyList(favoritos, GerarToken.GetTokenFromCache());
                }
            }
            catch (Exception ex)
            {
                MostrarMensagem.Mostrar(ex.Message);
            }
        }
        public void SetHasAddOrRemoveFromMyList()
        {
            if (MinhaLista==null)
            {
                AddRemoveMinhaListaText = "Adicionar a minha lista";
                return;
            }
            int c = MinhaLista.Where(x => x.Titulo == Livro.Titulo).Count();
            if (c > 0)
            {
                AddRemoveMinhaListaText = "Remover da minha lista";
            }
            else
            {
                AddRemoveMinhaListaText = "Adicionar a minha lista";
            }
        }
    }
}
