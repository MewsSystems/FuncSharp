namespace FuncSharp
{
    /// <summary>
    /// An implementation of equality for the specified type.
    /// </summary>
    public interface IEquality<A>
    {
        /// <summary>
        /// Returns whether the two specified elements are equal.
        /// </summary>
        bool Equal(A a1, A a2);
    }
}