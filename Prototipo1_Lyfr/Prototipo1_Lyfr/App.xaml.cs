using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Prototipo1_Lyfr
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            HotReloader.Current.Run(this);
            MainPage = new NavigationPage(new Introducao());

        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
