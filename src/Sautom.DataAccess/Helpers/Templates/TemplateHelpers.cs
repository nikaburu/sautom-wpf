using System;
using System.Linq;

namespace Sautom.DataAccess.Helpers.Templates
{
    static class TemplateHelpers
    {
	    public static readonly Func<float, string> SumToText =
            sum =>
	            $"{sum} ({((decimal) sum).RusSpelledOut(true)})";

	    public static readonly Func<DateTime, string> DateToText =
            date => date.Date.ToString("«dd» MMMM yyyy г.");

	    //string.Format("«{0}» {1} {2}г.", );

	    public static readonly Func<float, string> HoursToText =
            hours => $"{hours} ({HoursTextFormater(hours)})";

	    public static readonly Func<string, string> NameToShort =
            name =>
	            $"{name.Split(' ').First()} {name.Split(' ')[1].First()}. {name.Split(' ')[2].First()}.";

	    public static string HoursTextFormater(float count)
        {
            if (count > 20)
            {
                return HoursTextFormater(count % 10);
            }

            if (Math.Abs(count - 0) < 0.001 || (count >= 5 && count <= 20))
            {
                return "часов";
            }
            if (Math.Abs(count - 1) < 0.001)
            {
                return "час";
            }

            if (count < 1)
            {
                return "часа";
            }

            return "часа";
        }
    }
}
