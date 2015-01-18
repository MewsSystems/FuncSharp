namespace FuncSharp
{
    internal class Some<A> : Option<A>
    {
        private A value;

        public Some(A value)
        {
            this.value = value;
        }

        public override A Value 
        {
            get { return value; }
        }

        public override bool IsEmpty
        {
            get { return true; }
        }
    }
}
