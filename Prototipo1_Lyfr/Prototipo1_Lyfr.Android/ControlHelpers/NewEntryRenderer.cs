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
                
            }
        }
    }
}