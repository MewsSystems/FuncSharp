namespace FuncSharp
{
    public class IntervalOrdering<A> : TotalOrdering<Interval<A>>
    {
        public IntervalOrdering(IntervalLimitOrderings<A> limitOrderings)
            : base((i1, i2) =>
            {
                if (i1.IsEmpty && i2.IsEmpty)
                {
                    return false;
                }
                else if (i1.LowerLimit.Equals(i2.LowerLimit))
                {
                    return limitOrderings.UpperRestrictiveness.Greater(i1.UpperLimit, i2.UpperLimit);
                }
                else
                {
                    return limitOrderings.LowerRestrictiveness.Less(i1.LowerLimit, i2.LowerLimit);
                }
            })
        {
        }
    }
}
