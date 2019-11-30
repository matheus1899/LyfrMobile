using Xamarin.Forms;
using Prototipo1_Lyfr.Models;
using System.Threading.Tasks;
using Prototipo1_Lyfr.ViewModels.Services;

namespace Prototipo1_Lyfr.Views.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoBack()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }
        public Task NavigateToAlterarEmail(Cliente c)
        {
            return App.Current.MainPage.Navigation.PushAsync(new AlterarEmail(c));
        }
        public void SetLoginMainPage()
        {
            App.Current.MainPage = new NavigationPage(new Login());
        }
        public Task NavigateToAlterarEndereco(Cliente c)
        {
            return App.Current.MainPage.Navigation.PushAsync(new AlterarEndereco(c));
        }
        public Task NavigateToAlterarSenha(Cliente c)
        {
            return App.Current.MainPage.Navigation.PushAsync(new AlterarSenha(c));
        }
        public Task NavigateToAlterarTelefone(Cliente c)
        {
            return App.Current.MainPage.Navigation.PushAsync(new AlterarTelefone(c));
        }

        public Task NavigateToMenuCapitulos(Livros l)
        {
            return App.Current.MainPage.Navigation.PushAsync(new MenuCapitulos(l));
        }
        public Task NavigateToInfoLivro(Livros l, Cliente c)
        {
            return App.Current.MainPage.Navigation.PushAsync(new InfoLivro(l, c));
        }
        public Task GoBackModal()
        {
            return App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
