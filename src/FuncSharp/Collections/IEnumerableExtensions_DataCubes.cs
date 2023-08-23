
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static partial class IEnumerableExtensions
    {

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
    }
}