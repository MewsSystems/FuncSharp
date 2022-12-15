using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    /// <summary>
    /// A total order relation for the specified type.
    /// </summary>
    /// <typeparam name="A">Type for which the ordering relation is implemented.</typeparam>
    public class TotalOrder<A> : PartialOrder<A>
    {
        private static readonly Interval<A> emptyInterval;
        private static readonly Interval<A> unbounedInterval;
        private static readonly IntervalSet<A> emptyIntervalSet;

        static TotalOrder()
        {
            var defaultBound = IntervalBound.Open(default(A)).ToOption();
            var noBound = Option.Empty<IntervalBound<A>>();

            emptyInterval = new Interval<A>(defaultBound, defaultBound, isEmpty: true);
            unbounedInterval = new Interval<A>(noBound, noBound, isEmpty: false);
            emptyIntervalSet = new IntervalSet<A>(Enumerable.Empty<Interval<A>>());
        }

        public TotalOrder(Func<A, A, bool> less)
            : base(less)
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
            if (lowerBound.FlatMap(l => upperBound.Map(u => Greater(l.Value, u.Value) || Equals(l.Value, u.Value) && (l.IsOpen || u.IsOpen))).GetOrFalse())
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
        /// Orders the specified intervals.
        /// </summary>
        public List<Interval<A>> Order(IEnumerable<Interval<A>> intervals, Ordering ordering = Ordering.Ascending)
        {
            return intervals.Order(Less, ordering);
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
                LowerBoundLess(a.LowerBound, b.LowerBound) ? b.LowerBound : a.LowerBound,
                UpperBoundLess(a.UpperBound, b.UpperBound) ? a.UpperBound : b.UpperBound
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
            if (interval.IsEmpty)
            {
                return EmptyIntervalSet;
            }
            return new IntervalSet<A>(new[] { interval });
        }

        /// <summary>
        /// Creates a new interval set from the specified collection of intervals.
        /// </summary>
        public IntervalSet<A> IntervalSet(IEnumerable<Interval<A>> intervals)
        {
            return Union(intervals);
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
            var orderedIntervals = Order(intervals.Where(i => i.NonEmpty));
            var results = new List<Interval<A>>();

            // Thanks to interval ordering, results of the union are formed of continuous sequences of intervals in the ordered interval collection.
            foreach (var interval in orderedIntervals)
            {
                var result = results.LastOption().Where(r => Intersects(r, interval) || Complements(r.UpperBound, interval.LowerBound));

                // If the interval should be part of the result, replace the result with a new extended result. Otherwise, initialize a new result.
                result.Match(
                    r => results[results.Count - 1] = Interval(
                        lowerBound: r.LowerBound,
                        upperBound: UpperBoundLess(r.UpperBound, interval.UpperBound) ? interval.UpperBound : r.UpperBound
                    ),
                    _ => results.Add(interval)
                );
            }

            return new IntervalSet<A>(results);
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
            return Union(new[] { a, b });
        }

        /// <summary>
        /// Returns union of the specified interval sets.
        /// </summary>
        public IntervalSet<A> Union(IEnumerable<IntervalSet<A>> sets)
        {
            return Union(sets.SelectMany(s => s.Intervals));
        }

        /// <summary>
        /// Returns whether the first interval is less than the second one.
        /// </summary>
        private bool Less(Interval<A> a, Interval<A> b)
        {
            if (a.IsEmpty)
            {
                return b.NonEmpty;
            }
            if (b.IsEmpty)
            {
                return false;
            }

            return
                LowerBoundLess(a.LowerBound, b.LowerBound) ||
                Equals(a.LowerBound, b.LowerBound) && UpperBoundLess(a.UpperBound, b.UpperBound);
        }

        /// <summary>
        /// Returns whether the first lower bound is less than the second.
        /// </summary>
        private bool LowerBoundLess(IOption<IntervalBound<A>> a, IOption<IntervalBound<A>> b)
        {
            var result = a.FlatMap(x => b.Map(y => Less(x.Value, y.Value) || Equals(x.Value, y.Value) && x.IsClosed && y.IsOpen));
            return result.GetOrElse(_ => a.IsEmpty && b.NonEmpty);
        }

        /// <summary>
        /// Returns whether the first upper bound is less than the second.
        /// </summary>
        private bool UpperBoundLess(IOption<IntervalBound<A>> a, IOption<IntervalBound<A>> b)
        {
            var result = a.FlatMap(x => b.Map(y => Less(x.Value, y.Value) || Equals(x.Value, y.Value) && x.IsOpen && y.IsClosed));
            return result.GetOrElse(_ => a.NonEmpty && b.IsEmpty);
        }

        /// <summary>
        /// Returns whther one interval bound complements another (i.e. have same value, but differ in type).
        /// </summary>
        private bool Complements(IOption<IntervalBound<A>> a, IOption<IntervalBound<A>> b)
        {
            return a.FlatMap(x => b.Map(y => Equals(x.Value, y.Value) && !Equals(x.Type, y.Type))).GetOrFalse();
        }
    }
}
