using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Returns a nonEmptyEnumerable in case the collection is nonempty. Otherwise returns empty option.
    /// </summary>
    [DebuggerStepThrough]
    public static Option<INonEmptyEnumerable<T>> AsNonEmpty<T>(this IEnumerable<T> source)
    {
        return source switch
        {
            null => Option.Empty<INonEmptyEnumerable<T>>(),
            INonEmptyEnumerable<T> list => Option.Valued(list),
            _ => NonEmptyEnumerable.Create(source)
        };
    }

    [Obsolete("This is already a NonEmptyEnumerable.", error: true)]
    public static Option<INonEmptyEnumerable<T>> AsNonEmpty<T>(this INonEmptyEnumerable<T> source)
    {
        throw new NotImplementedException();
    }

    public static bool NonEmpty<T>(this IEnumerable<T> e)
    {
        return e is not null && e.Any();
    }

    public static bool IsEmpty<T>(this IEnumerable<T> e)
    {
        return !e.NonEmpty();
    }

    [Pure]
    public static bool NonEmpty<T>(this IReadOnlyCollection<T> collection)
    {
        return collection is not null && collection.Count > 0;
    }

    [Pure]
    public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
    {
        return !collection.NonEmpty();
    }

    [Obsolete("This is a NonEmptyEnumerable. It's not empty.", error: true)]
    public static bool NonEmpty<T>(this INonEmptyEnumerable<T> source)
    {
        return true;
    }

    [Obsolete("This is a NonEmptyEnumerable. It's not empty.", error: true)]
    public static bool IsEmpty<T>(this INonEmptyEnumerable<T> source)
    {
        return false;
    }
}