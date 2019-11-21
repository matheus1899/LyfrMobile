using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.ViewModels.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ViewModels
{
    public class InfoLivroViewModel:BaseViewModel
    {
        private Livros _livro;
        private Cliente _cliente;

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
        private void GoToLerLivro()
        {
            DependencyService.Get<INavigationService>().NavigateToMenuCapitulos(_livro.Titulo);
        }
        public Livros Livro
        {
            get => _livro;
            set => SetProperty<Livros>(ref _livro, value, nameof(Livro));
        }
    }
}
