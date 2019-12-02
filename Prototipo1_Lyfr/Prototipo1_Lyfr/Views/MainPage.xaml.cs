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
        public MainPage(Cliente cliente)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Children.Add(new Generos(cliente));
            this.Children.Add(new Home(cliente));
            this.Children.Add(new Perfil(cliente));
            CurrentPage = this.Children[1];
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            NavigationPage.SetHasNavigationBar(this, false);
            Debug.WriteLine(CurrentPage.GetType().Name);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}