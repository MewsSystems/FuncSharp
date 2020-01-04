namespace FuncSharp
{
    public class Interval<A> : Product2<Option<IntervalBound<A>>, Option<IntervalBound<A>>>
    {
        /// <summary>
        /// Creates a new interval with the specified bounds.
        /// </summary>
        internal Interval(Option<IntervalBound<A>> lowerBound, Option<IntervalBound<A>> upperBound, bool isEmpty)
            : base(lowerBound, upperBound)
        {
            IsEmpty = isEmpty;
        }

        /// <summary>
        /// Lower bound of the interval.
        /// </summary>
        public Option<IntervalBound<A>> LowerBound
        {
            get { return ProductValue1; }
        }

        /// <summary>
        /// Upper bound of the interval.
        /// </summary>
        public Option<IntervalBound<A>> UpperBound
        {
            get { return ProductValue2; }
        }

        /// <summary>
        /// Value of the interval lower bound.
        /// </summary>
        public Option<A> LowerBoundValue
        {
            get { return LowerBound.Map(l => l.Value); }
        }

        /// <summary>
        /// Value of the interval upper bound.
        /// </summary>
        public Option<A> UpperBoundValue
        {
            get { return UpperBound.Map(l => l.Value); }
        }

        /// <summary>
        /// Returns whether the interval is bounded (i.e. both bounds are defined).
        /// </summary>
        public bool IsBounded
        {
            get { return LowerBound.NonEmpty && UpperBound.NonEmpty; }
        }

        /// <summary>
        /// Returns whether the interval is empty.
        /// </summary>
        public bool IsEmpty { get; }

        /// <summary>
        /// Returns whether the interval is non empty.
        /// </summary>
        public bool NonEmpty
        {
            get { return !IsEmpty; }
        }

        public override string ToString()
        {
            if (IsEmpty)
            {
                return "Ø";
            }
            if (UpperBoundValue.Equals(LowerBoundValue) && IsBounded)
            {
                return $"[{UpperBoundValue.Get()}]";
            }

            var lowerBound = LowerBound.Match(
                l => $"{(l.IsOpen ? "(" : "[")}{l.Value}",
                _ => "(-∞"
            );
            var upperBound = UpperBound.Match(
                l => $"{l.Value}{(l.IsOpen ? ")" : "]")}",
                _ => "∞)"
            );

            return $"{lowerBound}, {upperBound}";
        }
    }
}
