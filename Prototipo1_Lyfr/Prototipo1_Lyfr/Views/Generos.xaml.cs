using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.Conexao;
using System;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Generos : ContentPage
    {
        Lazy<ConexaoAPI> con = new Lazy<ConexaoAPI>();
        public Generos()
        {
            InitializeComponent();
            SetList();
        }
        private async void SetList()
        {

            //lista.ItemsSource = await con.Value.GetAllGeneros(GerarToken.GetTokenFromCache());
        }
    }
}