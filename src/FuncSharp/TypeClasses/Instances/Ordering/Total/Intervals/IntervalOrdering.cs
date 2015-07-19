namespace FuncSharp
{
    public class IntervalOrdering<A> : TotalOrdering<Interval<A>>
    {
        public IntervalOrdering(IntervalLimitOrderings<A> limitOrderings)
        {
            LimitOrderings = limitOrderings;
        }

        public IntervalLimitOrderings<A> LimitOrderings { get; private set; }

        public override bool Less(Interval<A> i1, Interval<A> i2)
        {
            if (i1.IsEmpty && i2.IsEmpty)
            {
                return false;
            }

            if (LimitOrderings.LowerRestrictiveness.Less(i1.LowerLimit, i2.LowerLimit))
            {
                return true;
            }
            if (LimitOrderings.UpperRestrictiveness.Greater(i1.LowerLimit, i2.LowerLimit))
            {
                return true;
            }
            return false;
        }
    }
}
