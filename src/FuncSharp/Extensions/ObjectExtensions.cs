using System;

namespace FuncSharp
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Casts the specified object to the given type.
        /// </summary>
        public static IOption<T> As<T>(this object o)
            where T : class
        {
            return (o as T).ToOption();
        }

        /// <summary>
        /// Returns string representation of the object. If the object is null, return the optionally specified null text.
        /// </summary>
        public static string SafeToString(this object o, string nullText = "null")
        {
            if (o == null)
            {
                return nullText;
            }
            return o.ToString();
        }

        /// <summary>
        /// Turns the specified value into a definite. Throws an exception if the value is null. 
        /// </summary>
        public static IDefinite<T> ToDefinite<T>(this T value)
        {
            return Definite.Create(value);    
        }

        /// <summary>
        /// Turns the specified value into an option.
        /// </summary>
        public static IOption<T> ToOption<T>(this T value)
        {
            return Option.Create(value);
        }

        /// <summary>
        /// Creates a new 0-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct0 AsCoproduct(this object value, Func<object, ICoproduct0> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 0 specified types.");
        }

        /// <summary>
        /// Creates a new 1-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct1<object> AsSafeCoproduct(this object value)
        {
            return value.AsCoproduct<object>(v => Coproduct.CreateFirst<object>(v));
        }

        /// <summary>
        /// Creates a new 1-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct1<T1> AsCoproduct<T1>(this object value, Func<object, ICoproduct1<T1>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct.CreateFirst<T1>((T1)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 1 specified types.");
        }

        /// <summary>
        /// Creates a new 2-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct2<T1, object> AsSafeCoproduct<T1>(this object value)
        {
            return value.AsCoproduct<T1, object>(v => Coproduct.CreateSecond<T1, object>(v));
        }

        /// <summary>
        /// Creates a new 2-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct2<T1, T2> AsCoproduct<T1, T2>(this object value, Func<object, ICoproduct2<T1, T2>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct.CreateFirst<T1, T2>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct.CreateSecond<T1, T2>((T2)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 2 specified types.");
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct3<T1, T2, object> AsSafeCoproduct<T1, T2>(this object value)
        {
            return value.AsCoproduct<T1, T2, object>(v => Coproduct.CreateThird<T1, T2, object>(v));
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct3<T1, T2, T3> AsCoproduct<T1, T2, T3>(this object value, Func<object, ICoproduct3<T1, T2, T3>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct.CreateFirst<T1, T2, T3>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct.CreateSecond<T1, T2, T3>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct.CreateThird<T1, T2, T3>((T3)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 3 specified types.");
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct4<T1, T2, T3, object> AsSafeCoproduct<T1, T2, T3>(this object value)
        {
            return value.AsCoproduct<T1, T2, T3, object>(v => Coproduct.CreateFourth<T1, T2, T3, object>(v));
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct4<T1, T2, T3, T4> AsCoproduct<T1, T2, T3, T4>(this object value, Func<object, ICoproduct4<T1, T2, T3, T4>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct.CreateThird<T1, T2, T3, T4>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4>((T4)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 4 specified types.");
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, object> AsSafeCoproduct<T1, T2, T3, T4>(this object value)
        {
            return value.AsCoproduct<T1, T2, T3, T4, object>(v => Coproduct.CreateFifth<T1, T2, T3, T4, object>(v));
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, T5> AsCoproduct<T1, T2, T3, T4, T5>(this object value, Func<object, ICoproduct5<T1, T2, T3, T4, T5>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct.CreateFifth<T1, T2, T3, T4, T5>((T5)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 5 specified types.");
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, object> AsSafeCoproduct<T1, T2, T3, T4, T5>(this object value)
        {
            return value.AsCoproduct<T1, T2, T3, T4, T5, object>(v => Coproduct.CreateSixth<T1, T2, T3, T4, T5, object>(v));
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, T6> AsCoproduct<T1, T2, T3, T4, T5, T6>(this object value, Func<object, ICoproduct6<T1, T2, T3, T4, T5, T6>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5, T6>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5, T6>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5, T6>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5, T6>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct.CreateFifth<T1, T2, T3, T4, T5, T6>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct.CreateSixth<T1, T2, T3, T4, T5, T6>((T6)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 6 specified types.");
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6>(this object value)
        {
            return value.AsCoproduct<T1, T2, T3, T4, T5, T6, object>(v => Coproduct.CreateSeventh<T1, T2, T3, T4, T5, T6, object>(v));
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, T7> AsCoproduct<T1, T2, T3, T4, T5, T6, T7>(this object value, Func<object, ICoproduct7<T1, T2, T3, T4, T5, T6, T7>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5, T6, T7>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5, T6, T7>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5, T6, T7>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5, T6, T7>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct.CreateFifth<T1, T2, T3, T4, T5, T6, T7>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct.CreateSixth<T1, T2, T3, T4, T5, T6, T7>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct.CreateSeventh<T1, T2, T3, T4, T5, T6, T7>((T7)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 7 specified types.");
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7>(this object value)
        {
            return value.AsCoproduct<T1, T2, T3, T4, T5, T6, T7, object>(v => Coproduct.CreateEighth<T1, T2, T3, T4, T5, T6, T7, object>(v));
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8>(this object value, Func<object, ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8>((T8)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 8 specified types.");
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8>(this object value)
        {
            return value.AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, object>(v => Coproduct.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, object>(v));
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this object value, Func<object, ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T9)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 9 specified types.");
        }

    }
}