using System.Collections.ObjectModel;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Models.LocalDBModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Prototipo1_Lyfr.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        Lazy<CacheLiteDB> _cacheLite = new Lazy<CacheLiteDB>();
        Lazy<ConexaoAPI> con = new Lazy<ConexaoAPI>();
        
        public HomeViewModel()
        {
            SetList();
        }

        private async void SetList()
        {
            LivrosNovos = await LivrosNovosViewModelAsync();
            ContinueLendo = await ContinueLendoViewModel();
        }

        public async Task<List<Livros>> LivrosNovosViewModelAsync()
        {
            return await con.Value.GetAllLivros(GerarToken.GetTokenFromCache(), 0);          
        }
        public async Task<List<Livros>> ContinueLendoViewModel()
        {
            return await con.Value.GetLivrosByCliente(GerarToken.GetTokenFromCache());
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
