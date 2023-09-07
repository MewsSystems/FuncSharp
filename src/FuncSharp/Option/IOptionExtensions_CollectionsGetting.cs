using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FuncSharp;

public static partial class OptionExtensions
{
    #region GetOrNull

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IEnumerable<T> GetOrNull<T>(this Option<IEnumerable<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IEnumerable<TResult> GetOrNull<T, TResult>(this Option<T> option, Func<T, IEnumerable<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IReadOnlyList<T> GetOrNull<T>(this Option<IReadOnlyList<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IReadOnlyList<TResult> GetOrNull<T, TResult>(this Option<T> option, Func<T, IReadOnlyList<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IReadOnlyCollection<T> GetOrNull<T>(this Option<IReadOnlyCollection<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IReadOnlyCollection<TResult> GetOrNull<T, TResult>(this Option<T> option, Func<T, IReadOnlyCollection<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static INonEmptyEnumerable<T> GetOrNull<T>(this Option<INonEmptyEnumerable<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static INonEmptyEnumerable<TResult> GetOrNull<T, TResult>(this Option<T> option, Func<T, INonEmptyEnumerable<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static T[] GetOrNull<T>(this Option<T[]> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static TResult[] GetOrNull<T, TResult>(this Option<T> option, Func<T, TResult[]> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static List<T> GetOrNull<T>(this Option<List<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static List<TResult> GetOrNull<T, TResult>(this Option<T> option, Func<T, List<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IGrouping<Key, Value> GetOrNull<Key, Value>(this Option<IGrouping<Key, Value>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IGrouping<Key, Value> GetOrNull<T, Key, Value>(this Option<T> option, Func<T, IGrouping<Key, Value>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static Dictionary<Key, Value> GetOrNull<Key, Value>(this Option<Dictionary<Key, Value>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static Dictionary<Key, Value> GetOrNull<T, Key, Value>(this Option<T> option, Func<T, Dictionary<Key, Value>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IDictionary<Key, Value> GetOrNull<Key, Value>(this Option<IDictionary<Key, Value>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IDictionary<Key, Value> GetOrNull<T, Key, Value>(this Option<T> option, Func<T, IDictionary<Key, Value>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IReadOnlyDictionary<Key, Value> GetOrNull<Key, Value>(this Option<IReadOnlyDictionary<Key, Value>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IReadOnlyDictionary<Key, Value> GetOrNull<T, Key, Value>(this Option<T> option, Func<T, IReadOnlyDictionary<Key, Value>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    #endregion GetOrNull

    #region GetOrDefault

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IEnumerable<T> GetOrDefault<T>(this Option<IEnumerable<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IEnumerable<TResult> GetOrDefault<T, TResult>(this Option<T> option, Func<T, IEnumerable<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IReadOnlyList<T> GetOrDefault<T>(this Option<IReadOnlyList<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IReadOnlyList<TResult> GetOrDefault<T, TResult>(this Option<T> option, Func<T, IReadOnlyList<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IReadOnlyCollection<T> GetOrDefault<T>(this Option<IReadOnlyCollection<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IReadOnlyCollection<TResult> GetOrDefault<T, TResult>(this Option<T> option, Func<T, IReadOnlyCollection<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static INonEmptyEnumerable<T> GetOrDefault<T>(this Option<INonEmptyEnumerable<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static INonEmptyEnumerable<TResult> GetOrDefault<T, TResult>(this Option<T> option, Func<T, INonEmptyEnumerable<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static T[] GetOrDefault<T>(this Option<T[]> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static TResult[] GetOrDefault<T, TResult>(this Option<T> option, Func<T, TResult[]> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static List<T> GetOrDefault<T>(this Option<List<T>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static List<TResult> GetOrDefault<T, TResult>(this Option<T> option, Func<T, List<TResult>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IGrouping<Key, Value> GetOrDefault<Key, Value>(this Option<IGrouping<Key, Value>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IGrouping<Key, Value> GetOrDefault<T, Key, Value>(this Option<T> option, Func<T, IGrouping<Key, Value>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static Dictionary<Key, Value> GetOrDefault<Key, Value>(this Option<Dictionary<Key, Value>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static Dictionary<Key, Value> GetOrDefault<T, Key, Value>(this Option<T> option, Func<T, Dictionary<Key, Value>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IDictionary<Key, Value> GetOrDefault<Key, Value>(this Option<IDictionary<Key, Value>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IDictionary<Key, Value> GetOrDefault<T, Key, Value>(this Option<T> option, Func<T, IDictionary<Key, Value>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    /// <summary>
    /// Returns value of the option if it has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `GetOrEmpty` instead.")]
    public static IReadOnlyDictionary<Key, Value> GetOrDefault<Key, Value>(this Option<IReadOnlyDictionary<Key, Value>> option)
    {
        return option.Value;
    }

    /// <summary>
    /// Returns value of the option mapped into a collection if the option has value. If not, returns null.
    /// </summary>
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use `Map` + `GetOrEmpty` instead.")]
    public static IReadOnlyDictionary<Key, Value> GetOrDefault<T, Key, Value>(this Option<T> option, Func<T, IReadOnlyDictionary<Key, Value>> func)
    {
        if (option.NonEmpty)
            return func(option.Value);
        return null;
    }

    #endregion GetOrDefault
}