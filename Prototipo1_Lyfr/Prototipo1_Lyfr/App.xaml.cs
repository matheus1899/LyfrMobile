using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Microsoft.AppCenter;
//using Microsoft.AppCenter.Analytics;
//using Microsoft.AppCenter.Crashes;
using Prototipo1_Lyfr.Conexao;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Prototipo1_Lyfr
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            HotReloader.Current.Run(this);

            MainPage = new NavigationPage(new Views.Introducao());
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
