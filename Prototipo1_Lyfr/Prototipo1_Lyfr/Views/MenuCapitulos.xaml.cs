using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersFx.Formats.Text.Epub;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuCapitulos : MasterDetailPage
    {
        public static string Capitulo;
        public static string titulo;

        ManagerEpub epub;
        public MenuCapitulos(Livros l)
        {
            InitializeComponent();
            epub = new ManagerEpub(l);
            lblTitulo.Text = l.Titulo;
            Detail = new NavigationPage(new CapaLivro(l));
            try
            {
                listCap.ItemsSource = epub.LoadChapter();
            }
            catch (Exception ex)
            {
                MostrarMensagem.Mostrar("Não foi possível carregar o livro!\n\n" + ex.Message);
            }
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Capitulos)e.SelectedItem;
            //Type page = item.TargetType;
            Detail = new NavigationPage(new Leitor(ManagerEpub.LoadBook(item.Title)));
            IsPresented = false;
        }

        private void ListMenu_ItemSelectedSub(object sender, SelectedItemChangedEventArgs e)
        {
            var subchapter = (EpubChapter)e.SelectedItem;
            HtmlWebViewSource html = new HtmlWebViewSource();
            html.Html = subchapter.HtmlContent;
            //Type page = item.TargetType;
            Detail = new NavigationPage(new Leitor(html));
            IsPresented = false;
        }
    }
}