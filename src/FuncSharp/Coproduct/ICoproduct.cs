
using System;

namespace FuncSharp
{
    /// <summary>
    /// A type that represents a disjunction of types, choice from multiple different types e.g. T1 or T2 or T3.
    /// </summary>
    public interface ICoproduct
    {
        /// <summary>
        /// Arity of the coproduct type. Should be non-negative.
        /// </summary>
        int CoproductArity { get; }

        /// <summary>
        /// Discriminator of the coproduct type value. Should be in interval [1, CoproductArity].
        /// </summary>
        int CoproductDiscriminator { get; }

        /// <summary>
        /// Value of the coproduct type no matter which one of the possible values it is.
        /// </summary>
        object CoproductValue { get; }
    }
}