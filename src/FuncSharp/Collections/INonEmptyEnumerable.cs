using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace FuncSharp;

public interface INonEmptyEnumerable<out T> : IReadOnlyList<T>
{
    T Head { get; }

    [Pure]
    IReadOnlyList<T> Tail { get; }

    [Pure]
    INonEmptyEnumerable<T> Distinct();

    [Pure]
    INonEmptyEnumerable<TResult> Distinct<TResult>(Func<T, TResult> selector);

    [Pure]
    INonEmptyEnumerable<TResult> Select<TResult>(Func<T, TResult> func);

    [Pure]
    INonEmptyEnumerable<TResult> Select<TResult>(Func<T, int, TResult> func);

    [Pure]
    INonEmptyEnumerable<TResult> SelectMany<TResult>(Func<T, INonEmptyEnumerable<TResult>> selector);

    [Pure]
    IReadOnlyList<T> AsReadOnly();
}