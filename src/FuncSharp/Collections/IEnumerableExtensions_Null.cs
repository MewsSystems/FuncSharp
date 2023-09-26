using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Returns the IEnumerable received or an empty one if the one provided is null.
    /// </summary>
    [DebuggerStepThrough]
    public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> enumerable)
    {
        return enumerable ?? Enumerable.Empty<T>();
    }

    /// <summary>
    /// Returns the Array received or an empty one if the one provided is null.
    /// </summary>
    [DebuggerStepThrough]
    public static T[] OrEmptyIfNull<T>(this T[] array)
    {
        return array ?? Array.Empty<T>();
    }

    /// <summary>
    /// Returns the List received or an empty one if the one provided is null.
    /// </summary>
    [DebuggerStepThrough]
    public static List<T> OrEmptyIfNull<T>(this List<T> list)
    {
        return list ?? new List<T>();
    }

    /// <summary>
    /// Returns the IReadOnlyList received or an empty one if the one provided is null.
    /// </summary>
    [DebuggerStepThrough]
    public static IReadOnlyList<T> OrEmptyIfNull<T>(this IReadOnlyList<T> readonlyList)
    {
        return readonlyList ?? ReadOnlyList.Empty<T>();
    }

    /// <summary>
    /// Returns the ICollection received or an empty one if the one provided is null.
    /// </summary>
    [DebuggerStepThrough]
    public static ICollection<T> OrEmptyIfNull<T>(this ICollection<T> collection)
    {
        return collection ?? ReadOnlyList<T>.EmptyReadOnlyCollection;
    }
}