using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class IEqualityExtensions
    {
        /// <summary>
        /// Returns whether the two specified elements are not equal.
        /// </summary>
        public static bool NonEqual<A>(this IEquality<A> equality, A a1, A a2)
        {
            return !equality.Equal(a1, a2);
        }

        /// <summary>
        /// Returns a collection that does not contain duplicities.
        /// </summary>
        public static IEnumerable<A> Distinct<A>(this IEquality<A> equality, IEnumerable<A> values)
        {
            var result = new List<A>();
            foreach (var value in values)
            {
                if (!result.Any(v => equality.Equal(value, v)))
                {
                    result.Add(value);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a collection that does not contain duplicities.
        /// </summary>
        public static IEnumerable<A> Distinct<A>(this IEquality<A> equality, params A[] values)
        {
            return equality.Distinct(values.AsEnumerable());
        }
    }
}
