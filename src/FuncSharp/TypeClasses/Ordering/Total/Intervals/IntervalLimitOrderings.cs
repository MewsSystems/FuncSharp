namespace FuncSharp
{
    public class IntervalLimitOrderings<A>
    {
        public IntervalLimitOrderings(ITotalOrdering<A> valueOrdering)
        {
            LowerRestrictiveness = new InetrvalLimitRestrictivenessOrdering<A>(valueOrdering);
            UpperRestrictiveness = new InetrvalLimitRestrictivenessOrdering<A>(valueOrdering.Reverse());
        }

        public ITotalOrdering<IntervalLimit<A>> LowerRestrictiveness { get; }

        public ITotalOrdering<IntervalLimit<A>> UpperRestrictiveness { get; }
    }
}
