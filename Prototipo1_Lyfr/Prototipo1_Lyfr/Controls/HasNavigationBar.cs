
using Xamarin.Forms;

namespace Prototipo1_Lyfr.Controls
{
    public class HasNavigationBar
    {
        public static void SetHasNavigationBar(string mensagem)
        {
            MessagingCenter.Send(mensagem,"Teste");
        }
    }
}
