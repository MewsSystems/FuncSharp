
using System;
using System.Collections.Generic;

namespace FuncSharp
{
    public static partial class IEnumerableExtensions
    {

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function.
        /// </summary>
        public static void PartitionMatch<T1>(
            this IEnumerable<ICoproduct1<T1>> source,
            Action<INonEmptyEnumerable<T1>> f1)
        {
            var list1 = new List<T1>();

            foreach (var c in source)
            {
                c.Match(
                    c1 => list1.Add(c1)
                );
            }

            list1.AsNonEmpty().Match(f1);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, TResult>(
            this IEnumerable<ICoproduct1<T1>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, TResult>(
            this IEnumerable<ICoproduct2<T1, T2>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, TResult>(
            this IEnumerable<ICoproduct3<T1, T2, T3>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, TResult>(
            this IEnumerable<ICoproduct4<T1, T2, T3, T4>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, TResult>(
            this IEnumerable<ICoproduct5<T1, T2, T3, T4, T5>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, TResult>(
            this IEnumerable<ICoproduct6<T1, T2, T3, T4, T5, T6>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this IEnumerable<ICoproduct7<T1, T2, T3, T4, T5, T6, T7>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this IEnumerable<ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this IEnumerable<ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this IEnumerable<ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this IEnumerable<ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11,
            Action<INonEmptyEnumerable<T12>> f12)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
            list12.AsNonEmpty().Match(f12);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this IEnumerable<ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11,
            Func<INonEmptyEnumerable<T12>, IEnumerable<TResult>> f12)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11,
            Action<INonEmptyEnumerable<T12>> f12,
            Action<INonEmptyEnumerable<T13>> f13)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
            list12.AsNonEmpty().Match(f12);
            list13.AsNonEmpty().Match(f13);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this IEnumerable<ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11,
            Func<INonEmptyEnumerable<T12>, IEnumerable<TResult>> f12,
            Func<INonEmptyEnumerable<T13>, IEnumerable<TResult>> f13)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11,
            Action<INonEmptyEnumerable<T12>> f12,
            Action<INonEmptyEnumerable<T13>> f13,
            Action<INonEmptyEnumerable<T14>> f14)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
            list12.AsNonEmpty().Match(f12);
            list13.AsNonEmpty().Match(f13);
            list14.AsNonEmpty().Match(f14);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this IEnumerable<ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11,
            Func<INonEmptyEnumerable<T12>, IEnumerable<TResult>> f12,
            Func<INonEmptyEnumerable<T13>, IEnumerable<TResult>> f13,
            Func<INonEmptyEnumerable<T14>, IEnumerable<TResult>> f14)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11,
            Action<INonEmptyEnumerable<T12>> f12,
            Action<INonEmptyEnumerable<T13>> f13,
            Action<INonEmptyEnumerable<T14>> f14,
            Action<INonEmptyEnumerable<T15>> f15)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
            list12.AsNonEmpty().Match(f12);
            list13.AsNonEmpty().Match(f13);
            list14.AsNonEmpty().Match(f14);
            list15.AsNonEmpty().Match(f15);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this IEnumerable<ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11,
            Func<INonEmptyEnumerable<T12>, IEnumerable<TResult>> f12,
            Func<INonEmptyEnumerable<T13>, IEnumerable<TResult>> f13,
            Func<INonEmptyEnumerable<T14>, IEnumerable<TResult>> f14,
            Func<INonEmptyEnumerable<T15>, IEnumerable<TResult>> f15)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11,
            Action<INonEmptyEnumerable<T12>> f12,
            Action<INonEmptyEnumerable<T13>> f13,
            Action<INonEmptyEnumerable<T14>> f14,
            Action<INonEmptyEnumerable<T15>> f15,
            Action<INonEmptyEnumerable<T16>> f16)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
            list12.AsNonEmpty().Match(f12);
            list13.AsNonEmpty().Match(f13);
            list14.AsNonEmpty().Match(f14);
            list15.AsNonEmpty().Match(f15);
            list16.AsNonEmpty().Match(f16);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this IEnumerable<ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11,
            Func<INonEmptyEnumerable<T12>, IEnumerable<TResult>> f12,
            Func<INonEmptyEnumerable<T13>, IEnumerable<TResult>> f13,
            Func<INonEmptyEnumerable<T14>, IEnumerable<TResult>> f14,
            Func<INonEmptyEnumerable<T15>, IEnumerable<TResult>> f15,
            Func<INonEmptyEnumerable<T16>, IEnumerable<TResult>> f16)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11,
            Action<INonEmptyEnumerable<T12>> f12,
            Action<INonEmptyEnumerable<T13>> f13,
            Action<INonEmptyEnumerable<T14>> f14,
            Action<INonEmptyEnumerable<T15>> f15,
            Action<INonEmptyEnumerable<T16>> f16,
            Action<INonEmptyEnumerable<T17>> f17)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
            list12.AsNonEmpty().Match(f12);
            list13.AsNonEmpty().Match(f13);
            list14.AsNonEmpty().Match(f14);
            list15.AsNonEmpty().Match(f15);
            list16.AsNonEmpty().Match(f16);
            list17.AsNonEmpty().Match(f17);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TResult>(
            this IEnumerable<ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11,
            Func<INonEmptyEnumerable<T12>, IEnumerable<TResult>> f12,
            Func<INonEmptyEnumerable<T13>, IEnumerable<TResult>> f13,
            Func<INonEmptyEnumerable<T14>, IEnumerable<TResult>> f14,
            Func<INonEmptyEnumerable<T15>, IEnumerable<TResult>> f15,
            Func<INonEmptyEnumerable<T16>, IEnumerable<TResult>> f16,
            Func<INonEmptyEnumerable<T17>, IEnumerable<TResult>> f17)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11,
            Action<INonEmptyEnumerable<T12>> f12,
            Action<INonEmptyEnumerable<T13>> f13,
            Action<INonEmptyEnumerable<T14>> f14,
            Action<INonEmptyEnumerable<T15>> f15,
            Action<INonEmptyEnumerable<T16>> f16,
            Action<INonEmptyEnumerable<T17>> f17,
            Action<INonEmptyEnumerable<T18>> f18)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
            list12.AsNonEmpty().Match(f12);
            list13.AsNonEmpty().Match(f13);
            list14.AsNonEmpty().Match(f14);
            list15.AsNonEmpty().Match(f15);
            list16.AsNonEmpty().Match(f16);
            list17.AsNonEmpty().Match(f17);
            list18.AsNonEmpty().Match(f18);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TResult>(
            this IEnumerable<ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11,
            Func<INonEmptyEnumerable<T12>, IEnumerable<TResult>> f12,
            Func<INonEmptyEnumerable<T13>, IEnumerable<TResult>> f13,
            Func<INonEmptyEnumerable<T14>, IEnumerable<TResult>> f14,
            Func<INonEmptyEnumerable<T15>, IEnumerable<TResult>> f15,
            Func<INonEmptyEnumerable<T16>, IEnumerable<TResult>> f16,
            Func<INonEmptyEnumerable<T17>, IEnumerable<TResult>> f17,
            Func<INonEmptyEnumerable<T18>, IEnumerable<TResult>> f18)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11,
            Action<INonEmptyEnumerable<T12>> f12,
            Action<INonEmptyEnumerable<T13>> f13,
            Action<INonEmptyEnumerable<T14>> f14,
            Action<INonEmptyEnumerable<T15>> f15,
            Action<INonEmptyEnumerable<T16>> f16,
            Action<INonEmptyEnumerable<T17>> f17,
            Action<INonEmptyEnumerable<T18>> f18,
            Action<INonEmptyEnumerable<T19>> f19)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
            list12.AsNonEmpty().Match(f12);
            list13.AsNonEmpty().Match(f13);
            list14.AsNonEmpty().Match(f14);
            list15.AsNonEmpty().Match(f15);
            list16.AsNonEmpty().Match(f16);
            list17.AsNonEmpty().Match(f17);
            list18.AsNonEmpty().Match(f18);
            list19.AsNonEmpty().Match(f19);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TResult>(
            this IEnumerable<ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11,
            Func<INonEmptyEnumerable<T12>, IEnumerable<TResult>> f12,
            Func<INonEmptyEnumerable<T13>, IEnumerable<TResult>> f13,
            Func<INonEmptyEnumerable<T14>, IEnumerable<TResult>> f14,
            Func<INonEmptyEnumerable<T15>, IEnumerable<TResult>> f15,
            Func<INonEmptyEnumerable<T16>, IEnumerable<TResult>> f16,
            Func<INonEmptyEnumerable<T17>, IEnumerable<TResult>> f17,
            Func<INonEmptyEnumerable<T18>, IEnumerable<TResult>> f18,
            Func<INonEmptyEnumerable<T19>, IEnumerable<TResult>> f19)
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
            Action<INonEmptyEnumerable<T1>> f1,
            Action<INonEmptyEnumerable<T2>> f2,
            Action<INonEmptyEnumerable<T3>> f3,
            Action<INonEmptyEnumerable<T4>> f4,
            Action<INonEmptyEnumerable<T5>> f5,
            Action<INonEmptyEnumerable<T6>> f6,
            Action<INonEmptyEnumerable<T7>> f7,
            Action<INonEmptyEnumerable<T8>> f8,
            Action<INonEmptyEnumerable<T9>> f9,
            Action<INonEmptyEnumerable<T10>> f10,
            Action<INonEmptyEnumerable<T11>> f11,
            Action<INonEmptyEnumerable<T12>> f12,
            Action<INonEmptyEnumerable<T13>> f13,
            Action<INonEmptyEnumerable<T14>> f14,
            Action<INonEmptyEnumerable<T15>> f15,
            Action<INonEmptyEnumerable<T16>> f16,
            Action<INonEmptyEnumerable<T17>> f17,
            Action<INonEmptyEnumerable<T18>> f18,
            Action<INonEmptyEnumerable<T19>> f19,
            Action<INonEmptyEnumerable<T20>> f20)
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

            list1.AsNonEmpty().Match(f1);
            list2.AsNonEmpty().Match(f2);
            list3.AsNonEmpty().Match(f3);
            list4.AsNonEmpty().Match(f4);
            list5.AsNonEmpty().Match(f5);
            list6.AsNonEmpty().Match(f6);
            list7.AsNonEmpty().Match(f7);
            list8.AsNonEmpty().Match(f8);
            list9.AsNonEmpty().Match(f9);
            list10.AsNonEmpty().Match(f10);
            list11.AsNonEmpty().Match(f11);
            list12.AsNonEmpty().Match(f12);
            list13.AsNonEmpty().Match(f13);
            list14.AsNonEmpty().Match(f14);
            list15.AsNonEmpty().Match(f15);
            list16.AsNonEmpty().Match(f16);
            list17.AsNonEmpty().Match(f17);
            list18.AsNonEmpty().Match(f18);
            list19.AsNonEmpty().Match(f19);
            list20.AsNonEmpty().Match(f20);
        }

        /// <summary>
        /// For each partition (collection of n-th coproduct elements), invokes the specified function, aggregates results and returns them.
        /// </summary>
        public static IReadOnlyList<TResult> PartitionMatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TResult>(
            this IEnumerable<ICoproduct20<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>> source,
            Func<INonEmptyEnumerable<T1>, IEnumerable<TResult>> f1,
            Func<INonEmptyEnumerable<T2>, IEnumerable<TResult>> f2,
            Func<INonEmptyEnumerable<T3>, IEnumerable<TResult>> f3,
            Func<INonEmptyEnumerable<T4>, IEnumerable<TResult>> f4,
            Func<INonEmptyEnumerable<T5>, IEnumerable<TResult>> f5,
            Func<INonEmptyEnumerable<T6>, IEnumerable<TResult>> f6,
            Func<INonEmptyEnumerable<T7>, IEnumerable<TResult>> f7,
            Func<INonEmptyEnumerable<T8>, IEnumerable<TResult>> f8,
            Func<INonEmptyEnumerable<T9>, IEnumerable<TResult>> f9,
            Func<INonEmptyEnumerable<T10>, IEnumerable<TResult>> f10,
            Func<INonEmptyEnumerable<T11>, IEnumerable<TResult>> f11,
            Func<INonEmptyEnumerable<T12>, IEnumerable<TResult>> f12,
            Func<INonEmptyEnumerable<T13>, IEnumerable<TResult>> f13,
            Func<INonEmptyEnumerable<T14>, IEnumerable<TResult>> f14,
            Func<INonEmptyEnumerable<T15>, IEnumerable<TResult>> f15,
            Func<INonEmptyEnumerable<T16>, IEnumerable<TResult>> f16,
            Func<INonEmptyEnumerable<T17>, IEnumerable<TResult>> f17,
            Func<INonEmptyEnumerable<T18>, IEnumerable<TResult>> f18,
            Func<INonEmptyEnumerable<T19>, IEnumerable<TResult>> f19,
            Func<INonEmptyEnumerable<T20>, IEnumerable<TResult>> f20)
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
    }
}