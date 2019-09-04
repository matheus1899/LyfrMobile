using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.Models;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Introducao : ContentPage
    {
        List<Texto> lista = new List<Texto>();
        public Introducao()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            lista.Add(new Texto { TextoIntro = "Bem vindo ao seu aplicativo de leitura" });
            lista.Add(new Texto { TextoIntro = "Lyfr tem um acervo contendo cerca de \n500 livros e aumentando..." });
            lista.Add(new Texto { TextoIntro = "Aproveite o seu livro, quando e \nonde quiser, gratuitamente" });
            Carousel.ItemsSource = lista;
        }
        protected override void OnDisappearing()
        {
            btn_Cadastrar.IsEnabled = true;
            btn_Entrar.IsEnabled = true;
            base.OnDisappearing();
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        private void ChamarPagCadastrar(object sender, EventArgs e){
            btn_Cadastrar.IsEnabled = false;
            btn_Entrar.IsEnabled = false;
            App.Current.MainPage = new Cadastrar();
        }
        private void ChamarPagLogin(object sender, EventArgs e){
            btn_Cadastrar.IsEnabled = false;
            btn_Entrar.IsEnabled = false;
            Navigation.PushAsync(new Login());
        }
        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > this.Height)
            {
                VisualStateManager.GoToState(stc_Buttons, "Landscape");
            }
            else
            {
                VisualStateManager.GoToState(stc_Buttons, "Portrait");
            }
        }
    }
}