using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class IOptionExtensions
    {
        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<A>(this IOption<A> option)
            where A : struct
        {
            if (option.NonEmpty)
                return option.GetOrDefault();
            return null;
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<A>(this IOption<A?> option)
            where A : struct
        {
            if (option.NonEmpty)
                return option.GetOrDefault();
            return null;
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static B? ToNullable<A, B>(this IOption<A> option, Func<A, B?> func)
            where B : struct
        {
            if (option.NonEmpty)
                return func(option.GetOrDefault());
            return null;
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static B? ToNullable<A, B>(this IOption<A> option, Func<A, B> func)
            where B : struct
        {
            if (option.NonEmpty)
                return func(option.GetOrDefault());
            return null;
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns null.
        /// </summary>
        public static T GetOrNull<T>(this IOption<T> option)
            where T : class
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns null.
        /// </summary>
        public static R GetOrNull<T, R>(this IOption<T> option, Func<T, R> func)
            where R : class
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static short GetOrZero(this IOption<short> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static short GetOrZero<T>(this IOption<T> option, Func<T, short> func)
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static int GetOrZero(this IOption<int> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static int GetOrZero<T>(this IOption<T> option, Func<T, int> func)
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static long GetOrZero(this IOption<long> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static long GetOrZero<T>(this IOption<T> option, Func<T, long> func)
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static decimal GetOrZero(this IOption<decimal> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static decimal GetOrZero<T>(this IOption<T> option, Func<T, decimal> func)
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static double GetOrZero(this IOption<double> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static double GetOrZero<T>(this IOption<T> option, Func<T, double> func)
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns false.
        /// </summary>
        public static bool GetOrFalse(this IOption<bool> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns false.
        /// </summary>
        public static bool GetOrFalse<T>(this IOption<T> option, Func<T, bool> func)
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns the <paramref name="otherwise"/>.
        /// </summary>
        public static B GetOrElse<A, B>(this IOption<A> option, B otherwise)
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
        public static B GetOrElse<A, B>(this IOption<A> option, Func<Unit, B> otherwise)
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
        public static IOption<B> OrElse<A, B>(this IOption<A> option, Func<Unit, IOption<B>> alternative)
            where A : B
        {
            if (option.NonEmpty)
            {
                return (IOption<B>)option;
            }
            return alternative(Unit.Value);
        }

        /// <summary>
        /// Returns the value of the outer option or an empty opion.
        /// </summary>
        public static IOption<A> Flatten<A>(this IOption<IOption<A>> option)
        {
            return option.FlatMap(o => o);
        }

        /// <summary>
        /// Turns the option of nullable into an option.
        /// </summary>
        public static IOption<A> Flatten<A>(this IOption<A?> option)
            where A : struct
        {
            return option.FlatMap(a => a.ToOption());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty enumerable.
        /// </summary>
        public static IEnumerable<A> Flatten<A>(this IOption<IEnumerable<A>> option)
        {
            return option.GetOrElse(_ => Enumerable.Empty<A>());
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and
        /// returns a new option with that new value.
        /// </summary>
        public static IOption<B> Select<A, B>(this IOption<A> option, Func<A, B> f)
        {
            return option.Map(f);
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and
        /// returns that new option.
        /// </summary>
        public static IOption<B> SelectMany<A, B>(this IOption<A> option, Func<A, IOption<B>> f)
        {
            return option.FlatMap(f);
        }

        /// <summary>
        /// Maps the current value to a new option using the specified function and combines values of both of the options.
        /// </summary>
        public static IOption<B> SelectMany<A, X, B>(this IOption<A> option, Func<A, IOption<X>> f, Func<A, X, B> compose)
        {
            return option.FlatMap(a => f(a).Map(x => compose(a, x)));
        }

        /// <summary>
        /// Retuns the current option only if its value matches the specified predicate. Otherwise returns an empty option.
        /// </summary>
        public static IOption<A> Where<A>(this IOption<A> option, Func<A, bool> predicate)
        {
            if (option.IsEmpty || !predicate(option.GetOrDefault()))
            {
                return Option.Empty<A>();
            }
            return option;
        }

        /// <summary>
        /// Retuns true if value of the option matches the specified predicate. Otherwise returns false.
        /// </summary>
        public static bool Is<A>(this IOption<A> option, Func<A, bool> predicate)
        {
            if (option.NonEmpty)
                return predicate(option.GetOrDefault());
            return false;
        }

        /// <summary>
        /// Turns the option into a try using the exception in case of empty option.
        /// </summary>
        public static Try<A, E> ToTry<A, E>(this IOption<A> option, Func<Unit, E> e)
        {
            if (option.NonEmpty)
                return Try.Success<A, E>(option.GetOrDefault());

            return Try.Error<A, E>(e(Unit.Value));
        }
    }
}
