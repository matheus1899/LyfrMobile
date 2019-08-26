using Prototipo1_Lyfr.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Introducao : ContentPage
    {
        List<View> lista = new List<View>();

        public Introducao()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var a = new TesteView();
            a.BackgroundColor =  Color.Red;
            var b = new TesteView();
            b.BackgroundColor = Color.Yellow;
            var c = new TesteView();
            c.BackgroundColor = Color.RoyalBlue;


        }
        private void ChamarPagCadastrar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastrar());
        }
        private void ChamarPagLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}