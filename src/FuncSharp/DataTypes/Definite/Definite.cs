using System;

namespace FuncSharp
{
    public static class Definite
    {
        /// <summary>
        /// Creates a new definite from a non-null value.
        /// </summary>
        public static IDefinite<A> Create<A>(A value)
        {
            return new Definite<A>(value);
        }
    }

    internal class Definite<A> : Option<A>, IDefinite<A>
    {
        public Definite(A value)
            : base(value)
        {
            if (value == null)
            {
                throw new ArgumentException("The value has to be non-null.");
            }
        }
    }
}
