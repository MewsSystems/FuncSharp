using System;
using System.Collections.Generic;

namespace FuncSharp
{
    internal class Comparer<A> : IComparer<A>
    {
        public Comparer(Func<A, A, bool> less, Ordering ordering = Ordering.Ascending)
        {
            Less = less;
            Multiplier = ordering.Match(
                Ordering.Ascending, _ => 1,
                Ordering.Descending, _ => -1
            );
        }

        private Func<A, A, bool> Less { get; }

        private int Multiplier { get; }

        public int Compare(A x, A y)
        {
            if (Less(y, x))
            {
                return Multiplier;
            }
            if (Less(x, y))
            {
                return -Multiplier;
            }

            // Either equal or non-equal non-comparable.
            return 0;
        }
    }
}
