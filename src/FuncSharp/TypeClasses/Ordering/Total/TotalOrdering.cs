using System;

namespace FuncSharp
{
    public class TotalOrdering<A> : Equality<A>, ITotalOrdering<A>
    {
        public TotalOrdering(Func<A, A, bool> less, Func<A, A, bool> equal = null)
            : base(equal)
        {
            LessImpl = less;
            TraitDataStorage = new TraitDataStorage();
        }

        public TraitDataStorage TraitDataStorage { get; }

        private Func<A, A, bool> LessImpl { get; set; }

        public bool Less(A a1, A a2)
        {
            return LessImpl(a1, a2);
        }
    }
}
