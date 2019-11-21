using System;
using System.Collections.Generic;
using System.IO;
using VersFx.Formats.Text.Epub;
using System.Text;
using Prototipo1_Lyfr.Models;
using Xamarin.Forms;

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
        string _titulo;

        public ManagerEpub(string Titulo)
        {
            this._titulo = Titulo;
            var livro = conexao.GetLivroByTitulo(Titulo, GerarToken.GetTokenFromCache()).Result;
            FileStream fs = File.Open(livro.Arquivo, FileMode.Open);
            epubBook = EpubReader.ReadBook(fs);
            bookContent = epubBook.Content;
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
