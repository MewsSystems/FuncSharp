using System;

namespace FuncSharp
{
    public static class Try
    {
        /// <summary>
        /// Creates a new try with a successful result.
        /// </summary>
        public static ITry<TSuccess> Success<TSuccess>(TSuccess success)
        {
            return new Try<TSuccess>(success);
        }

        /// <summary>
        /// Creates a new try with a successful result.
        /// </summary>
        public static ITry<TSuccess, TException> Success<TSuccess, TException>(TSuccess success)
            where TException : Exception
        {
            return new Try<TSuccess, TException>(success);
        }

        /// <summary>
        /// Creates a new try with an exception result.
        /// </summary>
        public static ITry<TSuccess> Exception<TSuccess>(Exception exception)
        {
            return new Try<TSuccess>(exception);
        }

        /// <summary>
        /// Creates a new try with an exception result.
        /// </summary>
        public static ITry<TSuccess, TException> Exception<TSuccess, TException>(TException exception)
            where TException : Exception
        {
            return new Try<TSuccess, TException>(exception);
        }
    }

    public class Try<TSuccess, TException> : Coproduct2<TSuccess, TException>, ITry<TSuccess, TException>
        where TException : Exception
    {
        public Try(TSuccess success)
            : base(success)
        {
        }

        public Try(TException exception)
            : base(exception)
        {
        }

        public bool IsSuccess
        {
            get { return IsFirst; }
        }

        public bool IsException
        {
            get { return IsSecond; }
        }

        public IOption<TSuccess> Success
        {
            get { return First; }
        }

        public IOption<TException> Exception
        {
            get { return Second; }
        }

        public TSuccess Get()
        {
            return Match(
                s => s,
                e => { throw e; }
            );
        }
    }

    public class Try<TSuccess> : Try<TSuccess, Exception>, ITry<TSuccess>
    {
        public Try(TSuccess success)
            : base(success)
        {
        }

        public Try(Exception exception)
            : base(exception)
        {
        }

        public ITry<TNewSuccess> MapSuccess<TNewSuccess>(Func<TSuccess, TNewSuccess> f)
        {
            return FlatMapSuccess(s => Try.Success(f(s)));
        }

        public ITry<TNewSuccess> FlatMapSuccess<TNewSuccess>(Func<TSuccess, ITry<TNewSuccess>> f)
        {
            return Match(
                s => f(s),
                e => Try.Exception<TNewSuccess>(e)
            );
        }
    }
}
