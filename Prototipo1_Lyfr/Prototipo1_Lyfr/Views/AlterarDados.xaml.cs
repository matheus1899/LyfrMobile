using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterarDados : ContentPage
    {

        private bool ModificarEmail = false;
        private bool ModificarSenha = false;
        private bool ModificarTelefone = false;
        private bool ModificarEndereco = false;
        private bool ModificarPlano = false;

        public AlterarDados(string propriedade)
        {
            InitializeComponent();
            if (propriedade == "Email")
            {
                Stack_Email.IsVisible = true;
                ModificarEmail = true;
            }else if (propriedade == "Senha")
            {
                Stack_Senha.IsVisible = true;
                ModificarSenha = true;
            }else if (propriedade == "Telefone")
            {
                Stack_Telefone.IsVisible = true;
                ModificarTelefone = true;
            }
            else
            {
                Stack_Endereco.IsVisible = true;
                ModificarEndereco = true;
            }
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
        private async void Esconde_Exibe_Senha_Clicked(object sender, EventArgs e)
        {
            var a = sender as ImageButton;
            await a.ScaleTo(1.3, 100, Easing.SpringIn);
            var pai = a.Parent as StackLayout;
            var ent = pai.Children[0] as Entry;
            ent.IsPassword = !ent.IsPassword;
            await a.ScaleTo(1, 100, Easing.BounceIn);
        }

        private void btn_Alterar_Clicked(object sender, EventArgs e)
        {
            return;
            if (ModificarEmail)
            {
                //valida...
            }else if (ModificarSenha)
            {
                //valida...
            }else if (ModificarTelefone)
            {
                //valida...
            }else if (ModificarEndereco)
            {
                //valida...
            }
            else
            {
                return;
            }
        }
        private void Senha_Ent_Unfocused(object sender, FocusEventArgs e)
        {
            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            c.IsEnabled = false;
            c.IsVisible = false;
        }

        private void Senha_Ent_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}