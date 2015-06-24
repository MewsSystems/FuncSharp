namespace FuncSharp
{
    public static class ISumExtensions
    {
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
        public static int SumHashCode(this ISum sum)
        {
            return sum.SumRepresentation().GetHashCode();
        }

        /// <summary>
        /// Returns whether the two specified sums are structurally equal. Note that two nulls are 
        /// considered structurally equal sums.
        /// </summary>
        public static bool SumEquals(this ISum s1, object s2)
        {
            return s1.FastEquals(s2).GetOrElse(() =>
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
                    sum.SumDiscriminator + "/" + sum.SumArity + ", " +
                    sum.SumValue.SafeToString() +
                ")";
        }
    }
}
