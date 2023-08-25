using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FuncSharp
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Returns a nonEmptyEnumerable in case the collection is nonempty. Otherwise returns empty option.
        /// </summary>
        [DebuggerStepThrough]
        public static IOption<INonEmptyEnumerable<T>> AsNonEmpty<T>(this IEnumerable<T> source)
        {
            return source switch
            {
                null => Option.Empty<INonEmptyEnumerable<T>>(),
                INonEmptyEnumerable<T> list => Option.Valued(list),
                _ => NonEmptyEnumerable.Create(source)
            };
        }

        [Obsolete("This is already a NonEmptyEnumerable.", error: true)]
        public static IOption<INonEmptyEnumerable<T>> AsNonEmpty<T>(this INonEmptyEnumerable<T> source)
        {
            throw new NotImplementedException();
        }

        [Pure]
        public static INonEmptyEnumerable<T> Flatten<T>(this INonEmptyEnumerable<INonEmptyEnumerable<T>> source)
        {
            return NonEmptyEnumerable<T>.Create(source.Head.Head, source.Head.Tail.Concat(source.Tail.Flatten()).ToArray());
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