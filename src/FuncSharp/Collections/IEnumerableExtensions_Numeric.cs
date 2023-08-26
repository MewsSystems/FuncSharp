using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FuncSharp
{
    public static partial class IEnumerableExtensions
    {
        [Pure]
        public static PositiveInt Sum(this INonEmptyEnumerable<PositiveInt> values)
        {
            return PositiveInt.CreateUnsafe(values.Sum(v => v.Value));
        }

        [Pure]
        public static PositiveDecimal Sum(this INonEmptyEnumerable<PositiveDecimal> values)
        {
            return PositiveDecimal.CreateUnsafe(values.Sum(v => v.Value));
        }

        public static Option<PositiveInt> SafeSum(this IEnumerable<PositiveInt> values)
        {
            return PositiveInt.Create(values.Sum(v => v.Value));
        }

        public static Option<PositiveDecimal> SafeSum(this IEnumerable<PositiveDecimal> values)
        {
            return PositiveDecimal.Create(values.Sum(v => v.Value));
        }

        public static NonPositiveInt Sum(this IEnumerable<NonPositiveInt> values)
        {
            return values.Aggregate(NonPositiveInt.Zero, (a, b) => a + b);
        }

        public static NonPositiveDecimal Sum(this IEnumerable<NonPositiveDecimal> values)
        {
            return values.Aggregate(NonPositiveDecimal.Zero, (a, b) => a + b);
        }

        public static NonNegativeInt Sum(this IEnumerable<NonNegativeInt> values)
        {
            return values.Aggregate(NonNegativeInt.Zero, (a, b) => a + b);
        }

        public static NonNegativeDecimal Sum(this IEnumerable<NonNegativeDecimal> values)
        {
            return values.Aggregate(NonNegativeDecimal.Zero, (a, b) => a + b);
        }
    }
}