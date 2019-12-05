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
        List<Livros> minha_lista;
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
        public InfoLivroViewModel()
        {
            AddLivroToMyList = new Command(AddRemoveToMinhaLista);
            GoToReadBook = new Command(GoToLerLivro);
        }
        public async void SetMinhaLista()
        {
            minha_lista = await conexao.Value.GetLivrosByCliente(Cliente.IdCliente, GerarToken.GetTokenFromCache());
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
                int c = minha_lista.Where(x => x.Titulo == Livro.Titulo).Count();
                Favoritos favoritos = new Favoritos()
                {
                    FkIdLivro = Livro.IdLivro,
                    FkIdCliente = Cliente.IdCliente
                };
                if (c > 0)
                {
                    minha_lista.Remove(Livro);
                    MostrarMensagem.Mostrar("Livro removido da sua lista!");
                    AddRemoveMinhaListaText = "Adicionar a minha lista";
                    await conexao.Value.RemoveFromMyList(favoritos, GerarToken.GetTokenFromCache());
                }
                else
                {
                    await conexao.Value.AddToMyList(favoritos, GerarToken.GetTokenFromCache());
                    minha_lista.Add(Livro);
                    MostrarMensagem.Mostrar("Livro adicionado na sua lista!");
                    AddRemoveMinhaListaText = "Remover da minha lista";
                }
            }
            catch (Exception ex)
            {
                MostrarMensagem.Mostrar(ex.Message);
            }
        }
        public void SetHasAddOrRemoveFromMyList()
        {
            if (minha_lista==null)
            {
                AddRemoveMinhaListaText = "Adicionar a minha lista";
                return;
            }
            int c = minha_lista.Where(x => x.Titulo == Livro.Titulo).Count();
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
