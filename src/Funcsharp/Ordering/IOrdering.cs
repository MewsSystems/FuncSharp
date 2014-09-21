using System;
using System.Collections.Generic;
using System.Linq;
using FuncSharp.Equality;

namespace FuncSharp.Ordering
{
    /// <summary>
    /// An ordering relation for the specified type.
    /// </summary>
    /// <typeparam name="A">Type for which the ordering relation is implemented.</typeparam>
    public interface IOrdering<A> : IEquality<A>
    {
        /// <summary>
        /// Returns whether the first element is less than the second element.
        /// </summary>
        bool Less(A a1, A a2);
    }

    public static class IOrdering
    {
        /// <summary>
        /// Returns whether the first element is less or equal to the second element.
        /// </summary>
        public static bool LessOrEqual<A>(this IOrdering<A> o, A a1, A a2)
        {
            return o.Less(a1, a2) || o.Equal(a1, a2);
        }

        /// <summary>
        /// Returns whether the first element is greater than the second element.
        /// </summary>
        public static bool Greater<A>(this IOrdering<A> o, A a1, A a2)
        {
            return !o.LessOrEqual(a1, a2);
        }

        /// <summary>
        /// Returns whether the first element is greater or equal to the second element.
        /// </summary>
        public static bool GreaterOrEqual<A>(this IOrdering<A> o, A a1, A a2)
        {
            return !o.Less(a1, a2);
        }

        /// <summary>
        /// Returns minimum element from the specified elements. Throws an exception if there is no element to determine the minimum from.
        /// </summary>
        public static A Min<A>(this IOrdering<A> o, IEnumerable<A> values)
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("Empty collection doesn't have a minimum value.");
            }
            return values.Aggregate((a, b) => o.Less(a, b) ? a : b);
        }

        /// <summary>
        /// Returns minimum element from the specified elements. Throws an exception if there is no element to determine the minimum from.
        /// </summary>
        public static A Min<A>(this IOrdering<A> o, params A[] values)
        {
            return o.Min(values.AsEnumerable());
        }

        /// <summary>
        /// Returns maximum element from the specified elements. Throws an exception if there is no element to determine the maximum from.
        /// </summary>
        public static A Max<A>(this IOrdering<A> o, IEnumerable<A> values)
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("Empty collection doesn't have a maximum value.");
            }
            return values.Aggregate((a, b) => o.Less(a, b) ? b : a);
        }

        /// <summary>
        /// Returns maximum element from the specified elements. Throws an exception if there is no element to determine the maximum from.
        /// </summary>
        public static A Max<A>(this IOrdering<A> o, params A[] values)
        {
            return o.Max(values.AsEnumerable());
        }

        /// <summary>
        /// Returns the values ordered from the lowest to the greatest. So first is less than second, which is less than third etc.
        /// </summary>
        public static IEnumerable<A> Order<A>(this IOrdering<A> o, IEnumerable<A> values)
        {
            var result = new List<A>(values);
            var comparer = new OrderingComparer<A> { Ordering = o };
            result.Sort(comparer);
            return result;
        }
    }
}