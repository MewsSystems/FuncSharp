namespace FuncSharp
{
    public class TotalOrderingData<A>
    {
        public TotalOrderingData(IntervalLimitOrderings<A> limitOrderings, ITotalOrdering<Interval<A>> intervalOrdering)
        {
            LimitOrderings = limitOrderings;
            IntervalOrdering = intervalOrdering;
        }

        public IntervalLimitOrderings<A> LimitOrderings { get; }

        public ITotalOrdering<Interval<A>> IntervalOrdering { get; }
    }
}
