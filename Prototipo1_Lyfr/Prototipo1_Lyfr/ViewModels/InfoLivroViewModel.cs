using System;
using Xamarin.Forms;
using System.Windows.Input;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.ViewModels.Services;

namespace Prototipo1_Lyfr.ViewModels
{
    public class InfoLivroViewModel:BaseViewModel
    {
        private Livros _livro;
        private Cliente _cliente;
        ConexaoAPI conexao = new ConexaoAPI();
        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value, nameof(Cliente));
        }
        public ICommand AddLivroToMyList { get; private set; }
        public ICommand GoToReadBook { get; private set; }

        public InfoLivroViewModel()
        {
            AddLivroToMyList = new Command(async()=>
            {
                ConexaoAPI con = new ConexaoAPI();
                try
                {
                    Favoritos favoritos = new Favoritos()
                    {
                        FkIdLivro = _livro.IdLivro,
                        FkIdCliente = Cliente.IdCliente
                    };
                    await con.AddToMyList(favoritos, GerarToken.GetTokenFromCache());
                    MostrarMensagem.Mostrar("Livro adicionado na sua lista!");
                }
                catch (Exception ex)
                {
                    MostrarMensagem.Mostrar(ex.Message);
                }
            });

            GoToReadBook = new Command(GoToLerLivro);
        }
        private async void GoToLerLivro()
        {
            var livro = await conexao.GetLivroByTituloWithoutFile(Livro.Titulo, GerarToken.GetTokenFromCache());
            DependencyService.Get<INavigationService>().GoBackModal();
            DependencyService.Get<INavigationService>().NavigateToMenuCapitulos(livro);          
        }
        public Livros Livro
        {
            get => _livro;
            set => SetProperty<Livros>(ref _livro, value, nameof(Livro));
        }
    }
}
