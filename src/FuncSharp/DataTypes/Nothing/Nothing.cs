namespace FuncSharp
{
    /// <summary>
    /// The bottom uninhabited type. Can be e.g. used to denote return type of methods that never return (always throw an exception).
    /// </summary>
    public sealed class Nothing
    {
        private Nothing()
        {

        }
    }
}
