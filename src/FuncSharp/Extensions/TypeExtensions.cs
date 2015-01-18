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

        /// <summary>
        /// Returns name of the type stripped from generic parameters.
        /// </summary>
        public static string SimpleName(this Type t)
        {
            var simpleName = t.Name;
            var backtickIndex = simpleName.IndexOf("`");
            if (backtickIndex > 0)
            {
                simpleName = simpleName.Substring(0, backtickIndex);
            }
            return simpleName;
        }
    }
}
