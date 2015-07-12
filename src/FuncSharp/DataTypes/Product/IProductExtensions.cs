using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuncSharp
{
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
        /// Returns hash code of the specified product values.
        /// </summary>
        public static int ProductHashCode(IEnumerable<object> values)
        {
            var result = 19;
            foreach (var value in values)
            {
                unchecked
                {
                    result += 41 * (value != null ? value.GetHashCode() : 0);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns hash code of the specified product values.
        /// </summary>
        public static int ProductHashCode(params object[] values)
        {
            return ProductHashCode(values.AsEnumerable());
        }

        /// <summary>
        /// Returns whether the two specified products are structurally equal. Note that two nulls are 
        /// considered structurally equal products.
        /// </summary>
        public static bool ProductEquals(this IProduct p1, object p2)
        {
            return p1.FastEquals(p2).GetOrElse(() =>
                p1.ProductValues.SequenceEqual(((IProduct)p2).ProductValues)
            );
        }

        /// <summary>
        /// Returns string representation of the specified product.
        /// </summary>
        public static string ProductToString(this IProduct product)
        {
            var b = new StringBuilder(product.GetType().SimpleName() + "(");

            var prefix = "";
            foreach (var value in product.ProductValues)
            {
                b.Append(prefix);
                b.Append(value.SafeToString());
                prefix = ", ";
            }

            b.Append(")");
            return b.ToString();
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public static Tuple<T1> ToTuple<T1>(this IProduct1<T1> p)
        {
            return Tuple.Create(p.ProductValue1);
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public static Tuple<T1, T2> ToTuple<T1, T2>(this IProduct2<T1, T2> p)
        {
            return Tuple.Create(p.ProductValue1, p.ProductValue2);
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public static Tuple<T1, T2, T3> ToTuple<T1, T2, T3>(this IProduct3<T1, T2, T3> p)
        {
            return Tuple.Create(p.ProductValue1, p.ProductValue2, p.ProductValue3);
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public static Tuple<T1, T2, T3, T4> ToTuple<T1, T2, T3, T4>(this IProduct4<T1, T2, T3, T4> p)
        {
            return Tuple.Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4);
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public static Tuple<T1, T2, T3, T4, T5> ToTuple<T1, T2, T3, T4, T5>(this IProduct5<T1, T2, T3, T4, T5> p)
        {
            return Tuple.Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5);
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public static Tuple<T1, T2, T3, T4, T5, T6> ToTuple<T1, T2, T3, T4, T5, T6>(this IProduct6<T1, T2, T3, T4, T5, T6> p)
        {
            return Tuple.Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6);
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public static Tuple<T1, T2, T3, T4, T5, T6, T7> ToTuple<T1, T2, T3, T4, T5, T6, T7>(this IProduct7<T1, T2, T3, T4, T5, T6, T7> p)
        {
            return Tuple.Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7);
        }
    }
}
