using System;

namespace FuncSharp
{
    /// <summary>
    /// Result of an operation that may either succeed or fail with an exception.
    /// </summary>
    public interface ITry<out TSuccess, out TException> : ICoproduct2<TSuccess, TException>
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
    }

    /// <summary>
    /// Result of an operation that may either succeed or fail with an exception.
    /// </summary>
    public interface ITry<out TSuccess> : ITry<TSuccess, Exception>
    {
    }
}