using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Prototipo1_Lyfr.Controls;
using Android.Graphics.Drawables;
using Prototipo1_Lyfr.Droid.ControlHelpers;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(NewEntryRenderer),typeof(NewEntry))]
namespace Prototipo1_Lyfr.Droid.ControlHelpers
{
    [Obsolete]
    public class NewEntryRenderer:EntryRenderer
    {
        //NewEntryRenderer(Context context):base(context){}
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradient = new GradientDrawable();
                gradient.SetColor(Color.White);
                gradient.SetCornerRadius(60f);
                gradient.SetStroke(10, Color.DarkRed);
                Control.SetBackground(gradient);
                Control.SetHighlightColor(Color.Red);
                Control.SetTextColor(Color.Blue);
                Control.SetHintTextColor(Color.Indigo);
                Control.SetPadding(50,Control.PaddingTop,Control.PaddingRight, Control.PaddingBottom);
            }
        }
    }
}