﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FuncSharp
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Returns a ToList() juts of type IReadOnlyList.
        /// </summary>
        public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> e)
        {
            return e.ToList().AsReadOnly();
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

        /// <summary>
        /// Returns all the items inside all the collections combined into 1 IEnumerable.
        /// </summary>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> e)
        {
            return e.SelectMany(i => i);
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> e, params T[] excludedItems)
        {
            return e.Except(excludedItems.AsEnumerable());
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> e, params IEnumerable<T>[] others)
        {
            return Enumerable.Except(e, others.Flatten());
        }

        public static IEnumerable<T> ExceptNulls<T>(this IEnumerable<T?> e)
            where T : struct
        {
            return e.Where(v => v.HasValue).Select(v => v.Value);
        }

        public static IEnumerable<T> ExceptNulls<T>(this IEnumerable<T> e)
            where T : class
        {
            return e.Where(v => v is not null);
        }

        public static bool NonEmpty<T>(this IEnumerable<T> e)
        {
            return e is not null && e.Any();
        }

        public static bool IsEmpty<T>(this IEnumerable<T> e)
        {
            return !e.NonEmpty();
        }

        public static bool IsMultiple<T>(this IEnumerable<T> e)
        {
            return e is not null && e.Take(2).Count().SafeEquals(2);
        }

        public static bool IsSingle<T>(this IEnumerable<T> e)
        {
            return e is not null && e.Take(2).Count().SafeEquals(1);
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
            return Enumerable.Concat(first ?? Enumerable.Empty<T>(), items);
        }

        public static IEnumerable<T> SafeConcat<T>(this IEnumerable<T> first, params IEnumerable<T>[] others)
        {
            return Enumerable.Concat(first ?? Enumerable.Empty<T>(), others.SelectMany(o => o ?? Enumerable.Empty<T>()));
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
        public static IOption<Exception> Aggregate(this IEnumerable<Exception> source)
        {
            var exceptions = source.AsReadOnlyList();
            switch (exceptions.Count)
            {
                case 0: return Option<Exception>.Empty;
                case 1: return Option.Valued(exceptions[0]);
                default: return Option.Valued(new AggregateException(exceptions));
            }
        }
    }
}