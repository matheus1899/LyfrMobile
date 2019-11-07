using System.Threading.Tasks;
using Prototipo1_Lyfr.ViewModels.Services;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.Views.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoBack()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }
        public Task NavigateToAlterarEmail()
        {
            throw new System.NotImplementedException();
        }
        public void SetLoginMainPage()
        {
            App.Current.MainPage = new NavigationPage(new Login());
        }
        public Task NavigateToAlterarEndereco()
        {
            throw new System.NotImplementedException();
        }

        public Task NavigateToAlterarSenha(object o)
        {
            return App.Current.MainPage.Navigation.PushAsync(new AlterarSenha(o));
        }

        public Task NavigateToAlterarTelefone()
        {
            throw new System.NotImplementedException();
        }
    }
}
