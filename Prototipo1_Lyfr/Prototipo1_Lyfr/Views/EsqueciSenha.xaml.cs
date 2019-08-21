using Android.Util;
using Prototipo1_Lyfr.Controls;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                Log.WriteLine(LogPriority.Error, "ERRO -> ", e.Message.ToString());
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
        private void BtnEnviaCodigo_Clicked(object sender, EventArgs e)
        {
            //if (Codigo_Enviado==false)
            //{
            //    await Frame_Ent_Email.FadeTo(0,200,Easing.Linear);
            //    Frame_Ent_Email.IsVisible = false;
            //    Lbl_DigiteEmail.TextColor = Color.FromHex("#EEDBAA");
            //    BtnEnviaCodigo.Text = "confirmar código de verificação";
            //    Lbl_SubHeaderFrame.Text = "Insira o código de verificação";
            //    await Stack_Codigo_Verificacao.FadeTo(0, 0, Easing.Linear);
            //    Stack_Codigo_Verificacao.IsVisible = true;
            //    await Stack_Codigo_Verificacao.FadeTo(1,500,Easing.Linear);
            //    Codigo_Enviado = true;
            //}
            //else
            //{
            //    Lbl_Tempo.TextColor = Color.FromHex("#436477");
            //    btn_ReenviaCodigo.IsVisible = true;
            //}
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