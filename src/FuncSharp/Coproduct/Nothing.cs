namespace FuncSharp;

/// <summary>
/// The bottom uninhabited type. That is the type without any instances. Can be e.g. used to denote return type of 
/// methods that never return (always throw an exception) instead of void.
/// </summary>
public sealed class Nothing : Coproduct0
{
    private Nothing()
        : base()
    {
    }
}