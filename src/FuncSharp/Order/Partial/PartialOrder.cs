using System;
using System.Collections.Generic;

namespace FuncSharp
{
    /// <summary>
    /// A partial order for the specified type.
    /// </summary>
    /// <typeparam name="A">Type for which the ordering relation is implemented.</typeparam>
    public class PartialOrder<A>
    {
        public PartialOrder(Func<A, A, bool> less)
        {
            LessImpl = less;
        }

        protected Func<A, A, bool> LessImpl { get; }

        /// <summary>
        /// Returns whether the first element is less than the second element.
        /// </summary>
        public bool Less(A a, A b)
        {
            return LessImpl(a, b);
        }

        /// <summary>
        /// Returns whether the first element is less or equal to the second element.
        /// </summary>
        public bool LessOrEqual(A a, A b)
        {
            return Less(a, b) || Equals(a, b);
        }

        /// <summary>
        /// Returns whether the first element is greater than the second element.
        /// </summary>
        public bool Greater(A a, A b)
        {
            return Less(b, a);
        }

        /// <summary>
        /// Returns whether the first element is greater or equal to the second element.
        /// </summary>
        public bool GreaterOrEqual(A a, A b)
        {
            return Greater(a, b) || Equals(a, b);
        }

        /// <summary>
        /// Returns the values ordered according to the specified order.
        /// </summary>
        public IEnumerable<A> Order(IEnumerable<A> values, Ordering ordering = Ordering.Ascending)
        {
            return values.Order(Less, ordering);
        }
    }
}