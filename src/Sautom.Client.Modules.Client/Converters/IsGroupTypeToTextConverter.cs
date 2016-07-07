using System;
using System.Globalization;
using System.Windows.Data;

namespace Sautom.Client.Modules.Client.Converters
{
    public class IsGroupTypeToTextConverter : IValueConverter
    {
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = System.Convert.ToBoolean(value);
            //return val ? ProposalResources.ProposalGroupTypeLabel : ProposalResources.ProposalIndividualTypeLabel;
	        return "";
        }

	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}