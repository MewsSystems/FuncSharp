namespace FuncSharp
{
    /// <summary>
    /// A total ordering relation for the specified type.
    /// </summary>
    /// <typeparam name="A">Type for which the ordering relation is implemented.</typeparam>
    public interface ITotalOrdering<A> : ITrait<TotalOrderingData<A>>, IPartialOrdering<A>
    {
    }
}