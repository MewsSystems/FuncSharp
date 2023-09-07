using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace FuncSharp;

public static partial class ObjectExtensions
{
    #region MapRef

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IEnumerable<TResult> MapRef<A, TResult>(this A a, Func<A, IEnumerable<TResult>> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IReadOnlyList<TResult> MapRef<A, TResult>(this A a, Func<A, IReadOnlyList<TResult>> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IReadOnlyCollection<TResult> MapRef<A, TResult>(this A a, Func<A, IReadOnlyCollection<TResult>> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static INonEmptyEnumerable<TResult> MapRef<A, TResult>(this A a, Func<A, INonEmptyEnumerable<TResult>> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static TResult[] MapRef<A, TResult>(this A a, Func<A, TResult[]> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static List<TResult> MapRef<A, TResult>(this A a, Func<A, List<TResult>> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IGrouping<Key, Value> MapRef<A, Key, Value>(this A a, Func<A, IGrouping<Key, Value>> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static Dictionary<Key, Value> MapRef<A, Key, Value>(this A a, Func<A, Dictionary<Key, Value>> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IDictionary<Key, Value> MapRef<A, Key, Value>(this A a, Func<A, IDictionary<Key, Value>> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IReadOnlyDictionary<Key, Value> MapRef<A, Key, Value>(this A a, Func<A, IReadOnlyDictionary<Key, Value>> func)
        where A : class
    {
        return a is not null 
            ? func(a) 
            : null;
    }

    #endregion MapRef

    #region MapRefAsync

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IEnumerable<TResult>> MapRefAsync<A, TResult>(this A a, Func<A, Task<IEnumerable<TResult>>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IReadOnlyList<TResult>> MapRefAsync<A, TResult>(this A a, Func<A, Task<IReadOnlyList<TResult>>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IReadOnlyCollection<TResult>> MapRefAsync<A, TResult>(this A a, Func<A, Task<IReadOnlyCollection<TResult>>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<INonEmptyEnumerable<TResult>> MapRefAsync<A, TResult>(this A a, Func<A, Task<INonEmptyEnumerable<TResult>>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<TResult[]> MapRefAsync<A, TResult>(this A a, Func<A, Task<TResult[]>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<List<TResult>> MapRefAsync<A, TResult>(this A a, Func<A, Task<List<TResult>>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IGrouping<Key, Value>> MapRefAsync<A, Key, Value>(this A a, Func<A, Task<IGrouping<Key, Value>>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<Dictionary<Key, Value>> MapRefAsync<A, Key, Value>(this A a, Func<A, Task<Dictionary<Key, Value>>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IDictionary<Key, Value>> MapRefAsync<A, Key, Value>(this A a, Func<A, Task<IDictionary<Key, Value>>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IReadOnlyDictionary<Key, Value>> MapRefAsync<A, Key, Value>(this A a, Func<A, Task<IReadOnlyDictionary<Key, Value>>> func)
        where A : class
    {
        return a is not null
            ? await func(a)
            : default;
    }

    #endregion MapRefAsync

    #region MapValToRef

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IEnumerable<TResult> MapValToRef<A, TResult>(this A? a, Func<A, IEnumerable<TResult>> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IReadOnlyList<TResult> MapValToRef<A, TResult>(this A? a, Func<A, IReadOnlyList<TResult>> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IReadOnlyCollection<TResult> MapValToRef<A, TResult>(this A? a, Func<A, IReadOnlyCollection<TResult>> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static INonEmptyEnumerable<TResult> MapValToRef<A, TResult>(this A? a, Func<A, INonEmptyEnumerable<TResult>> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static TResult[] MapValToRef<A, TResult>(this A? a, Func<A, TResult[]> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static List<TResult> MapValToRef<A, TResult>(this A? a, Func<A, List<TResult>> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IGrouping<Key, Value> MapValToRef<A, Key, Value>(this A? a, Func<A, IGrouping<Key, Value>> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static Dictionary<Key, Value> MapValToRef<A, Key, Value>(this A? a, Func<A, Dictionary<Key, Value>> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IDictionary<Key, Value> MapValToRef<A, Key, Value>(this A? a, Func<A, IDictionary<Key, Value>> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static IReadOnlyDictionary<Key, Value> MapValToRef<A, Key, Value>(this A? a, Func<A, IReadOnlyDictionary<Key, Value>> func)
        where A : struct
    {
        return a is {} value
            ? func(value)
            : null;
    }

    #endregion MapValToRef

    #region MapValToRefAsync

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IEnumerable<TResult>> MapValToRefAsync<A, TResult>(this A? a, Func<A, Task<IEnumerable<TResult>>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IReadOnlyList<TResult>> MapValToRefAsync<A, TResult>(this A? a, Func<A, Task<IReadOnlyList<TResult>>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IReadOnlyCollection<TResult>> MapValToRefAsync<A, TResult>(this A? a, Func<A, Task<IReadOnlyCollection<TResult>>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<INonEmptyEnumerable<TResult>> MapValToRefAsync<A, TResult>(this A? a, Func<A, Task<INonEmptyEnumerable<TResult>>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<TResult[]> MapValToRefAsync<A, TResult>(this A? a, Func<A, Task<TResult[]>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<List<TResult>> MapValToRefAsync<A, TResult>(this A? a, Func<A, Task<List<TResult>>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IGrouping<Key, Value>> MapValToRefAsync<A, Key, Value>(this A? a, Func<A, Task<IGrouping<Key, Value>>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<Dictionary<Key, Value>> MapValToRefAsync<A, Key, Value>(this A? a, Func<A, Task<Dictionary<Key, Value>>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IDictionary<Key, Value>> MapValToRefAsync<A, Key, Value>(this A? a, Func<A, Task<IDictionary<Key, Value>>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    /// <summary>
    /// Maps the value into a result in case it is not null. Returns null if the value is null.
    /// </summary>
    [DebuggerStepThrough]
    [Pure]
    [Obsolete("You shouldn't have nulls in variables of collection types. Use options instead.")]
    public static async Task<IReadOnlyDictionary<Key, Value>> MapValToRefAsync<A, Key, Value>(this A? a, Func<A, Task<IReadOnlyDictionary<Key, Value>>> func)
        where A : struct
    {
        return a is {} value
            ? await func(value)
            : null;
    }

    #endregion MapValToRefAsync
}