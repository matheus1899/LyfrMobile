using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

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
                gerarToken.ChecharCache();
            } catch(Exception ex)
            {
                DisplayAlert("Aviso","Seguinte erro ocorreu -> "+ex.Message,"OK");
            }
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        private void ChamarPagCadastrar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastrar());
        }

        private async void Logar_Clicked(object sender, EventArgs e)
        {
            gerarToken.ChecharCache();

            Cliente cliente = new Cliente()
            {
                Email = ent_Email_Usuario.Text,
                Senha = ent_Senha_Usuario.Text
            };

            try
            {
                var select = await conexao.SelectOne(cliente, GerarToken.GetTokenFromCache());
                App.Current.MainPage = new MainPage(select);
            }
            catch (Exception ex)
            {
                MostrarMensagem.Mostrar(ex.Message);
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
            if (ent_Email_Usuario.Text.Length>0)
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
        private void NewFrame_Focused(object sender, FocusEventArgs e)
        {

        }
        private void lbl_LembrarSenha_Tapped(object sender, EventArgs e)
        {
            cbx_LembrarSenha.IsChecked = !cbx_LembrarSenha.IsChecked;
        }
    }
}
