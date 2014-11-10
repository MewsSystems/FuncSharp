using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public class None<T> : Option<T>
    {
        static None()
        {
            Instance = new None<T>();
        }

        private None()
        {
        }

        /// <summary>
        /// The only instace of the None.
        /// </summary>
        internal static None<T> Instance { get; private set; }

        public override bool IsEmpty
        {
            get { return true; }
        }

        public override IEnumerable<object> ProductValues
        {
            get { return Enumerable.Empty<object>(); }
        }

        public override T Get()
        {
            throw new InvalidOperationException("None doesn't have a value.");
        }

        public override T GetOrElse(Func<T> otherwise)
        {
            return otherwise();
        }

        public override Option<TNewValue> Map<TNewValue>(Func<T, TNewValue> f)
        {
            return None<TNewValue>.Instance;
        }

        public override Option<TNewValue> FlatMap<TNewValue>(Func<T, Option<TNewValue>> f)
        {
            return None<TNewValue>.Instance;
        }
    }
}
