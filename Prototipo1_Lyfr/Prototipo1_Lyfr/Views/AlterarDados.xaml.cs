using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterarDados : ContentPage
    {
        private bool ModificarEmail = false;
        private bool ModificarSenha = false;
        private bool ModificarTelefone = false;
        private bool ModificarEndereco = false;
        private Cliente cliente;
        private GerarToken gerarToken;

        private async void btn_Alterar_Clicked(object sender, EventArgs e)
        {
            SetIsRunningAndIsVisible(act_ind_alteracao, true);
            if (ModificarEmail)
            {
                try
                {

                    if (cliente.Email == ent_EmailAtual_Usuario.Text)
                    {
                        Cliente clienteAlterado = new Cliente()
                        {
                            Nome = cliente.Nome,
                            IdCliente = cliente.IdCliente,
                            Email = ent_EmailNovo_Usuario.Text,
                            Senha = cliente.Senha,
                            Cpf = cliente.Cpf,
                            Cep = cliente.Cep,
                            Cidade = cliente.Cidade,
                            DataNasc = cliente.DataNasc,
                            Data_Cadastro = cliente.Data_Cadastro,
                            Estado = cliente.Estado,
                            Numero = cliente.Numero,
                            Rua = cliente.Rua,
                            Telefone = cliente.Telefone
                        };

                        var conexao = new ConexaoAPI();
                        var result = await conexao.Update(clienteAlterado, GerarToken.GetTokenFromCache());
                        MostrarMensagem.Mostrar(result);
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        SetIsRunningAndIsVisible(act_ind_alteracao, false);
                        MostrarMensagem.Mostrar("O e-mail atual não corresponde!");
                    }
                }
                catch (Exception ex)
                {
                    SetIsRunningAndIsVisible(act_ind_alteracao, false);
                    MostrarMensagem.Mostrar(ex.Message);
                }

            }
            else if (ModificarSenha)
            {
                try
                {

                    if (cliente.Senha == ent_SenhaAtual_Usuario.Text && ent_SenhaNova_Usuario.Text == ent_SenhaConfirmarNova_Usuario.Text)
                    {
                        Cliente clienteAlterado = new Cliente()
                        {
                            Nome = cliente.Nome,
                            IdCliente = cliente.IdCliente,
                            Email = cliente.Email,
                            Senha = ent_SenhaNova_Usuario.Text,
                            Cpf = cliente.Cpf,
                            Cep = cliente.Cep,
                            Cidade = cliente.Cidade,
                            DataNasc = cliente.DataNasc,
                            Data_Cadastro = cliente.Data_Cadastro,
                            Estado = cliente.Estado,
                            Numero = cliente.Numero,
                            //Plano = cliente.Plano,
                            Rua = cliente.Rua,
                            Telefone = cliente.Telefone
                        };

                        var conexao = new ConexaoAPI();
                        var result = await conexao.Update(clienteAlterado, GerarToken.GetTokenFromCache());
                        MostrarMensagem.Mostrar(result);
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        SetIsRunningAndIsVisible(act_ind_alteracao, false);
                        MostrarMensagem.Mostrar("As senhas não correspondem!");
                    }
                }
                catch (Exception ex)
                {
                    SetIsRunningAndIsVisible(act_ind_alteracao, false);
                    MostrarMensagem.Mostrar(ex.Message);
                }
            }
            else if (ModificarTelefone)
            {
                try
                {

                    Cliente clienteAlterado = new Cliente()
                    {
                        Nome = cliente.Nome,
                        IdCliente = cliente.IdCliente,
                        Email = cliente.Email,
                        Senha = cliente.Senha,
                        Cpf = cliente.Cpf,
                        Cep = cliente.Cep,
                        Cidade = cliente.Cidade,
                        DataNasc = cliente.DataNasc,
                        Data_Cadastro = cliente.Data_Cadastro,
                        Estado = cliente.Estado,
                        Numero = cliente.Numero,
                        //Plano = cliente.Plano,
                        Rua = cliente.Rua,
                        Telefone = ent_Telefone_Usuario.Text
                    };

                    var conexao = new ConexaoAPI();
                    var result = await conexao.Update(clienteAlterado, GerarToken.GetTokenFromCache());
                    MostrarMensagem.Mostrar(result);
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    SetIsRunningAndIsVisible(act_ind_alteracao, false);
                    MostrarMensagem.Mostrar(ex.Message);
                }
            }
            else if (ModificarEndereco)
            {
                try
                {

                    Cliente clienteAlterado = new Cliente()
                    {
                        Nome = cliente.Nome,
                        IdCliente = cliente.IdCliente,
                        Email = cliente.Email,
                        Senha = cliente.Senha,
                        Cpf = cliente.Cpf,
                        Cep = ent_CEP_Usuario.Text,
                        Cidade = ent_Cidade_Usuario.Text,
                        DataNasc = cliente.DataNasc,
                        Data_Cadastro = cliente.Data_Cadastro,
                        Estado = ent_Estado_Usuario.Text,
                        Numero = ent_Numero_Usuario.Text,
                        //Plano = cliente.Plano,
                        Rua = ent_Rua_Usuario.Text,
                        Telefone = cliente.Telefone
                    };

                    var conexao = new ConexaoAPI();
                    var result = await conexao.Update(clienteAlterado, GerarToken.GetTokenFromCache());
                    MostrarMensagem.Mostrar(result);
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    SetIsRunningAndIsVisible(act_ind_alteracao, false);
                    MostrarMensagem.Mostrar(ex.Message);
                }
            }
            else
            {
                return;
            }
        }

        public AlterarDados(string propriedade, Cliente cliente)
        {
            InitializeComponent();
            gerarToken = new GerarToken();
            if (propriedade == "Email")
            {
                Stack_Email.IsVisible = true;
                ModificarEmail = true;
            }
            else if (propriedade == "Senha")
            {
                Stack_Senha.IsVisible = true;
                ModificarSenha = true;
            }
            else if (propriedade == "Telefone")
            {
                Stack_Telefone.IsVisible = true;
                ModificarTelefone = true;
            }
            else
            {
                Stack_Endereco.IsVisible = true;
                ModificarEndereco = true;
            }

            this.cliente = cliente;
        }
        private void SetIsRunningAndIsVisible(ActivityIndicator act, bool b)
        {
            act.IsRunning = b;
            act.IsVisible = b;
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
        
        private void Senha_Ent_Unfocused(object sender, FocusEventArgs e)
        {
            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            c.IsEnabled = false;
            c.IsVisible = false;
        }
        private void Senha_Ent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = sender as Entry;
            var b = a.Parent as StackLayout;
            var c = b.Children[1] as Label;

            if(string.IsNullOrEmpty(e.NewTextValue) || string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                c.IsEnabled = false;
                c.IsVisible = false;
                return;
            }
            if (e.NewTextValue.Length > 0)
            {
                c.IsEnabled = true;
                c.IsVisible = true;
            }
        }
        private async void Esconde_Exibe_Senha_Clicked(object sender, EventArgs e)
        {
            var a = sender as ImageButton;
            await a.ScaleTo(1.3, 100, Easing.SpringIn);
            var pai = a.Parent as StackLayout;
            var ent = pai.Children[0] as Entry;
            ent.IsPassword = !ent.IsPassword;
            await a.ScaleTo(1, 100, Easing.BounceIn);
        }
    }
}