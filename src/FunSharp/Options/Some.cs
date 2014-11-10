using System;
using System.Collections.Generic;

namespace FuncSharp
{
    public class Some<T> : Option<T>
    {
        private T value;

        internal Some(T value)
        {
            this.value = value;
        }

        public override bool IsEmpty
        {
            get { return false; }
        }

        public override IEnumerable<object> ProductValues
        {
            get { yield return value; }
        }

        public override T Get()
        {
            return value;
        }

        public override T GetOrElse(Func<T> otherwise)
        {
            return value;
        }

        public override Option<TNewValue> Map<TNewValue>(Func<T, TNewValue> f)
        {
            return new Some<TNewValue>(f(value));
        }

        public override Option<TNewValue> FlatMap<TNewValue>(Func<T, Option<TNewValue>> f)
        {
            return f(value);
        }
    }
}
