namespace FuncSharp.Equality
{
    /// <summary>
    /// An equality relation for the specified type.
    /// </summary>
    /// <typeparam name="A">Type for which the equality relation is implemented.</typeparam>
    public interface IEquality<A>
    {
        /// <summary>
        /// Returns whether the two specified elements are equal.
        /// </summary>
        bool Equal(A a1, A a2);
    }
}