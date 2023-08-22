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
        return NonEmptyEnumerable<T>.Create(head, tail);
    }

    public static INonEmptyEnumerable<T> Create<T>(T head, IEnumerable<T> tail)
    {
        return NonEmptyEnumerable<T>.Create(head, tail);
    }

    public static IOption<INonEmptyEnumerable<T>> Create<T>(IEnumerable<T> values)
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
    /// <summary>
    /// All the static constructors make sure to copy the contents of the array to prevent future modifications of the content of this class. That's why we can simply assign it here.
    /// </summary>
    private NonEmptyEnumerable(T head, IReadOnlyList<T> tail)
    {
        Head = head;
        Tail = tail;
    }

    private NonEmptyEnumerable(T[] array)
    {
        Head = array[0];
        Tail = array.AsSpan().Slice(1).ToArray();;
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
        return new NonEmptyEnumerable<TResult>(func(Head), Tail.Select(func).ToArray());
    }

    public INonEmptyEnumerable<TResult> Select<TResult>(Func<T, int, TResult> func)
    {
        return new NonEmptyEnumerable<TResult>(func(Head, 0), Tail.Select((v, i) => func(v, i + 1)).ToArray());
    }

    public INonEmptyEnumerable<TResult> SelectMany<TResult>(Func<T, INonEmptyEnumerable<TResult>> selector)
    {
        var headResult = selector(Head);
        return new NonEmptyEnumerable<TResult>(headResult.Head, headResult.Tail.Concat(Tail.SelectMany(selector)).ToArray());
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
        if (tail is IReadOnlyList<T> list)
            return new NonEmptyEnumerable<T>(head, list);

        return new NonEmptyEnumerable<T>(head, tail.ToArray());
    }

    public static IOption<INonEmptyEnumerable<T>> Create(IEnumerable<T> values)
    {
        if (values is IReadOnlyList<T> list)
        {
            return list.Count == 0
                ? Option.Empty<INonEmptyEnumerable<T>>()
                : Option.Valued(new NonEmptyEnumerable<T>(list[0], list.ToArray()));
        }

        var array = values.ToArray();
        return array.Length == 0
            ? Option.Empty<INonEmptyEnumerable<T>>()
            : Option.Valued(new NonEmptyEnumerable<T>(array));
    }

    public static IOption<INonEmptyEnumerable<T>> CreateFlat(params IOption<T>[] values)
    {
        var array = values.Flatten().ToArray();

        return array.Length == 0
            ? Option.Empty<INonEmptyEnumerable<T>>()
            : Option.Valued(new NonEmptyEnumerable<T>(array));
    }

    public static INonEmptyEnumerable<T> CreateFlat(INonEmptyEnumerable<T> head, params IEnumerable<T>[] tail)
    {
        return new NonEmptyEnumerable<T>(head: head.Head, tail: head.Tail.Concat(tail.Flatten()).ToArray());
    }

    #endregion static Create methods
}
