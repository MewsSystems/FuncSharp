using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class IPartialOrderingExtensions
    {
        /// <summary>
        /// Returns whether the first element is less or equal to the second element.
        /// </summary>
        public static bool LessOrEqual<A>(this IPartialOrdering<A> ordering, A a1, A a2)
        {
            return ordering.Less(a1, a2) || ordering.Equal(a1, a2);
        }

        /// <summary>
        /// Returns whether the first element is greater than the second element.
        /// </summary>
        public static bool Greater<A>(this IPartialOrdering<A> ordering, A a1, A a2)
        {
            return ordering.Less(a2, a1);
        }

        /// <summary>
        /// Returns whether the first element is greater or equal to the second element.
        /// </summary>
        public static bool GreaterOrEqual<A>(this IPartialOrdering<A> ordering, A a1, A a2)
        {
            return ordering.Greater(a1, a2) || ordering.Equal(a1, a2);
        }

        /// <summary>
        /// Returns the values ordered according to the specified order.
        /// </summary>
        public static IEnumerable<A> Order<A>(this IPartialOrdering<A> ordering, IEnumerable<A> values, Order order = FuncSharp.Order.Ascending)
        {
            var result = values.ToList();
            var comparer = new PartialOrderingComparer<A>(ordering, order);
            result.Sort(comparer);
            return result;
        }
    }
}
