using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class IAlgebraExtensions
    {
        /// <summary>
        /// Returns whether the two specified elements are not equal.
        /// </summary>
        public static bool NonEqual<A>(this IAlgebra<A> algebra, A a1, A a2)
        {
            return !algebra.Equal(a1, a2);
        }

        /// <summary>
        /// Returns a collection that does not contain duplicities.
        /// </summary>
        public static IEnumerable<A> Distinct<A>(this IAlgebra<A> algebra, IEnumerable<A> values)
        {
            var result = new List<A>();
            foreach (var value in values)
            {
                if (!result.Any(v => algebra.Equal(value, v)))
                {
                    result.Add(value);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a collection that does not contain duplicities.
        /// </summary>
        public static IEnumerable<A> Distinct<A>(this IAlgebra<A> algebra, params A[] values)
        {
            return algebra.Distinct(values.AsEnumerable());
        }
    }
}
