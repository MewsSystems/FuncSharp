using System;

namespace FuncSharp
{
    public static class DateTimes
    {
        public static readonly IEquality<DateTime> Equality = new Equality<DateTime>();

        public static readonly ITotalOrdering<DateTime> Ordering = new ComparableOrdering<DateTime>();
    }
}
