using System;
using System.Collections.Generic;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1>(
        this IEnumerable<ICoproduct1<T1>> source,
        Action<IReadOnlyList<T1>> f1)
    {
        var list1 = new List<T1>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1)
            );
        }

        f1(list1);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, TResult>(
        this IEnumerable<ICoproduct1<T1>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1))
        );

        return result;
    }


    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2>(
        this IEnumerable<ICoproduct2<T1, T2>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2)
            );
        }

        f1(list1);
        f2(list2);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, TResult>(
        this IEnumerable<ICoproduct2<T1, T2>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>) Partition<T1, T2>(this IEnumerable<ICoproduct2<T1, T2>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2)
            );
        }

        return (list1, list2);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3>(
        this IEnumerable<ICoproduct3<T1, T2, T3>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, TResult>(
        this IEnumerable<ICoproduct3<T1, T2, T3>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>) Partition<T1, T2, T3>(this IEnumerable<ICoproduct3<T1, T2, T3>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3)
            );
        }

        return (list1, list2, list3);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4>(
        this IEnumerable<ICoproduct4<T1, T2, T3, T4>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, TResult>(
        this IEnumerable<ICoproduct4<T1, T2, T3, T4>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>) Partition<T1, T2, T3, T4>(this IEnumerable<ICoproduct4<T1, T2, T3, T4>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4)
            );
        }

        return (list1, list2, list3, list4);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5>(
        this IEnumerable<ICoproduct5<T1, T2, T3, T4, T5>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, TResult>(
        this IEnumerable<ICoproduct5<T1, T2, T3, T4, T5>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>) Partition<T1, T2, T3, T4, T5>(this IEnumerable<ICoproduct5<T1, T2, T3, T4, T5>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5)
            );
        }

        return (list1, list2, list3, list4, list5);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6>(
        this IEnumerable<ICoproduct6<T1, T2, T3, T4, T5, T6>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, TResult>(
        this IEnumerable<ICoproduct6<T1, T2, T3, T4, T5, T6>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>) Partition<T1, T2, T3, T4, T5, T6>(this IEnumerable<ICoproduct6<T1, T2, T3, T4, T5, T6>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6)
            );
        }

        return (list1, list2, list3, list4, list5, list6);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7>(
        this IEnumerable<ICoproduct7<T1, T2, T3, T4, T5, T6, T7>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this IEnumerable<ICoproduct7<T1, T2, T3, T4, T5, T6, T7>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>) Partition<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<ICoproduct7<T1, T2, T3, T4, T5, T6, T7>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8>(
        this IEnumerable<ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
        this IEnumerable<ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>) Partition<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable<ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        this IEnumerable<ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
        this IEnumerable<ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEnumerable<ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        this IEnumerable<ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
        this IEnumerable<ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IEnumerable<ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
        this IEnumerable<ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
        this IEnumerable<ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IEnumerable<ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
        this IEnumerable<ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
        this IEnumerable<ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IEnumerable<ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
        this IEnumerable<ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12,
        Action<IReadOnlyList<T13>> f13)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
        f13(list13);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
        this IEnumerable<ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12,
        Func<IReadOnlyList<T13>, IEnumerable<TResult>> f13)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12)),
            c13 => result.AddRange(f13(c13))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IEnumerable<ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
        this IEnumerable<ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12,
        Action<IReadOnlyList<T13>> f13,
        Action<IReadOnlyList<T14>> f14)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
        f13(list13);
        f14(list14);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
        this IEnumerable<ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12,
        Func<IReadOnlyList<T13>, IEnumerable<TResult>> f13,
        Func<IReadOnlyList<T14>, IEnumerable<TResult>> f14)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12)),
            c13 => result.AddRange(f13(c13)),
            c14 => result.AddRange(f14(c14))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IEnumerable<ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
        this IEnumerable<ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12,
        Action<IReadOnlyList<T13>> f13,
        Action<IReadOnlyList<T14>> f14,
        Action<IReadOnlyList<T15>> f15)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
        f13(list13);
        f14(list14);
        f15(list15);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
        this IEnumerable<ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12,
        Func<IReadOnlyList<T13>, IEnumerable<TResult>> f13,
        Func<IReadOnlyList<T14>, IEnumerable<TResult>> f14,
        Func<IReadOnlyList<T15>, IEnumerable<TResult>> f15)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12)),
            c13 => result.AddRange(f13(c13)),
            c14 => result.AddRange(f14(c14)),
            c15 => result.AddRange(f15(c15))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IEnumerable<ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
        this IEnumerable<ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12,
        Action<IReadOnlyList<T13>> f13,
        Action<IReadOnlyList<T14>> f14,
        Action<IReadOnlyList<T15>> f15,
        Action<IReadOnlyList<T16>> f16)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
        f13(list13);
        f14(list14);
        f15(list15);
        f16(list16);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
        this IEnumerable<ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12,
        Func<IReadOnlyList<T13>, IEnumerable<TResult>> f13,
        Func<IReadOnlyList<T14>, IEnumerable<TResult>> f14,
        Func<IReadOnlyList<T15>, IEnumerable<TResult>> f15,
        Func<IReadOnlyList<T16>, IEnumerable<TResult>> f16)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12)),
            c13 => result.AddRange(f13(c13)),
            c14 => result.AddRange(f14(c14)),
            c15 => result.AddRange(f15(c15)),
            c16 => result.AddRange(f16(c16))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IEnumerable<ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
        this IEnumerable<ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12,
        Action<IReadOnlyList<T13>> f13,
        Action<IReadOnlyList<T14>> f14,
        Action<IReadOnlyList<T15>> f15,
        Action<IReadOnlyList<T16>> f16,
        Action<IReadOnlyList<T17>> f17)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
        f13(list13);
        f14(list14);
        f15(list15);
        f16(list16);
        f17(list17);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult>(
        this IEnumerable<ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12,
        Func<IReadOnlyList<T13>, IEnumerable<TResult>> f13,
        Func<IReadOnlyList<T14>, IEnumerable<TResult>> f14,
        Func<IReadOnlyList<T15>, IEnumerable<TResult>> f15,
        Func<IReadOnlyList<T16>, IEnumerable<TResult>> f16,
        Func<IReadOnlyList<T17>, IEnumerable<TResult>> f17)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12)),
            c13 => result.AddRange(f13(c13)),
            c14 => result.AddRange(f14(c14)),
            c15 => result.AddRange(f15(c15)),
            c16 => result.AddRange(f16(c16)),
            c17 => result.AddRange(f17(c17))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>, IReadOnlyList<T17>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(this IEnumerable<ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, list17);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
        this IEnumerable<ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12,
        Action<IReadOnlyList<T13>> f13,
        Action<IReadOnlyList<T14>> f14,
        Action<IReadOnlyList<T15>> f15,
        Action<IReadOnlyList<T16>> f16,
        Action<IReadOnlyList<T17>> f17,
        Action<IReadOnlyList<T18>> f18)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();
        var list18 = new List<T18>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17),
                c18 => list18.Add(c18)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
        f13(list13);
        f14(list14);
        f15(list15);
        f16(list16);
        f17(list17);
        f18(list18);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TResult>(
        this IEnumerable<ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12,
        Func<IReadOnlyList<T13>, IEnumerable<TResult>> f13,
        Func<IReadOnlyList<T14>, IEnumerable<TResult>> f14,
        Func<IReadOnlyList<T15>, IEnumerable<TResult>> f15,
        Func<IReadOnlyList<T16>, IEnumerable<TResult>> f16,
        Func<IReadOnlyList<T17>, IEnumerable<TResult>> f17,
        Func<IReadOnlyList<T18>, IEnumerable<TResult>> f18)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12)),
            c13 => result.AddRange(f13(c13)),
            c14 => result.AddRange(f14(c14)),
            c15 => result.AddRange(f15(c15)),
            c16 => result.AddRange(f16(c16)),
            c17 => result.AddRange(f17(c17)),
            c18 => result.AddRange(f18(c18))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>, IReadOnlyList<T17>, IReadOnlyList<T18>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(this IEnumerable<ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();
        var list18 = new List<T18>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17),
                c18 => list18.Add(c18)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, list17, list18);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
        this IEnumerable<ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12,
        Action<IReadOnlyList<T13>> f13,
        Action<IReadOnlyList<T14>> f14,
        Action<IReadOnlyList<T15>> f15,
        Action<IReadOnlyList<T16>> f16,
        Action<IReadOnlyList<T17>> f17,
        Action<IReadOnlyList<T18>> f18,
        Action<IReadOnlyList<T19>> f19)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();
        var list18 = new List<T18>();
        var list19 = new List<T19>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17),
                c18 => list18.Add(c18),
                c19 => list19.Add(c19)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
        f13(list13);
        f14(list14);
        f15(list15);
        f16(list16);
        f17(list17);
        f18(list18);
        f19(list19);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TResult>(
        this IEnumerable<ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12,
        Func<IReadOnlyList<T13>, IEnumerable<TResult>> f13,
        Func<IReadOnlyList<T14>, IEnumerable<TResult>> f14,
        Func<IReadOnlyList<T15>, IEnumerable<TResult>> f15,
        Func<IReadOnlyList<T16>, IEnumerable<TResult>> f16,
        Func<IReadOnlyList<T17>, IEnumerable<TResult>> f17,
        Func<IReadOnlyList<T18>, IEnumerable<TResult>> f18,
        Func<IReadOnlyList<T19>, IEnumerable<TResult>> f19)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12)),
            c13 => result.AddRange(f13(c13)),
            c14 => result.AddRange(f14(c14)),
            c15 => result.AddRange(f15(c15)),
            c16 => result.AddRange(f16(c16)),
            c17 => result.AddRange(f17(c17)),
            c18 => result.AddRange(f18(c18)),
            c19 => result.AddRange(f19(c19))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>, IReadOnlyList<T17>, IReadOnlyList<T18>, IReadOnlyList<T19>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(this IEnumerable<ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();
        var list18 = new List<T18>();
        var list19 = new List<T19>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17),
                c18 => list18.Add(c18),
                c19 => list19.Add(c19)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, list17, list18, list19);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
        this IEnumerable<ICoproduct20<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12,
        Action<IReadOnlyList<T13>> f13,
        Action<IReadOnlyList<T14>> f14,
        Action<IReadOnlyList<T15>> f15,
        Action<IReadOnlyList<T16>> f16,
        Action<IReadOnlyList<T17>> f17,
        Action<IReadOnlyList<T18>> f18,
        Action<IReadOnlyList<T19>> f19,
        Action<IReadOnlyList<T20>> f20)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();
        var list18 = new List<T18>();
        var list19 = new List<T19>();
        var list20 = new List<T20>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17),
                c18 => list18.Add(c18),
                c19 => list19.Add(c19),
                c20 => list20.Add(c20)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
        f13(list13);
        f14(list14);
        f15(list15);
        f16(list16);
        f17(list17);
        f18(list18);
        f19(list19);
        f20(list20);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TResult>(
        this IEnumerable<ICoproduct20<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12,
        Func<IReadOnlyList<T13>, IEnumerable<TResult>> f13,
        Func<IReadOnlyList<T14>, IEnumerable<TResult>> f14,
        Func<IReadOnlyList<T15>, IEnumerable<TResult>> f15,
        Func<IReadOnlyList<T16>, IEnumerable<TResult>> f16,
        Func<IReadOnlyList<T17>, IEnumerable<TResult>> f17,
        Func<IReadOnlyList<T18>, IEnumerable<TResult>> f18,
        Func<IReadOnlyList<T19>, IEnumerable<TResult>> f19,
        Func<IReadOnlyList<T20>, IEnumerable<TResult>> f20)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12)),
            c13 => result.AddRange(f13(c13)),
            c14 => result.AddRange(f14(c14)),
            c15 => result.AddRange(f15(c15)),
            c16 => result.AddRange(f16(c16)),
            c17 => result.AddRange(f17(c17)),
            c18 => result.AddRange(f18(c18)),
            c19 => result.AddRange(f19(c19)),
            c20 => result.AddRange(f20(c20))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>, IReadOnlyList<T17>, IReadOnlyList<T18>, IReadOnlyList<T19>, IReadOnlyList<T20>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(this IEnumerable<ICoproduct20<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();
        var list18 = new List<T18>();
        var list19 = new List<T19>();
        var list20 = new List<T20>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17),
                c18 => list18.Add(c18),
                c19 => list19.Add(c19),
                c20 => list20.Add(c20)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, list17, list18, list19, list20);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function.
    /// </summary>
    public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(
        this IEnumerable<ICoproduct21<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>> source,
        Action<IReadOnlyList<T1>> f1,
        Action<IReadOnlyList<T2>> f2,
        Action<IReadOnlyList<T3>> f3,
        Action<IReadOnlyList<T4>> f4,
        Action<IReadOnlyList<T5>> f5,
        Action<IReadOnlyList<T6>> f6,
        Action<IReadOnlyList<T7>> f7,
        Action<IReadOnlyList<T8>> f8,
        Action<IReadOnlyList<T9>> f9,
        Action<IReadOnlyList<T10>> f10,
        Action<IReadOnlyList<T11>> f11,
        Action<IReadOnlyList<T12>> f12,
        Action<IReadOnlyList<T13>> f13,
        Action<IReadOnlyList<T14>> f14,
        Action<IReadOnlyList<T15>> f15,
        Action<IReadOnlyList<T16>> f16,
        Action<IReadOnlyList<T17>> f17,
        Action<IReadOnlyList<T18>> f18,
        Action<IReadOnlyList<T19>> f19,
        Action<IReadOnlyList<T20>> f20,
        Action<IReadOnlyList<T21>> f21)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();
        var list18 = new List<T18>();
        var list19 = new List<T19>();
        var list20 = new List<T20>();
        var list21 = new List<T21>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17),
                c18 => list18.Add(c18),
                c19 => list19.Add(c19),
                c20 => list20.Add(c20),
                c21 => list21.Add(c21)
            );
        }

        f1(list1);
        f2(list2);
        f3(list3);
        f4(list4);
        f5(list5);
        f6(list6);
        f7(list7);
        f8(list8);
        f9(list9);
        f10(list10);
        f11(list11);
        f12(list12);
        f13(list13);
        f14(list14);
        f15(list15);
        f16(list16);
        f17(list17);
        f18(list18);
        f19(list19);
        f20(list20);
        f21(list21);
    }

    /// <summary>
    /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
    /// </summary>
    public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TResult>(
        this IEnumerable<ICoproduct21<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>> source,
        Func<IReadOnlyList<T1>, IEnumerable<TResult>> f1,
        Func<IReadOnlyList<T2>, IEnumerable<TResult>> f2,
        Func<IReadOnlyList<T3>, IEnumerable<TResult>> f3,
        Func<IReadOnlyList<T4>, IEnumerable<TResult>> f4,
        Func<IReadOnlyList<T5>, IEnumerable<TResult>> f5,
        Func<IReadOnlyList<T6>, IEnumerable<TResult>> f6,
        Func<IReadOnlyList<T7>, IEnumerable<TResult>> f7,
        Func<IReadOnlyList<T8>, IEnumerable<TResult>> f8,
        Func<IReadOnlyList<T9>, IEnumerable<TResult>> f9,
        Func<IReadOnlyList<T10>, IEnumerable<TResult>> f10,
        Func<IReadOnlyList<T11>, IEnumerable<TResult>> f11,
        Func<IReadOnlyList<T12>, IEnumerable<TResult>> f12,
        Func<IReadOnlyList<T13>, IEnumerable<TResult>> f13,
        Func<IReadOnlyList<T14>, IEnumerable<TResult>> f14,
        Func<IReadOnlyList<T15>, IEnumerable<TResult>> f15,
        Func<IReadOnlyList<T16>, IEnumerable<TResult>> f16,
        Func<IReadOnlyList<T17>, IEnumerable<TResult>> f17,
        Func<IReadOnlyList<T18>, IEnumerable<TResult>> f18,
        Func<IReadOnlyList<T19>, IEnumerable<TResult>> f19,
        Func<IReadOnlyList<T20>, IEnumerable<TResult>> f20,
        Func<IReadOnlyList<T21>, IEnumerable<TResult>> f21)
    {
        var result = new List<TResult>();

        source.PartitionMatch(
            c1 => result.AddRange(f1(c1)),
            c2 => result.AddRange(f2(c2)),
            c3 => result.AddRange(f3(c3)),
            c4 => result.AddRange(f4(c4)),
            c5 => result.AddRange(f5(c5)),
            c6 => result.AddRange(f6(c6)),
            c7 => result.AddRange(f7(c7)),
            c8 => result.AddRange(f8(c8)),
            c9 => result.AddRange(f9(c9)),
            c10 => result.AddRange(f10(c10)),
            c11 => result.AddRange(f11(c11)),
            c12 => result.AddRange(f12(c12)),
            c13 => result.AddRange(f13(c13)),
            c14 => result.AddRange(f14(c14)),
            c15 => result.AddRange(f15(c15)),
            c16 => result.AddRange(f16(c16)),
            c17 => result.AddRange(f17(c17)),
            c18 => result.AddRange(f18(c18)),
            c19 => result.AddRange(f19(c19)),
            c20 => result.AddRange(f20(c20)),
            c21 => result.AddRange(f21(c21))
        );

        return result;
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>, IReadOnlyList<T17>, IReadOnlyList<T18>, IReadOnlyList<T19>, IReadOnlyList<T20>, IReadOnlyList<T21>) Partition<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(this IEnumerable<ICoproduct21<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>> source)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();
        var list9 = new List<T9>();
        var list10 = new List<T10>();
        var list11 = new List<T11>();
        var list12 = new List<T12>();
        var list13 = new List<T13>();
        var list14 = new List<T14>();
        var list15 = new List<T15>();
        var list16 = new List<T16>();
        var list17 = new List<T17>();
        var list18 = new List<T18>();
        var list19 = new List<T19>();
        var list20 = new List<T20>();
        var list21 = new List<T21>();

        foreach (var c in source)
        {
            c.Match(
                c1 => list1.Add(c1),
                c2 => list2.Add(c2),
                c3 => list3.Add(c3),
                c4 => list4.Add(c4),
                c5 => list5.Add(c5),
                c6 => list6.Add(c6),
                c7 => list7.Add(c7),
                c8 => list8.Add(c8),
                c9 => list9.Add(c9),
                c10 => list10.Add(c10),
                c11 => list11.Add(c11),
                c12 => list12.Add(c12),
                c13 => list13.Add(c13),
                c14 => list14.Add(c14),
                c15 => list15.Add(c15),
                c16 => list16.Add(c16),
                c17 => list17.Add(c17),
                c18 => list18.Add(c18),
                c19 => list19.Add(c19),
                c20 => list20.Add(c20),
                c21 => list21.Add(c21)
            );
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, list17, list18, list19, list20, list21);
    }
}