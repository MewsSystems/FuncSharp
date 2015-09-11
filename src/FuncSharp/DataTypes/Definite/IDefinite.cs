namespace FuncSharp
{
    /// <summary>
    /// A container for value that is definitely not null.
    /// </summary>
    public interface IDefinite<out A> : IOption<A>
    {
    }
}
