using System.Collections.Generic;

namespace Funcsharp.Ordering
{
    internal class OrderingComparer<A> : IComparer<A>
    {
        public IOrdering<A> Ordering { get; set; }

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
