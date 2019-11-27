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

        public static EpubBook epubBook;
        EpubContent bookContent;
        
        public static string capitulo;
        Livros _livro;

        public  ManagerEpub(Livros Livro)
        {
            this._livro = Livro;
            
            GetLivroFromCache();
        }

        public void GetLivroFromCache()
        {
            string caminho = CacheLiteDB.GetLivroFromCache(_livro.Arquivo, _livro.Titulo);
            FileStream fs = File.Open(caminho, FileMode.Open);
            epubBook = EpubReader.ReadBook(fs);
            bookContent = epubBook.Content;
        }

        public List<Capitulos> LoadChapter()
        {
            list_capitulos = new List<Capitulos>();
            foreach (EpubChapter chapter in epubBook.Chapters)
            {
                list_capitulos.Add(new Capitulos() { Title = chapter.Title, TargetType = typeof(Leitor)});
            }
            return list_capitulos;
        }

        public static HtmlWebViewSource LoadBook(string capitulo)
        {
            HtmlWebViewSource htmlWeb = new HtmlWebViewSource();
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
