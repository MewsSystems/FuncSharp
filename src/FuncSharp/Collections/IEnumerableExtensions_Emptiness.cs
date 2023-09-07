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

    /// <summary>
    /// Returns the same enumerable that was provided because it's already not empty. It's just wrapped in an option.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    [Obsolete("This is already a NonEmptyEnumerable.", error: true)]
    public static Option<INonEmptyEnumerable<T>> AsNonEmpty<T>(this INonEmptyEnumerable<T> source)
    {
        return source.ToOption();
    }

    /// <summary>
    /// Returns true if the collection contains at least one  element.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    [Obsolete("This method is obsolete because there were breaking changes and some people might put a null into this method expecting it to work. It will be made non-obsolete on 20th of September 2023", error: true)]
    public static bool NonEmpty<T>(this IEnumerable<T> source)
    {
        return source.Any();
    }

    /// <summary>
    /// Returns true if the collection contains no elements.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    [Obsolete("This method is obsolete because there were breaking changes and some people might put a null into this method expecting it to work. It will be made non-obsolete on 20th of September 2023", error: true)]
    public static bool IsEmpty<T>(this IEnumerable<T> source)
    {
        return !source.Any();
    }

    /// <summary>
    /// Returns true if the collection contains at least one  element.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    [Pure]
    [Obsolete("This method is obsolete because there were breaking changes and some people might put a null into this method expecting it to work. It will be made non-obsolete on 20th of September 2023", error: true)]
    public static bool NonEmpty<T>(this IReadOnlyCollection<T> source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return source.Count > 0;
    }

    /// <summary>
    /// Returns true if the collection contains no elements.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    [Pure]
    [Obsolete("This method is obsolete because there were breaking changes and some people might put a null into this method expecting it to work. It will be made non-obsolete on 20th of September 2023", error: true)]
    public static bool IsEmpty<T>(this IReadOnlyCollection<T> source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return source.Count == 0;
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