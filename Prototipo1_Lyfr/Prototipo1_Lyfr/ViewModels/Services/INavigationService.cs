using System.Threading.Tasks;

namespace Prototipo1_Lyfr.ViewModels.Services
{
    public interface INavigationService
    {
        Task GoBack();
        void SetLoginMainPage();
        Task NavigateToAlterarSenha(object o);
        Task NavigateToAlterarEmail();
        Task NavigateToAlterarTelefone();
        Task NavigateToAlterarEndereco();
    }
}
