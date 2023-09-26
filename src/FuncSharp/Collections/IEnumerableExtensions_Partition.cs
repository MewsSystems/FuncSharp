using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Splits the items in a collection into 2 collection based on the condition provided.
    /// </summary>
    public static (IReadOnlyList<T> Passing, IReadOnlyList<T> Violating) Partition<T>(this IEnumerable<T> values, Func<T, bool> predicate)
    {
        var passing = new List<T>();
        var violating = new List<T>();
        foreach (var value in values)
        {
            if (predicate(value))
            {
                passing.Add(value);
            }
            else
            {
                violating.Add(value);
            }
        }
        return (passing, violating);
    }
}