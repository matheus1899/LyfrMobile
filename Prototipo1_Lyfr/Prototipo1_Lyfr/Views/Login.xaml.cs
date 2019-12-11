using System;
using Xamarin.Forms;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using System.Text.RegularExpressions;
using Prototipo1_Lyfr.Models.LocalDBModels;

namespace Prototipo1_Lyfr.Views
{
    public partial class Login : ContentPage
    {
        ConexaoAPI conexao = new ConexaoAPI();
        Cache cache = new Cache();

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
            return true;
        }
        private async void ChamarPagCadastrar(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new Cadastrar());
            }
            catch(Exception ex)
            {
                await Navigation.PushAsync(new Cadastrar());
            }
        }
        private async void Logar_Clicked(object sender, EventArgs e)
        { 
            try
            {
                SetActivityIndicatorState(true);
                HasNavigationBar.SetHasNavigationBar("");
                Cliente cliente = new Cliente()
                {
                    Email = ent_Email_Usuario.Text,
                    Senha = ent_Senha_Usuario.Text
                };
                var usuario = await conexao.SelectOne(cliente, GerarToken.GetTokenFromCache());
                SetActivityIndicatorState(false);
                if (cbx_LembrarSenha.IsChecked == true)
                {
                    cache.InserirClienteLocal(new ClienteLocal 
                    { 
                        Cpf = usuario.Cpf,
                        Nome = usuario.Nome, 
                        Email = usuario.Email,
                        Senha = usuario.Senha, 
                        IdCliente = usuario.IdCliente,
                        Data_Cadastro = usuario.Data_Cadastro
                    });
                    App.Current.MainPage = new NavigationPage(new MainPage(usuario));
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new MainPage(usuario));
                }
            }
            catch (TimeoutException ex)
            {
                btn_Login.IsEnabled = true;
                MostrarMensagem.Mostrar("Não é possivel se comunicar com a base de dados!");
                return;
            }
            catch (Exception ex)
            {
                SetActivityIndicatorState(false);
                System.Diagnostics.Debug.WriteLine(ex.Message +" - "+ex.InnerException);
                MostrarMensagem.Mostrar(ex.Message);
                return;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            btn_Login.IsEnabled = true;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            btn_Login.IsEnabled = false;
        }

        private void SetActivityIndicatorState(bool state)
        {
            act_ind_Login.IsVisible = state;
            act_ind_Login.IsRunning = state;
        }
        #region EntryActions
        private async void Esconde_Exibe_Senha_Clicked(object sender, EventArgs e)
        {
            var a = sender as ImageButton;
            await a.ScaleTo(1.3, 100, Easing.SpringIn);
            ent_Senha_Usuario.IsPassword = !ent_Senha_Usuario.IsPassword;
            await a.ScaleTo(1, 100, Easing.BounceIn);
        }
        private async void Esqueceu_Senha_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EsqueciSenha());
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
        private void Lbl_Apagar_Entry(object sender, EventArgs e)
        {
            var a = sender as Label;
            var pai = a.Parent as StackLayout;
            var ent = pai.Children[0] as Entry;
            ent.Text = string.Empty;
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
        #endregion
        private void lbl_LembrarSenha_Tapped(object sender, EventArgs e)
        {
            //cbx_LembrarSenha.IsChecked = !cbx_LembrarSenha.IsChecked;
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
            if (Regex.IsMatch(password, @"@#!%&=") == true)
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
