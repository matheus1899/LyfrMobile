using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.TriggersAction
{
    public class PasswordValidationTriggerAction:TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            bool Valido;
            if (!Regex.IsMatch(sender.Text,@"[A-Z]"))
            {
                Valido = false;
            }
            else if (!Regex.IsMatch(sender.Text, @"[@#%&_!?]"))
            {
                Valido = false;
            }
            else if (sender.Text.Length<8)
            {
                Valido = false;
            }
            else
            {
                Valido = true;
            }

            sender.TextColor = Valido ? Color.Black : Color.Red;
        }
    }
}
