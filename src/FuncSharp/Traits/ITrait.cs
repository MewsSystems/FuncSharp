namespace FuncSharp
{
    /// <summary>
    /// A trait-like interface with the specified type of data (fields of the trait).
    /// </summary>
    public interface ITrait<TData>
        where TData : class
    {
        /// <summary>
        /// Data storage of the trait data (fields of the trait).
        /// </summary>
        TraitDataStorage TraitDataStorage { get; }
    }
}
