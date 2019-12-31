using System;
namespace FuncSharp
{
    public class ComparableTotalOrdering<A> : TotalOrdering<A>
        where A : IComparable<A>
    {
        public ComparableTotalOrdering()
            : base((a, b) => Equals(a, b), (a, b) => a.CompareTo(b) < 0)
        {
        }
    }
}
