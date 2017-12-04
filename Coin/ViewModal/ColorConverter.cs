using System;
using System.Globalization;
using Xamarin.Forms;

namespace Coin
{
    public class ColorConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = int.Parse((string)value);
            if(number % 2 == 0 )
            {
                return Color.White;
            }
            else
            {
                return Color.Blue;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
