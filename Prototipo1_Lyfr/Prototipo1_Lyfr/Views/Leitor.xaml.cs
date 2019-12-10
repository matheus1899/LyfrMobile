using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.ViewModels.Services;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Leitor : ContentPage
    {
        HtmlWebViewSource _html;
        public Leitor(HtmlWebViewSource html)
        {
            InitializeComponent();
            this._html = html;
            web.Source = _html;
        }
        private void ToolbarClose_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<INavigationService>().GoBack();
        }
    }
}