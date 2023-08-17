using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp;

public static class IReadOnlyListExtensions
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
        return source.Count > 1;
    }

    public static bool IsSingle<T>(this IReadOnlyList<T> source)
    {
        return source.Count == 1;
    }

    public static IOption<T> SingleOption<T>(this IReadOnlyList<T> source)
    {
        return source.IsSingle().Match(
            t => Option.Valued(source[0]),
            f => Option.Empty<T>()
        );
    }

    public static IOption<T> FirstOption<T>(this IReadOnlyList<T> source)
    {
        return source.IsEmpty().Match(
            t => Option.Empty<T>(),
            f => Option.Valued(source[0])
        );
    }

    public static T Second<T>(this IReadOnlyList<T> source)
    {
        if (source.Count <= 1)
        {
            throw new ArgumentException("Source has less than 2 elements.");
        }

        return source[1];
    }

    public static T Last<T>(this IReadOnlyList<T> source)
    {
        if (source.Count == 0)
        {
            throw new ArgumentException("Source is empty.");
        }

        return source[source.Count - 1];
    }

    public static IOption<T> LastOption<T>(this IReadOnlyList<T> source)
    {
        return source.IsEmpty().Match(
            t => Option.Empty<T>(),
            f => Option.Valued(source[source.Count - 1])
        );
    }

    public static T ElementAt<T>(this IReadOnlyList<T> source, int index)
    {
        return source[index];
    }

    public static IOption<T> ElementAtOption<T>(this IReadOnlyList<T> source, NonNegativeInt index)
    {
        return (source.Count > index).Match(
            t => source[index].ToOption(),
            f => Option.Empty<T>()
        );
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

public static class ReadOnlyList
{
    public static IReadOnlyList<T> Create<T>(params T[] values)
    {
        return CreateFlat(values);
    }

    public static IReadOnlyList<T> Create<T>(IEnumerable<T> values)
    {
        return values.ToList();
    }

    public static IReadOnlyList<T> Create<T>(IReadOnlyList<T> values)
    {
        return values.ToList();
    }

    public static IReadOnlyList<T> CreateFlat<T>(params IEnumerable<T>[] values)
    {
        return values.Flatten().ToList();
    }

    public static IReadOnlyList<T> CreateFlat<T>(params IOption<T>[] values)
    {
        return CreateFlat(values.AsEnumerable());
    }

    public static IReadOnlyList<T> CreateFlat<T>(params IEnumerable<IOption<T>>[] values)
    {
        return values.Flatten().Flatten().ToList();
    }

    public static IReadOnlyList<T> CreateFlat<T>(params IOption<IEnumerable<T>>[] values)
    {
        return values.SelectMany(v => v.Flatten()).ToList();
    }

    public static IReadOnlyList<T> Empty<T>()
    {
        return ReadOnlyList<T>.Empty;
    }
}

public class ReadOnlyList<T>
{
    public static readonly IReadOnlyList<T> Empty = new List<T>();
}
