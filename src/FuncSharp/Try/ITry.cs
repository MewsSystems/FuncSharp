using System;

namespace FuncSharp
{
    /// <summary>
    /// Result of an operation that may either succeed or fail with an error.
    /// </summary>
    public interface ITry<out A, out E> : ICoproduct2<A, E>
    {
        /// <summary>
        /// Returns whether the result is a success.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Returns whether the result is an error.
        /// </summary>
        bool IsError { get; }

        /// <summary>
        /// Returns the successful result.
        /// </summary>
        IOption<A> Success { get; }

        /// <summary>
        /// Returns the error result.
        /// </summary>
        IOption<E> Error { get; }

        /// <summary>
        /// Maps the successful result to a new successful result.
        /// </summary>
        ITry<B, E> Map<B>(Func<A, B> f);

        /// <summary>
        /// Maps the error result to a new error result.
        /// </summary>
        ITry<A, F> MapError<F>(Func<E, F> f);
    }
}
