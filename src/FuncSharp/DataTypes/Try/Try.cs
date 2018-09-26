using System;
using System.Linq;
using System.Collections.Generic;

namespace FuncSharp
{
    public static class Try
    {
        /// <summary>
        /// Tries the specified action and returns its result if it succeeds. Otherwise in case of the specified exception,
        /// returns result of the recovery function.
        /// </summary>
        public static A Catch<A, E>(Func<Unit, A> action, Func<E, A> recover)
            where E : Exception
        {
            try
            {
                return action(Unit.Value);
            }
            catch (E e)
            {
                return recover(e);
            }
        }

        /// <summary>
        /// Create a new try with the result of the specified function while converting exceptions of the specified type
        /// into erroneous result.
        /// </summary>
        public static ITry<A> Create<A, E>(Func<Unit, A> f)
            where E : Exception
        {
            return Catch<ITry<A>, Exception>(
                _ => Success(f(Unit.Value)),
                e => Error<A>(e)
            );
        }

        /// <summary>
        /// Creates a new try with a successful result.
        /// </summary>
        public static ITry<A, E> Success<A, E>(A success)
        {
            return new Try<A, E>(success);
        }

        /// <summary>
        /// Creates a new try with a successful result.
        /// </summary>
        public static ITry<A> Success<A>(A success)
        {
            return new Try<A>(success);
        }

        /// <summary>
        /// Creates a new try with an error result.
        /// </summary>
        public static ITry<A, E> Error<A, E>(E error)
        {
            return new Try<A, E>(error);
        }

        /// <summary>
        /// Creates a new try with an exception result.
        /// </summary>
        public static ITry<A> Error<A>(Exception exception)
        {
            return new Try<A>(exception);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, R>(ITry<T1> t1, ITry<T2> t2, Func<T1, T2, R> f)
        {
            if (t1.IsError || t2.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, Func<T1, T2, T3, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, Func<T1, T2, T3, T4, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, Func<T1, T2, T3, T4, T5, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, Func<T1, T2, T3, T4, T5, T6, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, Func<T1, T2, T3, T4, T5, T6, T7, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError || t7.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten(), t7.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get(), t7.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, Func<T1, T2, T3, T4, T5, T6, T7, T8, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError || t7.IsError || t8.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten(), t7.Exceptions.Flatten(), t8.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get(), t7.Get(), t8.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError || t7.IsError || t8.IsError || t9.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten(), t7.Exceptions.Flatten(), t8.Exceptions.Flatten(), t9.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get(), t7.Get(), t8.Get(), t9.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError || t7.IsError || t8.IsError || t9.IsError || t10.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten(), t7.Exceptions.Flatten(), t8.Exceptions.Flatten(), t9.Exceptions.Flatten(), t10.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get(), t7.Get(), t8.Get(), t9.Get(), t10.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError || t7.IsError || t8.IsError || t9.IsError || t10.IsError || t11.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten(), t7.Exceptions.Flatten(), t8.Exceptions.Flatten(), t9.Exceptions.Flatten(), t10.Exceptions.Flatten(), t11.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get(), t7.Get(), t8.Get(), t9.Get(), t10.Get(), t11.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, ITry<T12> t12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError || t7.IsError || t8.IsError || t9.IsError || t10.IsError || t11.IsError || t12.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten(), t7.Exceptions.Flatten(), t8.Exceptions.Flatten(), t9.Exceptions.Flatten(), t10.Exceptions.Flatten(), t11.Exceptions.Flatten(), t12.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get(), t7.Get(), t8.Get(), t9.Get(), t10.Get(), t11.Get(), t12.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, ITry<T12> t12, ITry<T13> t13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError || t7.IsError || t8.IsError || t9.IsError || t10.IsError || t11.IsError || t12.IsError || t13.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten(), t7.Exceptions.Flatten(), t8.Exceptions.Flatten(), t9.Exceptions.Flatten(), t10.Exceptions.Flatten(), t11.Exceptions.Flatten(), t12.Exceptions.Flatten(), t13.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get(), t7.Get(), t8.Get(), t9.Get(), t10.Get(), t11.Get(), t12.Get(), t13.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, ITry<T12> t12, ITry<T13> t13, ITry<T14> t14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError || t7.IsError || t8.IsError || t9.IsError || t10.IsError || t11.IsError || t12.IsError || t13.IsError || t14.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten(), t7.Exceptions.Flatten(), t8.Exceptions.Flatten(), t9.Exceptions.Flatten(), t10.Exceptions.Flatten(), t11.Exceptions.Flatten(), t12.Exceptions.Flatten(), t13.Exceptions.Flatten(), t14.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get(), t7.Get(), t8.Get(), t9.Get(), t10.Get(), t11.Get(), t12.Get(), t13.Get(), t14.Get()));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions into error result.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, ITry<T12> t12, ITry<T13> t13, ITry<T14> t14, ITry<T15> t15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> f)
        {
            if (t1.IsError || t2.IsError || t3.IsError || t4.IsError || t5.IsError || t6.IsError || t7.IsError || t8.IsError || t9.IsError || t10.IsError || t11.IsError || t12.IsError || t13.IsError || t14.IsError || t15.IsError)
            {
                var exceptions = new[] { t1.Exceptions.Flatten(), t2.Exceptions.Flatten(), t3.Exceptions.Flatten(), t4.Exceptions.Flatten(), t5.Exceptions.Flatten(), t6.Exceptions.Flatten(), t7.Exceptions.Flatten(), t8.Exceptions.Flatten(), t9.Exceptions.Flatten(), t10.Exceptions.Flatten(), t11.Exceptions.Flatten(), t12.Exceptions.Flatten(), t13.Exceptions.Flatten(), t14.Exceptions.Flatten(), t15.Exceptions.Flatten() };
                return Try.Error<R>(new AggregateException(exceptions.SelectMany(e => e)));
            }
            return Try.Success(f(t1.Get(), t2.Get(), t3.Get(), t4.Get(), t5.Get(), t6.Get(), t7.Get(), t8.Get(), t9.Get(), t10.Get(), t11.Get(), t12.Get(), t13.Get(), t14.Get(), t15.Get()));
        }
    }

    internal class Try<A, E> : Coproduct2<A, E>, ITry<A, E>
    {
        public Try(A success)
            : base(success)
        {
        }

        public Try(E error)
            : base(error)
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

        public IOption<E> Error
        {
            get { return Second; }
        }

        public ITry<B, E> Map<B>(Func<A, B> f)
        {
            return Match(
                s => Try.Success<B, E>(f(s)),
                e => Try.Error<B, E>(e)
            );
        }

        public ITry<A, F> MapError<F>(Func<E, F> f)
        {
            return Match(
                s => Try.Success<A, F>(s),
                e => Try.Error<A, F>(f(e))
            );
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

        public IOption<IEnumerable<Exception>> Exceptions
        {
            get { return Error.Map(e => GetExceptions(e)); }
        }

        public A Get()
        {
            return Match(
                s => s,
                e => throw e
            );
        }

        public new ITry<B> Map<B>(Func<A, B> f)
        {
            return Match(
                s => Try.Success<B>(f(s)),
                e => Try.Error<B>(e)
            );
        }

        public ITry<A> MapError(Func<Exception, Exception> f)
        {
            return Match(
                s => Try.Success<A>(s),
                e => Try.Error<A>(f(e))
            );
        }

        public R Match<R>(Func<A, R> ifFirst, Func<IEnumerable<Exception>, R> ifSecond)
        {
            return Match(
                s => ifFirst(s),
                e => ifSecond(GetExceptions(e))
            );
        }

        private IEnumerable<Exception> GetExceptions(Exception exception)
        {
            if (exception is AggregateException aggregateException)
            {
                return aggregateException.InnerExceptions;
            }
            return new[] { exception };
        }
    }
}