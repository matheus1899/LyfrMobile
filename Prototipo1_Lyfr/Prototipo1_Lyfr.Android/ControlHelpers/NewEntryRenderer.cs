using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Prototipo1_Lyfr.Controls;
using Android.Graphics;
using Prototipo1_Lyfr.Droid.ControlHelpers;
using Color = Android.Graphics.Color;
using Android.Content;

[assembly: ExportRenderer(typeof(NewEntryRenderer),typeof(NewEntry))]
namespace Prototipo1_Lyfr.Droid.ControlHelpers
{
    public class NewEntryRenderer:EntryRenderer
    {
        NewEntryRenderer(Context context):base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                //var gradient = new GradientDrawable();
                //gradient.SetColor(Color.White);
                //gradient.SetCornerRadius(60f);
                //gradient.SetStroke(10, Color.DarkRed);
                //Control.SetBackground(gradient);
                //Control.SetHighlightColor(Color.Red);
                //Control.SetTextColor(Color.Blue);
                //Control.SetHintTextColor(Color.Indigo);
                //Control.SetPadding(50,Control.PaddingTop,Control.PaddingRight, Control.PaddingBottom);
                //Control.Background.SetColorFilter(Color.Transparent,PorterDuff.Mode.SrcAtop);
                //Control.Background = null;
                //var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                //layoutParams.SetMargins(0, 0, 0, 0);
                //LayoutParameters = layoutParams;
                //Control.LayoutParameters = layoutParams;
                //Control.SetPadding(0, 0, 0, 0);
                //SetPadding(0, 0, 0, 0);
            }
        }
    }
}