using System.ComponentModel;
using System.Windows.Input;
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
                SetProperty<string>(ref _email, value, nameof(Email));
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
                SetProperty<string>(ref _senha, value, nameof(Senha));
            }
        }

        public ICommand Next_Entry_Command {private set; get;}

        public LoginViewModel()
        {
            Next_Entry_Command = new Command((e) => {
                var a = e as Entry;
                a.Focus();
            });
        }

    }
}
