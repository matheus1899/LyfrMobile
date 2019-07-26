using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Leitor : ContentPage
    {

        public Leitor(string url, string nome_livro)
        {
            InitializeComponent();
            webview.Source = url;
        }
    }
}