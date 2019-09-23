using System;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.Models;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Children.Add(new Views.Downloads());
            this.Children.Add(new Views.Home());
            this.Children.Add(new Views.Perfil());
        }
        public MainPage(Cliente cliente)
        {
            InitializeComponent();
            this.Children.Add(new Views.Downloads());
            this.Children.Add(new Views.Home());
            this.Children.Add(new Views.Perfil(cliente));
            CurrentPage = this.Children[1];
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            NavigationPage.SetHasNavigationBar(this, false);
            Debug.WriteLine(CurrentPage.GetType().Name);
            //if (CurrentPage.GetType().Name == "Home")
            //{
            //    NavigationPage.SetHasBackButton(this, false);
            //    NavigationPage.SetHasNavigationBar(this, true);
            //    search_bar.IsVisible = true;
            //}
            //else
            //{
            //    NavigationPage.SetHasNavigationBar(this, false);
            //}
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}