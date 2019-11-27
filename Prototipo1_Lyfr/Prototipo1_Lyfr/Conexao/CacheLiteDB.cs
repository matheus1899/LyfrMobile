using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.IO;
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
            //Com arquivo convertido
            string caminho;
            //byte[] arquivoConvert = Encoding.ASCII.GetBytes(arquivo);
            var diretorio = "storage/emulated/0/Android/data/com.the_endeavour.lyfr/files/";

            if (!Directory.Exists(Path.Combine(diretorio, titulo + ".epub")))
            {
                //File.WriteAllBytes(Path.Combine(diretorio, titulo + ".epub"), Convert.FromBase64String(arquivo));
                byte[] b = Convert.FromBase64String(arquivo);
                using (FileStream file = new FileStream(Path.Combine(diretorio, titulo + ".epub"), System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Read(b, 0, (int)ms.Length);
                    file.Write(b, 0, b.Length);
                    ms.Close();
                }
                caminho = Path.Combine(diretorio, titulo + ".epub");
            }
            else
            {
                caminho = Path.Combine(Path.Combine(diretorio, titulo + ".epub"));
            }
            return caminho;

            //Teste Download
            //var diretorio = "storage/emulated/0/Android/data/com.the_endeavour.lyfr/files/" + titulo.Replace(" ","") + ".epub";
            //string url = "http://www.lyfrapi.com.br/Livros/Epubs/lyfr_book22_10_2019_16_04_42.epub";

            //System.Net.WebClient client = new System.Net.WebClient();
            //client.DownloadFile(url, diretorio);
            //return diretorio;

            //return "storage/emulated/0/Android/data/com.the_endeavour.lyfr/files/teste.epub";
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
