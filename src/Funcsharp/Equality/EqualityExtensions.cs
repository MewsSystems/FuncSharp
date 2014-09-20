using System;

namespace Funcsharp.Equality
{
    /// <summary>
    /// Extensions of .NET equality and objects.
    /// </summary>
    public static class EqualityExtensions
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
            return o1.FastEquals(o2) ?? o1.Equals(o2);
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
        public static bool? FastEquals<T>(this T o1, object o2)
        {
            if (o1.ReferentiallyEquals(o2))
            {
                return true;
            }

            // They're not referentially equal but one of them can be null while the other not.
            var o1Null = o1.ReferentiallyEquals(null);
            var o2Null = o2.ReferentiallyEquals(null);
            if (o1Null && !o2Null || !o1Null && o2Null)
            {
                return false;
            }

            // Both of the are not null, so the second one has to be of the same type as the first one.
            if (!(o2 is T))
            {
                return false;
            }

            return null;
        }
    }
}
