﻿using System;
using System.Windows.Data;

namespace Sautom.Client.Comunication.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class TypeToStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
