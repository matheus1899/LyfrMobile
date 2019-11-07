using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Prototipo1_Lyfr.Conexao.Interfaces;

using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Models.SQLiteModels;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.Conexao.Classes
{
    public class CacheLiteDB:IDisposable
    {
        LiteDatabase _dataBase;
        LiteCollection<Capa> Capas;
        Lazy<Cache> cache = new Lazy<Cache>();
        Lazy<ConexaoAPI> _conexao = new Lazy<ConexaoAPI>();
        List<Livros> livros;
        private bool Disposed;

        public CacheLiteDB()
        {
            _dataBase = new LiteDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("MeuBanco.db"));
            Capas = _dataBase.GetCollection<Capa>();
        }
        public void InserirCapa(Capa capa)
        {
            Capas.Upsert(capa);
        }
        public Capa GetCapa(string nomeLivro)
        {
            if (Capas.Count() > 0)
            {
                return Capas.FindOne(x => x.NomeLivro == nomeLivro);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Capa>> LoadCapas()
        {
            if (Capas.Count() <= 0)
            {
                livros = await _conexao.Value.GetAllLivros(GerarToken.GetTokenFromCache(),0);
                foreach (var livro in livros)
                {
                    Capa capa = new Capa()
                    {
                        NomeLivro = livro.Titulo,
                        Caminho = livro.Capa
                    };
                    InserirCapa(capa);
                }
                return ListarCapas();
            }
            else
            {
                return ListarCapas();
            }
        }
        public List<Capa> ListarCapas()
        {
            return Capas.FindAll().ToList();
        }
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
                    _dataBase.Dispose();
                }
                // Liberando recursos não gerenciados
                //informa que os recursos já foram liberados
                Disposed = true;
            }
        }
        //Destrutor
        ~CacheLiteDB()
        {
            Dispose(false);
        }
    }
}
