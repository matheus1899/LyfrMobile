﻿using System;
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
        public List<Capitulos> list_capitulos { get; set; }

        public static EpubBook epubBook;
        EpubContent bookContent;

        public static string capitulo;
        Livros _livro;

        public ManagerEpub(Livros Livro)
        {
            this._livro = Livro;
            
            GetLivroFromCache();
        }

        public void GetLivroFromCache()
        {
            string caminho = GetLivroCache(_livro.Arquivo, _livro.Titulo);
            FileStream fs = File.Open(caminho, FileMode.Open);
            epubBook = EpubReader.ReadBook(fs);
            bookContent = epubBook.Content;
        }

        public string GetLivroCache(string link, string titulo)
        {
            var diretorio = "storage/emulated/0/Android/data/com.the_endeavour.lyfr/files/" + titulo.Replace(" ", "") + ".epub";
            if (!Directory.Exists(diretorio))
            {
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    client.DownloadFile(link, diretorio);
                };
                return diretorio;
            }
            else
            {
                return diretorio;
            }
        }

        public void DownloadFile(string link, string diretorio)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            Uri uri = new Uri(link);
            client.DownloadFileAsync(uri, diretorio);
        }

        public List<Capitulos> LoadChapter()
        {
            list_capitulos = new List<Capitulos>();
            foreach (EpubChapter chapter in epubBook.Chapters)
            {
                Capitulos c = new Capitulos();
                c.Title = chapter.Title;

                if (chapter.SubChapters.Count > 0)
                {
                    c.HasSubchapters = true;
                    c.SubChapters = chapter.SubChapters;
                }
                else
                {
                    c.HasSubchapters = false;
                }
                list_capitulos.Add(c);
            }
            return list_capitulos;
        }

        public static HtmlWebViewSource LoadBook(string capitulo)
        {
            HtmlWebViewSource htmlWeb = new HtmlWebViewSource();
            int i = 0;
            foreach (EpubChapter chapter in epubBook.Chapters)
            {
                string htmlcontent = chapter.HtmlContent;

                if (chapter.Title == capitulo)
                {
                    htmlWeb.Html += htmlcontent;
                }
                if (chapter.SubChapters.Count > 0)
                {
                    while (i < chapter.SubChapters.Count)
                    {
                        htmlWeb.Html += chapter.SubChapters[i].HtmlContent;
                        i++;
                    }
                }
            }
            return htmlWeb;
        }

        //public static HtmlWebViewSource LoadBookSubChapter(int index)
        //{
        //    HtmlWebViewSource htmlWeb = new HtmlWebViewSource();

        //    foreach (EpubChapter chapter in epubBook.Chapters)
        //    {
        //        string htmlcontent = chapter.HtmlContent;
        //        htmlWeb.Html += chapter.SubChapters[index].HtmlContent;
        //    }
        //    return htmlWeb;
        //}
    }
}
