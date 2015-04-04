namespace FuncSharp
{
    /// <summary>
    /// A type that represents a choice from multiple different types e.g. T1 or T2 or T3.
    /// Therefore instances of a product type consist of values of the compound types, e.g. T1 value1, T2 value2 and T3 value3.
    /// This interface represents the most abstract definition of a product type with unknown compound types and unknown arity.
    /// </summary>
    public interface ISum
    {
        /// <summary>
        /// Arity of the sum type. Should be non-negative.
        /// </summary>
        int SumArity { get; }

        /// <summary>
        /// Discriminator of the sum type value. Should be in interval [1, SumArity].
        /// </summary>
        int SumDiscriminator { get; }

        /// <summary>
        /// Value of the sum type no matter which one of the possible values it is.
        /// </summary>
        object SumValue { get; }
    }

    public static class ISumExtensions
    {
        /// <summary>
        /// Canonical representation of the sum.
        /// </summary>
        public static Product3<int, int, object> Representation(this ISum sum)
        {
            return Product.Create(sum.SumArity, sum.SumDiscriminator, sum.SumValue);
        }

        /// <summary>
        /// Returns hash code of the specified sum.
        /// </summary>
        public static int SumHashCode(this ISum sum)
        {
            return sum.Representation().GetHashCode();
        }

        /// <summary>
        /// Returns whether the two specified sums are structurally equal. Note that two nulls are 
        /// considered structurally equal sums.
        /// </summary>
        public static bool SumEquals<TSum>(this TSum s1, object s2)
            where TSum : ISum
        {
            return s1.FastEquals(s2).GetOrElse(() =>
                s1.Representation().Equals(((ISum)s2).Representation())
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
