using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Interfaces;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text;

namespace Prototipo1_Lyfr
{
    public partial class Login : ContentPage
    {
        GerarToken gerarToken = new GerarToken();
        Conexao.Classes.ConexaoAPI conexao = new Conexao.Classes.ConexaoAPI();

        public Login()
        {
            try
            {
                InitializeComponent();

                NavigationPage.SetHasNavigationBar(this, false);
                //gerarToken.ChecharCache();
            }
            catch (Exception ex)
            {
                DisplayAlert("Aviso", "Seguinte erro ocorreu -> " + ex.Message, "OK");
            }
        }
        protected override bool OnBackButtonPressed()
        {
            //Exit();
            return base.OnBackButtonPressed();
        }

        //private async void Exit()
        //{ 
        //    await DisplayAlert("Lyfr", "Você deseja realmente sair do aplicativo?", "OK", "Cancel").ContinueWith(t => {
        //        if (t.Result)
        //        {
        //            DependencyService.Get<IExit>().ExitApp();
        //        }

        //    });

        //}

        private async void ChamarPagCadastrar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastrar());
        }

        private async void Logar_Clicked(object sender, EventArgs e)
        {

            try
            {
                gerarToken.ChecarCache();

                if (string.IsNullOrEmpty(ent_Email_Usuario.Text))
                {
                    MostrarMensagem.Mostrar("Preencha o campo do e-mail corretamente");
                }
                else if (string.IsNullOrEmpty(ent_Senha_Usuario.Text))
                {
                    MostrarMensagem.Mostrar("Preencha o campo da senha corretamente!");
                }
                else
                {
                    Cliente cliente = new Cliente()
                    {
                        Email = ent_Email_Usuario.Text,
                        Senha = ent_Senha_Usuario.Text
                    };
                    var tkn = GerarToken.GetTokenFromCache();
                    var select = await conexao.SelectOne(cliente, tkn);
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
            }

            catch (Exception ex)
            {
                MostrarMensagem.Mostrar(ex.Message);
                return;
            }

        }

        private async void Esconde_Exibe_Senha_Clicked(object sender, EventArgs e)
        {
            var a = sender as ImageButton;
            await a.ScaleTo(1.3, 100, Easing.SpringIn);
            ent_Senha_Usuario.IsPassword = !ent_Senha_Usuario.IsPassword;
            await a.ScaleTo(1, 100, Easing.BounceIn);
        }
        private void Esqueceu_Senha_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EsqueciSenha());
        }
        private void EntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = sender as Entry;
            int lenght = a.Text.Length;
            if (lenght > 0)
            {
                Lbl_X_Email.IsEnabled = true;
                Lbl_X_Email.IsVisible = true;
            }
            else
            {
                Lbl_X_Email.IsEnabled = false;
                Lbl_X_Email.IsVisible = false;
            }
        }
        private void EntrySenha_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = sender as Entry;
            int lenght = a.Text.Length;
            if (lenght > 0)
            {
                Lbl_X_Senha.IsEnabled = true;
                Lbl_X_Senha.IsVisible = true;
            }
            else
            {
                Lbl_X_Senha.IsEnabled = false;
                Lbl_X_Senha.IsVisible = false;
            }
        }
        private void Lbl_Apagar_Entry_Email(object sender, EventArgs e)
        {
            ent_Email_Usuario.Text = string.Empty;
        }
        private void Lbl_Apagar_Entry_Senha(object sender, EventArgs e)
        {
            ent_Senha_Usuario.Text = string.Empty;
        }
        private void EntryEmail_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Email_Usuario.Text))
            {
                Lbl_X_Email.IsEnabled = false;
                Lbl_X_Email.IsVisible = false;
                return;
            }
            if (ent_Email_Usuario.Text.Length > 0)
            {
                Lbl_X_Email.IsEnabled = true;
                Lbl_X_Email.IsVisible = true;
            }
            else
            {
                Lbl_X_Email.IsEnabled = false;
                Lbl_X_Email.IsVisible = false;
            }
        }
        private void EntrySenha_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Senha_Usuario.Text))
            {
                Lbl_X_Senha.IsEnabled = false;
                Lbl_X_Senha.IsVisible = false;
                return;
            }
            if (ent_Senha_Usuario.Text.Length > 0)
            {
                Lbl_X_Senha.IsEnabled = true;
                Lbl_X_Senha.IsVisible = true;
            }
            else
            {
                Lbl_X_Senha.IsEnabled = false;
                Lbl_X_Senha.IsVisible = false;
            }
        }
        private void EntryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            Lbl_X_Email.IsEnabled = false;
            Lbl_X_Email.IsVisible = false;
        }
        private void EntrySenha_Unfocused(object sender, FocusEventArgs e)
        {
            Lbl_X_Senha.IsEnabled = false;
            Lbl_X_Senha.IsVisible = false;
        }
        private void lbl_LembrarSenha_Tapped(object sender, EventArgs e)
        {
            cbx_LembrarSenha.IsChecked = !cbx_LembrarSenha.IsChecked;
        }
        private bool IsValidPassword(string password)
        {
            bool _Maiusculo = false;
            bool _Especial = false;

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            if (password.Length < 8)
            {
                return false;
            }
            if (Regex.IsMatch(password, "@#!%&=") == true)
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
        private bool IsValidEmail(string email)
        {
            bool IsValid;
            IsValid = Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(50));
            return IsValid;
        }
    }
}
