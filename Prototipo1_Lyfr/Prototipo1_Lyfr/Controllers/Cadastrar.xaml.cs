using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastrar : ContentPage
    {
        private bool pago = false;
        public Cadastrar(){
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Grid_.Children[4].TranslationX = 1500;
            Grid_.Children[5].TranslationX = 1500;
            Grid_.Children[6].TranslationX = 1500;
            Grid_.Children[7].TranslationX = 1500;
            Grid_.Children[8].TranslationX = 1500;
            Grid_.Children[9].TranslationX = 1500;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override bool OnBackButtonPressed(){
            Navigation.PushAsync(new Login());
            return true;
        }

        private void btn_gratis_Clicked(object sender, EventArgs e)
        {
            btn_gratis.IsEnabled = false;
            btn_pago.IsEnabled = false;
            btn_Cadastrar.IsEnabled = false;
            pago = !pago;
            btn_gratis.Style = Application.Current.Resources["Style_Button_Ativo"] as Style;
            btn_pago.Style = Application.Current.Resources["Style_Button_Desativo"] as Style;

            Task.Run(() => {
                for(int i = 4; i <= 9; i++) {
                    //Grid_.Children[i].TranslateTo(1500, 0, 150, Easing.Linear);
                    Task.Run(()=> {
                        int n = 0;
                        while (n <= 1500)
                        {
                            Grid_.Children[i].TranslationX = n++;
                        }
                    });
                        //Device.BeginInvokeOnMainThread(()=> { Grid_.Children[i].IsVisible = false; });
                }
            });

            btn_gratis.IsEnabled = true;
            btn_pago.IsEnabled = true;
            btn_Cadastrar.IsEnabled = true;
        }
        private void btn_pago_Clicked(object sender, EventArgs e)
        {
            btn_gratis.IsEnabled = false;
            btn_pago.IsEnabled = false;
            btn_Cadastrar.IsEnabled = false;

            pago = !pago;
            btn_pago.Style = Application.Current.Resources["Style_Button_Ativo"] as Style;
            btn_gratis.Style = Application.Current.Resources["Style_Button_Desativo"] as Style;
            if (pago)
            {

                Stack_Ent_CPF.IsVisible = true;
                Stack_Ent_CEP.IsVisible = true;
                Stack_Ent_Tele.IsVisible = true;
                Stack_Ent_DataNasc.IsVisible = true;
                Stack_Ent_Rua_Numero.IsVisible = true;
                Stack_Ent_Cidade_Estado.IsVisible = true;

                Task.Run(async()=> {
                    await Stack_Ent_CPF.TranslateTo(0, 0, 350, Easing.Linear);
                });
                Task.Run(async () => {
                    await Stack_Ent_CEP.TranslateTo(0, 0, 350, Easing.Linear);
                });
                Task.Run(async () =>
                {
                    await Stack_Ent_Tele.TranslateTo(0, 0, 350, Easing.Linear);
                });
                Task.Run(async () =>
                {
                    await Stack_Ent_DataNasc.TranslateTo(0, 0, 350, Easing.Linear);
                });
                Task.Run(async () =>
                {
                    await Stack_Ent_Rua_Numero.TranslateTo(0, 0, 350, Easing.Linear);
                });
                Task.Run(async () =>
                {
                    await Stack_Ent_Cidade_Estado.TranslateTo(0, 0, 350, Easing.Linear);
                });
            }
            btn_gratis.IsEnabled = true;
            btn_pago.IsEnabled = true;
            btn_Cadastrar.IsEnabled = true;
        }
        private void Cadastrar_Clicked(object sender, EventArgs e)
        {
            return;
        }
        private async void Esconde_Exibe_Senha_Clicked(object sender, EventArgs e)
        {
            ent_Senha_Usuario.IsPassword = !ent_Senha_Usuario.IsPassword;
            await btn_Img_Eye.ScaleTo(1.3,100,Easing.SpringIn);
            await btn_Img_Eye.ScaleTo(1,100,Easing.BounceIn);
        }
        
        private void Lbl_Apagar_Entry(object sender, EventArgs e)
        {
            var a = sender as Label;
            var pai = a.Parent as StackLayout;
            var ent = pai.Children[0] as Entry;
            ent.Text = string.Empty;
        }
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ent = sender as Entry;
            var stc = ent.Parent as StackLayout;
            var lbl = stc.Children[1] as Label;

            int lenght = ent.Text.Length;
            if (lenght > 0)
            {
                lbl.IsEnabled = true;
                lbl.IsVisible = true;
            }
            else
            {
                lbl.IsEnabled = false;
                lbl.IsVisible = false;
            }
        }
        private void Entry_Focused(object sender, FocusEventArgs e)
        {

            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            if (string.IsNullOrEmpty(a.Text))
            {
                c.IsEnabled = false;
                c.IsVisible = false;
                return;
            }
            if (a.Text.Length > 0)
            {
                c.IsEnabled = true;
                c.IsVisible = true;
            }
            else
            {
                c.IsEnabled = false;
                c.IsVisible = false;
            }
        }
        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            c.IsEnabled = false;
            c.IsVisible = false;
        }
        
    }
}