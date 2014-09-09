using System.Collections.Generic;

namespace Mews.Core.ProductTypes
{
    /// <summary>
    /// A type that is a compound of other types. Can be understood as a cartesian product of types, e.g. T1 × T2 × T3.
    /// Therefore instances of a product type consist of values of the compound types, e.g. T1 value1, T2 value2 and T3 value3.
    /// This interface represents the most abstract definition of a product type with unknown compound types and unknown arity.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Elements of the product. Should never return null.
        /// </summary>
        IEnumerable<object> ProductElements { get; }
    }
}
