using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace FuncSharp
{
    public static class TryExtensions
    {
        /// <summary>
        /// If the successful result passes the predicate, returns the original try. Otherwise returns erroneous try with the specified result.
        /// </summary>
        public static Try<A, E> Where<A, E>(this Try<A, E> t, Func<A, bool> predicate, Func<Unit, E> otherwise)
        {
            return t.FlatMap(a => predicate(a).Match(
                _ => t,
                _ => Try.Error<A, E>(otherwise(Unit.Value))
            ));
        }

        /// <summary>
        /// If the successful result passes the predicate, returns the original try. Otherwise returns erroneous try with the specified result.
        /// </summary>
        public static Try<A, IEnumerable<E>> Where<A, E>(this Try<A, IEnumerable<E>> t, Func<A, bool> predicate, Func<Unit, E> otherwise)
        {
            return t.FlatMap(a => predicate(a).Match(
                _ => t,
                _ => Try.Error<A, IEnumerable<E>>(new[] { otherwise(Unit.Value) })
            ));
        }

        /// <summary>
        /// Maps the successful result to a new try.
        /// </summary>
        public static Try<B, E> FlatMap<A, E, B>(this Try<A, E> t, Func<A, Try<B, E>> f)
        {
            return t.Match(
                s => f(s),
                e => Try.Error<B, E>(e)
            );
        }

        /// <summary>
        /// Maps the error result to a new try.
        /// </summary>
        public static Try<B, F> FlatMapError<A, E, B, F>(this Try<A, E> t, Func<E, Try<B, F>> f)
            where A : B
            where E : F
        {
            return t.Match(
                s => Try.Success<B, F>(s),
                e => f(e)
            );
        }

        /// <summary>
        /// If the result is success, returns it. Otherwise throws the result of the otherwise function.
        /// </summary>
        public static A Get<A, E>(this Try<A, E> t, Func<E, Exception> otherwise)
        {
            return t.Match(
                s => s,
                e =>
                {
                    ExceptionDispatchInfo.Capture(otherwise(e)).Throw();
                    return default;
                }
            );
        }

        /// <summary>
        /// If the result is success, returns it. Otherwise throws the exception.
        /// </summary>
        public static A Get<A, E>(this Try<A, E> t)
            where E : Exception
        {
            return t.Match(
                s => s,
                e =>
                {
                    ExceptionDispatchInfo.Capture(e).Throw();
                    return default;
                }
            );
        }
    }
}
