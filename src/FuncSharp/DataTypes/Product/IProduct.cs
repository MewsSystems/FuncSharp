using System;
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
        /// Values of the product.
        /// </summary>
        IEnumerable<object> ProductValues { get; }
    }

    /// <summary>
    /// A 0-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct0 : IProduct
    {

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        R Match<R>(Func<R> f);
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
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        R Match<R>(Func<T1, R> f);
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
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        R Match<R>(Func<T1, T2, R> f);
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
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        R Match<R>(Func<T1, T2, T3, R> f);
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
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        R Match<R>(Func<T1, T2, T3, T4, R> f);
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
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        R Match<R>(Func<T1, T2, T3, T4, T5, R> f);
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
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        R Match<R>(Func<T1, T2, T3, T4, T5, T6, R> f);
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

    }

    /// <summary>
    /// A 10-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct10<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct9<T2, T3, T4, T5, T6, T7, T8, T9, T10> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct9<T1, T3, T4, T5, T6, T7, T8, T9, T10> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct9<T1, T2, T4, T5, T6, T7, T8, T9, T10> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct9<T1, T2, T3, T5, T6, T7, T8, T9, T10> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct9<T1, T2, T3, T4, T6, T7, T8, T9, T10> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct9<T1, T2, T3, T4, T5, T7, T8, T9, T10> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct9<T1, T2, T3, T4, T5, T6, T8, T9, T10> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct9<T1, T2, T3, T4, T5, T6, T7, T9, T10> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T10> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> ExceptValue10 { get; }

    }

    /// <summary>
    /// A 11-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct11<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// Value of the product in the dimension 11.
        /// </summary>
        T11 ProductValue11 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct10<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct10<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct10<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct10<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct10<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct10<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct10<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct10<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct10<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11> ExceptValue10 { get; }

        /// <summary>
        /// The same product with ProductValue11 omitted.
        /// </summary>
        IProduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> ExceptValue11 { get; }

    }

    /// <summary>
    /// A 12-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct12<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// Value of the product in the dimension 11.
        /// </summary>
        T11 ProductValue11 { get; }

        /// <summary>
        /// Value of the product in the dimension 12.
        /// </summary>
        T12 ProductValue12 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct11<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct11<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct11<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct11<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct11<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct11<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct11<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct11<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12> ExceptValue10 { get; }

        /// <summary>
        /// The same product with ProductValue11 omitted.
        /// </summary>
        IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12> ExceptValue11 { get; }

        /// <summary>
        /// The same product with ProductValue12 omitted.
        /// </summary>
        IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> ExceptValue12 { get; }

    }

    /// <summary>
    /// A 13-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct13<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// Value of the product in the dimension 11.
        /// </summary>
        T11 ProductValue11 { get; }

        /// <summary>
        /// Value of the product in the dimension 12.
        /// </summary>
        T12 ProductValue12 { get; }

        /// <summary>
        /// Value of the product in the dimension 13.
        /// </summary>
        T13 ProductValue13 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct12<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct12<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct12<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13> ExceptValue10 { get; }

        /// <summary>
        /// The same product with ProductValue11 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13> ExceptValue11 { get; }

        /// <summary>
        /// The same product with ProductValue12 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13> ExceptValue12 { get; }

        /// <summary>
        /// The same product with ProductValue13 omitted.
        /// </summary>
        IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> ExceptValue13 { get; }

    }

    /// <summary>
    /// A 14-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct14<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// Value of the product in the dimension 11.
        /// </summary>
        T11 ProductValue11 { get; }

        /// <summary>
        /// Value of the product in the dimension 12.
        /// </summary>
        T12 ProductValue12 { get; }

        /// <summary>
        /// Value of the product in the dimension 13.
        /// </summary>
        T13 ProductValue13 { get; }

        /// <summary>
        /// Value of the product in the dimension 14.
        /// </summary>
        T14 ProductValue14 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct13<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct13<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct13<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14> ExceptValue10 { get; }

        /// <summary>
        /// The same product with ProductValue11 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14> ExceptValue11 { get; }

        /// <summary>
        /// The same product with ProductValue12 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14> ExceptValue12 { get; }

        /// <summary>
        /// The same product with ProductValue13 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14> ExceptValue13 { get; }

        /// <summary>
        /// The same product with ProductValue14 omitted.
        /// </summary>
        IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> ExceptValue14 { get; }

    }

    /// <summary>
    /// A 15-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct15<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// Value of the product in the dimension 11.
        /// </summary>
        T11 ProductValue11 { get; }

        /// <summary>
        /// Value of the product in the dimension 12.
        /// </summary>
        T12 ProductValue12 { get; }

        /// <summary>
        /// Value of the product in the dimension 13.
        /// </summary>
        T13 ProductValue13 { get; }

        /// <summary>
        /// Value of the product in the dimension 14.
        /// </summary>
        T14 ProductValue14 { get; }

        /// <summary>
        /// Value of the product in the dimension 15.
        /// </summary>
        T15 ProductValue15 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct14<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct14<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct14<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15> ExceptValue10 { get; }

        /// <summary>
        /// The same product with ProductValue11 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15> ExceptValue11 { get; }

        /// <summary>
        /// The same product with ProductValue12 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15> ExceptValue12 { get; }

        /// <summary>
        /// The same product with ProductValue13 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15> ExceptValue13 { get; }

        /// <summary>
        /// The same product with ProductValue14 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15> ExceptValue14 { get; }

        /// <summary>
        /// The same product with ProductValue15 omitted.
        /// </summary>
        IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> ExceptValue15 { get; }

    }

    /// <summary>
    /// A 16-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct16<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// Value of the product in the dimension 11.
        /// </summary>
        T11 ProductValue11 { get; }

        /// <summary>
        /// Value of the product in the dimension 12.
        /// </summary>
        T12 ProductValue12 { get; }

        /// <summary>
        /// Value of the product in the dimension 13.
        /// </summary>
        T13 ProductValue13 { get; }

        /// <summary>
        /// Value of the product in the dimension 14.
        /// </summary>
        T14 ProductValue14 { get; }

        /// <summary>
        /// Value of the product in the dimension 15.
        /// </summary>
        T15 ProductValue15 { get; }

        /// <summary>
        /// Value of the product in the dimension 16.
        /// </summary>
        T16 ProductValue16 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct15<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct15<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct15<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15, T16> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15, T16> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15, T16> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15, T16> ExceptValue10 { get; }

        /// <summary>
        /// The same product with ProductValue11 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15, T16> ExceptValue11 { get; }

        /// <summary>
        /// The same product with ProductValue12 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15, T16> ExceptValue12 { get; }

        /// <summary>
        /// The same product with ProductValue13 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15, T16> ExceptValue13 { get; }

        /// <summary>
        /// The same product with ProductValue14 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15, T16> ExceptValue14 { get; }

        /// <summary>
        /// The same product with ProductValue15 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T16> ExceptValue15 { get; }

        /// <summary>
        /// The same product with ProductValue16 omitted.
        /// </summary>
        IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> ExceptValue16 { get; }

    }

    /// <summary>
    /// A 17-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct17<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// Value of the product in the dimension 11.
        /// </summary>
        T11 ProductValue11 { get; }

        /// <summary>
        /// Value of the product in the dimension 12.
        /// </summary>
        T12 ProductValue12 { get; }

        /// <summary>
        /// Value of the product in the dimension 13.
        /// </summary>
        T13 ProductValue13 { get; }

        /// <summary>
        /// Value of the product in the dimension 14.
        /// </summary>
        T14 ProductValue14 { get; }

        /// <summary>
        /// Value of the product in the dimension 15.
        /// </summary>
        T15 ProductValue15 { get; }

        /// <summary>
        /// Value of the product in the dimension 16.
        /// </summary>
        T16 ProductValue16 { get; }

        /// <summary>
        /// Value of the product in the dimension 17.
        /// </summary>
        T17 ProductValue17 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct16<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct16<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct16<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15, T16, T17> ExceptValue10 { get; }

        /// <summary>
        /// The same product with ProductValue11 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15, T16, T17> ExceptValue11 { get; }

        /// <summary>
        /// The same product with ProductValue12 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15, T16, T17> ExceptValue12 { get; }

        /// <summary>
        /// The same product with ProductValue13 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15, T16, T17> ExceptValue13 { get; }

        /// <summary>
        /// The same product with ProductValue14 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15, T16, T17> ExceptValue14 { get; }

        /// <summary>
        /// The same product with ProductValue15 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T16, T17> ExceptValue15 { get; }

        /// <summary>
        /// The same product with ProductValue16 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T17> ExceptValue16 { get; }

        /// <summary>
        /// The same product with ProductValue17 omitted.
        /// </summary>
        IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> ExceptValue17 { get; }

    }

    /// <summary>
    /// A 18-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct18<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17, out T18> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// Value of the product in the dimension 11.
        /// </summary>
        T11 ProductValue11 { get; }

        /// <summary>
        /// Value of the product in the dimension 12.
        /// </summary>
        T12 ProductValue12 { get; }

        /// <summary>
        /// Value of the product in the dimension 13.
        /// </summary>
        T13 ProductValue13 { get; }

        /// <summary>
        /// Value of the product in the dimension 14.
        /// </summary>
        T14 ProductValue14 { get; }

        /// <summary>
        /// Value of the product in the dimension 15.
        /// </summary>
        T15 ProductValue15 { get; }

        /// <summary>
        /// Value of the product in the dimension 16.
        /// </summary>
        T16 ProductValue16 { get; }

        /// <summary>
        /// Value of the product in the dimension 17.
        /// </summary>
        T17 ProductValue17 { get; }

        /// <summary>
        /// Value of the product in the dimension 18.
        /// </summary>
        T18 ProductValue18 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct17<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct17<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct17<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue10 { get; }

        /// <summary>
        /// The same product with ProductValue11 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15, T16, T17, T18> ExceptValue11 { get; }

        /// <summary>
        /// The same product with ProductValue12 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15, T16, T17, T18> ExceptValue12 { get; }

        /// <summary>
        /// The same product with ProductValue13 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15, T16, T17, T18> ExceptValue13 { get; }

        /// <summary>
        /// The same product with ProductValue14 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15, T16, T17, T18> ExceptValue14 { get; }

        /// <summary>
        /// The same product with ProductValue15 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T16, T17, T18> ExceptValue15 { get; }

        /// <summary>
        /// The same product with ProductValue16 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T17, T18> ExceptValue16 { get; }

        /// <summary>
        /// The same product with ProductValue17 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T18> ExceptValue17 { get; }

        /// <summary>
        /// The same product with ProductValue18 omitted.
        /// </summary>
        IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> ExceptValue18 { get; }

    }

    /// <summary>
    /// A 19-dimensional strongly-typed product.
    /// </summary>
    public interface IProduct19<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17, out T18, out T19> : IProduct
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
        /// Value of the product in the dimension 10.
        /// </summary>
        T10 ProductValue10 { get; }

        /// <summary>
        /// Value of the product in the dimension 11.
        /// </summary>
        T11 ProductValue11 { get; }

        /// <summary>
        /// Value of the product in the dimension 12.
        /// </summary>
        T12 ProductValue12 { get; }

        /// <summary>
        /// Value of the product in the dimension 13.
        /// </summary>
        T13 ProductValue13 { get; }

        /// <summary>
        /// Value of the product in the dimension 14.
        /// </summary>
        T14 ProductValue14 { get; }

        /// <summary>
        /// Value of the product in the dimension 15.
        /// </summary>
        T15 ProductValue15 { get; }

        /// <summary>
        /// Value of the product in the dimension 16.
        /// </summary>
        T16 ProductValue16 { get; }

        /// <summary>
        /// Value of the product in the dimension 17.
        /// </summary>
        T17 ProductValue17 { get; }

        /// <summary>
        /// Value of the product in the dimension 18.
        /// </summary>
        T18 ProductValue18 { get; }

        /// <summary>
        /// Value of the product in the dimension 19.
        /// </summary>
        T19 ProductValue19 { get; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        IProduct18<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue1 { get; }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        IProduct18<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue2 { get; }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        IProduct18<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue3 { get; }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue4 { get; }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue5 { get; }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue6 { get; }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue7 { get; }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue8 { get; }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue9 { get; }

        /// <summary>
        /// The same product with ProductValue10 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue10 { get; }

        /// <summary>
        /// The same product with ProductValue11 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15, T16, T17, T18, T19> ExceptValue11 { get; }

        /// <summary>
        /// The same product with ProductValue12 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15, T16, T17, T18, T19> ExceptValue12 { get; }

        /// <summary>
        /// The same product with ProductValue13 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15, T16, T17, T18, T19> ExceptValue13 { get; }

        /// <summary>
        /// The same product with ProductValue14 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15, T16, T17, T18, T19> ExceptValue14 { get; }

        /// <summary>
        /// The same product with ProductValue15 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T16, T17, T18, T19> ExceptValue15 { get; }

        /// <summary>
        /// The same product with ProductValue16 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T17, T18, T19> ExceptValue16 { get; }

        /// <summary>
        /// The same product with ProductValue17 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T18, T19> ExceptValue17 { get; }

        /// <summary>
        /// The same product with ProductValue18 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T19> ExceptValue18 { get; }

        /// <summary>
        /// The same product with ProductValue19 omitted.
        /// </summary>
        IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ExceptValue19 { get; }

    }

}