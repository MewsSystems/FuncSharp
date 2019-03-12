using System;
using System.Collections.Generic;

namespace FuncSharp
{
    public static class TryExtensions
    {
        /// <summary>
        /// Maps the successful result to a new try.
        /// </summary>
        public static Try<B> FlatMap<A, B>(this Try<A> t, Func<A, Try<B>> f)
        {
            return t.Match(
                s => f(s),
                e => Try.Error<B>(e)
            );
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
        /// Maps the exception result to a new try.
        /// </summary>
        public static Try<B> FlatMapError<A, B>(this Try<A> t, Func<IEnumerable<Exception>, Try<B>> f)
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
        public static Try<B, F> FlatMapError<A, E, B, F>(this Try<A, E> t, Func<E, Try<B, F>> f)
            where A : B
            where E : F
        {
            return t.Match(
                s => Try.Success<B, F>(s),
                e => f(e)
            );
        }
    }
}
