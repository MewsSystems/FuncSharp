using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FuncSharp;

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
        var list = values.ToArray();
        return list.Length == 0
            ? Option.Empty<INonEmptyEnumerable<T>>()
            : Option.Valued(Create(list[0], list.Skip(1)));
    }

    public static IOption<INonEmptyEnumerable<T>> Create<T>(IReadOnlyList<T> values)
    {
        return values.FirstOption().Map(h => Create(h, values.Skip(1).ToList()));
    }

    public static IOption<INonEmptyEnumerable<T>> CreateFlat<T>(params IOption<T>[] values)
    {
        return Create(values.Flatten());
    }

    public static INonEmptyEnumerable<T> CreateFlat<T>(INonEmptyEnumerable<T> head, params IEnumerable<T>[] tail)
    {
        return Create(head: head.Head, tail: head.Tail.Concat(tail.Flatten()));
    }

    [Obsolete("This is a NonEmptyEnumerable. It's not empty.", error: true)]
    public static bool NonEmpty<T>(this INonEmptyEnumerable<T> source)
    {
        return true;
    }

    [Obsolete("This is a NonEmptyEnumerable. It's not empty.", error: true)]
    public static bool IsEmpty<T>(this INonEmptyEnumerable<T> source)
    {
        return false;
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
        return new NonEmptyEnumerable<TResult>(func(Head), Tail.Select(func).ToList());
    }

    public INonEmptyEnumerable<TResult> Select<TResult>(Func<T, int, TResult> func)
    {
        return new NonEmptyEnumerable<TResult>(func(Head, 0), Tail.Select((v, i) => func(v, i + 1)).ToList());
    }

    public IReadOnlyList<T> AsReadonly()
    {
        return this;
    }
}
