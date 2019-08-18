using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastrar : ContentPage
    {
        private bool pago = false;
        private bool gratis = true;
        public Cadastrar(){
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override bool OnBackButtonPressed(){
            return true;
        }

        private async void btn_gratis_Clicked(object sender, EventArgs e)
        {
            btn_gratis.IsEnabled = false;
            btn_pago.IsEnabled = false;
            btn_Cadastrar.IsEnabled = false;
            pago = !pago;
            gratis = !gratis;
            btn_gratis.Style = Application.Current.Resources["Style_Button_Ativo"] as Style;
            btn_pago.Style = Application.Current.Resources["Style_Button_Desativo"] as Style;
            await Stack_Ent_CPF.TranslateTo(1500, 0, 450, Easing.Linear);
            Stack_Ent_CPF.IsVisible = false;
            await Stack_Ent_CEP.TranslateTo(1500, 0, 450, Easing.Linear);
            Stack_Ent_CEP.IsVisible = false;
            await Stack_Ent_Tele.TranslateTo(1500, 0, 450, Easing.Linear);
            Stack_Ent_Tele.IsVisible = false;
            await Stack_Ent_DataNasc.TranslateTo(1500, 0, 450, Easing.Linear);
            Stack_Ent_DataNasc.IsVisible = false;

            btn_gratis.IsEnabled = true;
            btn_pago.IsEnabled = true;
            btn_Cadastrar.IsEnabled = true;
        }
        private async void btn_pago_Clicked(object sender, EventArgs e)
        {
            btn_gratis.IsEnabled = false;
            btn_pago.IsEnabled = false;
            btn_Cadastrar.IsEnabled = false;

            pago = !pago;
            gratis = !gratis;
            btn_pago.Style = Application.Current.Resources["Style_Button_Ativo"] as Style;
            btn_gratis.Style = Application.Current.Resources["Style_Button_Desativo"] as Style;

            await Stack_Ent_CPF.TranslateTo(1500, 0,50, Easing.Linear);
            await Stack_Ent_CEP.TranslateTo(1500, 0, 50, Easing.Linear);
            await Stack_Ent_Tele.TranslateTo(1500, 0, 50, Easing.Linear);
            await Stack_Ent_DataNasc.TranslateTo(1500, 0, 50, Easing.Linear);

            Stack_Ent_CPF.IsVisible = true;
            await Stack_Ent_CPF.TranslateTo(0, 0, 500, Easing.Linear);
            Stack_Ent_CEP.IsVisible = true;
            await Stack_Ent_CEP.TranslateTo(0, 0, 500, Easing.Linear);
            Stack_Ent_Tele.IsVisible = true;
            await Stack_Ent_Tele.TranslateTo(0, 0, 500, Easing.Linear);
            Stack_Ent_DataNasc.IsVisible = true;
            await Stack_Ent_DataNasc.TranslateTo(0, 0, 500, Easing.Linear);

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
            await btn_Img_Eye.ScaleTo(1.2,100,Easing.SpringIn);
            await btn_Img_Eye.ScaleTo(1,100,Easing.BounceIn);
        }
        private void Lbl_Apagar_Entry_Nome(object sender, EventArgs e)
        {
            ent_Nome_Usuario.Text = string.Empty;
        }
        private void Lbl_Apagar_Entry_Senha(object sender, EventArgs e)
        {
            ent_Senha_Usuario.Text = string.Empty;
        }
        private void Lbl_Apagar_Entry_Email(object sender, EventArgs e)
        {
            ent_Email_Usuario.Text = string.Empty;
        }
        private void EntryNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = sender as Entry;
            int lenght = a.Text.Length;
            if (lenght>0){
                Lbl_X_Nome.IsEnabled = true;
                Lbl_X_Nome.IsVisible = true;
            }
            else{
                Lbl_X_Nome.IsEnabled = false;
                Lbl_X_Nome.IsVisible = false;
            }
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
        private void EntryNome_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Nome_Usuario.Text))
            {
                Lbl_X_Nome.IsEnabled = false;
                Lbl_X_Nome.IsVisible = false;
                return;
            }
            if (ent_Nome_Usuario.Text.Length > 0)
            {
                Lbl_X_Nome.IsEnabled = true;
                Lbl_X_Nome.IsVisible = true;
            }
            else
            {
                Lbl_X_Nome.IsEnabled = false;
                Lbl_X_Nome.IsVisible = false;
            }
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
        private void EntryNome_Unfocused(object sender, FocusEventArgs e)
        {
            Lbl_X_Nome.IsEnabled = false;
            Lbl_X_Nome.IsVisible = false;
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
        private void EntryCEP_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(ent_CEP_Usuario.Text))
            {
                Lbl_X_CEP.IsEnabled = false;
                Lbl_X_CEP.IsVisible = false;
                return;
            }
            if (ent_CEP_Usuario.Text.Length > 0)
            {
                Lbl_X_CEP.IsEnabled = true;
                Lbl_X_CEP.IsVisible = true;
            }
            else
            {
                Lbl_X_CEP.IsEnabled = false;
                Lbl_X_CEP.IsVisible = false;
            }
        }
        private void EntryCEP_Unfocused(object sender, FocusEventArgs e)
        {
            Lbl_X_CEP.IsEnabled = false;
            Lbl_X_CEP.IsVisible = false;
        }
        private void EntryCEP_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = sender as Entry;
            int lenght = a.Text.Length;
            if (lenght > 0)
            {
                Lbl_X_CEP.IsEnabled = true;
                Lbl_X_CEP.IsVisible = true;
            }
            else
            {
                Lbl_X_CEP.IsEnabled = false;
                Lbl_X_CEP.IsVisible = false;
            }
        }
        private void Lbl_Apagar_Entry_CEP(object sender, EventArgs e)
        {
            ent_CEP_Usuario.Text = string.Empty;
        }
        private void EntryTelefone_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Telefone_Usuario.Text))
            {
                Lbl_X_Telefone.IsEnabled = false;
                Lbl_X_Telefone.IsVisible = false;
                return;
            }
            if (ent_Telefone_Usuario.Text.Length > 0)
            {
                Lbl_X_Telefone.IsEnabled = true;
                Lbl_X_Telefone.IsVisible = true;
            }
            else
            {
                Lbl_X_Telefone.IsEnabled = false;
                Lbl_X_Telefone.IsVisible = false;
            }
        }
        private void EntryTelefone_Unfocused(object sender, FocusEventArgs e)
        {
            Lbl_X_Telefone.IsEnabled = false;
            Lbl_X_Telefone.IsVisible = false;
        }
        private void EntryTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = sender as Entry;
            int lenght = a.Text.Length;
            if (lenght > 0)
            {
                Lbl_X_Telefone.IsEnabled = true;
                Lbl_X_Telefone.IsVisible = true;
            }
            else
            {
                Lbl_X_Telefone.IsEnabled = false;
                Lbl_X_Telefone.IsVisible = false;
            }
        }
        private void Lbl_Apagar_Entry_Telefone(object sender, EventArgs e)
        {
            ent_Telefone_Usuario.Text = string.Empty;
        }
        private void EntryCPF_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(ent_CPF_Usuario.Text))
            {
                Lbl_X_CPF.IsEnabled = false;
                Lbl_X_CPF.IsVisible = false;
                return;
            }
            if (ent_CPF_Usuario.Text.Length > 0)
            {
                Lbl_X_CPF.IsEnabled = true;
                Lbl_X_CPF.IsVisible = true;
            }
            else
            {
                Lbl_X_CPF.IsEnabled = false;
                Lbl_X_CPF.IsVisible = false;
            }
        }
        private void EntryCPF_Unfocused(object sender, FocusEventArgs e)
        {
            Lbl_X_CPF.IsEnabled = false;
            Lbl_X_CPF.IsVisible = false;
        }
        private void EntryCPF_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = sender as Entry;
            int lenght = a.Text.Length;
            if (lenght > 0)
            {
                Lbl_X_CPF.IsEnabled = true;
                Lbl_X_CPF.IsVisible = true;
            }
            else
            {
                Lbl_X_CPF.IsEnabled = false;
                Lbl_X_CPF.IsVisible = false;
            }
        }
        private void Lbl_Apagar_Entry_CPF(object sender, EventArgs e)
        {
            ent_CPF_Usuario.Text = string.Empty;
        }
    }
}