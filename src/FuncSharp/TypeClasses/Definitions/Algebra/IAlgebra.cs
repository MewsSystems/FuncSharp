namespace FuncSharp
{
    /// <summary>
    /// An universal algebra over the specified type.
    /// </summary>
    public interface IAlgebra<A>
    {
        /// <summary>
        /// Returns whether the two specified elements are equal.
        /// </summary>
        bool Equal(A a1, A a2);
    }
}