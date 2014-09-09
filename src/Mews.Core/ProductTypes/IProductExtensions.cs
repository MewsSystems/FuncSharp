using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mews.Core.Equality;

namespace Mews.Core.ProductTypes
{
    /// <summary>
    /// A set of methods available for all types that inherit the IProductType interface. Also provides default implementations
    /// of common object methods, that would otherwise had to be defined manually for each class that inherits the IPRoductType.
    /// </summary>
    public static class IProductExtensions
    {
        /// <summary>
        /// Returns string representation of the specified product.
        /// </summary>
        public static string ProductToString(this IProduct product)
        {
            return ProductToString(product.ProductElements);
        }

        /// <summary>
        /// Returns string representation of a product consisting of the specified product elements.
        /// </summary>
        public static string ProductToString(IEnumerable<object> productElements)
        {
            var b = new StringBuilder("(");

            var first = true;
            foreach (var element in productElements)
            {
                if (!first)
                {
                    b.Append(", ");
                }
                b.Append(element == null ? "null" : element.ToString());
                first = false;
            }

            b.Append(")");
            return b.ToString();
        }

        /// <summary>
        /// Returns hash code of the specified product computed from the product elements.
        /// </summary>
        public static int ProductHashCode(this IProduct product)
        {
            return ProductHashCode(product.ProductElements);
        }

        /// <summary>
        /// Returns hash code of a product consisting of the specified product elements.
        /// </summary>
        public static int ProductHashCode(IEnumerable<object> productElements)
        {
            var result = 19;
            foreach (var element in productElements)
            {
                unchecked
                {
                    result += 41 * (element != null ? element.GetHashCode() : 0);
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
            return
                p1.FastEquals(p2) ??
                p1.ProductElements.SequenceEqual(((TProduct)p2).ProductElements);
        }
    }
}
