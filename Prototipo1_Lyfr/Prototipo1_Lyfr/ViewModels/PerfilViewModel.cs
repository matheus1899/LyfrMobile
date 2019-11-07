using Prototipo1_Lyfr.Conexao.Classes;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ViewModels
{
    public class PerfilViewModel : BaseViewModel
    {
        #region Propertys
        private string _Plano;
        private string _Nome;
        private string _Telefone;
        private string _Rua;
        private string _Numero;
        private string _Cidade;
        private string _Estado;
        private string _Email;
        private string _Senha;
        private int _IdCliente;
        private bool _Act_Ind_Sugestao;
        #endregion

        #region Get_Set
        public string Plano
        {
            get
            {
                return _Plano;
            }
            set
            {
                SetProperty<string>(ref _Plano, value, nameof(Plano));
            }
        }
        public int IdCliente
        {
            get
            {
                return _IdCliente;
            }
            set
            {
                SetProperty<int>(ref _IdCliente, value, nameof(IdCliente));
            }
        }
        public string Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                SetProperty<string>(ref _Nome, value, nameof(Nome));
            }
        }
        public string Telefone
        {
            get
            {
                return _Telefone;
            }
            set
            {
                SetProperty<string>(ref _Telefone, value, nameof(Telefone));
            }
        }
        public string Rua
        {
            get
            {
                return _Rua;
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
                return _Numero;
            }
            set
            {
                SetProperty<string>(ref _Numero, value, nameof(Numero));
            }
        }
        public string Cidade
        {
            get
            {
                return _Cidade;
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
                return _Estado;
            }
            set
            {
                SetProperty<string>(ref _Estado, value, nameof(Estado));
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetProperty<string>(ref _Email, value, nameof(Email));
            }
        }
        public string Senha
        {
            get
            {
                return _Senha;
            }
            set
            {
                SetProperty<string>(ref _Senha, value, nameof(Senha));
            }
        }
        public bool Act_Ind_Sugestao
        {
            get
            {
                return (bool)_Act_Ind_Sugestao;
            }
            set
            {
                SetProperty<bool>(ref _Act_Ind_Sugestao, value, nameof(Act_Ind_Sugestao));
            }
        }
        #endregion

        public ICommand Enviar_Sugestao_Command { get; private set; }

        public PerfilViewModel(Cliente cliente)
        {
            Set_Initial_Values(cliente);
            GerarToken gerarToken = new GerarToken();
            ConexaoAPI conexao = new ConexaoAPI();

            Enviar_Sugestao_Command = new Command(async(e)=> {
                var msn = e as string;
                Sugestao sugestao = new Sugestao()
                {
                    FkIdCliente = IdCliente,
                    Atendido = char.Parse("N"),
                    Mensagem = msn
                };

                try
                {
                    Act_Ind_Sugestao = true;

                    var result = await conexao.SendSugestao(sugestao, GerarToken.GetTokenFromCache());
                    MostrarMensagem.Mostrar(result);

                    Act_Ind_Sugestao = false;
                }

                catch (Exception ex)
                {
                    Act_Ind_Sugestao = false;
                    MostrarMensagem.Mostrar(ex.Message);
                }
            });
        }

        private void Set_Initial_Values(Cliente cliente)
        {
            //Plano = cliente.Plano == "P" ? "Premium" : "Gratuito";
            IdCliente = cliente.IdCliente;
            Nome = cliente.Nome;
            Nome = cliente.Nome;
            Rua = cliente.Rua;
            Numero = cliente.Numero;
            Cidade = cliente.Cidade;
            Estado = cliente.Estado;
            Email = cliente.Email;
            Telefone = cliente.Telefone;
        }
    }
}
