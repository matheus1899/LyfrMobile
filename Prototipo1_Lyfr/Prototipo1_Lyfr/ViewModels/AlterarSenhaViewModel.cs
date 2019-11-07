using Prototipo1_Lyfr.Conexao.Classes;
using Prototipo1_Lyfr.Controls;
using Prototipo1_Lyfr.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using Prototipo1_Lyfr.ViewModels.Services;

namespace Prototipo1_Lyfr.ViewModels
{
    public class AlterarSenhaViewModel:BaseViewModel
    {
        #region Property
        private string _NovaSenha;
        private string _ConfirmarNovaSenha;
        private bool _EntryNovaSenhaIsPassword;
        private bool _EntryConfirmarNovaSenhaIsPassword;
        private bool _ActIsRunning;

        public string NovaSenha
        {
            get => _NovaSenha;
            set => SetProperty(ref _NovaSenha, value, nameof(NovaSenha));
        }
        public string ConfirmarNovaSenha
        {
            get => _ConfirmarNovaSenha;
            set => SetProperty(ref _ConfirmarNovaSenha, value, nameof(ConfirmarNovaSenha));
        }
        public bool EntryNovaSenhaIsPassword
        {
            get => _EntryNovaSenhaIsPassword;
            set => SetProperty(ref _EntryNovaSenhaIsPassword, value, nameof(EntryNovaSenhaIsPassword));
        }
        public bool EntryConfirmarNovaSenhaIsPassword
        {
            get => _EntryConfirmarNovaSenhaIsPassword;
            set => SetProperty(ref _EntryConfirmarNovaSenhaIsPassword, value, nameof(EntryConfirmarNovaSenhaIsPassword));
        }
        public bool ActIsRunning
        {
            get => _ActIsRunning;
            set => SetProperty(ref _ActIsRunning, value, nameof(ActIsRunning));
        }
        public Cliente OldCliente { get; set; }
        #endregion
        public ICommand AlterarSenhaCommand { get; private set; }
        public ICommand SetEmptyNovaSenhaCommand { get; private set; }
        public ICommand SetEmptyConfirmarNovaSenhaCommand { get; private set; }
        public ICommand EntryNovaSenhaIsPasswordCommand { get; private set; }
        public ICommand EntryConfirmarNovaSenhaIsPasswordCommand { get; private set; }
        public AlterarSenhaViewModel()
        {
            NovaSenha = string.Empty;
            ConfirmarNovaSenha = string.Empty;

            EntryNovaSenhaIsPassword = true;
            EntryConfirmarNovaSenhaIsPassword = true;

            SetEmptyNovaSenhaCommand = new Command(SetEmptyNovaSenha);
            SetEmptyConfirmarNovaSenhaCommand = new Command(SetEmptyConfirmarSenha);
            EntryConfirmarNovaSenhaIsPasswordCommand = new Command(ConfirmarSenhaIsPassword);
            EntryNovaSenhaIsPasswordCommand = new Command(NovaSenhaIsPassword);
            AlterarSenhaCommand = new Command(async (e) => {
                try
                {
                    if (IsNullOrWhiteSpaceOrEmpty(NovaSenha, ConfirmarNovaSenha))
                    {
                        var a = e as StackLayout;
                        var b = a.Children[0];
                        var c = a.Children[1];
                        ShakeShake(b);
                        ShakeShake(c);
                    }
                    else if(NovaSenha != ConfirmarNovaSenha)
                    {
                        var a = e as StackLayout;
                        var b = a.Children[0];
                        var c = a.Children[1];
                        ShakeShake(b);
                        ShakeShake(c);
                    }
                    else
                    {
                        var con = new ConexaoAPI();
                        Cliente backup = OldCliente;
                        OldCliente.Senha = NovaSenha;
                        using(Cache c = new Cache())
                        {
                            await con.Update(OldCliente, c.GetTokenCache().TokenString);
                        }
                        MostrarMensagem.Mostrar("Senha alterada com sucesso");
                        await DependencyService.Get<INavigationService>().GoBack();
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensagem.Mostrar(ex.Message);
                }
            });
        }
        private void SetEmptyConfirmarSenha()
        {
            ConfirmarNovaSenha = string.Empty;
        }
        private void SetEmptyNovaSenha()
        {
            NovaSenha = string.Empty;
        }
        private void ConfirmarSenhaIsPassword()
        {
            EntryConfirmarNovaSenhaIsPassword = !EntryConfirmarNovaSenhaIsPassword;
        }
        private void NovaSenhaIsPassword()
        {
            EntryNovaSenhaIsPassword = !EntryNovaSenhaIsPassword;
        }

    }
}
