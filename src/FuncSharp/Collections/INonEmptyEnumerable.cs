using System;
using System.Collections.Generic;

namespace FuncSharp;

public interface INonEmptyEnumerable<out T>
{
    T Head { get; }

    IReadOnlyList<T> Tail { get; }

    INonEmptyEnumerable<T> Distinct();

    INonEmptyEnumerable<TResult> Distinct<TResult>(Func<T, TResult> selector);

    INonEmptyEnumerable<TResult> Select<TResult>(Func<T, TResult> func);

    INonEmptyEnumerable<TResult> Select<TResult>(Func<T, int, TResult> func);

    IReadOnlyList<T> AsReadonly();
}