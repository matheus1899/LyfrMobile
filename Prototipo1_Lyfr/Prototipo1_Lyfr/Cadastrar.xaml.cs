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
    public partial class Cadastrar : ContentPage
    {
        private bool pago = false;
        private bool gratis = true;
        public Cadastrar(){
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed(){
            App.Current.MainPage = new Login();
            return true;
        }

        private void btn_gratis_Clicked(object sender, EventArgs e)
        {
            pago = false;
            gratis = true;
            btn_gratis.Style = Application.Current.Resources["Style_Button_Ativo"] as Style;
            btn_pago.Style = Application.Current.Resources["Style_Button_Desativo"] as Style;
        }

        private void btn_pago_Clicked(object sender, EventArgs e)
        {
            pago = true;
            gratis = false;
            btn_pago.Style = Application.Current.Resources["Style_Button_Ativo"] as Style;
            btn_gratis.Style = Application.Current.Resources["Style_Button_Desativo"] as Style;
        }

        private void cadastrar_Clicked(object sender, EventArgs e)
        {
            return;
        }

        private void ibtn_SenhaOuNao_Clicked(object sender, EventArgs e)
        {
            ent_Senha_Usuario.IsPassword = !ent_Senha_Usuario.IsPassword;
        }
    }
}