
namespace FuncSharp
{
    public static class Bound
    {
        /// <summary>
        /// Creates a new open (exclusive) bound with the specified value.
        /// </summary>
        public static Bound<T> Open<T>(T value)
        {
            return new Bound<T>(value, BoundType.Open);
        }

        /// <summary>
        /// Creates a new closed (inclusive) bound with the specified value.
        /// </summary>
        public static Bound<T> Closed<T>(T value)
        {
            return new Bound<T>(value, BoundType.Closed);
        }
    }

    public class Bound<T> : Product2<T, BoundType>
    {
        /// <summary>
        /// Creates a new bound with the specified value and type.
        /// </summary>
        internal Bound(T value, BoundType type)
            : base(value, type)
        {
        }

        /// <summary>
        /// Value of the bound.
        /// </summary>
        public T Value
        {
            get { return ProductValue1; }
        }

        /// <summary>
        /// Type of the bound.
        /// </summary>
        public BoundType Type
        {
            get { return ProductValue2; }
        }

        /// <summary>
        /// Returns whether the bound is open (exclusive).
        /// </summary>
        public bool IsOpen
        {
            get { return Type == BoundType.Open; }
        }

        /// <summary>
        /// Returns whether the bound is closed (inclusive).
        /// </summary>
        public bool IsClosed
        {
            get { return Type == BoundType.Closed; }
        }
    }
}
