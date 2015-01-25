using System;

namespace FuncSharp
{
    public partial class Union
    {
        /// <summary>
        /// Creates a new 1-dimensional union with the first value.
        /// </summary>
        public static Union1<T1> CreateFirst<T1>(T1 t1)
        {
            return new Union1<T1>(1, t1);
        }

        /// <summary>
        /// Creates a new 2-dimensional union with the second value.
        /// </summary>
        public static Union2<T1, T2> CreateFirst<T1, T2>(T1 t1)
        {
            return new Union2<T1, T2>(1, t1);
        }

        /// <summary>
        /// Creates a new 2-dimensional union with the second value.
        /// </summary>
        public static Union2<T1, T2> CreateSecond<T1, T2>(T2 t2)
        {
            return new Union2<T1, T2>(2, t2);
        }

        /// <summary>
        /// Creates a new 3-dimensional union with the third value.
        /// </summary>
        public static Union3<T1, T2, T3> CreateFirst<T1, T2, T3>(T1 t1)
        {
            return new Union3<T1, T2, T3>(1, t1);
        }

        /// <summary>
        /// Creates a new 3-dimensional union with the third value.
        /// </summary>
        public static Union3<T1, T2, T3> CreateSecond<T1, T2, T3>(T2 t2)
        {
            return new Union3<T1, T2, T3>(2, t2);
        }

        /// <summary>
        /// Creates a new 3-dimensional union with the third value.
        /// </summary>
        public static Union3<T1, T2, T3> CreateThird<T1, T2, T3>(T3 t3)
        {
            return new Union3<T1, T2, T3>(3, t3);
        }

        /// <summary>
        /// Creates a new 4-dimensional union with the fourth value.
        /// </summary>
        public static Union4<T1, T2, T3, T4> CreateFirst<T1, T2, T3, T4>(T1 t1)
        {
            return new Union4<T1, T2, T3, T4>(1, t1);
        }

        /// <summary>
        /// Creates a new 4-dimensional union with the fourth value.
        /// </summary>
        public static Union4<T1, T2, T3, T4> CreateSecond<T1, T2, T3, T4>(T2 t2)
        {
            return new Union4<T1, T2, T3, T4>(2, t2);
        }

        /// <summary>
        /// Creates a new 4-dimensional union with the fourth value.
        /// </summary>
        public static Union4<T1, T2, T3, T4> CreateThird<T1, T2, T3, T4>(T3 t3)
        {
            return new Union4<T1, T2, T3, T4>(3, t3);
        }

        /// <summary>
        /// Creates a new 4-dimensional union with the fourth value.
        /// </summary>
        public static Union4<T1, T2, T3, T4> CreateFourth<T1, T2, T3, T4>(T4 t4)
        {
            return new Union4<T1, T2, T3, T4>(4, t4);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the fifth value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> CreateFirst<T1, T2, T3, T4, T5>(T1 t1)
        {
            return new Union5<T1, T2, T3, T4, T5>(1, t1);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the fifth value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> CreateSecond<T1, T2, T3, T4, T5>(T2 t2)
        {
            return new Union5<T1, T2, T3, T4, T5>(2, t2);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the fifth value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> CreateThird<T1, T2, T3, T4, T5>(T3 t3)
        {
            return new Union5<T1, T2, T3, T4, T5>(3, t3);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the fifth value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> CreateFourth<T1, T2, T3, T4, T5>(T4 t4)
        {
            return new Union5<T1, T2, T3, T4, T5>(4, t4);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the fifth value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> CreateFifth<T1, T2, T3, T4, T5>(T5 t5)
        {
            return new Union5<T1, T2, T3, T4, T5>(5, t5);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the sixth value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> CreateFirst<T1, T2, T3, T4, T5, T6>(T1 t1)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(1, t1);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the sixth value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> CreateSecond<T1, T2, T3, T4, T5, T6>(T2 t2)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(2, t2);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the sixth value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> CreateThird<T1, T2, T3, T4, T5, T6>(T3 t3)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(3, t3);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the sixth value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> CreateFourth<T1, T2, T3, T4, T5, T6>(T4 t4)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(4, t4);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the sixth value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> CreateFifth<T1, T2, T3, T4, T5, T6>(T5 t5)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(5, t5);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the sixth value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> CreateSixth<T1, T2, T3, T4, T5, T6>(T6 t6)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(6, t6);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the seventh value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> CreateFirst<T1, T2, T3, T4, T5, T6, T7>(T1 t1)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(1, t1);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the seventh value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> CreateSecond<T1, T2, T3, T4, T5, T6, T7>(T2 t2)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(2, t2);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the seventh value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> CreateThird<T1, T2, T3, T4, T5, T6, T7>(T3 t3)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(3, t3);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the seventh value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> CreateFourth<T1, T2, T3, T4, T5, T6, T7>(T4 t4)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(4, t4);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the seventh value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> CreateFifth<T1, T2, T3, T4, T5, T6, T7>(T5 t5)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(5, t5);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the seventh value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> CreateSixth<T1, T2, T3, T4, T5, T6, T7>(T6 t6)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(6, t6);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the seventh value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> CreateSeventh<T1, T2, T3, T4, T5, T6, T7>(T7 t7)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(7, t7);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the eighth value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(1, t1);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the eighth value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>(T2 t2)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(2, t2);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the eighth value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>(T3 t3)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(3, t3);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the eighth value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>(T4 t4)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(4, t4);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the eighth value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>(T5 t5)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(5, t5);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the eighth value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>(T6 t6)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(6, t6);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the eighth value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>(T7 t7)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(7, t7);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the eighth value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8>(T8 t8)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(8, t8);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the ninth value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(1, t1);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the ninth value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 t2)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(2, t2);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the ninth value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 t3)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(3, t3);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the ninth value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 t4)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(4, t4);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the ninth value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 t5)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(5, t5);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the ninth value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 t6)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(6, t6);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the ninth value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 t7)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(7, t7);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the ninth value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 t8)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(8, t8);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the ninth value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 t9)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(9, t9);
        }

        /// <summary>
        /// Creates a new 0-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union0 Typed(object value)
        {
            return Typed(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 0 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 0-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union0 Typed(object value, Func<object, Union0> otherwise)
        {
            return otherwise(value);
        }

        /// <summary>
        /// Creates a new 1-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union1<object> TypedSafe(object value)
        {
            return Typed<object>(value, v =>
            {
                return CreateFirst<object>(v);
            });
        }

        /// <summary>
        /// Creates a new 1-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union1<T1> Typed<T1>(object value)
        {
            return Typed<T1>(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 1 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 1-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union1<T1> Typed<T1>(object value, Func<object, Union1<T1>> otherwise)
        {
            if (value is T1)
            {
                return CreateFirst<T1>((T1)value);
            }
            return otherwise(value);
        }

        /// <summary>
        /// Creates a new 2-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union2<T1, object> TypedSafe<T1>(object value)
        {
            return Typed<T1, object>(value, v =>
            {
                return CreateSecond<T1, object>(v);
            });
        }

        /// <summary>
        /// Creates a new 2-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union2<T1, T2> Typed<T1, T2>(object value)
        {
            return Typed<T1, T2>(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 2 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 2-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union2<T1, T2> Typed<T1, T2>(object value, Func<object, Union2<T1, T2>> otherwise)
        {
            if (value is T1)
            {
                return CreateFirst<T1, T2>((T1)value);
            }
            if (value is T2)
            {
                return CreateSecond<T1, T2>((T2)value);
            }
            return otherwise(value);
        }

        /// <summary>
        /// Creates a new 3-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union3<T1, T2, object> TypedSafe<T1, T2>(object value)
        {
            return Typed<T1, T2, object>(value, v =>
            {
                return CreateThird<T1, T2, object>(v);
            });
        }

        /// <summary>
        /// Creates a new 3-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union3<T1, T2, T3> Typed<T1, T2, T3>(object value)
        {
            return Typed<T1, T2, T3>(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 3 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 3-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union3<T1, T2, T3> Typed<T1, T2, T3>(object value, Func<object, Union3<T1, T2, T3>> otherwise)
        {
            if (value is T1)
            {
                return CreateFirst<T1, T2, T3>((T1)value);
            }
            if (value is T2)
            {
                return CreateSecond<T1, T2, T3>((T2)value);
            }
            if (value is T3)
            {
                return CreateThird<T1, T2, T3>((T3)value);
            }
            return otherwise(value);
        }

        /// <summary>
        /// Creates a new 4-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union4<T1, T2, T3, object> TypedSafe<T1, T2, T3>(object value)
        {
            return Typed<T1, T2, T3, object>(value, v =>
            {
                return CreateFourth<T1, T2, T3, object>(v);
            });
        }

        /// <summary>
        /// Creates a new 4-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union4<T1, T2, T3, T4> Typed<T1, T2, T3, T4>(object value)
        {
            return Typed<T1, T2, T3, T4>(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 4 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 4-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union4<T1, T2, T3, T4> Typed<T1, T2, T3, T4>(object value, Func<object, Union4<T1, T2, T3, T4>> otherwise)
        {
            if (value is T1)
            {
                return CreateFirst<T1, T2, T3, T4>((T1)value);
            }
            if (value is T2)
            {
                return CreateSecond<T1, T2, T3, T4>((T2)value);
            }
            if (value is T3)
            {
                return CreateThird<T1, T2, T3, T4>((T3)value);
            }
            if (value is T4)
            {
                return CreateFourth<T1, T2, T3, T4>((T4)value);
            }
            return otherwise(value);
        }

        /// <summary>
        /// Creates a new 5-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union5<T1, T2, T3, T4, object> TypedSafe<T1, T2, T3, T4>(object value)
        {
            return Typed<T1, T2, T3, T4, object>(value, v =>
            {
                return CreateFifth<T1, T2, T3, T4, object>(v);
            });
        }

        /// <summary>
        /// Creates a new 5-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> Typed<T1, T2, T3, T4, T5>(object value)
        {
            return Typed<T1, T2, T3, T4, T5>(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 5 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 5-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> Typed<T1, T2, T3, T4, T5>(object value, Func<object, Union5<T1, T2, T3, T4, T5>> otherwise)
        {
            if (value is T1)
            {
                return CreateFirst<T1, T2, T3, T4, T5>((T1)value);
            }
            if (value is T2)
            {
                return CreateSecond<T1, T2, T3, T4, T5>((T2)value);
            }
            if (value is T3)
            {
                return CreateThird<T1, T2, T3, T4, T5>((T3)value);
            }
            if (value is T4)
            {
                return CreateFourth<T1, T2, T3, T4, T5>((T4)value);
            }
            if (value is T5)
            {
                return CreateFifth<T1, T2, T3, T4, T5>((T5)value);
            }
            return otherwise(value);
        }

        /// <summary>
        /// Creates a new 6-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, object> TypedSafe<T1, T2, T3, T4, T5>(object value)
        {
            return Typed<T1, T2, T3, T4, T5, object>(value, v =>
            {
                return CreateSixth<T1, T2, T3, T4, T5, object>(v);
            });
        }

        /// <summary>
        /// Creates a new 6-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> Typed<T1, T2, T3, T4, T5, T6>(object value)
        {
            return Typed<T1, T2, T3, T4, T5, T6>(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 6 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 6-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> Typed<T1, T2, T3, T4, T5, T6>(object value, Func<object, Union6<T1, T2, T3, T4, T5, T6>> otherwise)
        {
            if (value is T1)
            {
                return CreateFirst<T1, T2, T3, T4, T5, T6>((T1)value);
            }
            if (value is T2)
            {
                return CreateSecond<T1, T2, T3, T4, T5, T6>((T2)value);
            }
            if (value is T3)
            {
                return CreateThird<T1, T2, T3, T4, T5, T6>((T3)value);
            }
            if (value is T4)
            {
                return CreateFourth<T1, T2, T3, T4, T5, T6>((T4)value);
            }
            if (value is T5)
            {
                return CreateFifth<T1, T2, T3, T4, T5, T6>((T5)value);
            }
            if (value is T6)
            {
                return CreateSixth<T1, T2, T3, T4, T5, T6>((T6)value);
            }
            return otherwise(value);
        }

        /// <summary>
        /// Creates a new 7-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, object> TypedSafe<T1, T2, T3, T4, T5, T6>(object value)
        {
            return Typed<T1, T2, T3, T4, T5, T6, object>(value, v =>
            {
                return CreateSeventh<T1, T2, T3, T4, T5, T6, object>(v);
            });
        }

        /// <summary>
        /// Creates a new 7-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> Typed<T1, T2, T3, T4, T5, T6, T7>(object value)
        {
            return Typed<T1, T2, T3, T4, T5, T6, T7>(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 7 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 7-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> Typed<T1, T2, T3, T4, T5, T6, T7>(object value, Func<object, Union7<T1, T2, T3, T4, T5, T6, T7>> otherwise)
        {
            if (value is T1)
            {
                return CreateFirst<T1, T2, T3, T4, T5, T6, T7>((T1)value);
            }
            if (value is T2)
            {
                return CreateSecond<T1, T2, T3, T4, T5, T6, T7>((T2)value);
            }
            if (value is T3)
            {
                return CreateThird<T1, T2, T3, T4, T5, T6, T7>((T3)value);
            }
            if (value is T4)
            {
                return CreateFourth<T1, T2, T3, T4, T5, T6, T7>((T4)value);
            }
            if (value is T5)
            {
                return CreateFifth<T1, T2, T3, T4, T5, T6, T7>((T5)value);
            }
            if (value is T6)
            {
                return CreateSixth<T1, T2, T3, T4, T5, T6, T7>((T6)value);
            }
            if (value is T7)
            {
                return CreateSeventh<T1, T2, T3, T4, T5, T6, T7>((T7)value);
            }
            return otherwise(value);
        }

        /// <summary>
        /// Creates a new 8-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, object> TypedSafe<T1, T2, T3, T4, T5, T6, T7>(object value)
        {
            return Typed<T1, T2, T3, T4, T5, T6, T7, object>(value, v =>
            {
                return CreateEighth<T1, T2, T3, T4, T5, T6, T7, object>(v);
            });
        }

        /// <summary>
        /// Creates a new 8-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Typed<T1, T2, T3, T4, T5, T6, T7, T8>(object value)
        {
            return Typed<T1, T2, T3, T4, T5, T6, T7, T8>(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 8 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 8-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Typed<T1, T2, T3, T4, T5, T6, T7, T8>(object value, Func<object, Union8<T1, T2, T3, T4, T5, T6, T7, T8>> otherwise)
        {
            if (value is T1)
            {
                return CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>((T1)value);
            }
            if (value is T2)
            {
                return CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>((T2)value);
            }
            if (value is T3)
            {
                return CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>((T3)value);
            }
            if (value is T4)
            {
                return CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>((T4)value);
            }
            if (value is T5)
            {
                return CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>((T5)value);
            }
            if (value is T6)
            {
                return CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>((T6)value);
            }
            if (value is T7)
            {
                return CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>((T7)value);
            }
            if (value is T8)
            {
                return CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8>((T8)value);
            }
            return otherwise(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, object> TypedSafe<T1, T2, T3, T4, T5, T6, T7, T8>(object value)
        {
            return Typed<T1, T2, T3, T4, T5, T6, T7, T8, object>(value, v =>
            {
                return CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, object>(v);
            });
        }

        /// <summary>
        /// Creates a new 9-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, throws an exception.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Typed<T1, T2, T3, T4, T5, T6, T7, T8, T9>(object value)
        {
            return Typed<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value, v =>
            {
                throw new ArgumentException("The value " + v.SafeToString() + " does not match any of the 9 specified types.");
            });
        }

        /// <summary>
        /// Creates a new 9-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Typed<T1, T2, T3, T4, T5, T6, T7, T8, T9>(object value, Func<object, Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> otherwise)
        {
            if (value is T1)
            {
                return CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T1)value);
            }
            if (value is T2)
            {
                return CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T2)value);
            }
            if (value is T3)
            {
                return CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T3)value);
            }
            if (value is T4)
            {
                return CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T4)value);
            }
            if (value is T5)
            {
                return CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T5)value);
            }
            if (value is T6)
            {
                return CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T6)value);
            }
            if (value is T7)
            {
                return CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T7)value);
            }
            if (value is T8)
            {
                return CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T8)value);
            }
            if (value is T9)
            {
                return CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T9)value);
            }
            return otherwise(value);
        }

    }

    /// <summary>
    /// A 0-dimensional union.
    /// </summary> 
    public class Union0 : Union
    {
        /// <summary>
        /// Creates a new 0-dimensional union.
        /// </summary>
        internal Union0(int discriminator, object value)
            : base(0, discriminator, value)
        {
        }
    }

    /// <summary>
    /// A 1-dimensional union.
    /// </summary> 
    public class Union1<T1> : Union
    {
        /// <summary>
        /// Creates a new 1-dimensional union.
        /// </summary>
        internal Union1(int discriminator, object value)
            : base(1, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the first value.
        /// </summary>
        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns first value of the union as an option. The option contains the first value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T1> First
        {
            get
            { 
                return PartialMatch(
                    ifFirst: v => Option.Some(v),
                    otherwise: _ => Option.None<T1>()
                );
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value. E.g. if the union is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        public R Match<R>(
            Func<T1, R> ifFirst)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                default: return default(R); // Never happens.
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v)
            );
        }
    }

    /// <summary>
    /// A 2-dimensional union.
    /// </summary> 
    public class Union2<T1, T2> : Union
    {
        /// <summary>
        /// Creates a new 2-dimensional union.
        /// </summary>
        internal Union2(int discriminator, object value)
            : base(2, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the first value.
        /// </summary>
        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns first value of the union as an option. The option contains the first value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T1> First
        {
            get
            { 
                return PartialMatch(
                    ifFirst: v => Option.Some(v),
                    otherwise: _ => Option.None<T1>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the second value.
        /// </summary>
        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns second value of the union as an option. The option contains the second value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T2> Second
        {
            get
            { 
                return PartialMatch(
                    ifSecond: v => Option.Some(v),
                    otherwise: _ => Option.None<T2>()
                );
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value. E.g. if the union is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                default: return default(R); // Never happens.
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v)
            );
        }
    }

    /// <summary>
    /// A 3-dimensional union.
    /// </summary> 
    public class Union3<T1, T2, T3> : Union
    {
        /// <summary>
        /// Creates a new 3-dimensional union.
        /// </summary>
        internal Union3(int discriminator, object value)
            : base(3, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the first value.
        /// </summary>
        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns first value of the union as an option. The option contains the first value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T1> First
        {
            get
            { 
                return PartialMatch(
                    ifFirst: v => Option.Some(v),
                    otherwise: _ => Option.None<T1>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the second value.
        /// </summary>
        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns second value of the union as an option. The option contains the second value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T2> Second
        {
            get
            { 
                return PartialMatch(
                    ifSecond: v => Option.Some(v),
                    otherwise: _ => Option.None<T2>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the third value.
        /// </summary>
        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns third value of the union as an option. The option contains the third value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T3> Third
        {
            get
            { 
                return PartialMatch(
                    ifThird: v => Option.Some(v),
                    otherwise: _ => Option.None<T3>()
                );
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value. E.g. if the union is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                default: return default(R); // Never happens.
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v)
            );
        }
    }

    /// <summary>
    /// A 4-dimensional union.
    /// </summary> 
    public class Union4<T1, T2, T3, T4> : Union
    {
        /// <summary>
        /// Creates a new 4-dimensional union.
        /// </summary>
        internal Union4(int discriminator, object value)
            : base(4, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the first value.
        /// </summary>
        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns first value of the union as an option. The option contains the first value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T1> First
        {
            get
            { 
                return PartialMatch(
                    ifFirst: v => Option.Some(v),
                    otherwise: _ => Option.None<T1>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the second value.
        /// </summary>
        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns second value of the union as an option. The option contains the second value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T2> Second
        {
            get
            { 
                return PartialMatch(
                    ifSecond: v => Option.Some(v),
                    otherwise: _ => Option.None<T2>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the third value.
        /// </summary>
        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns third value of the union as an option. The option contains the third value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T3> Third
        {
            get
            { 
                return PartialMatch(
                    ifThird: v => Option.Some(v),
                    otherwise: _ => Option.None<T3>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fourth value.
        /// </summary>
        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns fourth value of the union as an option. The option contains the fourth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T4> Fourth
        {
            get
            { 
                return PartialMatch(
                    ifFourth: v => Option.Some(v),
                    otherwise: _ => Option.None<T4>()
                );
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value. E.g. if the union is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                default: return default(R); // Never happens.
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v)
            );
        }
    }

    /// <summary>
    /// A 5-dimensional union.
    /// </summary> 
    public class Union5<T1, T2, T3, T4, T5> : Union
    {
        /// <summary>
        /// Creates a new 5-dimensional union.
        /// </summary>
        internal Union5(int discriminator, object value)
            : base(5, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the first value.
        /// </summary>
        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns first value of the union as an option. The option contains the first value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T1> First
        {
            get
            { 
                return PartialMatch(
                    ifFirst: v => Option.Some(v),
                    otherwise: _ => Option.None<T1>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the second value.
        /// </summary>
        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns second value of the union as an option. The option contains the second value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T2> Second
        {
            get
            { 
                return PartialMatch(
                    ifSecond: v => Option.Some(v),
                    otherwise: _ => Option.None<T2>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the third value.
        /// </summary>
        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns third value of the union as an option. The option contains the third value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T3> Third
        {
            get
            { 
                return PartialMatch(
                    ifThird: v => Option.Some(v),
                    otherwise: _ => Option.None<T3>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fourth value.
        /// </summary>
        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns fourth value of the union as an option. The option contains the fourth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T4> Fourth
        {
            get
            { 
                return PartialMatch(
                    ifFourth: v => Option.Some(v),
                    otherwise: _ => Option.None<T4>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fifth value.
        /// </summary>
        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        /// <summary>
        /// Returns fifth value of the union as an option. The option contains the fifth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T5> Fifth
        {
            get
            { 
                return PartialMatch(
                    ifFifth: v => Option.Some(v),
                    otherwise: _ => Option.None<T5>()
                );
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value. E.g. if the union is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                default: return default(R); // Never happens.
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v)
            );
        }
    }

    /// <summary>
    /// A 6-dimensional union.
    /// </summary> 
    public class Union6<T1, T2, T3, T4, T5, T6> : Union
    {
        /// <summary>
        /// Creates a new 6-dimensional union.
        /// </summary>
        internal Union6(int discriminator, object value)
            : base(6, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the first value.
        /// </summary>
        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns first value of the union as an option. The option contains the first value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T1> First
        {
            get
            { 
                return PartialMatch(
                    ifFirst: v => Option.Some(v),
                    otherwise: _ => Option.None<T1>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the second value.
        /// </summary>
        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns second value of the union as an option. The option contains the second value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T2> Second
        {
            get
            { 
                return PartialMatch(
                    ifSecond: v => Option.Some(v),
                    otherwise: _ => Option.None<T2>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the third value.
        /// </summary>
        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns third value of the union as an option. The option contains the third value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T3> Third
        {
            get
            { 
                return PartialMatch(
                    ifThird: v => Option.Some(v),
                    otherwise: _ => Option.None<T3>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fourth value.
        /// </summary>
        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns fourth value of the union as an option. The option contains the fourth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T4> Fourth
        {
            get
            { 
                return PartialMatch(
                    ifFourth: v => Option.Some(v),
                    otherwise: _ => Option.None<T4>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fifth value.
        /// </summary>
        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        /// <summary>
        /// Returns fifth value of the union as an option. The option contains the fifth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T5> Fifth
        {
            get
            { 
                return PartialMatch(
                    ifFifth: v => Option.Some(v),
                    otherwise: _ => Option.None<T5>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the sixth value.
        /// </summary>
        public bool IsSixth
        {
            get { return SumDiscriminator == 6; }
        }

        /// <summary>
        /// Returns sixth value of the union as an option. The option contains the sixth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T6> Sixth
        {
            get
            { 
                return PartialMatch(
                    ifSixth: v => Option.Some(v),
                    otherwise: _ => Option.None<T6>()
                );
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value. E.g. if the union is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                case 6: return ifSixth(GetSumValue<T6>());
                default: return default(R); // Never happens.
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v),
                v => ifSixth == null ? otherwise(v) : ifSixth(v)
            );
        }
    }

    /// <summary>
    /// A 7-dimensional union.
    /// </summary> 
    public class Union7<T1, T2, T3, T4, T5, T6, T7> : Union
    {
        /// <summary>
        /// Creates a new 7-dimensional union.
        /// </summary>
        internal Union7(int discriminator, object value)
            : base(7, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the first value.
        /// </summary>
        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns first value of the union as an option. The option contains the first value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T1> First
        {
            get
            { 
                return PartialMatch(
                    ifFirst: v => Option.Some(v),
                    otherwise: _ => Option.None<T1>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the second value.
        /// </summary>
        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns second value of the union as an option. The option contains the second value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T2> Second
        {
            get
            { 
                return PartialMatch(
                    ifSecond: v => Option.Some(v),
                    otherwise: _ => Option.None<T2>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the third value.
        /// </summary>
        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns third value of the union as an option. The option contains the third value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T3> Third
        {
            get
            { 
                return PartialMatch(
                    ifThird: v => Option.Some(v),
                    otherwise: _ => Option.None<T3>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fourth value.
        /// </summary>
        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns fourth value of the union as an option. The option contains the fourth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T4> Fourth
        {
            get
            { 
                return PartialMatch(
                    ifFourth: v => Option.Some(v),
                    otherwise: _ => Option.None<T4>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fifth value.
        /// </summary>
        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        /// <summary>
        /// Returns fifth value of the union as an option. The option contains the fifth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T5> Fifth
        {
            get
            { 
                return PartialMatch(
                    ifFifth: v => Option.Some(v),
                    otherwise: _ => Option.None<T5>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the sixth value.
        /// </summary>
        public bool IsSixth
        {
            get { return SumDiscriminator == 6; }
        }

        /// <summary>
        /// Returns sixth value of the union as an option. The option contains the sixth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T6> Sixth
        {
            get
            { 
                return PartialMatch(
                    ifSixth: v => Option.Some(v),
                    otherwise: _ => Option.None<T6>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the seventh value.
        /// </summary>
        public bool IsSeventh
        {
            get { return SumDiscriminator == 7; }
        }

        /// <summary>
        /// Returns seventh value of the union as an option. The option contains the seventh value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T7> Seventh
        {
            get
            { 
                return PartialMatch(
                    ifSeventh: v => Option.Some(v),
                    otherwise: _ => Option.None<T7>()
                );
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value. E.g. if the union is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                case 6: return ifSixth(GetSumValue<T6>());
                case 7: return ifSeventh(GetSumValue<T7>());
                default: return default(R); // Never happens.
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<T7, R> ifSeventh = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v),
                v => ifSixth == null ? otherwise(v) : ifSixth(v),
                v => ifSeventh == null ? otherwise(v) : ifSeventh(v)
            );
        }
    }

    /// <summary>
    /// A 8-dimensional union.
    /// </summary> 
    public class Union8<T1, T2, T3, T4, T5, T6, T7, T8> : Union
    {
        /// <summary>
        /// Creates a new 8-dimensional union.
        /// </summary>
        internal Union8(int discriminator, object value)
            : base(8, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the first value.
        /// </summary>
        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns first value of the union as an option. The option contains the first value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T1> First
        {
            get
            { 
                return PartialMatch(
                    ifFirst: v => Option.Some(v),
                    otherwise: _ => Option.None<T1>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the second value.
        /// </summary>
        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns second value of the union as an option. The option contains the second value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T2> Second
        {
            get
            { 
                return PartialMatch(
                    ifSecond: v => Option.Some(v),
                    otherwise: _ => Option.None<T2>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the third value.
        /// </summary>
        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns third value of the union as an option. The option contains the third value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T3> Third
        {
            get
            { 
                return PartialMatch(
                    ifThird: v => Option.Some(v),
                    otherwise: _ => Option.None<T3>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fourth value.
        /// </summary>
        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns fourth value of the union as an option. The option contains the fourth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T4> Fourth
        {
            get
            { 
                return PartialMatch(
                    ifFourth: v => Option.Some(v),
                    otherwise: _ => Option.None<T4>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fifth value.
        /// </summary>
        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        /// <summary>
        /// Returns fifth value of the union as an option. The option contains the fifth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T5> Fifth
        {
            get
            { 
                return PartialMatch(
                    ifFifth: v => Option.Some(v),
                    otherwise: _ => Option.None<T5>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the sixth value.
        /// </summary>
        public bool IsSixth
        {
            get { return SumDiscriminator == 6; }
        }

        /// <summary>
        /// Returns sixth value of the union as an option. The option contains the sixth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T6> Sixth
        {
            get
            { 
                return PartialMatch(
                    ifSixth: v => Option.Some(v),
                    otherwise: _ => Option.None<T6>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the seventh value.
        /// </summary>
        public bool IsSeventh
        {
            get { return SumDiscriminator == 7; }
        }

        /// <summary>
        /// Returns seventh value of the union as an option. The option contains the seventh value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T7> Seventh
        {
            get
            { 
                return PartialMatch(
                    ifSeventh: v => Option.Some(v),
                    otherwise: _ => Option.None<T7>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the eighth value.
        /// </summary>
        public bool IsEighth
        {
            get { return SumDiscriminator == 8; }
        }

        /// <summary>
        /// Returns eighth value of the union as an option. The option contains the eighth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T8> Eighth
        {
            get
            { 
                return PartialMatch(
                    ifEighth: v => Option.Some(v),
                    otherwise: _ => Option.None<T8>()
                );
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value. E.g. if the union is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                case 6: return ifSixth(GetSumValue<T6>());
                case 7: return ifSeventh(GetSumValue<T7>());
                case 8: return ifEighth(GetSumValue<T8>());
                default: return default(R); // Never happens.
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<T7, R> ifSeventh = null,
            Func<T8, R> ifEighth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v),
                v => ifSixth == null ? otherwise(v) : ifSixth(v),
                v => ifSeventh == null ? otherwise(v) : ifSeventh(v),
                v => ifEighth == null ? otherwise(v) : ifEighth(v)
            );
        }
    }

    /// <summary>
    /// A 9-dimensional union.
    /// </summary> 
    public class Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Union
    {
        /// <summary>
        /// Creates a new 9-dimensional union.
        /// </summary>
        internal Union9(int discriminator, object value)
            : base(9, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the first value.
        /// </summary>
        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns first value of the union as an option. The option contains the first value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T1> First
        {
            get
            { 
                return PartialMatch(
                    ifFirst: v => Option.Some(v),
                    otherwise: _ => Option.None<T1>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the second value.
        /// </summary>
        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns second value of the union as an option. The option contains the second value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T2> Second
        {
            get
            { 
                return PartialMatch(
                    ifSecond: v => Option.Some(v),
                    otherwise: _ => Option.None<T2>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the third value.
        /// </summary>
        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns third value of the union as an option. The option contains the third value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T3> Third
        {
            get
            { 
                return PartialMatch(
                    ifThird: v => Option.Some(v),
                    otherwise: _ => Option.None<T3>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fourth value.
        /// </summary>
        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns fourth value of the union as an option. The option contains the fourth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T4> Fourth
        {
            get
            { 
                return PartialMatch(
                    ifFourth: v => Option.Some(v),
                    otherwise: _ => Option.None<T4>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the fifth value.
        /// </summary>
        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        /// <summary>
        /// Returns fifth value of the union as an option. The option contains the fifth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T5> Fifth
        {
            get
            { 
                return PartialMatch(
                    ifFifth: v => Option.Some(v),
                    otherwise: _ => Option.None<T5>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the sixth value.
        /// </summary>
        public bool IsSixth
        {
            get { return SumDiscriminator == 6; }
        }

        /// <summary>
        /// Returns sixth value of the union as an option. The option contains the sixth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T6> Sixth
        {
            get
            { 
                return PartialMatch(
                    ifSixth: v => Option.Some(v),
                    otherwise: _ => Option.None<T6>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the seventh value.
        /// </summary>
        public bool IsSeventh
        {
            get { return SumDiscriminator == 7; }
        }

        /// <summary>
        /// Returns seventh value of the union as an option. The option contains the seventh value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T7> Seventh
        {
            get
            { 
                return PartialMatch(
                    ifSeventh: v => Option.Some(v),
                    otherwise: _ => Option.None<T7>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the eighth value.
        /// </summary>
        public bool IsEighth
        {
            get { return SumDiscriminator == 8; }
        }

        /// <summary>
        /// Returns eighth value of the union as an option. The option contains the eighth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T8> Eighth
        {
            get
            { 
                return PartialMatch(
                    ifEighth: v => Option.Some(v),
                    otherwise: _ => Option.None<T8>()
                );
            }
        }

        /// <summary>
        /// Returns whether the union contains the ninth value.
        /// </summary>
        public bool IsNinth
        {
            get { return SumDiscriminator == 9; }
        }

        /// <summary>
        /// Returns ninth value of the union as an option. The option contains the ninth value
        /// or is empty if the union contains different value.
        /// </summary>
        public IOption<T9> Ninth
        {
            get
            { 
                return PartialMatch(
                    ifNinth: v => Option.Some(v),
                    otherwise: _ => Option.None<T9>()
                );
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value. E.g. if the union is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                case 6: return ifSixth(GetSumValue<T6>());
                case 7: return ifSeventh(GetSumValue<T7>());
                case 8: return ifEighth(GetSumValue<T8>());
                case 9: return ifNinth(GetSumValue<T9>());
                default: return default(R); // Never happens.
            }
        }

        /// <summary>
        /// Returns result of a function that corresponds to the union value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<T7, R> ifSeventh = null,
            Func<T8, R> ifEighth = null,
            Func<T9, R> ifNinth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v),
                v => ifSixth == null ? otherwise(v) : ifSixth(v),
                v => ifSeventh == null ? otherwise(v) : ifSeventh(v),
                v => ifEighth == null ? otherwise(v) : ifEighth(v),
                v => ifNinth == null ? otherwise(v) : ifNinth(v)
            );
        }
    }

}

