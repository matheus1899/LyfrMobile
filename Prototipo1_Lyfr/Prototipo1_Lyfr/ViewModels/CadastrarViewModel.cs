using Prototipo1_Lyfr.Conexao.Classes;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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
            Cep = string.Empty;
            Rua = string.Empty;
            Numero = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            DataNasc = DateTime.Now;

            Cadastrar_Clicked = new Command(async () =>
            {
                if (string.IsNullOrEmpty(Nome))
                {
                    MostrarMensagem.Mostrar("Prencha o campo do nome");
                    return;
                }
                
                else if (string.IsNullOrEmpty(Email))
                {
                    MostrarMensagem.Mostrar("Preencha o campo do e-mail");
                    return;
                }
                else if (string.IsNullOrEmpty(Senha))
                {
                    MostrarMensagem.Mostrar("Preencha o campo da senha");
                    return;
                }
                else if (string.IsNullOrEmpty(Cpf))
                {
                    MostrarMensagem.Mostrar("Preencha o campo do CPF");
                    return;
                }
                else if (string.IsNullOrEmpty(Cep))
                {
                    MostrarMensagem.Mostrar("Preencha o campo do CEP");
                    return;
                }
                else if (string.IsNullOrEmpty(Telefone))
                {
                    MostrarMensagem.Mostrar("Preencha o campo do telefone");
                    return;
                }
                else if (string.IsNullOrEmpty(Rua))
                {
                    MostrarMensagem.Mostrar("Preencha o campo da rua");
                    return;
                }
                else if (string.IsNullOrEmpty(Numero))
                {
                    MostrarMensagem.Mostrar("Preencha o campo do número");
                    return;
                }
                else if (string.IsNullOrEmpty(Cidade))
                {
                    MostrarMensagem.Mostrar("Preencha o campo da cidade");
                    return;
                }
                else if (string.IsNullOrEmpty(Estado))
                {
                    MostrarMensagem.Mostrar("Preencha o campo do estado");
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
                        Cep = this.Cep,
                        Rua = this.Rua.Trim(),
                        Numero = this.Numero.Trim(),
                        Cidade = this.Cidade.Trim(),
                        Estado = this.Estado,
                        Telefone = this.Telefone,
                        Cpf = this.Cpf,
                        DataNasc = this.DataNasc.ToString("MM/dd/yyyy"),
                        Data_Cadastro = DateTime.Now.ToString()
                    };

                    var conexao = new Conexao.Classes.ConexaoAPI();
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
                else if (a.Placeholder == "CEP")
                {

                    a.Focus();
                }
                else if (a.Placeholder == "Telefone")
                {

                    a.Focus();
                }
                else if (a.Placeholder == "Rua")
                {

                    a.Focus();
                }
                else if (a.Placeholder == "Número")
                {

                    a.Focus();
                }
                else if (a.Placeholder == "Cidade")
                {

                    a.Focus();
                }
                else if (a.Placeholder == "Estado  ")
                {

                    a.Focus();

                }
            });
        }

        #region Propertys
        private string _Plano;
        private string _Nome;
        private string _Cpf;
        private string _Email;
        private string _Rua;
        private string _Numero;
        private string _Cep;
        private string _Cidade;
        private string _Estado;
        private string _DataNasc;
        private string _Senha;
        private string _Telefone;
        private string _Data_Cadastro;
        //private Style _Botao_Gratis;
        //private Style _Botao_Pago;

        private bool _Act_Indicator;

        #endregion

        #region Get_Set
        
        public string Nome
        {
            get
            {
                return (string)_Nome;
            }
            set
            {
                SetProperty<string>(ref _Nome, value, nameof(Nome));
            }
        }
        public string Cpf
        {
            get
            {
                return (string)_Cpf;
            }
            set
            {
                SetProperty<string>(ref _Cpf, value, nameof(Cpf));
            }
        }
        public string Email
        {
            get
            {
                return (string)_Email;
            }
            set
            {
                SetProperty<string>(ref _Email, value, nameof(Email));
            }
        }
        public string Rua
        {
            get
            {
                return (string)_Rua;
            }
            set
            {
                SetProperty<string>(ref _Rua, value, nameof(Rua));
            }
        }
        public string Numero
        {
            get
            {
                return (string)_Numero;
            }
            set
            {
                SetProperty<string>(ref _Numero, value, nameof(Numero));
            }
        }
        public string Cep
        {
            get
            {
                return (string)_Cep;
            }
            set
            {
                SetProperty<string>(ref _Cep, value, nameof(Cep));
            }
        }
        public string Cidade
        {
            get
            {
                return (string)_Cidade;
            }
            set
            {
                SetProperty<string>(ref _Cidade, value, nameof(Cidade));
            }
        }
        public string Estado
        {
            get
            {
                return (string)_Estado;
            }
            set
            {
                SetProperty<string>(ref _Estado, value, nameof(Estado));
            }
        }
        public DateTime DataNasc
        {
            get
            {
                return DateTime.Parse(_DataNasc);
            }
            set
            {
                SetProperty<string>(ref _DataNasc, value.ToString(), nameof(DataNasc));
            }
        }
        public string Senha
        {
            get
            {
                return (string)_Senha;
            }
            set
            {
                SetProperty<string>(ref _Senha, value, nameof(Senha));
            }
        }
        public string Telefone
        {
            get
            {
                return (string)_Telefone;
            }
            set
            {
                SetProperty<string>(ref _Telefone, value, nameof(Telefone));
            }
        }
        public DateTime Data_Cadastro
        {
            get
            {
                return DateTime.Parse(_Data_Cadastro);
            }
            set
            {
                SetProperty<string>(ref _Data_Cadastro, value.ToString(), nameof(Data_Cadastro));
            }
        }
        //public Style Botao_Pago
        //{
        //    //get
        //    //{
        //    //    //return (Style)_Botao_Pago;
        //    //}
        //    //set
        //    //{
        //    //    //SetProperty<Style>(ref _Botao_Pago, value, nameof(Botao_Pago));
        //    //}
        //}
        //public Style Botao_Gratis
        //{
        //    ////get
        //    //{
        //    //    //return (Style)_Botao_Gratis;
        //    //}
        //    //set
        //    //{
        //    //    //SetProperty<Style>(ref _Botao_Gratis, value, nameof(Botao_Gratis));
        //    //}
        //}

        public bool Act_Indicator
        {
            get
            {
                return (bool)_Act_Indicator;
            }
            set
            {
                SetProperty<bool>(ref _Act_Indicator, value, nameof(Act_Indicator));
            }
        }
        #endregion

    }
}
