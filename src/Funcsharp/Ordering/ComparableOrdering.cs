using System;
using Funcsharp.Equality;

namespace Funcsharp.Ordering
{
    public class ComparableOrdering<T> : IOrdering<T>
        where T : IComparable<T>
    {
        public bool Less(T a1, T a2)
        {
            return a1.CompareTo(a2) < 0;
        }

        public bool Equal(T a1, T a2)
        {
            return a1.StructurallyEquals(a2);
        }
    }
}
