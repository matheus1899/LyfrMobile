using System;
using Xamarin.Forms;
using Prototipo1_Lyfr.Models;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.ViewModels;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterarSenha : ContentPage
    {
        public AlterarSenha(object o)
        {
            InitializeComponent();
            var c = BindingContext as AlterarSenhaViewModel;
            c.OldCliente = o as Cliente;
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
            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            if (string.IsNullOrEmpty(e.NewTextValue) || string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                c.IsEnabled = false;
                c.IsVisible = false;
                return;
            }
            if (e.NewTextValue.Length > 0)
            {
                c.IsEnabled = true;
                c.IsVisible = true;
            }
        }
    }
}