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
        public static Try<A> Create<A, E>(Func<Unit, A> f)
            where E : Exception
        {
            return Catch<Try<A>, E>(
                _ => Success(f(Unit.Value)),
                e => Exception(e)
            );
        }

        /// <summary>
        /// Create a new try with the result of the specified function while converting all exceptions into erroneous result.
        /// </summary>
        public static Try<A> Create<A>(Func<Unit, A> f)
        {
            return Create<A, Exception>(f);
        }

        /// <summary>
        /// Creates a new try with a successful result.
        /// </summary>
        public static TrySuccess<A> Success<A>(A value)
        {
            return new TrySuccess<A>(value);
        }

        /// <summary>
        /// Creates a new try with a successful result.
        /// </summary>
        public static Try<A, E> Success<A, E>(A value)
        {
            return new Try<A, E>(value);
        }

        /// <summary>
        /// Creates a new try with an error result.
        /// </summary>
        public static TryError<E> Error<E>(E error)
        {
            return new TryError<E>(error);
        }

        /// <summary>
        /// Creates a new try with an error result.
        /// </summary>
        public static Try<A, E> Error<A, E>(E error)
        {
            return new Try<A, E>(error);
        }

        /// <summary>
        /// Creates a new try with an exception result.
        /// </summary>
        public static TryException Exception(Exception exception)
        {
            return new TryException(exception);
        }

        /// <summary>
        /// Creates a new try with an error result.
        /// </summary>
        public static Try<A> Exception<A>(Exception exception)
        {
            return new Try<A>(exception);
        }

        /// <summary>
        /// Aggregates a collection of tries into a try of collection.
        /// </summary>
        public static Try<IEnumerable<A>> Aggregate<A>(IEnumerable<Try<A>> tries)
        {
            return Aggregate<A, Exception, Try<IEnumerable<A>>>(
                tries,
                t => Success(t),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A, E, R>(IEnumerable<Try<A, E>> tries, Func<IEnumerable<A>, R> success, Func<IEnumerable<E>, R> error)
        {
            var enumeratedTries = tries.ToList();
            if (enumeratedTries.All(t => t.IsSuccess))
            {
                return success(enumeratedTries.Select(t => t.Success).Flatten().ToList());
            }

            return error(enumeratedTries.Select(t => t.Error).Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, E, R>(Try<A1, E> t1, Try<A2, E> t2, Func<A1, A2, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, B>(Try<A1> t1, Try<A2> t2, Func<A1, A2, B> f)
        {
            return Aggregate<A1, A2, Exception, Try<B>>(
                t1, t2,
                (s1, s2) => Success(f(s1, s2)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Func<A1, A2, A3, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Func<A1, A2, A3, B> f)
        {
            return Aggregate<A1, A2, A3, Exception, Try<B>>(
                t1, t2, t3,
                (s1, s2, s3) => Success(f(s1, s2, s3)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Func<A1, A2, A3, A4, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Func<A1, A2, A3, A4, B> f)
        {
            return Aggregate<A1, A2, A3, A4, Exception, Try<B>>(
                t1, t2, t3, t4,
                (s1, s2, s3, s4) => Success(f(s1, s2, s3, s4)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Func<A1, A2, A3, A4, A5, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Func<A1, A2, A3, A4, A5, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, Exception, Try<B>>(
                t1, t2, t3, t4, t5,
                (s1, s2, s3, s4, s5) => Success(f(s1, s2, s3, s4, s5)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Func<A1, A2, A3, A4, A5, A6, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Func<A1, A2, A3, A4, A5, A6, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6,
                (s1, s2, s3, s4, s5, s6) => Success(f(s1, s2, s3, s4, s5, s6)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Func<A1, A2, A3, A4, A5, A6, A7, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, A7, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Try<A7> t7, Func<A1, A2, A3, A4, A5, A6, A7, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, A7, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6, t7,
                (s1, s2, s3, s4, s5, s6, s7) => Success(f(s1, s2, s3, s4, s5, s6, s7)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Try<A7> t7, Try<A8> t8, Func<A1, A2, A3, A4, A5, A6, A7, A8, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6, t7, t8,
                (s1, s2, s3, s4, s5, s6, s7, s8) => Success(f(s1, s2, s3, s4, s5, s6, s7, s8)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Try<A7> t7, Try<A8> t8, Try<A9> t9, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6, t7, t8, t9,
                (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success(f(s1, s2, s3, s4, s5, s6, s7, s8, s9)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Try<A7> t7, Try<A8> t8, Try<A9> t9, Try<A10> t10, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
                (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Try<A7> t7, Try<A8> t8, Try<A9> t9, Try<A10> t10, Try<A11> t11, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
                (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Try<A7> t7, Try<A8> t8, Try<A9> t9, Try<A10> t10, Try<A11> t11, Try<A12> t12, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
                (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Try<A13, E> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Try<A7> t7, Try<A8> t8, Try<A9> t9, Try<A10> t10, Try<A11> t11, Try<A12> t12, Try<A13> t13, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
                (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Try<A13, E> t13, Try<A14, E> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess && t14.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get(), t14.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error, t14.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Try<A7> t7, Try<A8> t8, Try<A9> t9, Try<A10> t10, Try<A11> t11, Try<A12> t12, Try<A13> t13, Try<A14> t14, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
                (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)),
                e => Exception(e.Aggregate())
            );
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by given aggregate and calls error function.
        /// </summary>
        public static R Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, E, R>(Try<A1, E> t1, Try<A2, E> t2, Try<A3, E> t3, Try<A4, E> t4, Try<A5, E> t5, Try<A6, E> t6, Try<A7, E> t7, Try<A8, E> t8, Try<A9, E> t9, Try<A10, E> t10, Try<A11, E> t11, Try<A12, E> t12, Try<A13, E> t13, Try<A14, E> t14, Try<A15, E> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> success, Func<IEnumerable<E>, R> error)
        {
            if (t1.IsSuccess && t2.IsSuccess && t3.IsSuccess && t4.IsSuccess && t5.IsSuccess && t6.IsSuccess && t7.IsSuccess && t8.IsSuccess && t9.IsSuccess && t10.IsSuccess && t11.IsSuccess && t12.IsSuccess && t13.IsSuccess && t14.IsSuccess && t15.IsSuccess)
            {
                return success(t1.Success.Get(), t2.Success.Get(), t3.Success.Get(), t4.Success.Get(), t5.Success.Get(), t6.Success.Get(), t7.Success.Get(), t8.Success.Get(), t9.Success.Get(), t10.Success.Get(), t11.Success.Get(), t12.Success.Get(), t13.Success.Get(), t14.Success.Get(), t15.Success.Get());
            }

            var errors = new[] { t1.Error, t2.Error, t3.Error, t4.Error, t5.Error, t6.Error, t7.Error, t8.Error, t9.Error, t10.Error, t11.Error, t12.Error, t13.Error, t14.Error, t15.Error };
            return error(errors.Flatten());
        }

        /// <summary>
        /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all exceptions into an AggregateException.
        /// </summary>
        public static Try<B> Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, B>(Try<A1> t1, Try<A2> t2, Try<A3> t3, Try<A4> t4, Try<A5> t5, Try<A6> t6, Try<A7> t7, Try<A8> t8, Try<A9> t9, Try<A10> t10, Try<A11> t11, Try<A12> t12, Try<A13> t13, Try<A14> t14, Try<A15> t15, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, B> f)
        {
            return Aggregate<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, Exception, Try<B>>(
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
                (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success(f(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)),
                e => Exception(e.Aggregate())
            );
        }
    }

    /// <summary>
    /// Result of an operation that may either succeed or fail with an error.
    /// </summary>
    public class Try<A, E> : Coproduct2<A, E>
    {
        internal Try(A success)
            : base(success)
        {
        }

        internal Try(E error)
            : base(error)
        {
        }

        /// <summary>
        /// Returns whether the result is a success.
        /// </summary>
        public bool IsSuccess
        {
            get { return IsFirst; }
        }

        /// <summary>
        /// Returns whether the result is an error.
        /// </summary>
        public bool IsError
        {
            get { return IsSecond; }
        }

        /// <summary>
        /// Returns the successful result.
        /// </summary>
        public Option<A> Success
        {
            get { return First; }
        }

        /// <summary>
        /// Returns the error result.
        /// </summary>
        public Option<E> Error
        {
            get { return Second; }
        }

        /// <summary>
        /// Maps the successful result to a new successful result.
        /// </summary>
        public Try<B, E> Map<B>(Func<A, B> f)
        {
            return Match<Try<B, E>>(
                s => Try.Success(f(s)),
                e => Try.Error(e)
            );
        }

        /// <summary>
        /// Maps the error result to a new error result.
        /// </summary>
        public Try<A, F> MapError<F>(Func<E, F> f)
        {
            return Match<Try<A, F>>(
                s => Try.Success(s),
                e => Try.Error(f(e))
            );
        }

        public static implicit operator Try<A, E>(TrySuccess<A> success)
        {
            return new Try<A, E>(success.Value);
        }

        public static implicit operator Try<A, E>(TryError<E> error)
        {
            return new Try<A, E>(error.Value);
        }
    }

    /// <summary>
    /// Result of an operation that may either succeed or fail with exception.
    /// </summary>
    public class Try<A> : Try<A, Exception>
    {
        internal Try(A success)
            : base(success)
        {
        }

        internal Try(Exception exception)
            : base(exception)
        {
        }

        /// <summary>
        /// If the result is success, returns it. Otherwise throws the exception result.
        /// </summary>
        public A Get()
        {
            return Match(
                s => s,
                e => throw e
            );
        }

        /// <summary>
        /// Maps the successful result to a new successful result and erroneous result into new erroneous result.
        /// </summary>
        public Try<B> Map<B>(Func<A, B> f, Func<Exception, Exception> g)
        {
            return Match<Try<B>>(
                s => Try.Success(f(s)),
                e => Try.Exception(g(e))
            );
        }

        /// <summary>
        /// Maps the successful result to a new successful result.
        /// </summary>
        public new Try<B> Map<B>(Func<A, B> f)
        {
            return Map(f, e => e);
        }

        /// <summary>
        /// Maps the exception result to a new exception result.
        /// </summary>
        public Try<A> MapError(Func<Exception, Exception> f)
        {
            return Map(s => s, f);
        }

        public static implicit operator Try<A>(TrySuccess<A> success)
        {
            return new Try<A>(success.Value);
        }

        public static implicit operator Try<A>(TryException exception)
        {
            return new Try<A>(exception.Value);
        }
    }
}
