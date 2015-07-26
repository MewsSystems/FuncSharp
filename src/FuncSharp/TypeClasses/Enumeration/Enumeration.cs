using System;

namespace FuncSharp
{
    public class Enumeration<A> : Equality<A>, IEnumeration<A>
    {
        public Enumeration(Func<A, A> successor, Func<A, A, bool> equal = null)
            : base(equal)
        {
            SuccessorImpl = successor;
        }

        public TraitDataStorage TraitDataStorage { get; private set; }

        private Func<A, A> SuccessorImpl { get; set; }

        public A Successor(A a)
        {
            return SuccessorImpl(a);
        }
    }
}
