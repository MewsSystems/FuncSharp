using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
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

    [Pure]
    public static bool IsMultiple<T>(this IReadOnlyCollection<T> collection)
    {
        return collection is not null && collection.Count > 1;
    }

    [Pure]
    public static bool IsSingle<T>(this IReadOnlyCollection<T> collection)
    {
        return collection is not null && collection.Count == 1;
    }

    [Pure]
    public static T Single<T>(this IReadOnlyList<T> list)
    {
        return list.Count == 1
            ? list[0]
            : throw new ArgumentException("Source is not a single element.");
    }

    [Pure]
    public static IOption<T> SingleOption<T>(this IReadOnlyList<T> list)
    {
        return list.IsSingle()
            ? Option.Valued(list[0])
            : Option.Empty<T>();
    }

    [Pure]
    public static T First<T>(this IReadOnlyList<T> list)
    {
        return list.ElementAt(0);
    }

    [Pure]
    public static IOption<T> FirstOption<T>(this IReadOnlyList<T> list)
    {
        return list.IsEmpty()
            ? Option.Empty<T>()
            : Option.Valued(list[0]);
    }

    [Pure]
    public static T Second<T>(this IReadOnlyList<T> list)
    {
        return list.ElementAt(1);
    }

    public static T Third<T>(this IReadOnlyList<T> list)
    {
        return list.ElementAt(2);
    }

    public static T Fourth<T>(this IReadOnlyList<T> list)
    {
        return list.ElementAt(3);
    }

    public static T Fifth<T>(this IReadOnlyList<T> list)
    {
        return list.ElementAt(4);
    }

    [Pure]
    public static T Last<T>(this IReadOnlyList<T> list)
    {
        return list.Count == 0
            ? throw new ArgumentException("Source is empty.")
            : list[list.Count - 1];
    }

    [Pure]
    public static IOption<T> LastOption<T>(this IReadOnlyList<T> list)
    {
        return list.IsEmpty()
            ? Option.Empty<T>()
            : Option.Valued(list[list.Count - 1]);
    }

    [Pure]
    public static T ElementAt<T>(this IReadOnlyList<T> list, int index)
    {
        return list[index];
    }

    [Pure]
    public static IOption<T> ElementAtOption<T>(this IReadOnlyList<T> list, NonNegativeInt index)
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
            if (list[i].SafeEquals(item))
            {
                return i;
            }
        }
        return -1;
    }
}