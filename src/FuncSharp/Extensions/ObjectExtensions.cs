using System;

namespace FuncSharp
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns whether the two specified objects are structurally equal. The only difference from
        /// Object.Equals is that it checks type of the second object <paramref name="o2"/> before the
        /// Equals method is actually invoked. Note that two nulls are structurally equal.
        /// </summary>
        public static bool StructurallyEquals(this object o1, object o2)
        {
            return o1.FastEquals(o2).GetOrElse(() => o1.Equals(o2));
        }

        /// <summary>
        /// Returns whether the objects are structurally equal based on references and their types, which is the 
        /// fastest check possible, since Equals method is not invoked. If it can't be decided just from that, 
        /// an empty option is returned. In that case it's however sure that both objects are not null and that the
        /// second object <paramref name="o2"/> is of the same type. Note that two nulls are structurally equal.
        /// </summary>
        /// <example>
        /// Useful when overriding Equals method. You can invoke it first and use its return value. And only
        /// if the result is empty, you should continue comparing structures of the objects.
        /// </example>
        public static IOption<bool> FastEquals(this object o1, object o2)
        {
            if (o1 == o2)
            {
                return true.ToOption();
            }
            if (o1 == null || o2 == null)
            {
                return false.ToOption();
            }
            if (o1.GetType() != o2.GetType())
            {
                return false.ToOption();
            }

            return Option.Empty<bool>();
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
        public static IOption<T> ToOption<T>(this T value)
        {
            return Option.Create(value);
        }

        /// <summary>
        /// Creates a new 0-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum0 AsSum(this object value, Func<object, ISum0> otherwise = null)
        {
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 0 specified types.");
        }

        /// <summary>
        /// Creates a new 1-dimensional sum as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static ISum1<object> AsSafeSum(this object value)
        {
            return value.AsSum<object>(v => Sum.CreateFirst<object>(v));
        }

        /// <summary>
        /// Creates a new 1-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum1<T1> AsSum<T1>(this object value, Func<object, ISum1<T1>> otherwise = null)
        {
            if (value is T1)
            {
                return Sum.CreateFirst<T1>((T1)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 1 specified types.");
        }

        /// <summary>
        /// Creates a new 2-dimensional sum as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static ISum2<T1, object> AsSafeSum<T1>(this object value)
        {
            return value.AsSum<T1, object>(v => Sum.CreateSecond<T1, object>(v));
        }

        /// <summary>
        /// Creates a new 2-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum2<T1, T2> AsSum<T1, T2>(this object value, Func<object, ISum2<T1, T2>> otherwise = null)
        {
            if (value is T1)
            {
                return Sum.CreateFirst<T1, T2>((T1)value);
            }
            if (value is T2)
            {
                return Sum.CreateSecond<T1, T2>((T2)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 2 specified types.");
        }

        /// <summary>
        /// Creates a new 3-dimensional sum as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static ISum3<T1, T2, object> AsSafeSum<T1, T2>(this object value)
        {
            return value.AsSum<T1, T2, object>(v => Sum.CreateThird<T1, T2, object>(v));
        }

        /// <summary>
        /// Creates a new 3-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum3<T1, T2, T3> AsSum<T1, T2, T3>(this object value, Func<object, ISum3<T1, T2, T3>> otherwise = null)
        {
            if (value is T1)
            {
                return Sum.CreateFirst<T1, T2, T3>((T1)value);
            }
            if (value is T2)
            {
                return Sum.CreateSecond<T1, T2, T3>((T2)value);
            }
            if (value is T3)
            {
                return Sum.CreateThird<T1, T2, T3>((T3)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 3 specified types.");
        }

        /// <summary>
        /// Creates a new 4-dimensional sum as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static ISum4<T1, T2, T3, object> AsSafeSum<T1, T2, T3>(this object value)
        {
            return value.AsSum<T1, T2, T3, object>(v => Sum.CreateFourth<T1, T2, T3, object>(v));
        }

        /// <summary>
        /// Creates a new 4-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum4<T1, T2, T3, T4> AsSum<T1, T2, T3, T4>(this object value, Func<object, ISum4<T1, T2, T3, T4>> otherwise = null)
        {
            if (value is T1)
            {
                return Sum.CreateFirst<T1, T2, T3, T4>((T1)value);
            }
            if (value is T2)
            {
                return Sum.CreateSecond<T1, T2, T3, T4>((T2)value);
            }
            if (value is T3)
            {
                return Sum.CreateThird<T1, T2, T3, T4>((T3)value);
            }
            if (value is T4)
            {
                return Sum.CreateFourth<T1, T2, T3, T4>((T4)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 4 specified types.");
        }

        /// <summary>
        /// Creates a new 5-dimensional sum as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static ISum5<T1, T2, T3, T4, object> AsSafeSum<T1, T2, T3, T4>(this object value)
        {
            return value.AsSum<T1, T2, T3, T4, object>(v => Sum.CreateFifth<T1, T2, T3, T4, object>(v));
        }

        /// <summary>
        /// Creates a new 5-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum5<T1, T2, T3, T4, T5> AsSum<T1, T2, T3, T4, T5>(this object value, Func<object, ISum5<T1, T2, T3, T4, T5>> otherwise = null)
        {
            if (value is T1)
            {
                return Sum.CreateFirst<T1, T2, T3, T4, T5>((T1)value);
            }
            if (value is T2)
            {
                return Sum.CreateSecond<T1, T2, T3, T4, T5>((T2)value);
            }
            if (value is T3)
            {
                return Sum.CreateThird<T1, T2, T3, T4, T5>((T3)value);
            }
            if (value is T4)
            {
                return Sum.CreateFourth<T1, T2, T3, T4, T5>((T4)value);
            }
            if (value is T5)
            {
                return Sum.CreateFifth<T1, T2, T3, T4, T5>((T5)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 5 specified types.");
        }

        /// <summary>
        /// Creates a new 6-dimensional sum as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static ISum6<T1, T2, T3, T4, T5, object> AsSafeSum<T1, T2, T3, T4, T5>(this object value)
        {
            return value.AsSum<T1, T2, T3, T4, T5, object>(v => Sum.CreateSixth<T1, T2, T3, T4, T5, object>(v));
        }

        /// <summary>
        /// Creates a new 6-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum6<T1, T2, T3, T4, T5, T6> AsSum<T1, T2, T3, T4, T5, T6>(this object value, Func<object, ISum6<T1, T2, T3, T4, T5, T6>> otherwise = null)
        {
            if (value is T1)
            {
                return Sum.CreateFirst<T1, T2, T3, T4, T5, T6>((T1)value);
            }
            if (value is T2)
            {
                return Sum.CreateSecond<T1, T2, T3, T4, T5, T6>((T2)value);
            }
            if (value is T3)
            {
                return Sum.CreateThird<T1, T2, T3, T4, T5, T6>((T3)value);
            }
            if (value is T4)
            {
                return Sum.CreateFourth<T1, T2, T3, T4, T5, T6>((T4)value);
            }
            if (value is T5)
            {
                return Sum.CreateFifth<T1, T2, T3, T4, T5, T6>((T5)value);
            }
            if (value is T6)
            {
                return Sum.CreateSixth<T1, T2, T3, T4, T5, T6>((T6)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 6 specified types.");
        }

        /// <summary>
        /// Creates a new 7-dimensional sum as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static ISum7<T1, T2, T3, T4, T5, T6, object> AsSafeSum<T1, T2, T3, T4, T5, T6>(this object value)
        {
            return value.AsSum<T1, T2, T3, T4, T5, T6, object>(v => Sum.CreateSeventh<T1, T2, T3, T4, T5, T6, object>(v));
        }

        /// <summary>
        /// Creates a new 7-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum7<T1, T2, T3, T4, T5, T6, T7> AsSum<T1, T2, T3, T4, T5, T6, T7>(this object value, Func<object, ISum7<T1, T2, T3, T4, T5, T6, T7>> otherwise = null)
        {
            if (value is T1)
            {
                return Sum.CreateFirst<T1, T2, T3, T4, T5, T6, T7>((T1)value);
            }
            if (value is T2)
            {
                return Sum.CreateSecond<T1, T2, T3, T4, T5, T6, T7>((T2)value);
            }
            if (value is T3)
            {
                return Sum.CreateThird<T1, T2, T3, T4, T5, T6, T7>((T3)value);
            }
            if (value is T4)
            {
                return Sum.CreateFourth<T1, T2, T3, T4, T5, T6, T7>((T4)value);
            }
            if (value is T5)
            {
                return Sum.CreateFifth<T1, T2, T3, T4, T5, T6, T7>((T5)value);
            }
            if (value is T6)
            {
                return Sum.CreateSixth<T1, T2, T3, T4, T5, T6, T7>((T6)value);
            }
            if (value is T7)
            {
                return Sum.CreateSeventh<T1, T2, T3, T4, T5, T6, T7>((T7)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 7 specified types.");
        }

        /// <summary>
        /// Creates a new 8-dimensional sum as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, object> AsSafeSum<T1, T2, T3, T4, T5, T6, T7>(this object value)
        {
            return value.AsSum<T1, T2, T3, T4, T5, T6, T7, object>(v => Sum.CreateEighth<T1, T2, T3, T4, T5, T6, T7, object>(v));
        }

        /// <summary>
        /// Creates a new 8-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, T8> AsSum<T1, T2, T3, T4, T5, T6, T7, T8>(this object value, Func<object, ISum8<T1, T2, T3, T4, T5, T6, T7, T8>> otherwise = null)
        {
            if (value is T1)
            {
                return Sum.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>((T1)value);
            }
            if (value is T2)
            {
                return Sum.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>((T2)value);
            }
            if (value is T3)
            {
                return Sum.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>((T3)value);
            }
            if (value is T4)
            {
                return Sum.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>((T4)value);
            }
            if (value is T5)
            {
                return Sum.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>((T5)value);
            }
            if (value is T6)
            {
                return Sum.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>((T6)value);
            }
            if (value is T7)
            {
                return Sum.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>((T7)value);
            }
            if (value is T8)
            {
                return Sum.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8>((T8)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 8 specified types.");
        }

        /// <summary>
        /// Creates a new 9-dimensional sum as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, object> AsSafeSum<T1, T2, T3, T4, T5, T6, T7, T8>(this object value)
        {
            return value.AsSum<T1, T2, T3, T4, T5, T6, T7, T8, object>(v => Sum.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, object>(v));
        }

        /// <summary>
        /// Creates a new 9-dimensional sum as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> AsSum<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this object value, Func<object, ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> otherwise = null)
        {
            if (value is T1)
            {
                return Sum.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T1)value);
            }
            if (value is T2)
            {
                return Sum.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T2)value);
            }
            if (value is T3)
            {
                return Sum.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T3)value);
            }
            if (value is T4)
            {
                return Sum.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T4)value);
            }
            if (value is T5)
            {
                return Sum.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T5)value);
            }
            if (value is T6)
            {
                return Sum.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T6)value);
            }
            if (value is T7)
            {
                return Sum.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T7)value);
            }
            if (value is T8)
            {
                return Sum.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T8)value);
            }
            if (value is T9)
            {
                return Sum.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T9)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 9 specified types.");
        }

    }
}