using Prototipo1_Lyfr.Conexao;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ViewModels
{
    public class AlterarTelefoneViewModel:BaseViewModel
    {
        private bool _Act_State;
        private string _NovoTelefone;
        private Cliente _cliente;
        private Lazy<ConexaoAPI> con = new Lazy<ConexaoAPI>();

        public bool Act_State
        {
            get => _Act_State;
            set => SetProperty(ref _Act_State, value, nameof(Act_State));
        }
        public string NovoTelefone
        {
            get => _NovoTelefone;
            set => SetProperty(ref _NovoTelefone, value, nameof(NovoTelefone));
        }
        public Cliente cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value, nameof(cliente));
        }

        public ICommand AlterarTelefoneCommand { get; private set; }

        public AlterarTelefoneViewModel()
        {
            Act_State = false;
            NovoTelefone = string.Empty;

            AlterarTelefoneCommand = new Command(async (e) =>
            {
                try
                {
                    Act_State = true;
                    var a = e as StackLayout;
                    var b = a.Children[2] as StackLayout;
                    if (!TelefoneIsValid(NovoTelefone))
                    {
                        ShakeShake(b);
                        Act_State = false;
                    }
                    else
                    {
                        Cliente c = cliente;
                        cliente.Telefone = NovoTelefone;
                        using (Cache cache = new Cache())
                        {
                            await con.Value.Update(cliente, cache.GetTokenCache().TokenString);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensagem.Mostrar(ex.Message);
                }
            });
        }
    }
}
