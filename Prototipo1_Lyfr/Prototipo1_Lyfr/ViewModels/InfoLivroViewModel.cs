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
        private int _MaxLinesOnSinopse;
        private int _MaxLinesOnSobreAutor;
        private string _TextButtonLeiaMaisMenosSinopse;
        private string _TextButtonLeiaMaisMenosSobreAutor;
        ConexaoAPI conexao = new ConexaoAPI();
        public string SinopseLivro { get; set; }
        public string SobreAutorLivro { get; set; }

        public int MaxLinesOnSinopse
        {
            get => _MaxLinesOnSinopse;
            set => SetProperty(ref _MaxLinesOnSinopse, value, nameof(MaxLinesOnSinopse));
        }
        public int MaxLinesOnSobreAutor
        {
            get => _MaxLinesOnSobreAutor;
            set => SetProperty(ref _MaxLinesOnSobreAutor, value, nameof(MaxLinesOnSobreAutor));
        }
        public string TextButtonLeiaMaisMenosSinopse
        {
            get => _TextButtonLeiaMaisMenosSinopse;
            set => SetProperty(ref _TextButtonLeiaMaisMenosSinopse, value, nameof(TextButtonLeiaMaisMenosSinopse));
        }
        public string TextButtonLeiaMaisMenosSobreAutor
        {
            get => _TextButtonLeiaMaisMenosSobreAutor;
            set => SetProperty(ref _TextButtonLeiaMaisMenosSobreAutor, value, nameof(TextButtonLeiaMaisMenosSobreAutor));
        }
        public Cliente Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value, nameof(Cliente));
        }
        public ICommand AddLivroToMyList { get; private set; }
        public ICommand GoToReadBook { get; private set; }
        public ICommand ChangeNumMaxLinesOnSinopseCommand { get; private set; }
        public ICommand ChangeNumMaxLinesOnSobreAutorCommand { get; private set; }

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
            TextButtonLeiaMaisMenosSinopse = "LEIA MAIS";
            TextButtonLeiaMaisMenosSobreAutor = "LEIA MAIS";
            MaxLinesOnSinopse = 5;
            MaxLinesOnSobreAutor = 5;
            GoToReadBook = new Command(GoToLerLivro);
            ChangeNumMaxLinesOnSinopseCommand = new Command(ChangeOnSinopse);
            ChangeNumMaxLinesOnSobreAutorCommand = new Command(ChangeOnSobreAutor);
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

        private void ChangeOnSinopse()
        {
            if (MaxLinesOnSinopse==5)
            {
                MaxLinesOnSinopse = 300;
                TextButtonLeiaMaisMenosSinopse = "LEIA MENOS";
                Livro.Sinopse = SinopseLivro;
                Livro.Autor.Bio = SobreAutorLivro;
            }
            else
            {
                MaxLinesOnSinopse = 5;
                TextButtonLeiaMaisMenosSinopse = "LEIA MAIS";
                Livro.Sinopse = SinopseLivro;
                Livro.Autor.Bio = SobreAutorLivro;
            }
        }
        private void ChangeOnSobreAutor()
        {
            if (MaxLinesOnSobreAutor==5)
            {
                MaxLinesOnSobreAutor = 300;
                TextButtonLeiaMaisMenosSobreAutor = "LEIA MENOS";
                Livro.Sinopse = SinopseLivro;
                Livro.Autor.Bio = SobreAutorLivro;
            }
            else
            {
                MaxLinesOnSobreAutor = 5;
                TextButtonLeiaMaisMenosSobreAutor = "LEIA MAIS";
                Livro.Sinopse = SinopseLivro;
                Livro.Autor.Bio = SobreAutorLivro;
            }
        }
    }
}
