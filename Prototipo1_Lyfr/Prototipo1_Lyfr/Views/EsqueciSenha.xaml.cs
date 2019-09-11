using Prototipo1_Lyfr.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.Conexao;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EsqueciSenha : ContentPage
    {
        //bool Codigo_Enviado = false;
        public EsqueciSenha()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void Lbl_Apagar_Entry_Email(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Email_Usuario.Text) || string.IsNullOrWhiteSpace(ent_Email_Usuario.Text))
            {
                return;
            }
            else
            {
                ent_Email_Usuario.Text = string.Empty;
            }
        }
        private void EntryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            Lbl_X_Email.IsEnabled = false;
            Lbl_X_Email.IsVisible = false;
        }
        private void EntryEmail_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Email_Usuario.Text))
            {
                Lbl_X_Email.IsEnabled = false;
                Lbl_X_Email.IsVisible = false;
                return;
            }
            if (ent_Email_Usuario.Text.Length > 0)
            {
                Lbl_X_Email.IsEnabled = true;
                Lbl_X_Email.IsVisible = true;
            }
            else
            {
                Lbl_X_Email.IsEnabled = false;
                Lbl_X_Email.IsVisible = false;
            }
        }
        private void EntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(ent_Email_Usuario.Text) || string.IsNullOrWhiteSpace(ent_Email_Usuario.Text))
            {
                Lbl_X_Email.IsEnabled = false;
                Lbl_X_Email.IsVisible = false;
            }else
            {
                Lbl_X_Email.IsEnabled = true;
                Lbl_X_Email.IsVisible = true;
            }
        }
        private async void BtnEnviaCodigo_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ent_Email_Usuario.Text) || string.IsNullOrWhiteSpace(ent_Email_Usuario.Text))
                {
                    throw new ArgumentNullException();
                }
                if (!Regex.IsMatch(ent_Email_Usuario.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(50)))
                {
                    throw new FormatException();
                }

                Conexao.Classes.ConexaoAPI conexao = new Conexao.Classes.ConexaoAPI();
                GerarToken gerarToken = new GerarToken();
                string result=" ";
                gerarToken.ChecarCache();
                await Task.Run(async () => { result = await conexao.EnviarEmail(ent_Email_Usuario.Text, GerarToken.GetTokenFromCache()); });
                MostrarMensagem.Mostrar(result);
            }
            catch (ArgumentNullException)
            {
                MostrarMensagem.Mostrar("Preencha o campo para completar a solicitação");
            }
            catch (FormatException)
            {
                MostrarMensagem.Mostrar("Email inválido, por favor digite o seu email novamente");
            }
            catch (Exception ex)
            {
                MostrarMensagem.Mostrar(ex.Message);
            }
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return base.OnBackButtonPressed();
        }
    }
}