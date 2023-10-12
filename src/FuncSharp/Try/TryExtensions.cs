using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace FuncSharp;

public static class TryExtensions
{
    public static Try<T, E> Flatten<T, E>(this Try<Try<T, E>, E> value)
    {
        return value.FlatMap(v => v);
    }

    public static Try<IReadOnlyList<T>, IReadOnlyList<E>> Flatten<T, E>(this IEnumerable<Try<T, E>> values)
    {
        return Try.Aggregate(values);
    }

    /// <summary>
    /// If the successful result passes the predicate, returns the original try. Otherwise returns erroneous try with the specified result.
    /// </summary>
    public static Try<A, E> Where<A, E>(this Try<A, E> t, Func<A, bool> predicate, Func<Unit, E> otherwise)
    {
        return t.FlatMap(a => predicate(a).Match(
            _ => t,
            _ => Try.Error<A, E>(otherwise(Unit.Value))
        ));
    }

    /// <summary>
    /// If the successful result passes the predicate, returns the original try. Otherwise returns erroneous try with the specified result.
    /// </summary>
    public static Try<A, IEnumerable<E>> Where<A, E>(this Try<A, IEnumerable<E>> t, Func<A, bool> predicate, Func<Unit, E> otherwise)
    {
        return t.FlatMap(a => predicate(a).Match(
            _ => t,
            _ => Try.Error<A, IEnumerable<E>>(new[] { otherwise(Unit.Value) })
        ));
    }

    public static Try<A, Exception> Where<A>(this Try<A, Exception> t, Func<A, bool> predicate, Func<Unit, Exception> error)
    {
        return t.FlatMap(a => predicate(a).Match(
            _ => t,
            _ => Try.Error<A, Exception>(error(Unit.Value))
        ));
    }

    /// <summary>
    /// Maps the successful result to a new try.
    /// </summary>
    public static Try<B, E> FlatMap<A, E, B>(this Try<A, E> t, Func<A, Try<B, E>> f)
    {
        return t.Match(
            s => f(s),
            e => Try.Error<B, E>(e)
        );
    }

    public static async Task<Try<TResult, E>> FlatMapAsync<A, TResult, E>(this Try<A, E> self, Func<A, Task<Try<TResult, E>>> f)
    {
        return await self.Match(
            f,
            e => Task.FromResult(Try.Error<TResult, E>(e))
        );
    }

    /// <summary>
    /// Maps the error result to a new try.
    /// </summary>
    public static Try<B, F> FlatMapError<A, E, B, F>(this Try<A, E> t, Func<E, Try<B, F>> f)
        where A : B
        where E : F
    {
        return t.Match(
            s => Try.Success<B, F>(s),
            e => f(e)
        );
    }

    /// <summary>
    /// If the result is success, returns it. Otherwise throws the result of the otherwise function.
    /// </summary>
    public static A Get<A, E>(this Try<A, E> t, Func<E, Exception> otherwise)
    {
        return t.Match(
            s => s,
            e =>
            {
                ExceptionDispatchInfo.Capture(otherwise(e)).Throw();
                return default;
            }
        );
    }

    /// <summary>
    /// If the result is success, returns it. Otherwise throws the exception.
    /// </summary>
    public static A Get<A, E>(this Try<A, E> t)
        where E : Exception
    {
        return t.Match(
            s => s,
            e =>
            {
                ExceptionDispatchInfo.Capture(e).Throw();
                return default;
            }
        );
    }

    public static T Get<T, E>(this Try<T, IReadOnlyList<E>> value)
        where E : Exception
    {
        return value.Match(
            s => s,
            (Func<IReadOnlyList<Exception>, T>)(e =>
            {
                if (e.IsSingle())
                {
                    ExceptionDispatchInfo.Capture(e[0]).Throw();
                }
                throw new AggregateException(e);
            })
        );
    }
}