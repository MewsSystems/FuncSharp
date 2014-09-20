namespace Funcsharp.Options
{
    public class Some<T> : Option<T>
    {
        private T value;

        public Some(T value)
        {
            this.value = value;
        }

        public override bool IsEmpty
        {
            get { return false; }
        }

        public override T Value
        {
            get { return value; }
        }
    }
}
