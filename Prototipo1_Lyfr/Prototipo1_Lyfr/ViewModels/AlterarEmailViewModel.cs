using System;
using Xamarin.Forms;
using System.Windows.Input;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Conexao.Classes;

namespace Prototipo1_Lyfr.ViewModels
{
    public class AlterarEmailViewModel:BaseViewModel
    {
        private string _NovoEmail;
        private bool _Act_State;
        private Cliente _cliente;
        private Lazy<ConexaoAPI> con = new Lazy<ConexaoAPI>();
        public string NovoEmail
        {
            get => _NovoEmail;
            set => SetProperty(ref _NovoEmail, value, nameof(NovoEmail));
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

        public ICommand AlterarEmailCommand { get; private set; }
        public AlterarEmailViewModel()
        {
            AlterarEmailCommand = new Command(async(e) => {
                try
                {
                    Act_State = true;
                    var a = e as StackLayout;
                    var b = a.Children[2] as StackLayout;
                    if (!EmailIsValid(NovoEmail))
                    {
                        ShakeShake(b);
                        Act_State = false;
                    }
                    else
                    {
                        Cliente c = cliente;
                        cliente.Email = NovoEmail;
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
