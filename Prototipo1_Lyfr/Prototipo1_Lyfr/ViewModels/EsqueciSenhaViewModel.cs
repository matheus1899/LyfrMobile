using Prototipo1_Lyfr.Conexao.Classes;
using Prototipo1_Lyfr.ConexaoAPI;
using Prototipo1_Lyfr.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ViewModels
{
    public class EsqueciSenhaViewModel:BaseViewModel
    {
        #region Property
        private string _Codigo;
        private string _Email;
        private string _C1;
        private string _C2;
        private string _C3;
        private string _C4;
        private string _C5;
        private bool _IsValid;
        private bool _Act_State;
        private Lazy<Conexao.Classes.ConexaoAPI> con;
        private Lazy<Cache> db_cache;

        public ICommand Btn_Enviar_Email_Command { get; private set; }
        public ICommand Btn_Verificar_Codigo_Command { get; private set; }

        public string Codigo
        {
            get { return _Codigo; }
            set { SetProperty<string>(ref _Codigo, value, nameof(Codigo)); }
        }
        public string Email
        {
            get { return _Email; }
            set { SetProperty<string>(ref _Email, value, nameof(Email)); }
        }
        public string C1
        {
            get { return _C1; }
            set { SetProperty<string>(ref _C1, value, nameof(C1)); }
        }
        public string C2
        {
            get { return _C2; }
            set { SetProperty<string>(ref _C2, value, nameof(C2)); }
        }
        public string C3
        {
            get { return _C3; }
            set { SetProperty<string>(ref _C3, value, nameof(C3)); }
        }
        public string C4
        {
            get { return _C4; }
            set { SetProperty<string>(ref _C4, value, nameof(C4)); }
        }
        public string C5
        {
            get => _C5;
            set { SetProperty(ref _C5, value, nameof(C5)); }
        }
        public bool IsValid
        {
            get => _IsValid;
            set { SetProperty(ref _IsValid, value, nameof(IsValid)); }
        }
        public bool Act_State
        {
            get => _Act_State;
            set { SetProperty(ref _Act_State, value, nameof(Act_State)); }
        }
        #endregion
        public EsqueciSenhaViewModel()
        {
            Codigo = string.Empty;
            Email = string.Empty;
            C1 = string.Empty;
            C2 = string.Empty;
            C3 = string.Empty;
            C4 = string.Empty;
            C5 = string.Empty;
            IsValid = false;
            Act_State = false;

            con = new Lazy<Conexao.Classes.ConexaoAPI>();
            db_cache = new Lazy<Cache>();

            Btn_Enviar_Email_Command = new Command(async (e)=> 
            {

                Act_State = true;
                var a = e as StackLayout;
                var b = a.Children[0] as StackLayout;
                if (!Regex.IsMatch(Email,
                            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(50))){
                    var c = b.Children[1];
                    await c.TranslateTo(25, 0, 30, Easing.Linear);
                    await c.TranslateTo(-25, 0, 30, Easing.Linear);
                    await c.TranslateTo(10, 0, 25, Easing.Linear);
                    await c.TranslateTo(-10, 0, 25, Easing.Linear);
                    await c.TranslateTo(5, 0, 25, Easing.Linear);
                    await c.TranslateTo(-5, 0, 25, Easing.Linear);
                    await c.TranslateTo(0, 0, 25, Easing.Linear);
                    Act_State = false;
                }
                else
                {
                    Act_State = true;
                    Gerar_Codigo();
                    await con.Value.EnviarEmail(new RecoveryPassword {Email = this.Email, CodigoGerado = Codigo }, db_cache.Value.GetTokenCache().TokenString);
                    var c = a.Children[2];
                    await b.FadeTo(0, 250, Easing.Linear);
                    await c.FadeTo(0, 250, Easing.Linear);
                    b.IsVisible = false;
                    c.IsVisible = false;
                    var d = a.Children[1];
                    d.IsVisible = true;
                    await d.FadeTo(1, 300, Easing.Linear);
                }
                
            });

            Btn_Verificar_Codigo_Command = new Command(async(e)=> {
                var b = e as StackLayout;
                if(string.IsNullOrWhiteSpace(C1) ||  string.IsNullOrWhiteSpace(C2) ||  string.IsNullOrWhiteSpace(C3) ||  string.IsNullOrWhiteSpace(C4) || string.IsNullOrWhiteSpace(C5)){
                    await b.TranslateTo(25, 0, 30, Easing.Linear);
                    await b.TranslateTo(-25, 0, 30, Easing.Linear);
                    await b.TranslateTo(10, 0, 25, Easing.Linear);
                    await b.TranslateTo(-10, 0, 25, Easing.Linear);
                    await b.TranslateTo(5, 0, 25, Easing.Linear);
                    await b.TranslateTo(-5, 0, 25, Easing.Linear);
                    await b.TranslateTo(0, 0, 25, Easing.Linear);
                }
                else if (!Equals(Codigo, string.Concat(C1,C2,C3,C4,C5)))
                {
                    await b.TranslateTo(25, 0, 30, Easing.Linear);
                    await b.TranslateTo(-25, 0, 30, Easing.Linear);
                    await b.TranslateTo(10, 0, 25, Easing.Linear);
                    await b.TranslateTo(-10, 0, 25, Easing.Linear);
                    await b.TranslateTo(5, 0, 25, Easing.Linear);
                    await b.TranslateTo(-5, 0, 25, Easing.Linear);
                    await b.TranslateTo(0, 0, 25, Easing.Linear);
                }
                else
                {

                }
            });
        }


        private void Gerar_Codigo()
        {
            string c = string.Empty;
            var rand = new Random();
            for (short i =0; i<5; i++)
            {
                c = string.Concat(c, rand.Next(0,9).ToString());
            }
            Codigo = c;
        }
        
    }
}
