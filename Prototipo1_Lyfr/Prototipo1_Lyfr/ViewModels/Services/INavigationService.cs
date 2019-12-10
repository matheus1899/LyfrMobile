using Prototipo1_Lyfr.Models;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.ViewModels.Services
{
    public interface INavigationService
    {
        Task GoBack();
        Task GoBackModal();
        void SetLoginMainPage();
        Task NavigateToAlterarSenha(Cliente c);
        Task NavigateToAlterarEmail(Cliente c);
        Task NavigateToMenuCapitulos(Livros l);
        Task NavigateToInfoLivro(Livros l, Cliente c);
    }
}

