namespace Funcsharp.Intervals
{
    public class Bound<T>
    {
        /// <summary>
        /// Creates a new bound with the specified value and type.
        /// </summary>
        internal Bound(T value, BoundType type)
        {
            Value = value;
            Type = type;
        }

        /// <summary>
        /// Value of the bound.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Type of the bound.
        /// </summary>
        public BoundType Type { get; private set; }

        public bool IsOpen
        {
            get { return Type == BoundType.Open; }
        }
        public bool IsClosed
        {
            get { return Type == BoundType.Closed; }
        }
    }

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
}
