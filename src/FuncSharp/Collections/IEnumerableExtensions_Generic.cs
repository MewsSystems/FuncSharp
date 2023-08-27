﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FuncSharp
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Uses ToArray to generate an IReadOnlyList.
        /// </summary>
        public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> e)
        {
            return e.ToArray();
        }

        /// <summary>
        /// Returns the IEnumerable in case it is a ReadOnlyList or creates a new ReadOnlyList from it.
        /// </summary>
        [DebuggerStepThrough]
        public static IReadOnlyList<T> AsReadOnlyList<T>(this IEnumerable<T> source)
        {
            return source as IReadOnlyList<T> ?? source.ToArray();
        }

        /// <summary>
        /// Returns the array in case it is a ReadOnlyList or creates a new ReadOnlyList from it.
        /// </summary>
        [DebuggerStepThrough]
        [Pure]
        public static IReadOnlyList<T> AsReadOnlyList<T>(this T[] source)
        {
            return source;
        }

        /// <summary>
        /// Returns the list in case it is a ReadOnlyList or creates a new ReadOnlyList from it.
        /// </summary>
        [DebuggerStepThrough]
        [Pure]
        public static IReadOnlyList<T> AsReadOnlyList<T>(this List<T> source)
        {
            return source;
        }

        [Obsolete("This already is of type ReadOnlyList.", error: true)]
        public static IReadOnlyList<T> AsReadOnlyList<T>(this IReadOnlyList<T> source)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the IEnumerable in case it is a List or creates a new List from it.
        /// </summary>
        [DebuggerStepThrough]
        public static List<T> AsList<T>(this IEnumerable<T> source)
        {
            return source as List<T> ?? source.ToList();
        }

        /// <summary>
        /// Returns the IEnumerable in case it is a Array or creates a new Array from it.
        /// </summary>
        [DebuggerStepThrough]
        public static T[] AsArray<T>(this IEnumerable<T> source)
        {
            return source as T[] ?? source.ToArray();
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> e, params T[] excludedItems)
        {
            return Enumerable.Except(e, excludedItems);
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> e, params IEnumerable<T>[] others)
        {
            return Enumerable.Except(e, others.Flatten());
        }

        public static IEnumerable<T> ExceptNulls<T>(this IEnumerable<T?> e)
            where T : struct
        {
            return e.Where(item => item.HasValue).Select(item => item.Value);
        }

        public static IEnumerable<T> ExceptNulls<T>(this IEnumerable<T> e)
            where T : class
        {
            return e.Where(v => v is not null);
        }

        public static bool IsMultiple<T>(this IEnumerable<T> e)
        {
            switch (e)
            {
                case null:
                    return false;
                case IReadOnlyCollection<T> c:
                    return c.Count > 1;
                default:
                {
                    using var enumerator = e.GetEnumerator();
                    return enumerator.MoveNext() && enumerator.MoveNext();
                }
            }
        }

        public static bool IsSingle<T>(this IEnumerable<T> e)
        {
            switch (e)
            {
                case null:
                    return false;
                case IReadOnlyCollection<T> c1:
                    return c1.Count == 1;
                default:
                {
                    using var enumerator = e.GetEnumerator();
                    return enumerator.MoveNext() && !enumerator.MoveNext();
                }
            }
        }

        public static T Second<T>(this IEnumerable<T> e)
        {
            return e.ElementAt(1);
        }

        public static T Third<T>(this IEnumerable<T> e)
        {
            return e.ElementAt(2);
        }

        public static T Fourth<T>(this IEnumerable<T> e)
        {
            return e.ElementAt(3);
        }

        public static T Fifth<T>(this IEnumerable<T> e)
        {
            return e.ElementAt(4);
        }

        /// <summary>
        /// Orders the values using the specified less function in the specified order.
        /// </summary>
        public static IEnumerable<T> Order<T>(this IEnumerable<T> values, Func<T, T, bool> less, Ordering ordering = Ordering.Ascending)
        {
            var comparer = new Comparer<T>(less, ordering);
            return values.OrderBy(v => v, comparer);
        }

        /// <summary>
        /// Aggregates the exceptions into an AggregateException. If there is a single exception, returns it directly.
        /// </summary>
        public static Option<Exception> Aggregate(this IEnumerable<Exception> source)
        {
            return Aggregate(source.AsReadOnlyList());
        }

        /// <summary>
        /// Aggregates the exceptions into an AggregateException. If there is a single exception, returns it directly.
        /// </summary>
        [Pure]
        public static Option<Exception> Aggregate(this IReadOnlyList<Exception> source)
        {
            return source.Count switch
            {
                0 => Option<Exception>.Empty,
                1 => Option.Valued(source[0]),
                _ => Option.Valued<Exception>(new AggregateException(source))
            };
        }

        /// <summary>
        /// Aggregates the exceptions into an AggregateException. If there is a single exception, returns it directly.
        /// </summary>
        [Pure]
        public static Exception Aggregate(this INonEmptyEnumerable<Exception> source)
        {
                return source.Count switch
                {
                    1 => source[0],
                    _ => new AggregateException(source)
                };
        }
    }
}