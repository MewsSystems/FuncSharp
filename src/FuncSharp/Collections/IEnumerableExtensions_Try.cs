using System;
using System.Collections.Generic;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Splits a collection of tries into a collection of success results and a collection of errors.
    /// </summary>
    public static (IReadOnlyList<TSuccess>, IReadOnlyList<TError>) Partition<TSuccess, TError>(this IEnumerable<Try<TSuccess, TError>> values)
    {
        var successes = new List<TSuccess>();
        var errors = new List<TError>();
        foreach (var value in values)
        {
            if (value.IsSuccess)
            {
                successes.Add(value.Success.GetOrDefault());
            }
            else
            {
                errors.Add(value.Error.GetOrDefault());
            }
        }
        return (successes, errors);
    }

    /// <summary>
    /// Splits a collection of tries into a collection of success results and a collection of errors and executes an action for those.
    /// </summary>
    public static void PartitionMatch<TSuccess, TError>(this IEnumerable<Try<TSuccess, TError>> values, Action<IReadOnlyList<TSuccess>> success, Action<IReadOnlyList<TError>> error)
    {
        var successes = new List<TSuccess>();
        var errors = new List<TError>();
        foreach (var item in values)
        {
            if (item.IsSuccess)
            {
                successes.Add(item.Success.Value);
            }
            else
            {
                errors.Add(item.Error.Value);
            }
        }

        success(successes);
        error(errors);
    }

    public static IReadOnlyList<TResult> PartitionMatch<TSuccess, TError, TResult>(
        this IEnumerable<Try<TSuccess, TError>> values,
        Func<IReadOnlyList<TSuccess>, IEnumerable<TResult>> success,
        Func<IReadOnlyList<TError>, IEnumerable<TResult>> error)
    {
        var successes = new List<TSuccess>();
        var errors = new List<TError>();
        foreach (var item in values)
        {
            if (item.IsSuccess)
            {
                successes.Add(item.Success.Value);
            }
            else
            {
                errors.Add(item.Error.Value);
            }
        }

        return ReadOnlyList.CreateFlat(success(successes), error(errors));
    }
}