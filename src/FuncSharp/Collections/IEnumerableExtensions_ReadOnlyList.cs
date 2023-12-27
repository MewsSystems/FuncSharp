using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
    [Pure]
    public static bool IsMultiple<T>(this IReadOnlyCollection<T> collection)
    {
        return collection.Count > 1;
    }

    [Pure]
    public static bool IsSingle<T>(this IReadOnlyCollection<T> collection)
    {
        return collection.Count == 1;
    }

    [Pure]
    public static T Single<T>(this IReadOnlyList<T> list)
    {
        return list.Count == 1
            ? list[0]
            : throw new ArgumentException("Source is not a single element.");
    }

    [Pure]
    public static Option<T> SingleOption<T>(this IReadOnlyList<T> list)
    {
        return list.Count == 1
            ? Option.Valued(list[0])
            : Option.Empty<T>();
    }

    [Pure]
    public static T First<T>(this IReadOnlyList<T> list)
    {
        return list.ElementAt(0);
    }

    /// <summary>
    /// Returns the first element inside the list or an empty option if the list is empty.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="list"/> parameter is null.</exception>
    [Pure]
    public static Option<T> FirstOption<T>(this IReadOnlyList<T> list)
    {
        return list.Count == 0
            ? Option.Empty<T>()
            : Option.Valued(list[0]);
    }

    [Pure]
    public static T Second<T>(this IReadOnlyList<T> list)
    {
        return list[1];
    }

    public static T Third<T>(this IReadOnlyList<T> list)
    {
        return list[2];
    }

    public static T Fourth<T>(this IReadOnlyList<T> list)
    {
        return list[3];
    }

    public static T Fifth<T>(this IReadOnlyList<T> list)
    {
        return list[4];
    }

    [Pure]
    public static T Last<T>(this IReadOnlyList<T> list)
    {
        return list.Count == 0
            ? throw new ArgumentException("Source is empty.")
            : list[list.Count - 1];
    }

    /// <summary>
    /// Returns the last element inside the list or an empty option if the list is empty.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="list"/> parameter is null.</exception>
    [Pure]
    public static Option<T> LastOption<T>(this IReadOnlyList<T> list)
    {
        return list.Count == 0
            ? Option.Empty<T>()
            : Option.Valued(list[list.Count - 1]);
    }

    [Pure]
    public static T ElementAt<T>(this IReadOnlyList<T> list, int index)
    {
        return list[index];
    }

    [Pure]
    public static Option<T> ElementAtOption<T>(this IReadOnlyList<T> list, NonNegativeInt index)
    {
        return list.Count > index.Value
            ? Option.Valued(list[index.Value])
            : Option.Empty<T>();
    }

    [Pure]
    public static int IndexOf<T>(this IReadOnlyList<T> list, T item)
    {
        for (var i = 0; i < list.Count; i++)
        {
            if (Equals(list[i], item))
            {
                return i;
            }
        }
        return -1;
    }
}