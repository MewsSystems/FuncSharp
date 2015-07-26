using System.Collections.Generic;

namespace FuncSharp
{
    public static class ISumExtensions
    {
        private static readonly Dictionary<int, string> Ordinals = new Dictionary<int, string>
        {
            { 1, "First" },
            { 2, "Second" },
            { 3, "Third" },
            { 4, "Fourth" },
            { 5, "Fifth" },
            { 6, "Sixth" },
            { 7, "Seventh" },
            { 8, "Eighth" },
            { 9, "Ninth" }
        };

        /// <summary>
        /// Returns ordinal corresponding to the number.
        /// </summary>
        public static string GetOrdinal(int i)
        {
            return Ordinals.ContainsKey(i) ? Ordinals[i] : i + "th";
        }

        /// <summary>
        /// Canonical representation of the sum.
        /// </summary>
        public static IProduct3<int, int, object> SumRepresentation(this ISum s)
        {
            return Product.Create(s.SumArity, s.SumDiscriminator, s.SumValue);
        }

        /// <summary>
        /// Returns hash code of the specified sum.
        /// </summary>
        public static int SumHashCode(this ISum s)
        {
            return IProductExtensions.ProductHashCode(s.SumArity, s.SumDiscriminator, s.SumValue);
        }

        /// <summary>
        /// Returns whether the two specified sums are structurally equal. Note that two nulls are 
        /// considered structurally equal sums.
        /// </summary>
        public static bool SumEquals(this ISum s1, object s2)
        {
            return s1.FastEquals(s2).GetOrElse(_ =>
                s1.SumRepresentation().Equals(((ISum)s2).SumRepresentation())
            );
        }

        /// <summary>
        /// Returns string representation of the specified sum type.
        /// </summary>
        public static string SumToString(this ISum sum)
        {
            return
                sum.GetType().SimpleName() + "(" +
                    GetOrdinal(sum.SumDiscriminator) + "(" +
                        sum.SumValue.SafeToString() +
                    ")" +
                ")";
        }
    }
}
