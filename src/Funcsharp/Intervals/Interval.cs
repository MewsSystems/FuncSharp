using System;
using System.Collections.Generic;
using Funcsharp.Options;
using Funcsharp.Ordering;
using Funcsharp.ProductTypes;

namespace Funcsharp.Intervals
{
    public class Interval<T> : IProduct
        where T : IComparable<T>
    {
        static Interval()
        {
            Ordering = new ComparableOrdering<T>();
        }

        /// <summary>
        /// Creates a new range with the specified bounds.
        /// </summary>
        public Interval(Option<Bound<T>> lowerBound = null, Option<Bound<T>> upperBound = null)
        {
            lowerBound = lowerBound ?? Option.None<Bound<T>>();
            upperBound = upperBound ?? Option.None<Bound<T>>();

            if (lowerBound.NonEmpty && upperBound.NonEmpty)
            {
                var l = lowerBound.Get();
                var u = upperBound.Get();
                if (Ordering.Less(u.Value, l.Value))
                {
                    throw new ArgumentException("The upper bound cannot be less than then the lower bound.");
                }
                if (Ordering.Equal(l.Value, u.Value) && l.Type != u.Type)
                {
                    throw new ArgumentException("One bound cannot be inclusive and the other exclusive if they both have the same value.");
                }
            }

            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        public static IOrdering<T> Ordering { get; private set; }

        /// <summary>
        /// Lower bound of the range. None represents an unbounded lower bound.
        /// </summary>
        public Option<Bound<T>> LowerBound { get; private set; }

        /// <summary>
        /// Upper bound of the range. None represents an unbounded upper bound.
        /// </summary>
        public Option<Bound<T>> UpperBound { get; private set; }

        /// <summary>
        /// Values of the range as a product.
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
        /// Return whether the range is lower-bounded.
        /// </summary>
        public bool IsLowerBounded
        {
            get { return LowerBound.NonEmpty; }
        }

        /// <summary>
        /// Return whether the range is upper-bounded.
        /// </summary>
        public bool IsUpperBounded
        {
            get { return UpperBound.NonEmpty; }
        }

        /// <summary>
        /// Returns whether the range is bounded (i.e. both bounds have a value).
        /// </summary>
        public bool IsBounded
        {
            get { return IsLowerBounded && IsUpperBounded; }
        }

        /// <summary>
        /// Returns whether the range is unbounded (i.e. at least one of the bounds doesn't have a value).
        /// </summary>
        public bool IsUnbounded
        {
            get { return !IsBounded; }
        }

        public override bool Equals(object obj)
        {
            return this.ProductEquals(obj);
        }

        public override int GetHashCode()
        {
            return this.ProductHashCode();
        }

        public override string ToString()
        {
            var equalOpenBounds = LowerBound.FlatMap(l => UpperBound.Map(u =>
                Ordering.Equal(l.Value, u.Value) && l.IsOpen && u.IsOpen
            ));

            if (equalOpenBounds.GetOrDefault())
            {
                return "Ø";
            }

            return String.Format(
                "{0}, {1}",
                LowerBound.Map(b => (b.IsClosed ? "[" : "(") + b.Value.ToString()).GetOrElse(() => "(-∞"),
                UpperBound.Map(b => b.Value.ToString() + (b.IsClosed ? "]" : ")")).GetOrElse(() => "∞)")
            );
        }
    }

    public static class Interval
    {
        /// <summary>
        /// Creates a new interval with the specified bounds.
        /// </summary>
        public static Interval<T> Create<T>(Bound<T> lowerBound = null, Bound<T> upperBound = null)
            where T : IComparable<T>
        {
            return Create(lowerBound.ToOption(), upperBound.ToOption());
        }

        /// <summary>
        /// Creates a new interval with the specified bounds.
        /// </summary>
        public static Interval<T> Create<T>(Option<Bound<T>> lowerBound, Option<Bound<T>> upperBound)
            where T : IComparable<T>
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
            where T : IComparable<T>
        {
            var bound = Bound.Closed(value).ToOption();
            return Create(bound, bound);
        }

        /// <summary>
        /// Creates a bounded open interval with the specified bounds.
        /// </summary>
        public static Interval<T> Open<T>(T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return Create(Bound.Open(lowerBound), Bound.Open(upperBound));
        }

        /// <summary>
        /// Creates a bounded interval with the specified closed lower bound and open upper bound.
        /// </summary>
        public static Interval<T> ClosedOpen<T>(T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return Create(Bound.Closed(lowerBound), Bound.Open(upperBound));
        }

        /// <summary>
        /// Creates a bounded interval with the specified open lower bound and closed upper bound.
        /// </summary>
        public static Interval<T> OpenClosed<T>(T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return Create(Bound.Open(lowerBound), Bound.Closed(upperBound));
        }

        /// <summary>
        /// Creates a bounded closed interval with the specified bounds.
        /// </summary>
        public static Interval<T> Closed<T>(T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return Create(Bound.Closed(lowerBound), Bound.Closed(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval with the specified open lower bound.
        /// </summary>
        public static Interval<T> LowerOpen<T>(T lowerBound)
            where T : IComparable<T>
        {
            return Create(lowerBound: Bound.Open(lowerBound));
        }

        /// <summary>
        /// Creates an unbounded interval with the specified closed lower bound.
        /// </summary>
        public static Interval<T> LowerClosed<T>(T lowerBound)
            where T : IComparable<T>
        {
            return Create(lowerBound: Bound.Closed(lowerBound));
        }

        /// <summary>
        /// Creates an unbounded interval with the specified open upper bound.
        /// </summary>
        public static Interval<T> UpperOpen<T>(T upperBound)
            where T : IComparable<T>
        {
            return Create(upperBound: Bound.Open(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval with the specified closed upper bound.
        /// </summary>
        public static Interval<T> UpperClosed<T>(T upperBound)
            where T : IComparable<T>
        {
            return Create(upperBound: Bound.Closed(upperBound));
        }

        /// <summary>
        /// Creates an unbounded interval consisting of all values.
        /// </summary>
        public static Interval<T> Unbounded<T>()
            where T : IComparable<T>
        {
            var bound = Option.None<Bound<T>>();
            return Create(bound, bound);
        }
    }
}
