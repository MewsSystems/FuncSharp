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

    public static INonEmptyEnumerable<T> Create<T>(T head, IReadOnlyList<T> tail)
    {
        return NonEmptyEnumerable<T>.Create(head, tail);
    }

    public static INonEmptyEnumerable<T> Create<T>(T head, IEnumerable<T> tail)
    {
        return NonEmptyEnumerable<T>.Create(head, tail);
    }

    public static Option<INonEmptyEnumerable<T>> Create<T>(List<T> values)
    {
        return NonEmptyEnumerable<T>.Create(values);
    }

    public static Option<INonEmptyEnumerable<T>> Create<T>(T[] values)
    {
        return NonEmptyEnumerable<T>.Create(values);
    }

    public static Option<INonEmptyEnumerable<T>> Create<T>(IEnumerable<T> values)
    {
        return NonEmptyEnumerable<T>.Create(values);
    }

    public static Option<INonEmptyEnumerable<T>> CreateFlat<T>(params Option<T>[] values)
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
        Count = Tail.Count + 1;
    }

    public T Head { get; }

    public IReadOnlyList<T> Tail { get; }

    public int Count { get; }

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

        return CreateFromNonEmptyArray(Enumerable.Distinct(this).ToArray());
    }

    public INonEmptyEnumerable<TResult> Distinct<TResult>(Func<T, TResult> selector)
    {
        return CreateFromNonEmptyArray<TResult>(Enumerable.Select(this, selector).Distinct().ToArray());
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

    /// <summary>
    /// Returns the NonEmptyEnumerable typed as IReadOnlyList.
    /// </summary>
    public IReadOnlyList<T> AsReadOnly()
    {
        return this;
    }

    #region static Create methods

    public static INonEmptyEnumerable<T> Create(T head, IEnumerable<T> tail)
    {
        return new NonEmptyEnumerable<T>(head, tail.AsReadOnlyList());
    }

    public static INonEmptyEnumerable<T> Create(T head, params T[] tail)
    {
        return new NonEmptyEnumerable<T>(head, tail);
    }

    public static INonEmptyEnumerable<T> Create(T head, IReadOnlyList<T> tail)
    {
        return new NonEmptyEnumerable<T>(head, tail);
    }

    public static Option<INonEmptyEnumerable<T>> Create(IEnumerable<T> values)
    {
        return values switch
        {
            List<T> list => Create(list),
            T[] array => array.Length == 0
                ? Option.Empty<INonEmptyEnumerable<T>>()
                : Option.Valued<INonEmptyEnumerable<T>>(new NonEmptyEnumerable<T>(array[0], array.Skip(1).ToArray())), // This is here, because you can theoretically have array of a more specific type passed in as an array of a less specific type. That would then crash as you try to make a Span out of it. Because the type would not match.
            _ => Create(values.ToArray())
        };
    }

    public static Option<INonEmptyEnumerable<T>> Create(List<T> list)
    {
        return list.Count == 0
            ? Option.Empty<INonEmptyEnumerable<T>>()
            : Option.Valued<INonEmptyEnumerable<T>>(new NonEmptyEnumerable<T>(list[0], CollectionsMarshal.AsSpan(list).Slice(1).ToArray()));
    }

    public static Option<INonEmptyEnumerable<T>> Create(T[] array)
    {
        return array.Length == 0
            ? Option.Empty<INonEmptyEnumerable<T>>()
            : Option.Valued(CreateFromNonEmptyArray(array));
    }

    public static Option<INonEmptyEnumerable<T>> CreateFlat(params Option<T>[] values)
    {
        return Create(values.Flatten());
    }

    public static INonEmptyEnumerable<T> CreateFlat(INonEmptyEnumerable<T> head, params IEnumerable<T>[] tail)
    {
        return new NonEmptyEnumerable<T>(head: head.Head, tail: head.Tail.Concat(tail.Flatten()).ToArray());
    }

    private static INonEmptyEnumerable<TResult> CreateFromNonEmptyArray<TResult>(TResult[] array)
    {
        return new NonEmptyEnumerable<TResult>(array[0], array.AsSpan().Slice(1).ToArray());
    }

    #endregion static Create methods
}
