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
        public Cadastrar()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed(){
            App.Current.MainPage = new Login();
            return true;
        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            var a = sender as ContentPage;
            if (a.Width > a.Height)
            {
                bxv1.HeightRequest = bxv1.Height * 3.3;
                lbl1.Margin = new Thickness(0,0,0,-25);
                //bxv2.HeightRequest = bxv2.Height * 3.3;
                //lbl2.Margin = new Thickness(0,0,0,-30);
                bxv3.HeightRequest = bxv3.Height * 3.3;
                lbl3.Margin = new Thickness(0,0,0,-40);
                bxv4.HeightRequest = bxv4.Height * 3.3;
                lbl4.Margin = new Thickness(0,0,0,-50);
                stack_cad.Style = App.Current.Resources["Style_Stack_Cad"] as Style;
            }
            else
            {
                stack_cad.Style = App.Current.Resources["Style_Stack_Cad2"] as Style;

            }
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

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            var a = sender as ContentPage;
            if (a.Width > a.Height)
            {
                stack_cad.Style = App.Current.Resources["Style_Stack_Cad2"] as Style;
            }
            else
            {
                stack_cad.Style = App.Current.Resources["Style_Stack_Cad"] as Style;

            }
        }

        private void cadastrar_Clicked(object sender, EventArgs e)
        {
            return;
        }
    }
}