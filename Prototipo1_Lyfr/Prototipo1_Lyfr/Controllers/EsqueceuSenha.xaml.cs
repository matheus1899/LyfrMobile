using Android.Util;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EsqueceuSenha : ContentPage
    {
        public EsqueceuSenha()
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
        private async void BtnEnviaCodigo_Clicked(object sender, EventArgs e)
        {
            await Frame_Ent_Email.FadeTo(0,200,Easing.Linear);
            Frame_Ent_Email.IsVisible = true;
            await Stack_Codigo_Verificacao.FadeTo(0, 0, Easing.Linear);
            Stack_Codigo_Verificacao.IsVisible = true;
            await Stack_Codigo_Verificacao.FadeTo(1,500,Easing.Linear);
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return base.OnBackButtonPressed();
        }
    }
}