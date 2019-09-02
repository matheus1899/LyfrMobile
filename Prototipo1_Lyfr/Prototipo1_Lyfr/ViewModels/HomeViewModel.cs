using System.Collections.Generic;
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
                new Livro { Nome = "Noturno", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" },
                new Livro { Nome = "Dom Casmurro", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" },
                new Livro { Nome = "A Queda", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" },
                new Livro { Nome = "Noite Eterna", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" },
                new Livro { Nome = "O Iluminado", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51gewmYeKUL.jpg" },
                new Livro { Nome = "It, A Coisa - Livro 1", Source_imagem = "https://img.wook.pt/images/a-coisa---livro-i-stephen-king/MXwyMTQwMjgzN3wxNzI3NjgxN3wxNTM3NDg0NDAwMDAw/250x" },
                new Livro { Nome = "Doutor Sono", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" },
                new Livro { Nome = "As Fontes do Paraíso", Source_imagem = "https://editoraaleph.vteximg.com.br/arquivos/ids/155589-800-1145/01_AsFontesDoParaiso.png?v=636022977747630000" },
                new Livro { Nome = "Fundação", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/41BRVR07ilL.jpg" },
                new Livro { Nome = "Segunda Fundação", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51cghxPyCUL.jpg" },
                new Livro { Nome = "O País de Outubro", Source_imagem = "https://4.bp.blogspot.com/-diMAvkRTnmI/UJmI6HTqDNI/AAAAAAAABiE/Z8UfJs4PULU/s1600/O_PAIS_DE_OUTUBRO_1318297292P.jpg" }
            };
        }
        public ObservableCollection<Livro> ContinueLendoViewModel()
        {
            return new ObservableCollection<Livro>
            {
                new Livro { Nome = "Como as Democracias Morrem", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg", Url="https://drive.google.com/file/d/1nKDf3z9Zkqb68lnndyTe5P0JMFl-GvUO/view?usp=sharing"},
                new Livro { Nome = "A tolice da inteligência brasileira: ou como o país se deixa manipular pela elite", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" },
                new Livro { Nome = "Noturno", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" },
                new Livro { Nome = "A Queda", Source_imagem="https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" },
                new Livro { Nome = "Noite Eterna", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" },
                new Livro { Nome = "Encontro com Rama", Source_imagem="https://images-na.ssl-images-amazon.com/images/I/51vNPYb6FEL.jpg" }
            };
        }

        public ObservableCollection<Livro> LivrosRecomendados { get=>LivrosRecomendadosViewModel();}
        public ObservableCollection<Livro> ContinueLendo { get => ContinueLendoViewModel(); }
    }
}
