using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

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
        /// Tries the specified action and returns a successful try if it succeeds. Otherwise in case of the specified exception,
        /// returns an erroneous try.
        /// </summary>
        public static ITry<A, E> Catch<A, E>(Func<Unit, A> f)
            where E : Exception
        {
            return Catch<ITry<A, E>, E>(
                _ => Success<A, E>(f(Unit.Value)),
                e => Error<A, E>(e)
            );
        }

        /// <summary>
        /// Create a new try with the result of the specified function while converting exceptions of the specified type
        /// into erroneous result.
        /// </summary>
        public static ITry<A> Create<A, E>(Func<Unit, A> f)
            where E : Exception
        {
            return Catch<ITry<A>, E>(
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
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A, E, R>(IEnumerable<ITry<A, E>> tries, Func<IEnumerable<A>, R> success, Func<IEnumerable<E>, R> error)
        {
            var enumeratedTries = tries.ToList();
            if (enumeratedTries.All(t => t.IsSuccess))
            {
                return success(enumeratedTries.Select(t => t.Success).Flatten().ToList());
            }

            return error(enumeratedTries.Select(t => t.Error).Flatten());
        }

        /// <summary>
        /// Aggregates a collection of tries into a try of collection.
        /// </summary>
        public static ITry<IEnumerable<A>, IEnumerable<E>> Aggregate<A, E>(IEnumerable<ITry<A, E>> tries)
        {
            return Aggregate(
                tries,
                success: results => Success<IEnumerable<A>, IEnumerable<E>>(results),
                error: errors => Error<IEnumerable<A>, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates a collection of tries into a try of collection.
        /// </summary>
        public static ITry<IEnumerable<A>, IEnumerable<E>> Aggregate<A, E>(IEnumerable<ITry<A, IEnumerable<E>>> tries)
        {
            return Aggregate(
                tries,
                success: results => Success<IEnumerable<A>, IEnumerable<E>>(results),
                error: errors => Error<IEnumerable<A>, IEnumerable<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A, R>(IEnumerable<ITry<A, Exception>> tries, Func<IEnumerable<A>, R> success)
        {
            return Aggregate(
                tries,
                success: results => Success<R, Exception>(success(results)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates a collection of tries into a try of collection.
        /// </summary>
        public static ITry<IEnumerable<A>, Exception> Aggregate<A>(IEnumerable<ITry<A, Exception>> tries)
        {
            return Aggregate(
                tries,
                success: results => results
            );
        }

        /// <summary>
        /// Aggregates a collection of tries into a try of collection.
        /// </summary>
        public static ITry<IEnumerable<A>> Aggregate<A>(IEnumerable<ITry<A>> tries)
        {
            return Aggregate(
                tries,
                t => Success(t),
                e => Error<IEnumerable<A>>(e.SelectMany(error => error).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, Func<A1, A2, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, Func<A1, A2, R> success)
        {
            return Aggregate(
                t1, t2,
                success: (s1, s2) => Success<R, Exception>(success(s1, s2)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, Func<E, E, E> errorAggregate, Func<A1, A2, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, Func<A1, A2, R> success)
        {
            return Aggregate(
                t1, t2,
                success: (s1, s2) => Success<R, IEnumerable<E>>(success(s1, s2)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, Func<A1, A2, R> success)
        {
            return Aggregate(
                t1, t2,
                success: (s1, s2) => Success<R, IEnumerable<E>>(success(s1, s2)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, R>(ITry<A1> t1, ITry<A2> t2, Func<A1, A2, R> success)
        {
            return Aggregate(
                t1, t2,
                success: (s1, s2) => Success(success(s1, s2)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, Func<A1, A2, A3, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, Func<A1, A2, A3, R> success)
        {
            return Aggregate(
                t1, t2, t3,
                success: (s1, s2, s3) => Success<R, Exception>(success(s1, s2, s3)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, Func<E, E, E> errorAggregate, Func<A1, A2, A3, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, Func<A1, A2, A3, R> success)
        {
            return Aggregate(
                t1, t2, t3,
                success: (s1, s2, s3) => Success<R, IEnumerable<E>>(success(s1, s2, s3)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, Func<A1, A2, A3, R> success)
        {
            return Aggregate(
                t1, t2, t3,
                success: (s1, s2, s3) => Success<R, IEnumerable<E>>(success(s1, s2, s3)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, Func<A1, A2, A3, R> success)
        {
            return Aggregate(
                t1, t2, t3,
                success: (s1, s2, s3) => Success(success(s1, s2, s3)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, Func<A1, A2, A3, A4, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, Func<A1, A2, A3, A4, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4,
                success: (s1, s2, s3, s4) => Success<R, Exception>(success(s1, s2, s3, s4)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, Func<A1, A2, A3, A4, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4,
                success: (s1, s2, s3, s4) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, Func<A1, A2, A3, A4, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4,
                success: (s1, s2, s3, s4) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, Func<A1, A2, A3, A4, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4,
                success: (s1, s2, s3, s4) => Success(success(s1, s2, s3, s4)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, Func<A1, A2, A3, A4, A5, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, Func<A1, A2, A3, A4, A5, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5,
                success: (s1, s2, s3, s4, s5) => Success<R, Exception>(success(s1, s2, s3, s4, s5)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, Func<A1, A2, A3, A4, A5, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5,
                success: (s1, s2, s3, s4, s5) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, Func<A1, A2, A3, A4, A5, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5,
                success: (s1, s2, s3, s4, s5) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, Func<A1, A2, A3, A4, A5, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5,
                success: (s1, s2, s3, s4, s5) => Success(success(s1, s2, s3, s4, s5)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, Func<A1, A2, A3, A4, A5, A6, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, Func<A1, A2, A3, A4, A5, A6, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6,
                success: (s1, s2, s3, s4, s5, s6) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, Func<A1, A2, A3, A4, A5, A6, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6,
                success: (s1, s2, s3, s4, s5, s6) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, Func<A1, A2, A3, A4, A5, A6, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6,
                success: (s1, s2, s3, s4, s5, s6) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, Func<A1, A2, A3, A4, A5, A6, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6,
                success: (s1, s2, s3, s4, s5, s6) => Success(success(s1, s2, s3, s4, s5, s6)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, Func<A1, A2, A3, A4, A5, A6, A7, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, A7, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, ITry<A7, Exception> t7, Func<A1, A2, A3, A4, A5, A6, A7, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7,
                success: (s1, s2, s3, s4, s5, s6, s7) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6, s7)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, A7, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, Func<A1, A2, A3, A4, A5, A6, A7, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7,
                success: (s1, s2, s3, s4, s5, s6, s7) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, ITry<A7, IEnumerable<E>> t7, Func<A1, A2, A3, A4, A5, A6, A7, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7,
                success: (s1, s2, s3, s4, s5, s6, s7) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, A7, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, ITry<A7> t7, Func<A1, A2, A3, A4, A5, A6, A7, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7,
                success: (s1, s2, s3, s4, s5, s6, s7) => Success(success(s1, s2, s3, s4, s5, s6, s7)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, ITry<A7, Exception> t7, ITry<A8, Exception> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8,
                success: (s1, s2, s3, s4, s5, s6, s7, s8) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6, s7, s8)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8,
                success: (s1, s2, s3, s4, s5, s6, s7, s8) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, ITry<A7, IEnumerable<E>> t7, ITry<A8, IEnumerable<E>> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8,
                success: (s1, s2, s3, s4, s5, s6, s7, s8) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, ITry<A7> t7, ITry<A8> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8,
                success: (s1, s2, s3, s4, s5, s6, s7, s8) => Success(success(s1, s2, s3, s4, s5, s6, s7, s8)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, ITry<A7, Exception> t7, ITry<A8, Exception> t8, ITry<A9, Exception> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, ITry<A7, IEnumerable<E>> t7, ITry<A8, IEnumerable<E>> t8, ITry<A9, IEnumerable<E>> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, ITry<A7> t7, ITry<A8> t8, ITry<A9> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success(success(s1, s2, s3, s4, s5, s6, s7, s8, s9)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, ITry<A7, Exception> t7, ITry<A8, Exception> t8, ITry<A9, Exception> t9, ITry<A10, Exception> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, ITry<A7, IEnumerable<E>> t7, ITry<A8, IEnumerable<E>> t8, ITry<A9, IEnumerable<E>> t9, ITry<A10, IEnumerable<E>> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, ITry<A7> t7, ITry<A8> t8, ITry<A9> t9, ITry<A10> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, ITry<A7, Exception> t7, ITry<A8, Exception> t8, ITry<A9, Exception> t9, ITry<A10, Exception> t10, ITry<A11, Exception> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, ITry<A7, IEnumerable<E>> t7, ITry<A8, IEnumerable<E>> t8, ITry<A9, IEnumerable<E>> t9, ITry<A10, IEnumerable<E>> t10, ITry<A11, IEnumerable<E>> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, ITry<A7> t7, ITry<A8> t8, ITry<A9> t9, ITry<A10> t10, ITry<A11> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, ITry<A7, Exception> t7, ITry<A8, Exception> t8, ITry<A9, Exception> t9, ITry<A10, Exception> t10, ITry<A11, Exception> t11, ITry<A12, Exception> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, ITry<A7, IEnumerable<E>> t7, ITry<A8, IEnumerable<E>> t8, ITry<A9, IEnumerable<E>> t9, ITry<A10, IEnumerable<E>> t10, ITry<A11, IEnumerable<E>> t11, ITry<A12, IEnumerable<E>> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, ITry<A7> t7, ITry<A8> t8, ITry<A9> t9, ITry<A10> t10, ITry<A11> t11, ITry<A12> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, ITry<A13, E> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, ITry<A7, Exception> t7, ITry<A8, Exception> t8, ITry<A9, Exception> t9, ITry<A10, Exception> t10, ITry<A11, Exception> t11, ITry<A12, Exception> t12, ITry<A13, Exception> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, ITry<A13, E> t13, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, ITry<A13, E> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, ITry<A7, IEnumerable<E>> t7, ITry<A8, IEnumerable<E>> t8, ITry<A9, IEnumerable<E>> t9, ITry<A10, IEnumerable<E>> t10, ITry<A11, IEnumerable<E>> t11, ITry<A12, IEnumerable<E>> t12, ITry<A13, IEnumerable<E>> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, ITry<A7> t7, ITry<A8> t8, ITry<A9> t9, ITry<A10> t10, ITry<A11> t11, ITry<A12> t12, ITry<A13> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, ITry<A13, E> t13, ITry<A14, E> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess && t14.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get(), t14.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error, t14.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, ITry<A7, Exception> t7, ITry<A8, Exception> t8, ITry<A9, Exception> t9, ITry<A10, Exception> t10, ITry<A11, Exception> t11, ITry<A12, Exception> t12, ITry<A13, Exception> t13, ITry<A14, Exception> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, ITry<A13, E> t13, ITry<A14, E> t14, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, ITry<A13, E> t13, ITry<A14, E> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, ITry<A7, IEnumerable<E>> t7, ITry<A8, IEnumerable<E>> t8, ITry<A9, IEnumerable<E>> t9, ITry<A10, IEnumerable<E>> t10, ITry<A11, IEnumerable<E>> t11, ITry<A12, IEnumerable<E>> t12, ITry<A13, IEnumerable<E>> t13, ITry<A14, IEnumerable<E>> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, ITry<A7> t7, ITry<A8> t8, ITry<A9> t9, ITry<A10> t10, ITry<A11> t11, ITry<A12> t12, ITry<A13> t13, ITry<A14> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, ITry<A13, E> t13, ITry<A14, E> t14, ITry<A15, E> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess && t14.IsSuccess && t15.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get(), t14.Success.Get(), t15.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error, t14.Error, t15.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the exceptions.
        /// </summary>
        public static ITry<R, Exception> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R>(ITry<A1, Exception> t1, ITry<A2, Exception> t2, ITry<A3, Exception> t3, ITry<A4, Exception> t4, ITry<A5, Exception> t5, ITry<A6, Exception> t6, ITry<A7, Exception> t7, ITry<A8, Exception> t8, ITry<A9, Exception> t9, ITry<A10, Exception> t10, ITry<A11, Exception> t11, ITry<A12, Exception> t12, ITry<A13, Exception> t13, ITry<A14, Exception> t14, ITry<A15, Exception> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success<R, Exception>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)),
                error: exceptions => Error<R, Exception>(exceptions.Aggregate().Get())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, E, R>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, ITry<A13, E> t13, ITry<A14, E> t14, ITry<A15, E> t15, Func<E, E, E> errorAggregate, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success, Func<E, R> error)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
                success: success,
                error: errors => error(errors.Aggregate(errorAggregate))
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R, E>(ITry<A1, E> t1, ITry<A2, E> t2, ITry<A3, E> t3, ITry<A4, E> t4, ITry<A5, E> t5, ITry<A6, E> t6, ITry<A7, E> t7, ITry<A8, E> t8, ITry<A9, E> t9, ITry<A10, E> t10, ITry<A11, E> t11, ITry<A12, E> t12, ITry<A13, E> t13, ITry<A14, E> t14, ITry<A15, E> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)),
                error: errors => Error<R, IEnumerable<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static ITry<R, IEnumerable<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R, E>(ITry<A1, IEnumerable<E>> t1, ITry<A2, IEnumerable<E>> t2, ITry<A3, IEnumerable<E>> t3, ITry<A4, IEnumerable<E>> t4, ITry<A5, IEnumerable<E>> t5, ITry<A6, IEnumerable<E>> t6, ITry<A7, IEnumerable<E>> t7, ITry<A8, IEnumerable<E>> t8, ITry<A9, IEnumerable<E>> t9, ITry<A10, IEnumerable<E>> t10, ITry<A11, IEnumerable<E>> t11, ITry<A12, IEnumerable<E>> t12, ITry<A13, IEnumerable<E>> t13, ITry<A14, IEnumerable<E>> t14, ITry<A15, IEnumerable<E>> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success<R, IEnumerable<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)),
                error: errors => Error<R, IEnumerable<E>>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into error result by concatenation.
        /// </summary>
        public static ITry<R> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R>(ITry<A1> t1, ITry<A2> t2, ITry<A3> t3, ITry<A4> t4, ITry<A5> t5, ITry<A6> t6, ITry<A7> t7, ITry<A8> t8, ITry<A9> t9, ITry<A10> t10, ITry<A11> t11, ITry<A12> t12, ITry<A13> t13, ITry<A14> t14, ITry<A15> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)),
                error: errors => Error<R>(errors),
                errorAggregate: (e1, e2) => e1.Concat(e2)
            );
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
                e =>
                {
                    var exception = e.SingleOption();
                    if (exception.NonEmpty)
                    {
                        ExceptionDispatchInfo.Capture(exception.Get()).Throw();
                    }

                    throw new AggregateException(e);
                }
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
