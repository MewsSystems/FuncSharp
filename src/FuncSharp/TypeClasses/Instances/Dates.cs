using System;

namespace FuncSharp
{
    public static class Dates
    {
        public static readonly IEquality<DateTime> Equality = new Equality<DateTime>(
            (d1, d2) => DateTimes.Equality.Equal(d1.Date, d2.Date)
        );

        public static readonly IEnumeration<DateTime> Enumeration = new Enumeration<DateTime>(
            d => d.AddDays(1),
            Equality.Equal
        );

        public static readonly ITotalOrdering<DateTime> Ordering = new TotalOrdering<DateTime>(
            (d1, d2) => DateTimes.Ordering.Less(d1.Date, d2.Date),
            Equality.Equal
        );
    }
}
