using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        Cliente _cliente;
        Conexao.Classes.ConexaoAPI conexao = new Conexao.Classes.ConexaoAPI();
        GerarToken gerarToken = new GerarToken();

        public Perfil()
        {
            InitializeComponent();
        }

        public Perfil(Cliente cliente)
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.PerfilViewModel(cliente);
            _cliente = cliente;
        }


        private async void EnviarSugestao_Clicked(object sender, System.EventArgs e)
        {
            Sugestao sugestao = new Sugestao()
            {
                FkIdCliente = _cliente.IdCliente,
                Atendido = char.Parse("N"),
                Mensagem = mensagem.Text
            };

            try
            {
                gerarToken.ChecarCache();

                var result = await conexao.SendSugestao(sugestao, GerarToken.GetTokenFromCache());
                MostrarMensagem.Mostrar(result);
            }

            catch (Exception ex)
            {
                MostrarMensagem.Mostrar(ex.Message);
            }
        }
    }
}