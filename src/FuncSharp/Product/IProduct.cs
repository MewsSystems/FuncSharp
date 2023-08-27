using System;
using System.Collections.Generic;

namespace FuncSharp;

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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> f);
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
    /// Invokes the specified function with the product values as its parameters and returns its result.
    /// </summary>
    R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> f);

    /// <summary>
    /// Invokes the specified function with the product values as its parameters.
    /// </summary>
    void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> f);
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

}

/// <summary>
/// A 20-dimensional strongly-typed product.
/// </summary>
public interface IProduct20<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17, out T18, out T19, out T20> : IProduct
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
    /// Value of the product in the dimension 20.
    /// </summary>
    T20 ProductValue20 { get; }

}