using Prototipo1_Lyfr.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage(Cliente cliente)
        {
            InitializeComponent();
            Detail = new Home();
        }

        private void Home_Tapped(object sender, EventArgs e)
        {
            Detail = new Home();
        }

        private void Historico_Tapped(object sender, EventArgs e)
        {
            Detail = new Historico();
        }
    }
}