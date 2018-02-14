using System;

namespace FuncSharp
{
    public class Equality<A> : IEquality<A>
    {
        public Equality(Func<A, A, bool> equal = null)
        {
            EqualImpl = equal ?? ((a1, a2) => a1.Equals(a2));
        }

        public Func<A, A, bool> EqualImpl { get; }

        public virtual bool Equal(A a1, A a2)
        {
            return EqualImpl(a1, a2);
        }
    }
}
