using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace FuncSharp
{
    public static class ITryExtensions
    {
        /// <summary>
        /// If the successful result passes the predicate, returns the original try. Otherwise returns erroneous try with the specified result.
        /// </summary>
        public static ITry<A> Where<A>(this ITry<A> t, Func<A, bool> predicate, Func<Unit, Exception> otherwise)
        {
            return t.FlatMap(a => predicate(a).Match(
                _ => t,
                _ => Try.Error<A>(otherwise(Unit.Value))
            ));
        }

        /// <summary>
        /// If the successful result passes the predicate, returns the original try. Otherwise returns erroneous try with the specified result.
        /// </summary>
        public static ITry<A, E> Where<A, E>(this ITry<A, E> t, Func<A, bool> predicate, Func<Unit, E> otherwise)
        {
            return t.FlatMap(a => predicate(a).Match(
                _ => t,
                _ => Try.Error<A, E>(otherwise(Unit.Value))
            ));
        }

        /// <summary>
        /// Maps the successful result to a new try.
        /// </summary>
        public static ITry<B> FlatMap<A, B>(this ITry<A> t, Func<A, ITry<B>> f)
        {
            return t.Match(
                s => f(s),
                e => Try.Error<B>(e)
            );
        }

        /// <summary>
        /// Maps the successful result to a new try.
        /// </summary>
        public static ITry<B, E> FlatMap<A, E, B>(this ITry<A, E> t, Func<A, ITry<B, E>> f)
        {
            return t.Match(
                s => f(s),
                e => Try.Error<B, E>(e)
            );
        }

        /// <summary>
        /// Maps the exception result to a new try.
        /// </summary>
        public static ITry<B> FlatMapError<A, B>(this ITry<A> t, Func<IEnumerable<Exception>, ITry<B>> f)
            where A : B
        {
            return t.Match(
                s => Try.Success<B>(s),
                e => f(e)
            );
        }

        /// <summary>
        /// Maps the error result to a new try.
        /// </summary>
        public static ITry<B, F> FlatMapError<A, E, B, F>(this ITry<A, E> t, Func<E, ITry<B, F>> f)
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
        public static A Get<A, E>(this ITry<A, E> t, Func<E, Exception> otherwise)
        {
            return t.Match(
                s => s,
                e => throw otherwise(e)
            );
        }

        /// <summary>
        /// If the result is success, returns it. Otherwise throws the exception.
        /// </summary>
        public static A Get<A, E>(this ITry<A, E> t)
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
