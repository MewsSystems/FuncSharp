using System;

namespace FuncSharp
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Casts the specified object to the given type.
        /// </summary>
        public static IOption<A> As<A>(this object o)
            where A : class
        {
            return (o as A).ToOption();
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
        /// Turns the specified value into an option.
        /// </summary>
        public static IOption<A> ToOption<A>(this A value)
        {
            return Option.Create(value);
        }

        /// <summary>
        /// Turns the specified value into a successful try.
        /// </summary>
        public static ITry<A> ToTry<A>(this A value)
        {
            return Try.Success(value);
        }

        /// <summary>
        /// Turns the specified exception into a try.
        /// </summary>
        public static ITry<A> ToTry<A>(this Exception e)
        {
            return Try.Error<A>(e);
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T1, TResult>(
            this object value,
            T1 t1, Func<T1, TResult> f1)
        {
            return value.AsCoproduct(t1).Match(f1);
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
        /// Creates a new 1-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct1<T1> AsCoproduct<T1>(this object value, T1 t1, Func<object, ICoproduct1<T1>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
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
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 1 specified values.");
        }

        /// <summary>
        /// Creates a new 2-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct2<T1, object> AsSafeCoproduct<T1>(this object value)
        {
            return value.AsCoproduct(v => Coproduct.CreateSecond<T1, object>(v));
        }

        /// <summary>
        /// Creates a new 2-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct2<T1, object> AsSafeCoproduct<T1>(this object value, T1 t1)
        {
            return value.AsCoproduct(t1, null, v => Coproduct.CreateSecond<T1, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T1, T2, TResult>(
            this object value,
            T1 t1, Func<T1, TResult> f1,
            T2 t2, Func<T2, TResult> f2)
        {
            return value.AsCoproduct(t1, t2).Match(f1, f2);
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
        /// Creates a new 2-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct2<T1, T2> AsCoproduct<T1, T2>(this object value, T1 t1, T2 t2, Func<object, ICoproduct2<T1, T2>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct.CreateFirst<T1, T2>((T1)value);
            }
            if (Equals(value, t2))
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
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 2 specified values.");
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct3<T1, T2, object> AsSafeCoproduct<T1, T2>(this object value)
        {
            return value.AsCoproduct(v => Coproduct.CreateThird<T1, T2, object>(v));
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct3<T1, T2, object> AsSafeCoproduct<T1, T2>(this object value, T1 t1, T2 t2)
        {
            return value.AsCoproduct(t1, t2, null, v => Coproduct.CreateThird<T1, T2, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T1, T2, T3, TResult>(
            this object value,
            T1 t1, Func<T1, TResult> f1,
            T2 t2, Func<T2, TResult> f2,
            T3 t3, Func<T3, TResult> f3)
        {
            return value.AsCoproduct(t1, t2, t3).Match(f1, f2, f3);
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
        /// Creates a new 3-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct3<T1, T2, T3> AsCoproduct<T1, T2, T3>(this object value, T1 t1, T2 t2, T3 t3, Func<object, ICoproduct3<T1, T2, T3>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct.CreateFirst<T1, T2, T3>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct.CreateSecond<T1, T2, T3>((T2)value);
            }
            if (Equals(value, t3))
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
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 3 specified values.");
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct4<T1, T2, T3, object> AsSafeCoproduct<T1, T2, T3>(this object value)
        {
            return value.AsCoproduct(v => Coproduct.CreateFourth<T1, T2, T3, object>(v));
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct4<T1, T2, T3, object> AsSafeCoproduct<T1, T2, T3>(this object value, T1 t1, T2 t2, T3 t3)
        {
            return value.AsCoproduct(t1, t2, t3, null, v => Coproduct.CreateFourth<T1, T2, T3, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T1, T2, T3, T4, TResult>(
            this object value,
            T1 t1, Func<T1, TResult> f1,
            T2 t2, Func<T2, TResult> f2,
            T3 t3, Func<T3, TResult> f3,
            T4 t4, Func<T4, TResult> f4)
        {
            return value.AsCoproduct(t1, t2, t3, t4).Match(f1, f2, f3, f4);
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
        /// Creates a new 4-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct4<T1, T2, T3, T4> AsCoproduct<T1, T2, T3, T4>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, Func<object, ICoproduct4<T1, T2, T3, T4>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct.CreateThird<T1, T2, T3, T4>((T3)value);
            }
            if (Equals(value, t4))
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
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 4 specified values.");
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, object> AsSafeCoproduct<T1, T2, T3, T4>(this object value)
        {
            return value.AsCoproduct(v => Coproduct.CreateFifth<T1, T2, T3, T4, object>(v));
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, object> AsSafeCoproduct<T1, T2, T3, T4>(this object value, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return value.AsCoproduct(t1, t2, t3, t4, null, v => Coproduct.CreateFifth<T1, T2, T3, T4, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T1, T2, T3, T4, T5, TResult>(
            this object value,
            T1 t1, Func<T1, TResult> f1,
            T2 t2, Func<T2, TResult> f2,
            T3 t3, Func<T3, TResult> f3,
            T4 t4, Func<T4, TResult> f4,
            T5 t5, Func<T5, TResult> f5)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5).Match(f1, f2, f3, f4, f5);
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
        /// Creates a new 5-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, T5> AsCoproduct<T1, T2, T3, T4, T5>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, Func<object, ICoproduct5<T1, T2, T3, T4, T5>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5>((T4)value);
            }
            if (Equals(value, t5))
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
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 5 specified values.");
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, object> AsSafeCoproduct<T1, T2, T3, T4, T5>(this object value)
        {
            return value.AsCoproduct(v => Coproduct.CreateSixth<T1, T2, T3, T4, T5, object>(v));
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, object> AsSafeCoproduct<T1, T2, T3, T4, T5>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, null, v => Coproduct.CreateSixth<T1, T2, T3, T4, T5, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T1, T2, T3, T4, T5, T6, TResult>(
            this object value,
            T1 t1, Func<T1, TResult> f1,
            T2 t2, Func<T2, TResult> f2,
            T3 t3, Func<T3, TResult> f3,
            T4 t4, Func<T4, TResult> f4,
            T5 t5, Func<T5, TResult> f5,
            T6 t6, Func<T6, TResult> f6)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6).Match(f1, f2, f3, f4, f5, f6);
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
        /// Creates a new 6-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, T6> AsCoproduct<T1, T2, T3, T4, T5, T6>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, Func<object, ICoproduct6<T1, T2, T3, T4, T5, T6>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5, T6>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5, T6>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5, T6>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5, T6>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct.CreateFifth<T1, T2, T3, T4, T5, T6>((T5)value);
            }
            if (Equals(value, t6))
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
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 6 specified values.");
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6>(this object value)
        {
            return value.AsCoproduct(v => Coproduct.CreateSeventh<T1, T2, T3, T4, T5, T6, object>(v));
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, null, v => Coproduct.CreateSeventh<T1, T2, T3, T4, T5, T6, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this object value,
            T1 t1, Func<T1, TResult> f1,
            T2 t2, Func<T2, TResult> f2,
            T3 t3, Func<T3, TResult> f3,
            T4 t4, Func<T4, TResult> f4,
            T5 t5, Func<T5, TResult> f5,
            T6 t6, Func<T6, TResult> f6,
            T7 t7, Func<T7, TResult> f7)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7).Match(f1, f2, f3, f4, f5, f6, f7);
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
        /// Creates a new 7-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, T7> AsCoproduct<T1, T2, T3, T4, T5, T6, T7>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, Func<object, ICoproduct7<T1, T2, T3, T4, T5, T6, T7>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5, T6, T7>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5, T6, T7>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5, T6, T7>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5, T6, T7>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct.CreateFifth<T1, T2, T3, T4, T5, T6, T7>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct.CreateSixth<T1, T2, T3, T4, T5, T6, T7>((T6)value);
            }
            if (Equals(value, t7))
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
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 7 specified values.");
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7>(this object value)
        {
            return value.AsCoproduct(v => Coproduct.CreateEighth<T1, T2, T3, T4, T5, T6, T7, object>(v));
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, null, v => Coproduct.CreateEighth<T1, T2, T3, T4, T5, T6, T7, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this object value,
            T1 t1, Func<T1, TResult> f1,
            T2 t2, Func<T2, TResult> f2,
            T3 t3, Func<T3, TResult> f3,
            T4 t4, Func<T4, TResult> f4,
            T5 t5, Func<T5, TResult> f5,
            T6 t6, Func<T6, TResult> f6,
            T7 t7, Func<T7, TResult> f7,
            T8 t8, Func<T8, TResult> f8)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8).Match(f1, f2, f3, f4, f5, f6, f7, f8);
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
        /// Creates a new 8-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, Func<object, ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>((T7)value);
            }
            if (Equals(value, t8))
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
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 8 specified values.");
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8>(this object value)
        {
            return value.AsCoproduct(v => Coproduct.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, object>(v));
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, null, v => Coproduct.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this object value,
            T1 t1, Func<T1, TResult> f1,
            T2 t2, Func<T2, TResult> f2,
            T3 t3, Func<T3, TResult> f3,
            T4 t4, Func<T4, TResult> f4,
            T5 t5, Func<T5, TResult> f5,
            T6 t6, Func<T6, TResult> f6,
            T7 t7, Func<T7, TResult> f7,
            T8 t8, Func<T8, TResult> f8,
            T9 t9, Func<T9, TResult> f9)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9);
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

        /// <summary>
        /// Creates a new 9-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, Func<object, ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T8)value);
            }
            if (Equals(value, t9))
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
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 9 specified values.");
        }

    }
}