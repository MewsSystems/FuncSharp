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
    /// Returns the first element inside the list or an empty option if the list is empty.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    [Obsolete("This method is obsolete because there were breaking changes and some people might put a null into this method expecting it to work. It will be made non-obsolete on 13th of September 2023", error: true)]
    public static Option<T> FirstOption<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        return source.Where(predicate).FirstOption();
    }

    /// <summary>
    /// Returns the first element inside the list or an empty option if the list is empty.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    [Obsolete("This method is obsolete because there were breaking changes and some people might put a null into this method expecting it to work. It will be made non-obsolete on 13th of September 2023", error: true)]
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
    /// Returns the last element inside the list or an empty option if the list is empty.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    public static Option<T> LastOption<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        // TODO - call FirstOption instead of copy-pasted code.
        using var enumerator = source.Where(predicate).Reverse().GetEnumerator();
        return enumerator.MoveNext()
            ? Option.Valued(enumerator.Current)
            : Option.Empty<T>();
    }

    /// <summary>
    /// Returns the first element inside the list or an empty option if the list is empty.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is null.</exception>
    public static Option<T> LastOption<T>(this IEnumerable<T> source)
    {
        if (source is IReadOnlyList<T> list)
            return list.LastOption();

        // TODO - call FirstOption instead of copy-pasted code.
        using var enumerator = source.Reverse().GetEnumerator();
        return enumerator.MoveNext()
            ? Option.Valued(enumerator.Current)
            : Option.Empty<T>();
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