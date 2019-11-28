using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            listCap.ItemsSource = epub.LoadChapter();
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Capitulos)e.SelectedItem;
            Capitulo = item.Title;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}