using System;

namespace FuncSharp
{
    internal class None<A> : Option<A>
    {
        static None()
        {
            Instance = new None<A>();
        }

        private None()
        {
        }

        public static None<A> Instance { get; private set; }

        public override A Value
        {
            get { throw new InvalidOperationException("An empty option does not have a value."); }
        }

        public override bool IsEmpty
        {
            get { return true; }
        }
    }
}
