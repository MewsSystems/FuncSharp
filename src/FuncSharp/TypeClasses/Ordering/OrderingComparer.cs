using System.Collections.Generic;

namespace FuncSharp
{
    internal class OrderingComparer<A> : IComparer<A>
    {
        public OrderingComparer(IOrdering<A> ordering, Order order)
        {
            Ordering = ordering;
            Order = order;
            Sign = Order == Order.Ascending ? 1 : -1;
        }

        public IOrdering<A> Ordering { get; private set; }
        public Order Order { get; private set; }

        private int Sign { get; set; }

        public int Compare(A x, A y)
        {
            if (Ordering.Less(x, y))
            {
                return -1 * Sign;
            }
            if (Ordering.Equal(x, y))
            {
                return 0;
            }
            return 1 * Sign;
        }
    }
}
