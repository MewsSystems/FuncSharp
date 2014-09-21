using System;
using System.Collections.Generic;
using FuncSharp.Options;
using FuncSharp.Ordering;
using FuncSharp.ProductTypes;

namespace FuncSharp.Intervals
{
    public class Interval<T> : IProduct
        where T : IComparable<T>, new()
    {
        static Interval()
        {
            Ordering = new ComparableOrdering<T>();
        }

        /// <summary>
        /// Creates a new interval with the specified bounds.
        /// </summary>
        public Interval(Option<Bound<T>> lowerBound = null, Option<Bound<T>> upperBound = null)
        {
            LowerBound = lowerBound ?? Option.None<Bound<T>>();
            UpperBound = upperBound ?? Option.None<Bound<T>>();

            IsEmpty = LowerBound.FlatMap(l => UpperBound.Map(u =>
                Ordering.Less(u.Value, l.Value) ||
                Ordering.Equal(l.Value, u.Value) && (l.IsOpen || u.IsOpen)
            )).GetOrDefault();
        }

        /// <summary>
        /// Ordering of the interval value domain.
        /// </summary>
        public static IOrdering<T> Ordering { get; private set; }

        /// <summary>
        /// Lower bound of the interval. None represents an unbounded lower bound.
        /// </summary>
        public Option<Bound<T>> LowerBound { get; private set; }

        /// <summary>
        /// Upper bound of the interval. None represents an unbounded upper bound.
        /// </summary>
        public Option<Bound<T>> UpperBound { get; private set; }

        /// <summary>
        /// Values of the interval as a product.
        /// </summary>
        public IEnumerable<object> ProductValues
        {
            get
            {
                yield return LowerBound;
                yield return UpperBound;
            }
        }

        /// <summary>
        /// Returns whether the interval is empty.
        /// </summary>
        public bool IsEmpty { get; private set; }

        /// <summary>
        /// Return whether the interval is lower-bounded.
        /// </summary>
        public bool IsLowerBounded
        {
            get { return LowerBound.NonEmpty; }
        }

        /// <summary>
        /// Return whether the interval is upper-bounded.
        /// </summary>
        public bool IsUpperBounded
        {
            get { return UpperBound.NonEmpty; }
        }

        /// <summary>
        /// Returns whether the interval is bounded (i.e. both bounds have a value).
        /// </summary>
        public bool IsBounded
        {
            get { return IsLowerBounded && IsUpperBounded; }
        }

        /// <summary>
        /// Returns whether the interval is unbounded (i.e. at least one of the bounds doesn't have a value).
        /// </summary>
        public bool IsUnbounded
        {
            get { return !IsBounded; }
        }

        /// <summary>
        /// Returns whether the interval contains the specified value.
        /// </summary>
        public bool Contains(T value)
        {
            return
                !IsEmpty &&
                BoundContains(LowerBound, value, Ordering.Less) &&
                BoundContains(UpperBound, value, Ordering.Greater);
        }

        /// <summary>
        /// Returns intersection of the current interval and the specified interval.
        /// </summary>
        public Interval<T> Intersect(Interval<T> i)
        {
            return Interval.Create(
                BoundIntersect(LowerBound, i.LowerBound, (b1, b2) => Ordering.Max(b1, b2)),
                BoundIntersect(UpperBound, i.UpperBound, (b1, b2) => Ordering.Min(b1, b2))
            );
        }

        public override int GetHashCode()
        {
            if (IsEmpty)
            {
                return 0;
            }
            return this.ProductHashCode();
        }
        public override bool Equals(object obj)
        {
            var interval = obj as Interval<T>;
            if (interval != null && IsEmpty && interval.IsEmpty)
            {
                return true;
            }

            return this.ProductEquals(obj);
        }
        public override string ToString()
        {
            if (IsEmpty)
            {
                return "Ø";
            }

            return String.Format(
                "{0}, {1}",
                LowerBound.Map(b => (b.IsClosed ? "[" : "(") + b.Value.ToString()).GetOrElse(() => "(-∞"),
                UpperBound.Map(b => b.Value.ToString() + (b.IsClosed ? "]" : ")")).GetOrElse(() => "∞)")
            );
        }

        private bool BoundContains(Option<Bound<T>> bound, T value, Func<T, T, bool> comparison)
        {
            var withinBound = bound.Map(b =>
                b.IsClosed && Ordering.Equal(b.Value, value) ||
                comparison(b.Value, value)
            );
            return withinBound.GetOrElse(() => true);
        }

        private Option<Bound<T>> BoundIntersect(Option<Bound<T>> bound1, Option<Bound<T>> bound2, Func<T, T, T> moreRestrictive)
        {
            if (bound1.IsEmpty)
            {
                return bound2;
            }
            if (bound2.IsEmpty)
            {
                return bound1;
            }

            return bound1.FlatMap(b1 => bound2.Map(b2 =>
            {
                var bound = moreRestrictive(b1.Value, b2.Value);
                var isOpen =
                    Ordering.Equal(bound, b1.Value) && b1.IsOpen ||
                    Ordering.Equal(bound, b2.Value) && b2.IsOpen;
                return isOpen ? Bound.Open(bound) : Bound.Closed(bound);
            }));
        }
    }

    public static class Interval
    {
        /// <summary>
        /// Creates a new interval with the specified bounds.
        /// </summary>
        public static Interval<T> Create<T>(Bound<T> lowerBound = null, Bound<T> upperBound = null)
            where T : IComparable<T>, new()
        {
            return Create(lowerBound.ToOption(), upperBound.ToOption());
        }

        /// <summary>
        /// Creates a new interval with the specified bounds.
        /// </summary>
        public static Interval<T> Create<T>(Option<Bound<T>> lowerBound, Option<Bound<T>> upperBound)
            where T : IComparable<T>, new()
        {
            return new Interval<T>(lowerBound, upperBound);
        }

        /// <summary>
        /// Creates a new empty interval.
        /// </summary>
        public static Interval<T> Empty<T>()
            where T : IComparable<T>, new()
        {
            var bound = Bound.Open(new T()).ToOption();
            return Create(bound, bound);
        }

        /// <summary>
        /// Creates a new degenerate interval that consists of just one value.
        /// </summary>
        public static Interval<T> Single<T>(T value)
            where T : IComparable<T>, new()
        {
            var bound = Bound.Closed(value).ToOption();
            return Create(bound, bound);
        }

        /// <summary>
        /// Creates a bounded open interval with the specified bounds.
        /// </summary>
        public static Interval<T> Open<T>(T lowerBound, T upperBound)
            where T : IComparable<T>, new()
        {
            return Create(Bound.Open(lowerBound), Bound.Open(upperBound));
        }

        /// <summary>
        /// Creates a bounded interval with the specified closed lower bound and open upper bound.
        /// </summary>
        public static Interval<T> ClosedOpen<T>(T lowerBound, T upperBound)
            where T : IComparable<T>, new()
        {
            return Create(Bound.Closed(lowerBound), Bound.Open(upperBound));
        }

        /// <summary>
        /// Creates a bounded interval with the specified open lower bound and closed upper bound.
        /// </summary>
        public static Interval<T> OpenClosed<T>(T lowerBound, T upperBound)
            where T : IComparable<T>, new()
        {
            return Create(Bound.Open(lowerBound), Bound.Closed(upperBound));
        }

        /// <summary>
        /// Creates a bounded closed interval with the specified bounds.
        /// </summary>
        public static Interval<T> Closed<T>(T lowerBound, T upperBound)
            where T : IComparable<T>, new()
        {
            return Create(Bound.Closed(lowerBound), Bound.Closed(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval with the specified open lower bound.
        /// </summary>
        public static Interval<T> LowerOpen<T>(T lowerBound)
            where T : IComparable<T>, new()
        {
            return Create(lowerBound: Bound.Open(lowerBound));
        }

        /// <summary>
        /// Creates an unbounded interval with the specified closed lower bound.
        /// </summary>
        public static Interval<T> LowerClosed<T>(T lowerBound)
            where T : IComparable<T>, new()
        {
            return Create(lowerBound: Bound.Closed(lowerBound));
        }

        /// <summary>
        /// Creates an unbounded interval with the specified open upper bound.
        /// </summary>
        public static Interval<T> UpperOpen<T>(T upperBound)
            where T : IComparable<T>, new()
        {
            return Create(upperBound: Bound.Open(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval with the specified closed upper bound.
        /// </summary>
        public static Interval<T> UpperClosed<T>(T upperBound)
            where T : IComparable<T>, new()
        {
            return Create(upperBound: Bound.Closed(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval consisting of all values.
        /// </summary>
        public static Interval<T> Unbounded<T>()
            where T : IComparable<T>, new()
        {
            var bound = Option.None<Bound<T>>();
            return Create(bound, bound);
        }
    }
}
