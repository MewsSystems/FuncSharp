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
        /// Creates a new 1-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct1<T1> AsCoproduct<T1>(this object value, Func<object, ICoproduct1<T1>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct1.CreateFirst<T1>((T1)value);
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
                return Coproduct1.CreateFirst<T1>((T1)value);
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
            return value.AsCoproduct(v => Coproduct2.CreateSecond<T1, object>(v));
        }

        /// <summary>
        /// Creates a new 2-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct2<T1, object> AsSafeCoproduct<T1>(this object value, T1 t1)
        {
            return value.AsCoproduct(t1, null, v => Coproduct2.CreateSecond<T1, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1).Match(f1);
            }
            return value.AsSafeCoproduct(t1).Match(f1, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1).Match(f1);
            }
            else
            {
                value.AsSafeCoproduct(t1).Match(f1, _ => otherwise(value));
            }
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
                return Coproduct2.CreateFirst<T1, T2>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct2.CreateSecond<T1, T2>((T2)value);
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
                return Coproduct2.CreateFirst<T1, T2>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct2.CreateSecond<T1, T2>((T2)value);
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
            return value.AsCoproduct(v => Coproduct3.CreateThird<T1, T2, object>(v));
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct3<T1, T2, object> AsSafeCoproduct<T1, T2>(this object value, T1 t1, T2 t2)
        {
            return value.AsCoproduct(t1, t2, null, v => Coproduct3.CreateThird<T1, T2, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2).Match(f1, f2);
            }
            return value.AsSafeCoproduct(t1, t2).Match(f1, f2, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2).Match(f1, f2);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2).Match(f1, f2, _ => otherwise(value));
            }
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
                return Coproduct3.CreateFirst<T1, T2, T3>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct3.CreateSecond<T1, T2, T3>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct3.CreateThird<T1, T2, T3>((T3)value);
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
                return Coproduct3.CreateFirst<T1, T2, T3>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct3.CreateSecond<T1, T2, T3>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct3.CreateThird<T1, T2, T3>((T3)value);
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
            return value.AsCoproduct(v => Coproduct4.CreateFourth<T1, T2, T3, object>(v));
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct4<T1, T2, T3, object> AsSafeCoproduct<T1, T2, T3>(this object value, T1 t1, T2 t2, T3 t3)
        {
            return value.AsCoproduct(t1, t2, t3, null, v => Coproduct4.CreateFourth<T1, T2, T3, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3).Match(f1, f2, f3);
            }
            return value.AsSafeCoproduct(t1, t2, t3).Match(f1, f2, f3, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3).Match(f1, f2, f3);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3).Match(f1, f2, f3, _ => otherwise(value));
            }
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
                return Coproduct4.CreateFirst<T1, T2, T3, T4>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct4.CreateSecond<T1, T2, T3, T4>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct4.CreateThird<T1, T2, T3, T4>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct4.CreateFourth<T1, T2, T3, T4>((T4)value);
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
                return Coproduct4.CreateFirst<T1, T2, T3, T4>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct4.CreateSecond<T1, T2, T3, T4>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct4.CreateThird<T1, T2, T3, T4>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct4.CreateFourth<T1, T2, T3, T4>((T4)value);
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
            return value.AsCoproduct(v => Coproduct5.CreateFifth<T1, T2, T3, T4, object>(v));
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, object> AsSafeCoproduct<T1, T2, T3, T4>(this object value, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return value.AsCoproduct(t1, t2, t3, t4, null, v => Coproduct5.CreateFifth<T1, T2, T3, T4, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4).Match(f1, f2, f3, f4);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4).Match(f1, f2, f3, f4, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4).Match(f1, f2, f3, f4);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4).Match(f1, f2, f3, f4, _ => otherwise(value));
            }
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
                return Coproduct5.CreateFirst<T1, T2, T3, T4, T5>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct5.CreateSecond<T1, T2, T3, T4, T5>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct5.CreateThird<T1, T2, T3, T4, T5>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct5.CreateFourth<T1, T2, T3, T4, T5>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct5.CreateFifth<T1, T2, T3, T4, T5>((T5)value);
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
                return Coproduct5.CreateFirst<T1, T2, T3, T4, T5>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct5.CreateSecond<T1, T2, T3, T4, T5>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct5.CreateThird<T1, T2, T3, T4, T5>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct5.CreateFourth<T1, T2, T3, T4, T5>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct5.CreateFifth<T1, T2, T3, T4, T5>((T5)value);
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
            return value.AsCoproduct(v => Coproduct6.CreateSixth<T1, T2, T3, T4, T5, object>(v));
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, object> AsSafeCoproduct<T1, T2, T3, T4, T5>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, null, v => Coproduct6.CreateSixth<T1, T2, T3, T4, T5, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5).Match(f1, f2, f3, f4, f5);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5).Match(f1, f2, f3, f4, f5, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5).Match(f1, f2, f3, f4, f5);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5).Match(f1, f2, f3, f4, f5, _ => otherwise(value));
            }
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
                return Coproduct6.CreateFirst<T1, T2, T3, T4, T5, T6>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct6.CreateSecond<T1, T2, T3, T4, T5, T6>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct6.CreateThird<T1, T2, T3, T4, T5, T6>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct6.CreateFourth<T1, T2, T3, T4, T5, T6>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct6.CreateFifth<T1, T2, T3, T4, T5, T6>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct6.CreateSixth<T1, T2, T3, T4, T5, T6>((T6)value);
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
                return Coproduct6.CreateFirst<T1, T2, T3, T4, T5, T6>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct6.CreateSecond<T1, T2, T3, T4, T5, T6>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct6.CreateThird<T1, T2, T3, T4, T5, T6>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct6.CreateFourth<T1, T2, T3, T4, T5, T6>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct6.CreateFifth<T1, T2, T3, T4, T5, T6>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct6.CreateSixth<T1, T2, T3, T4, T5, T6>((T6)value);
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
            return value.AsCoproduct(v => Coproduct7.CreateSeventh<T1, T2, T3, T4, T5, T6, object>(v));
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, null, v => Coproduct7.CreateSeventh<T1, T2, T3, T4, T5, T6, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6).Match(f1, f2, f3, f4, f5, f6);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6).Match(f1, f2, f3, f4, f5, f6, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6).Match(f1, f2, f3, f4, f5, f6);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6).Match(f1, f2, f3, f4, f5, f6, _ => otherwise(value));
            }
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
                return Coproduct7.CreateFirst<T1, T2, T3, T4, T5, T6, T7>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct7.CreateSecond<T1, T2, T3, T4, T5, T6, T7>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct7.CreateThird<T1, T2, T3, T4, T5, T6, T7>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct7.CreateFourth<T1, T2, T3, T4, T5, T6, T7>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct7.CreateFifth<T1, T2, T3, T4, T5, T6, T7>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct7.CreateSixth<T1, T2, T3, T4, T5, T6, T7>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct7.CreateSeventh<T1, T2, T3, T4, T5, T6, T7>((T7)value);
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
                return Coproduct7.CreateFirst<T1, T2, T3, T4, T5, T6, T7>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct7.CreateSecond<T1, T2, T3, T4, T5, T6, T7>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct7.CreateThird<T1, T2, T3, T4, T5, T6, T7>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct7.CreateFourth<T1, T2, T3, T4, T5, T6, T7>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct7.CreateFifth<T1, T2, T3, T4, T5, T6, T7>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct7.CreateSixth<T1, T2, T3, T4, T5, T6, T7>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct7.CreateSeventh<T1, T2, T3, T4, T5, T6, T7>((T7)value);
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
            return value.AsCoproduct(v => Coproduct8.CreateEighth<T1, T2, T3, T4, T5, T6, T7, object>(v));
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, null, v => Coproduct8.CreateEighth<T1, T2, T3, T4, T5, T6, T7, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7).Match(f1, f2, f3, f4, f5, f6, f7);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7).Match(f1, f2, f3, f4, f5, f6, f7, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7).Match(f1, f2, f3, f4, f5, f6, f7);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7).Match(f1, f2, f3, f4, f5, f6, f7, _ => otherwise(value));
            }
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
                return Coproduct8.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct8.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct8.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct8.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct8.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct8.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct8.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct8.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8>((T8)value);
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
                return Coproduct8.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct8.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct8.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct8.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct8.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct8.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct8.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct8.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8>((T8)value);
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
            return value.AsCoproduct(v => Coproduct9.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, object>(v));
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, null, v => Coproduct9.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8).Match(f1, f2, f3, f4, f5, f6, f7, f8);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8).Match(f1, f2, f3, f4, f5, f6, f7, f8, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8).Match(f1, f2, f3, f4, f5, f6, f7, f8);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8).Match(f1, f2, f3, f4, f5, f6, f7, f8, _ => otherwise(value));
            }
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
                return Coproduct9.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct9.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct9.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct9.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct9.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct9.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct9.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct9.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct9.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T9)value);
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
                return Coproduct9.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct9.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct9.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct9.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct9.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct9.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct9.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct9.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct9.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T9)value);
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

        /// <summary>
        /// Creates a new 10-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this object value)
        {
            return value.AsCoproduct(v => Coproduct10.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>(v));
        }

        /// <summary>
        /// Creates a new 10-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, null, v => Coproduct10.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 10-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this object value, Func<object, ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct10.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct10.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct10.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct10.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct10.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct10.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct10.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct10.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct10.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct10.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T10)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 10 specified types.");
        }

        /// <summary>
        /// Creates a new 10-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, Func<object, ICoproduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct10.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct10.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct10.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct10.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct10.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct10.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct10.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct10.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct10.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct10.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T10)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 10 specified values.");
        }

        /// <summary>
        /// Creates a new 11-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this object value)
        {
            return value.AsCoproduct(v => Coproduct11.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>(v));
        }

        /// <summary>
        /// Creates a new 11-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, null, v => Coproduct11.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 11-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this object value, Func<object, ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct11.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct11.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct11.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct11.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct11.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct11.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct11.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct11.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct11.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct11.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T10)value);
            }
            if (value is T11)
            {
                return Coproduct11.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T11)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 11 specified types.");
        }

        /// <summary>
        /// Creates a new 11-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, Func<object, ICoproduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct11.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct11.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct11.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct11.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct11.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct11.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct11.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct11.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct11.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct11.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T10)value);
            }
            if (Equals(value, t11))
            {
                return Coproduct11.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T11)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 11 specified values.");
        }

        /// <summary>
        /// Creates a new 12-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this object value)
        {
            return value.AsCoproduct(v => Coproduct12.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>(v));
        }

        /// <summary>
        /// Creates a new 12-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, null, v => Coproduct12.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 12-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this object value, Func<object, ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct12.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct12.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct12.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct12.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct12.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct12.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct12.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct12.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct12.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct12.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T10)value);
            }
            if (value is T11)
            {
                return Coproduct12.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T11)value);
            }
            if (value is T12)
            {
                return Coproduct12.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T12)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 12 specified types.");
        }

        /// <summary>
        /// Creates a new 12-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, Func<object, ICoproduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct12.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct12.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct12.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct12.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct12.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct12.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct12.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct12.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct12.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct12.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T10)value);
            }
            if (Equals(value, t11))
            {
                return Coproduct12.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T11)value);
            }
            if (Equals(value, t12))
            {
                return Coproduct12.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T12)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 12 specified values.");
        }

        /// <summary>
        /// Creates a new 13-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this object value)
        {
            return value.AsCoproduct(v => Coproduct13.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>(v));
        }

        /// <summary>
        /// Creates a new 13-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, null, v => Coproduct13.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 13-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this object value, Func<object, ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct13.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct13.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct13.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct13.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct13.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct13.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct13.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct13.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct13.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct13.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T10)value);
            }
            if (value is T11)
            {
                return Coproduct13.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T11)value);
            }
            if (value is T12)
            {
                return Coproduct13.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T12)value);
            }
            if (value is T13)
            {
                return Coproduct13.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T13)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 13 specified types.");
        }

        /// <summary>
        /// Creates a new 13-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, Func<object, ICoproduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct13.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct13.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct13.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct13.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct13.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct13.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct13.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct13.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct13.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct13.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T10)value);
            }
            if (Equals(value, t11))
            {
                return Coproduct13.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T11)value);
            }
            if (Equals(value, t12))
            {
                return Coproduct13.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T12)value);
            }
            if (Equals(value, t13))
            {
                return Coproduct13.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T13)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 13 specified values.");
        }

        /// <summary>
        /// Creates a new 14-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this object value)
        {
            return value.AsCoproduct(v => Coproduct14.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>(v));
        }

        /// <summary>
        /// Creates a new 14-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, null, v => Coproduct14.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 14-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this object value, Func<object, ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct14.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct14.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct14.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct14.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct14.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct14.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct14.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct14.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct14.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct14.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T10)value);
            }
            if (value is T11)
            {
                return Coproduct14.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T11)value);
            }
            if (value is T12)
            {
                return Coproduct14.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T12)value);
            }
            if (value is T13)
            {
                return Coproduct14.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T13)value);
            }
            if (value is T14)
            {
                return Coproduct14.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T14)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 14 specified types.");
        }

        /// <summary>
        /// Creates a new 14-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, Func<object, ICoproduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct14.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct14.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct14.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct14.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct14.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct14.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct14.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct14.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct14.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct14.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T10)value);
            }
            if (Equals(value, t11))
            {
                return Coproduct14.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T11)value);
            }
            if (Equals(value, t12))
            {
                return Coproduct14.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T12)value);
            }
            if (Equals(value, t13))
            {
                return Coproduct14.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T13)value);
            }
            if (Equals(value, t14))
            {
                return Coproduct14.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T14)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 14 specified values.");
        }

        /// <summary>
        /// Creates a new 15-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this object value)
        {
            return value.AsCoproduct(v => Coproduct15.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>(v));
        }

        /// <summary>
        /// Creates a new 15-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, null, v => Coproduct15.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 15-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this object value, Func<object, ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct15.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct15.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct15.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct15.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct15.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct15.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct15.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct15.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct15.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct15.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T10)value);
            }
            if (value is T11)
            {
                return Coproduct15.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T11)value);
            }
            if (value is T12)
            {
                return Coproduct15.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T12)value);
            }
            if (value is T13)
            {
                return Coproduct15.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T13)value);
            }
            if (value is T14)
            {
                return Coproduct15.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T14)value);
            }
            if (value is T15)
            {
                return Coproduct15.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T15)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 15 specified types.");
        }

        /// <summary>
        /// Creates a new 15-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, Func<object, ICoproduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct15.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct15.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct15.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct15.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct15.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct15.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct15.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct15.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct15.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct15.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T10)value);
            }
            if (Equals(value, t11))
            {
                return Coproduct15.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T11)value);
            }
            if (Equals(value, t12))
            {
                return Coproduct15.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T12)value);
            }
            if (Equals(value, t13))
            {
                return Coproduct15.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T13)value);
            }
            if (Equals(value, t14))
            {
                return Coproduct15.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T14)value);
            }
            if (Equals(value, t15))
            {
                return Coproduct15.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T15)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 15 specified values.");
        }

        /// <summary>
        /// Creates a new 16-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this object value)
        {
            return value.AsCoproduct(v => Coproduct16.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>(v));
        }

        /// <summary>
        /// Creates a new 16-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, null, v => Coproduct16.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 16-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this object value, Func<object, ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct16.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct16.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct16.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct16.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct16.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct16.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct16.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct16.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct16.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct16.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T10)value);
            }
            if (value is T11)
            {
                return Coproduct16.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T11)value);
            }
            if (value is T12)
            {
                return Coproduct16.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T12)value);
            }
            if (value is T13)
            {
                return Coproduct16.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T13)value);
            }
            if (value is T14)
            {
                return Coproduct16.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T14)value);
            }
            if (value is T15)
            {
                return Coproduct16.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T15)value);
            }
            if (value is T16)
            {
                return Coproduct16.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T16)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 16 specified types.");
        }

        /// <summary>
        /// Creates a new 16-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, Func<object, ICoproduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct16.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct16.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct16.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct16.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct16.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct16.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct16.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct16.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct16.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct16.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T10)value);
            }
            if (Equals(value, t11))
            {
                return Coproduct16.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T11)value);
            }
            if (Equals(value, t12))
            {
                return Coproduct16.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T12)value);
            }
            if (Equals(value, t13))
            {
                return Coproduct16.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T13)value);
            }
            if (Equals(value, t14))
            {
                return Coproduct16.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T14)value);
            }
            if (Equals(value, t15))
            {
                return Coproduct16.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T15)value);
            }
            if (Equals(value, t16))
            {
                return Coproduct16.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T16)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 16 specified values.");
        }

        /// <summary>
        /// Creates a new 17-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this object value)
        {
            return value.AsCoproduct(v => Coproduct17.CreateSeventeenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, object>(v));
        }

        /// <summary>
        /// Creates a new 17-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, null, v => Coproduct17.CreateSeventeenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
            T t16, Func<T, TResult> f16,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
            T t16, Action<T> f16,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 17-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(this object value, Func<object, ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct17.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct17.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct17.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct17.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct17.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct17.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct17.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct17.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct17.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct17.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T10)value);
            }
            if (value is T11)
            {
                return Coproduct17.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T11)value);
            }
            if (value is T12)
            {
                return Coproduct17.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T12)value);
            }
            if (value is T13)
            {
                return Coproduct17.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T13)value);
            }
            if (value is T14)
            {
                return Coproduct17.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T14)value);
            }
            if (value is T15)
            {
                return Coproduct17.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T15)value);
            }
            if (value is T16)
            {
                return Coproduct17.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T16)value);
            }
            if (value is T17)
            {
                return Coproduct17.CreateSeventeenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T17)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 17 specified types.");
        }

        /// <summary>
        /// Creates a new 17-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, Func<object, ICoproduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct17.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct17.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct17.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct17.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct17.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct17.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct17.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct17.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct17.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct17.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T10)value);
            }
            if (Equals(value, t11))
            {
                return Coproduct17.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T11)value);
            }
            if (Equals(value, t12))
            {
                return Coproduct17.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T12)value);
            }
            if (Equals(value, t13))
            {
                return Coproduct17.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T13)value);
            }
            if (Equals(value, t14))
            {
                return Coproduct17.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T14)value);
            }
            if (Equals(value, t15))
            {
                return Coproduct17.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T15)value);
            }
            if (Equals(value, t16))
            {
                return Coproduct17.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T16)value);
            }
            if (Equals(value, t17))
            {
                return Coproduct17.CreateSeventeenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T17)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 17 specified values.");
        }

        /// <summary>
        /// Creates a new 18-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(this object value)
        {
            return value.AsCoproduct(v => Coproduct18.CreateEighteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, object>(v));
        }

        /// <summary>
        /// Creates a new 18-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, null, v => Coproduct18.CreateEighteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
            T t16, Func<T, TResult> f16,
            T t17, Func<T, TResult> f17,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
            T t16, Action<T> f16,
            T t17, Action<T> f17,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 18-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(this object value, Func<object, ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct18.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct18.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct18.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct18.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct18.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct18.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct18.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct18.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct18.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct18.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T10)value);
            }
            if (value is T11)
            {
                return Coproduct18.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T11)value);
            }
            if (value is T12)
            {
                return Coproduct18.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T12)value);
            }
            if (value is T13)
            {
                return Coproduct18.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T13)value);
            }
            if (value is T14)
            {
                return Coproduct18.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T14)value);
            }
            if (value is T15)
            {
                return Coproduct18.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T15)value);
            }
            if (value is T16)
            {
                return Coproduct18.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T16)value);
            }
            if (value is T17)
            {
                return Coproduct18.CreateSeventeenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T17)value);
            }
            if (value is T18)
            {
                return Coproduct18.CreateEighteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T18)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 18 specified types.");
        }

        /// <summary>
        /// Creates a new 18-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, Func<object, ICoproduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct18.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct18.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct18.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct18.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct18.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct18.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct18.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct18.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct18.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct18.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T10)value);
            }
            if (Equals(value, t11))
            {
                return Coproduct18.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T11)value);
            }
            if (Equals(value, t12))
            {
                return Coproduct18.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T12)value);
            }
            if (Equals(value, t13))
            {
                return Coproduct18.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T13)value);
            }
            if (Equals(value, t14))
            {
                return Coproduct18.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T14)value);
            }
            if (Equals(value, t15))
            {
                return Coproduct18.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T15)value);
            }
            if (Equals(value, t16))
            {
                return Coproduct18.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T16)value);
            }
            if (Equals(value, t17))
            {
                return Coproduct18.CreateSeventeenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T17)value);
            }
            if (Equals(value, t18))
            {
                return Coproduct18.CreateEighteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>((T18)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 18 specified values.");
        }

        /// <summary>
        /// Creates a new 19-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, then the value will be placed in 
        /// the last place.
        /// </summary>
        public static ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(this object value)
        {
            return value.AsCoproduct(v => Coproduct19.CreateNineteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, object>(v));
        }

        /// <summary>
        /// Creates a new 19-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters equals the value, then 
        /// the value will be placed in the last place.
        /// </summary>
        public static ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, object> AsSafeCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18)
        {
            return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, null, v => Coproduct19.CreateNineteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, object>(v));
        }

        /// <summary>
        /// Matches the value with the specified parameters and returns result of the corresponding function.
        /// </summary>
        public static TResult Match<T, TResult>(
            this T value,
            T t1, Func<T, TResult> f1,
            T t2, Func<T, TResult> f2,
            T t3, Func<T, TResult> f3,
            T t4, Func<T, TResult> f4,
            T t5, Func<T, TResult> f5,
            T t6, Func<T, TResult> f6,
            T t7, Func<T, TResult> f7,
            T t8, Func<T, TResult> f8,
            T t9, Func<T, TResult> f9,
            T t10, Func<T, TResult> f10,
            T t11, Func<T, TResult> f11,
            T t12, Func<T, TResult> f12,
            T t13, Func<T, TResult> f13,
            T t14, Func<T, TResult> f14,
            T t15, Func<T, TResult> f15,
            T t16, Func<T, TResult> f16,
            T t17, Func<T, TResult> f17,
            T t18, Func<T, TResult> f18,
            Func<T, TResult> otherwise = null)
        {
            if (otherwise == null)
            {
                return value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18);
            }
            return value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, _ => otherwise(value));
        }

        /// <summary>
        /// Matches the value with the specified parameters and executes the corresponding function.
        /// </summary>
        public static void Match<T>(
            this T value,
            T t1, Action<T> f1,
            T t2, Action<T> f2,
            T t3, Action<T> f3,
            T t4, Action<T> f4,
            T t5, Action<T> f5,
            T t6, Action<T> f6,
            T t7, Action<T> f7,
            T t8, Action<T> f8,
            T t9, Action<T> f9,
            T t10, Action<T> f10,
            T t11, Action<T> f11,
            T t12, Action<T> f12,
            T t13, Action<T> f13,
            T t14, Action<T> f14,
            T t15, Action<T> f15,
            T t16, Action<T> f16,
            T t17, Action<T> f17,
            T t18, Action<T> f18,
            Action<T> otherwise = null)
        {
            if (otherwise == null)
            {
                value.AsCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18);
            }
            else
            {
                value.AsSafeCoproduct(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18).Match(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, _ => otherwise(value));
            }
        }

        /// <summary>
        /// Creates a new 19-dimensional coproduct as a result of type match. The specified value will be on the first place 
        /// whose type matches type of the value. If none of the types matches type of the value, returns result of the fallback 
        /// function. In case when the fallback is null, throws an exception (optionally created by the otherwise function).
        /// </summary>
        public static ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(this object value, Func<object, ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (value is T1)
            {
                return Coproduct19.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T1)value);
            }
            if (value is T2)
            {
                return Coproduct19.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T2)value);
            }
            if (value is T3)
            {
                return Coproduct19.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T3)value);
            }
            if (value is T4)
            {
                return Coproduct19.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T4)value);
            }
            if (value is T5)
            {
                return Coproduct19.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T5)value);
            }
            if (value is T6)
            {
                return Coproduct19.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T6)value);
            }
            if (value is T7)
            {
                return Coproduct19.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T7)value);
            }
            if (value is T8)
            {
                return Coproduct19.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T8)value);
            }
            if (value is T9)
            {
                return Coproduct19.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T9)value);
            }
            if (value is T10)
            {
                return Coproduct19.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T10)value);
            }
            if (value is T11)
            {
                return Coproduct19.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T11)value);
            }
            if (value is T12)
            {
                return Coproduct19.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T12)value);
            }
            if (value is T13)
            {
                return Coproduct19.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T13)value);
            }
            if (value is T14)
            {
                return Coproduct19.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T14)value);
            }
            if (value is T15)
            {
                return Coproduct19.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T15)value);
            }
            if (value is T16)
            {
                return Coproduct19.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T16)value);
            }
            if (value is T17)
            {
                return Coproduct19.CreateSeventeenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T17)value);
            }
            if (value is T18)
            {
                return Coproduct19.CreateEighteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T18)value);
            }
            if (value is T19)
            {
                return Coproduct19.CreateNineteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T19)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 19 specified types.");
        }

        /// <summary>
        /// Creates a new 19-dimensional coproduct as a result of value match against the parameters. The specified value will
        /// be on the first place whose corresponding parameter equals the value. If none of the parameters matches the value, 
        /// returns result of the fallback function. In case when the fallback is null, throws an exception (optionally created by 
        /// the otherwise function).
        /// </summary>
        public static ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> AsCoproduct<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(this object value, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, Func<object, ICoproduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>> fallback = null, Func<Unit, Exception> otherwise = null)
        {
            if (Equals(value, t1))
            {
                return Coproduct19.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T1)value);
            }
            if (Equals(value, t2))
            {
                return Coproduct19.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T2)value);
            }
            if (Equals(value, t3))
            {
                return Coproduct19.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T3)value);
            }
            if (Equals(value, t4))
            {
                return Coproduct19.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T4)value);
            }
            if (Equals(value, t5))
            {
                return Coproduct19.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T5)value);
            }
            if (Equals(value, t6))
            {
                return Coproduct19.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T6)value);
            }
            if (Equals(value, t7))
            {
                return Coproduct19.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T7)value);
            }
            if (Equals(value, t8))
            {
                return Coproduct19.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T8)value);
            }
            if (Equals(value, t9))
            {
                return Coproduct19.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T9)value);
            }
            if (Equals(value, t10))
            {
                return Coproduct19.CreateTenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T10)value);
            }
            if (Equals(value, t11))
            {
                return Coproduct19.CreateEleventh<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T11)value);
            }
            if (Equals(value, t12))
            {
                return Coproduct19.CreateTwelfth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T12)value);
            }
            if (Equals(value, t13))
            {
                return Coproduct19.CreateThirteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T13)value);
            }
            if (Equals(value, t14))
            {
                return Coproduct19.CreateFourteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T14)value);
            }
            if (Equals(value, t15))
            {
                return Coproduct19.CreateFifteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T15)value);
            }
            if (Equals(value, t16))
            {
                return Coproduct19.CreateSixteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T16)value);
            }
            if (Equals(value, t17))
            {
                return Coproduct19.CreateSeventeenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T17)value);
            }
            if (Equals(value, t18))
            {
                return Coproduct19.CreateEighteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T18)value);
            }
            if (Equals(value, t19))
            {
                return Coproduct19.CreateNineteenth<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>((T19)value);
            }
            if (fallback != null)
            {
                return fallback(value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 19 specified values.");
        }

    }
}