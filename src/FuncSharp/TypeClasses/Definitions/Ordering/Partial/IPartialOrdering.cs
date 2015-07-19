namespace FuncSharp
{
    /// <summary>
    /// A partial ordering for the specified type.
    /// </summary>
    /// <typeparam name="A">Type for which the ordering relation is implemented.</typeparam>
    public interface IPartialOrdering<A> : IAlgebra<A>
    {
        /// <summary>
        /// Returns whether the first element is less than the second element.
        /// </summary>
        bool Less(A a1, A a2);
    }
}