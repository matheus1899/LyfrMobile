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

        private void ChamarPagCadastrar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastrar());
        }

        private void Logar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new MainPage()));
        }

        private void Esqueceu_Senha_Tapped(object sender, EventArgs e)
        {

        }
    }
}
