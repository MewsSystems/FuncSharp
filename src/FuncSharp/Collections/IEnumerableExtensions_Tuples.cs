
using System.Collections.Generic;

namespace FuncSharp;

public static partial class IEnumerableExtensions
{

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>) Unpack<T1, T2>(this IEnumerable<(T1, T2)> values)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
        }

        return (list1, list2);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>) Unpack<T1, T2, T3>(this IEnumerable<(T1, T2, T3)> values)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
        }

        return (list1, list2, list3);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>) Unpack<T1, T2, T3, T4>(this IEnumerable<(T1, T2, T3, T4)> values)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
        }

        return (list1, list2, list3, list4);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>) Unpack<T1, T2, T3, T4, T5>(this IEnumerable<(T1, T2, T3, T4, T5)> values)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
        }

        return (list1, list2, list3, list4, list5);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>) Unpack<T1, T2, T3, T4, T5, T6>(this IEnumerable<(T1, T2, T3, T4, T5, T6)> values)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
        }

        return (list1, list2, list3, list4, list5, list6);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>) Unpack<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> values)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
        }

        return (list1, list2, list3, list4, list5, list6, list7);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> values)
    {
        var list1 = new List<T1>();
        var list2 = new List<T2>();
        var list3 = new List<T3>();
        var list4 = new List<T4>();
        var list5 = new List<T5>();
        var list6 = new List<T6>();
        var list7 = new List<T7>();
        var list8 = new List<T8>();

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
            list12.Add(tuple.Item12);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
            list12.Add(tuple.Item12);
            list13.Add(tuple.Item13);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
            list12.Add(tuple.Item12);
            list13.Add(tuple.Item13);
            list14.Add(tuple.Item14);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
            list12.Add(tuple.Item12);
            list13.Add(tuple.Item13);
            list14.Add(tuple.Item14);
            list15.Add(tuple.Item15);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
            list12.Add(tuple.Item12);
            list13.Add(tuple.Item13);
            list14.Add(tuple.Item14);
            list15.Add(tuple.Item15);
            list16.Add(tuple.Item16);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>, IReadOnlyList<T17>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
            list12.Add(tuple.Item12);
            list13.Add(tuple.Item13);
            list14.Add(tuple.Item14);
            list15.Add(tuple.Item15);
            list16.Add(tuple.Item16);
            list17.Add(tuple.Item17);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, list17);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>, IReadOnlyList<T17>, IReadOnlyList<T18>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
            list12.Add(tuple.Item12);
            list13.Add(tuple.Item13);
            list14.Add(tuple.Item14);
            list15.Add(tuple.Item15);
            list16.Add(tuple.Item16);
            list17.Add(tuple.Item17);
            list18.Add(tuple.Item18);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, list17, list18);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>, IReadOnlyList<T17>, IReadOnlyList<T18>, IReadOnlyList<T19>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
            list12.Add(tuple.Item12);
            list13.Add(tuple.Item13);
            list14.Add(tuple.Item14);
            list15.Add(tuple.Item15);
            list16.Add(tuple.Item16);
            list17.Add(tuple.Item17);
            list18.Add(tuple.Item18);
            list19.Add(tuple.Item19);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, list17, list18, list19);
    }

    /// <summary>
    /// Takes a collection of coproducts, partitions them into collections and returns those collections.
    /// </summary>
    public static (IReadOnlyList<T1>, IReadOnlyList<T2>, IReadOnlyList<T3>, IReadOnlyList<T4>, IReadOnlyList<T5>, IReadOnlyList<T6>, IReadOnlyList<T7>, IReadOnlyList<T8>, IReadOnlyList<T9>, IReadOnlyList<T10>, IReadOnlyList<T11>, IReadOnlyList<T12>, IReadOnlyList<T13>, IReadOnlyList<T14>, IReadOnlyList<T15>, IReadOnlyList<T16>, IReadOnlyList<T17>, IReadOnlyList<T18>, IReadOnlyList<T19>, IReadOnlyList<T20>) Unpack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20)> values)
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

        foreach (var tuple in values)
        {
            list1.Add(tuple.Item1);
            list2.Add(tuple.Item2);
            list3.Add(tuple.Item3);
            list4.Add(tuple.Item4);
            list5.Add(tuple.Item5);
            list6.Add(tuple.Item6);
            list7.Add(tuple.Item7);
            list8.Add(tuple.Item8);
            list9.Add(tuple.Item9);
            list10.Add(tuple.Item10);
            list11.Add(tuple.Item11);
            list12.Add(tuple.Item12);
            list13.Add(tuple.Item13);
            list14.Add(tuple.Item14);
            list15.Add(tuple.Item15);
            list16.Add(tuple.Item16);
            list17.Add(tuple.Item17);
            list18.Add(tuple.Item18);
            list19.Add(tuple.Item19);
            list20.Add(tuple.Item20);
        }

        return (list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, list17, list18, list19, list20);
    }
}