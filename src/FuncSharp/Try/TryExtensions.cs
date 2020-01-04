using System;

namespace FuncSharp
{
    public static class TryExtensions
    {
        /// <summary>
        /// If the result is success, returns it. Otherwise throws the exception result.
        /// </summary>
        public static A Get<A, E>(this Try<A, E> t)
            where E : Exception
        {
            return t.Match(
                s => s,
                e => throw e
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
                e => throw otherwise(e)
            );
        }
    }
}
