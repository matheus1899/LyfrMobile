using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterarEmail : ContentPage
    {
        public AlterarEmail(Cliente c)
        {
            InitializeComponent();
            var b = BindingContext as AlterarEmailViewModel;
            b.cliente = c;
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