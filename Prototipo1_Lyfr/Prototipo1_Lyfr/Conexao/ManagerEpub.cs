using System;
using System.Collections.Generic;
using System.IO;
using VersFx.Formats.Text.Epub;
using System.Text;
using Prototipo1_Lyfr.Models;
using Xamarin.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.Conexao
{
    public class ManagerEpub
    {
        ConexaoAPI conexao = new ConexaoAPI();
        public List<Capitulos> list_capitulos{ get; set; }
        EpubBook epubBook;
        EpubContent bookContent;
        HtmlWebViewSource htmlWeb = new HtmlWebViewSource();

        public static string capitulo;
        Livros _livro;

        public  ManagerEpub(Livros Livro)
        {
            this._livro = Livro;
            GetLivroFromCache();
        }

        public async void GetLivroFromCache()
        {
            var livro = await GetLivro(_livro.Titulo);
            string caminho = CacheLiteDB.GetLivroFromCache(livro.Arquivo, _livro.Titulo);
            FileStream fs = File.Open(caminho, FileMode.Open);
            epubBook = EpubReader.ReadBook(fs);
            bookContent = epubBook.Content;
        }

        public async Task<Livros> GetLivro(string titulo)
        {
            Livros l = await conexao.GetLivroByTitulo(titulo, GerarToken.GetTokenFromCache());
            return l;
        }

        public List<Capitulos> LoadChapter()
        {
            foreach (EpubChapter chapter in epubBook.Chapters)
            {
                list_capitulos.Add(new Capitulos() { Title = chapter.Title, TargetType = typeof(Leitor)});
            }
            return list_capitulos;
        }

        public HtmlWebViewSource LoadBook(string capitulo)
        {
            foreach (EpubChapter chapter in epubBook.Chapters)
            {
                string htmlcontent = chapter.HtmlContent;
                if (chapter.Title == capitulo)
                {
                    htmlWeb.Html += htmlcontent;
                }
            }
            return htmlWeb;
        }

    
    }
}
