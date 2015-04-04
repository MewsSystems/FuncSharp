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

        /// <summary>
        /// Returns an either with the value swapped between left and right.
        /// </summary>
        IEither<B, A> Swapped { get; }

        /// <summary>
        /// If the either is left, invokes the <paramref name="ifLeft"/> function and returns its result. Otherwise returns result
        /// of the <paramref name="ifRight"/> invocation.
        /// </summary>
        R Match<R>(Func<B, R> ifRight, Func<A, R> ifLeft);
    }
}
