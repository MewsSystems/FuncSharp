using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Returns values of the nonempty options.
        /// </summary>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IOption<T>> source)
        {
            return source.SelectMany(o => o.ToEnumerable());
        }

        /// <summary>
        /// Returns the specified collection as an option in case it is nonempty. Otherwise returns empty option.
        /// </summary>
        public static IOption<IEnumerable<T>> ToNonEmptyOption<T>(this IEnumerable<T> source)
            where T : IEnumerable
        {
            if (source == null || !source.Any())
            {
                return Option.Empty<IEnumerable<T>>();
            }
            return source.ToOption();
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

        /// <summary>
        /// Coverts the source to a new 1-dimensional data cube.
        /// </summary>
        public static DataCube1<P1, TValue> ToDataCube<T, P1, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, TValue> value)
        {
            return DataCube.Create(source, p1, value);
        }

        /// <summary>
        /// Transposes a collection of coproducts to product of collections.
        /// </summary>
        public static IProduct1<IEnumerable<T1>> Transpose<T1>(this IEnumerable<ICoproduct1<T1>> source)
        {
            return Product1.Create(
              source.Select(c => c.First).Flatten().ToList().AsEnumerable()
            );
        }

        /// <summary>
        /// Coverts the source to a new 2-dimensional data cube.
        /// </summary>
        public static DataCube2<P1, P2, TValue> ToDataCube<T, P1, P2, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, TValue> value)
        {
            return DataCube.Create(source, p1, p2, value);
        }

        /// <summary>
        /// Transposes a collection of coproducts to product of collections.
        /// </summary>
        public static IProduct2<IEnumerable<T1>, IEnumerable<T2>> Transpose<T1, T2>(this IEnumerable<ICoproduct2<T1, T2>> source)
        {
            return Product2.Create(
              source.Select(c => c.First).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Second).Flatten().ToList().AsEnumerable()
            );
        }

        /// <summary>
        /// Coverts the source to a new 3-dimensional data cube.
        /// </summary>
        public static DataCube3<P1, P2, P3, TValue> ToDataCube<T, P1, P2, P3, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, TValue> value)
        {
            return DataCube.Create(source, p1, p2, p3, value);
        }

        /// <summary>
        /// Transposes a collection of coproducts to product of collections.
        /// </summary>
        public static IProduct3<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> Transpose<T1, T2, T3>(this IEnumerable<ICoproduct3<T1, T2, T3>> source)
        {
            return Product3.Create(
              source.Select(c => c.First).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Second).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Third).Flatten().ToList().AsEnumerable()
            );
        }

        /// <summary>
        /// Coverts the source to a new 4-dimensional data cube.
        /// </summary>
        public static DataCube4<P1, P2, P3, P4, TValue> ToDataCube<T, P1, P2, P3, P4, TValue>(
            this IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, TValue> value)
        {
            return DataCube.Create(source, p1, p2, p3, p4, value);
        }

        /// <summary>
        /// Transposes a collection of coproducts to product of collections.
        /// </summary>
        public static IProduct4<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> Transpose<T1, T2, T3, T4>(this IEnumerable<ICoproduct4<T1, T2, T3, T4>> source)
        {
            return Product4.Create(
              source.Select(c => c.First).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Second).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Third).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Fourth).Flatten().ToList().AsEnumerable()
            );
        }

        /// <summary>
        /// Coverts the source to a new 5-dimensional data cube.
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
            return DataCube.Create(source, p1, p2, p3, p4, p5, value);
        }

        /// <summary>
        /// Transposes a collection of coproducts to product of collections.
        /// </summary>
        public static IProduct5<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> Transpose<T1, T2, T3, T4, T5>(this IEnumerable<ICoproduct5<T1, T2, T3, T4, T5>> source)
        {
            return Product5.Create(
              source.Select(c => c.First).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Second).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Third).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Fourth).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Fifth).Flatten().ToList().AsEnumerable()
            );
        }

        /// <summary>
        /// Coverts the source to a new 6-dimensional data cube.
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
            return DataCube.Create(source, p1, p2, p3, p4, p5, p6, value);
        }

        /// <summary>
        /// Transposes a collection of coproducts to product of collections.
        /// </summary>
        public static IProduct6<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>> Transpose<T1, T2, T3, T4, T5, T6>(this IEnumerable<ICoproduct6<T1, T2, T3, T4, T5, T6>> source)
        {
            return Product6.Create(
              source.Select(c => c.First).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Second).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Third).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Fourth).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Fifth).Flatten().ToList().AsEnumerable(),
              source.Select(c => c.Sixth).Flatten().ToList().AsEnumerable()
            );
        }
    }
}