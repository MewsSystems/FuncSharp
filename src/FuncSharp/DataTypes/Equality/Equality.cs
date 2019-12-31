using System;

namespace FuncSharp
{
    /// <summary>
    /// An equality for the specified type.
    /// </summary>
    public class Equality<A>
    {
        public Equality(Func<A, A, bool> equal = null)
        {
            EqualImpl = equal ?? ((a1, a2) => a1.Equals(a2));
        }

        protected Func<A, A, bool> EqualImpl { get; }

        /// <summary>
        /// Returns whether the two specified elements are equal.
        /// </summary>
        public bool Equal(A a, A b)
        {
            return EqualImpl(a, b);
        }

        /// <summary>
        /// Returns whether the two specified elements are not equal.
        /// </summary>
        public bool NonEqual(A a, A b)
        {
            return !Equal(a, b);
        }
    }
}
