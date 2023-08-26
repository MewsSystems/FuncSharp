using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace FuncSharp
{
    public static class NonEmptyStringExtensions
    {
        [Pure]
        public static bool SafeEquals(this NonEmptyString value, string other)
        {
            if (value is null)
                return other is null;
            return value.Value.SafeEquals(other);
        }

        [Pure]
        public static bool SafeNotEquals(this NonEmptyString value, string other)
        {
            if (value is null)
                return other is not null;
            return value.Value.SafeNotEquals(other);
        }

        [Pure]
        public static string SafeSubstring(this NonEmptyString s, int length)
        {
            return s?.Substring(length);
        }

        [Pure]
        public static string SafeSubstring(this NonEmptyString s, int start, int length)
        {
            return s?.Substring(start, length);
        }

        [Pure]
        public static string GetOrElse(this IOption<NonEmptyString> option, string otherwise)
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            else
            {
                return otherwise;
            }
        }

        [Pure]
        public static string GetOrElse(this IOption<NonEmptyString> option, Func<Unit, string> otherwise)
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            else
            {
                return otherwise(Unit.Value);
            }
        }

        [Pure]
        public static string GetOrElse(this IOption<string> option, NonEmptyString otherwise)
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            else
            {
                return otherwise;
            }
        }

        [Pure]
        public static string GetOrElse(this IOption<string> option, Func<Unit, NonEmptyString> otherwise)
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            else
            {
                return otherwise(Unit.Value);
            }
        }

        [Pure]
        public static IOption<string> OrElse(this IOption<NonEmptyString> option, IOption<string> otherwise)
        {
            if (option.NonEmpty)
            {
                return option.Map(v => v.Value);
            }
            else
            {
                return otherwise;
            }
        }

        [Pure]
        public static IOption<string> OrElse(this IOption<NonEmptyString> option, Func<Unit, IOption<string>> otherwise)
        {
            if (option.NonEmpty)
            {
                return option.Map(v => v.Value);
            }
            else
            {
                return otherwise(Unit.Value);
            }
        }

        [Pure]
        public static IOption<string> OrElse(this IOption<string> option, IOption<NonEmptyString> otherwise)
        {
            if (option.NonEmpty)
            {
                return option;
            }
            else
            {
                return otherwise.Map(o => o.Value);
            }
        }

        [Pure]
        public static IOption<string> OrElse(this IOption<string> option, Func<Unit, IOption<NonEmptyString>> otherwise)
        {
            if (option.NonEmpty)
            {
                return option;
            }
            else
            {
                return otherwise(Unit.Value).Map(o => o.Value);
            }
        }

        [Pure]
        public static IOption<byte> ToByte(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return byte.TryParse(s.Value, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<byte>();
        }

        [Pure]
        public static IOption<short> ToShort(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return short.TryParse(s.Value, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<short>();
        }

        [Pure]
        public static IOption<int> ToInt(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return int.TryParse(s.Value, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<int>();
        }

        [Pure]
        public static IOption<long> ToLong(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return long.TryParse(s.Value, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<long>();
        }

        [Pure]
        public static IOption<float> ToFloat(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return float.TryParse(s.Value, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<float>();
        }

        [Pure]
        public static IOption<double> ToDouble(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return double.TryParse(s.Value, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<double>();
        }

        [Pure]
        public static IOption<decimal> ToDecimal(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return decimal.TryParse(s.Value, style, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<decimal>();
        }

        [Pure]
        public static IOption<bool> ToBool(this NonEmptyString s)
        {
            return bool.TryParse(s.Value, out var value)
                ? Option.Valued(value)
                : Option.Empty<bool>();
        }

        [Pure]
        public static IOption<DateTime> ToDateTime(this NonEmptyString s, IFormatProvider format = null, DateTimeStyles style = DateTimeStyles.None)
        {
            return DateTime.TryParse(s.Value, format, style, out var value)
                ? Option.Valued(value)
                : Option.Empty<DateTime>();
        }

        [Pure]
        public static IOption<TimeSpan> ToTimeSpan(this NonEmptyString s, IFormatProvider format = null)
        {
            return TimeSpan.TryParse(s.Value, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<TimeSpan>();
        }

        [Pure]
        public static IOption<TEnum> ToEnum<TEnum>(this NonEmptyString s, bool ignoreCase = false)
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
        public static IOption<Guid> ToGuid(this NonEmptyString s)
        {
            return Guid.TryParse(s.Value, out var value)
                ? Option.Valued(value)
                : Option.Empty<Guid>();
        }

        [Pure]
        public static IOption<Guid> ToGuidExact(this NonEmptyString s, string format = "D")
        {
            return Guid.TryParseExact(s, format, out var value)
                ? Option.Valued(value)
                : Option.Empty<Guid>();
        }
    }
}
