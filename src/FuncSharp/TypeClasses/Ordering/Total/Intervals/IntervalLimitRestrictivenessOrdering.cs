namespace FuncSharp
{
    public class InetrvalLimitRestrictivenessOrdering<A> : TotalOrdering<IntervalLimit<A>>
    {
        public InetrvalLimitRestrictivenessOrdering(ITotalOrdering<A> valueRestrictivenessOrdering)
            : base(less: (l1, l2) =>
            {
                if (l1.IsUnbounded)
                {
                    return l2.IsBounded;
                }
                if (l2.IsUnbounded)
                {
                    return false;
                }
                return l1.Bound.FlatMap(b1 => l2.Bound.Map(b2 =>
                    valueRestrictivenessOrdering.Less(b1, b2) ||
                    valueRestrictivenessOrdering.Equal(b1, b2) && l1.IsClosed && l2.IsOpen
                )).GetOrFalse();
            })
        {
        }
    }
}
