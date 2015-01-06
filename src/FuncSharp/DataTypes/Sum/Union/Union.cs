using System;

namespace FuncSharp
{
    /// <summary>
    /// Base class of all disjunction types.
    /// </summary>
    public abstract partial class Union : ISum
    {
        protected internal Union(int arity, int discriminator, object value)
        {
            if (arity <= 0)
            {
                throw new ArgumentException("The arity must be a positive number.");
            }
            if (!(discriminator > 0 && discriminator <= arity))
            {
                throw new ArgumentException("The discriminator must be from interval [1, arity].");
            }

            SumArity = arity;
            SumDiscriminator = discriminator;
            SumValue = value;
            Representation = Vector.Create(SumArity, SumDiscriminator, SumValue);
        }

        public int SumArity { get; private set; }
        public int SumDiscriminator { get; private set; }
        public object SumValue { get; private set; }

        private Vector3<int, int, object> Representation { get; set; }

        public override int GetHashCode()
        {
            return Representation.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.FastEquals(obj).GetOrElse(() =>
                Representation.Equals(((Union)obj).Representation)
            );
        }
        public override string ToString()
        {
            return "Union(" + SumDiscriminator + "/" + SumArity + ", " + SumValue.SafeToString() + ")";
        }

        protected T GetSumValue<T>()
        {
            if (SumValue is T)
            {
                return (T)SumValue;
            }
            return default(T);
        }
    }
}
