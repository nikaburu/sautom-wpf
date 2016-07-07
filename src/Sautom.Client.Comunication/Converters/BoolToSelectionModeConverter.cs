using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace Sautom.Client.Comunication.Converters
{
    public class BoolToSelectionModeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return (bool)value ? SelectionMode.Single : SelectionMode.Multiple;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
