using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Sautom.Client.Comunication.Events;

namespace Sautom.Client.Ui.Converters
{
    public class NortificationTypeToSourceConverter : IValueConverter
    {
	    public Dictionary<NortificationType, string> Pathes = new Dictionary<NortificationType, string>
	    {
                                                                      {NortificationType.Information, @"..\Images\msgBoxIcons\infoIcon.png"},
                                                                      {NortificationType.Warning, @".\Images\msgBoxIcons\warningIcon.png"},
                                                                      {NortificationType.Error, @"..\Images\msgBoxIcons\errorIcon.png"}
                                                                  };

	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Pathes[(NortificationType) value];
        }

	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Only one way");
        }
    }
}