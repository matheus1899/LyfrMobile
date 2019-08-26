using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastrar : ContentPage
    {
        private bool pago = false;
        char plano;
        double width;

        public Cadastrar(){
            InitializeComponent();
            width = this.Width;
            NavigationPage.SetHasNavigationBar(this, false);
            Grid_.Children[4].TranslationX = 1700;
            Grid_.Children[5].TranslationX = 1700;
            Grid_.Children[6].TranslationX = 1700;
            Grid_.Children[7].TranslationX = 1700;
            Grid_.Children[8].TranslationX = 1700;
            Grid_.Children[9].TranslationX = 1700;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var StateGroup = new VisualStateGroup
            {
                Name = "StateForcaSenha",
                TargetType = typeof(Label)
            };
            StateGroup.States.Add(CreateState("Invalido", "\uf023", Color.Red));
            StateGroup.States.Add(CreateState("Válido", "\uf023", Color.Green));

            VisualStateManager.SetVisualStateGroups(lbl_aviso, new VisualStateGroupList { StateGroup });
        }
        static VisualState CreateState(string nameState, string text, Color color)
        {
            var textSetter = new Setter {Value=text, Property=Label.TextProperty };
            var colorSetter = new Setter { Value = color, Property = Label.TextColorProperty };

            return new VisualState
            {
                Name = nameState,
                TargetType = typeof(Label),
                Setters = { textSetter, colorSetter }
            };
        }
        protected override bool OnBackButtonPressed(){
            Navigation.PushAsync(new Login());
            return true;
        }

        private async void btn_gratis_Clicked(object sender, EventArgs e)
        {
            pago = false;

            if (pago==false)
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

            if (pago==true)
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

                Task.Run(async()=> {
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
            ai.IsVisible = true;
            ai.IsRunning = true;


            if (pago == true)
            {
                plano = char.Parse("P");
            }
            else
            {
                plano = char.Parse("G");
            }

            Cliente cliente = new Cliente()
            {
                Nome = ent_Nome_Usuario.Text,
                Email = ent_Email_Usuario.Text,
                Senha = ent_Senha_Usuario.Text,
                Cep = ent_CEP_Usuario.Text,
                Rua = ent_Rua_Usuario.Text,
                Numero = ent_Numero_Usuario.Text,
                Cidade = ent_Cidade_Usuario.Text,
                Estado = ent_Estado_Usuario.Text,
                Telefone = ent_Telefone_Usuario.Text,
                Cpf = ent_CPF_Usuario.Text,
                DataNasc = DataPicker_Nascimento.Date.ToString("MM/dd/yyyy"),
                Plano = plano
                //Sexo = char.Parse(sexo.Text)
            };

            var conexao = new Conexao.Classes.ConexaoAPI();
            GerarToken gerarToken = new GerarToken();

            try
            {
                gerarToken.ChecharCache();

                var result = await conexao.Add(cliente, GerarToken.GetTokenFromCache());

                await DisplayAlert("Lyfr", result, "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Lyfr", ex.Message, "OK");
            }

            ai.IsVisible = false;
            ai.IsRunning = false;
        
    }

        private async void Esconde_Exibe_Senha_Clicked(object sender, EventArgs e)
        {
            ent_Senha_Usuario.IsPassword = !ent_Senha_Usuario.IsPassword;
            await btn_Img_Eye.ScaleTo(1.3,100,Easing.SpringIn);
            await btn_Img_Eye.ScaleTo(1,100,Easing.BounceIn);
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
            }
            else
            {
                lbl.IsEnabled = false;
                lbl.IsVisible = false;
            }


            if (ValidaSenha(ent.Text)) { 
                VisualStateManager.GoToState(lbl_aviso, "Valido");
                   
            }else{
                VisualStateManager.GoToState(lbl_aviso, "Invalido");
            }
        }


        private bool ValidaSenha(string senha)
        {
            bool _Maiusculo = false;
            bool _Especial = false;

            if(string.IsNullOrEmpty(senha) || string.IsNullOrWhiteSpace(senha))
            {
                return false;
            }

            if (Regex.IsMatch(senha,"@#!%&=")==true)
            {
                _Especial = true;
            }
            if (Regex.IsMatch(senha, "ABCDEFGHIJKLMNOPQRSTUVWXYZ") == true)
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