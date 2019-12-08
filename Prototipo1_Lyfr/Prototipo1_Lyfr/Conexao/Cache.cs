using SQLite;
using System;
using Xamarin.Forms;
using Prototipo1_Lyfr.Interfaces;
using System.Collections.Generic;
using Prototipo1_Lyfr.Models.LocalDBModels;

namespace Prototipo1_Lyfr.Conexao
{
    public class Cache : IDisposable
    {
        private SQLiteConnection _conexao;
        private bool Disposed;
        public Cache()
        {
            var dep = DependencyService.Get<ICaminhoCache>();
            string caminho = dep.ObterCaminho("bancoCache.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<TokenCache>();
            _conexao.CreateTable<PesquisaCache>();
            _conexao.CreateTable<ClienteLocal>();
            _conexao.CreateTable<PrimeiraVez>();
        }
        #region PrimeiraVez
        public void InserirPrimeiraVez(PrimeiraVez p)
        {
            _conexao.DeleteAll<PrimeiraVez>();
            //Inserindo informações no banco
            _conexao.Insert(p);
        }

        public PrimeiraVez GetPrimeiraVez()
        {
            return _conexao.Table<PrimeiraVez>().FirstOrDefault();
        }

        public void DeletePrimeiraVez()
        {
            _conexao.DeleteAll<PrimeiraVez>();
        }
        public bool IsTablePrimeiraVezNull()
        {
            if (_conexao.Table<PrimeiraVez>().Count() == 0)
            {
                return true;
            }

            return false;
        }
        #endregion
        #region ClienteLocal
        public void InserirClienteLocal(ClienteLocal clienteLocal)
        {
            _conexao.DeleteAll<ClienteLocal>();
            //Inserindo informações no banco
            _conexao.Insert(clienteLocal);
        }

        public ClienteLocal GetClienteLocal()
        {
            return _conexao.Table<ClienteLocal>().FirstOrDefault();
        }

        public void DeleteClienteLocal()
        {
            _conexao.DeleteAll<ClienteLocal>();
        }
        public bool IsTableClienteNull()
        {
            if (_conexao.Table<ClienteLocal>().Count() == 0)
            {
                return true;
            }

            return false;
        }
        #endregion
        #region TokenCache
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
        #endregion
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    _conexao.Dispose();
                }
                // Liberando recursos não gerenciados
                //informa que os recursos já foram liberados
                Disposed = true;
            }
        }
        //Destrutor
        ~Cache(){
            Dispose(false);
        }
    }
}
