using Prototipo1_Lyfr.Models;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.ViewModels.Services
{
    public interface INavigationService
    {
        Task GoBack();
        void SetLoginMainPage();
        Task NavigateToAlterarSenha(Cliente c);
        Task NavigateToAlterarEmail(Cliente c);
        Task NavigateToAlterarTelefone(Cliente c);
        Task NavigateToAlterarEndereco(Cliente c);
        Task NavigateToMenuCapitulos(string titulo);
    }
}

