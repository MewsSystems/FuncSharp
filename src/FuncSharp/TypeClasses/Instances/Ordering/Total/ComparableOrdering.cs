using System;

namespace FuncSharp
{
    public class ComparableOrdering<T> : TotalOrdering<T>
        where T : IComparable<T>
    {
        public override bool Less(T a1, T a2)
        {
            return a1.CompareTo(a2) < 0;
        }
    }
}
