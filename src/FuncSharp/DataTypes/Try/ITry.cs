using System;

namespace FuncSharp
{
    /// <summary>
    /// Result of an operation that may either succeed or fail with an error.
    /// </summary>
    public interface ITry<out A, out TError> : ICoproduct2<A, TError>
    {
        /// <summary>
        /// Returns whether the result is a success.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Returns whether the result is an exception.
        /// </summary>
        bool IsError { get; }

        /// <summary>
        /// Returns the successful result.
        /// </summary>
        IOption<A> Success { get; }

        /// <summary>
        /// Returns the error result.
        /// </summary>
        IOption<TError> Error { get; }
    }

    /// <summary>
    /// Result of an operation that may either succeed or fail with an exception.
    /// </summary>
    public interface ITry<out A> : ITry<A, Exception>
    {
        /// <summary>
        /// If the result is success, returns it. Otherwise throws the exception result.
        /// </summary>
        A Get();

        /// <summary>
        /// Maps the successful result to a new successful result.
        /// </summary>
        ITry<B> MapSuccess<B>(Func<A, B> f);

        /// <summary>
        /// Maps the successful result to a new try.
        /// </summary>
        ITry<B> FlatMapSuccess<B>(Func<A, ITry<B>> f);
    }
}