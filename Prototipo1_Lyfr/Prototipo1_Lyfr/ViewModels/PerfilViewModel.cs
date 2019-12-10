using Prototipo1_Lyfr.Conexao;
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

        private string _Nome;
        private string _Email;
        private string _Senha;
        private int _IdCliente;
        private bool _Act_Ind_Sugestao;
        #endregion

        #region Get_Set

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
            IdCliente = cliente.IdCliente;
            Nome = cliente.Nome;
            Email = cliente.Email;
        }
    }
}
