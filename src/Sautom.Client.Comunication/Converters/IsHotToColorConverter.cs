using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace Sautom.Client.Comunication.Converters
{
    public class IsHotToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = System.Convert.ToBoolean(value);
            return val ? Color.Red : Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("One way only!");
        }
    }
}
