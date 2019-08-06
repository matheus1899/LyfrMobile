using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Leitor : ContentPage
    {

        public Leitor()
        {
            InitializeComponent();
        }

        private void Left_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            var caminho = new UrlWebViewSource
            {
                Url = "/storage/emulated/0/Download/teste.html"
            };

            web.Source = caminho.Url;
            web.Reload();
        }

        private void Right_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            var caminho = new UrlWebViewSource
            {
                Url = "/storage/emulated/0/Download/teste2.html"
            };

            web.Source = caminho.Url;
            web.Reload();
        }
    }
}