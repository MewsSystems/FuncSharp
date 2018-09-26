using System;

namespace FuncSharp
{
    public static class ITryExtensions
    {
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
        public static ITry<B> FlatMapError<A, B>(this ITry<A> t, Func<Exception, ITry<B>> f)
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
    }
}
