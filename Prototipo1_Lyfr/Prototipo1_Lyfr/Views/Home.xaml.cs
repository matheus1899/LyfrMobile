using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.ViewModels;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private Cliente _cliente;
        private HomeViewModel bind;
        public Home(Cliente c)
        {
            InitializeComponent();
            sb_home.TranslateTo(0, -60, 100, Easing.Linear);
            bind = this.BindingContext as HomeViewModel;
            bind.Cliente = c;
            bind.SetList();
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
            bind.SetAllListSelectedItems();
        }
        double height = 0;
        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY == 0)
            {
                sb_home.TranslateTo(0, -60, 500, Easing.Linear);
            }
            else if (height > e.ScrollY)
            {
                sb_home.TranslateTo(0, 0, 450, Easing.Linear);
            }
            else
            {
                sb_home.TranslateTo(0, -60, 450, Easing.Linear);
            }
            height = e.ScrollY;
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private async void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            var search = sender as SearchBar;
            search.Unfocus();
            await Task.Delay(100);
            await Navigation.PushAsync(new ListaPesquisa(_cliente));

            //list.IsVisible = true;
            //await list.ScaleTo(1, 350, Easing.Linear);
        }
        private async void SearchBar_Unfocused(object sender, FocusEventArgs e)
        {
            //await list.ScaleTo(0, 340, Easing.Linear);
            //await Task.Run(async () => {
            //    await list.ScaleTo(0, 380, Easing.Linear);
            //});
            //list.IsVisible = false;
        }
    }
}