using System;

namespace FuncSharp
{
    public static class TupleExtensions
    {
        /// <summary>
        /// Converts the specified tuple into a product.
        /// </summary>
        public static IProduct1<T1> ToProduct<T1>(this Tuple<T1> t)
        {
            return Product.Create(t.Item1);
        }

        /// <summary>
        /// Converts the specified tuple into a product.
        /// </summary>
        public static IProduct2<T1, T2> ToProduct<T1, T2>(this Tuple<T1, T2> t)
        {
            return Product.Create(t.Item1, t.Item2);
        }

        /// <summary>
        /// Converts the specified tuple into a product.
        /// </summary>
        public static IProduct3<T1, T2, T3> ToProduct<T1, T2, T3>(this Tuple<T1, T2, T3> t)
        {
            return Product.Create(t.Item1, t.Item2, t.Item3);
        }

        /// <summary>
        /// Converts the specified tuple into a product.
        /// </summary>
        public static IProduct4<T1, T2, T3, T4> ToProduct<T1, T2, T3, T4>(this Tuple<T1, T2, T3, T4> t)
        {
            return Product.Create(t.Item1, t.Item2, t.Item3, t.Item4);
        }

        /// <summary>
        /// Converts the specified tuple into a product.
        /// </summary>
        public static IProduct5<T1, T2, T3, T4, T5> ToProduct<T1, T2, T3, T4, T5>(this Tuple<T1, T2, T3, T4, T5> t)
        {
            return Product.Create(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5);
        }

        /// <summary>
        /// Converts the specified tuple into a product.
        /// </summary>
        public static IProduct6<T1, T2, T3, T4, T5, T6> ToProduct<T1, T2, T3, T4, T5, T6>(this Tuple<T1, T2, T3, T4, T5, T6> t)
        {
            return Product.Create(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6);
        }

        /// <summary>
        /// Converts the specified tuple into a product.
        /// </summary>
        public static IProduct7<T1, T2, T3, T4, T5, T6, T7> ToProduct<T1, T2, T3, T4, T5, T6, T7>(this Tuple<T1, T2, T3, T4, T5, T6, T7> t)
        {
            return Product.Create(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7);
        }

    }
}