using Xamarin.Forms;

namespace Prototipo1_Lyfr.TriggersAction
{
    public class NextEntryTriggerAction : TriggerAction<Entry>
    {
        private Entry _nextEntry;
        private Entry _prevEntry;

        public Entry NextEntry
        {
            get
            {
                return (Entry)_nextEntry;
            }
            set
            {
                _nextEntry = value;
            }
        }
        public Entry PrevEntry
        {
            get
            {
                return (Entry)_prevEntry;
            }
            set
            {
                _prevEntry = value;
            }
        }
        protected override void Invoke(Entry sender)
        {
            var a = sender as Entry;
            if (a==null)
            {
                a.Focus();
                return;
            }
            
            if (a.Text.Length == 1)
            {
                if (_nextEntry==null)
                {
                    return;
                }
                else
                {
                    _nextEntry.Focus();
                }
            }
            else if(a.Text.Length==0)
            {
                if (_prevEntry==null)
                {
                    return;
                }
                else
                {
                    _prevEntry.Focus();
                }
            }
        }
    }
}
