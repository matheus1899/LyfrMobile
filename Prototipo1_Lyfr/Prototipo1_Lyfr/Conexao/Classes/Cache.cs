using Prototipo1_Lyfr.Conexao.Interfaces;
using Prototipo1_Lyfr.Models.SQLiteModels;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ConexaoAPI
{
    public class Cache
    {
        private SQLiteConnection _conexao;

        public Cache()
        {
            var dep = DependencyService.Get<ICaminhoCache>();
            string caminho = dep.ObterCaminho("bancoCache.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<TokenCache>();
            _conexao.CreateTable<PesquisaCache>();
        }

        public void InserirTokenCache(TokenCache tokenCache)
        {
            _conexao.DeleteAll<TokenCache>();
            //Inserindo informações no banco
            _conexao.Insert(tokenCache);
        }

        public TokenCache GetTokenCache()
        {
            return _conexao.Table<TokenCache>().FirstOrDefault();
        }

        public bool IsTableNull()
        {
            if (_conexao.Table<TokenCache>().Count() == 0)
            {
                return true;
            }

            return false;
        }


        public void InserirPequisaCache(PesquisaCache pesquisaCache)
        {
            _conexao.Insert(pesquisaCache);
        }

        public List<PesquisaCache> GetPesquisaCache()
        {
            return _conexao.Table<PesquisaCache>().ToList();
        }


    }
}
