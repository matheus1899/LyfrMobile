using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Prototipo1_Lyfr.Interfaces;

using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Models.LocalDBModels;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.Conexao
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

        public static string GetLivroFromCache(string arquivo, string titulo)
        {
            LiteDatabase _dataBase;
            string caminho;
            byte[] arquivoConvert = Encoding.ASCII.GetBytes(arquivo);
            LiteFileInfo livro;
            _dataBase = new LiteDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Banco.db"));
            if (!_dataBase.FileStorage.Exists(titulo))
            {
                var diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                File.WriteAllBytes(Path.Combine(diretorio, titulo), arquivoConvert);
                FileStream fileStream = File.Open(Path.Combine(diretorio, titulo), System.IO.FileMode.Open);
                _dataBase.FileStorage.Upload(titulo, titulo, fileStream);
                livro = _dataBase.FileStorage.FindById(titulo);
                livro.SaveAs(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), titulo));
              
                caminho = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), titulo);
            }
            else
            {
                caminho = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), titulo);
            }
            return caminho;
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
