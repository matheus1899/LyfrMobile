using Prototipo1_Lyfr.Models;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(Cliente cliente)
        {
            InitializeComponent();
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}