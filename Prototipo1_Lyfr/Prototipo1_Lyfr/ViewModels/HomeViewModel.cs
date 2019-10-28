using System.Collections.ObjectModel;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao.Classes;
using Prototipo1_Lyfr.Models.SQLiteModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Prototipo1_Lyfr.Conexao;
using System.Runtime.InteropServices.ComTypes;

namespace Prototipo1_Lyfr.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        public CacheLiteDB _cacheLite = new CacheLiteDB();
        Conexao.Classes.ConexaoAPI con = new Conexao.Classes.ConexaoAPI();
        
        public HomeViewModel()
        {
            SetList();
        }

        private async void SetList()
        {
            LivrosNovos = await LivrosNovosViewModelAsync();
            ContinueLendo =  ContinueLendoViewModel();
        }

        public async Task<List<Livros>> LivrosNovosViewModelAsync()
        {
            var t = await con.GetAllLivros(GerarToken.GetTokenFromCache(),0);
            return t;
            //return _cacheLite.LoadCapas().Result;            
        }
        public List<Livros> ContinueLendoViewModel()
        {
            return new List<Livros>
            {
                new Livros { Titulo = "Como as Democracias Morrem", Capa = "http://www.lyfrapi.com.br/Livros/Capas/lyfr_cover24_10_2019_17_15_39.jpg"},
                new Livros { Titulo = "A tolice da inteligência brasileira: ou como o país se deixa manipular pela elite", Capa = "http://www.lyfrapi.com.br/Livros/Capas/lyfr_cover24_10_2019_17_15_39.jpg" },
                new Livros { Titulo = "Noturno", Capa = "cover_example.jpg" },
                new Livros { Titulo = "A Queda", Capa="cover_example.jpg" },
                new Livros { Titulo = "Noite Eterna", Capa = "cover_example.jpg" },
                new Livros { Titulo = "Encontro com Rama", Capa="cover_example.jpg" }
            };
        }

        private List<Livros> _LivrosNovos;
        private List<Livros> _ContinueLendo;

        public List<Livros> LivrosNovos
        {
            get => _LivrosNovos;
            set => SetProperty(ref _LivrosNovos, value, nameof(LivrosNovos));
        }
        public List<Livros> ContinueLendo
        {
            get => _ContinueLendo;
            set => SetProperty(ref _ContinueLendo, value, nameof(ContinueLendo));
        }


    }
}
