using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.Controls
{
    public class PhoneNumberValidatorBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += onTextChanged;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= onTextChanged;

            base.OnDetachingFrom(bindable);
        }

        void onTextChanged(object sender, TextChangedEventArgs args)
        {
            var isValid = isValidPhoneNumber(args.NewTextValue);

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }

        private bool isValidPhoneNumber(string input)
        {
            var digitsRegex = new Regex(@"[^\d]");
            var digits = digitsRegex.Replace(input, "");

            return digits.Length == 10;
        }
    }
}
