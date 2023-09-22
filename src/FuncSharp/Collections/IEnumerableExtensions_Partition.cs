using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Splits the items in a collection into 2 collection based on the condition provided.
    /// </summary>
    public static (IReadOnlyList<T> Passing, IReadOnlyList<T> Violating) Partition<T>(this IEnumerable<T> e, Func<T, bool> predicate)
    {
        var passing = new List<T>();
        var violating = new List<T>();
        foreach (var i in e)
        {
            if (predicate(i))
            {
                passing.Add(i);
            }
            else
            {
                violating.Add(i);
            }
        }
        return (passing, violating);
    }
}