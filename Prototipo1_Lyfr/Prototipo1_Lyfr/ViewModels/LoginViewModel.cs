using System.ComponentModel;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty<string>(ref _email, value, "Email");
            }
        }

        private string _senha;
        public string Senha
        {
            get
            {
                return _senha;
            }
            set
            {
                SetProperty<string>(ref _senha, value, "Senha");
            }
        }
    }
}
