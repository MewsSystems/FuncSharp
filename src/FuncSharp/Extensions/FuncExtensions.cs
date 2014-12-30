using System;

namespace FuncSharp
{
    public static class FuncExtensions
    {
        /// <summary>
        /// Converts the specified function to a function that takes 0-dimensional vector as its only parameter instead of
        /// 0 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector0, TResult> Normalized<TResult>(this Func<TResult> f)
        {
            return v => f();
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<TResult> Denormalized<TResult>(this Func<Vector0, TResult> f)
        {
            return () => f(Vector.Create());
        }
        /// <summary>
        /// Converts the specified function to a function that takes 1-dimensional vector as its only parameter instead of
        /// 1 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector1<T1>, TResult> Normalized<T1, TResult>(this Func<T1, TResult> f)
        {
            return v => f(v.Value1);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, TResult> Denormalized<T1, TResult>(this Func<Vector1<T1>, TResult> f)
        {
            return (t1) => f(Vector.Create(t1));
        }
        /// <summary>
        /// Converts the specified function to a function that takes 2-dimensional vector as its only parameter instead of
        /// 2 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector2<T1, T2>, TResult> Normalized<T1, T2, TResult>(this Func<T1, T2, TResult> f)
        {
            return v => f(v.Value1, v.Value2);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, TResult> Denormalized<T1, T2, TResult>(this Func<Vector2<T1, T2>, TResult> f)
        {
            return (t1, t2) => f(Vector.Create(t1, t2));
        }
        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, TResult>> Curried<T1, T2, TResult>(this Func<T1, T2, TResult> f)
        {
            return t1 => t2 => f(t1, t2);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 3-dimensional vector as its only parameter instead of
        /// 3 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector3<T1, T2, T3>, TResult> Normalized<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> f)
        {
            return v => f(v.Value1, v.Value2, v.Value3);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, TResult> Denormalized<T1, T2, T3, TResult>(this Func<Vector3<T1, T2, T3>, TResult> f)
        {
            return (t1, t2, t3) => f(Vector.Create(t1, t2, t3));
        }
        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, TResult>>> Curried<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> f)
        {
            return t1 => t2 => t3 => f(t1, t2, t3);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 4-dimensional vector as its only parameter instead of
        /// 4 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector4<T1, T2, T3, T4>, TResult> Normalized<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> f)
        {
            return v => f(v.Value1, v.Value2, v.Value3, v.Value4);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, TResult> Denormalized<T1, T2, T3, T4, TResult>(this Func<Vector4<T1, T2, T3, T4>, TResult> f)
        {
            return (t1, t2, t3, t4) => f(Vector.Create(t1, t2, t3, t4));
        }
        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curried<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> f)
        {
            return t1 => t2 => t3 => t4 => f(t1, t2, t3, t4);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 5-dimensional vector as its only parameter instead of
        /// 5 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector5<T1, T2, T3, T4, T5>, TResult> Normalized<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> f)
        {
            return v => f(v.Value1, v.Value2, v.Value3, v.Value4, v.Value5);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, TResult> Denormalized<T1, T2, T3, T4, T5, TResult>(this Func<Vector5<T1, T2, T3, T4, T5>, TResult> f)
        {
            return (t1, t2, t3, t4, t5) => f(Vector.Create(t1, t2, t3, t4, t5));
        }
        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> Curried<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => f(t1, t2, t3, t4, t5);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 6-dimensional vector as its only parameter instead of
        /// 6 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector6<T1, T2, T3, T4, T5, T6>, TResult> Normalized<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> f)
        {
            return v => f(v.Value1, v.Value2, v.Value3, v.Value4, v.Value5, v.Value6);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, TResult> Denormalized<T1, T2, T3, T4, T5, T6, TResult>(this Func<Vector6<T1, T2, T3, T4, T5, T6>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6) => f(Vector.Create(t1, t2, t3, t4, t5, t6));
        }
        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, TResult>>>>>> Curried<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => f(t1, t2, t3, t4, t5, t6);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 7-dimensional vector as its only parameter instead of
        /// 7 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector7<T1, T2, T3, T4, T5, T6, T7>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> f)
        {
            return v => f(v.Value1, v.Value2, v.Value3, v.Value4, v.Value5, v.Value6, v.Value7);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<Vector7<T1, T2, T3, T4, T5, T6, T7>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => f(Vector.Create(t1, t2, t3, t4, t5, t6, t7));
        }
        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, TResult>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => f(t1, t2, t3, t4, t5, t6, t7);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 8-dimensional vector as its only parameter instead of
        /// 8 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector8<T1, T2, T3, T4, T5, T6, T7, T8>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> f)
        {
            return v => f(v.Value1, v.Value2, v.Value3, v.Value4, v.Value5, v.Value6, v.Value7, v.Value8);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<Vector8<T1, T2, T3, T4, T5, T6, T7, T8>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8) => f(Vector.Create(t1, t2, t3, t4, t5, t6, t7, t8));
        }
        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, TResult>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => f(t1, t2, t3, t4, t5, t6, t7, t8);
        }

        /// <summary>
        /// Converts the specified function to a function that takes 9-dimensional vector as its only parameter instead of
        /// 9 parameters. That allows you to abstract over functions with different arity.
        /// </summary>
        public static Func<Vector9<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TResult> Normalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> f)
        {
            return v => f(v.Value1, v.Value2, v.Value3, v.Value4, v.Value5, v.Value6, v.Value7, v.Value8, v.Value9);
        }

        /// <summary>
        /// Converts the specified normalized function back to a standard function used in .NET.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Denormalized<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<Vector9<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TResult> f)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8, t9) => f(Vector.Create(t1, t2, t3, t4, t5, t6, t7, t8, t9));
        }
        /// <summary>
        /// Returnd curried version of the specified function.
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, TResult>>>>>>>>> Curried<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> f)
        {
            return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => t9 => f(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }

    }
}

