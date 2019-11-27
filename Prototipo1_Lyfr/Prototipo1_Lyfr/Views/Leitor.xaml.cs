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
        //string _titulo;
        public Leitor()
        {
            InitializeComponent();
            //this._titulo = l.Titulo;

            //ManagerEpub epub = new ManagerEpub(l);
            web.Source = ManagerEpub.LoadBook(MenuCapitulos.Capitulo);
        }

        private void Left_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            
        }

        private void Right_Direction_Swiped(object sender, SwipedEventArgs e)
        {
            
        }
    }
}