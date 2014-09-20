using System;

namespace Funcsharp.Options
{
    public class None<T> : Option<T>
    {
        public override bool IsEmpty
        {
            get { return true; }
        }

        public override T Value
        {
            get { throw new InvalidOperationException("None doesn't have a value."); }
        }
    }
}
