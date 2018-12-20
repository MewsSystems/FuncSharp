namespace FuncSharp
{
    public class Interval<A> : Product3<ITotalOrdering<A>, IntervalLimit<A>, IntervalLimit<A>>
    {
        /// <summary>
        /// Creates a new interval with the specified limits.
        /// </summary>
        internal Interval(ITotalOrdering<A> ordering, IntervalLimit<A> lowerLimit, IntervalLimit<A> upperLimit)
            : base(ordering, lowerLimit, upperLimit)
        {
            IsEmpty = LowerBound.FlatMap(l => UpperBound.Map(u =>
                Ordering.Greater(l, u) ||
                Ordering.Equal(l, u) && (LowerLimit.IsOpen || UpperLimit.IsOpen)
            )).GetOrFalse();
        }

        /// <summary>
        /// Ordering of the underlying values.
        /// </summary>
        public ITotalOrdering<A> Ordering
        {
            get { return ProductValue1; }
        }

        /// <summary>
        /// Lower limit of the interval.
        /// </summary>
        public IntervalLimit<A> LowerLimit
        {
            get { return ProductValue2; }
        }

        /// <summary>
        /// Upper limit of the interval.
        /// </summary>
        public IntervalLimit<A> UpperLimit
        {
            get { return ProductValue3; }
        }

        /// <summary>
        /// Lower bound of the interval.
        /// </summary>
        public IOption<A> LowerBound
        {
            get { return LowerLimit.Bound; ; }
        }

        /// <summary>
        /// Upper bound of the interval.
        /// </summary>
        public IOption<A> UpperBound
        {
            get { return UpperLimit.Bound; }
        }

        /// <summary>
        /// Returns whether the interval is empty.
        /// </summary>
        public bool IsEmpty { get; }

        /// <summary>
        /// Returns whether the interval is non empty.
        /// </summary>
        public bool IsNonEmpty
        {
            get { return !IsEmpty; }
        }

        /// <summary>
        /// Return whether the interval is lower-bounded.
        /// </summary>
        public bool IsLowerBounded
        {
            get { return LowerLimit.IsBounded; }
        }

        /// <summary>
        /// Return whether the interval is upper-bounded.
        /// </summary>
        public bool IsUpperBounded
        {
            get { return UpperLimit.IsBounded; }
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

        public override int GetHashCode()
        {
            if (IsEmpty)
            {
                return Ordering.GetHashCode();
            }
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Interval<A> interval && IsEmpty && interval.IsEmpty)
            {
                return Ordering.Equals(interval.Ordering);
            }

            return base.Equals(obj);
        }

        public override string ToString()
        {
            if (IsEmpty)
            {
                return "Ø";
            }
            if (UpperBound.Equals(LowerBound) && IsBounded)
            {
                return "[" + UpperBound.Get() + "]";
            }

            return
                (LowerLimit.IsOpen ? "(" : "[") +
                LowerBound.Map(b => b.ToString()).GetOrElse("-∞") + ", " +
                UpperBound.Map(b => b.ToString()).GetOrElse("∞") +
                (UpperLimit.IsOpen ? ")" : "]");
        }
    }
}
