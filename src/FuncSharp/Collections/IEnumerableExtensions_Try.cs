using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Splits a collection of tries into a collection of success results and a collection of errors.
    /// </summary>
    public static (IReadOnlyList<TSuccess>, IReadOnlyList<TError>) Partition<TSuccess, TError>(this IEnumerable<Try<TSuccess, TError>> values)
    {
        var passing = new List<TSuccess>();
        var violating = new List<TError>();
        foreach (var value in values)
        {
            if (value.IsSuccess)
            {
                passing.Add(value.Success.GetOrDefault());
            }
            else
            {
                violating.Add(value.Error.GetOrDefault());
            }
        }
        return (passing, violating);
    }

    /// <summary>
    /// Splits a collection of tries into a collection of success results and a collection of errors and executes an action for those.
    /// </summary>
    public static void PartitionMatch<TSuccess, TError>(this IEnumerable<Try<TSuccess, TError>> source, Action<IReadOnlyList<TSuccess>> f1, Action<IReadOnlyList<TError>> f2)
    {
        var list1 = new List<TSuccess>();
        var list2 = new List<TError>();
        foreach (var item in source)
        {
            item.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2)
            );
        }

        f1(list1);
        f2(list2);
    }

    public static IReadOnlyList<TResult> PartitionMatch<TSuccess, TError, TResult>(this IEnumerable<Try<TSuccess, TError>> source, Func<IReadOnlyList<TSuccess>, IEnumerable<TResult>> f1, Func<IReadOnlyList<TError>, IEnumerable<TResult>> f2)
    {
        var list1 = new List<TSuccess>();
        var list2 = new List<TError>();
        foreach (var item in source)
        {
            item.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2)
            );
        }

        return ReadOnlyList.CreateFlat(f1(list1), f2(list2));
    }
}