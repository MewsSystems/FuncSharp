
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace FuncSharp;

public static class Try
{
    /// <summary>
    /// Creates a new try with a successful result.
    /// </summary>
    public static Try<TSuccess, TError> Success<TSuccess, TError>(TSuccess success)
    {
        return new Try<TSuccess, TError>(success);
    }

    /// <summary>
    /// Creates a new try with an error result.
    /// </summary>
    public static Try<TSuccess, TError> Error<TSuccess, TError>(TError error)
    {
        return new Try<TSuccess, TError>(error);
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
    public static Try<TSuccess, TException> Catch<TSuccess, TException>(Func<Unit, TSuccess> f)
        where TException : Exception
    {
        try
        {
            return Success<TSuccess, TException>(f(Unit.Value));
        }
        catch (TException e)
        {
            return Error<TSuccess, TException>(e);
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
    public static TResult Aggregate<TSuccess, TError, TResult>(IEnumerable<Try<TSuccess, TError>> tries, Func<IReadOnlyList<TSuccess>, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<IReadOnlyList<TSuccess>, IReadOnlyList<TError>> Aggregate<TSuccess, TError>(IEnumerable<Try<TSuccess, TError>> tries)
    {
        return Aggregate(
            tries,
            success: results => Success<IReadOnlyList<TSuccess>, IReadOnlyList<TError>>(results),
            error: errors => Error<IReadOnlyList<TSuccess>, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates a collection of tries into a try of collection.
    /// </summary>
    public static Try<IReadOnlyList<TSuccess>, IReadOnlyList<TError>> Aggregate<TSuccess, TError>(IEnumerable<Try<TSuccess, IReadOnlyList<TError>>> tries)
    {
        return Aggregate(
            tries,
            success: results => Success<IReadOnlyList<TSuccess>, IReadOnlyList<TError>>(results),
            error: errors => Error<IReadOnlyList<TSuccess>, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Func<TSuccess1, TSuccess2, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Func<TSuccess1, TSuccess2, TResult> success)
    {
        return Aggregate(
            t1, t2,
            success: (s1, s2) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Func<TSuccess1, TSuccess2, TResult> success)
    {
        return Aggregate(
            t1, t2,
            success: (s1, s2) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Func<TSuccess1, TSuccess2, TSuccess3, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Func<TSuccess1, TSuccess2, TSuccess3, TResult> success)
    {
        return Aggregate(
            t1, t2, t3,
            success: (s1, s2, s3) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Func<TSuccess1, TSuccess2, TSuccess3, TResult> success)
    {
        return Aggregate(
            t1, t2, t3,
            success: (s1, s2, s3) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4,
            success: (s1, s2, s3, s4) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4,
            success: (s1, s2, s3, s4) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5,
            success: (s1, s2, s3, s4, s5) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5,
            success: (s1, s2, s3, s4, s5) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6,
            success: (s1, s2, s3, s4, s5, s6) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6,
            success: (s1, s2, s3, s4, s5, s6) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7,
            success: (s1, s2, s3, s4, s5, s6, s7) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Try<TSuccess7, IReadOnlyList<TError>> t7, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7,
            success: (s1, s2, s3, s4, s5, s6, s7) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8,
            success: (s1, s2, s3, s4, s5, s6, s7, s8) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Try<TSuccess7, IReadOnlyList<TError>> t7, Try<TSuccess8, IReadOnlyList<TError>> t8, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8,
            success: (s1, s2, s3, s4, s5, s6, s7, s8) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Try<TSuccess7, IReadOnlyList<TError>> t7, Try<TSuccess8, IReadOnlyList<TError>> t8, Try<TSuccess9, IReadOnlyList<TError>> t9, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Try<TSuccess7, IReadOnlyList<TError>> t7, Try<TSuccess8, IReadOnlyList<TError>> t8, Try<TSuccess9, IReadOnlyList<TError>> t9, Try<TSuccess10, IReadOnlyList<TError>> t10, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Try<TSuccess7, IReadOnlyList<TError>> t7, Try<TSuccess8, IReadOnlyList<TError>> t8, Try<TSuccess9, IReadOnlyList<TError>> t9, Try<TSuccess10, IReadOnlyList<TError>> t10, Try<TSuccess11, IReadOnlyList<TError>> t11, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Try<TSuccess12, TError> t12, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Try<TSuccess12, TError> t12, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Try<TSuccess7, IReadOnlyList<TError>> t7, Try<TSuccess8, IReadOnlyList<TError>> t8, Try<TSuccess9, IReadOnlyList<TError>> t9, Try<TSuccess10, IReadOnlyList<TError>> t10, Try<TSuccess11, IReadOnlyList<TError>> t11, Try<TSuccess12, IReadOnlyList<TError>> t12, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Try<TSuccess12, TError> t12, Try<TSuccess13, TError> t13, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Try<TSuccess12, TError> t12, Try<TSuccess13, TError> t13, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Try<TSuccess7, IReadOnlyList<TError>> t7, Try<TSuccess8, IReadOnlyList<TError>> t8, Try<TSuccess9, IReadOnlyList<TError>> t9, Try<TSuccess10, IReadOnlyList<TError>> t10, Try<TSuccess11, IReadOnlyList<TError>> t11, Try<TSuccess12, IReadOnlyList<TError>> t12, Try<TSuccess13, IReadOnlyList<TError>> t13, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Try<TSuccess12, TError> t12, Try<TSuccess13, TError> t13, Try<TSuccess14, TError> t14, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Try<TSuccess12, TError> t12, Try<TSuccess13, TError> t13, Try<TSuccess14, TError> t14, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Try<TSuccess7, IReadOnlyList<TError>> t7, Try<TSuccess8, IReadOnlyList<TError>> t8, Try<TSuccess9, IReadOnlyList<TError>> t9, Try<TSuccess10, IReadOnlyList<TError>> t10, Try<TSuccess11, IReadOnlyList<TError>> t11, Try<TSuccess12, IReadOnlyList<TError>> t12, Try<TSuccess13, IReadOnlyList<TError>> t13, Try<TSuccess14, IReadOnlyList<TError>> t14, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates the errors by the specified function.
    /// </summary>
    public static TResult Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TSuccess15, TError, TResult>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Try<TSuccess12, TError> t12, Try<TSuccess13, TError> t13, Try<TSuccess14, TError> t14, Try<TSuccess15, TError> t15, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TSuccess15, TResult> success, Func<IReadOnlyList<TError>, TResult> error)
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
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TSuccess15, TResult, TError>(Try<TSuccess1, TError> t1, Try<TSuccess2, TError> t2, Try<TSuccess3, TError> t3, Try<TSuccess4, TError> t4, Try<TSuccess5, TError> t5, Try<TSuccess6, TError> t6, Try<TSuccess7, TError> t7, Try<TSuccess8, TError> t8, Try<TSuccess9, TError> t9, Try<TSuccess10, TError> t10, Try<TSuccess11, TError> t11, Try<TSuccess12, TError> t12, Try<TSuccess13, TError> t13, Try<TSuccess14, TError> t14, Try<TSuccess15, TError> t15, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TSuccess15, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors)
        );
    }

    /// <summary>
    /// Aggregates the tries using the specified function if all of them are successful. Otherwise aggregates all errors into error result by concatenation.
    /// </summary>
    public static Try<TResult, IReadOnlyList<TError>> Aggregate<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TSuccess15, TResult, TError>(Try<TSuccess1, IReadOnlyList<TError>> t1, Try<TSuccess2, IReadOnlyList<TError>> t2, Try<TSuccess3, IReadOnlyList<TError>> t3, Try<TSuccess4, IReadOnlyList<TError>> t4, Try<TSuccess5, IReadOnlyList<TError>> t5, Try<TSuccess6, IReadOnlyList<TError>> t6, Try<TSuccess7, IReadOnlyList<TError>> t7, Try<TSuccess8, IReadOnlyList<TError>> t8, Try<TSuccess9, IReadOnlyList<TError>> t9, Try<TSuccess10, IReadOnlyList<TError>> t10, Try<TSuccess11, IReadOnlyList<TError>> t11, Try<TSuccess12, IReadOnlyList<TError>> t12, Try<TSuccess13, IReadOnlyList<TError>> t13, Try<TSuccess14, IReadOnlyList<TError>> t14, Try<TSuccess15, IReadOnlyList<TError>> t15, Func<TSuccess1, TSuccess2, TSuccess3, TSuccess4, TSuccess5, TSuccess6, TSuccess7, TSuccess8, TSuccess9, TSuccess10, TSuccess11, TSuccess12, TSuccess13, TSuccess14, TSuccess15, TResult> success)
    {
        return Aggregate(
            t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15,
            success: (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) => Success<TResult, IReadOnlyList<TError>>(success(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15)),
            error: errors => Error<TResult, IReadOnlyList<TError>>(errors.SelectMany(e => e).ToList())
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

public struct Try<TSuccess, TError> : IEquatable<Try<TSuccess, TError>>
{
    public Try(TSuccess success)
    {
        IsSuccess = true;
        Success = Option.Valued(success);
        IsError = false;
        Error = Option.Empty<TError>();
    }

    public Try(TError error)
    {
        IsSuccess = false;
        Success = Option.Empty<TSuccess>();
        IsError = true;
        Error = Option.Valued(error);
    }

    public bool IsSuccess { get; }
    public bool IsError { get; }
    public Option<TSuccess> Success { get; }
    public Option<TError> Error { get; }

    /// <summary>
    /// Maps the success into another type if the try succeeded.
    /// </summary>
    [Pure]
    public Try<TSuccessTarget, TError> Map<TSuccessTarget>(Func<TSuccess, TSuccessTarget> f)
    {
        return IsSuccess
            ? new Try<TSuccessTarget, TError>(f(Success.Value))
            : new Try<TSuccessTarget, TError>(Error.Value);
    }

    /// <summary>
    /// Maps the both the succees and the error into another types. Each function is called only when applicable.
    /// </summary>
    [Pure]
    public Try<TSuccessTarget, TErrorTarget> Map<TSuccessTarget, TErrorTarget>(Func<TSuccess, TSuccessTarget> success, Func<TError, TErrorTarget> error)
    {
        return IsSuccess
            ? new Try<TSuccessTarget, TErrorTarget>(success(Success.Value))
            : new Try<TSuccessTarget, TErrorTarget>(error(Error.Value));
    }

    /// <summary>
    /// Maps the error into another type if the try did not succeed.
    /// </summary>
    [Pure]
    public Try<TSuccess, TErrorTarget> MapError<TErrorTarget>(Func<TError, TErrorTarget> f)
    {
        return IsSuccess
            ? new Try<TSuccess, TErrorTarget>(Success.Value)
            : new Try<TSuccess, TErrorTarget>(f(Error.Value));
    }

    /// <summary>
    /// Returns result of the applicable function. Success when try succeeded. Error when not.
    /// </summary>
    [Pure]
    public TResult Match<TResult>(Func<TSuccess, TResult> ifSuccess, Func<TError, TResult> ifError)
    {
        return IsSuccess
            ? ifSuccess(Success.Value)
            : ifError(Error.Value);
    }

    /// <summary>
    /// Invokes the applicable function. Success when try succeeded. Error when not.
    /// </summary>
    [Pure]
    public void Match(Action<TSuccess> ifSuccess = null, Action<TError> ifError = null)
    {
        if (IsSuccess)
            ifSuccess?.Invoke(Success.Value);
        else
            ifError?.Invoke(Error.Value);
    }

    [Pure]
    public static bool operator ==(Try<TSuccess, TError> left, Try<TSuccess, TError> right)
    {
        return left.Equals(right);
    }

    [Pure]
    public static bool operator !=(Try<TSuccess, TError> left, Try<TSuccess, TError> right)
    {
        return !left.Equals(right);
    }

    [Pure]
    public bool Equals(Try<TSuccess, TError> other)
    {
        return IsSuccess == other.IsSuccess && IsError == other.IsError && Success.Equals(other.Success) && Error.Equals(other.Error);
    }

    [Pure]
    public override bool Equals(object obj)
    {
        return obj is Try<TSuccess, TError> other && Equals(other);
    }

    [Pure]
    public override int GetHashCode()
    {
        return HashCode.Combine(IsSuccess, IsError, Success, Error);
    }
}
