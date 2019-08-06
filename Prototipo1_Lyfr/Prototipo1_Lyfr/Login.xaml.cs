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

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        private void ChamarPagCadastrar(object sender, EventArgs e)
        {
            App.Current.MainPage = new Cadastrar();
        }

        private void Logar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void Esqueceu_Senha_Tapped(object sender, EventArgs e)
        {
            return;
        }
    }
}
