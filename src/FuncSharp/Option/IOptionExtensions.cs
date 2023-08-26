using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FuncSharp
{
    public static class OptionExtensions
    {
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

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<A>(this Option<A?> option)
            where A : struct
        {
            if (option.NonEmpty)
                return option.GetOrDefault();
            return null;
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static B? ToNullable<A, B>(this Option<A> option, Func<A, B?> func)
            where B : struct
        {
            if (option.NonEmpty)
                return func(option.GetOrDefault());
            return null;
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static B? ToNullable<A, B>(this Option<A> option, Func<A, B> func)
            where B : struct
        {
            if (option.NonEmpty)
                return func(option.GetOrDefault());
            return null;
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns null.
        /// </summary>
        public static T GetOrNull<T>(this Option<T> option)
            where T : class
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns null.
        /// </summary>
        public static R GetOrNull<T, R>(this Option<T> option, Func<T, R> func)
            where R : class
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static short GetOrZero(this Option<short> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static short GetOrZero<T>(this Option<T> option, Func<T, short> func)
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
        public static int GetOrZero<T>(this Option<T> option, Func<T, int> func)
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static long GetOrZero(this Option<long> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static long GetOrZero<T>(this Option<T> option, Func<T, long> func)
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
        public static decimal GetOrZero<T>(this Option<T> option, Func<T, decimal> func)
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static double GetOrZero(this Option<double> option)
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static double GetOrZero<T>(this Option<T> option, Func<T, double> func)
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
        public static bool GetOrFalse<T>(this Option<T> option, Func<T, bool> func)
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
        public static Option<B> OrElse<A, B>(this Option<A> option, Option<B> alternative)
            where A : B
        {
            if (option.NonEmpty)
            {
                return option.Map(value => (B)value);
            }
            return alternative;
        }

        /// <summary>
        /// Returns the option if it has value. Otherwise returns the alternative option.
        /// </summary>
        public static Option<B> OrElse<A, B>(this Option<A> option, Func<Unit, Option<B>> alternative)
            where A : B
        {
            if (option.NonEmpty)
            {
                return option.Map(value => (B)value);
            }
            return alternative(Unit.Value);
        }

        /// <summary>
        /// Returns the value of the outer option or an empty opion.
        /// </summary>
        public static Option<A> Flatten<A>(this Option<Option<A>> option)
        {
            return option.FlatMap(o => o);
        }

        /// <summary>
        /// Turns the option of nullable into an option.
        /// </summary>
        public static Option<A> Flatten<A>(this Option<A?> option)
            where A : struct
        {
            return option.FlatMap(a => a.ToOption());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IEnumerable<A> Flatten<A>(this Option<IEnumerable<A>> option)
        {
            return option.GetOrElse(_ => Enumerable.Empty<A>());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyList<A> Flatten<A>(this Option<IReadOnlyList<A>> option)
        {
            return option.GetOrElse(_ => ReadOnlyList.Empty<A>());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyList<A> Flatten<A>(this Option<INonEmptyEnumerable<A>> option)
        {
            return option.GetOrElse(_ => ReadOnlyList.Empty<A>());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static A[] Flatten<A>(this Option<A[]> option)
        {
            return option.GetOrElse(_ => Array.Empty<A>());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static List<A> Flatten<A>(this Option<List<A>> option)
        {
            return option.GetOrElse(_ => new List<A>());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IEnumerable<A> GetOrEmpty<A>(this Option<IEnumerable<A>> option)
        {
            return option.GetOrElse(_ => Enumerable.Empty<A>());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyList<A> GetOrEmpty<A>(this Option<IReadOnlyList<A>> option)
        {
            return option.GetOrElse(_ => ReadOnlyList.Empty<A>());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyList<A> GetOrEmpty<A>(this Option<INonEmptyEnumerable<A>> option)
        {
            return option.GetOrElse(_ => ReadOnlyList.Empty<A>());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static A[] GetOrEmpty<A>(this Option<A[]> option)
        {
            return option.GetOrElse(_ => Array.Empty<A>());
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static List<A> GetOrEmpty<A>(this Option<List<A>> option)
        {
            return option.GetOrElse(_ => new List<A>());
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and
        /// returns a new option with that new value.
        /// </summary>
        public static Option<B> Select<A, B>(this Option<A> option, Func<A, B> f)
        {
            return option.Map(f);
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and
        /// returns that new option.
        /// </summary>
        public static Option<B> SelectMany<A, B>(this Option<A> option, Func<A, Option<B>> f)
        {
            return option.FlatMap(f);
        }

        /// <summary>
        /// Maps the current value to a new option using the specified function and combines values of both of the options.
        /// </summary>
        public static Option<B> SelectMany<A, X, B>(this Option<A> option, Func<A, Option<X>> f, Func<A, X, B> compose)
        {
            return option.FlatMap(a => f(a).Map(x => compose(a, x)));
        }

        /// <summary>
        /// Retuns the current option only if its value matches the specified predicate. Otherwise returns an empty option.
        /// </summary>
        public static Option<A> Where<A>(this Option<A> option, Func<A, bool> predicate)
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
        public static bool Is<A>(this Option<A> option, Func<A, bool> predicate)
        {
            if (option.NonEmpty)
                return predicate(option.GetOrDefault());
            return false;
        }

        /// <summary>
        /// Turns the option into a try using the exception in case of empty option.
        /// </summary>
        public static Try<A, E> ToTry<A, E>(this Option<A> option, Func<Unit, E> e)
        {
            if (option.NonEmpty)
                return Try.Success<A, E>(option.GetOrDefault());

            return Try.Error<A, E>(e(Unit.Value));
        }

        /// <summary>
        /// Maps value of the current <see cref="Option{A}"/> (if present) into a new value using the specified function and
        /// returns a new <see cref="Option{A}"/> (with that new value) wrapped in a <see cref="System.Threading.Tasks.Task"/>.
        /// </summary>
        public static async Task<Option<B>> MapAsync<A, B>(this Option<A> option, Func<A, Task<B>> f)
        {
            if (option.NonEmpty)
            {
                return Option.Valued(await f(option.GetOrDefault()));
            }
            else
            {
                return Option.Empty<B>();
            }
        }

        public static async Task MatchAsync<A>(this Option<A> option, Func<A, Task> ifFirst, Func<Unit, Task> ifSecond)
        {
            if (option.NonEmpty)
            {
                await ifFirst(option.GetOrDefault());
            }
            else
            {
                await ifSecond(Unit.Value);
            }
        }

        public static async Task<TResult> MatchAsync<A, TResult>(this Option<A> option, Func<A, Task<TResult>> ifFirst, Func<Unit, Task<TResult>> ifSecond)
        {
            if (option.NonEmpty)
            {
                return await ifFirst(option.GetOrDefault());
            }
            else
            {
                return await ifSecond(Unit.Value);
            }
        }

        /// <summary>
        /// Maps value of the current <see cref="Option{A}"/> (if present) into a new option using the specified function and
        /// returns <see cref="Option{B}"/> wrapped in a <see cref="System.Threading.Tasks.Task"/>.
        /// </summary>
        public static async Task<Option<B>> FlatMapAsync<A, B>(this Option<A> option, Func<A, Task<Option<B>>> f)
        {
            if (option.NonEmpty)
            {
                return await f(option.GetOrDefault());
            }
            else
            {
                return Option.Empty<B>();
            }
        }
    }
}
