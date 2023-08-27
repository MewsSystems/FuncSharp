
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuncSharp
{
    public static class Try
    {
        /// <summary>
        /// Creates a new try with a successful result.
        /// </summary>
        public static Try<A, E> Success<A, E>(A success)
        {
            return new Try<A, E>(success);
        }

        /// <summary>
        /// Creates a new try with an error result.
        /// </summary>
        public static Try<A, E> Error<A, E>(E error)
        {
            return new Try<A, E>(error);
        }

        /// <summary>
        /// Tries the specified action and returns its result if it succeeds. Otherwise in case of the specified exception,
        /// returns result of the recovery function.
        /// </summary>
        public static TResult Catch<TResult, TException>(Func<Unit, TResult> action, Func<TException, TResult> recover)
            where TException : Exception
        {
            try
            {
                return action(Unit.Value);
            }
            catch (TException e)
            {
                return recover(e);
            }
        }

        /// <summary>
        /// Tries the specified action and returns a successful try if it succeeds. Otherwise in case of the specified exception,
        /// returns an erroneous try.
        /// </summary>
        public static Try<A, TException> Catch<A, TException>(Func<Unit, A> f)
            where TException : Exception
        {
            try
            {
                return Success<A, TException>(f(Unit.Value));
            }
            catch (TException e)
            {
                return Error<A, TException>(e);
            }
        }

        /// <summary>
        /// Tries to await the specified asynchronous action which returns a successful try wrapped in a <see cref="System.Threading.Tasks.Task"/>.
        /// Otherwise, in case of an <see cref="System.Exception"/>, an erroneous try wrapped in a <see cref="System.Threading.Tasks.Task"/> is returned,
        /// however this does not apply to <see cref="System.OperationCanceledException"/> and its inheritors.
        /// </summary>
        /// <exception cref="System.OperationCanceledException">
        /// The <paramref name="action"/> delegate has been canceled.
        /// </exception>
        public static async Task<Try<TResult, TException>> CatchAsync<TResult, TException>(Func<Unit, Task<TResult>> action)
            where TException : Exception
        {
            try
            {
                return Try.Success<TResult, TException>(await action(Unit.Value));
            }
            catch (TException e) when (!e.IsOrContainsOperationCanceledException())
            {
                return Try.Error<TResult, TException>(e);
            }
        }

        /// <summary>
        /// Tries to await the specified asynchronous action which returns a successful try wrapped in a <see cref="System.Threading.Tasks.Task"/>.
        /// Otherwise, in case of an <see cref="System.Exception"/>, an erroneous try wrapped in a <see cref="System.Threading.Tasks.Task"/> is returned,
        /// however this does not apply to <see cref="System.OperationCanceledException"/> and its inheritors.
        /// </summary>
        /// <exception cref="System.OperationCanceledException">
        /// The <paramref name="action"/> delegate has been canceled.
        /// </exception>
        public static async Task<TResult> CatchAsync<TResult, TException>(Func<Unit, Task<TResult>> action, Func<TException, Task<TResult>> recover)
            where TException : Exception
        {
            try
            {
                return await action(Unit.Value);
            }
            catch (TException e) when (!e.IsOrContainsOperationCanceledException())
            {
                return await recover(e);
            }
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors using the specified function.
        /// </summary>
        public static R Aggregate<A, E, R>(IEnumerable<Try<A, E>> tries, Func<IReadOnlyList<A>, R> success, Func<IReadOnlyList<E>, R> error)
        {
            var enumeratedTries = tries.ToList();
            if (enumeratedTries.All(t => t.IsSuccess))
            {
                return success(enumeratedTries.Select(t => t.Success).Flatten().ToList());
            }

            return error(enumeratedTries.Select(t => t.Error).Flatten().ToList());
        }

        /// <summary>
        /// Aggregates a collection of tries into a try of collection.
        /// </summary>
        public static Try<IReadOnlyList<A>, IReadOnlyList<E>> Aggregate<A, E>(IEnumerable<Try<A, E>> tries)
        {
            return Aggregate(
                tries,
                success: results => Success<IReadOnlyList<A>, IReadOnlyList<E>>(results),
                error: errors => Error<IReadOnlyList<A>, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates a collection of tries into a try of collection.
        /// </summary>
        public static Try<IReadOnlyList<A>, IReadOnlyList<E>> Aggregate<A, E>(IEnumerable<Try<A, IReadOnlyList<E>>> tries)
        {
            return Aggregate(
                tries,
                success: results => Success<IReadOnlyList<A>, IReadOnlyList<E>>(results),
                error: errors => Error<IReadOnlyList<A>, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, E, R>(Try<A1, E> t1, Try<A2, E> t2, Func<A1, A2, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, R, E>(Try<A1, E> t1, Try<A2, E> t2, Func<A1, A2, R> success)
        {
            return Aggregate(
                t1, t2,
                success: (s1, s2) => Success<R, IReadOnlyList<E>>(success(s1, s2)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Func<A1, A2, R> success)
        {
            return Aggregate(
                t1, t2,
                success: (s1, s2) => Success<R, IReadOnlyList<E>>(success(s1, s2)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Func<A1, A2, A3, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Func<A1, A2, A3, R> success)
        {
            return Aggregate(
                t1, t2, t3,
                success: (s1, s2, s3) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Func<A1, A2, A3, R> success)
        {
            return Aggregate(
                t1, t2, t3,
                success: (s1, s2, s3) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Func<A1, A2, A3, A4, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Func<A1, A2, A3, A4, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4,
                success: (s1, s2, s3, s4) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Func<A1, A2, A3, A4, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4,
                success: (s1, s2, s3, s4) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Func<A1, A2, A3, A4, A5, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Func<A1, A2, A3, A4, A5, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5,
                success: (s1, s2, s3, s4, s5) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Func<A1, A2, A3, A4, A5, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5,
                success: (s1, s2, s3, s4, s5) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Func<A1, A2, A3, A4, A5, A6, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Func<A1, A2, A3, A4, A5, A6, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6,
                success: (s1, s2, s3, s4, s5, s6) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Func<A1, A2, A3, A4, A5, A6, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6,
                success: (s1, s2, s3, s4, s5, s6) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Func<A1, A2, A3, A4, A5, A6, A7, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Func<A1, A2, A3, A4, A5, A6, A7, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7,
                success: (s1, s2, s3, s4, s5, s6, s7) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Try<A7, IReadOnlyList<E>> t7, Func<A1, A2, A3, A4, A5, A6, A7, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7,
                success: (s1, s2, s3, s4, s5, s6, s7) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8,
                success: (s1, s2, s3, s4, s5, s6, s7, s8) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Try<A7, IReadOnlyList<E>> t7, Try<A8, IReadOnlyList<E>> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8,
                success: (s1, s2, s3, s4, s5, s6, s7, s8) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Try<A7, IReadOnlyList<E>> t7, Try<A8, IReadOnlyList<E>> t8, Try<A9, IReadOnlyList<E>> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Try<A7, IReadOnlyList<E>> t7, Try<A8, IReadOnlyList<E>> t8, Try<A9, IReadOnlyList<E>> t9, Try<A10, IReadOnlyList<E>> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Try<A7, IReadOnlyList<E>> t7, Try<A8, IReadOnlyList<E>> t8, Try<A9, IReadOnlyList<E>> t9, Try<A10, IReadOnlyList<E>> t10, Try<A11, IReadOnlyList<E>> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Try<A7, IReadOnlyList<E>> t7, Try<A8, IReadOnlyList<E>> t8, Try<A9, IReadOnlyList<E>> t9, Try<A10, IReadOnlyList<E>> t10, Try<A11, IReadOnlyList<E>> t11, Try<A12, IReadOnlyList<E>> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Try<A13, E> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Try<A13, E> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Try<A7, IReadOnlyList<E>> t7, Try<A8, IReadOnlyList<E>> t8, Try<A9, IReadOnlyList<E>> t9, Try<A10, IReadOnlyList<E>> t10, Try<A11, IReadOnlyList<E>> t11, Try<A12, IReadOnlyList<E>> t12, Try<A13, IReadOnlyList<E>> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Try<A13, E> t13, Try<A14, E> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess && t14.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get(), t14.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error, t14.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Try<A13, E> t13, Try<A14, E> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Try<A7, IReadOnlyList<E>> t7, Try<A8, IReadOnlyList<E>> t8, Try<A9, IReadOnlyList<E>> t9, Try<A10, IReadOnlyList<E>> t10, Try<A11, IReadOnlyList<E>> t11, Try<A12, IReadOnlyList<E>> t12, Try<A13, IReadOnlyList<E>> t13, Try<A14, IReadOnlyList<E>> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Try<A13, E> t13, Try<A14, E> t14, Try<A15, E> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success, Func<IReadOnlyList<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess && t14.IsSuccess && t15.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get(), t14.Success.Get(), t15.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error, t14.Error, t15.Error };
            return error(errors.Flatten().ToList());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R, E>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Try<A13, E> t13, Try<A14, E> t14, Try<A15, E> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)),
                error: errors => Error<R, IReadOnlyList<E>>(errors)
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
        /// </summary>
        public static Try<R, IReadOnlyList<E>> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R, E>(Try<A1, IReadOnlyList<E>> t1, Try<A2, IReadOnlyList<E>> t2, Try<A3, IReadOnlyList<E>> t3, Try<A4, IReadOnlyList<E>> t4, Try<A5, IReadOnlyList<E>> t5, Try<A6, IReadOnlyList<E>> t6, Try<A7, IReadOnlyList<E>> t7, Try<A8, IReadOnlyList<E>> t8, Try<A9, IReadOnlyList<E>> t9, Try<A10, IReadOnlyList<E>> t10, Try<A11, IReadOnlyList<E>> t11, Try<A12, IReadOnlyList<E>> t12, Try<A13, IReadOnlyList<E>> t13, Try<A14, IReadOnlyList<E>> t14, Try<A15, IReadOnlyList<E>> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success)
        {
            return Aggregate(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
                success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success<R, IReadOnlyList<E>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)),
                error: errors => Error<R, IReadOnlyList<E>>(errors.SelectMany(e => e).ToList())
            );
        }

        private static bool IsOrContainsOperationCanceledException(this Exception exception)
        {
            if (exception is OperationCanceledException)
            {
                return true;
            }

            if (exception.InnerException is not null)
            {
                return IsOrContainsOperationCanceledException(exception.InnerException);
            }

            return false;
        }
    }

    public class Try<A, E>
    {
        public Try(A success)
        {
            IsSuccess = true;
            Success = Option.Valued(success);
            IsError = false;
            Error = Option.Empty<E>();
        }

        public Try(E error)
        {
            IsSuccess = false;
            Success = Option.Empty<A>();
            IsError = true;
            Error = Option.Valued(error);
        }

        public bool IsSuccess { get; }
        public bool IsError { get; }
        public Option<A> Success { get; }
        public Option<E> Error { get; }

        /// <summary>
        /// Maps the success into another type if the try succeeded.
        /// </summary>
        public Try<B, E> Map<B>(Func<A, B> f)
        {
            return IsSuccess
                ? new Try<B, E>(f(Success.GetOrDefault()))
                : new Try<B, E>(Error.GetOrDefault());
        }

        /// <summary>
        /// Maps the both the succees and the error into another types. Each function is called only when applicable.
        /// </summary>
        public Try<B, F> Map<B, F>(Func<A, B> success, Func<E, F> error)
        {
            return IsSuccess
                ? new Try<B, F>(success(Success.GetOrDefault()))
                : new Try<B, F>(error(Error.GetOrDefault()));
        }

        /// <summary>
        /// Maps the error into another type if the try did not succeed.
        /// </summary>
        public Try<A, F> MapError<F>(Func<E, F> f)
        {
            return IsSuccess
                ? new Try<A, F>(Success.GetOrDefault())
                : new Try<A, F>(f(Error.GetOrDefault()));
        }

        /// <summary>
        /// Returns result of the applicable function. Success when try succeeded. Error when not.
        /// </summary>
        public TResult Match<TResult>(Func<A, TResult> ifSuccess, Func<E, TResult> ifError)
        {
            return IsSuccess
                ? ifSuccess(Success.GetOrDefault())
                : ifError(Error.GetOrDefault());
        }

        /// <summary>
        /// Invokes the applicable function. Success when try succeeded. Error when not.
        /// </summary>
        public void Match(Action<A> ifSuccess = null, Action<E> ifError = null)
        {
            if (IsSuccess)
                ifSuccess?.Invoke(Success.GetOrDefault());
            else
                ifError?.Invoke(Error.GetOrDefault());
        }
    }
}
