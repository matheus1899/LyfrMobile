using System;
using System.Diagnostics;
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
        double height = 0;
        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (height > e.ScrollY)
            {
                //search_bar.IsVisible = true;
                search_bar.TranslateTo(0,0,250,Easing.Linear);
            }
            else
            {

                search_bar.TranslateTo(0,-50,250,Easing.Linear);
                //search_bar.IsVisible = false;
                
            }
            Debug.WriteLine("SearchY -> "+ search_bar.Y);
            height = e.ScrollY;
        }
    }
}