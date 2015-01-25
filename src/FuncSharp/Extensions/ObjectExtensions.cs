using System;

namespace FuncSharp
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns whether the two specified objects are referentially equal. Just a convenience extension 
        /// method instead of Object.ReferenceEquals.
        /// </summary>
        public static bool ReferentiallyEquals(this object o1, object o2)
        {
            return Object.ReferenceEquals(o1, o2);
        }

        /// <summary>
        /// Returns whether the two specified objects are structurally equal. The only difference from
        /// Object.Equals is that it checks type of the second object <paramref name="o2"/> before the
        /// Equals method is actually invoked. Note that two nulls are structurally equal.
        /// </summary>
        public static bool StructurallyEquals<T>(this T o1, object o2)
        {
            return o1.FastEquals(o2).GetOrElse(() => o1.Equals(o2));
        }

        /// <summary>
        /// Returns whether the objects are structurally equal based on references and their types which is the 
        /// fastest check possible, since it doesn't involve the Equals method. If it can't be decided just from 
        /// that, null is returned. In that case it's however sure that both objects are not null and that the
        /// second object <paramref name="o2"/> is of type <typeparamref name="T"/>. Note that two nulls are 
        /// structurally equal.
        /// </summary>
        /// <example>
        /// Useful when overriding Equals method. You can invoke it first and use its return value. And only
        /// if it returns null, you should continue comparing equality of the objects.
        /// </example>
        public static IOption<bool> FastEquals<T>(this T o1, object o2)
        {
            if (o1.ReferentiallyEquals(o2))
            {
                return true.ToOption();
            }

            // They're not referentially equal but one of them can be null while the other not.
            var o1Null = o1.ReferentiallyEquals(null);
            var o2Null = o2.ReferentiallyEquals(null);
            if (o1Null && !o2Null || !o1Null && o2Null)
            {
                return false.ToOption();
            }

            // Both of the are not null, so the second one has to be of the same type as the first one.
            if (!(o2 is T))
            {
                return false.ToOption();
            }

            return Option.None<bool>();
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
        /// Creates a new 0-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union0 AsUnion(this object value, Func<object, Union0> otherwise = null)
        {
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 0 specified types.");
        }

        /// <summary>
        /// Creates a new 1-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union1<object> AsSafeUnion(this object value)
        {
            return value.AsUnion<object>(v => Union.CreateFirst<object>(v));
        }

        /// <summary>
        /// Creates a new 1-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union1<T1> AsUnion<T1>(this object value, Func<object, Union1<T1>> otherwise = null)
        {
            if (value is T1)
            {
                return Union.CreateFirst<T1>((T1)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 1 specified types.");
        }

        /// <summary>
        /// Creates a new 2-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union2<T1, object> AsSafeUnion<T1>(this object value)
        {
            return value.AsUnion<T1, object>(v => Union.CreateSecond<T1, object>(v));
        }

        /// <summary>
        /// Creates a new 2-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union2<T1, T2> AsUnion<T1, T2>(this object value, Func<object, Union2<T1, T2>> otherwise = null)
        {
            if (value is T1)
            {
                return Union.CreateFirst<T1, T2>((T1)value);
            }
            if (value is T2)
            {
                return Union.CreateSecond<T1, T2>((T2)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 2 specified types.");
        }

        /// <summary>
        /// Creates a new 3-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union3<T1, T2, object> AsSafeUnion<T1, T2>(this object value)
        {
            return value.AsUnion<T1, T2, object>(v => Union.CreateThird<T1, T2, object>(v));
        }

        /// <summary>
        /// Creates a new 3-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union3<T1, T2, T3> AsUnion<T1, T2, T3>(this object value, Func<object, Union3<T1, T2, T3>> otherwise = null)
        {
            if (value is T1)
            {
                return Union.CreateFirst<T1, T2, T3>((T1)value);
            }
            if (value is T2)
            {
                return Union.CreateSecond<T1, T2, T3>((T2)value);
            }
            if (value is T3)
            {
                return Union.CreateThird<T1, T2, T3>((T3)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 3 specified types.");
        }

        /// <summary>
        /// Creates a new 4-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union4<T1, T2, T3, object> AsSafeUnion<T1, T2, T3>(this object value)
        {
            return value.AsUnion<T1, T2, T3, object>(v => Union.CreateFourth<T1, T2, T3, object>(v));
        }

        /// <summary>
        /// Creates a new 4-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union4<T1, T2, T3, T4> AsUnion<T1, T2, T3, T4>(this object value, Func<object, Union4<T1, T2, T3, T4>> otherwise = null)
        {
            if (value is T1)
            {
                return Union.CreateFirst<T1, T2, T3, T4>((T1)value);
            }
            if (value is T2)
            {
                return Union.CreateSecond<T1, T2, T3, T4>((T2)value);
            }
            if (value is T3)
            {
                return Union.CreateThird<T1, T2, T3, T4>((T3)value);
            }
            if (value is T4)
            {
                return Union.CreateFourth<T1, T2, T3, T4>((T4)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 4 specified types.");
        }

        /// <summary>
        /// Creates a new 5-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union5<T1, T2, T3, T4, object> AsSafeUnion<T1, T2, T3, T4>(this object value)
        {
            return value.AsUnion<T1, T2, T3, T4, object>(v => Union.CreateFifth<T1, T2, T3, T4, object>(v));
        }

        /// <summary>
        /// Creates a new 5-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> AsUnion<T1, T2, T3, T4, T5>(this object value, Func<object, Union5<T1, T2, T3, T4, T5>> otherwise = null)
        {
            if (value is T1)
            {
                return Union.CreateFirst<T1, T2, T3, T4, T5>((T1)value);
            }
            if (value is T2)
            {
                return Union.CreateSecond<T1, T2, T3, T4, T5>((T2)value);
            }
            if (value is T3)
            {
                return Union.CreateThird<T1, T2, T3, T4, T5>((T3)value);
            }
            if (value is T4)
            {
                return Union.CreateFourth<T1, T2, T3, T4, T5>((T4)value);
            }
            if (value is T5)
            {
                return Union.CreateFifth<T1, T2, T3, T4, T5>((T5)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 5 specified types.");
        }

        /// <summary>
        /// Creates a new 6-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, object> AsSafeUnion<T1, T2, T3, T4, T5>(this object value)
        {
            return value.AsUnion<T1, T2, T3, T4, T5, object>(v => Union.CreateSixth<T1, T2, T3, T4, T5, object>(v));
        }

        /// <summary>
        /// Creates a new 6-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> AsUnion<T1, T2, T3, T4, T5, T6>(this object value, Func<object, Union6<T1, T2, T3, T4, T5, T6>> otherwise = null)
        {
            if (value is T1)
            {
                return Union.CreateFirst<T1, T2, T3, T4, T5, T6>((T1)value);
            }
            if (value is T2)
            {
                return Union.CreateSecond<T1, T2, T3, T4, T5, T6>((T2)value);
            }
            if (value is T3)
            {
                return Union.CreateThird<T1, T2, T3, T4, T5, T6>((T3)value);
            }
            if (value is T4)
            {
                return Union.CreateFourth<T1, T2, T3, T4, T5, T6>((T4)value);
            }
            if (value is T5)
            {
                return Union.CreateFifth<T1, T2, T3, T4, T5, T6>((T5)value);
            }
            if (value is T6)
            {
                return Union.CreateSixth<T1, T2, T3, T4, T5, T6>((T6)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 6 specified types.");
        }

        /// <summary>
        /// Creates a new 7-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, object> AsSafeUnion<T1, T2, T3, T4, T5, T6>(this object value)
        {
            return value.AsUnion<T1, T2, T3, T4, T5, T6, object>(v => Union.CreateSeventh<T1, T2, T3, T4, T5, T6, object>(v));
        }

        /// <summary>
        /// Creates a new 7-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> AsUnion<T1, T2, T3, T4, T5, T6, T7>(this object value, Func<object, Union7<T1, T2, T3, T4, T5, T6, T7>> otherwise = null)
        {
            if (value is T1)
            {
                return Union.CreateFirst<T1, T2, T3, T4, T5, T6, T7>((T1)value);
            }
            if (value is T2)
            {
                return Union.CreateSecond<T1, T2, T3, T4, T5, T6, T7>((T2)value);
            }
            if (value is T3)
            {
                return Union.CreateThird<T1, T2, T3, T4, T5, T6, T7>((T3)value);
            }
            if (value is T4)
            {
                return Union.CreateFourth<T1, T2, T3, T4, T5, T6, T7>((T4)value);
            }
            if (value is T5)
            {
                return Union.CreateFifth<T1, T2, T3, T4, T5, T6, T7>((T5)value);
            }
            if (value is T6)
            {
                return Union.CreateSixth<T1, T2, T3, T4, T5, T6, T7>((T6)value);
            }
            if (value is T7)
            {
                return Union.CreateSeventh<T1, T2, T3, T4, T5, T6, T7>((T7)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 7 specified types.");
        }

        /// <summary>
        /// Creates a new 8-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, object> AsSafeUnion<T1, T2, T3, T4, T5, T6, T7>(this object value)
        {
            return value.AsUnion<T1, T2, T3, T4, T5, T6, T7, object>(v => Union.CreateEighth<T1, T2, T3, T4, T5, T6, T7, object>(v));
        }

        /// <summary>
        /// Creates a new 8-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> AsUnion<T1, T2, T3, T4, T5, T6, T7, T8>(this object value, Func<object, Union8<T1, T2, T3, T4, T5, T6, T7, T8>> otherwise = null)
        {
            if (value is T1)
            {
                return Union.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>((T1)value);
            }
            if (value is T2)
            {
                return Union.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>((T2)value);
            }
            if (value is T3)
            {
                return Union.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>((T3)value);
            }
            if (value is T4)
            {
                return Union.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>((T4)value);
            }
            if (value is T5)
            {
                return Union.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>((T5)value);
            }
            if (value is T6)
            {
                return Union.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>((T6)value);
            }
            if (value is T7)
            {
                return Union.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>((T7)value);
            }
            if (value is T8)
            {
                return Union.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8>((T8)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 8 specified types.");
        }

        /// <summary>
        /// Creates a new 9-dimensional union as a result of type match. The specified value will be on the first place whose 
        /// type matches type of the value. If none of the types matches type of the value, then the value will be placed in the last place.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, object> AsSafeUnion<T1, T2, T3, T4, T5, T6, T7, T8>(this object value)
        {
            return value.AsUnion<T1, T2, T3, T4, T5, T6, T7, T8, object>(v => Union.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, object>(v));
        }

        /// <summary>
        /// Creates a new 9-dimensional union as a result of type match. The specified value will be on the first place whose type 
        /// matches type of the value. If none of the types matches type of the value, returns result of the otherwise function. In case
        /// when the otherwise function is null, throws an exception.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> AsUnion<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this object value, Func<object, Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>> otherwise = null)
        {
            if (value is T1)
            {
                return Union.CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T1)value);
            }
            if (value is T2)
            {
                return Union.CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T2)value);
            }
            if (value is T3)
            {
                return Union.CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T3)value);
            }
            if (value is T4)
            {
                return Union.CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T4)value);
            }
            if (value is T5)
            {
                return Union.CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T5)value);
            }
            if (value is T6)
            {
                return Union.CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T6)value);
            }
            if (value is T7)
            {
                return Union.CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T7)value);
            }
            if (value is T8)
            {
                return Union.CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T8)value);
            }
            if (value is T9)
            {
                return Union.CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T9)value);
            }
            if (otherwise != null)
            {
                return otherwise(value);
            }
            throw new ArgumentException("The value " + value.SafeToString() + " does not match any of the 9 specified types.");
        }

    }
}