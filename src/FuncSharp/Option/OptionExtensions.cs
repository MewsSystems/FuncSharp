using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class OptionExtensions
    {
        /// <summary>
        /// Returns value of the option if it has value. If not, returns null.
        /// </summary>
        public static A GetOrNull<A>(this Option<A> option)
            where A : class
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns null.
        /// </summary>
        public static R GetOrNull<A, R>(this Option<A> option, Func<A, R> func)
            where R : class
        {
            return option.GetOrDefault(func);
        }


        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static int GetOrZero(this Option<int> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static int GetOrZero<A>(this Option<A> option, Func<A, int> func)

        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static decimal GetOrZero(this Option<decimal> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static decimal GetOrZero<A>(this Option<A> option, Func<A, decimal> func)

        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns false.
        /// </summary>
        public static bool GetOrFalse(this Option<bool> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns false.
        /// </summary>
        public static bool GetOrFalse<A>(this Option<A> option, Func<A, bool> func)

        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns the <paramref name="otherwise"/>.
        /// </summary>
        public static B GetOrElse<A, B>(this Option<A> option, B otherwise)
            where A : B
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            return otherwise;
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns value created by the otherwise function.
        /// </summary>
        public static B GetOrElse<A, B>(this Option<A> option, Func<Unit, B> otherwise)
            where A : B
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            return otherwise(Unit.Value);
        }

        /// <summary>
        /// Returns the option if it has value. Otherwise returns the alternative option.
        /// </summary>
        public static Option<B> OrElse<A, B>(this Option<A> option, Func<Unit, Option<B>> alternative)
            where A : B
        {
            if (option.NonEmpty)
            {
                return Option.Valued((B)option.GetOrDefault());
            }
            return alternative(Unit.Value);
        }

        /// <summary>
        /// Turns the option of nullable into an option.
        /// </summary>
        public static Option<A> Flatten<A>(this Option<A?> option)
            where A : struct
        {
            if (option.IsEmpty)
                return new Option<A>();

            return option.GetOrDefault().ToOption();
        }

        /// <summary>
        /// Returns the value of the outer option or an empty opion.
        /// </summary>
        public static Option<A> Flatten<A>(this Option<Option<A>> option)
        {
            if (option.IsEmpty)
                return new Option<A>();

            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty enumerable.
        /// </summary>
        public static IEnumerable<A> Flatten<T, A>(this Option<T> option)
            where T : IEnumerable<A>
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            return Enumerable.Empty<A>();
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<A>(this Option<A> option)
            where A : struct
        {
            if (option.NonEmpty)
                return option.GetOrDefault();

            return null;
        }
    }
}
