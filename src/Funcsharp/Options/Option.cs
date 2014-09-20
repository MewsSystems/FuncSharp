using System;
using Funcsharp.Reflection;

namespace Funcsharp.Options
{
    public static class Option
    {
        public static Option<T> Create<T>(T value)
        {
            if (value != null)
            {
                return new Some<T>(value);
            }
            return None<T>();
        }

        public static Option<T> Create<T>(T? value)
            where T : struct
        {
            if (value.HasValue)
            {
                return new Some<T>(value.Value);
            }
            return None<T>();
        }

        public static Option<T> None<T>()
        {
            return new None<T>();
        }
    }

    public abstract class Option<T>
    {
        static Option()
        {
            var t = typeof(T);
            if (t.IsNullable())
            {
                throw new InvalidOperationException("An option of nullable type " + t + " isn't supported.");
            }
        }

        public bool NonEmpty
        {
            get { return !IsEmpty; }
        }

        public abstract bool IsEmpty { get; }

        public abstract T Value { get; }
    }
}
