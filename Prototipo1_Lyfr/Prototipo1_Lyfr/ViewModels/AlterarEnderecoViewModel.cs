using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System.Windows.Input;
using System;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ViewModels
{
    public class AlterarEnderecoViewModel:BaseViewModel
    {
        #region Property
        private string _NovaRua;
        private string _NovoNumero;
        private string _NovoCEP;
        private string _NovaCidade;
        private string _NovoEstado;
        private bool _Act_State;
        private Cliente _cliente;

        public string NovaRua
        {
            get => _NovaRua;
            set => SetProperty(ref _NovaRua, value, nameof(NovaRua));
        }
        public string NovoNumero
        {
            get => _NovoNumero;
            set => SetProperty(ref _NovoNumero, value, nameof(NovoNumero));
        }
        public string NovoCEP
        {
            get => _NovoCEP;
            set => SetProperty(ref _NovoCEP, value, nameof(NovoCEP));
        }
        public string NovaCidade
        {
            get => _NovaCidade;
            set => SetProperty(ref _NovaCidade, value, nameof(NovaCidade));
        }
        public string NovoEstado
        {
            get => _NovoEstado;
            set => SetProperty(ref _NovoEstado, value, nameof(NovoEstado));
        }
        public bool Act_State
        {
            get => _Act_State;
            set => SetProperty(ref _Act_State, value, nameof(Act_State));
        }
        public Cliente cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value, nameof(cliente));
        }
        #endregion
        private Lazy<ConexaoAPI> con = new Lazy<ConexaoAPI>();
        public ICommand AlterarEnderecoCommand { get; private set; }
        public AlterarEnderecoViewModel()
        {
            SetEmpty(NovaRua, NovoNumero, NovoCEP, NovaCidade, NovoEstado);
            Act_State = false;

            AlterarEnderecoCommand = new Command(async (e) => {
                var a = e as StackLayout;
                if (IsNullOrWhiteSpaceOrEmpty(NovoCEP))
                {
                    ShakeShake(a.Children[1]);
                    MostrarMensagem.Mostrar("Preencha o campo CEP...");
                    return;
                }
                if (IsNullOrWhiteSpaceOrEmpty(NovaRua, NovoNumero))
                {
                    ShakeShake(a.Children[2]);
                    MostrarMensagem.Mostrar("Preencha os campos Rua e Número...");
                    return;
                }
                if (IsNullOrWhiteSpaceOrEmpty(NovaCidade, NovoEstado))
                {
                    ShakeShake(a.Children[3]);
                    MostrarMensagem.Mostrar("Preencha os campos Cidade e Estado...");
                    return;
                }

                Cliente c = cliente;
                cliente.Rua = NovaRua;
                cliente.Numero = NovoNumero;
                cliente.Cidade = NovaCidade;
                cliente.Estado = NovoEstado;
                using (Cache cache = new Cache())
                {
                    await con.Value.Update(cliente, cache.GetTokenCache().TokenString);
                }
            });
        }

        private void SetEmpty(params string[] array)
        {
            for(short i = 0; i < array.Length; i++)
            {
                array[i] = string.Empty;
            }
        }
    }
}
