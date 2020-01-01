using System;
namespace FuncSharp
{
    public class ComparableTotalOrder<A> : TotalOrder<A>
        where A : IComparable<A>
    {
        public ComparableTotalOrder()
            : base((a, b) => a.CompareTo(b) < 0)
        {
        }
    }
}
