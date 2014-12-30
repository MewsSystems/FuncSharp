namespace FuncSharp
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

    public static class IEqualityExtensions
    {
        /// <summary>
        /// Returns whether the two specified elements are not equal.
        /// </summary>
        public static bool NonEqual<A>(this IEquality<A> equality, A a1, A a2)
        {
            return !equality.Equal(a1, a2);
        }
    }
}