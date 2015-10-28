using System.Collections.Generic;

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

    /// <summary>
    /// A 0-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct0 : IProduct
    {
        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct0 ToCanonicalProduct();
    }

    /// <summary>
    /// A 1-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct1<out T1> : IProduct
    {
        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        T1 ProductValue1 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct0 ExceptValue1 { get; }

        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct1<T1> ToCanonicalProduct();
    }

    /// <summary>
    /// A 2-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct2<out T1, out T2> : IProduct
    {
        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        T2 ProductValue2 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct1<T2> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct1<T1> ExceptValue2 { get; }

        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct2<T1, T2> ToCanonicalProduct();
    }

    /// <summary>
    /// A 3-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct3<out T1, out T2, out T3> : IProduct
    {
        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        T3 ProductValue3 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct2<T2, T3> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct2<T1, T3> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct2<T1, T2> ExceptValue3 { get; }

        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct3<T1, T2, T3> ToCanonicalProduct();
    }

    /// <summary>
    /// A 4-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct4<out T1, out T2, out T3, out T4> : IProduct
    {
        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        T4 ProductValue4 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct3<T2, T3, T4> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct3<T1, T3, T4> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct3<T1, T2, T4> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct3<T1, T2, T3> ExceptValue4 { get; }

        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct4<T1, T2, T3, T4> ToCanonicalProduct();
    }

    /// <summary>
    /// A 5-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct5<out T1, out T2, out T3, out T4, out T5> : IProduct
    {
        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        T4 ProductValue4 { get; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        T5 ProductValue5 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct4<T2, T3, T4, T5> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct4<T1, T3, T4, T5> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct4<T1, T2, T4, T5> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct4<T1, T2, T3, T5> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct4<T1, T2, T3, T4> ExceptValue5 { get; }

        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct5<T1, T2, T3, T4, T5> ToCanonicalProduct();
    }

    /// <summary>
    /// A 6-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct6<out T1, out T2, out T3, out T4, out T5, out T6> : IProduct
    {
        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        T4 ProductValue4 { get; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        T5 ProductValue5 { get; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        T6 ProductValue6 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct5<T2, T3, T4, T5, T6> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct5<T1, T3, T4, T5, T6> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct5<T1, T2, T4, T5, T6> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct5<T1, T2, T3, T5, T6> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct5<T1, T2, T3, T4, T6> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct5<T1, T2, T3, T4, T5> ExceptValue6 { get; }

        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct6<T1, T2, T3, T4, T5, T6> ToCanonicalProduct();
    }

    /// <summary>
    /// A 7-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct7<out T1, out T2, out T3, out T4, out T5, out T6, out T7> : IProduct
    {
        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        T4 ProductValue4 { get; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        T5 ProductValue5 { get; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        T6 ProductValue6 { get; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        T7 ProductValue7 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct6<T2, T3, T4, T5, T6, T7> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct6<T1, T3, T4, T5, T6, T7> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct6<T1, T2, T4, T5, T6, T7> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct6<T1, T2, T3, T5, T6, T7> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct6<T1, T2, T3, T4, T6, T7> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct6<T1, T2, T3, T4, T5, T7> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct6<T1, T2, T3, T4, T5, T6> ExceptValue7 { get; }

        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct7<T1, T2, T3, T4, T5, T6, T7> ToCanonicalProduct();
    }

    /// <summary>
    /// A 8-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct8<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8> : IProduct
    {
        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        T4 ProductValue4 { get; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        T5 ProductValue5 { get; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        T6 ProductValue6 { get; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        T7 ProductValue7 { get; }

        /// <summary>
        /// Value of the product in the dimension 8.
        /// </summary>
        T8 ProductValue8 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct7<T2, T3, T4, T5, T6, T7, T8> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct7<T1, T3, T4, T5, T6, T7, T8> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct7<T1, T2, T4, T5, T6, T7, T8> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct7<T1, T2, T3, T5, T6, T7, T8> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct7<T1, T2, T3, T4, T6, T7, T8> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct7<T1, T2, T3, T4, T5, T7, T8> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct7<T1, T2, T3, T4, T5, T6, T8> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct7<T1, T2, T3, T4, T5, T6, T7> ExceptValue8 { get; }

        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct8<T1, T2, T3, T4, T5, T6, T7, T8> ToCanonicalProduct();
    }

    /// <summary>
    /// A 9-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct9<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9> : IProduct
    {
        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        T4 ProductValue4 { get; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        T5 ProductValue5 { get; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        T6 ProductValue6 { get; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        T7 ProductValue7 { get; }

        /// <summary>
        /// Value of the product in the dimension 8.
        /// </summary>
        T8 ProductValue8 { get; }

        /// <summary>
        /// Value of the product in the dimension 9.
        /// </summary>
        T9 ProductValue9 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct8<T2, T3, T4, T5, T6, T7, T8, T9> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct8<T1, T3, T4, T5, T6, T7, T8, T9> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct8<T1, T2, T4, T5, T6, T7, T8, T9> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct8<T1, T2, T3, T5, T6, T7, T8, T9> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct8<T1, T2, T3, T4, T6, T7, T8, T9> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct8<T1, T2, T3, T4, T5, T7, T8, T9> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct8<T1, T2, T3, T4, T5, T6, T8, T9> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct8<T1, T2, T3, T4, T5, T6, T7, T9> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct8<T1, T2, T3, T4, T5, T6, T7, T8> ExceptValue9 { get; }

        /// <summary>
        /// Converts the product into the canonical implementation.
        /// </summary>
        IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> ToCanonicalProduct();
    }

}