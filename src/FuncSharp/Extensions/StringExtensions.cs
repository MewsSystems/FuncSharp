using System;
using System.Globalization;

namespace FuncSharp
{
    public static class StringExtensions
    {
        public static IOption<byte> ToByte(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return new TryParser<byte, NumberStyles, IFormatProvider>(Byte.TryParse).ToOption(s, style, format);
        }

        public static IOption<short> ToShort(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return new TryParser<short, NumberStyles, IFormatProvider>(Int16.TryParse).ToOption(s, style, format);
        }

        public static IOption<int> ToInt(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return new TryParser<int, NumberStyles, IFormatProvider>(Int32.TryParse).ToOption(s, style, format);
        }

        public static IOption<long> ToLong(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return new TryParser<long, NumberStyles, IFormatProvider>(Int64.TryParse).ToOption(s, style, format);
        }

        public static IOption<float> ToFloat(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return new TryParser<float, NumberStyles, IFormatProvider>(Single.TryParse).ToOption(s, style, format);
        }

        public static IOption<double> ToDouble(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return new TryParser<double, NumberStyles, IFormatProvider>(Double.TryParse).ToOption(s, style, format);
        }

        public static IOption<decimal> ToDecimal(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return new TryParser<decimal, NumberStyles, IFormatProvider>(Decimal.TryParse).ToOption(s, style, format);
        }

        public static IOption<bool> ToBool(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return new TryParser<bool>(Boolean.TryParse).ToOption(s);
        }

        public static IOption<DateTime> ToDateTime(this string s, IFormatProvider format = null, DateTimeStyles style = DateTimeStyles.None)
        {
            return new TryParser<DateTime, IFormatProvider, DateTimeStyles>(DateTime.TryParse).ToOption(s, format, style);
        }

        public static IOption<TimeSpan> ToTimeSpan(this string s, IFormatProvider format = null)
        {
            return new TryParser<TimeSpan, IFormatProvider>(TimeSpan.TryParse).ToOption(s, format);
        }

        public static IOption<TEnum> ToEnum<TEnum>(this string s, bool ignoreCase = false)
            where TEnum : struct
        {
            return new TryParser<TEnum, bool>(Enum.TryParse<TEnum>).ToOption(s, ignoreCase);
        }

        public static IOption<Guid> ToGuid(this string s)
        {
            return new TryParser<Guid>(Guid.TryParse).ToOption(s);
        }
    }
}
