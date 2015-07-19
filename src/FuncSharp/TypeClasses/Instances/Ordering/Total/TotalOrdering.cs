namespace FuncSharp
{
    public abstract class TotalOrdering<A> : ITotalOrdering<A>
    {
        public TotalOrdering()
        {
            TraitDataStorage = new TraitDataStorage();
        }

        public TraitDataStorage TraitDataStorage { get; private set; }

        public abstract bool Less(A a1, A a2);

        public virtual bool Equal(A a1, A a2)
        {
            return a1.Equals(a2);
        }
    }
}
