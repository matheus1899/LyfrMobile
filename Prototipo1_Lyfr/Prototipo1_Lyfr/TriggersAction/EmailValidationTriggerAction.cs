using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.TriggersAction
{
    public class EmailValidationTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            bool Valido;
            Valido = Regex.IsMatch(sender.Text,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(50));
            sender.TextColor = Valido ? Color.Black : Color.Red;
        }
    }
}
