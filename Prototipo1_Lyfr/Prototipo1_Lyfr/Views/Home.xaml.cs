using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        List<Models.Livro> lista_livros = new List<Models.Livro>();
        List<Models.Livro> lista_livros2 = new List<Models.Livro>();

        public Home()
        {
            InitializeComponent();
            lista_livros.Add(new Models.Livro { Nome = "Noturno", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51rU3nLQ%2BFL.jpg" });
            lista_livros.Add(new Models.Livro { Nome = "Dom Casmurro", Source_imagem = "https://blog.poemese.com/wp-content/uploads/2016/06/principais-obras-de-machado-de-assis-dom-casmurro-211x300.jpg" });
            lista_livros.Add(new Models.Livro { Nome = "A Queda", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" });
            lista_livros.Add(new Models.Livro { Nome = "Noite Eterna", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51tpIBvS9pL.jpg" });
            lista_livros.Add(new Models.Livro { Nome = "O Iluminado", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51gewmYeKUL.jpg" });
            lista_livros.Add(new Models.Livro { Nome = "It, A Coisa - Livro 1", Source_imagem = "https://img.wook.pt/images/a-coisa---livro-i-stephen-king/MXwyMTQwMjgzN3wxNzI3NjgxN3wxNTM3NDg0NDAwMDAw/250x" });
            lista_livros.Add(new Models.Livro { Nome = "Doutor Sono", Source_imagem = "http://statics.livrariacultura.net.br/products/capas_lg/732/42743732.jpg" });
            lista_livros.Add(new Models.Livro { Nome = "As Fontes do Paraíso", Source_imagem = "https://editoraaleph.vteximg.com.br/arquivos/ids/155589-800-1145/01_AsFontesDoParaiso.png?v=636022977747630000" });
            lista_livros.Add(new Models.Livro { Nome = "Fundação", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/41BRVR07ilL.jpg" });
            lista_livros.Add(new Models.Livro { Nome = "Segunda Fundação", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51cghxPyCUL.jpg" });
            lista_livros.Add(new Models.Livro { Nome = "O País de Outubro", Source_imagem = "https://4.bp.blogspot.com/-diMAvkRTnmI/UJmI6HTqDNI/AAAAAAAABiE/Z8UfJs4PULU/s1600/O_PAIS_DE_OUTUBRO_1318297292P.jpg" });
            lista_livros2.Add(new Models.Livro { Nome = "Como as Democracias Morrem", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/41p-rmMszcL.jpg", Url = "https://drive.google.com/file/d/1nKDf3z9Zkqb68lnndyTe5P0JMFl-GvUO/view?usp=sharing" });
            lista_livros2.Add(new Models.Livro { Nome= "A tolice da inteligência brasileira: ou como o país se deixa manipular pela elite",Source_imagem= "https://images-na.ssl-images-amazon.com/images/I/41375M5Dk1L._SX339_BO1,204,203,200_.jpg" });
            lista_livros2.Add(new Models.Livro { Nome = "Noturno", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51rU3nLQ%2BFL.jpg" });
            lista_livros2.Add(new Models.Livro { Nome = "A Queda", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" });
            lista_livros2.Add(new Models.Livro { Nome = "Noite Eterna", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51tpIBvS9pL.jpg" });
            lista_livros2.Add(new Models.Livro { Nome = "Encontro com Rama", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51vNPYb6FEL.jpg" });
            lista.ItemsSource = lista_livros;
            lista2.ItemsSource = lista_livros2;
        
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }


        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushAsync(new Leitor());

        }
        private async void CollectionView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string Nome_livro = (e.CurrentSelection.FirstOrDefault() as Models.Livro)?.Nome;
                Models.Livro livro_selecionado = lista_livros2.First(j => j.Nome == Nome_livro);
            }
            catch (Exception exception)
            {
                await DisplayAlert("Aviso", "-> " + exception.Message, "OK");
                return;
            }

        }

    }
}