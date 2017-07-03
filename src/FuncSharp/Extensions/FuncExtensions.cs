using System;

namespace FuncSharp
{
    public static class FuncExtensions
    {
        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action ToAction(this Func<Unit> f)
        {
            return () => f();
        }

        /// <summary>
        /// Converts the specified function to a function that takes 0-dimensional product as its only parameter instead of
        /// 0 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct0, TResult> Normalized<TResult>(this Func<TResult> f)
        {
            return p => f();
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<TResult> Denormalized<TResult>(this Func<IProduct0, TResult> f)
        {
            return () => f(Product0.Create());
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1> ToAction<T1>(this Func<T1, Unit> f)
        {
            return (t1) => f(t1);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 1-dimensional product as its only parameter instead of
        /// 1 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct1<T1>, TResult> Normalized<T1, TResult>(this Func<T1, TResult> f)
        {
            return p => f(p.ProductValue1);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, TResult> Denormalized<T1, TResult>(this Func<IProduct1<T1>, TResult> f)
        {
            return (t1) => f(Product1.Create(t1));
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2> ToAction<T1, T2>(this Func<T1, T2, Unit> f)
        {
            return (t1, t2) => f(t1, t2);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 2-dimensional product as its only parameter instead of
        /// 2 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct2<T1, T2>, TResult> Normalized<T1, T2, TResult>(this Func<T1, T2, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, TResult> Denormalized<T1, T2, TResult>(this Func<IProduct2<T1, T2>, TResult> f)
        {
            return (t1, t2) => f(Product2.Create(t1, t2));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, TResult>> Curried<T1, T2, TResult>(this Func<T1, T2, TResult> f)
        {
            return t1 => t2 => f(t1, t2);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3> ToAction<T1, T2, T3>(this Func<T1, T2, T3, Unit> f)
        {
            return (t1, t2, t3) => f(t1, t2, t3);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 3-dimensional product as its only parameter instead of
        /// 3 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct3<T1, T2, T3>, TResult> Normalized<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, TResult> Denormalized<T1, T2, T3, TResult>(this Func<IProduct3<T1, T2, T3>, TResult> f)
        {
            return (t1, t2, t3) => f(Product3.Create(t1, t2, t3));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, TResult>>> Curried<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> f)
        {
            return t1 => t2 => t3 => f(t1, t2, t3);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4> ToAction<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Unit> f)
        {
            return (t1, t2, t3, t4) => f(t1, t2, t3, t4);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 4-dimensional product as its only parameter instead of
        /// 4 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct4<T1, T2, T3, T4>, TResult> Normalized<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, TResult> Denormalized<T1, T2, T3, T4, TResult>(this Func<IProduct4<T1, T2, T3, T4>, TResult> f)
        {
            return (t1, t2, t3, t4) => f(Product4.Create(t1, t2, t3, t4));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curried<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> f)
        {
            return t1 => t2 => t3 => t4 => f(t1, t2, t3, t4);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> ToAction<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5, Unit> f)
        {
            return (t1, t2, t3, t4, t5) => f(t1, t2, t3, t4, t5);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 5-dimensional product as its only parameter instead of
        /// 5 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct5<T1, T2, T3, T4, T5>, TResult> Normalized<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, TResult> Denormalized<T1, T2, T3, T4, T5, TResult>(this Func<IProduct5<T1, T2, T3, T4, T5>, TResult> f)
        {
            return (t1, t2, t3, t4, t5) => f(Product5.Create(t1, t2, t3, t4, t5));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> Curried<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => f(t1, t2, t3, t4, t5);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> ToAction<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6) => f(t1, t2, t3, t4, t5, t6);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 6-dimensional product as its only parameter instead of
        /// 6 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct6<T1, T2, T3, T4, T5, T6>, TResult> Normalized<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, TResult> Denormalized<T1, T2, T3, T4, T5, T6, TResult>(this Func<IProduct6<T1, T2, T3, T4, T5, T6>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6) => f(Product6.Create(t1, t2, t3, t4, t5, t6));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, TResult>>>>>> Curried<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => f(t1, t2, t3, t4, t5, t6);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> ToAction<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => f(t1, t2, t3, t4, t5, t6, t7);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 7-dimensional product as its only parameter instead of
        /// 7 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct7<T1, T2, T3, T4, T5, T6, T7>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<IProduct7<T1, T2, T3, T4, T5, T6, T7>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => f(Product7.Create(t1, t2, t3, t4, t5, t6, t7));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, TResult>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => f(t1, t2, t3, t4, t5, t6, t7);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> ToAction<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8) => f(t1, t2, t3, t4, t5, t6, t7, t8);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 8-dimensional product as its only parameter instead of
        /// 8 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct8<T1, T2, T3, T4, T5, T6, T7, T8>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<IProduct8<T1, T2, T3, T4, T5, T6, T7, T8>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8) => f(Product8.Create(t1, t2, t3, t4, t5, t6, t7, t8));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, TResult>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => f(t1, t2, t3, t4, t5, t6, t7, t8);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9) => f(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 9-dimensional product as its only parameter instead of
        /// 9 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9) => f(Product9.Create(t1, t2, t3, t4, t5, t6, t7, t8, t9));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, TResult>>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => f(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10) => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 10-dimensional product as its only parameter instead of
        /// 10 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<IProduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10) => f(Product10.Create(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, TResult>>>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11) => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 11-dimensional product as its only parameter instead of
        /// 11 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Func<IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11) => f(Product11.Create(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, TResult>>>>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12) => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 12-dimensional product as its only parameter instead of
        /// 12 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Func<IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12) => f(Product12.Create(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, TResult>>>>>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => t12 => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13) => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 13-dimensional product as its only parameter instead of
        /// 13 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Func<IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13) => f(Product13.Create(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, TResult>>>>>>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => t12 => t13 => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14) => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 14-dimensional product as its only parameter instead of
        /// 14 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Func<IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14) => f(Product14.Create(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, TResult>>>>>>>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => t12 => t13 => t14 => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
        }

        /// <summary>
        /// Converts the specified function that returns unit into a corresponding action.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Unit> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15) => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 15-dimensional product as its only parameter instead of
        /// 15 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> f)
        {
            return p => f(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Func<IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15) => f(Product15.Create(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15));
        }

        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, Func<T15, TResult>>>>>>>>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => t10 => t11 => t12 => t13 => t14 => t15 => f(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
        }

    }
}

