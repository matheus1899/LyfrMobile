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
using Prototipo1_Lyfr.Controls;

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
            string caminho = GetLivroCache(_livro.Arquivo, _livro.Titulo);
            FileStream fs = File.Open(caminho, FileMode.Open);

            epubBook =  EpubReader.ReadBook(fs);
            bookContent = epubBook.Content;
        }

        public static string GetLivroCache(string link, string titulo)
        {
            var diretorio = "storage/emulated/0/Android/data/com.the_endeavour.lyfr/files/" + titulo.Replace(" ", "") + ".epub";
            if (!Directory.Exists(diretorio))
            {
                System.Net.WebClient client = new System.Net.WebClient();
                client.DownloadFile(link, diretorio);
                return diretorio;
            }
            else
            {
                return diretorio;
            }
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
