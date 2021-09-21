
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1, T2>(
            this IEnumerable<ICoproduct2<T1, T2>> source,
            Action<IEnumerable<T1>> f1,
            Action<IEnumerable<T2>> f2)
        {
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
            f12(evaluatedSource.Select(c => c.Twelfth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
            f12(evaluatedSource.Select(c => c.Twelfth).Flatten());
            f13(evaluatedSource.Select(c => c.Thirteenth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
            f12(evaluatedSource.Select(c => c.Twelfth).Flatten());
            f13(evaluatedSource.Select(c => c.Thirteenth).Flatten());
            f14(evaluatedSource.Select(c => c.Fourteenth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
            f12(evaluatedSource.Select(c => c.Twelfth).Flatten());
            f13(evaluatedSource.Select(c => c.Thirteenth).Flatten());
            f14(evaluatedSource.Select(c => c.Fourteenth).Flatten());
            f15(evaluatedSource.Select(c => c.Fifteenth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
            f12(evaluatedSource.Select(c => c.Twelfth).Flatten());
            f13(evaluatedSource.Select(c => c.Thirteenth).Flatten());
            f14(evaluatedSource.Select(c => c.Fourteenth).Flatten());
            f15(evaluatedSource.Select(c => c.Fifteenth).Flatten());
            f16(evaluatedSource.Select(c => c.Sixteenth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
            f12(evaluatedSource.Select(c => c.Twelfth).Flatten());
            f13(evaluatedSource.Select(c => c.Thirteenth).Flatten());
            f14(evaluatedSource.Select(c => c.Fourteenth).Flatten());
            f15(evaluatedSource.Select(c => c.Fifteenth).Flatten());
            f16(evaluatedSource.Select(c => c.Sixteenth).Flatten());
            f17(evaluatedSource.Select(c => c.Seventeenth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
            f12(evaluatedSource.Select(c => c.Twelfth).Flatten());
            f13(evaluatedSource.Select(c => c.Thirteenth).Flatten());
            f14(evaluatedSource.Select(c => c.Fourteenth).Flatten());
            f15(evaluatedSource.Select(c => c.Fifteenth).Flatten());
            f16(evaluatedSource.Select(c => c.Sixteenth).Flatten());
            f17(evaluatedSource.Select(c => c.Seventeenth).Flatten());
            f18(evaluatedSource.Select(c => c.Eighteenth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
            f12(evaluatedSource.Select(c => c.Twelfth).Flatten());
            f13(evaluatedSource.Select(c => c.Thirteenth).Flatten());
            f14(evaluatedSource.Select(c => c.Fourteenth).Flatten());
            f15(evaluatedSource.Select(c => c.Fifteenth).Flatten());
            f16(evaluatedSource.Select(c => c.Sixteenth).Flatten());
            f17(evaluatedSource.Select(c => c.Seventeenth).Flatten());
            f18(evaluatedSource.Select(c => c.Eighteenth).Flatten());
            f19(evaluatedSource.Select(c => c.Nineteenth).Flatten());
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
            var evaluatedSource = source.ToList();
            f1(evaluatedSource.Select(c => c.First).Flatten());
            f2(evaluatedSource.Select(c => c.Second).Flatten());
            f3(evaluatedSource.Select(c => c.Third).Flatten());
            f4(evaluatedSource.Select(c => c.Fourth).Flatten());
            f5(evaluatedSource.Select(c => c.Fifth).Flatten());
            f6(evaluatedSource.Select(c => c.Sixth).Flatten());
            f7(evaluatedSource.Select(c => c.Seventh).Flatten());
            f8(evaluatedSource.Select(c => c.Eighth).Flatten());
            f9(evaluatedSource.Select(c => c.Ninth).Flatten());
            f10(evaluatedSource.Select(c => c.Tenth).Flatten());
            f11(evaluatedSource.Select(c => c.Eleventh).Flatten());
            f12(evaluatedSource.Select(c => c.Twelfth).Flatten());
            f13(evaluatedSource.Select(c => c.Thirteenth).Flatten());
            f14(evaluatedSource.Select(c => c.Fourteenth).Flatten());
            f15(evaluatedSource.Select(c => c.Fifteenth).Flatten());
            f16(evaluatedSource.Select(c => c.Sixteenth).Flatten());
            f17(evaluatedSource.Select(c => c.Seventeenth).Flatten());
            f18(evaluatedSource.Select(c => c.Eighteenth).Flatten());
            f19(evaluatedSource.Select(c => c.Nineteenth).Flatten());
            f20(evaluatedSource.Select(c => c.Twentieth).Flatten());
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, TResult>(
            this IEnumerable<ICoproduct1<T1>> source,
            Func<T1, TResult> f1)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, TResult>(
            this IEnumerable<ICoproduct2<T1, T2>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, TResult>(
            this IEnumerable<ICoproduct3<T1, T2, T3>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, TResult>(
            this IEnumerable<ICoproduct4<T1, T2, T3, T4>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, TResult>(
            this IEnumerable<ICoproduct5<T1, T2, T3, T4, T5>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, TResult>(
            this IEnumerable<ICoproduct6<T1, T2, T3, T4, T5, T6>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this IEnumerable<ICoproduct7<T1, T2, T3, T4, T5, T6, T7>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this IEnumerable<ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this IEnumerable<ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this IEnumerable<ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this IEnumerable<ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this IEnumerable<ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11,
            Func<T12, TResult> f12)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c))),
                c12 => result.AddRange(c12.Select(c => f12(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this IEnumerable<ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11,
            Func<T12, TResult> f12,
            Func<T13, TResult> f13)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c))),
                c12 => result.AddRange(c12.Select(c => f12(c))),
                c13 => result.AddRange(c13.Select(c => f13(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this IEnumerable<ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11,
            Func<T12, TResult> f12,
            Func<T13, TResult> f13,
            Func<T14, TResult> f14)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c))),
                c12 => result.AddRange(c12.Select(c => f12(c))),
                c13 => result.AddRange(c13.Select(c => f13(c))),
                c14 => result.AddRange(c14.Select(c => f14(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this IEnumerable<ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11,
            Func<T12, TResult> f12,
            Func<T13, TResult> f13,
            Func<T14, TResult> f14,
            Func<T15, TResult> f15)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c))),
                c12 => result.AddRange(c12.Select(c => f12(c))),
                c13 => result.AddRange(c13.Select(c => f13(c))),
                c14 => result.AddRange(c14.Select(c => f14(c))),
                c15 => result.AddRange(c15.Select(c => f15(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this IEnumerable<ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11,
            Func<T12, TResult> f12,
            Func<T13, TResult> f13,
            Func<T14, TResult> f14,
            Func<T15, TResult> f15,
            Func<T16, TResult> f16)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c))),
                c12 => result.AddRange(c12.Select(c => f12(c))),
                c13 => result.AddRange(c13.Select(c => f13(c))),
                c14 => result.AddRange(c14.Select(c => f14(c))),
                c15 => result.AddRange(c15.Select(c => f15(c))),
                c16 => result.AddRange(c16.Select(c => f16(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult>(
            this IEnumerable<ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11,
            Func<T12, TResult> f12,
            Func<T13, TResult> f13,
            Func<T14, TResult> f14,
            Func<T15, TResult> f15,
            Func<T16, TResult> f16,
            Func<T17, TResult> f17)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c))),
                c12 => result.AddRange(c12.Select(c => f12(c))),
                c13 => result.AddRange(c13.Select(c => f13(c))),
                c14 => result.AddRange(c14.Select(c => f14(c))),
                c15 => result.AddRange(c15.Select(c => f15(c))),
                c16 => result.AddRange(c16.Select(c => f16(c))),
                c17 => result.AddRange(c17.Select(c => f17(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TResult>(
            this IEnumerable<ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11,
            Func<T12, TResult> f12,
            Func<T13, TResult> f13,
            Func<T14, TResult> f14,
            Func<T15, TResult> f15,
            Func<T16, TResult> f16,
            Func<T17, TResult> f17,
            Func<T18, TResult> f18)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c))),
                c12 => result.AddRange(c12.Select(c => f12(c))),
                c13 => result.AddRange(c13.Select(c => f13(c))),
                c14 => result.AddRange(c14.Select(c => f14(c))),
                c15 => result.AddRange(c15.Select(c => f15(c))),
                c16 => result.AddRange(c16.Select(c => f16(c))),
                c17 => result.AddRange(c17.Select(c => f17(c))),
                c18 => result.AddRange(c18.Select(c => f18(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TResult>(
            this IEnumerable<ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11,
            Func<T12, TResult> f12,
            Func<T13, TResult> f13,
            Func<T14, TResult> f14,
            Func<T15, TResult> f15,
            Func<T16, TResult> f16,
            Func<T17, TResult> f17,
            Func<T18, TResult> f18,
            Func<T19, TResult> f19)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c))),
                c12 => result.AddRange(c12.Select(c => f12(c))),
                c13 => result.AddRange(c13.Select(c => f13(c))),
                c14 => result.AddRange(c14.Select(c => f14(c))),
                c15 => result.AddRange(c15.Select(c => f15(c))),
                c16 => result.AddRange(c16.Select(c => f16(c))),
                c17 => result.AddRange(c17.Select(c => f17(c))),
                c18 => result.AddRange(c18.Select(c => f18(c))),
                c19 => result.AddRange(c19.Select(c => f19(c)))
            );
            return result;
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IEnumerable<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TResult>(
            this IEnumerable<ICoproduct20<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>> source,
            Func<T1, TResult> f1,
            Func<T2, TResult> f2,
            Func<T3, TResult> f3,
            Func<T4, TResult> f4,
            Func<T5, TResult> f5,
            Func<T6, TResult> f6,
            Func<T7, TResult> f7,
            Func<T8, TResult> f8,
            Func<T9, TResult> f9,
            Func<T10, TResult> f10,
            Func<T11, TResult> f11,
            Func<T12, TResult> f12,
            Func<T13, TResult> f13,
            Func<T14, TResult> f14,
            Func<T15, TResult> f15,
            Func<T16, TResult> f16,
            Func<T17, TResult> f17,
            Func<T18, TResult> f18,
            Func<T19, TResult> f19,
            Func<T20, TResult> f20)
        {
            var result = new List<TResult>();
            source.PartitionMatch(
                c1 => result.AddRange(c1.Select(c => f1(c))),
                c2 => result.AddRange(c2.Select(c => f2(c))),
                c3 => result.AddRange(c3.Select(c => f3(c))),
                c4 => result.AddRange(c4.Select(c => f4(c))),
                c5 => result.AddRange(c5.Select(c => f5(c))),
                c6 => result.AddRange(c6.Select(c => f6(c))),
                c7 => result.AddRange(c7.Select(c => f7(c))),
                c8 => result.AddRange(c8.Select(c => f8(c))),
                c9 => result.AddRange(c9.Select(c => f9(c))),
                c10 => result.AddRange(c10.Select(c => f10(c))),
                c11 => result.AddRange(c11.Select(c => f11(c))),
                c12 => result.AddRange(c12.Select(c => f12(c))),
                c13 => result.AddRange(c13.Select(c => f13(c))),
                c14 => result.AddRange(c14.Select(c => f14(c))),
                c15 => result.AddRange(c15.Select(c => f15(c))),
                c16 => result.AddRange(c16.Select(c => f16(c))),
                c17 => result.AddRange(c17.Select(c => f17(c))),
                c18 => result.AddRange(c18.Select(c => f18(c))),
                c19 => result.AddRange(c19.Select(c => f19(c))),
                c20 => result.AddRange(c20.Select(c => f20(c)))
            );
            return result;
        }
    }
}