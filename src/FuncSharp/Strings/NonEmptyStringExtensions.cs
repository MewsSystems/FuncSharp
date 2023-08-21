using System;
using System.Globalization;

namespace FuncSharp
{
    public static class NonEmptyStringExtensions
    {
        public static bool SafeEquals(this NonEmptyString value, string other)
        {
            if (value is null)
                return other is null;
            return value.Value.SafeEquals(other);
        }

        public static bool SafeNotEquals(this NonEmptyString value, string other)
        {
            if (value is null)
                return other is not null;
            return value.Value.SafeNotEquals(other);
        }

        public static string SafeSubstring(this NonEmptyString s, int length)
        {
            return s?.Substring(length);
        }

        public static string SafeSubstring(this NonEmptyString s, int start, int length)
        {
            return s?.Substring(start, length);
        }

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

        public static IOption<byte> ToByte(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return Tryer.Invoke<string, NumberStyles, IFormatProvider, byte>(Byte.TryParse, s, style, format);
        }

        public static IOption<short> ToShort(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return Tryer.Invoke<string, NumberStyles, IFormatProvider, short>(Int16.TryParse, s, style, format);
        }

        public static IOption<int> ToInt(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return Tryer.Invoke<string, NumberStyles, IFormatProvider, int>(Int32.TryParse, s, style, format);
        }

        public static IOption<long> ToLong(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Integer)
        {
            return Tryer.Invoke<string, NumberStyles, IFormatProvider, long>(Int64.TryParse, s, style, format);
        }

        public static IOption<float> ToFloat(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return Tryer.Invoke<string, NumberStyles, IFormatProvider, float>(Single.TryParse, s, style, format);
        }

        public static IOption<double> ToDouble(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            return Tryer.Invoke<string, NumberStyles, IFormatProvider, double>(Double.TryParse, s, style, format);
        }

        public static IOption<decimal> ToDecimal(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return Tryer.Invoke<string, NumberStyles, IFormatProvider, decimal>(Decimal.TryParse, s, style, format);
        }

        public static IOption<bool> ToBool(this NonEmptyString s, IFormatProvider format = null, NumberStyles style = NumberStyles.Number)
        {
            return Tryer.Invoke<string, bool>(Boolean.TryParse, s);
        }

        public static IOption<DateTime> ToDateTime(this NonEmptyString s, IFormatProvider format = null, DateTimeStyles style = DateTimeStyles.None)
        {
            return Tryer.Invoke<string, IFormatProvider, DateTimeStyles, DateTime>(DateTime.TryParse, s, format, style);
        }

        public static IOption<TimeSpan> ToTimeSpan(this NonEmptyString s, IFormatProvider format = null)
        {
            return Tryer.Invoke<string, IFormatProvider, TimeSpan>(TimeSpan.TryParse, s, format);
        }

        public static IOption<TEnum> ToEnum<TEnum>(this NonEmptyString s, bool ignoreCase = false)
            where TEnum : struct
        {
            if (s == null || s.Value.Contains(","))
            {
                return Option.Empty<TEnum>();
            }
            var enumValue = Tryer.Invoke<string, bool, TEnum>(Enum.TryParse<TEnum>, s, ignoreCase);
            return enumValue.Where(v => Enum.IsDefined(typeof(TEnum), v) && v.ToString().Equals(s, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IOption<Guid> ToGuid(this NonEmptyString s)
        {
            return Tryer.Invoke<string, Guid>(Guid.TryParse, s);
        }

        public static IOption<Guid> ToGuidExact(this NonEmptyString s, string format = "D")
        {
            return Tryer.Invoke<string, string, Guid>(Guid.TryParseExact, s, format);
        }
    }
}
