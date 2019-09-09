using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var livro_Selecionado = e.CurrentSelection.FirstOrDefault() as Models.Livro;
            }
            catch (Exception exception)
            {
                await DisplayAlert("Aviso", "-> " + exception.Message, "OK");
                return;
            }
        }
        private async void CollectionView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var livro_Selecionado = e.CurrentSelection.FirstOrDefault() as Models.Livro;
            }
            catch (Exception exception)
            {
                await DisplayAlert("Aviso", "-> " + exception.Message, "OK");
                return;
            }

        }
    }
}