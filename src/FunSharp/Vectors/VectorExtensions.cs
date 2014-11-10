using System;

namespace FuncSharp
{
    /// <summary>
    /// Extensions of the vectors and conversions of .NET classes to/from vectors.
    /// </summary>
    public static class VectorExtensions
    {
        /// <summary>
        /// Converts the vector into a tuple.
        /// </summary>
        public static Tuple<T1> ToTuple<T1>(this Vector1<T1> v)
        {
            return Tuple.Create(v.Value1);
        }

        /// <summary>
        /// Converts the tuple into a vector.
        /// </summary>
        public static Vector1<T1> ToVector<T1>(this Tuple<T1> t)
        {
            return Vector.Create(t.Item1);
        }

        /// <summary>
        /// Converts the vector into a tuple.
        /// </summary>
        public static Tuple<T1, T2> ToTuple<T1, T2>(this Vector2<T1, T2> v)
        {
            return Tuple.Create(v.Value1, v.Value2);
        }

        /// <summary>
        /// Converts the tuple into a vector.
        /// </summary>
        public static Vector2<T1, T2> ToVector<T1, T2>(this Tuple<T1, T2> t)
        {
            return Vector.Create(t.Item1, t.Item2);
        }

        /// <summary>
        /// Converts the vector into a tuple.
        /// </summary>
        public static Tuple<T1, T2, T3> ToTuple<T1, T2, T3>(this Vector3<T1, T2, T3> v)
        {
            return Tuple.Create(v.Value1, v.Value2, v.Value3);
        }

        /// <summary>
        /// Converts the tuple into a vector.
        /// </summary>
        public static Vector3<T1, T2, T3> ToVector<T1, T2, T3>(this Tuple<T1, T2, T3> t)
        {
            return Vector.Create(t.Item1, t.Item2, t.Item3);
        }

        /// <summary>
        /// Converts the vector into a tuple.
        /// </summary>
        public static Tuple<T1, T2, T3, T4> ToTuple<T1, T2, T3, T4>(this Vector4<T1, T2, T3, T4> v)
        {
            return Tuple.Create(v.Value1, v.Value2, v.Value3, v.Value4);
        }

        /// <summary>
        /// Converts the tuple into a vector.
        /// </summary>
        public static Vector4<T1, T2, T3, T4> ToVector<T1, T2, T3, T4>(this Tuple<T1, T2, T3, T4> t)
        {
            return Vector.Create(t.Item1, t.Item2, t.Item3, t.Item4);
        }

        /// <summary>
        /// Converts the vector into a tuple.
        /// </summary>
        public static Tuple<T1, T2, T3, T4, T5> ToTuple<T1, T2, T3, T4, T5>(this Vector5<T1, T2, T3, T4, T5> v)
        {
            return Tuple.Create(v.Value1, v.Value2, v.Value3, v.Value4, v.Value5);
        }

        /// <summary>
        /// Converts the tuple into a vector.
        /// </summary>
        public static Vector5<T1, T2, T3, T4, T5> ToVector<T1, T2, T3, T4, T5>(this Tuple<T1, T2, T3, T4, T5> t)
        {
            return Vector.Create(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5);
        }

    }
}
