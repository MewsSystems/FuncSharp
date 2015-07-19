namespace FuncSharp
{
    public class InetrvalLimitRestrictivenessOrdering<A> : TotalOrdering<IntervalLimit<A>>
    {
        public InetrvalLimitRestrictivenessOrdering(ITotalOrdering<A> valueRestrictivenessOrdering)
        {
            ValueRestrictivenessOrdering = valueRestrictivenessOrdering;
        }

        public ITotalOrdering<A> ValueRestrictivenessOrdering { get; private set; }

        public override bool Less(IntervalLimit<A> l1, IntervalLimit<A> l2)
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
                ValueRestrictivenessOrdering.Less(b1, b2) ||
                ValueRestrictivenessOrdering.Equal(b1, b2) && l1.IsClosed && l2.IsOpen
            )).GetOrDefault();
        }
    }
}
