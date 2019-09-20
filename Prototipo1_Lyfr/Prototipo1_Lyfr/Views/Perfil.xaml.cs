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
                act_ind_Sugestao.IsVisible = true;
                act_ind_Sugestao.IsRunning = true;

                gerarToken.ChecarCache();

                var result = await conexao.SendSugestao(sugestao, GerarToken.GetTokenFromCache());
                MostrarMensagem.Mostrar(result);

                act_ind_Sugestao.IsVisible = false;
                act_ind_Sugestao.IsRunning = false;
            }

            catch (Exception ex)
            {
                MostrarMensagem.Mostrar(ex.Message);
            }
        }
        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            MudarEstadoImagem();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MudarEstadoImagem();
        }
        private void MudarEstadoImagem()
        {
            if (Width > Height)
            {
                VisualStateManager.GoToState(img_lidos, "Landscape");
                VisualStateManager.GoToState(img_plan, "Landscape");
                bxv1.IsVisible = false;
                bxv2.IsVisible = false;
            }
            else
            {
                VisualStateManager.GoToState(img_lidos, "Portrait");
                VisualStateManager.GoToState(img_plan, "Portrait");
                bxv1.IsVisible = true;
                bxv2.IsVisible = true;
            }
        }
    }
}