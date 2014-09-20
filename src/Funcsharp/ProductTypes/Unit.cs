using System.Collections.Generic;
using System.Linq;

namespace Funcsharp.ProductTypes
{
    /// <summary>
    /// The Unit type (product of zero types). It has only one instance.
    /// </summary>
    public sealed class Unit : IProduct
    {
        static Unit()
        {
            Instance = new Unit();
        }

        private Unit()
        {

        }

        /// <summary>
        /// The only instance of the Unit type.
        /// </summary>
        public static Unit Instance { get; private set; }

        public IEnumerable<object> ProductValues
        {
            get { return Enumerable.Empty<object>(); }
        }

        public override int GetHashCode()
        {
            return 19;
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override string ToString()
        {
            return "()";
        }
    }
}
