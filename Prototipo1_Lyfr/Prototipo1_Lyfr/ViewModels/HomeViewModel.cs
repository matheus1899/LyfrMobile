using System.Collections.ObjectModel;
using Prototipo1_Lyfr.Models;

namespace Prototipo1_Lyfr.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        // Provavelmente no futuro esses métodos irão se conectar a API carregando os livros pela WEB
        // É provavel também que ambos os métodos recebam sobrecarga recebendo parâmetros como
        // nome de usuário ou categorias de livros...

        //Funções devem ser criadas para o retorno dos Recomendados, de preferência no DB
               

        public ObservableCollection<Livro> LivrosRecomendadosViewModel()
        {
            return new ObservableCollection<Livro>
            {
                new Livro { Nome = "Noturno", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "Dom Casmurro", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "A Queda", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "Noite Eterna", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "O Iluminado", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "It, A Coisa - Livro 1", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "Doutor Sono", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "As Fontes do Paraíso", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "Fundação", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "Segunda Fundação", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "O País de Outubro", Source_imagem = "cover_example.jpg" }
            };
        }
        public ObservableCollection<Livro> ContinueLendoViewModel()
        {
            return new ObservableCollection<Livro>
            {
                new Livro { Nome = "Como as Democracias Morrem", Source_imagem = "cover_example.jpg"},
                new Livro { Nome = "A tolice da inteligência brasileira: ou como o país se deixa manipular pela elite", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "Noturno", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "A Queda", Source_imagem="cover_example.jpg" },
                new Livro { Nome = "Noite Eterna", Source_imagem = "cover_example.jpg" },
                new Livro { Nome = "Encontro com Rama", Source_imagem="cover_example.jpg" }
            };
        }

        public ObservableCollection<Livro> LivrosRecomendados { get=>LivrosRecomendadosViewModel();}
        public ObservableCollection<Livro> ContinueLendo { get => ContinueLendoViewModel(); }
    }
}
