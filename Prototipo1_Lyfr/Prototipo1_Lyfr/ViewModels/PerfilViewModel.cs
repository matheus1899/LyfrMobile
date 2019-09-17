using Prototipo1_Lyfr.Models;

namespace Prototipo1_Lyfr.ViewModels
{
    public class PerfilViewModel : BaseViewModel
    {
        private string _Plano;
        private string _Nome;
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

        public PerfilViewModel(Cliente cliente)
        {
            Plano = cliente.Plano == "P" ? "Premium" : "Gratuito";
            Nome = cliente.Nome;
        }
    }
}
