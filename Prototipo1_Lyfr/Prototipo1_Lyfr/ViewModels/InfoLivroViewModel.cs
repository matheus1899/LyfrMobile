using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototipo1_Lyfr.ViewModels
{
    public class InfoLivroViewModel:BaseViewModel
    {
        private Livros _livro;

        public Livros Livro
        {
            get => _livro;
            set => SetProperty<Livros>(ref _livro, value, nameof(Livro));
        }
    }
}
