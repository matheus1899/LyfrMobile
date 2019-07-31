using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prototipo1_Lyfr
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            var a = sender as ContentPage;
            if (a.Width > a.Height)
            {
                //bxv1.HeightRequest = bxv1.Height * 3.5;
                //bxv2.HeightRequest = bxv2.Height * 3.5;
            }
        }

        private void ChamarPagCadastrar(object sender, EventArgs e)
        {
            App.Current.MainPage = new Cadastrar();
        }

        private void Logar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}
