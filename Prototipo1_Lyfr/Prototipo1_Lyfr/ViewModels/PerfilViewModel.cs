using Prototipo1_Lyfr.Models;

namespace Prototipo1_Lyfr.ViewModels
{
    public class PerfilViewModel : BaseViewModel
    {
        private string _Plano;
        private string _Nome;
        private string _Telefone;
        private string _Rua;
        private string _Numero;
        private string _Cidade;
        private string _Estado;
        private string _Email;
        private string _Senha;

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

        public PerfilViewModel(Cliente cliente)
        {
            Plano = cliente.Plano == "P" ? "Premium" : "Gratuito";
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
