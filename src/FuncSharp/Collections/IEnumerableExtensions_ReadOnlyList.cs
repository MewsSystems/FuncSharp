using System;
using System.Collections.Generic;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
    public static bool NonEmpty<T>(this IReadOnlyList<T> source)
    {
        return source is not null && source.Count > 0;
    }

    public static bool IsEmpty<T>(this IReadOnlyList<T> source)
    {
        return !source.NonEmpty();
    }

    public static bool IsMultiple<T>(this IReadOnlyList<T> source)
    {
        return source is not null && source.Count > 1;
    }

    public static bool IsSingle<T>(this IReadOnlyList<T> source)
    {
        return source is not null && source.Count == 1;
    }

    public static T Single<T>(this IReadOnlyList<T> source)
    {
        return !source.IsSingle()
            ? throw new ArgumentException("Source is not a single element.")
            : source[0];
    }

    public static IOption<T> SingleOption<T>(this IReadOnlyList<T> source)
    {
        return source.IsSingle()
            ? Option.Valued(source[0])
            : Option.Empty<T>();
    }

    public static T First<T>(this IReadOnlyList<T> source)
    {
        return source.IsEmpty()
            ? throw new ArgumentException("Source is empty.")
            : source[0];
    }

    public static IOption<T> FirstOption<T>(this IReadOnlyList<T> source)
    {
        return source.IsEmpty()
            ? Option.Empty<T>()
            : Option.Valued(source[0]);
    }

    public static T Second<T>(this IReadOnlyList<T> source)
    {
        return source.Count <= 1
            ? throw new ArgumentException("Source has less than 2 elements.")
            : source[1];
    }

    public static T Last<T>(this IReadOnlyList<T> source)
    {
        return source.Count == 0
            ? throw new ArgumentException("Source is empty.")
            : source[source.Count - 1];
    }

    public static IOption<T> LastOption<T>(this IReadOnlyList<T> source)
    {
        return source.IsEmpty()
            ? Option.Empty<T>()
            : Option.Valued(source[source.Count - 1]);
    }

    public static T ElementAt<T>(this IReadOnlyList<T> source, int index)
    {
        return source[index];
    }

    public static IOption<T> ElementAtOption<T>(this IReadOnlyList<T> source, NonNegativeInt index)
    {
        return source.Count > index.Value
            ? Option.Valued(source[index.Value])
            : Option.Empty<T>();
    }

    public static int IndexOf<T>(this IReadOnlyList<T> source, T item)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (source[i].SafeEquals(item))
            {
                return i;
            }
        }
        return -1;
    }
}