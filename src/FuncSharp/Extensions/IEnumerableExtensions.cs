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
        public static IOption<T> ToNonEmptyOption<T>(this T source)
            where T : IEnumerable
        {
            if (source == null || !source.OfType<object>().Any())
            {
                return Option.Empty<T>();
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
        /// Orders the values using the specified less function in the specified order.
        /// </summary>
        public static List<T> Order<T>(this IEnumerable<T> values, Func<T, T, bool> less, Ordering ordering = Ordering.Ascending)
        {
            var result = values.ToList();
            var comparer = new Comparer<T>(less, ordering);
            result.Sort(comparer);
            return result;
        }

        /// <summary>
        /// Aggregates the exceptions into an AggregateException. If there is a single exception, returns it directly.
        /// </summary>
        public static IOption<Exception> Aggregate(this IEnumerable<Exception> source)
        {
            return source.SingleOption().OrElse(_ => source.FirstOption().Map<Exception>(e => new AggregateException(source)));
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
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1>(
            this IEnumerable<ICoproduct1<T1>> source,
            Action<IEnumerable<T1>> f1)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2>(
            this IEnumerable<ICoproduct2<T1, T2>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3>(
            this IEnumerable<ICoproduct3<T1, T2, T3>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4>(
            this IEnumerable<ICoproduct4<T1, T2, T3, T4>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5>(
            this IEnumerable<ICoproduct5<T1, T2, T3, T4, T5>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6>(
            this IEnumerable<ICoproduct6<T1, T2, T3, T4, T5, T6>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7>(
            this IEnumerable<ICoproduct7<T1, T2, T3, T4, T5, T6, T7>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8>(
            this IEnumerable<ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this IEnumerable<ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this IEnumerable<ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this IEnumerable<ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this IEnumerable<ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11,
            Action<IEnumerable<T12>> f12)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
            f12(source.Select(c => c.Twelfth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this IEnumerable<ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11,
            Action<IEnumerable<T12>> f12,
            Action<IEnumerable<T13>> f13)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
            f12(source.Select(c => c.Twelfth).Flatten().ToList());
            f13(source.Select(c => c.Thirteenth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this IEnumerable<ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11,
            Action<IEnumerable<T12>> f12,
            Action<IEnumerable<T13>> f13,
            Action<IEnumerable<T14>> f14)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
            f12(source.Select(c => c.Twelfth).Flatten().ToList());
            f13(source.Select(c => c.Thirteenth).Flatten().ToList());
            f14(source.Select(c => c.Fourteenth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this IEnumerable<ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11,
            Action<IEnumerable<T12>> f12,
            Action<IEnumerable<T13>> f13,
            Action<IEnumerable<T14>> f14,
            Action<IEnumerable<T15>> f15)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
            f12(source.Select(c => c.Twelfth).Flatten().ToList());
            f13(source.Select(c => c.Thirteenth).Flatten().ToList());
            f14(source.Select(c => c.Fourteenth).Flatten().ToList());
            f15(source.Select(c => c.Fifteenth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this IEnumerable<ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11,
            Action<IEnumerable<T12>> f12,
            Action<IEnumerable<T13>> f13,
            Action<IEnumerable<T14>> f14,
            Action<IEnumerable<T15>> f15,
            Action<IEnumerable<T16>> f16)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
            f12(source.Select(c => c.Twelfth).Flatten().ToList());
            f13(source.Select(c => c.Thirteenth).Flatten().ToList());
            f14(source.Select(c => c.Fourteenth).Flatten().ToList());
            f15(source.Select(c => c.Fifteenth).Flatten().ToList());
            f16(source.Select(c => c.Sixteenth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
            this IEnumerable<ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11,
            Action<IEnumerable<T12>> f12,
            Action<IEnumerable<T13>> f13,
            Action<IEnumerable<T14>> f14,
            Action<IEnumerable<T15>> f15,
            Action<IEnumerable<T16>> f16,
            Action<IEnumerable<T17>> f17)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
            f12(source.Select(c => c.Twelfth).Flatten().ToList());
            f13(source.Select(c => c.Thirteenth).Flatten().ToList());
            f14(source.Select(c => c.Fourteenth).Flatten().ToList());
            f15(source.Select(c => c.Fifteenth).Flatten().ToList());
            f16(source.Select(c => c.Sixteenth).Flatten().ToList());
            f17(source.Select(c => c.Seventeenth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
            this IEnumerable<ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11,
            Action<IEnumerable<T12>> f12,
            Action<IEnumerable<T13>> f13,
            Action<IEnumerable<T14>> f14,
            Action<IEnumerable<T15>> f15,
            Action<IEnumerable<T16>> f16,
            Action<IEnumerable<T17>> f17,
            Action<IEnumerable<T18>> f18)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
            f12(source.Select(c => c.Twelfth).Flatten().ToList());
            f13(source.Select(c => c.Thirteenth).Flatten().ToList());
            f14(source.Select(c => c.Fourteenth).Flatten().ToList());
            f15(source.Select(c => c.Fifteenth).Flatten().ToList());
            f16(source.Select(c => c.Sixteenth).Flatten().ToList());
            f17(source.Select(c => c.Seventeenth).Flatten().ToList());
            f18(source.Select(c => c.Eighteenth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
            this IEnumerable<ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11,
            Action<IEnumerable<T12>> f12,
            Action<IEnumerable<T13>> f13,
            Action<IEnumerable<T14>> f14,
            Action<IEnumerable<T15>> f15,
            Action<IEnumerable<T16>> f16,
            Action<IEnumerable<T17>> f17,
            Action<IEnumerable<T18>> f18,
            Action<IEnumerable<T19>> f19)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
            f12(source.Select(c => c.Twelfth).Flatten().ToList());
            f13(source.Select(c => c.Thirteenth).Flatten().ToList());
            f14(source.Select(c => c.Fourteenth).Flatten().ToList());
            f15(source.Select(c => c.Fifteenth).Flatten().ToList());
            f16(source.Select(c => c.Sixteenth).Flatten().ToList());
            f17(source.Select(c => c.Seventeenth).Flatten().ToList());
            f18(source.Select(c => c.Eighteenth).Flatten().ToList());
            f19(source.Select(c => c.Nineteenth).Flatten().ToList());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
            this IEnumerable<ICoproduct20<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2,
            Action<IEnumerable<T3>> f3,
            Action<IEnumerable<T4>> f4,
            Action<IEnumerable<T5>> f5,
            Action<IEnumerable<T6>> f6,
            Action<IEnumerable<T7>> f7,
            Action<IEnumerable<T8>> f8,
            Action<IEnumerable<T9>> f9,
            Action<IEnumerable<T10>> f10,
            Action<IEnumerable<T11>> f11,
            Action<IEnumerable<T12>> f12,
            Action<IEnumerable<T13>> f13,
            Action<IEnumerable<T14>> f14,
            Action<IEnumerable<T15>> f15,
            Action<IEnumerable<T16>> f16,
            Action<IEnumerable<T17>> f17,
            Action<IEnumerable<T18>> f18,
            Action<IEnumerable<T19>> f19,
            Action<IEnumerable<T20>> f20)
        {
            f1(source.Select(c => c.First).Flatten().ToList());
            f2(source.Select(c => c.Second).Flatten().ToList());
            f3(source.Select(c => c.Third).Flatten().ToList());
            f4(source.Select(c => c.Fourth).Flatten().ToList());
            f5(source.Select(c => c.Fifth).Flatten().ToList());
            f6(source.Select(c => c.Sixth).Flatten().ToList());
            f7(source.Select(c => c.Seventh).Flatten().ToList());
            f8(source.Select(c => c.Eighth).Flatten().ToList());
            f9(source.Select(c => c.Ninth).Flatten().ToList());
            f10(source.Select(c => c.Tenth).Flatten().ToList());
            f11(source.Select(c => c.Eleventh).Flatten().ToList());
            f12(source.Select(c => c.Twelfth).Flatten().ToList());
            f13(source.Select(c => c.Thirteenth).Flatten().ToList());
            f14(source.Select(c => c.Fourteenth).Flatten().ToList());
            f15(source.Select(c => c.Fifteenth).Flatten().ToList());
            f16(source.Select(c => c.Sixteenth).Flatten().ToList());
            f17(source.Select(c => c.Seventeenth).Flatten().ToList());
            f18(source.Select(c => c.Eighteenth).Flatten().ToList());
            f19(source.Select(c => c.Nineteenth).Flatten().ToList());
            f20(source.Select(c => c.Twentieth).Flatten().ToList());
        }
    }
}