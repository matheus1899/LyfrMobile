using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Introducao : ContentPage
    {
        public Introducao()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            SetVisualStateStackCard();
        }
        protected override void OnDisappearing()
        {
            btn_Cadastrar.IsEnabled = true;
            btn_Entrar.IsEnabled = true;
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        private void ChamarPagCadastrar(object sender, EventArgs e){
            btn_Cadastrar.IsEnabled = false;
            btn_Entrar.IsEnabled = false;
            App.Current.MainPage = new NavigationPage(new Cadastrar());
        }
        private void ChamarPagLogin(object sender, EventArgs e){
            btn_Cadastrar.IsEnabled = false;
            btn_Entrar.IsEnabled = false;
            App.Current.MainPage = new NavigationPage(new Login());
        }
        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            SetVisualStateStackCard();
        }
        private void SetVisualStateStackCard()
        {
            return;
        }
    }
}