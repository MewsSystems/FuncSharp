using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FuncSharp;

namespace FuncSharp;

public interface INonEmptyEnumerable<out T> : IReadOnlyList<T>
{
    T Head { get; }

    IReadOnlyList<T> Tail { get; }

    INonEmptyEnumerable<T> Distinct();

    INonEmptyEnumerable<TResult> Distinct<TResult>(Func<T, TResult> selector);

    INonEmptyEnumerable<TResult> Select<TResult>(Func<T, TResult> func);

    INonEmptyEnumerable<TResult> Select<TResult>(Func<T, int, TResult> func);

    IReadOnlyList<T> AsReadonly();
}

public static class NonEmptyEnumerable
{
    public static INonEmptyEnumerable<T> Create<T>(T head, params T[] tail)
    {
        return Create(head, tail.ToList());
    }

    public static INonEmptyEnumerable<T> Create<T>(T head, IEnumerable<T> tail)
    {
        return Create(head, tail.ToList());
    }

    public static INonEmptyEnumerable<T> Create<T>(T head, IReadOnlyList<T> tail)
    {
        return new NonEmptyEnumerable<T>(head, tail);
    }

    public static IOption<INonEmptyEnumerable<T>> Create<T>(IEnumerable<T> values)
    {
        return Create(values.ToList());
    }

    public static IOption<INonEmptyEnumerable<T>> Create<T>(IReadOnlyList<T> values)
    {
        return values.FirstOption().Map(h => Create(h, values.Skip(1).ToList()));
    }

    public static IOption<INonEmptyEnumerable<T>> CreateFlat<T>(params IOption<T>[] values)
    {
        return Create(values.Flatten());
    }

    public static INonEmptyEnumerable<T> CreateFlat<T>(INonEmptyEnumerable<INonEmptyEnumerable<T>> values)
    {
        return CreateFlat(values.Head, values.Tail);
    }

    public static INonEmptyEnumerable<T> CreateFlat<T>(INonEmptyEnumerable<T> head, params IEnumerable<T>[] tail)
    {
        return CreateFlat(head, tail.AsEnumerable());
    }

    public static INonEmptyEnumerable<T> CreateFlat<T>(INonEmptyEnumerable<T> head, IEnumerable<IEnumerable<T>> tail)
    {
        return Create(head: head.Head, tail: head.Tail.Concat(tail.Flatten()));
    }
}

[DebuggerTypeProxy(typeof(CollectionDebugView<>))]
[DebuggerDisplay("Count = {Count}")]
public class NonEmptyEnumerable<T> : IReadOnlyList<T>, INonEmptyEnumerable<T>
{
    private readonly IReadOnlyList<T> data;

    public NonEmptyEnumerable(T head, IReadOnlyList<T> tail)
    {
        Head = head;
        Tail = tail;

        var list = new List<T> { head };
        list.AddRange(Tail);
        data = list;
    }

    public T Head { get; }

    public IReadOnlyList<T> Tail { get; }

    public int Count => data.Count;

    public T this[int index] => data[index];

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return data.GetEnumerator();
    }

    public INonEmptyEnumerable<T> Distinct()
    {
        return NonEmptyEnumerable.Create(Head, Tail.Distinct().Except(Head));
    }

    public INonEmptyEnumerable<TResult> Distinct<TResult>(Func<T, TResult> selector)
    {
        return Select(selector).Distinct();
    }

    public INonEmptyEnumerable<TResult> Select<TResult>(Func<T, TResult> func)
    {
        return new NonEmptyEnumerable<TResult>(func(Head), Tail.SelectStrict(func));
    }

    public INonEmptyEnumerable<TResult> Select<TResult>(Func<T, int, TResult> func)
    {
        return new NonEmptyEnumerable<TResult>(func(Head, 0), Tail.SelectStrict((v, i) => func(v, i + 1)));
    }

    public IReadOnlyList<T> AsReadonly()
    {
        return this;
    }
}
