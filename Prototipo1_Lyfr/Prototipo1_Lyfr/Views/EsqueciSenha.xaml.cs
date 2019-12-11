using Prototipo1_Lyfr.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.Conexao;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EsqueciSenha : ContentPage
    {
        //bool Codigo_Enviado = false;
        public EsqueciSenha()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Stack_Codigo_Verificacao.FadeTo(0, 1, Easing.Linear);
            Stack_Codigo_Verificacao.IsVisible = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
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
        protected override bool OnBackButtonPressed()
        {
            //Navigation.PopAsync();
            return base.OnBackButtonPressed();
        }
    }
}