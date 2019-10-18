using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prototipo1_Lyfr.ConexaoAPI;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Models.SQLiteModels;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ViewModels
{
    public class ListaPesquisaViewModel:BaseViewModel
    {
        private Lazy<Cache> cache = new Lazy<Cache>();
        private string _SearchBar_Text;
        private List<PesquisaCache> _Lista_Pesquisa;


        public ICommand SearchBar_Command;

        public string SearchBar_Text
        {
            get => _SearchBar_Text;
            set
            {
                try
                {
                    if(!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
                    {
                        SetProperty(ref _SearchBar_Text,value,nameof(SearchBar_Text));
                        Lista_Pesquisa = cache.Value.GetPesquisaCache().Where( x => x.ItemPesquisado.ToLower().StartsWith(value.ToLower())).ToList();
                    }
                    else
                    {
                        SetProperty(ref _SearchBar_Text, value, nameof(SearchBar_Text));
                    }
                }
                catch(Exception ex)
                {
                    MostrarMensagem.Mostrar("ERRO > "+ex.Message);
                }
            }
        }
        public List<PesquisaCache> Lista_Pesquisa
        {
            get => _Lista_Pesquisa;
            set => SetProperty(ref _Lista_Pesquisa,value,nameof(Lista_Pesquisa));
        }


        public ListaPesquisaViewModel()
        {
            SearchBar_Command = new Command(() => {
                try
                {
                    PesquisaCache p = new PesquisaCache {
                        ItemPesquisado = SearchBar_Text,
                        DataPesquisa = DateTime.Now.ToString() 
                    };

                    cache.Value.InserirPequisaCache(p);
                }
                catch(Exception ex)
                {
                    MostrarMensagem.Mostrar("ERRO -> " + ex.Message);
                }
            });
        }
    }
}
