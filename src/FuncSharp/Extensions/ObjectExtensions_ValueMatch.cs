
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace FuncSharp;

public static partial class ObjectExtensions
{
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 1 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 1 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 1 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 1 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 2 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 2 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 2 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 2 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 3 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 3 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 3 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 3 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 4 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 4 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 4 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 4 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 5 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 5 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 5 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 5 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 6 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 6 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 6 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 6 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 7 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 7 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 7 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 7 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 8 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 8 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 8 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 8 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 9 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 9 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 9 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 9 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 10 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 10 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 10 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 10 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 11 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 11 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 11 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 11 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (Equals(value, t12))
        {
            return f12(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 12 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
            T t12, TResult f12,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        if (value is not null && value.Equals(t12))
        {
            return f12;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
            T t12, Func<T, Task<TResult>> f12,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (Equals(value, t12))
        {
            return await f12(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 12 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            f12(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 12 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
            T t12, Func<T,Task> f12,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            await f12(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 12 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (Equals(value, t12))
        {
            return f12(value);
        }
        if (Equals(value, t13))
        {
            return f13(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 13 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
            T t12, TResult f12,
            T t13, TResult f13,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        if (value is not null && value.Equals(t12))
        {
            return f12;
        }
        if (value is not null && value.Equals(t13))
        {
            return f13;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
            T t12, Func<T, Task<TResult>> f12,
            T t13, Func<T, Task<TResult>> f13,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (Equals(value, t12))
        {
            return await f12(value);
        }
        if (Equals(value, t13))
        {
            return await f13(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 13 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            f13(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 13 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
            T t12, Func<T,Task> f12,
            T t13, Func<T,Task> f13,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            await f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            await f13(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 13 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (Equals(value, t12))
        {
            return f12(value);
        }
        if (Equals(value, t13))
        {
            return f13(value);
        }
        if (Equals(value, t14))
        {
            return f14(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 14 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
            T t12, TResult f12,
            T t13, TResult f13,
            T t14, TResult f14,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        if (value is not null && value.Equals(t12))
        {
            return f12;
        }
        if (value is not null && value.Equals(t13))
        {
            return f13;
        }
        if (value is not null && value.Equals(t14))
        {
            return f14;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
            T t12, Func<T, Task<TResult>> f12,
            T t13, Func<T, Task<TResult>> f13,
            T t14, Func<T, Task<TResult>> f14,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (Equals(value, t12))
        {
            return await f12(value);
        }
        if (Equals(value, t13))
        {
            return await f13(value);
        }
        if (Equals(value, t14))
        {
            return await f14(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 14 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            f14(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 14 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
            T t12, Func<T,Task> f12,
            T t13, Func<T,Task> f13,
            T t14, Func<T,Task> f14,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            await f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            await f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            await f14(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 14 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (Equals(value, t12))
        {
            return f12(value);
        }
        if (Equals(value, t13))
        {
            return f13(value);
        }
        if (Equals(value, t14))
        {
            return f14(value);
        }
        if (Equals(value, t15))
        {
            return f15(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 15 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
            T t12, TResult f12,
            T t13, TResult f13,
            T t14, TResult f14,
            T t15, TResult f15,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        if (value is not null && value.Equals(t12))
        {
            return f12;
        }
        if (value is not null && value.Equals(t13))
        {
            return f13;
        }
        if (value is not null && value.Equals(t14))
        {
            return f14;
        }
        if (value is not null && value.Equals(t15))
        {
            return f15;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
            T t12, Func<T, Task<TResult>> f12,
            T t13, Func<T, Task<TResult>> f13,
            T t14, Func<T, Task<TResult>> f14,
            T t15, Func<T, Task<TResult>> f15,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (Equals(value, t12))
        {
            return await f12(value);
        }
        if (Equals(value, t13))
        {
            return await f13(value);
        }
        if (Equals(value, t14))
        {
            return await f14(value);
        }
        if (Equals(value, t15))
        {
            return await f15(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 15 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            f15(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 15 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
            T t12, Func<T,Task> f12,
            T t13, Func<T,Task> f13,
            T t14, Func<T,Task> f14,
            T t15, Func<T,Task> f15,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            await f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            await f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            await f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            await f15(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 15 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
            T t16, Func<T, TResult> f16,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (Equals(value, t12))
        {
            return f12(value);
        }
        if (Equals(value, t13))
        {
            return f13(value);
        }
        if (Equals(value, t14))
        {
            return f14(value);
        }
        if (Equals(value, t15))
        {
            return f15(value);
        }
        if (Equals(value, t16))
        {
            return f16(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 16 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
            T t12, TResult f12,
            T t13, TResult f13,
            T t14, TResult f14,
            T t15, TResult f15,
            T t16, TResult f16,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        if (value is not null && value.Equals(t12))
        {
            return f12;
        }
        if (value is not null && value.Equals(t13))
        {
            return f13;
        }
        if (value is not null && value.Equals(t14))
        {
            return f14;
        }
        if (value is not null && value.Equals(t15))
        {
            return f15;
        }
        if (value is not null && value.Equals(t16))
        {
            return f16;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
            T t12, Func<T, Task<TResult>> f12,
            T t13, Func<T, Task<TResult>> f13,
            T t14, Func<T, Task<TResult>> f14,
            T t15, Func<T, Task<TResult>> f15,
            T t16, Func<T, Task<TResult>> f16,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (Equals(value, t12))
        {
            return await f12(value);
        }
        if (Equals(value, t13))
        {
            return await f13(value);
        }
        if (Equals(value, t14))
        {
            return await f14(value);
        }
        if (Equals(value, t15))
        {
            return await f15(value);
        }
        if (Equals(value, t16))
        {
            return await f16(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 16 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
            T t16, Action<T> f16,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            f16(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 16 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
            T t12, Func<T,Task> f12,
            T t13, Func<T,Task> f13,
            T t14, Func<T,Task> f14,
            T t15, Func<T,Task> f15,
            T t16, Func<T,Task> f16,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            await f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            await f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            await f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            await f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            await f16(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 16 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
            T t16, Func<T, TResult> f16,
            T t17, Func<T, TResult> f17,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (Equals(value, t12))
        {
            return f12(value);
        }
        if (Equals(value, t13))
        {
            return f13(value);
        }
        if (Equals(value, t14))
        {
            return f14(value);
        }
        if (Equals(value, t15))
        {
            return f15(value);
        }
        if (Equals(value, t16))
        {
            return f16(value);
        }
        if (Equals(value, t17))
        {
            return f17(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 17 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
            T t12, TResult f12,
            T t13, TResult f13,
            T t14, TResult f14,
            T t15, TResult f15,
            T t16, TResult f16,
            T t17, TResult f17,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        if (value is not null && value.Equals(t12))
        {
            return f12;
        }
        if (value is not null && value.Equals(t13))
        {
            return f13;
        }
        if (value is not null && value.Equals(t14))
        {
            return f14;
        }
        if (value is not null && value.Equals(t15))
        {
            return f15;
        }
        if (value is not null && value.Equals(t16))
        {
            return f16;
        }
        if (value is not null && value.Equals(t17))
        {
            return f17;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
            T t12, Func<T, Task<TResult>> f12,
            T t13, Func<T, Task<TResult>> f13,
            T t14, Func<T, Task<TResult>> f14,
            T t15, Func<T, Task<TResult>> f15,
            T t16, Func<T, Task<TResult>> f16,
            T t17, Func<T, Task<TResult>> f17,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (Equals(value, t12))
        {
            return await f12(value);
        }
        if (Equals(value, t13))
        {
            return await f13(value);
        }
        if (Equals(value, t14))
        {
            return await f14(value);
        }
        if (Equals(value, t15))
        {
            return await f15(value);
        }
        if (Equals(value, t16))
        {
            return await f16(value);
        }
        if (Equals(value, t17))
        {
            return await f17(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 17 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
            T t16, Action<T> f16,
            T t17, Action<T> f17,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            f16(value);
            return;
        }
        if (Equals(value, t17))
        {
            f17(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 17 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
            T t12, Func<T,Task> f12,
            T t13, Func<T,Task> f13,
            T t14, Func<T,Task> f14,
            T t15, Func<T,Task> f15,
            T t16, Func<T,Task> f16,
            T t17, Func<T,Task> f17,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            await f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            await f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            await f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            await f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            await f16(value);
            return;
        }
        if (Equals(value, t17))
        {
            await f17(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 17 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
            T t16, Func<T, TResult> f16,
            T t17, Func<T, TResult> f17,
            T t18, Func<T, TResult> f18,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (Equals(value, t12))
        {
            return f12(value);
        }
        if (Equals(value, t13))
        {
            return f13(value);
        }
        if (Equals(value, t14))
        {
            return f14(value);
        }
        if (Equals(value, t15))
        {
            return f15(value);
        }
        if (Equals(value, t16))
        {
            return f16(value);
        }
        if (Equals(value, t17))
        {
            return f17(value);
        }
        if (Equals(value, t18))
        {
            return f18(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 18 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
            T t12, TResult f12,
            T t13, TResult f13,
            T t14, TResult f14,
            T t15, TResult f15,
            T t16, TResult f16,
            T t17, TResult f17,
            T t18, TResult f18,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        if (value is not null && value.Equals(t12))
        {
            return f12;
        }
        if (value is not null && value.Equals(t13))
        {
            return f13;
        }
        if (value is not null && value.Equals(t14))
        {
            return f14;
        }
        if (value is not null && value.Equals(t15))
        {
            return f15;
        }
        if (value is not null && value.Equals(t16))
        {
            return f16;
        }
        if (value is not null && value.Equals(t17))
        {
            return f17;
        }
        if (value is not null && value.Equals(t18))
        {
            return f18;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
            T t12, Func<T, Task<TResult>> f12,
            T t13, Func<T, Task<TResult>> f13,
            T t14, Func<T, Task<TResult>> f14,
            T t15, Func<T, Task<TResult>> f15,
            T t16, Func<T, Task<TResult>> f16,
            T t17, Func<T, Task<TResult>> f17,
            T t18, Func<T, Task<TResult>> f18,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (Equals(value, t12))
        {
            return await f12(value);
        }
        if (Equals(value, t13))
        {
            return await f13(value);
        }
        if (Equals(value, t14))
        {
            return await f14(value);
        }
        if (Equals(value, t15))
        {
            return await f15(value);
        }
        if (Equals(value, t16))
        {
            return await f16(value);
        }
        if (Equals(value, t17))
        {
            return await f17(value);
        }
        if (Equals(value, t18))
        {
            return await f18(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 18 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
            T t16, Action<T> f16,
            T t17, Action<T> f17,
            T t18, Action<T> f18,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            f16(value);
            return;
        }
        if (Equals(value, t17))
        {
            f17(value);
            return;
        }
        if (Equals(value, t18))
        {
            f18(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 18 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
            T t12, Func<T,Task> f12,
            T t13, Func<T,Task> f13,
            T t14, Func<T,Task> f14,
            T t15, Func<T,Task> f15,
            T t16, Func<T,Task> f16,
            T t17, Func<T,Task> f17,
            T t18, Func<T,Task> f18,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            await f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            await f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            await f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            await f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            await f16(value);
            return;
        }
        if (Equals(value, t17))
        {
            await f17(value);
            return;
        }
        if (Equals(value, t18))
        {
            await f18(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 18 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
            T t16, Func<T, TResult> f16,
            T t17, Func<T, TResult> f17,
            T t18, Func<T, TResult> f18,
            T t19, Func<T, TResult> f19,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (Equals(value, t12))
        {
            return f12(value);
        }
        if (Equals(value, t13))
        {
            return f13(value);
        }
        if (Equals(value, t14))
        {
            return f14(value);
        }
        if (Equals(value, t15))
        {
            return f15(value);
        }
        if (Equals(value, t16))
        {
            return f16(value);
        }
        if (Equals(value, t17))
        {
            return f17(value);
        }
        if (Equals(value, t18))
        {
            return f18(value);
        }
        if (Equals(value, t19))
        {
            return f19(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 19 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
            T t12, TResult f12,
            T t13, TResult f13,
            T t14, TResult f14,
            T t15, TResult f15,
            T t16, TResult f16,
            T t17, TResult f17,
            T t18, TResult f18,
            T t19, TResult f19,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        if (value is not null && value.Equals(t12))
        {
            return f12;
        }
        if (value is not null && value.Equals(t13))
        {
            return f13;
        }
        if (value is not null && value.Equals(t14))
        {
            return f14;
        }
        if (value is not null && value.Equals(t15))
        {
            return f15;
        }
        if (value is not null && value.Equals(t16))
        {
            return f16;
        }
        if (value is not null && value.Equals(t17))
        {
            return f17;
        }
        if (value is not null && value.Equals(t18))
        {
            return f18;
        }
        if (value is not null && value.Equals(t19))
        {
            return f19;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
            T t12, Func<T, Task<TResult>> f12,
            T t13, Func<T, Task<TResult>> f13,
            T t14, Func<T, Task<TResult>> f14,
            T t15, Func<T, Task<TResult>> f15,
            T t16, Func<T, Task<TResult>> f16,
            T t17, Func<T, Task<TResult>> f17,
            T t18, Func<T, Task<TResult>> f18,
            T t19, Func<T, Task<TResult>> f19,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (Equals(value, t12))
        {
            return await f12(value);
        }
        if (Equals(value, t13))
        {
            return await f13(value);
        }
        if (Equals(value, t14))
        {
            return await f14(value);
        }
        if (Equals(value, t15))
        {
            return await f15(value);
        }
        if (Equals(value, t16))
        {
            return await f16(value);
        }
        if (Equals(value, t17))
        {
            return await f17(value);
        }
        if (Equals(value, t18))
        {
            return await f18(value);
        }
        if (Equals(value, t19))
        {
            return await f19(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 19 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
            T t16, Action<T> f16,
            T t17, Action<T> f17,
            T t18, Action<T> f18,
            T t19, Action<T> f19,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            f16(value);
            return;
        }
        if (Equals(value, t17))
        {
            f17(value);
            return;
        }
        if (Equals(value, t18))
        {
            f18(value);
            return;
        }
        if (Equals(value, t19))
        {
            f19(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 19 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
            T t12, Func<T,Task> f12,
            T t13, Func<T,Task> f13,
            T t14, Func<T,Task> f14,
            T t15, Func<T,Task> f15,
            T t16, Func<T,Task> f16,
            T t17, Func<T,Task> f17,
            T t18, Func<T,Task> f18,
            T t19, Func<T,Task> f19,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            await f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            await f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            await f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            await f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            await f16(value);
            return;
        }
        if (Equals(value, t17))
        {
            await f17(value);
            return;
        }
        if (Equals(value, t18))
        {
            await f18(value);
            return;
        }
        if (Equals(value, t19))
        {
            await f19(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 19 specified values.");
    }
    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding function.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
            T t16, Func<T, TResult> f16,
            T t17, Func<T, TResult> f17,
            T t18, Func<T, TResult> f18,
            T t19, Func<T, TResult> f19,
            T t20, Func<T, TResult> f20,
        Func<T, TResult> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return f1(value);
        }
        if (Equals(value, t2))
        {
            return f2(value);
        }
        if (Equals(value, t3))
        {
            return f3(value);
        }
        if (Equals(value, t4))
        {
            return f4(value);
        }
        if (Equals(value, t5))
        {
            return f5(value);
        }
        if (Equals(value, t6))
        {
            return f6(value);
        }
        if (Equals(value, t7))
        {
            return f7(value);
        }
        if (Equals(value, t8))
        {
            return f8(value);
        }
        if (Equals(value, t9))
        {
            return f9(value);
        }
        if (Equals(value, t10))
        {
            return f10(value);
        }
        if (Equals(value, t11))
        {
            return f11(value);
        }
        if (Equals(value, t12))
        {
            return f12(value);
        }
        if (Equals(value, t13))
        {
            return f13(value);
        }
        if (Equals(value, t14))
        {
            return f14(value);
        }
        if (Equals(value, t15))
        {
            return f15(value);
        }
        if (Equals(value, t16))
        {
            return f16(value);
        }
        if (Equals(value, t17))
        {
            return f17(value);
        }
        if (Equals(value, t18))
        {
            return f18(value);
        }
        if (Equals(value, t19))
        {
            return f19(value);
        }
        if (Equals(value, t20))
        {
            return f20(value);
        }
        if (otherwise != null)
        {
            return otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 20 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and returns result of the corresponding value.
    /// </summary>
    [Pure]
    public static TResult Match<T, TResult>(
        this T value,
            T t1, TResult f1,
            T t2, TResult f2,
            T t3, TResult f3,
            T t4, TResult f4,
            T t5, TResult f5,
            T t6, TResult f6,
            T t7, TResult f7,
            T t8, TResult f8,
            T t9, TResult f9,
            T t10, TResult f10,
            T t11, TResult f11,
            T t12, TResult f12,
            T t13, TResult f13,
            T t14, TResult f14,
            T t15, TResult f15,
            T t16, TResult f16,
            T t17, TResult f17,
            T t18, TResult f18,
            T t19, TResult f19,
            T t20, TResult f20,
        TResult otherwise = default(TResult))
    where T: IEquatable<T>
    {
        if (value is not null && value.Equals(t1))
        {
            return f1;
        }
        if (value is not null && value.Equals(t2))
        {
            return f2;
        }
        if (value is not null && value.Equals(t3))
        {
            return f3;
        }
        if (value is not null && value.Equals(t4))
        {
            return f4;
        }
        if (value is not null && value.Equals(t5))
        {
            return f5;
        }
        if (value is not null && value.Equals(t6))
        {
            return f6;
        }
        if (value is not null && value.Equals(t7))
        {
            return f7;
        }
        if (value is not null && value.Equals(t8))
        {
            return f8;
        }
        if (value is not null && value.Equals(t9))
        {
            return f9;
        }
        if (value is not null && value.Equals(t10))
        {
            return f10;
        }
        if (value is not null && value.Equals(t11))
        {
            return f11;
        }
        if (value is not null && value.Equals(t12))
        {
            return f12;
        }
        if (value is not null && value.Equals(t13))
        {
            return f13;
        }
        if (value is not null && value.Equals(t14))
        {
            return f14;
        }
        if (value is not null && value.Equals(t15))
        {
            return f15;
        }
        if (value is not null && value.Equals(t16))
        {
            return f16;
        }
        if (value is not null && value.Equals(t17))
        {
            return f17;
        }
        if (value is not null && value.Equals(t18))
        {
            return f18;
        }
        if (value is not null && value.Equals(t19))
        {
            return f19;
        }
        if (value is not null && value.Equals(t20))
        {
            return f20;
        }
        return otherwise;
    }

    [Pure]
    public static async Task<TResult> MatchAsync<T, TResult>(
        this T value,
            T t1, Func<T, Task<TResult>> f1,
            T t2, Func<T, Task<TResult>> f2,
            T t3, Func<T, Task<TResult>> f3,
            T t4, Func<T, Task<TResult>> f4,
            T t5, Func<T, Task<TResult>> f5,
            T t6, Func<T, Task<TResult>> f6,
            T t7, Func<T, Task<TResult>> f7,
            T t8, Func<T, Task<TResult>> f8,
            T t9, Func<T, Task<TResult>> f9,
            T t10, Func<T, Task<TResult>> f10,
            T t11, Func<T, Task<TResult>> f11,
            T t12, Func<T, Task<TResult>> f12,
            T t13, Func<T, Task<TResult>> f13,
            T t14, Func<T, Task<TResult>> f14,
            T t15, Func<T, Task<TResult>> f15,
            T t16, Func<T, Task<TResult>> f16,
            T t17, Func<T, Task<TResult>> f17,
            T t18, Func<T, Task<TResult>> f18,
            T t19, Func<T, Task<TResult>> f19,
            T t20, Func<T, Task<TResult>> f20,
        Func<T, Task<TResult>> otherwise = null)
    {
        if (Equals(value, t1))
        {
            return await f1(value);
        }
        if (Equals(value, t2))
        {
            return await f2(value);
        }
        if (Equals(value, t3))
        {
            return await f3(value);
        }
        if (Equals(value, t4))
        {
            return await f4(value);
        }
        if (Equals(value, t5))
        {
            return await f5(value);
        }
        if (Equals(value, t6))
        {
            return await f6(value);
        }
        if (Equals(value, t7))
        {
            return await f7(value);
        }
        if (Equals(value, t8))
        {
            return await f8(value);
        }
        if (Equals(value, t9))
        {
            return await f9(value);
        }
        if (Equals(value, t10))
        {
            return await f10(value);
        }
        if (Equals(value, t11))
        {
            return await f11(value);
        }
        if (Equals(value, t12))
        {
            return await f12(value);
        }
        if (Equals(value, t13))
        {
            return await f13(value);
        }
        if (Equals(value, t14))
        {
            return await f14(value);
        }
        if (Equals(value, t15))
        {
            return await f15(value);
        }
        if (Equals(value, t16))
        {
            return await f16(value);
        }
        if (Equals(value, t17))
        {
            return await f17(value);
        }
        if (Equals(value, t18))
        {
            return await f18(value);
        }
        if (Equals(value, t19))
        {
            return await f19(value);
        }
        if (Equals(value, t20))
        {
            return await f20(value);
        }
        if (otherwise != null)
        {
            return await otherwise(value);
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 20 specified values.");
    }

    /// <summary>
    /// Matches the value with the specified parameters and executes the corresponding function.
    /// </summary>
    [Pure]
    public static void Match<T>(
        this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
            T t16, Action<T> f16,
            T t17, Action<T> f17,
            T t18, Action<T> f18,
            T t19, Action<T> f19,
            T t20, Action<T> f20,
        Action<T> otherwise = null)
    {
        if (Equals(value, t1))
        {
            f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            f16(value);
            return;
        }
        if (Equals(value, t17))
        {
            f17(value);
            return;
        }
        if (Equals(value, t18))
        {
            f18(value);
            return;
        }
        if (Equals(value, t19))
        {
            f19(value);
            return;
        }
        if (Equals(value, t20))
        {
            f20(value);
            return;
        }
        if (otherwise != null)
        {
            otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 20 specified values.");
    }

    [Pure]
    public static async Task MatchAsync<T>(
        this T value,
            T t1, Func<T,Task> f1,
            T t2, Func<T,Task> f2,
            T t3, Func<T,Task> f3,
            T t4, Func<T,Task> f4,
            T t5, Func<T,Task> f5,
            T t6, Func<T,Task> f6,
            T t7, Func<T,Task> f7,
            T t8, Func<T,Task> f8,
            T t9, Func<T,Task> f9,
            T t10, Func<T,Task> f10,
            T t11, Func<T,Task> f11,
            T t12, Func<T,Task> f12,
            T t13, Func<T,Task> f13,
            T t14, Func<T,Task> f14,
            T t15, Func<T,Task> f15,
            T t16, Func<T,Task> f16,
            T t17, Func<T,Task> f17,
            T t18, Func<T,Task> f18,
            T t19, Func<T,Task> f19,
            T t20, Func<T,Task> f20,
        Func<T, Task> otherwise = null)
    {
        if (Equals(value, t1))
        {
            await f1(value);
            return;
        }
        if (Equals(value, t2))
        {
            await f2(value);
            return;
        }
        if (Equals(value, t3))
        {
            await f3(value);
            return;
        }
        if (Equals(value, t4))
        {
            await f4(value);
            return;
        }
        if (Equals(value, t5))
        {
            await f5(value);
            return;
        }
        if (Equals(value, t6))
        {
            await f6(value);
            return;
        }
        if (Equals(value, t7))
        {
            await f7(value);
            return;
        }
        if (Equals(value, t8))
        {
            await f8(value);
            return;
        }
        if (Equals(value, t9))
        {
            await f9(value);
            return;
        }
        if (Equals(value, t10))
        {
            await f10(value);
            return;
        }
        if (Equals(value, t11))
        {
            await f11(value);
            return;
        }
        if (Equals(value, t12))
        {
            await f12(value);
            return;
        }
        if (Equals(value, t13))
        {
            await f13(value);
            return;
        }
        if (Equals(value, t14))
        {
            await f14(value);
            return;
        }
        if (Equals(value, t15))
        {
            await f15(value);
            return;
        }
        if (Equals(value, t16))
        {
            await f16(value);
            return;
        }
        if (Equals(value, t17))
        {
            await f17(value);
            return;
        }
        if (Equals(value, t18))
        {
            await f18(value);
            return;
        }
        if (Equals(value, t19))
        {
            await f19(value);
            return;
        }
        if (Equals(value, t20))
        {
            await f20(value);
            return;
        }
        if (otherwise != null)
        {
            await otherwise(value);
            return;
        }
        throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 20 specified values.");
    }
}
