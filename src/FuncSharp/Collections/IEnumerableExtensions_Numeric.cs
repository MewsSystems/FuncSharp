using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static partial class IEnumerableExtensions
    {
        public static PositiveInt Sum(this INonEmptyEnumerable<PositiveInt> values)
        {
            return PositiveInt.CreateUnsafe(values.Sum(v => v.Value));
        }

        public static NonPositiveInt Sum(this IEnumerable<NonPositiveInt> values)
        {
            return values.Aggregate(0.AsUnsafeNonPositive(), (a, b) => a + b);
        }

        public static NonNegativeInt Sum(this IEnumerable<NonNegativeInt> values)
        {
            return values.Aggregate(NonNegativeInt.Zero, (a, b) => a + b);
        }
    }
}