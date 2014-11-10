using System.Collections.Generic;

namespace FuncSharp
{
    internal class OrderingComparer<A> : IComparer<A>
    {
        public OrderingComparer(IOrdering<A> ordering)
        {
            Ordering = ordering;
        }

        public IOrdering<A> Ordering { get; private set; }

        public int Compare(A x, A y)
        {
            if (Ordering.Less(x, y))
            {
                return -1;
            }
            if (Ordering.Equal(x, y))
            {
                return 0;
            }
            return 1;
        }
    }
}
