using System;

namespace FuncSharp
{
    public interface IEither<out A, out B> : ISum
    {
        /// <summary>
        /// Returns whether the either contains a value on the left.
        /// </summary>
        bool IsLeft { get; }

        /// <summary>
        /// Returns whether the either contains a value on the right.
        /// </summary>
        bool IsRight { get; }

        /// <summary>
        /// Left value of the either.
        /// </summary>
        IOption<A> Left { get; }

        /// <summary>
        /// Right value of the either.
        /// </summary>
        IOption<B> Right { get; }
    }

    public static class IEitherExtensions
    {
        /// <summary>
        /// If the either is left, invokes the <paramref name="ifLeft"/> function and returns its result. Otherwise returns result
        /// of the <paramref name="ifRight"/> invocation.
        /// </summary>
        public static R Match<A, B, R>(this IEither<A, B> either, Func<A, R> ifLeft, Func<B, R> ifRight)
        {
            if (either.IsLeft)
            {
                return ifLeft(either.Left.Value);
            }
            else
            {
                return ifRight(either.Right.Value);
            }
        }

        /// <summary>
        /// Returns an either with the value swapped between left and right.
        /// </summary>
        public static IEither<B, A> Swap<A, B>(this IEither<A, B> either)
        {
            return either.Match(
                l => Either.Right<B, A>(l),
                r => Either.Left<B, A>(r)
            );
        }
    }
}
