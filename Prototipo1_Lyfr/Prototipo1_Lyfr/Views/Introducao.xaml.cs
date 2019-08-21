using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Introducao : ContentPage
    {
        List<Models.Livro> lista = new List<Models.Livro>();
        public Introducao()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            lista.Add(new Models.Livro { Nome = "bfhadbahbfj" });
            lista.Add(new Models.Livro { Nome = "bfhadbahbfjhadbfjk" });
            lista.Add(new Models.Livro { Nome = "bfhadbahbfjhadbhbfdajk" });
            Carousel.ItemsSource = lista;
           
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