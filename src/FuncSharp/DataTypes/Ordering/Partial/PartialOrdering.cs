using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    /// <summary>
    /// A partial ordering for the specified type.
    /// </summary>
    /// <typeparam name="A">Type for which the ordering relation is implemented.</typeparam>
    public class PartialOrdering<A> : Equality<A>
    {
        public PartialOrdering(Func<A, A, bool> equal, Func<A, A, bool> less)
            : base(equal)
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
            return Less(a, b) || Equal(a, b);
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
            return Greater(a, b) || Equal(a, b);
        }

        /// <summary>
        /// Returns the values ordered according to the specified order.
        /// </summary>
        public IEnumerable<A> Order(IEnumerable<A> values, Order order = FuncSharp.Order.Ascending)
        {
            var result = values.ToList();
            var comparer = new PartialOrderingComparer<A>(this, order);
            result.Sort(comparer);
            return result;
        }
    }
}