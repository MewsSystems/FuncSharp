using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    /// <summary>
    /// A total ordering relation for the specified type.
    /// </summary>
    /// <typeparam name="A">Type for which the ordering relation is implemented.</typeparam>
    public class TotalOrdering<A> : PartialOrdering<A>
    {
        private static readonly Interval<A> emptyInterval;
        private static readonly Interval<A> unbounedInterval;
        private static readonly IntervalSet<A> emptyIntervalSet;

        static TotalOrdering()
        {
            var defaultBound = IntervalBound.Open(default(A)).ToOption();
            var noBound = Option.Empty<IntervalBound<A>>();

            emptyInterval = new Interval<A>(defaultBound, defaultBound, isEmpty: true);
            unbounedInterval = new Interval<A>(noBound, noBound, isEmpty: false);
            emptyIntervalSet = new IntervalSet<A>(Enumerable.Empty<Interval<A>>());
        }

        public TotalOrdering(Func<A, A, bool> equal, Func<A, A, bool> less)
            : base(equal, less)
        {
        }

        /// <summary>
        /// An empty interval which does not contain any values.
        /// </summary>
        public Interval<A> EmptyInterval
        {
            get { return emptyInterval; }
        }

        /// <summary>
        /// An unbounded interval which contains all of the values.
        /// </summary>
        public Interval<A> UnboundedInterval
        {
            get { return unbounedInterval; }
        }

        /// <summary>
        /// An empty interval set.
        /// </summary>
        public IntervalSet<A> EmptyIntervalSet
        {
            get { return emptyIntervalSet; }
        }

        /// <summary>
        /// Returns minimum element from the specified elements. Throws an exception if there is no element to determine the minimum from.
        /// </summary>
        public A Min(IEnumerable<A> values)
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("Empty collection doesn't have a minimum value.");
            }
            return values.Aggregate((a, b) => Less(a, b) ? a : b);
        }

        /// <summary>
        /// Returns minimum element from the specified elements. Throws an exception if there is no element to determine the minimum from.
        /// </summary>
        public A Min(params A[] values)
        {
            return Min(values.AsEnumerable());
        }

        /// <summary>
        /// Returns maximum element from the specified elements. Throws an exception if there is no element to determine the maximum from.
        /// </summary>
        public A Max(IEnumerable<A> values)
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("Empty collection doesn't have a maximum value.");
            }
            return values.Aggregate((a, b) => Less(a, b) ? b : a);
        }

        /// <summary>
        /// Returns maximum element from the specified elements. Throws an exception if there is no element to determine the maximum from.
        /// </summary>
        public A Max(params A[] values)
        {
            return Max(values.AsEnumerable());
        }

        /// <summary>
        /// Creates a new interval with the specified bounds.
        /// </summary>
        public Interval<A> Interval(IntervalBound<A> lowerBound = null, IntervalBound<A> upperBound = null)
        {
            return Interval(lowerBound.ToOption(), upperBound.ToOption());
        }

        /// <summary>
        /// Creates a new interval with the specified bounds.
        /// </summary>
        public Interval<A> Interval(IOption<IntervalBound<A>> lowerBound, IOption<IntervalBound<A>> upperBound)
        {
            if (lowerBound.IsEmpty && upperBound.IsEmpty)
            {
                return UnboundedInterval;
            }
            if (lowerBound.FlatMap(l => upperBound.Map(u => Greater(l.Value, u.Value) || Equal(l.Value, u.Value) && (l.IsOpen || u.IsOpen))).GetOrFalse())
            {
                return EmptyInterval;
            }

            return new Interval<A>(lowerBound, upperBound, isEmpty: false);
        }

        /// <summary>
        /// Creates a new degenerate interval that consists of just one value.
        /// </summary>
        public Interval<A> SingleValueInterval(A value)
        {
            var bound = IntervalBound.Closed(value).ToOption();
            return new Interval<A>(bound, bound, isEmpty: false);
        }

        /// <summary>
        /// Creates an open interval with the specified bounds.
        /// </summary>
        public Interval<A> OpenInterval(A lowerBound, A upperBound)
        {
            return Interval(IntervalBound.Open(lowerBound), IntervalBound.Open(upperBound));
        }

        /// <summary>
        /// Creates an interval with closed lower bound and open upper bound.
        /// </summary>
        public Interval<A> ClosedOpenInterval(A lowerBound, A upperBound)
        {
            return Interval(IntervalBound.Closed(lowerBound), IntervalBound.Open(upperBound));
        }

        /// <summary>
        /// Creates an interval with open lower bound and closed upper bound.
        /// </summary>
        public Interval<A> OpenClosedInterval(A lowerBound, A upperBound)
        {
            return Interval(IntervalBound.Open(lowerBound), IntervalBound.Closed(upperBound));
        }

        /// <summary>
        /// Creates a closed interval with the specified bounds.
        /// </summary>
        public Interval<A> ClosedInterval(A lowerBound, A upperBound)
        {
            return Interval(IntervalBound.Closed(lowerBound), IntervalBound.Closed(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval with open lower bound.
        /// </summary>
        public Interval<A> OpenUnboundedInterval(A lowerBound)
        {
            return Interval(lowerBound: IntervalBound.Open(lowerBound));
        }

        /// <summary>
        /// Creates an unbounded interval with closed lower bound.
        /// </summary>
        public Interval<A> ClosedUnboundedInterval(A lowerBound)
        {
            return Interval(lowerBound: IntervalBound.Closed(lowerBound));
        }

        /// <summary>
        /// Creates an unbounded interval with open upper bound.
        /// </summary>
        public Interval<A> UnboundedOpenInterval(A upperBound)
        {
            return Interval(upperBound: IntervalBound.Open(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval with closed upper bound.
        /// </summary>
        public Interval<A> UnboundedClosedInterval(A upperBound)
        {
            return Interval(upperBound: IntervalBound.Closed(upperBound));
        }

        /// <summary>
        /// Returns whether the interval contains the specified value.
        /// </summary>
        public bool Contains(Interval<A> interval, A value)
        {
            return Contains(interval, SingleValueInterval(value));
        }

        /// <summary>
        /// Returns whether the first interval contains the second interval (i.e. whether the second one is a subset of the first one).
        /// </summary>
        public bool Contains(Interval<A> a, Interval<A> b)
        {
            return Intersect(a, b).Equals(b);
        }

        /// <summary>
        /// Returns whether the two intervals have intersection.
        /// </summary>
        public bool Intersects(Interval<A> a, Interval<A> b)
        {
            return Intersect(a, b).NonEmpty;
        }

        /// <summary>
        /// Returns intersection of the two intervals.
        /// </summary>
        public Interval<A> Intersect(Interval<A> a, Interval<A> b)
        {
            return Interval(
                ExtremeBound(a.LowerBound, b.LowerBound, Greater),
                ExtremeBound(a.UpperBound, b.UpperBound, Less)
            );
        }

        /// <summary>
        /// Returns intersection of the specified intervals.
        /// </summary>
        public Interval<A> Intersect(IEnumerable<Interval<A>> intervals)
        {
            return intervals.Aggregate(EmptyInterval, Intersect);
        }

        /// <summary>
        /// Creates a new interval set consisting only of the specified interval.
        /// </summary>
        public IntervalSet<A> IntervalSet(Interval<A> interval)
        {
            return new IntervalSet<A>(new[] { interval });
        }

        /// <summary>
        /// Creates a new interval set from the specified collection of intervals.
        /// </summary>
        public IntervalSet<A> IntervalSet(IEnumerable<Interval<A>> intervals)
        {
            return intervals.Aggregate(EmptyIntervalSet, Union);
        }

        /// <summary>
        /// Creates a new interval set from the specified collection of intervals.
        /// </summary>
        public IntervalSet<A> IntervalSet(params Interval<A>[] intervals)
        {
            return IntervalSet(intervals.AsEnumerable());
        }

        /// <summary>
        /// Returns whether the interval set contains the specified value.
        /// </summary>
        public bool Contains(IntervalSet<A> set, A value)
        {
            return Contains(set, SingleValueInterval(value));
        }

        /// <summary>
        /// Returns whether the interval set contains the specified interval.
        /// </summary>
        public bool Contains(IntervalSet<A> set, Interval<A> interval)
        {
            return Contains(set, IntervalSet(interval));
        }

        /// <summary>
        /// Returns whether the first interval set contains the second interval set.
        /// </summary>
        public bool Contains(IntervalSet<A> a, IntervalSet<A> b)
        {
            return Intersect(a, b).Equals(b);
        }

        /// <summary>
        /// Returns intersection of the interval set and the specified interval.
        /// </summary>
        public IntervalSet<A> Intersect(IntervalSet<A> set, Interval<A> interval)
        {
            return Intersect(set, IntervalSet(interval));
        }

        /// <summary>
        /// Returns intersection of the two interval sets.
        /// </summary>
        public IntervalSet<A> Intersect(IntervalSet<A> a, IntervalSet<A> b)
        {
            var intersection = a.Intervals.SelectMany(x => b.Intervals.Select(y => Intersect(x, y)));
            return new IntervalSet<A>(intersection.Where(i => i.NonEmpty).ToList());
        }

        /// <summary>
        /// Returns intersection of the specified interval sets.
        /// </summary>
        public IntervalSet<A> Intersect(IEnumerable<IntervalSet<A>> sets)
        {
            return sets.Aggregate(EmptyIntervalSet, Intersect);
        }

        /// <summary>
        /// Returns union of the two intervals.
        /// </summary>
        public IntervalSet<A> Union(Interval<A> a, Interval<A> b)
        {
            return Union(IntervalSet(a), b);
        }

        /// <summary>
        /// Returns union of the specified intervals.
        /// </summary>
        public IntervalSet<A> Union(IEnumerable<Interval<A>> intervals)
        {
            return IntervalSet(intervals);
        }

        /// <summary>
        /// Returns union of the interval set and the specified interval.
        /// </summary>
        public IntervalSet<A> Union(IntervalSet<A> set, Interval<A> interval)
        {
            return Union(set, IntervalSet(interval));
        }

        /// <summary>
        /// Returns union of the two interval sets.
        /// </summary>
        public IntervalSet<A> Union(IntervalSet<A> a, IntervalSet<A> b)
        {
            new IntervalSet<A>(a.Intervals.Aggregate(b.Intervals, Union));

            // Check that all intervals belong to the underlying space and that they are disjoint.        
            var orderedIntervals = ordering.GetIntervalOrdering().Order(intervals.Where(i => i.IsNonEmpty)).ToArray();
            for (var i = 0; i < orderedIntervals.Length; i++)
            {
                Ordering.Check(orderedIntervals[i], _ => new ArgumentException($"The {i}-th interval uses different ordering."));

                if (i + 1 < orderedIntervals.Length)
                {
                    if (Ordering.Intersects(orderedIntervals[i], orderedIntervals[i + 1]))
                    {
                        throw new ArgumentException("The intervals have to be disjoint.");
                    }
                }
            }
        }

        /// <summary>
        /// Returns union of the specified interval sets.
        /// </summary>
        public IntervalSet<A> Union(IEnumerable<IntervalSet<A>> sets)
        {
            return sets.Aggregate(EmptyIntervalSet, Union);
        }

        /// <summary>
        /// Returns extreme of the specified two bounds of same type.
        /// </summary>
        private IOption<IntervalBound<A>> ExtremeBound(IOption<IntervalBound<A>> a, IOption<IntervalBound<A>> b, Func<A, A, bool> metric)
        {
            return a.FlatMap(x => b.Map(y => ExtremeBound(x, y, metric))).OrElse(_ => a).OrElse(_ => b);
        }

        /// <summary>
        /// Returns extreme of the specified two bounds of same type.
        /// </summary>
        private IntervalBound<A> ExtremeBound(IntervalBound<A> a, IntervalBound<A> b, Func<A, A, bool> metric)
        {
            if (metric(a.Value, b.Value) || Equal(a.Value, b.Value) && a.IsOpen)
            {
                return a;
            }
            return b;
        }

        private IEnumerable<Interval<A>> Union(IEnumerable<Interval<A>> intervals, Interval<A> interval)
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
                    data.LimitOrderings.LowerRestrictiveness.Min(interval.LowerBound, unionIntervals.First().LowerBound),
                    data.LimitOrderings.UpperRestrictiveness.Min(interval.UpperBound, unionIntervals.Last().UpperBound)
                );
            }

            return data.IntervalOrdering.Order(otherIntervals.Concat(new[] { unionInterval }));
        }
    }
}
