using System;
using Xamarin.Forms;
using System.Windows.Input;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;

namespace Prototipo1_Lyfr.ViewModels
{
    public class CadastrarViewModel : BaseViewModel
    {
        public ICommand Cadastrar_Clicked { private set; get; }
        public ICommand Next_Entry_Command { private set; get; }

        public CadastrarViewModel()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Senha = string.Empty;
            Cpf = string.Empty;

            Cadastrar_Clicked = new Command(async (e) =>
            {
                var g = e as Grid;
                if (string.IsNullOrEmpty(Nome))
                {
                    ShakeShake(g.Children[2]);
                    MostrarMensagem.Mostrar("Prencha o campo do nome");
                    return;
                }
                else if (string.IsNullOrEmpty(Email))
                {
                    ShakeShake(g.Children[3]);
                    MostrarMensagem.Mostrar("Preencha o campo do e-mail");
                    return;
                }
                else if (string.IsNullOrEmpty(Senha))
                {
                    ShakeShake(g.Children[4]);
                    MostrarMensagem.Mostrar("Preencha o campo da senha");
                    return;
                }
                else if (string.IsNullOrEmpty(Cpf))
                {
                    ShakeShake(g.Children[5]);
                    MostrarMensagem.Mostrar("Preencha o campo do CPF");
                    return;
                }
                else
                {
                    Act_Indicator = true;
                    Cliente cliente = new Cliente()
                    {
                        Nome = this.Nome.Trim(),
                        Email = Email.Trim(),
                        Senha = Senha.Trim(),
                        Cpf = this.Cpf,
                        Data_Cadastro = DateTime.Now.ToString()
                    };

                    var conexao = new ConexaoAPI();
                    Lazy<GerarToken> gerarToken = new Lazy<GerarToken>();

                    try
                    {
                        var result = await conexao.Add(cliente, GerarToken.GetTokenFromCache());
                        MostrarMensagem.Mostrar(result);

                        Act_Indicator = false;
                    }
                    catch (Exception ex)
                    {
                        MostrarMensagem.Mostrar(ex.Message);
                    }
                }
            });
            Next_Entry_Command = new Command(async (e) =>
            {
                var a = e as Entry;
                if (a.Placeholder == "Email")
                {
                    a.Focus();
                }
                else if (a.Placeholder == "Senha")
                {
                    a.Focus();
                }
                else if (a.Placeholder == "CPF")
                {
                    a.Focus();
                }
            });
        }
        #region Propertys
        private string _Nome;
        private string _Cpf;
        private string _Email;
        private string _Senha;
        private string _Data_Cadastro;
        private bool _Act_Indicator;

        #endregion
        #region Get_Set
        
        public string Nome
        {
            get =>(string)_Nome;
            set => SetProperty<string>(ref _Nome, value, nameof(Nome));
        }
        public string Cpf
        {
            get=>(string)_Cpf;
            set=>SetProperty<string>(ref _Cpf, value, nameof(Cpf));
        }
        public string Email
        {
            get=>(string)_Email;
            set=>SetProperty<string>(ref _Email, value, nameof(Email));
        }
        public string Senha
        {
            get=>(string)_Senha;
            set=>SetProperty<string>(ref _Senha, value, nameof(Senha));
        }
        public DateTime Data_Cadastro
        {
            get=>DateTime.Parse(_Data_Cadastro);
            set=>SetProperty<string>(ref _Data_Cadastro, value.ToString(), nameof(Data_Cadastro));
        }
        public bool Act_Indicator
        {
            get=>(bool)_Act_Indicator;
            set=>SetProperty<bool>(ref _Act_Indicator, value, nameof(Act_Indicator));
        }
        #endregion
    }
}
