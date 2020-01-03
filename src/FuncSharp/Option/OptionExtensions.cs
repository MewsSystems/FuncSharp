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
            return option.GetOrElse<A, A>(_ => null);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static int GetOrZero(this Option<int> option)
        {
            return option.GetOrElse(0);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static decimal GetOrZero(this Option<decimal> option)
        {
            return option.GetOrElse(0m);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns false.
        /// </summary>
        public static bool GetOrFalse(this Option<bool> option)
        {
            return option.GetOrElse(false);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns the <paramref name="otherwise"/>.
        /// </summary>
        public static B GetOrElse<A, B>(this Option<A> option, B otherwise)
            where A : B
        {
            return option.GetOrElse(_ => otherwise);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns value created by the otherwise function.
        /// </summary>
        public static B GetOrElse<A, B>(this Option<A> option, Func<Unit, B> otherwise)
            where A : B
        {
            return option.Match(
                a => a,
                _ => otherwise(Unit.Value)
            );
        }

        /// <summary>
        /// Returns the option if it has value. Otherwise returns the alternative option.
        /// </summary>
        public static Option<B> OrElse<A, B>(this Option<A> option, Func<Unit, Option<B>> alternative)
            where A : B
        {
            return option.Match(
                _ => option as Option<B>,
                _ => alternative(Unit.Value)
            );
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
        /// Returns the value if the option is nonempty, otherwise empty enumerable.
        /// </summary>
        public static IEnumerable<A> Flatten<A>(this Option<IEnumerable<A>> option)
        {
            return option.GetOrElse(_ => Enumerable.Empty<A>());
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
            return option.FlatMap(a => predicate(a).Match(
                t => option,
                f => Option.Empty<A>()
            ));
        }

        /// <summary>
        /// Retuns true if value of the option matches the specified predicate. Otherwise returns false.
        /// </summary>
        public static bool Is<A>(this Option<A> option, Func<A, bool> predicate)
        {
            return option.Match(
                a => predicate(a),
                _ => false
            );
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<A>(this Option<A> option)
            where A : struct
        {
            return option.Match<A?>(
                a => a,
                _ => null
            );
        }

        /// <summary>
        /// Turns the option into a try using the exception in case of empty option.
        /// </summary>
        public static Try<A> ToTry<A>(this Option<A> option, Func<Unit, Exception> e)
        {
            return option.Match(
                val => Try.Success(val),
                _ => Try.Error<A>(e(Unit.Value))
            );
        }

        /// <summary>
        /// Turns the option into a try using the exception in case of empty option.
        /// </summary>
        public static Try<A, E> ToTry<A, E>(this Option<A> option, Func<Unit, E> e)
        {
            return option.Match(
                val => Try.Success<A, E>(val),
                _ => Try.Error<A, E>(e(Unit.Value))
            );
        }
    }
}
