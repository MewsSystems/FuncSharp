namespace FuncSharp
{
    public static class IntervalLimit
    {
        /// <summary>
        /// Creates an unbounded limit.
        /// </summary>
        public static IntervalLimit<A> Unbounded<A>()
        {
            return new IntervalLimit<A>(Option.Empty<A>(), isOpen: true);
        }

        /// <summary>
        /// Creates a new limit with the specified bound.
        /// </summary>
        public static IntervalLimit<A> Create<A>(A bound, bool isOpen)
        {
            return new IntervalLimit<A>(Option.Valued(bound), isOpen);
        }

        /// <summary>
        /// Creates a new open (exclusive) limit with the specified bound.
        /// </summary>
        public static IntervalLimit<A> Open<A>(A bound)
        {
            return Create(bound, true);
        }

        /// <summary>
        /// Creates a new closed (inclusive) limit with the specified bound.
        /// </summary>
        public static IntervalLimit<A> Closed<A>(A bound)
        {
            return Create(bound, false);
        }
    }

    public class IntervalLimit<A> : Product2<IOption<A>, bool>
    {
        /// <summary>
        /// Creates a new limit with the specified bound.
        /// </summary>
        internal IntervalLimit(IOption<A> limit, bool isOpen)
            : base(limit, isOpen)
        {
        }

        /// <summary>
        /// Bound of the interval limit.
        /// </summary>
        public IOption<A> Bound
        {
            get { return ProductValue1; }
        }

        /// <summary>
        /// Returns whether the limit is bounded.
        /// </summary>
        public bool IsBounded
        {
            get { return !Bound.IsEmpty; }
        }

        /// <summary>
        /// Returns whether the limit is unbounded.
        /// </summary>
        public bool IsUnbounded
        {
            get { return !IsBounded; }
        }

        /// <summary>
        /// Returns whether the limit is open (exclusive).
        /// </summary>
        public bool IsOpen
        {
            get { return ProductValue2; }
        }

        /// <summary>
        /// Returns whether the limit is closed (inclusive).
        /// </summary>
        public bool IsClosed
        {
            get { return !IsOpen; }
        }

        public override string ToString()
        {
            return (IsOpen ? "Open(" : "Closed(") + Bound.Map(b => b.ToString()).GetOrElse("Unounded") + ")";
        }
    }
}
