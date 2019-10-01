using System.Windows.Input;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ViewModels
{
    public class EsqueciSenhaViewModel:BaseViewModel
    {
        private string _Codigo;
        private string _Email;
        private string _C1;
        private string _C2;
        private string _C3;
        private string _C4;
        private string _C5;

        public EsqueciSenhaViewModel()
        {
            Codigo = string.Empty;
            Email = string.Empty;
            C1 = string.Empty;
            C2 = string.Empty;
            C3 = string.Empty;
            C4 = string.Empty;
            C5 = string.Empty;

            Btn_Enviar_Email_Command = new Command(async (e)=> {
                var a = e as StackLayout;
                var b = a.Children[0];
                var c = a.Children[2];
                await b.FadeTo(0, 250, Easing.Linear);
                await c.FadeTo(0, 250, Easing.Linear);
                b.IsVisible = false;
                c.IsVisible = false;
                var d = a.Children[1];
                d.IsVisible = true;
                await d.FadeTo(1, 300, Easing.Linear);
                
            });

            Btn_Verificar_Codigo_Command = new Command(async(e)=> {
                var b = e as StackLayout;
                if(string.IsNullOrWhiteSpace(C1) || 
                string.IsNullOrWhiteSpace(C2) || 
                string.IsNullOrWhiteSpace(C3) || 
                string.IsNullOrWhiteSpace(C4) ||
                string.IsNullOrWhiteSpace(C5))
                {
                    await b.TranslateTo(25, 0, 30, Easing.Linear);
                    await b.TranslateTo(-25, 0, 30, Easing.Linear);
                    await b.TranslateTo(10, 0, 25, Easing.Linear);
                    await b.TranslateTo(-10, 0, 25, Easing.Linear);
                    await b.TranslateTo(5, 0, 25, Easing.Linear);
                    await b.TranslateTo(-5, 0, 25, Easing.Linear);
                    await b.TranslateTo(0, 0, 25, Easing.Linear);
                }
            });
        }


        public ICommand Btn_Enviar_Email_Command { get; set; }

        public ICommand Btn_Verificar_Codigo_Command { get; set; }

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
            get { return _C5; }
            set { SetProperty<string>(ref _C5, value, nameof(C5)); }
        }
    }
}
