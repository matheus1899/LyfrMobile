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

        private void ChamarPageCadastrar(object sender, EventArgs e)
        {
            App.Current.MainPage = new Cadastrar();
        }

        private void Logar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        private void lbl_LembrarSenha_Tapped(object sender, EventArgs e)
        {
            switch_LembrarSenha.IsToggled = !switch_LembrarSenha.IsToggled;
        }

        private void ibtn_SenhaOuNao_Clicked(object sender, EventArgs e)
        {
            ent_Senha.IsPassword = !ent_Senha.IsPassword;
        }
    }
}
