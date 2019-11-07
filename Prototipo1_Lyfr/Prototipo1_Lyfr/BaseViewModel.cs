using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Prototipo1_Lyfr
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }
        protected bool SetProperty<T>(ref T storage, T value,[CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            else
            {
                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }
        }
        protected bool IsNullOrWhiteSpaceOrEmpty(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsNullOrWhiteSpaceOrEmpty(params string[] s)
        {
            for (short i = 0; i < s.Length; i++)
            {
                if (IsNullOrWhiteSpaceOrEmpty(s[i]))
                {
                    return true;
                }
            }
            return false;
        }
        protected bool EmailIsValid(string e)
        {
            return Regex.IsMatch(e,
                            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(50));
        }
        protected bool TelefoneIsValid(string t)
        {
            return Regex.IsMatch(t, @"(\(\d{2}\)\s)(\d{4,5}\-\d{4})$");
        }
        protected bool SenhaIsValid(string s)
        {
            bool Valido;
            if (!Regex.IsMatch(s, @"[A-Z]"))
            {
                Valido = false;
            }
            else if (!Regex.IsMatch(s, @"[@#%&_!?]"))
            {
                Valido = false;
            }
            else if (s.Length < 8)
            {
                Valido = false;
            }
            else
            {
                Valido = true;
            }

            return Valido;
        }
        protected async void ShakeShake(VisualElement v)
        {
            await v.TranslateTo(25, 0, 30, Easing.Linear);
            await v.TranslateTo(-25, 0, 30, Easing.Linear);
            await v.TranslateTo(10, 0, 30, Easing.Linear);
            await v.TranslateTo(-10, 0, 30, Easing.Linear);
            await v.TranslateTo(5, 0, 30, Easing.Linear);
            await v.TranslateTo(-5, 0, 30, Easing.Linear);
            await v.TranslateTo(0, 0, 30, Easing.Linear);
        }
    }
}
