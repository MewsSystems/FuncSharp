using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Returns values of the nonempty options.
    /// </summary>
    public static IEnumerable<T> Flatten<T>(this IEnumerable<Option<T>> source)
    {
        return source.Where(o => o.NonEmpty).Select(o => o.Value);
    }

    /// <summary>
    /// Returns the max value of the enumerable or an empty option if it is empty.
    /// </summary>
    public static Option<TValue> SafeMax<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector)
    {
        return source.AsNonEmpty().Map(s => s.Max(selector));
    }

    /// <summary>
    /// Returns the min value of the enumerable or an empty option if it is empty.
    /// </summary>
    public static Option<TValue> SafeMin<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector)
    {
        return source.AsNonEmpty().Map(s => s.Min(selector));
    }

    /// <summary>
    /// Returns the first element satisfying the predicate or an empty option if no such element exists.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    public static Option<T> FirstOption<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        return source.Where(predicate).FirstOption();
    }

    /// <summary>
    /// Returns the first element inside the enumerable or an empty option if the enumerable is empty.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    public static Option<T> FirstOption<T>(this IEnumerable<T> source)
    {
        if (source is IReadOnlyList<T> list)
        {
            return list.FirstOption();
        }

        using var enumerator = source.GetEnumerator();
        return enumerator.MoveNext()
            ? Option.Valued(enumerator.Current)
            : Option.Empty<T>();
    }

    /// <summary>
    /// Returns the last element satisfying the predicate or an empty option if no such element exists.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    public static Option<T> LastOption<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        return source.Reverse().FirstOption(predicate);
    }

    /// <summary>
    /// Returns the first element inside the enumerable or an empty option if the enumerable is empty.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    public static Option<T> LastOption<T>(this IEnumerable<T> source)
    {
        if (source is IReadOnlyList<T> list)
            return list.LastOption();

        return source.Reverse().FirstOption();
    }

    /// <summary>
    /// Returns the only value if the source contains just one value, otherwise an empty option.
    /// </summary>
    public static Option<T> SingleOption<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        return source.Where(predicate).SingleOption();
    }

    /// <summary>
    /// Returns the only value if the source contains just one value, otherwise an empty option.
    /// </summary>
    public static Option<T> SingleOption<T>(this IEnumerable<T> source)
    {
        if (source is IReadOnlyList<T> list)
        {
            return list.SingleOption();
        }

        using var enumerator = source.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            return Option.Empty<T>();
        }
        var result = enumerator.Current;
        return enumerator.MoveNext()
            ? Option.Empty<T>()
            : Option.Valued(result);
    }
}