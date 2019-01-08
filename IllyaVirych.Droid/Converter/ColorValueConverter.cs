using System.Globalization;
using MvvmCross.Plugin.Color;
using MvvmCross.UI;

namespace IllyaVirych.Droid.Converter
{
    public class ColorValueConverter : MvxColorValueConverter<bool>
    {
        protected override MvxColor Convert(bool value, object parameter, CultureInfo culture)
        {
            //var color = Color.Rgb(value.R, value.G, value.B);
            //var drawable = new ColorDrawable(color);
            return value ? new MvxColor(0, 128, 0, 255) : new MvxColor(255, 255, 0, 255);
        }
    }
}