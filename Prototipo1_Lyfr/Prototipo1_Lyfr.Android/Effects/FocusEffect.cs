using Prototipo1_Lyfr.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ResolutionGroupName("Focus")]
[assembly: ExportEffect(typeof(FocusEffect),"FocusEffect")]
namespace Prototipo1_Lyfr.Droid.Effects
{
    public class FocusEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            Control.SetBackgroundColor(Color.Transparent);
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            //if (args.PropertyName == "IsFocused")
        }
    }
}