using System;
using System.Collections.Generic;
using System.Linq;

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
        public static ITry<A, E> Create<A, E>(Func<Unit, A> f)
            where E : Exception
        {
            return Catch<ITry<A>, E>(
                _ => Success<A, E>(f(Unit.Value)),
                e => Error<A, E>(e)
            );
        }

        /// <summary>
        /// Create a new try with the result of the specified function while converting all exceptions into erroneous result.
        /// </summary>
        public static ITry<A> Create<A>(Func<Unit, A> f)
        {
            return Create<A, Exception>(f);
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
            return new Try<A>(new[] { exception });
        }

        /// <summary>
        /// Creates a new try with an exception result.
        /// </summary>
        public static ITry<A> Error<A>(IEnumerable<Exception> exception)
        {
            return new Try<A>(exception);
        }

        /// <summary>
        /// Aggregates a collection of tries into a try of collection.
        /// </summary>
        public static ITry<IEnumerable<A>> Aggregate<A>(IEnumerable<ITry<A>> tries)
        {
            if (tries.All(t => t.IsSuccess))
            {
                return Success(tries.Select(t => t.Success).Flatten().ToList());
            }

            return Error<IEnumerable<A>>(tries.SelectMany(t => t.Error.Flatten()).ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, Func<E, E, E> errorAggregate, Func<T1, T2, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, Func<T1, T2, R> f)
        {
            return Aggregate(t1, t2, (e1, e2) => e1.Concat(e2), (s1, s2) => Success<R, IEnumerable<E>>(f(s1, s2)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, R>(ITry<T1> t1, ITry<T2> t2, Func<T1, T2, R> f)
        {
            return Aggregate(t1, t2, (e1, e2) => e1.Concat(e2), (s1, s2) => Success<R>(f(s1, s2)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, Func<T1, T2, T3, R> f)
        {
            return Aggregate(t1, t2, t3, (e1, e2) => e1.Concat(e2), (s1, s2, s3) => Success<R, IEnumerable<E>>(f(s1, s2, s3)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, Func<T1, T2, T3, R> f)
        {
            return Aggregate(t1, t2, t3, (e1, e2) => e1.Concat(e2), (s1, s2, s3) => Success<R>(f(s1, s2, s3)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, Func<T1, T2, T3, T4, R> f)
        {
            return Aggregate(t1, t2, t3, t4, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, Func<T1, T2, T3, T4, R> f)
        {
            return Aggregate(t1, t2, t3, t4, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4) => Success<R>(f(s1, s2, s3, s4)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, Func<T1, T2, T3, T4, T5, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, Func<T1, T2, T3, T4, T5, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5) => Success<R>(f(s1, s2, s3, s4, s5)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, Func<T1, T2, T3, T4, T5, T6, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, Func<T1, T2, T3, T4, T5, T6, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6) => Success<R>(f(s1, s2, s3, s4, s5, s6)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T7, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, ITry<T7, E> t7, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T7, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, T7, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, ITry<T7, IEnumerable<E>> t7, Func<T1, T2, T3, T4, T5, T6, T7, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6, s7)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, Func<T1, T2, T3, T4, T5, T6, T7, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7) => Success<R>(f(s1, s2, s3, s4, s5, s6, s7)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, ITry<T7, E> t7, ITry<T8, E> t8, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T7, T8, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, ITry<T7, IEnumerable<E>> t7, ITry<T8, IEnumerable<E>> t8, Func<T1, T2, T3, T4, T5, T6, T7, T8, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6, s7, s8)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, Func<T1, T2, T3, T4, T5, T6, T7, T8, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8) => Success<R>(f(s1, s2, s3, s4, s5, s6, s7, s8)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, ITry<T7, E> t7, ITry<T8, E> t8, ITry<T9, E> t9, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, ITry<T7, IEnumerable<E>> t7, ITry<T8, IEnumerable<E>> t8, ITry<T9, IEnumerable<E>> t9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success<R>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, ITry<T7, E> t7, ITry<T8, E> t8, ITry<T9, E> t9, ITry<T10, E> t10, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, ITry<T7, IEnumerable<E>> t7, ITry<T8, IEnumerable<E>> t8, ITry<T9, IEnumerable<E>> t9, ITry<T10, IEnumerable<E>> t10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success<R>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, ITry<T7, E> t7, ITry<T8, E> t8, ITry<T9, E> t9, ITry<T10, E> t10, ITry<T11, E> t11, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, ITry<T7, IEnumerable<E>> t7, ITry<T8, IEnumerable<E>> t8, ITry<T9, IEnumerable<E>> t9, ITry<T10, IEnumerable<E>> t10, ITry<T11, IEnumerable<E>> t11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success<R>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, ITry<T7, E> t7, ITry<T8, E> t8, ITry<T9, E> t9, ITry<T10, E> t10, ITry<T11, E> t11, ITry<T12, E> t12, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, ITry<T7, IEnumerable<E>> t7, ITry<T8, IEnumerable<E>> t8, ITry<T9, IEnumerable<E>> t9, ITry<T10, IEnumerable<E>> t10, ITry<T11, IEnumerable<E>> t11, ITry<T12, IEnumerable<E>> t12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, ITry<T12> t12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success<R>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, ITry<T7, E> t7, ITry<T8, E> t8, ITry<T9, E> t9, ITry<T10, E> t10, ITry<T11, E> t11, ITry<T12, E> t12, ITry<T13, E> t13, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, ITry<T7, IEnumerable<E>> t7, ITry<T8, IEnumerable<E>> t8, ITry<T9, IEnumerable<E>> t9, ITry<T10, IEnumerable<E>> t10, ITry<T11, IEnumerable<E>> t11, ITry<T12, IEnumerable<E>> t12, ITry<T13, IEnumerable<E>> t13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, ITry<T12> t12, ITry<T13> t13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success<R>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, ITry<T7, E> t7, ITry<T8, E> t8, ITry<T9, E> t9, ITry<T10, E> t10, ITry<T11, E> t11, ITry<T12, E> t12, ITry<T13, E> t13, ITry<T14, E> t14, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess && t14.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get(), t14.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error, t14.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, ITry<T7, IEnumerable<E>> t7, ITry<T8, IEnumerable<E>> t8, ITry<T9, IEnumerable<E>> t9, ITry<T10, IEnumerable<E>> t10, ITry<T11, IEnumerable<E>> t11, ITry<T12, IEnumerable<E>> t12, ITry<T13, IEnumerable<E>> t13, ITry<T14, IEnumerable<E>> t14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, ITry<T12> t12, ITry<T13> t13, ITry<T14> t14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success<R>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)), Error<R>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static T Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T, E>(ITry<T1, E> t1, ITry<T2, E> t2, ITry<T3, E> t3, ITry<T4, E> t4, ITry<T5, E> t5, ITry<T6, E> t6, ITry<T7, E> t7, ITry<T8, E> t8, ITry<T9, E> t9, ITry<T10, E> t10, ITry<T11, E> t11, ITry<T12, E> t12, ITry<T13, E> t13, ITry<T14, E> t14, ITry<T15, E> t15, Func<E, E, E> errorAggregate, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T> success, Func<E, T> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess && t14.IsSuccess && t15.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get(), t14.Success.Get(), t15.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error, t14.Error, t15.Error };
            return error(errors.Flatten().Aggregate(errorAggregate));
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R, E>(ITry<T1, IEnumerable<E>> t1, ITry<T2, IEnumerable<E>> t2, ITry<T3, IEnumerable<E>> t3, ITry<T4, IEnumerable<E>> t4, ITry<T5, IEnumerable<E>> t5, ITry<T6, IEnumerable<E>> t6, ITry<T7, IEnumerable<E>> t7, ITry<T8, IEnumerable<E>> t8, ITry<T9, IEnumerable<E>> t9, ITry<T10, IEnumerable<E>> t10, ITry<T11, IEnumerable<E>> t11, ITry<T12, IEnumerable<E>> t12, ITry<T13, IEnumerable<E>> t13, ITry<T14, IEnumerable<E>> t14, ITry<T15, IEnumerable<E>> t15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success<R, IEnumerable<E>>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)), Error<R, IEnumerable<E>>);
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>(ITry<T1> t1, ITry<T2> t2, ITry<T3> t3, ITry<T4> t4, ITry<T5> t5, ITry<T6> t6, ITry<T7> t7, ITry<T8> t8, ITry<T9> t9, ITry<T10> t10, ITry<T11> t11, ITry<T12> t12, ITry<T13> t13, ITry<T14> t14, ITry<T15> t15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> f)
        {
            return Aggregate(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, (e1, e2) => e1.Concat(e2), (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success<R>(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)), Error<R>);
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

    internal class Try<A> : Try<A, IEnumerable<Exception>>, ITry<A>
    {
        public Try(A success)
            : base(success)
        {
        }

        public Try(IEnumerable<Exception> exceptions)
            : base(exceptions)
        {
        }

        public A Get()
        {
            return Match(
                s => s,
                e => throw e.SingleOption().GetOrElse(_ => new AggregateException(e) as Exception)
            );
        }
        
        public ITry<B> Map<B>(Func<A, B> f, Func<IEnumerable<Exception>, IEnumerable<Exception>> g)
        {
            return Match(
                s => Try.Success<B>(f(s)),
                e => Try.Error<B>(g(e))
            );
        }

        public ITry<B> Map<B>(Func<A, B> f, Func<IEnumerable<Exception>, Exception> g)
        {
            return Map(f, e => new[] { g(e) });
        }

        public new ITry<B> Map<B>(Func<A, B> f)
        {
            return Map(f, e => e);
        }

        public ITry<A> MapError(Func<IEnumerable<Exception>, IEnumerable<Exception>> f)
        {
            return Map(s => s, f);
        }

        public ITry<A> MapError(Func<IEnumerable<Exception>, Exception> f)
        {
            return MapError(e => new[] { f(e) });
        }

		public ITry<A> MapError(Func<Exception, Exception> f)
        {
            return MapError(exceptions => exceptions.Select(f).ToList());
        }
    }
}
