using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FuncSharp
{
    public static partial class IEnumerableExtensions
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, params T[] items)
        {
            return Enumerable.Concat(first, items);
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, params IEnumerable<T>[] others)
        {
            return Enumerable.Concat(first, others.Flatten());
        }

        public static IEnumerable<T> SafeConcat<T>(this IEnumerable<T> first, params T[] items)
        {
            return first is null
                ? items
                : Enumerable.Concat(first, items);
        }

        public static IEnumerable<T> SafeConcat<T>(this IEnumerable<T> first, params IEnumerable<T>[] others)
        {
            var othersResult = others is null
                ? Array.Empty<T>()
                : others.SelectMany(o => o ?? Enumerable.Empty<T>());

            return first is null
                ? othersResult
                : Enumerable.Concat(first, othersResult);
        }

        public static INonEmptyEnumerable<T> Concat<T>(this T e, params IEnumerable<T>[] others)
        {
            return NonEmptyEnumerable.Create(e, others.Flatten().ToArray());
        }

        [Pure]
        public static INonEmptyEnumerable<T> Concat<T>(this INonEmptyEnumerable<T> source, params T[] items)
        {
            return NonEmptyEnumerable.Create(source.Head, source.Tail.Concat(items).ToArray());
        }

        public static INonEmptyEnumerable<T> Concat<T>(this INonEmptyEnumerable<T> source, params IEnumerable<T>[] items)
        {
            return NonEmptyEnumerable.Create(source.Head, source.Tail.Concat(items).ToArray());
        }
    }
}