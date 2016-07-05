using System;
using System.Text;

namespace Sautom.DataAccess.Helpers
{
    /// <summary>
    /// A set of C# methods for spelling Russian numerics 
    /// http://www.gotdotnet.ru/blogs/avk/928/
    /// Copyright (c) 2002-2008 Rsdn Group
    /// </summary>
    public static class RusNumber
    {
	    private static readonly string[] Frac20Male =
            {
                 "", "один", "два", "три", "четыре", "пять", "шесть",
                 "семь", "восемь", "девять", "десять", "одиннадцать",
                 "двенадцать", "тринадцать", "четырнадцать", "пятнадцать",
                 "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
             };

	    private static readonly string[] Frac20Female =
            {
                 "", "одна", "две", "три", "четыре", "пять", "шесть",
                 "семь", "восемь", "девять", "десять", "одиннадцать",
                 "двенадцать", "тринадцать", "четырнадцать", "пятнадцать",
                 "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
             };

	    private static readonly string[] Hunds =
             {
                 "", "сто", "двести", "триста", "четыреста",
                 "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот"
             };

	    private static readonly string[] Tens =
             {
                 "", "десять", "двадцать", "тридцать", "сорок", "пятьдесят",
                 "шестьдесят", "семьдесят", "восемьдесят", "девяносто"
             };

	    public static string RusSpelledOut(
            this decimal value,
            bool male)
        {
            if (value >= 1000000000000000)
                throw new ArgumentOutOfRangeException(nameof(value));

            StringBuilder str = new StringBuilder();

            if (value < 0)
            {
                str.Append("минус");
                value = -value;
            }

            value = value
                .AppendPeriod(1000000000000, str, "триллион", "триллиона", "триллионов", true)
                .AppendPeriod(1000000000, str, "миллиард", "миллиарда", "миллиардов", true)
                .AppendPeriod(1000000, str, "миллион", "миллиона", "миллионов", true)
                .AppendPeriod(1000, str, "тысяча", "тысячи", "тысяч", false);

            int hundreds = (int)(value / 100);
            if (hundreds != 0)
                str.AppendWithSpace(Hunds[hundreds]);

            int less100 = (int)(value % 100);
            string[] frac20 = male ? Frac20Male : Frac20Female;
            if (less100 < 20)
                str.AppendWithSpace(frac20[less100]);
            else
            {
                int tens = less100 / 10;
                str.AppendWithSpace(Tens[tens]);
                int less10 = less100 % 10;
                if (less10 != 0)
                    str.Append(" " + frac20[less100 % 10]);
            }

            return str.ToString();
        }

	    private static void AppendWithSpace(this StringBuilder stringBuilder, string str)
        {
            if (stringBuilder.Length > 0)
                stringBuilder.Append(" ");
            stringBuilder.Append(str);
        }

	    private static decimal AppendPeriod(
            this decimal value,
            long power,
            StringBuilder str,
            string declension1,
            string declension2,
            string declension5,
            bool male)
        {
            int thousands = (int)(value / power);
            if (thousands > 0)
            {
                str.AppendWithSpace(
                    ((decimal)thousands).RusSpelledOut(male, declension1, declension2, declension5));
                return value % power;
            }
            return value;
        }

	    public static string RusSpelledOut(
            this decimal value,
            bool male,
            string valueDeclensionFor1,
            string valueDeclensionFor2,
            string valueDeclensionFor5)
        {
            return
                RusSpelledOut(value, male)
                    + " "
                    + ((int)(value % 10)).GetDeclension(valueDeclensionFor1, valueDeclensionFor2, valueDeclensionFor5);
        }

	    public static string GetDeclension(this int val, string one, string two, string five)
        {
            int t = val % 100 > 20 ? val % 10 : val % 20;

            switch (t)
            {
                case 1:
                    return one;
                case 2:
                case 3:
                case 4:
                    return two;
                default:
                    return five;
            }
        }
    }
}