using Prototipo1_Lyfr.Models;
using System.Collections.Generic;

namespace Prototipo1_Lyfr.ViewModels
{
    public class IntroducaoViewModel:BaseViewModel
    {
        private List<IntroCard> _lista;

        public List<IntroCard> ListaDeExibicao
        {
            get => _lista;
            private set => SetProperty(ref _lista, value, nameof(ListaDeExibicao));
        }

        public IntroducaoViewModel()
        {
            ListaDeExibicao = new List<IntroCard>
            {
                new IntroCard
                {
                    Source_Image="monitor.png",
                    Text="Baixe o app do Lyfr (own vc já fez isso ♥) no seu dispositivo Android, ou leia seus livros na nossa página web pelo seu navegador!"
                },
                new IntroCard
                {
                    Source_Image="books.png",
                    Text="Temos um acervo de livros gigante, onde você poderá adquirir um conhecimento imenso ou simplesmente se entreter!"
                },
                new IntroCard
                {
                    Source_Image="mobile.png",
                    Text="Lyfr foi desenvolvido com uma interface bonita e funcional, pensado especialmente em você! Por que? Porque amamos você leitor fiel!"
                },
                new IntroCard
                {
                    Source_Image="gears.png",
                    Text="Customize sua biblioteca de acordo com seus gostos, e receba sugestões de livros que provavelmente você vai gostar... ou não •-•"
                }
            };
        }
    }
}
