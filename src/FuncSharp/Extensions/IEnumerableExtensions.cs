﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FuncSharp
{
    public static class IEnumerableExtensions
    {
        #region Generic

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
            return source as IReadOnlyList<T> ?? source.ToList();
        }

        /// <summary>
        /// Returns the IEnumerable in case it is a ReadOnlyList or creates a new ReadOnlyList from it.
        /// </summary>
        [DebuggerStepThrough]
        public static List<T> AsList<T>(this IEnumerable<T> source)
        {
            return source as List<T> ?? source.ToList();
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
            var exceptions = source.ToList();
            switch (exceptions.Count)
            {
                case 0: return Option<Exception>.Empty;
                case 1: return Option.Valued(exceptions[0]);
                default: return Option.Valued(new AggregateException(exceptions));
            }
        }

        #endregion Generic

        #region Numeric

        public static PositiveInt Sum(this INonEmptyEnumerable<PositiveInt> values)
        {
            return PositiveInt.CreateUnsafe(values.Sum(v => v.Value));
        }

        public static NonPositiveInt Sum(this IEnumerable<NonPositiveInt> values)
        {
            return values.Aggregate(0.AsUnsafeNonPositive(), (a, b) => a + b);
        }

        public static NonNegativeInt Sum(this IEnumerable<NonNegativeInt> values)
        {
            return values.Aggregate(NonNegativeInt.Zero, (a, b) => a + b);
        }

        #endregion Numeric

        #region NonEmpty

        /// <summary>
        /// Returns a nonEmptyEnumerable in case the collection is nonempty. Otherwise returns empty option.
        /// </summary>
        [DebuggerStepThrough]
        public static IOption<INonEmptyEnumerable<T>> AsNonEmpty<T>(this IEnumerable<T> source)
        {
            if (source is null)
            {
                return Option.Empty<INonEmptyEnumerable<T>>();
            }
            return NonEmptyEnumerable.Create(source);
        }

        /// <summary>
        /// Returns the nonEmptyEnumerable typed as IReadOnlyList.
        /// </summary>
        [DebuggerStepThrough]
        public static IReadOnlyList<T> AsReadOnly<T>(this INonEmptyEnumerable<T> source)
        {
            return source;
        }

        public static INonEmptyEnumerable<V> SelectMany<T, V>(this INonEmptyEnumerable<T> source, Func<T, INonEmptyEnumerable<V>> selector)
        {
            return NonEmptyEnumerable.CreateFlat(source.Select(selector));
        }

        public static INonEmptyEnumerable<T> Flatten<T>(this INonEmptyEnumerable<INonEmptyEnumerable<T>> source)
        {
            return NonEmptyEnumerable.CreateFlat(source);
        }

        public static INonEmptyEnumerable<T> Concat<T>(this T e, params IEnumerable<T>[] others)
        {
            return NonEmptyEnumerable.Create(e, others.Flatten());
        }

        public static INonEmptyEnumerable<T> Concat<T>(this INonEmptyEnumerable<T> source, params T[] items)
        {
            return source.Concat(items.AsEnumerable());
        }

        public static INonEmptyEnumerable<T> Concat<T>(this INonEmptyEnumerable<T> source, params IEnumerable<T>[] items)
        {
            return NonEmptyEnumerable.Create(source.Head, source.Tail.Concat(items));
        }

        #endregion NonEmpty

        #region Options

        /// <summary>
        /// Returns values of the nonempty options.
        /// </summary>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IOption<T>> source)
        {
            return source.SelectMany(o => o.ToList());
        }

        public static IOption<TValue> SafeMax<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector)
        {
            return source.AsNonEmpty().Map(s => s.Max(selector));
        }

        public static IOption<TValue> SafeMin<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector)
        {
            return source.AsNonEmpty().Map(s => s.Min(selector));
        }

        /// <summary>
        /// Returns first value or an empty option.
        /// </summary>
        public static IOption<T> FirstOption<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            var data = source.Where(predicate ?? (t => true)).Take(1).ToList();
            if (data.Count == 0)
            {
                return Option.Empty<T>();
            }
            return Option.Valued(data.First());
        }

        /// <summary>
        /// Returns last value or an empty option.
        /// </summary>
        public static IOption<T> LastOption<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            return source.Reverse().FirstOption(predicate);
        }

        /// <summary>
        /// Returns the only value if the source contains just one value, otherwise an empty option.
        /// </summary>
        public static IOption<T> SingleOption<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            var data = source.Where(predicate ?? (t => true)).Take(2).ToList();
            if (data.Count == 2)
            {
                return Option.Empty<T>();
            }
            return data.FirstOption();
        }

        #endregion Options

        #region DataCubes

        /// <summary>
        /// Converts the source to a new 1-dimensional data cube and aggregates the values in case of conflicting positions.
        /// </summary>
        public static DataCube1<P1, TResult> ToDataCube<T, P1, TValue, TResult>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, TValue> value,
            Func<TValue, TResult> initialization,
            Func<TResult, TValue, TResult> aggregation)
        {
            var dataCube = new DataCube1<P1, TResult>();
            foreach (var v in source)
            {
                dataCube.SetOrElseUpdate<TValue>(p1(v), value(v), initialization, aggregation);
            }
            return dataCube;
        }

        /// <summary>
        /// Converts the source to a new 2-dimensional data cube and aggregates the values in case of conflicting positions.
        /// </summary>
        public static DataCube2<P1, P2, TResult> ToDataCube<T, P1, P2, TValue, TResult>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, TValue> value,
            Func<TValue, TResult> initialization,
            Func<TResult, TValue, TResult> aggregation)
        {
            var dataCube = new DataCube2<P1, P2, TResult>();
            foreach (var v in source)
            {
                dataCube.SetOrElseUpdate<TValue>(p1(v), p2(v), value(v), initialization, aggregation);
            }
            return dataCube;
        }

        /// <summary>
        /// Converts the source to a new 3-dimensional data cube and aggregates the values in case of conflicting positions.
        /// </summary>
        public static DataCube3<P1, P2, P3, TResult> ToDataCube<T, P1, P2, P3, TValue, TResult>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, TValue> value,
            Func<TValue, TResult> initialization,
            Func<TResult, TValue, TResult> aggregation)
        {
            var dataCube = new DataCube3<P1, P2, P3, TResult>();
            foreach (var v in source)
            {
                dataCube.SetOrElseUpdate<TValue>(p1(v), p2(v), p3(v), value(v), initialization, aggregation);
            }
            return dataCube;
        }

        /// <summary>
        /// Converts the source to a new 4-dimensional data cube and aggregates the values in case of conflicting positions.
        /// </summary>
        public static DataCube4<P1, P2, P3, P4, TResult> ToDataCube<T, P1, P2, P3, P4, TValue, TResult>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, TValue> value,
            Func<TValue, TResult> initialization,
            Func<TResult, TValue, TResult> aggregation)
        {
            var dataCube = new DataCube4<P1, P2, P3, P4, TResult>();
            foreach (var v in source)
            {
                dataCube.SetOrElseUpdate<TValue>(p1(v), p2(v), p3(v), p4(v), value(v), initialization, aggregation);
            }
            return dataCube;
        }

        /// <summary>
        /// Converts the source to a new 5-dimensional data cube and aggregates the values in case of conflicting positions.
        /// </summary>
        public static DataCube5<P1, P2, P3, P4, P5, TResult> ToDataCube<T, P1, P2, P3, P4, P5, TValue, TResult>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, P5> p5,
            Func<T, TValue> value,
            Func<TValue, TResult> initialization,
            Func<TResult, TValue, TResult> aggregation)
        {
            var dataCube = new DataCube5<P1, P2, P3, P4, P5, TResult>();
            foreach (var v in source)
            {
                dataCube.SetOrElseUpdate<TValue>(p1(v), p2(v), p3(v), p4(v), p5(v), value(v), initialization, aggregation);
            }
            return dataCube;
        }

        /// <summary>
        /// Converts the source to a new 6-dimensional data cube and aggregates the values in case of conflicting positions.
        /// </summary>
        public static DataCube6<P1, P2, P3, P4, P5, P6, TResult> ToDataCube<T, P1, P2, P3, P4, P5, P6, TValue, TResult>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, P5> p5,
            Func<T, P6> p6,
            Func<T, TValue> value,
            Func<TValue, TResult> initialization,
            Func<TResult, TValue, TResult> aggregation)
        {
            var dataCube = new DataCube6<P1, P2, P3, P4, P5, P6, TResult>();
            foreach (var v in source)
            {
                dataCube.SetOrElseUpdate<TValue>(p1(v), p2(v), p3(v), p4(v), p5(v), p6(v), value(v), initialization, aggregation);
            }
            return dataCube;
        }


        /// <summary>
        /// Converts the source to a new 1-dimensional data cube.
        /// </summary>
        public static DataCube1<P1, TValue> ToDataCube<T, P1, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, TValue, TValue>(source, p1, value, a => a, aggregation: (a, b) => throw new ArgumentException("An item with the same key has already been added."));
        }

        /// <summary>
        /// Converts the source to a new 2-dimensional data cube.
        /// </summary>
        public static DataCube2<P1, P2, TValue> ToDataCube<T, P1, P2, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, TValue, TValue>(source, p1, p2, value, a => a, aggregation: (a, b) => throw new ArgumentException("An item with the same key has already been added."));
        }

        /// <summary>
        /// Converts the source to a new 3-dimensional data cube.
        /// </summary>
        public static DataCube3<P1, P2, P3, TValue> ToDataCube<T, P1, P2, P3, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, P3, TValue, TValue>(source, p1, p2, p3, value, a => a, aggregation: (a, b) => throw new ArgumentException("An item with the same key has already been added."));
        }

        /// <summary>
        /// Converts the source to a new 4-dimensional data cube.
        /// </summary>
        public static DataCube4<P1, P2, P3, P4, TValue> ToDataCube<T, P1, P2, P3, P4, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, P3, P4, TValue, TValue>(source, p1, p2, p3, p4, value, a => a, aggregation: (a, b) => throw new ArgumentException("An item with the same key has already been added."));
        }

        /// <summary>
        /// Converts the source to a new 5-dimensional data cube.
        /// </summary>
        public static DataCube5<P1, P2, P3, P4, P5, TValue> ToDataCube<T, P1, P2, P3, P4, P5, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, P5> p5,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, P3, P4, P5, TValue, TValue>(source, p1, p2, p3, p4, p5, value, a => a, aggregation: (a, b) => throw new ArgumentException("An item with the same key has already been added."));
        }

        /// <summary>
        /// Converts the source to a new 6-dimensional data cube.
        /// </summary>
        public static DataCube6<P1, P2, P3, P4, P5, P6, TValue> ToDataCube<T, P1, P2, P3, P4, P5, P6, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, P5> p5,
            Func<T, P6> p6,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, P3, P4, P5, P6, TValue, TValue>(source, p1, p2, p3, p4, p5, p6, value, a => a, aggregation: (a, b) => throw new ArgumentException("An item with the same key has already been added."));
        }

        /// <summary>
        /// Converts the source to a new 1-dimensional data cube, in case of collisions, it aggregates the values to a collection.
        /// </summary>
        public static DataCube1<P1, IEnumerable<TValue>> ToCollectionDataCube<T, P1, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, TValue, IEnumerable<TValue>>(source, p1, value, a => Enumerable.Repeat(a, 1), (a, b) => a.Concat(new [] { b }));
        }

        /// <summary>
        /// Converts the source to a new 2-dimensional data cube, in case of collisions, it aggregates the values to a collection.
        /// </summary>
        public static DataCube2<P1, P2, IEnumerable<TValue>> ToCollectionDataCube<T, P1, P2, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, TValue, IEnumerable<TValue>>(source, p1, p2, value, a => Enumerable.Repeat(a, 1), (a, b) => a.Concat(new [] { b }));
        }

        /// <summary>
        /// Converts the source to a new 3-dimensional data cube, in case of collisions, it aggregates the values to a collection.
        /// </summary>
        public static DataCube3<P1, P2, P3, IEnumerable<TValue>> ToCollectionDataCube<T, P1, P2, P3, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, P3, TValue, IEnumerable<TValue>>(source, p1, p2, p3, value, a => Enumerable.Repeat(a, 1), (a, b) => a.Concat(new [] { b }));
        }

        /// <summary>
        /// Converts the source to a new 4-dimensional data cube, in case of collisions, it aggregates the values to a collection.
        /// </summary>
        public static DataCube4<P1, P2, P3, P4, IEnumerable<TValue>> ToCollectionDataCube<T, P1, P2, P3, P4, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, P3, P4, TValue, IEnumerable<TValue>>(source, p1, p2, p3, p4, value, a => Enumerable.Repeat(a, 1), (a, b) => a.Concat(new [] { b }));
        }

        /// <summary>
        /// Converts the source to a new 5-dimensional data cube, in case of collisions, it aggregates the values to a collection.
        /// </summary>
        public static DataCube5<P1, P2, P3, P4, P5, IEnumerable<TValue>> ToCollectionDataCube<T, P1, P2, P3, P4, P5, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, P5> p5,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, P3, P4, P5, TValue, IEnumerable<TValue>>(source, p1, p2, p3, p4, p5, value, a => Enumerable.Repeat(a, 1), (a, b) => a.Concat(new [] { b }));
        }

        /// <summary>
        /// Converts the source to a new 6-dimensional data cube, in case of collisions, it aggregates the values to a collection.
        /// </summary>
        public static DataCube6<P1, P2, P3, P4, P5, P6, IEnumerable<TValue>> ToCollectionDataCube<T, P1, P2, P3, P4, P5, P6, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, P5> p5,
            Func<T, P6> p6,
            Func<T, TValue> value)
        {
            return ToDataCube<T, P1, P2, P3, P4, P5, P6, TValue, IEnumerable<TValue>>(source, p1, p2, p3, p4, p5, p6, value, a => Enumerable.Repeat(a, 1), (a, b) => a.Concat(new [] { b }));
        }

        #endregion DataCubes

        #region PartitionMatch


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

        #endregion PartitionMatch

    }
}