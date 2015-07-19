
namespace FuncSharp
{
    public class ReversedOrdering<A> : TotalOrdering<A>
    {
        public ReversedOrdering(ITotalOrdering<A> originalOrdering)
        {
            OriginalOrdering = originalOrdering;
        }

        public ITotalOrdering<A> OriginalOrdering { get; private set; }

        public override bool Less(A a1, A a2)
        {
            return OriginalOrdering.Greater(a1, a2);
        }

        public override bool Equal(A a1, A a2)
        {
            return OriginalOrdering.Equal(a1, a2);
        }
    }
}
