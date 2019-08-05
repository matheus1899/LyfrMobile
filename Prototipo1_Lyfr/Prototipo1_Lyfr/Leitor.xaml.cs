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

        private async void Left_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            HtmlWebViewSource html = new HtmlWebViewSource();
            html.Html = "<p>Teste 1</p>";
            web.Reload();
            web.Source=html;
        }

        private async void Right_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            HtmlWebViewSource html2 = new HtmlWebViewSource();
            html2.Html = "<p>Teste 2</p>";
            web.Reload();
            web.Source = html2;
        }
    }
}