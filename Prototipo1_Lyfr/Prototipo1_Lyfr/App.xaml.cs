using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Microsoft.AppCenter;
//using Microsoft.AppCenter.Analytics;
//using Microsoft.AppCenter.Crashes;
using System.Diagnostics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Prototipo1_Lyfr
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();
                //MainPage = new NavigationPage(new Views.Introducao());
                MainPage = new NavigationPage(new Views.MainPage());
                //MainPage = new Views.MainPage();
                //MainPage = new Views.InfoLivro();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("AVISO -> " + ex.Message);
            }
        }
        protected override void OnStart()
        {
            //AppCenter.Start("android=5af831f0-b735-4a30-a1ff-a33d62146c66;", typeof(Analytics), typeof(Crashes));
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {

        }
    }
}
