using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuncSharp
{
    /// <summary>
    /// A type that is a compound of other types. Can be understood as a cartesian product of types, e.g. T1 × T2 × T3.
    /// Therefore instances of a product type consist of values of the compound types, e.g. T1 value1, T2 value2 and T3 value3.
    /// This interface represents the most abstract definition of a product type with unknown compound types and unknown arity.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Values of the product. Should never return null.
        /// </summary>
        IEnumerable<object> ProductValues { get; }
    }

    public static class IProductExtensions
    {
        /// <summary>
        /// Returns hash code of the specified product.
        /// </summary>
        public static int ProductHashCode(this IProduct product)
        {
            return ProductHashCode(product.ProductValues);
        }

        /// <summary>
        /// Returns hash code of a product consisting of the specified values.
        /// </summary>
        public static int ProductHashCode(IEnumerable<object> productValues)
        {
            var result = 19;
            foreach (var value in productValues)
            {
                unchecked
                {
                    result += 41 * (value != null ? value.GetHashCode() : 0);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns whether the two specified products are structurally equal. Note that two nulls are 
        /// considered structurally equal products.
        /// </summary>
        public static bool ProductEquals<TProduct>(this TProduct p1, object p2)
            where TProduct : IProduct
        {
            return p1.FastEquals(p2).GetOrElse(() =>
                p1.ProductValues.SequenceEqual(((TProduct)p2).ProductValues)
            );
        }

        /// <summary>
        /// Returns string representation of the specified product.
        /// </summary>
        public static string ProductToString(this IProduct product)
        {
            return product.GetType().SimpleName() + ProductToString(product.ProductValues);
        }

        /// <summary>
        /// Returns string representation of a product consisting of the specified product values.
        /// </summary>
        public static string ProductToString(IEnumerable<object> productValues)
        {
            var b = new StringBuilder("(");

            var prefix = "";
            foreach (var value in productValues)
            {
                b.Append(prefix);
                b.Append(value.SafeToString());
                prefix = ", ";
            }

            b.Append(")");
            return b.ToString();
        }
    }
}
