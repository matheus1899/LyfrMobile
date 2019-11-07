using System.Threading.Tasks;
using Prototipo1_Lyfr.ViewModels.Services;

namespace Prototipo1_Lyfr.Views.Services
{
    public class MessageService : IMessageService
    {
        public Task ShowMessage(string title, string message, string cancel)
        {
            return App.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
