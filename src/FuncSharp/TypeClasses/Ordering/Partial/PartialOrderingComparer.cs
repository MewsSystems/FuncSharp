using System.Collections.Generic;

namespace FuncSharp
{
    internal class PartialOrderingComparer<A> : IComparer<A>
    {
        public PartialOrderingComparer(IPartialOrdering<A> ordering, Order order)
        {
            Ordering = ordering;
            Multiplier = order == Order.Ascending ? 1 : -1;
        }

        public IPartialOrdering<A> Ordering { get; }

        private int Multiplier { get; }

        public int Compare(A x, A y)
        {
            if (Ordering.Greater(x, y))
            {
                return Multiplier;
            }
            if (Ordering.Less(x, y))
            {
                return -Multiplier;
            }

            // Either equal or non-equal non-comparable.
            return 0;
        }
    }
}
