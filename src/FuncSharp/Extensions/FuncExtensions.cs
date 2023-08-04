
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

    }
}

