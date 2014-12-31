namespace FuncSharp
{
    /// <summary>
    /// A type that represents a choice from multiple different types e.g. T1 or T2 or T3.
    /// Therefore instances of a product type consist of values of the compound types, e.g. T1 value1, T2 value2 and T3 value3.
    /// This interface represents the most abstract definition of a product type with unknown compound types and unknown arity.
    /// </summary>
    public interface ISum
    {
        /// <summary>
        /// Arity of the sum type. Should be non-negative.
        /// </summary>
        int SumArity { get; }

        /// <summary>
        /// Discriminator of the sum type value. Should be in interval [0, SumArity).
        /// </summary>
        int SumDiscriminator { get; }

        /// <summary>
        /// Value of the sum type no matter which one of the possible values it is.
        /// </summary>
        object SumValue { get; }
    }
}
