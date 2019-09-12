using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Conexao.Classes;
using Prototipo1_Lyfr.Controls;
namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastrar : ContentPage
    {
        private bool pago = false;
        string plano;

        public Cadastrar()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Grid_.Children[5].TranslationX = 1700;
            Grid_.Children[6].TranslationX = 1700;
            Grid_.Children[7].TranslationX = 1700;
            Grid_.Children[8].TranslationX = 1700;
            Grid_.Children[9].TranslationX = 1700;
            Grid_.Children[10].TranslationX = 1700;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        protected override bool OnBackButtonPressed(){
            BackToLogin();
            return true;
        }

        private void BackToLogin()
        {
            App.Current.MainPage = new Login();
        }

        private async void btn_gratis_Clicked(object sender, EventArgs e)
        {
            pago = false;
            plano = "G";

            if (pago == false)
            {
                btn_gratis.IsEnabled = false;
                btn_pago.IsEnabled = false;
                btn_Cadastrar.IsEnabled = false;
                btn_pago.Style = this.Resources["Style_Button_Desativo"] as Style;
                btn_gratis.Style = this.Resources["Style_Button_Ativo"] as Style;
                //Task.Run(async () => {
                await Stack_Ent_CPF.TranslateTo(1700, 0, 150, Easing.Linear);
                await Stack_Ent_CEP.TranslateTo(1700, 0, 150, Easing.Linear);
                await Stack_Ent_Tele.TranslateTo(1700, 0, 150, Easing.Linear);
                await Stack_Ent_DataNasc.TranslateTo(1700, 0, 150, Easing.Linear);
                await Stack_Ent_Rua_Numero.TranslateTo(1700, 0, 150, Easing.Linear);
                await Stack_Ent_Cidade_Estado.TranslateTo(1700, 0, 150, Easing.Linear);
                //});
                Stack_Ent_CPF.IsVisible = false;
                Stack_Ent_CEP.IsVisible = false;
                Stack_Ent_Tele.IsVisible = false;
                Stack_Ent_DataNasc.IsVisible = false;
                Stack_Ent_Rua_Numero.IsVisible = false;
                Stack_Ent_Cidade_Estado.IsVisible = false;
                btn_gratis.IsEnabled = true;
                btn_pago.IsEnabled = true;
                btn_Cadastrar.IsEnabled = true;
            }


        }
        private void btn_pago_Clicked(object sender, EventArgs e)
        {
            pago = true;
            plano = "P";

            if (pago == true)
            {
                btn_gratis.IsEnabled = false;
                btn_pago.IsEnabled = false;
                btn_Cadastrar.IsEnabled = false;
                btn_pago.Style = this.Resources["Style_Button_Ativo"] as Style;
                btn_gratis.Style = this.Resources["Style_Button_Desativo"] as Style;
                Stack_Ent_CPF.IsVisible = true;
                Stack_Ent_CEP.IsVisible = true;
                Stack_Ent_Tele.IsVisible = true;
                Stack_Ent_DataNasc.IsVisible = true;
                Stack_Ent_Rua_Numero.IsVisible = true;
                Stack_Ent_Cidade_Estado.IsVisible = true;

                Task.Run(async () =>
                {
                    await Stack_Ent_CPF.TranslateTo(0, 0, 150, Easing.Linear);
                    await Stack_Ent_CEP.TranslateTo(0, 0, 150, Easing.Linear);
                    await Stack_Ent_Tele.TranslateTo(0, 0, 150, Easing.Linear);
                    await Stack_Ent_DataNasc.TranslateTo(0, 0, 150, Easing.Linear);
                    await Stack_Ent_Rua_Numero.TranslateTo(0, 0, 150, Easing.Linear);
                    await Stack_Ent_Cidade_Estado.TranslateTo(0, 0, 150, Easing.Linear);
                });
                btn_gratis.IsEnabled = true;
                btn_pago.IsEnabled = true;
                btn_Cadastrar.IsEnabled = true;
            }
        }

        private async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Nome_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Prencha o campo do nome!");
            }
            else if (string.IsNullOrEmpty(ent_Email_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Preencha o campo do e-mail!");
            }
            else if (string.IsNullOrEmpty(ent_Senha_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Preencha o campo da senha!");
            }
            else if (string.IsNullOrEmpty(ent_CPF_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Preencha o campo do CPF!");
            }
            else if (string.IsNullOrEmpty(ent_CEP_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Preencha o campo do CEP!");
            }
            else if (string.IsNullOrEmpty(ent_Telefone_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Preencha o campo do telefone!");
            }
            else if (string.IsNullOrEmpty(ent_Rua_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Preencha o campo da rua!");
            }
            else if (string.IsNullOrEmpty(ent_Numero_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Preencha o campo do número!");
            }
            else if (string.IsNullOrEmpty(ent_Cidade_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Preencha o campo da cidade!");
            }
            else if (string.IsNullOrEmpty(ent_Estado_Usuario.Text))
            {
                MostrarMensagem.Mostrar("Preencha o campo do estado!");
            }
            else
            {
                ai.IsVisible = true;
                ai.IsRunning = true;

                Cliente cliente = new Cliente()
                {
                    Nome = ent_Nome_Usuario.Text.Trim(),
                    Email = ent_Email_Usuario.Text.Trim(),
                    Senha = ent_Senha_Usuario.Text.Trim(),
                    Cep = ent_CEP_Usuario.Text,
                    Rua = ent_Rua_Usuario.Text.Trim(),
                    Numero = ent_Numero_Usuario.Text.Trim(),
                    Cidade = ent_Cidade_Usuario.Text.Trim(),
                    Estado = ent_Estado_Usuario.Text,
                    Telefone = ent_Telefone_Usuario.Text,
                    Cpf = ent_CPF_Usuario.Text,
                    DataNasc = DataPicker_Nascimento.Date.ToString("MM/dd/yyyy"),
                    Data_Cadastro = DateTime.Now.ToString(),
                    Plano = plano
                };

                var conexao = new Conexao.Classes.ConexaoAPI();
                GerarToken gerarToken = new GerarToken();

                try
                {
                    gerarToken.ChecarCache();

                    var result = await conexao.Add(cliente, GerarToken.GetTokenFromCache());
                    MostrarMensagem.Mostrar(result);

                    ai.IsVisible = false;
                    ai.IsRunning = false;
                }
                catch (Exception ex)
                {
                    MostrarMensagem.Mostrar(ex.Message);
                }
            }
        }
        private async void Esconde_Exibe_Senha_Clicked(object sender, EventArgs e)
        {
            ent_Senha_Usuario.IsPassword = !ent_Senha_Usuario.IsPassword;
            await btn_Img_Eye.ScaleTo(1.3, 100, Easing.SpringIn);
            await btn_Img_Eye.ScaleTo(1, 100, Easing.BounceIn);
        }

        private void Lbl_Apagar_Entry(object sender, EventArgs e)
        {
            var a = sender as Label;
            var pai = a.Parent as StackLayout;
            var ent = pai.Children[0] as Entry;
            ent.Text = string.Empty;
        }
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ent = sender as Entry;
            var stc = ent.Parent as StackLayout;
            var lbl = stc.Children[1] as Label;

            int lenght = ent.Text.Length;
            if (lenght > 0)
            {
                lbl.IsEnabled = true;
                lbl.IsVisible = true;
            }
            else
            {
                lbl.IsEnabled = false;
                lbl.IsVisible = false;
            }
        }
        private void Entry_Focused(object sender, FocusEventArgs e)
        {

            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            if (string.IsNullOrEmpty(a.Text))
            {
                c.IsEnabled = false;
                c.IsVisible = false;
                return;
            }
            if (a.Text.Length > 0)
            {
                c.IsEnabled = true;
                c.IsVisible = true;
            }
            else
            {
                c.IsEnabled = false;
                c.IsVisible = false;
            }
        }
        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            c.IsEnabled = false;
            c.IsVisible = false;
        }

        private void Senha_Ent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ent = sender as Entry;
            var stc = ent.Parent as StackLayout;
            var lbl = stc.Children[1] as Label;

            int lenght = ent.Text.Length;
            if (lenght > 0)
            {
                lbl.IsEnabled = true;
                lbl.IsVisible = true;
                lbl_aviso.IsVisible = true;
            }
            else
            {
                lbl.IsEnabled = false;
                lbl.IsVisible = false;
            }


            
        }
        private void Senha_Ent_Unfocused(object sender, FocusEventArgs e)
        {
            lbl_aviso.IsVisible = false;
            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            c.IsEnabled = false;
            c.IsVisible = false;
        }

        private bool IsValidPassword(string password)
        {
            bool _Maiusculo = false;
            bool _Especial = false;

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (password.Length<8)
            {
                return false;
            }
            if (Regex.IsMatch(password, "@#!%&=")==true)
            {
                _Especial = true;
            }
            if (Regex.IsMatch(password, @"\b[A-Z]\w*\b") == true)
            {
                _Maiusculo = true;
            }

            if (_Maiusculo == true && _Especial == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}