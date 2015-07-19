using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class ITotalOrderingIntervalSetExtensions
    {
        /// <summary>
        /// Creates a new interval set consisting only of the specified interval.
        /// </summary>
        public static IntervalSet<A> IntervalSet<A>(this ITotalOrdering<A> ordering, Interval<A> interval)
        {
            return new IntervalSet<A>(ordering, new[] { interval });
        }

        /// <summary>
        /// Returns whether the interval set contains the specified value.
        /// </summary>
        public static bool Contains<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set, A value)
        {
            return ordering.Contains(set, ordering.SingleValueInterval(value));
        }

        /// <summary>
        /// Returns whether the interval set contains the specified interval.
        /// </summary>
        public static bool Contains<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set, Interval<A> interval)
        {
            return ordering.Contains(set, ordering.IntervalSet(interval));
        }

        /// <summary>
        /// Returns whether the first interval set contains the second interval set.
        /// </summary>
        public static bool Contains<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set1, IntervalSet<A> set2)
        {
            ordering.Check(set1, set2);

            return ordering.Intersect(set1, set2).Equals(set2);
        }

        /// <summary>
        /// Returns intersection of the interval set and the specified interval.
        /// </summary>
        public static IntervalSet<A> Intersect<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set, Interval<A> interval)
        {
            return ordering.Intersect(set, ordering.IntervalSet(interval));
        }

        /// <summary>
        /// Returns intersection of the two interval sets.
        /// </summary>
        public static IntervalSet<A> Intersect<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set1, IntervalSet<A> set2)
        {
            ordering.Check(set1, set2);

            return ordering.IntervalSet(set1.Intervals.SelectMany(i => ordering.Intersect(set2.Intervals, i)));
        }

        /// <summary>
        /// Returns union of the two intervals.
        /// </summary>
        public static IntervalSet<A> Union<A>(this ITotalOrdering<A> ordering, Interval<A> interval1, Interval<A> interval2)
        {
            return ordering.Union(ordering.IntervalSet(interval1), interval2);
        }

        /// <summary>
        /// Returns union of the interval set and the specified interval.
        /// </summary>
        public static IntervalSet<A> Union<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set, Interval<A> interval)
        {
            return ordering.Union(set, ordering.IntervalSet(interval));
        }

        /// <summary>
        /// Returns union of the two interval sets.
        /// </summary>
        public static IntervalSet<A> Union<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set1, IntervalSet<A> set2)
        {
            ordering.Check(set1, set2);

            return ordering.IntervalSet(set1.Intervals.Aggregate(set2.Intervals, (r, i) => ordering.Union(r, i)));
        }

        internal static void Check<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set, Func<Exception> exceptionCreator)
        {
            if (!ordering.Equals(set.Ordering))
            {
                throw exceptionCreator();
            }
        }

        internal static void Check<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set, Interval<A> interval)
        {
            ordering.Check(set, () => new ArgumentException("The interval set uses different ordering."));
            ordering.Check(interval, () => new ArgumentException("The interval uses different ordering."));
        }

        internal static void Check<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set1, IntervalSet<A> set2)
        {
            ordering.Check(set1, () => new ArgumentException("The first interval set uses different ordering."));
            ordering.Check(set2, () => new ArgumentException("The second interval set uses different ordering."));
        }

        private static IntervalSet<A> IntervalSet<A>(this ITotalOrdering<A> ordering, IEnumerable<Interval<A>> disjointIntervals)
        {
            return new IntervalSet<A>(ordering, disjointIntervals);
        }

        private static IEnumerable<Interval<A>> Intersect<A>(this ITotalOrdering<A> ordering, IEnumerable<Interval<A>> intervals, Interval<A> interval)
        {
            return intervals.Select(i => ordering.Intersect(i, interval)).ToList();
        }

        private static IEnumerable<Interval<A>> Union<A>(this ITotalOrdering<A> ordering, IEnumerable<Interval<A>> intervals, Interval<A> interval)
        {
            var intersectedIntervals = intervals.Where(i => ordering.Intersects(i, interval)).ToList();
            var otherIntervals = intervals.Except(intersectedIntervals);

            // Create a union interval from the intersectced intervals and the target interval. The union interval will replace
            // the intersected intervals.
            var data = ordering.GetTraitData();
            var unionInterval = interval;
            if (intersectedIntervals.Any())
            {
                // Union with the intervals is the first 
                unionInterval = ordering.Interval(
                    data.LimitOrderings.LowerRestrictiveness.Min(interval.LowerLimit, intersectedIntervals.First().LowerLimit),
                    data.LimitOrderings.UpperRestrictiveness.Min(interval.UpperLimit, intersectedIntervals.Last().UpperLimit)
                );
            }

            return data.IntervalOrdering.Order(otherIntervals.Concat(new[] { unionInterval }));
        }
    }
}
