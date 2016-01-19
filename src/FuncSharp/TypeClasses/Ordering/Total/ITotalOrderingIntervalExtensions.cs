using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class ITotalOrderingIntervalExtensions
    {
        /// <summary>
        /// Creates a new interval with the specified limits.
        /// </summary>
        public static Interval<A> Interval<A>(this ITotalOrdering<A> ordering, IntervalLimit<A> lowerLimit = null, IntervalLimit<A> upperLimit = null)
        {
            return new Interval<A>(ordering, lowerLimit ?? IntervalLimit.Unbounded<A>(), upperLimit ?? IntervalLimit.Unbounded<A>());
        }

        /// <summary>
        /// Creates a new empty interval represented as (a, a).
        /// </summary>
        public static Interval<A> EmptyInterval<A>(this ITotalOrdering<A> ordering, A a)
        {
            var bound = IntervalLimit.Open(a);
            return ordering.Interval(bound, bound);
        }

        /// <summary>
        /// Creates a new empty interval.
        /// </summary>
        public static Interval<A> EmptyInterval<A>(this ITotalOrdering<A> ordering)
            where A : new()
        {
            return ordering.EmptyInterval(new A());
        }

        /// <summary>
        /// Creates a new degenerate interval that consists of just one value.
        /// </summary>
        public static Interval<A> SingleValueInterval<A>(this ITotalOrdering<A> ordering, A value)
        {
            var bound = IntervalLimit.Closed(value);
            return ordering.Interval(bound, bound);
        }

        /// <summary>
        /// Creates a bounded open interval with the specified bounds.
        /// </summary>
        public static Interval<A> OpenInterval<A>(this ITotalOrdering<A> ordering, A lowerBound, A upperBound)
        {
            return ordering.Interval(IntervalLimit.Open(lowerBound), IntervalLimit.Open(upperBound));
        }

        /// <summary>
        /// Creates a bounded interval with closed lower bound and open upper bound.
        /// </summary>
        public static Interval<A> ClosedOpenInterval<A>(this ITotalOrdering<A> ordering, A lowerBound, A upperBound)
        {
            return ordering.Interval(IntervalLimit.Closed(lowerBound), IntervalLimit.Open(upperBound));
        }

        /// <summary>
        /// Creates a bounded interval with open lower bound and closed upper bound.
        /// </summary>
        public static Interval<A> OpenClosedInterval<A>(this ITotalOrdering<A> ordering, A lowerBound, A upperBound)
        {
            return ordering.Interval(IntervalLimit.Open(lowerBound), IntervalLimit.Closed(upperBound));
        }

        /// <summary>
        /// Creates a bounded closed interval with the specified bounds.
        /// </summary>
        public static Interval<A> ClosedInterval<A>(this ITotalOrdering<A> ordering, A lowerBound, A upperBound)
        {
            return ordering.Interval(IntervalLimit.Closed(lowerBound), IntervalLimit.Closed(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval with open lower bound.
        /// </summary>
        public static Interval<A> OpenUnboundedInterval<A>(this ITotalOrdering<A> ordering, A lowerBound)
        {
            return ordering.Interval(lowerLimit: IntervalLimit.Open(lowerBound));
        }

        /// <summary>
        /// Creates an unbounded interval with closed lower bound.
        /// </summary>
        public static Interval<A> ClosedUnboundedInterval<A>(this ITotalOrdering<A> ordering, A lowerBound)
        {
            return ordering.Interval(lowerLimit: IntervalLimit.Closed(lowerBound));
        }

        /// <summary>
        /// Creates an unbounded interval with open upper bound.
        /// </summary>
        public static Interval<A> UnboundedOpenInterval<A>(this ITotalOrdering<A> ordering, A upperBound)
        {
            return ordering.Interval(upperLimit: IntervalLimit.Open(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval with closed upper bound.
        /// </summary>
        public static Interval<A> UnboundedClosedInterval<A>(this ITotalOrdering<A> ordering, A upperBound)
        {
            return ordering.Interval(upperLimit: IntervalLimit.Closed(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval consisting of all values.
        /// </summary>
        public static Interval<A> UnboundedInterval<A>(this ITotalOrdering<A> ordering)
        {
            return ordering.Interval();
        }

        /// <summary>
        /// Returns whether the interval contains the specified value.
        /// </summary>
        public static bool Contains<A>(this ITotalOrdering<A> ordering, Interval<A> interval, A value)
        {
            return ordering.Contains(interval, ordering.SingleValueInterval(value));
        }

        /// <summary>
        /// Returns whether the first interval contains the second interval (i.e. whether the second one is a subset of the first one).
        /// </summary>
        public static bool Contains<A>(this ITotalOrdering<A> ordering, Interval<A> interval1, Interval<A> interval2)
        {
            return ordering.Intersect(interval1, interval2).Equals(interval2);
        }

        /// <summary>
        /// Returns whether the two intervals have intersection.
        /// </summary>
        public static bool Intersects<A>(this ITotalOrdering<A> ordering, Interval<A> interval1, Interval<A> interval2)
        {
            return ordering.Intersect(interval1, interval2).IsNonEmpty;
        }

        /// <summary>
        /// Returns intersection of the two intervals.
        /// </summary>
        public static Interval<A> Intersect<A>(this ITotalOrdering<A> ordering, Interval<A> interval1, Interval<A> interval2)
        {
            ordering.Check(interval1, interval2);

            var limitOrderings = ordering.GetLimitOrderings();
            return ordering.Interval(
                limitOrderings.LowerRestrictiveness.Max(interval1.LowerLimit, interval2.LowerLimit),
                limitOrderings.UpperRestrictiveness.Max(interval1.UpperLimit, interval2.UpperLimit)
            );
        }

        /// <summary>
        /// Returns intersection of the specified intervals.
        /// </summary>
        public static Interval<A> Intersect<A>(this ITotalOrdering<A> ordering, IEnumerable<Interval<A>> intervals)
            where A : new()
        {
            return intervals.Aggregate(ordering.EmptyInterval(), (i1, i2) => ordering.Intersect(i1, i2));
        }

        /// <summary>
        /// Returns closure of the interval (the same interval with all bounds closed).
        /// </summary>
        public static Interval<A> Closure<A>(this ITotalOrdering<A> ordering, Interval<A> interval)
        {
            if (interval.IsEmpty)
            {
                return interval;
            }

            return ordering.Interval(
                interval.LowerBound.Map(b => IntervalLimit.Closed(b)).GetOrElse(interval.LowerLimit),
                interval.UpperBound.Map(b => IntervalLimit.Closed(b)).GetOrElse(interval.UpperLimit)
            );
        }

        internal static void Check<A>(this ITotalOrdering<A> ordering, Interval<A> interval, Func<Unit, Exception> otherwise)
        {
            if (!ordering.Equals(interval.Ordering))
            {
                throw otherwise(Unit.Value);
            }
        }

        internal static void Check<A>(this ITotalOrdering<A> ordering, Interval<A> interval1, Interval<A> interval2)
        {
            ordering.Check(interval1, _ => new ArgumentException("The first interval uses different ordering."));
            ordering.Check(interval2, _ => new ArgumentException("The second interval uses different ordering."));
        }
    }
}
