using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.ViewModels;
using Prototipo1_Lyfr.Models;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Generos : ContentPage
    {
        private GenerosViewModel bind;
        public Generos(Cliente cliente)
        {
            InitializeComponent();
            bind = this.BindingContext as GenerosViewModel;
            bind.Cliente = cliente;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            bind.SetSelectedItemToNull();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            bind.SetSelectedItemToNull();
        }
    }
}