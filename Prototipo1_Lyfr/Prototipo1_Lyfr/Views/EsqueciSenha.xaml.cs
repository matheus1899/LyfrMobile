
using Prototipo1_Lyfr.Controls;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.Conexao.Classes;
using Prototipo1_Lyfr.Conexao;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EsqueciSenha : ContentPage
    {

        public bool Codigo_Enviado = false;
        public EsqueciSenha()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                //Log.WriteLine(LogPriority.Error, "ERRO -> ", e.Message.ToString());
            }
        }
        private void Lbl_Apagar_Entry_Email(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Email_Usuario.Text) || string.IsNullOrWhiteSpace(ent_Email_Usuario.Text))
            {
                return;
            }
            else
            {
                ent_Email_Usuario.Text = string.Empty;
            }
        }
        private void EntryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            Lbl_X_Email.IsEnabled = false;
            Lbl_X_Email.IsVisible = false;
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
        private void EntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Email_Usuario.Text) || string.IsNullOrWhiteSpace(ent_Email_Usuario.Text))
            {
                Lbl_X_Email.IsEnabled = false;
                Lbl_X_Email.IsVisible = false;
            }else
            {
                Lbl_X_Email.IsEnabled = true;
                Lbl_X_Email.IsVisible = true;
            }
        }

        private async void BtnEnviaCodigo_Clicked(object sender, EventArgs e)
        {
            try
            {
                Conexao.Classes.ConexaoAPI conexao = new Conexao.Classes.ConexaoAPI();
                GerarToken gerarToken = new GerarToken();

                gerarToken.ChecharCache();
                var result = await conexao.EnviarEmail(ent_Email_Usuario.Text, GerarToken.GetTokenFromCache());
                MostrarMensagem.Mostrar(result);
            }
            catch (Exception ex)
            {
                MostrarMensagem.Mostrar(ex.Message);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return base.OnBackButtonPressed();
        }
        private void Ent_Codigo1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length>0)
            {
                ent_Codigo2.Focus();
            }
            else
            {
                ent_Codigo1.Unfocus();
            }
        }
        private void Ent_Codigo2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                ent_Codigo3.Focus();
            }
            else
            {
                ent_Codigo1.Focus();
            }
        }
        private void Ent_Codigo3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                ent_Codigo4.Focus();
            }
            else
            {
                ent_Codigo2.Focus();
            }
        }
        private void Ent_Codigo4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                ent_Codigo5.Focus();
            }
            else
            {
                ent_Codigo3.Focus();
            }
        }
        private void Ent_Codigo5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                ent_Codigo5.Unfocus();
            }
            else
            {
                ent_Codigo4.Focus();
            }
        }
    }
}