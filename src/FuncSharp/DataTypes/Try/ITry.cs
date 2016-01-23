using System;

namespace FuncSharp
{
    /// <summary>
    /// Result of an operation that may either succeed or fail with an exception.
    /// </summary>
    public interface ITry<out TSuccess, out TException> : ICoproduct2<TSuccess, TException>
        where TException : Exception
    {
        /// <summary>
        /// Returns whether the result is a success.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Returns whether the result is an exception.
        /// </summary>
        bool IsException { get; }

        /// <summary>
        /// Returns the successful result.
        /// </summary>
        IOption<TSuccess> Success { get; }

        /// <summary>
        /// Returns the exception result.
        /// </summary>
        IOption<TException> Exception { get; }

        /// <summary>
        /// If the result is success, returns it. Otherwise throws the exception result.
        /// </summary>
        TSuccess Get();
    }

    /// <summary>
    /// Result of an operation that may either succeed or fail with an exception.
    /// </summary>
    public interface ITry<out TSuccess> : ITry<TSuccess, Exception>
    {
        /// <summary>
        /// Maps the successful result to a new successful result.
        /// </summary>
        ITry<TNewSuccess> MapSuccess<TNewSuccess>(Func<TSuccess, TNewSuccess> f);

        /// <summary>
        /// Maps the successful result to a new try.
        /// </summary>
        ITry<TNewSuccess> FlatMapSuccess<TNewSuccess>(Func<TSuccess, ITry<TNewSuccess>> f);
    }
}