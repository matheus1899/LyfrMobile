using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastrar : ContentPage
    {
        public Cadastrar()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Grid_.Children[5].TranslationX = 1700;
            Grid_.Children[6].TranslationX = 1700;
            Grid_.Children[7].TranslationX = 1700;
            Grid_.Children[8].TranslationX = 1700;
            Grid_.Children[9].TranslationX = 1700;
            Grid_.Children[10].TranslationX = 1700;
        }
        private void BackToLogin()
        {
            App.Current.MainPage = new Login();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override bool OnBackButtonPressed(){
            BackToLogin();
            return true;
        }
        private async void Esconde_Exibe_Senha_Clicked(object sender, EventArgs e)
        {
            ent_Senha_Usuario.IsPassword = !ent_Senha_Usuario.IsPassword;
            await btn_Img_Eye.ScaleTo(1.3, 100, Easing.SpringIn);
            await btn_Img_Eye.ScaleTo(1, 100, Easing.BounceIn);
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
        private void Senha_Ent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ent = sender as Entry;
            var stc = ent.Parent as StackLayout;
            var lbl = stc.Children[1] as Label;

            int lenght = ent.Text.Length;
            if (lenght > 0)
            {
                lbl.IsEnabled = true;
                lbl.IsVisible = true;
                lbl_aviso.IsVisible = true;
            }
            else
            {
                lbl.IsEnabled = false;
                lbl.IsVisible = false;
            }
        }
        private void Senha_Ent_Unfocused(object sender, FocusEventArgs e)
        {
            lbl_aviso.IsVisible = false;
            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            c.IsEnabled = false;
            c.IsVisible = false;
        }
        private bool IsValidPassword(string password)
        {
            bool _Maiusculo = false;
            bool _Especial = false;

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (password.Length<8)
            {
                return false;
            }
            if (Regex.IsMatch(password, "@#!%&=")==true)
            {
                _Especial = true;
            }
            if (Regex.IsMatch(password, @"\b[A-Z]\w*\b") == true)
            {
                _Maiusculo = true;
            }

            if (_Maiusculo == true && _Especial == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}