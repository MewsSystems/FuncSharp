using System;

namespace FuncSharp
{
    /// <summary>
    /// Base class of all disjunction types.
    /// </summary>
    public abstract partial class Sum : ISum
    {
        protected internal Sum(int arity, int discriminator, object value)
        {
            if (arity <= 0)
            {
                throw new ArgumentException("The arity must be a positive number.");
            }
            if (discriminator < 0 || arity < discriminator)
            {
                throw new ArgumentException("The discriminator must be from interval [1, arity].");
            }

            SumArity = arity;
            SumDiscriminator = discriminator;
            SumValue = value;
        }

        public int SumArity { get; private set; }
        public int SumDiscriminator { get; private set; }
        public object SumValue { get; private set; }

        public override int GetHashCode()
        {
            return this.SumHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.SumEquals(obj);
        }
        public override string ToString()
        {
            return this.SumToString();
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
