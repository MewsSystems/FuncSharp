using System;
using System.Collections.Generic;

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

    /// <summary>
    /// Result of an operation that may either succeed or fail with exception.
    /// </summary>
    public interface ITry<out A> : ITry<A, Exception>
    {
        /// <summary>
        /// All exceptions in the try.
        /// </summary>
        IOption<IEnumerable<Exception>> Exceptions { get; }

        /// <summary>
        /// If the result is success, returns it. Otherwise throws the exception result.
        /// </summary>
        A Get();

        /// <summary>
        /// Maps the successful result to a new successful result.
        /// </summary>
        new ITry<B> Map<B>(Func<A, B> f);

        /// <summary>
        /// Maps the exception result to a new exception result.
        /// </summary>
        ITry<A> MapError(Func<Exception, Exception> f);
    }
}