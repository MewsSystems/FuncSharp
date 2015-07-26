namespace FuncSharp
{
    /// <summary>
    /// An implementation of enumeration for the specified type.
    /// </summary>
    public interface IEnumeration<A> : IEquality<A>
    {
        /// <summary>
        /// Returns successor of the specified value.
        /// </summary>
        A Successor(A a);
    }
}