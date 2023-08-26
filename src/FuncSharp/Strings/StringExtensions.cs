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
        public static Option<NonEmptyString> AsNonEmpty(this string s)
        {
            return NonEmptyString.Create(s);
        }

        [Pure]
        public static Option<byte> ToByte(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return byte.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<byte>();
        }

        [Pure]
        public static Option<short> ToShort(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return short.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<short>();
        }

        [Pure]
        public static Option<int> ToInt(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return int.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<int>();
        }

        [Pure]
        public static Option<long> ToLong(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return long.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<long>();
        }

        [Pure]
        public static Option<float> ToFloat(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return float.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<float>();
        }

        [Pure]
        public static Option<double> ToDouble(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return double.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<double>();
        }

        [Pure]
        public static Option<decimal> ToDecimal(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return decimal.TryParse(s, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<decimal>();
        }

        [Pure]
        public static Option<bool> ToBool(this string s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return bool.TryParse(s, out var value)
                ? Option.Valued(value)
                : Option.Empty<bool>();
        }

        [Pure]
        public static Option<DateTime> ToDateTime(this string s, IFormatProvider format = null, DateTimeStyles style = DateTimeStyles.None)
        {
            return DateTime.TryParse(s, format, style, out var value)
                ? Option.Valued(value)
                : Option.Empty<DateTime>();
        }

        [Pure]
        public static Option<TimeSpan> ToTimeSpan(this string s, IFormatProvider format = null)
        {
            return TimeSpan.TryParse(s, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<TimeSpan>();
        }

        [Pure]
        public static Option<TEnum> ToEnum<TEnum>(this string s, bool ignoreCase = false)
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
        public static Option<Guid> ToGuid(this string s)
        {
            return Guid.TryParse(s, out var value)
                ? Option.Valued(value)
                : Option.Empty<Guid>();
        }

        [Pure]
        public static Option<Guid> ToGuidExact(this string s, string format = "D")
        {
            return Guid.TryParseExact(s, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<Guid>();
        }
    }
}
