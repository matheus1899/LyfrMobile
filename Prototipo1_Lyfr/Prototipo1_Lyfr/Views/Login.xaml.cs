﻿using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System;
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
            }

            catch (Exception ex)
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
            App.Current.MainPage = new Cadastrar();
        }

        private async void Logar_Clicked(object sender, EventArgs e)
        { 
            try
            {
                gerarToken.ChecharCache();

                if(string.IsNullOrWhiteSpace(ent_Email_Usuario.Text))
                {
                    MostrarMensagem.Mostrar("Preencha o campo do e-mail!");
                }
                else if (string.IsNullOrWhiteSpace(ent_Senha_Usuario.Text))
                {
                    MostrarMensagem.Mostrar("Preencha o campo da senha!");
                }
                else
                {
                    Cliente cliente = new Cliente()
                    {
                        Email = ent_Email_Usuario.Text,
                        Senha = ent_Senha_Usuario.Text
                    };

                    var select = await conexao.SelectOne(cliente, GerarToken.GetTokenFromCache());
                    App.Current.MainPage = new MainPage(select);               
                }
            }

            catch (Exception ex)
            {
                MostrarMensagem.Mostrar(ex.Message);
            }
            
        }
        private void Esconde_Exibe_Senha_Clicked(object sender, EventArgs e) 
        {
            ent_Senha_Usuario.IsPassword = !ent_Senha_Usuario.IsPassword;
        }
        private void Esqueceu_Senha_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new EsqueciSenha();
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
    }
}
