using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Leitor : ContentPage
    {
        string _titulo;
        public Leitor(string Titulo)
        {
            InitializeComponent();
            this._titulo = Titulo;

            ManagerEpub epub = new ManagerEpub(MenuCapitulos.titulo);
            web.Source = epub.LoadBook(MenuCapitulos.Capitulo);
        }

        private void Left_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            
        }

        private void Right_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            
        }
    }
}