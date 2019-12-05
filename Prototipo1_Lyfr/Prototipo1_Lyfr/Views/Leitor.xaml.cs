using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Leitor : ContentPage
    {
        HtmlWebViewSource _html;
        public Leitor(HtmlWebViewSource html)
        {
            InitializeComponent();
            this._html = html;
            web.Source = _html;
        }

        private void Left_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            
        }

        private void Right_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            
        }
    }
}