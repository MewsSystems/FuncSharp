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
        /// Returns all the items inside all the collections combined into 1 IEnumerable.
        /// </summary>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> e)
        {
            return e.SelectMany(i => i);
        }

        [Pure]
        public static INonEmptyEnumerable<T> Flatten<T>(this INonEmptyEnumerable<INonEmptyEnumerable<T>> source)
        {
            return NonEmptyEnumerable<T>.Create(source.Head.Head, source.Head.Tail.Concat(source.Tail.Flatten()).ToArray());
        }
    }
}