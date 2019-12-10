using Xamarin.Forms;

namespace Prototipo1_Lyfr.Controls
{
    public class MostrarMensagem
    {
        //Declara o metódo que coloca um Toast 
        public static void Mostrar(string mensagem)
        {
            MessagingCenter.Send(mensagem, "Mensagem");
        }
    }
}
