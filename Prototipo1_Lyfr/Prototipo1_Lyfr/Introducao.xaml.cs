using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Introducao : CarouselPage
    {
        public Introducao()
        {
            InitializeComponent();
        }

        private void ChamarPagCadastrar(object sender, EventArgs e)
        {
            App.Current.MainPage = new Cadastrar();
        }

        private void ChamarPagLogin(object sender, EventArgs e)
        {
            App.Current.MainPage = new Login();
        }
    }
}