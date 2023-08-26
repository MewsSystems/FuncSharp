using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace FuncSharp
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a type-safe option of NonEmptyString in case the string is not empty nor whitespace.
        /// </summary>
        [Pure]
        public static IOption<NonEmptyString> AsNonEmpty(this string s)
        {
            return NonEmptyString.Create(s);
        }

        [Pure]
        public static IOption<byte> ToByte(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return byte.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<byte>();
        }

        [Pure]
        public static IOption<short> ToShort(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return short.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<short>();
        }

        [Pure]
        public static IOption<int> ToInt(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return int.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<int>();
        }

        [Pure]
        public static IOption<long> ToLong(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return long.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<long>();
        }

        [Pure]
        public static IOption<float> ToFloat(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return float.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<float>();
        }

        [Pure]
        public static IOption<double> ToDouble(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return double.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<double>();
        }

        [Pure]
        public static IOption<decimal> ToDecimal(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return decimal.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<decimal>();
        }

        [Pure]
        public static IOption<bool> ToBool(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return bool.TryParse(s, out var value)
                ? Option.Valued(value)
                : Option.Empty<bool>();
        }

        [Pure]
        public static IOption<DateTime> ToDateTime(this string s, IFormatProvider format = null, DateTimeStyles style = DateTimeStyles.None)
        {
            return DateTime.TryParse(s, format, style, out var value)
                ? Option.Valued(value)
                : Option.Empty<DateTime>();
        }

        [Pure]
        public static IOption<TimeSpan> ToTimeSpan(this string s, IFormatProvider format = null)
        {
            return TimeSpan.TryParse(s, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<TimeSpan>();
        }

        [Pure]
        public static IOption<TEnum> ToEnum<TEnum>(this string s, bool ignoreCase = false)
            where TEnum : struct
        {
            if (s is null || s.Contains(",") || !Enum.TryParse<TEnum>(s, ignoreCase, out var value))
            {
                return Option.Empty<TEnum>();
            }

            if (!Enum.IsDefined(typeof(TEnum), value) || !value.ToString().Equals(s, StringComparison.InvariantCultureIgnoreCase))
            {
                return Option.Empty<TEnum>();
            }

            return Option.Valued(value);
        }

        [Pure]
        public static IOption<Guid> ToGuid(this string s)
        {
            return Guid.TryParse(s, out var value)
                ? Option.Valued(value)
                : Option.Empty<Guid>();
        }

        [Pure]
        public static IOption<Guid> ToGuidExact(this string s, string format = "D")
        {
            return Guid.TryParseExact(s, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<Guid>();
        }
    }
}
