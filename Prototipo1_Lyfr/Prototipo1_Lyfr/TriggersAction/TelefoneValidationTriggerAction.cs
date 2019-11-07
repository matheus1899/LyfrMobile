using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.TriggersAction
{
    public class TelefoneValidationTriggerAction: TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            bool Valido;
            Valido = Regex.IsMatch(sender.Text, @"(\(\d{2}\)\s)(\d{4,5}\-\d{4})$");
            sender.TextColor = Valido ? Color.Black : Color.Red;
        }
    }
}
