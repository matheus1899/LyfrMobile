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
        List<Modelo.Livro> lista_livros = new List<Modelo.Livro>();
        List<Modelo.Livro> lista_livros2 = new List<Modelo.Livro>();
        public Home()
        {
            InitializeComponent();
            lista_livros.Add(new Modelo.Livro { Nome = "Noturno", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51rU3nLQ%2BFL.jpg" });
            lista_livros.Add(new Modelo.Livro { Nome = "Dom Casmurro", Source_imagem = "https://blog.poemese.com/wp-content/uploads/2016/06/principais-obras-de-machado-de-assis-dom-casmurro-211x300.jpg" });
            lista_livros.Add(new Modelo.Livro { Nome = "A Queda", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" });
            lista_livros.Add(new Modelo.Livro { Nome = "Noite Eterna", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51tpIBvS9pL.jpg" });
            lista_livros.Add(new Modelo.Livro { Nome = "O Iluminado", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51gewmYeKUL.jpg" });
            lista_livros.Add(new Modelo.Livro { Nome = "It, A Coisa - Livro 1", Source_imagem = "https://img.wook.pt/images/a-coisa---livro-i-stephen-king/MXwyMTQwMjgzN3wxNzI3NjgxN3wxNTM3NDg0NDAwMDAw/250x" });
            lista_livros.Add(new Modelo.Livro { Nome = "Doutor Sono", Source_imagem = "http://statics.livrariacultura.net.br/products/capas_lg/732/42743732.jpg" });
            lista_livros.Add(new Modelo.Livro { Nome = "As Fontes do Paraíso", Source_imagem = "https://editoraaleph.vteximg.com.br/arquivos/ids/155589-800-1145/01_AsFontesDoParaiso.png?v=636022977747630000" });
            lista_livros.Add(new Modelo.Livro { Nome = "Fundação", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/41BRVR07ilL.jpg" });
            lista_livros.Add(new Modelo.Livro { Nome = "Segunda Fundação", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51cghxPyCUL.jpg" });
            lista_livros.Add(new Modelo.Livro { Nome = "O País de Outubro", Source_imagem = "https://4.bp.blogspot.com/-diMAvkRTnmI/UJmI6HTqDNI/AAAAAAAABiE/Z8UfJs4PULU/s1600/O_PAIS_DE_OUTUBRO_1318297292P.jpg" });
            lista.ItemsSource = lista_livros;
            lista_livros2.Add(new Modelo.Livro { Nome = "Como as Democracias Morrem", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/41p-rmMszcL.jpg", Url = "https://drive.google.com/file/d/1nKDf3z9Zkqb68lnndyTe5P0JMFl-GvUO/view?usp=sharing" });
            lista_livros2.Add(new Modelo.Livro { Nome= "A tolice da inteligência brasileira: ou como o país se deixa manipular pela elite",Source_imagem= "https://images-na.ssl-images-amazon.com/images/I/41375M5Dk1L._SX339_BO1,204,203,200_.jpg" });
            lista_livros2.Add(new Modelo.Livro { Nome = "Noturno", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51rU3nLQ%2BFL.jpg" });
            lista_livros2.Add(new Modelo.Livro { Nome = "A Queda", Source_imagem = "https://http2.mlstatic.com/livro-a-queda-guillermo-del-toro-trilogia-da-escurido-D_NQ_NP_844805-MLB29047464498_122018-F.jpg" });
            lista_livros2.Add(new Modelo.Livro { Nome = "Noite Eterna", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51tpIBvS9pL.jpg" });
            lista_livros2.Add(new Modelo.Livro { Nome = "Encontro com Rama", Source_imagem = "https://images-na.ssl-images-amazon.com/images/I/51vNPYb6FEL.jpg" });
            lista2.ItemsSource = lista_livros2;
        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            //var a = sender as ContentPage;
            //if (a.Width > a.Height)
            //{

            //}
            //else{

            //}
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string Nome_livro = (e.CurrentSelection.FirstOrDefault() as Modelo.Livro).Nome;
            //Modelo.Livro livro_selecionado = lista_livros.First(j => j.Nome == Nome_livro);
            //Navigation.PushAsync(new NavigationPage(new Leitor(livro_selecionado.Url, livro_selecionado.Nome)));

        }
        private async void CollectionView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string Nome_livro = (e.CurrentSelection.FirstOrDefault() as Modelo.Livro)?.Nome;
                Modelo.Livro livro_selecionado = lista_livros2.First(j => j.Nome == Nome_livro);

                /*string Sandbox = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var web = new WebClient();
                string diretorio = Path.Combine(Sandbox, "books");
                web.DownloadFileAsync(new Uri(livro_selecionado.Url), Path.Combine(diretorio));
                await DisplayAlert("Atenção",livro_selecionado.Url+" -> "+diretorio ,"OK");
                if(File.Exists(Path.Combine(diretorio,livro_selecionado.Nome + ".epub"))){
                    Path.ChangeExtension(Path.Combine(diretorio,livro_selecionado.Nome + ".epub"), ".zip");
                    ZipFile.ExtractToDirectory(Path.Combine(diretorio, livro_selecionado.Nome + ".zip"), Path.Combine(diretorio,livro_selecionado.Nome));
                    File.Delete(Path.Combine(diretorio, livro_selecionado.Nome + ".zip"));
                    string content = Path.GetFullPath(Path.Combine(diretorio,livro_selecionado.Nome));
                    await DisplayAlert("Aviso", content, "OK");
                    return;
                }
                else{
                    await DisplayAlert("Aviso","Erro na tentiva de download. Verifique se seu dispositivo tem conexão com rede e tente novamente","OK");
                    return;
                }*/
            }
            catch (Exception exception)
            {
                await DisplayAlert("Aviso", "-> " + exception.Message, "OK");
                return;
            }

        }

    }
}