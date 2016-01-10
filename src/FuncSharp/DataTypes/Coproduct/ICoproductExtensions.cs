using System.Collections.Generic;

namespace FuncSharp
{
    public static class ICoproductExtensions
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
        /// Canonical representation of the coproduct.
        /// </summary>
        public static IProduct3<int, int, object> CoproductRepresentation(this ICoproduct c)
        {
            return Product.Create(c.CoproductArity, c.CoproductDiscriminator, c.CoproductValue);
        }

        /// <summary>
        /// Returns hash code of the specified coproduct.
        /// </summary>
        public static int CoproductHashCode(this ICoproduct c)
        {
            return IProductExtensions.ProductHashCode(c.CoproductArity, c.CoproductDiscriminator, c.CoproductValue);
        }

        /// <summary>
        /// Returns whether the two specified coproducts are structurally equal. Note that two nulls are 
        /// considered structurally equal coproducts.
        /// </summary>
        public static bool CoproductEquals(this ICoproduct c1, object that)
        {
            var c2 = that as ICoproduct;
            if (c1 != null && c2 != null && c1.GetType() == c2.GetType())
            {
                return c1.CoproductRepresentation().Equals(c2.CoproductRepresentation());
            }
            return c1 == that;
        }

        /// <summary>
        /// Returns string representation of the specified coproduct type.
        /// </summary>
        public static string CoproductToString(this ICoproduct c)
        {
            return
                c.GetType().SimpleName() + "(" +
                    GetOrdinal(c.CoproductDiscriminator) + "(" +
                        c.CoproductValue.SafeToString() +
                    ")" +
                ")";
        }
    }
}
