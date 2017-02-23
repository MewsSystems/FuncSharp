using System;

namespace FuncSharp
{
    public static class Try
    {
        /// <summary>
        /// Create a new try with the result of the specified function while converting exceptions of the specified type
        /// into erroneous result.
        /// </summary>
        public static ITry<A> Create<A, TException>(Func<Unit, A> f)
            where TException : Exception
        {
            try
            {
                return Success(f(Unit.Value));
            }
            catch (TException e)
            {
                return Error<A>(e);
            }
        }

        /// <summary>
        /// Create a new try with the result of the specified function while converting all exceptions into erroneous result.
        /// </summary>
        public static ITry<A> Create<A>(Func<Unit, A> f)
        {
            return Try.Create<A, Exception>(f);
        }

        /// <summary>
        /// Creates a new try with a successful result.
        /// </summary>
        public static ITry<A> Success<A>(A success)
        {
            return new Try<A>(success);
        }

        /// <summary>
        /// Creates a new try with a successful result.
        /// </summary>
        public static ITry<A, TError> Success<A, TError>(A success)
            where TError : Exception
        {
            return new Try<A, TError>(success);
        }

        /// <summary>
        /// Creates a new try with an exception result.
        /// </summary>
        public static ITry<A> Error<A>(Exception exception)
        {
            return new Try<A>(exception);
        }

        /// <summary>
        /// Creates a new try with an exception result.
        /// </summary>
        public static ITry<A, TError> Error<A, TError>(TError exception)
            where TError : Exception
        {
            return new Try<A, TError>(exception);
        }
    }

    internal class Try<A, TError> : Coproduct2<A, TError>, ITry<A, TError>
    {
        public Try(A success)
            : base(success)
        {
        }

        public Try(TError exception)
            : base(exception)
        {
        }

        public bool IsSuccess
        {
            get { return IsFirst; }
        }

        public bool IsError
        {
            get { return IsSecond; }
        }

        public IOption<A> Success
        {
            get { return First; }
        }

        public IOption<TError> Error
        {
            get { return Second; }
        }
    }

    internal class Try<A> : Try<A, Exception>, ITry<A>
    {
        public Try(A success)
            : base(success)
        {
        }

        public Try(Exception exception)
            : base(exception)
        {
        }

        public A Get()
        {
            return Match(
                s => s,
                e => { throw e; }
            );
        }

        public ITry<B> MapSuccess<B>(Func<A, B> f)
        {
            return FlatMapSuccess(s => f(s).ToTry());
        }

        public ITry<B> FlatMapSuccess<B>(Func<A, ITry<B>> f)
        {
            return Match(
                s => f(s),
                e => Try.Error<B>(e)
            );
        }
    }
}
