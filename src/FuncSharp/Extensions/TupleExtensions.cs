using System;

namespace FuncSharp
{
    public static class TupleExtensions
    {
        /// <summary>
        /// Converts the specified tuple into a vector.
        /// </summary>
        public static Vector1<T1> ToVector<T1>(this Tuple<T1> t)
        {
            return Vector.Create(t.Item1);
        }

        /// <summary>
        /// Converts the specified tuple into a vector.
        /// </summary>
        public static Vector2<T1, T2> ToVector<T1, T2>(this Tuple<T1, T2> t)
        {
            return Vector.Create(t.Item1, t.Item2);
        }

        /// <summary>
        /// Converts the specified tuple into a vector.
        /// </summary>
        public static Vector3<T1, T2, T3> ToVector<T1, T2, T3>(this Tuple<T1, T2, T3> t)
        {
            return Vector.Create(t.Item1, t.Item2, t.Item3);
        }

        /// <summary>
        /// Converts the specified tuple into a vector.
        /// </summary>
        public static Vector4<T1, T2, T3, T4> ToVector<T1, T2, T3, T4>(this Tuple<T1, T2, T3, T4> t)
        {
            return Vector.Create(t.Item1, t.Item2, t.Item3, t.Item4);
        }

        /// <summary>
        /// Converts the specified tuple into a vector.
        /// </summary>
        public static Vector5<T1, T2, T3, T4, T5> ToVector<T1, T2, T3, T4, T5>(this Tuple<T1, T2, T3, T4, T5> t)
        {
            return Vector.Create(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5);
        }

        /// <summary>
        /// Converts the specified tuple into a vector.
        /// </summary>
        public static Vector6<T1, T2, T3, T4, T5, T6> ToVector<T1, T2, T3, T4, T5, T6>(this Tuple<T1, T2, T3, T4, T5, T6> t)
        {
            return Vector.Create(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6);
        }

        /// <summary>
        /// Converts the specified tuple into a vector.
        /// </summary>
        public static Vector7<T1, T2, T3, T4, T5, T6, T7> ToVector<T1, T2, T3, T4, T5, T6, T7>(this Tuple<T1, T2, T3, T4, T5, T6, T7> t)
        {
            return Vector.Create(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7);
        }

    }
}