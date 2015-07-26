using System;
namespace FuncSharp
{
    public class ComparableOrdering<A> : TotalOrdering<A>
        where A : IComparable<A>
    {
        public ComparableOrdering()
            : base((a1, a2) => a1.CompareTo(a2) < 0)
        {
        }
    }
}
