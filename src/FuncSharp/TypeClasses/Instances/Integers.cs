namespace FuncSharp
{
    public static class Integers
    {
        public static readonly IEquality<int> Equality = new Equality<int>();

        public static readonly IEnumeration<int> Enumeration = new Enumeration<int>(
            i => i + 1
        );

        public static readonly ITotalOrdering<int> Ordering = new ComparableOrdering<int>();
    }
}
