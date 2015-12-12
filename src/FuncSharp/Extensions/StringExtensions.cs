using System;
using System.Globalization;

namespace FuncSharp
{
    public static class StringExtensions
    {
        public static IOption<byte> ToByte(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return new Tryer<string, NumberStyles, IFormatProvider, byte>(Byte.TryParse).Invoke(s, style, format);
        }

        public static IOption<short> ToShort(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return new Tryer<string, NumberStyles, IFormatProvider, short>(Int16.TryParse).Invoke(s, style, format);
        }

        public static IOption<int> ToInt(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return new Tryer<string, NumberStyles, IFormatProvider, int>(Int32.TryParse).Invoke(s, style, format);
        }

        public static IOption<long> ToLong(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return new Tryer<string, NumberStyles, IFormatProvider, long>(Int64.TryParse).Invoke(s, style, format);
        }

        public static IOption<float> ToFloat(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return new Tryer<string, NumberStyles, IFormatProvider, float>(Single.TryParse).Invoke(s, style, format);
        }

        public static IOption<double> ToDouble(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return new Tryer<string, NumberStyles, IFormatProvider, double>(Double.TryParse).Invoke(s, style, format);
        }

        public static IOption<decimal> ToDecimal(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return new Tryer<string, NumberStyles, IFormatProvider, decimal>(Decimal.TryParse).Invoke(s, style, format);
        }

        public static IOption<bool> ToBool(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return new Tryer<string, bool>(Boolean.TryParse).Invoke(s);
        }

        public static IOption<DateTime> ToDateTime(this string s, IFormatProvider format = null, DateTimeStyles style = DateTimeStyles.None)
        {
            return new Tryer<string, IFormatProvider, DateTimeStyles, DateTime>(DateTime.TryParse).Invoke(s, format, style);
        }

        public static IOption<TimeSpan> ToTimeSpan(this string s, IFormatProvider format = null)
        {
            return new Tryer<string, IFormatProvider, TimeSpan>(TimeSpan.TryParse).Invoke(s, format);
        }

        public static IOption<TEnum> ToEnum<TEnum>(this string s, bool ignoreCase = false)
            where TEnum : struct
        {
            return new Tryer<string, bool, TEnum>(Enum.TryParse<TEnum>).Invoke(s, ignoreCase);
        }

        public static IOption<Guid> ToGuid(this string s)
        {
            return new Tryer<string, Guid>(Guid.TryParse).Invoke(s);
        }
    }
}
