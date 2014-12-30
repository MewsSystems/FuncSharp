using System;

namespace FuncSharp
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns whether the specified type is a nullable type.
        /// </summary>
        public static bool IsNullable(this Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}
