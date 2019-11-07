using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Models.LocalDBModels;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPesquisa : ContentPage
    {
        private Cache cache = new Cache();
        string[] livros = {
                "Noturno","A Queda","Noite Eterna","2001 Uma Odisseia no Espaço",
                "2010 Uma Odisseia no Espaço II","O Planeta dos Macacos","A Guerra dos Consoles: Sega, Nintendo e a Batalha que Definiu uma Geração",
                "Fundação","Fundação e Império","Segunda Fundação","O Hobbit","O Senhor dos Anéis: As Duas Torres","Guerra dos Tronos","Encontro com Rama",
                "As Fontes do Paraíso","As Areias de Marte","Pedra no Céu","Dom Casmurro","Andróides sonham com ovelhas elétricas","O Homem do Castelo Alto","Duna",
                "O Feiticeiro de Terramar","O Messias de Duna","O Homem Invisível","A Máquina do Tempo","O Fim da Infância","A Cidade e as Estrelas","Fahrenheit 451",
                "Memórias Póstumas de Bras Cubas","Quincas Borba","O Príncipe","Vidas Secas","Mensagem","O Evangelho segundo Jesus Cristo","Como as Democracias Morrem",
                "Iracema","O Guarani","Espumas Flutuantes","Capitães da Areia","O Sentimento do Mundo","O Cão dos Baskerville","O Signo dos Quatro","House of Cards"
        };
        public ListaPesquisa()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            searchbar.Focus();
        }

        private async void btnImageVoltar(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void PesquisaItem_Tapped(object sender, ItemTappedEventArgs e)
        {
            var book = e.Item as Models.Livro;
            //depois ocorre o metodo que chamará
            // a pagina de informações do livro
        }
        private void Searchbar_Focused(object sender,FocusEventArgs e)
        {
            lista_Pesquisa.ItemsSource = cache.GetPesquisaCache();
        }


        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //Requisitará uma lista de livros com base no que foi escrito
                //lista_Pesquisa.ItemsSource = cache.GetPesquisaCache().Where(x => x.ItemPesquisado.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
                //lista_Pesquisa.ItemsSource = livros.Where(x => x.Contains(e.NewTextValue)).ToList();
                if(string.IsNullOrEmpty(e.NewTextValue) || string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    lista_Pesquisa.ItemsSource = null;
                }
                else
                {
                    lista_Pesquisa.ItemsSource = livros.Where(x=>x.ToLower().StartsWith(e.NewTextValue.ToLower())).ToList();
                }
            }
            catch(InvalidCastException exc)
            {
                MostrarMensagem.Mostrar("ERRO -> "+exc.Message);
                return;
            }
            catch(Exception ex)
            {
                MostrarMensagem.Mostrar("ERRO -> " + ex.Message);
                return;
            }
        }

        private void SearchBar_Pressed(object sender,EventArgs e)
        {
            PesquisaCache pesquisa = new PesquisaCache
            {
                ItemPesquisado = searchbar.Text,
                DataPesquisa = DateTime.Now.Day.ToString()
            };

            try
            {
                cache.InserirPequisaCache(pesquisa);
            }
            catch(Exception ex)
            {
                MostrarMensagem.Mostrar("ERRO -> " + ex.Message);
            }
        }
    }

}