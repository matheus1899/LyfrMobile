using Xamarin.Forms;

namespace Prototipo1_Lyfr.Controls
{
    public class NewFrame:Frame,IBorderElement
    {
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create("BorderWidth", typeof(double), typeof(NewFrame), -1d);
        double IBorderElement.BorderWidthDefaultValue => -1d;
        public double BorderWidth
        {
            get { return (double)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        bool IBorderElement.IsBorderWidthSet() => IsSet(BorderWidthProperty);
    }
}
