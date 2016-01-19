using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class ITotalOrderingIntervalSetExtensions
    {
        /// <summary>
        /// Creates a new empty intervsal set.
        /// </summary>
        public static IntervalSet<A> EmptyIntervalSet<A>(this ITotalOrdering<A> ordering)
        {
            return new IntervalSet<A>(ordering, Enumerable.Empty<Interval<A>>());
        }

        /// <summary>
        /// Creates a new interval set consisting only of the specified interval.
        /// </summary>
        public static IntervalSet<A> IntervalSet<A>(this ITotalOrdering<A> ordering, Interval<A> interval)
        {
            return new IntervalSet<A>(ordering, new[] { interval });
        }

        /// <summary>
        /// Creates a new interval set from the specified collection of intervals.
        /// </summary>
        public static IntervalSet<A> IntervalSet<A>(this ITotalOrdering<A> ordering, IEnumerable<Interval<A>> intervals)
        {
            return intervals.Aggregate(ordering.EmptyIntervalSet(), (s, i) => ordering.Union(s, i));
        }

        /// <summary>
        /// Creates a new interval set from the specified collection of intervals.
        /// </summary>
        public static IntervalSet<A> IntervalSet<A>(this ITotalOrdering<A> ordering, params Interval<A>[] intervals)
        {
            return ordering.IntervalSet(intervals.AsEnumerable());
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

            var intersection = set1.Intervals.SelectMany(i => ordering.Intersect(set2.Intervals, i));
            return new IntervalSet<A>(ordering, intersection);
        }

        /// <summary>
        /// Returns intersection of the specified interval sets.
        /// </summary>
        public static IntervalSet<A> Intersect<A>(this ITotalOrdering<A> ordering, IEnumerable<IntervalSet<A>> sets)
        {
            return sets.Aggregate(ordering.EmptyIntervalSet(), (s1, s2) => ordering.Intersect(s1, s2));
        }

        /// <summary>
        /// Returns union of the two intervals.
        /// </summary>
        public static IntervalSet<A> Union<A>(this ITotalOrdering<A> ordering, Interval<A> interval1, Interval<A> interval2)
        {
            return ordering.Union(ordering.IntervalSet(interval1), interval2);
        }

        /// <summary>
        /// Returns union of the specified intervals.
        /// </summary>
        public static IntervalSet<A> Union<A>(this ITotalOrdering<A> ordering, IEnumerable<Interval<A>> intervals)
        {
            return ordering.IntervalSet(intervals);
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

            var union = set1.Intervals.Aggregate(set2.Intervals, (r, i) => ordering.Union(r, i));
            return new IntervalSet<A>(ordering, union);
        }

        /// <summary>
        /// Returns union of the specified interval sets.
        /// </summary>
        public static IntervalSet<A> Union<A>(this ITotalOrdering<A> ordering, IEnumerable<IntervalSet<A>> sets)
        {
            return sets.Aggregate(ordering.EmptyIntervalSet(), (s1, s2) => ordering.Union(s1, s2));
        }

        /// <summary>
        /// Returns the complementary interval set, i.e. interval set representing all values that are not in the 
        /// specified interval.
        /// </summary>
        public static IntervalSet<A> Complement<A>(this ITotalOrdering<A> ordering, Interval<A> interval)
        {
            if (interval.IsEmpty)
            {
                return ordering.IntervalSet(ordering.UnboundedInterval());
            }

            var lowerLimit = interval.LowerLimit;
            var upperLimit = interval.UpperLimit;
            var lowerComplement = lowerLimit.Bound.Map(b => ordering.Interval(upperLimit: IntervalLimit.Create(b, lowerLimit.IsClosed)));
            var upperComplement = upperLimit.Bound.Map(b => ordering.Interval(lowerLimit: IntervalLimit.Create(b, upperLimit.IsClosed)));

            return ordering.IntervalSet(lowerComplement.ToEnumerable().Concat(upperComplement.ToEnumerable()));
        }

        internal static void Check<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set, Func<Unit, Exception> otherwise)
        {
            if (!ordering.Equals(set.Ordering))
            {
                throw otherwise(Unit.Value);
            }
        }

        internal static void Check<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set, Interval<A> interval)
        {
            ordering.Check(set, _ => new ArgumentException("The interval set uses different ordering."));
            ordering.Check(interval, _ => new ArgumentException("The interval uses different ordering."));
        }

        internal static void Check<A>(this ITotalOrdering<A> ordering, IntervalSet<A> set1, IntervalSet<A> set2)
        {
            ordering.Check(set1, _ => new ArgumentException("The first interval set uses different ordering."));
            ordering.Check(set2, _ => new ArgumentException("The second interval set uses different ordering."));
        }

        private static IEnumerable<Interval<A>> Intersect<A>(this ITotalOrdering<A> ordering, IEnumerable<Interval<A>> intervals, Interval<A> interval)
        {
            return intervals.Select(i => ordering.Intersect(i, interval)).ToList();
        }

        private static IEnumerable<Interval<A>> Union<A>(this ITotalOrdering<A> ordering, IEnumerable<Interval<A>> intervals, Interval<A> interval)
        {
            // An interval should be merged together with another interval if either closure of the interval intersects the second
            // interval or if closure of the second interval intersects the first interval.
            var unionIntervals = intervals.Where(i =>
                ordering.Intersects(ordering.Closure(i), interval) ||
                ordering.Intersects(i, ordering.Closure(interval))
            ).ToList();
            var otherIntervals = intervals.Except(unionIntervals);

            // Create a union interval from the intersectced intervals and the target interval. The union interval will replace
            // the intersected intervals.
            var data = ordering.GetTraitData();
            var unionInterval = interval;
            if (unionIntervals.Any())
            {
                // Union with the intervals is the first 
                unionInterval = ordering.Interval(
                    data.LimitOrderings.LowerRestrictiveness.Min(interval.LowerLimit, unionIntervals.First().LowerLimit),
                    data.LimitOrderings.UpperRestrictiveness.Min(interval.UpperLimit, unionIntervals.Last().UpperLimit)
                );
            }

            return data.IntervalOrdering.Order(otherIntervals.Concat(new[] { unionInterval }));
        }
    }
}
