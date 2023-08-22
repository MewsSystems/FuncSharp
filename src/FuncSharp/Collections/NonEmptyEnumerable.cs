using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace FuncSharp;

public static class NonEmptyEnumerable
{
    public static INonEmptyEnumerable<T> Create<T>(T head, params T[] tail)
    {
        return NonEmptyEnumerable<T>.Create(head, tail);
    }

    public static INonEmptyEnumerable<T> Create<T>(T head, IEnumerable<T> tail)
    {
        return NonEmptyEnumerable<T>.Create(head, tail);
    }

    public static INonEmptyEnumerable<T> Create<T>(T head, IReadOnlyList<T> tail)
    {
        return NonEmptyEnumerable<T>.Create(head, tail);
    }

    public static IOption<INonEmptyEnumerable<T>> Create<T>(IEnumerable<T> values)
    {
        return NonEmptyEnumerable<T>.Create(values);
    }

    public static IOption<INonEmptyEnumerable<T>> Create<T>(IReadOnlyList<T> values)
    {
        return NonEmptyEnumerable<T>.Create(values);
    }

    public static IOption<INonEmptyEnumerable<T>> CreateFlat<T>(params IOption<T>[] values)
    {
        return NonEmptyEnumerable<T>.CreateFlat(values);
    }

    public static INonEmptyEnumerable<T> CreateFlat<T>(INonEmptyEnumerable<T> head, params IEnumerable<T>[] tail)
    {
        return NonEmptyEnumerable<T>.CreateFlat(head, tail);
    }

    public static INonEmptyEnumerable<T> CreateFlat<T>(INonEmptyEnumerable<INonEmptyEnumerable<T>> values)
    {
        return NonEmptyEnumerable<T>.CreateFlat(values);
    }

    public static INonEmptyEnumerable<V> CreateFlat<T, V>(this INonEmptyEnumerable<T> source, Func<T, INonEmptyEnumerable<V>> selector)
    {
        return NonEmptyEnumerable<T>.CreateFlat(source, selector);
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
    private NonEmptyEnumerable(T head, List<T> tail)
    {
        Head = head;
        Tail = CollectionsMarshal.AsSpan(tail).ToArray();
    }

    private NonEmptyEnumerable(T head, T[] tail)
    {
        Head = head;
        Tail = tail.AsSpan().ToArray();
    }

    private NonEmptyEnumerable(List<T> list)
    {
        Head = list[0];
        Tail = CollectionsMarshal.AsSpan(list).Slice(1).ToArray();
    }

    private NonEmptyEnumerable(T[] array)
    {
        Head = array[0];
        Tail = array.AsSpan().Slice(1).ToArray();
    }

    public T Head { get; }

    public IReadOnlyList<T> Tail { get; }

    public int Count => Tail.Count + 1;

    public T this[int index] => index switch
    {
        0 => Head,
        _ => Tail[index - 1]
    };

    public IEnumerator<T> GetEnumerator()
    {
        yield return Head;
        foreach (var item in Tail)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public INonEmptyEnumerable<T> Distinct()
    {
        return new NonEmptyEnumerable<T>(Enumerable.Distinct(this).ToArray());
    }

    public INonEmptyEnumerable<TResult> Distinct<TResult>(Func<T, TResult> selector)
    {
        return new NonEmptyEnumerable<TResult>(Enumerable.Select(this, selector).Distinct().ToArray());
    }

    public INonEmptyEnumerable<TResult> Select<TResult>(Func<T, TResult> func)
    {
        return new NonEmptyEnumerable<TResult>(Enumerable.Select(this, func).ToArray());
    }

    public INonEmptyEnumerable<TResult> Select<TResult>(Func<T, int, TResult> func)
    {
        return new NonEmptyEnumerable<TResult>(Enumerable.Select(this, func).ToArray());
    }

    public IReadOnlyList<T> AsReadonly()
    {
        return this;
    }

    #region static Create methods

    public static INonEmptyEnumerable<T> Create(T head, params T[] tail)
    {
        return new NonEmptyEnumerable<T>(head, tail);
    }

    public static INonEmptyEnumerable<T> Create(T head, IEnumerable<T> tail)
    {
        if (tail is T[] array)
            return new NonEmptyEnumerable<T>(head, array);

        return new NonEmptyEnumerable<T>(head, tail.AsList());
    }

    public static INonEmptyEnumerable<T> Create(T head, IReadOnlyList<T> tail)
    {
        return new NonEmptyEnumerable<T>(head, tail.ToList());
    }

    public static IOption<INonEmptyEnumerable<T>> Create(IEnumerable<T> values)
    {
        if (values is T[] array)
        {
            return array.Length == 0
                ? Option.Empty<INonEmptyEnumerable<T>>()
                : Option.Valued(new NonEmptyEnumerable<T>(array));
        }

        var list = values.AsList();
        return list.Count == 0
            ? Option.Empty<INonEmptyEnumerable<T>>()
            : Option.Valued(new NonEmptyEnumerable<T>(list));
    }

    public static IOption<INonEmptyEnumerable<T>> Create(IReadOnlyList<T> values)
    {
        if (values.Count == 0)
            return Option.Empty<INonEmptyEnumerable<T>>();

        if (values is T[] array)
            return Option.Valued(new NonEmptyEnumerable<T>(array));

        return Option.Valued(new NonEmptyEnumerable<T>(values.AsList()));
    }

    public static IOption<INonEmptyEnumerable<T>> CreateFlat(params IOption<T>[] values)
    {
        return Create(values.Flatten());
    }

    public static INonEmptyEnumerable<T> CreateFlat(INonEmptyEnumerable<T> head, params IEnumerable<T>[] tail)
    {
        return Create(head: head.Head, tail: head.Tail.Concat(tail.Flatten()));
    }

    public static INonEmptyEnumerable<T> CreateFlat(INonEmptyEnumerable<INonEmptyEnumerable<T>> values)
    {
        return Create(head: values.Head.Head, tail: values.Head.Tail.Concat(values.Tail.Flatten()));
    }

    public static INonEmptyEnumerable<V> CreateFlat<V>(INonEmptyEnumerable<T> source, Func<T, INonEmptyEnumerable<V>> selector)
    {
        return new NonEmptyEnumerable<V>(Enumerable.SelectMany(source, selector).ToArray());
    }

    #endregion static Create methods
}
