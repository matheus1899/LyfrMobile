using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        Cliente _cliente;

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
        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            //MudarEstadoImagem();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //MudarEstadoImagem();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SetIsEnabled(tableview_Main, true);
        }
        //private void MudarEstadoImagem()
        //{
        //    if (Width > Height)
        //    {
        //        VisualStateManager.GoToState(img_lidos, "Landscape");
        //        VisualStateManager.GoToState(img_plan, "Landscape");
        //        bxv1.IsVisible = false;
        //        bxv2.IsVisible = false;
        //    }
        //    else
        //    {
        //        VisualStateManager.GoToState(img_lidos, "Portrait");
        //        VisualStateManager.GoToState(img_plan, "Portrait");
        //        bxv1.IsVisible = true;
        //        bxv2.IsVisible = true;
        //    }
        //}
        private void GoTo_AlterEmail(object sender, EventArgs e)
        {
            SetIsEnabled(tableview_Main, false);
            Navigation.PushAsync(new AlterarDados("Email", _cliente));
        }
        private void GoTo_AlterSenha(object sender, EventArgs e)
        {
            SetIsEnabled(tableview_Main, false);
            Navigation.PushAsync(new AlterarDados("Senha", _cliente));
        }
        private void GoTo_AlterTelefone(object sender, EventArgs e)
        {
            SetIsEnabled(tableview_Main, false);
            Navigation.PushAsync(new AlterarDados("Telefone", _cliente));
        }
        private void GoTo_AlterEndereco(object sender, EventArgs e)
        {
            SetIsEnabled(tableview_Main, false);
             Navigation.PushAsync(new AlterarDados("Endereco", _cliente));
        }
        private void SetIsEnabled(View v, bool b)
        {
            v.IsEnabled = b;
        }
    }
}