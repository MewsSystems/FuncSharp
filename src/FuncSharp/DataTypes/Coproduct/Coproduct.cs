using System;

namespace FuncSharp
{
    /// <summary>
    /// Base class and factory of canonical coproduct types.
    /// </summary>
    public abstract class Coproduct : ICoproduct
    {
        public Coproduct(int arity, int discriminator, object value)
        {
            if (arity <= 0)
            {
                throw new ArgumentException("The arity must be a positive number.");
            }
            if (discriminator < 1 || arity < discriminator)
            {
                throw new ArgumentException("The discriminator must be from interval [1, arity].");
            }

            CoproductArity = arity;
            CoproductDiscriminator = discriminator;
            CoproductValue = value;
        }

        public int CoproductArity { get; }

        public int CoproductDiscriminator { get; }

        public object CoproductValue { get; }

        /// <summary>
        /// Creates a new 1-dimensional coproduct with the first value.
        /// </summary>
        public static ICoproduct1<T1> CreateFirst<T1>(T1 value)
        {
            return new Coproduct1<T1>(value);
        }

        /// <summary>
        /// Creates a new 2-dimensional coproduct with the second value.
        /// </summary>
        public static ICoproduct2<T1, T2> CreateFirst<T1, T2>(T1 value)
        {
            return new Coproduct2<T1, T2>(value);
        }

        /// <summary>
        /// Creates a new 2-dimensional coproduct with the second value.
        /// </summary>
        public static ICoproduct2<T1, T2> CreateSecond<T1, T2>(T2 value)
        {
            return new Coproduct2<T1, T2>(value);
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct with the third value.
        /// </summary>
        public static ICoproduct3<T1, T2, T3> CreateFirst<T1, T2, T3>(T1 value)
        {
            return new Coproduct3<T1, T2, T3>(value);
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct with the third value.
        /// </summary>
        public static ICoproduct3<T1, T2, T3> CreateSecond<T1, T2, T3>(T2 value)
        {
            return new Coproduct3<T1, T2, T3>(value);
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct with the third value.
        /// </summary>
        public static ICoproduct3<T1, T2, T3> CreateThird<T1, T2, T3>(T3 value)
        {
            return new Coproduct3<T1, T2, T3>(value);
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct with the fourth value.
        /// </summary>
        public static ICoproduct4<T1, T2, T3, T4> CreateFirst<T1, T2, T3, T4>(T1 value)
        {
            return new Coproduct4<T1, T2, T3, T4>(value);
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct with the fourth value.
        /// </summary>
        public static ICoproduct4<T1, T2, T3, T4> CreateSecond<T1, T2, T3, T4>(T2 value)
        {
            return new Coproduct4<T1, T2, T3, T4>(value);
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct with the fourth value.
        /// </summary>
        public static ICoproduct4<T1, T2, T3, T4> CreateThird<T1, T2, T3, T4>(T3 value)
        {
            return new Coproduct4<T1, T2, T3, T4>(value);
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct with the fourth value.
        /// </summary>
        public static ICoproduct4<T1, T2, T3, T4> CreateFourth<T1, T2, T3, T4>(T4 value)
        {
            return new Coproduct4<T1, T2, T3, T4>(value);
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct with the fifth value.
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, T5> CreateFirst<T1, T2, T3, T4, T5>(T1 value)
        {
            return new Coproduct5<T1, T2, T3, T4, T5>(value);
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct with the fifth value.
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, T5> CreateSecond<T1, T2, T3, T4, T5>(T2 value)
        {
            return new Coproduct5<T1, T2, T3, T4, T5>(value);
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct with the fifth value.
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, T5> CreateThird<T1, T2, T3, T4, T5>(T3 value)
        {
            return new Coproduct5<T1, T2, T3, T4, T5>(value);
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct with the fifth value.
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, T5> CreateFourth<T1, T2, T3, T4, T5>(T4 value)
        {
            return new Coproduct5<T1, T2, T3, T4, T5>(value);
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct with the fifth value.
        /// </summary>
        public static ICoproduct5<T1, T2, T3, T4, T5> CreateFifth<T1, T2, T3, T4, T5>(T5 value)
        {
            return new Coproduct5<T1, T2, T3, T4, T5>(value);
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the sixth value.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, T6> CreateFirst<T1, T2, T3, T4, T5, T6>(T1 value)
        {
            return new Coproduct6<T1, T2, T3, T4, T5, T6>(value);
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the sixth value.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, T6> CreateSecond<T1, T2, T3, T4, T5, T6>(T2 value)
        {
            return new Coproduct6<T1, T2, T3, T4, T5, T6>(value);
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the sixth value.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, T6> CreateThird<T1, T2, T3, T4, T5, T6>(T3 value)
        {
            return new Coproduct6<T1, T2, T3, T4, T5, T6>(value);
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the sixth value.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, T6> CreateFourth<T1, T2, T3, T4, T5, T6>(T4 value)
        {
            return new Coproduct6<T1, T2, T3, T4, T5, T6>(value);
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the sixth value.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, T6> CreateFifth<T1, T2, T3, T4, T5, T6>(T5 value)
        {
            return new Coproduct6<T1, T2, T3, T4, T5, T6>(value);
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the sixth value.
        /// </summary>
        public static ICoproduct6<T1, T2, T3, T4, T5, T6> CreateSixth<T1, T2, T3, T4, T5, T6>(T6 value)
        {
            return new Coproduct6<T1, T2, T3, T4, T5, T6>(value);
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the seventh value.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, T7> CreateFirst<T1, T2, T3, T4, T5, T6, T7>(T1 value)
        {
            return new Coproduct7<T1, T2, T3, T4, T5, T6, T7>(value);
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the seventh value.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, T7> CreateSecond<T1, T2, T3, T4, T5, T6, T7>(T2 value)
        {
            return new Coproduct7<T1, T2, T3, T4, T5, T6, T7>(value);
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the seventh value.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, T7> CreateThird<T1, T2, T3, T4, T5, T6, T7>(T3 value)
        {
            return new Coproduct7<T1, T2, T3, T4, T5, T6, T7>(value);
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the seventh value.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, T7> CreateFourth<T1, T2, T3, T4, T5, T6, T7>(T4 value)
        {
            return new Coproduct7<T1, T2, T3, T4, T5, T6, T7>(value);
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the seventh value.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, T7> CreateFifth<T1, T2, T3, T4, T5, T6, T7>(T5 value)
        {
            return new Coproduct7<T1, T2, T3, T4, T5, T6, T7>(value);
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the seventh value.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, T7> CreateSixth<T1, T2, T3, T4, T5, T6, T7>(T6 value)
        {
            return new Coproduct7<T1, T2, T3, T4, T5, T6, T7>(value);
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the seventh value.
        /// </summary>
        public static ICoproduct7<T1, T2, T3, T4, T5, T6, T7> CreateSeventh<T1, T2, T3, T4, T5, T6, T7>(T7 value)
        {
            return new Coproduct7<T1, T2, T3, T4, T5, T6, T7>(value);
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the eighth value.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value)
        {
            return new Coproduct8<T1, T2, T3, T4, T5, T6, T7, T8>(value);
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the eighth value.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>(T2 value)
        {
            return new Coproduct8<T1, T2, T3, T4, T5, T6, T7, T8>(value);
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the eighth value.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>(T3 value)
        {
            return new Coproduct8<T1, T2, T3, T4, T5, T6, T7, T8>(value);
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the eighth value.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>(T4 value)
        {
            return new Coproduct8<T1, T2, T3, T4, T5, T6, T7, T8>(value);
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the eighth value.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>(T5 value)
        {
            return new Coproduct8<T1, T2, T3, T4, T5, T6, T7, T8>(value);
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the eighth value.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>(T6 value)
        {
            return new Coproduct8<T1, T2, T3, T4, T5, T6, T7, T8>(value);
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the eighth value.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>(T7 value)
        {
            return new Coproduct8<T1, T2, T3, T4, T5, T6, T7, T8>(value);
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the eighth value.
        /// </summary>
        public static ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8>(T8 value)
        {
            return new Coproduct8<T1, T2, T3, T4, T5, T6, T7, T8>(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the ninth value.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 value)
        {
            return new Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the ninth value.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 value)
        {
            return new Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the ninth value.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 value)
        {
            return new Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the ninth value.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 value)
        {
            return new Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the ninth value.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 value)
        {
            return new Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the ninth value.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 value)
        {
            return new Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the ninth value.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 value)
        {
            return new Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the ninth value.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 value)
        {
            return new Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the ninth value.
        /// </summary>
        public static ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 value)
        {
            return new Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(value);
        }

        public override int GetHashCode()
        {
            return this.CoproductHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.CoproductEquals(obj);
        }

        public override string ToString()
        {
            return this.CoproductToString();
        }

        protected T GetCoproductValue<T>()
        {
            if (CoproductValue is T)
            {
                return (T)CoproductValue;
            }
            return default(T);
        }
    }

    /// <summary>
    /// A 0-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct0 : Coproduct, ICoproduct0
    {
        protected Coproduct0()
            : base(0, 0, null)
        {
        }
    }

    /// <summary>
    /// A 1-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct1<T1> : Coproduct, ICoproduct1<T1>
    {
        /// <summary>
        /// Creates a new 1-dimensional coproduct with the specified value on the first position.
        /// </summary>
        public Coproduct1(T1 firstValue)
            : this(1, firstValue)
        {
        }


        /// <summary>
        /// Creates a new 1-dimensional coproduct based on the specified source.
        /// </summary>
        public Coproduct1(ICoproduct1<T1> source)
            : this(source.CoproductDiscriminator, source.CoproductValue)
        {
        }

        /// <summary>
        /// Creates a new 1-dimensional coproduct.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the coproduct on the position defined by the discriminator.</param>
        protected Coproduct1(int discriminator, object value)
            : base(1, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return CoproductDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get { return IsFirst ? Option.Valued(GetCoproductValue<T1>()) : Option.Empty<T1>(); }
        }

        public R Match<R>(
            Func<T1, R> ifFirst)
        {
            switch (CoproductDiscriminator)
            {
                case 1: return ifFirst(GetCoproductValue<T1>());
                default: return default(R);
            }
        }

        public void Match(
            Action<T1> ifFirst = null)
        {
            switch (CoproductDiscriminator)
            {
                case 1: if (ifFirst != null) { ifFirst(GetCoproductValue<T1>()); } break;
            }
        }
    }

    /// <summary>
    /// A 2-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct2<T1, T2> : Coproduct, ICoproduct2<T1, T2>
    {
        /// <summary>
        /// Creates a new 2-dimensional coproduct with the specified value on the first position.
        /// </summary>
        public Coproduct2(T1 firstValue)
            : this(1, firstValue)
        {
        }

        /// <summary>
        /// Creates a new 2-dimensional coproduct with the specified value on the second position.
        /// </summary>
        public Coproduct2(T2 secondValue)
            : this(2, secondValue)
        {
        }


        /// <summary>
        /// Creates a new 2-dimensional coproduct based on the specified source.
        /// </summary>
        public Coproduct2(ICoproduct2<T1, T2> source)
            : this(source.CoproductDiscriminator, source.CoproductValue)
        {
        }

        /// <summary>
        /// Creates a new 2-dimensional coproduct.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the coproduct on the position defined by the discriminator.</param>
        protected Coproduct2(int discriminator, object value)
            : base(2, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return CoproductDiscriminator == 1; }
        }
        public bool IsSecond
        {
            get { return CoproductDiscriminator == 2; }
        }

        public IOption<T1> First
        {
            get { return IsFirst ? Option.Valued(GetCoproductValue<T1>()) : Option.Empty<T1>(); }
        }
        public IOption<T2> Second
        {
            get { return IsSecond ? Option.Valued(GetCoproductValue<T2>()) : Option.Empty<T2>(); }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond)
        {
            switch (CoproductDiscriminator)
            {
                case 1: return ifFirst(GetCoproductValue<T1>());
                case 2: return ifSecond(GetCoproductValue<T2>());
                default: return default(R);
            }
        }

        public void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null)
        {
            switch (CoproductDiscriminator)
            {
                case 1: if (ifFirst != null) { ifFirst(GetCoproductValue<T1>()); } break;
                case 2: if (ifSecond != null) { ifSecond(GetCoproductValue<T2>()); } break;
            }
        }
    }

    /// <summary>
    /// A 3-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct3<T1, T2, T3> : Coproduct, ICoproduct3<T1, T2, T3>
    {
        /// <summary>
        /// Creates a new 3-dimensional coproduct with the specified value on the first position.
        /// </summary>
        public Coproduct3(T1 firstValue)
            : this(1, firstValue)
        {
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct with the specified value on the second position.
        /// </summary>
        public Coproduct3(T2 secondValue)
            : this(2, secondValue)
        {
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct with the specified value on the third position.
        /// </summary>
        public Coproduct3(T3 thirdValue)
            : this(3, thirdValue)
        {
        }


        /// <summary>
        /// Creates a new 3-dimensional coproduct based on the specified source.
        /// </summary>
        public Coproduct3(ICoproduct3<T1, T2, T3> source)
            : this(source.CoproductDiscriminator, source.CoproductValue)
        {
        }

        /// <summary>
        /// Creates a new 3-dimensional coproduct.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the coproduct on the position defined by the discriminator.</param>
        protected Coproduct3(int discriminator, object value)
            : base(3, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return CoproductDiscriminator == 1; }
        }
        public bool IsSecond
        {
            get { return CoproductDiscriminator == 2; }
        }
        public bool IsThird
        {
            get { return CoproductDiscriminator == 3; }
        }

        public IOption<T1> First
        {
            get { return IsFirst ? Option.Valued(GetCoproductValue<T1>()) : Option.Empty<T1>(); }
        }
        public IOption<T2> Second
        {
            get { return IsSecond ? Option.Valued(GetCoproductValue<T2>()) : Option.Empty<T2>(); }
        }
        public IOption<T3> Third
        {
            get { return IsThird ? Option.Valued(GetCoproductValue<T3>()) : Option.Empty<T3>(); }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird)
        {
            switch (CoproductDiscriminator)
            {
                case 1: return ifFirst(GetCoproductValue<T1>());
                case 2: return ifSecond(GetCoproductValue<T2>());
                case 3: return ifThird(GetCoproductValue<T3>());
                default: return default(R);
            }
        }

        public void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null)
        {
            switch (CoproductDiscriminator)
            {
                case 1: if (ifFirst != null) { ifFirst(GetCoproductValue<T1>()); } break;
                case 2: if (ifSecond != null) { ifSecond(GetCoproductValue<T2>()); } break;
                case 3: if (ifThird != null) { ifThird(GetCoproductValue<T3>()); } break;
            }
        }
    }

    /// <summary>
    /// A 4-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct4<T1, T2, T3, T4> : Coproduct, ICoproduct4<T1, T2, T3, T4>
    {
        /// <summary>
        /// Creates a new 4-dimensional coproduct with the specified value on the first position.
        /// </summary>
        public Coproduct4(T1 firstValue)
            : this(1, firstValue)
        {
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct with the specified value on the second position.
        /// </summary>
        public Coproduct4(T2 secondValue)
            : this(2, secondValue)
        {
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct with the specified value on the third position.
        /// </summary>
        public Coproduct4(T3 thirdValue)
            : this(3, thirdValue)
        {
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct with the specified value on the fourth position.
        /// </summary>
        public Coproduct4(T4 fourthValue)
            : this(4, fourthValue)
        {
        }


        /// <summary>
        /// Creates a new 4-dimensional coproduct based on the specified source.
        /// </summary>
        public Coproduct4(ICoproduct4<T1, T2, T3, T4> source)
            : this(source.CoproductDiscriminator, source.CoproductValue)
        {
        }

        /// <summary>
        /// Creates a new 4-dimensional coproduct.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the coproduct on the position defined by the discriminator.</param>
        protected Coproduct4(int discriminator, object value)
            : base(4, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return CoproductDiscriminator == 1; }
        }
        public bool IsSecond
        {
            get { return CoproductDiscriminator == 2; }
        }
        public bool IsThird
        {
            get { return CoproductDiscriminator == 3; }
        }
        public bool IsFourth
        {
            get { return CoproductDiscriminator == 4; }
        }

        public IOption<T1> First
        {
            get { return IsFirst ? Option.Valued(GetCoproductValue<T1>()) : Option.Empty<T1>(); }
        }
        public IOption<T2> Second
        {
            get { return IsSecond ? Option.Valued(GetCoproductValue<T2>()) : Option.Empty<T2>(); }
        }
        public IOption<T3> Third
        {
            get { return IsThird ? Option.Valued(GetCoproductValue<T3>()) : Option.Empty<T3>(); }
        }
        public IOption<T4> Fourth
        {
            get { return IsFourth ? Option.Valued(GetCoproductValue<T4>()) : Option.Empty<T4>(); }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth)
        {
            switch (CoproductDiscriminator)
            {
                case 1: return ifFirst(GetCoproductValue<T1>());
                case 2: return ifSecond(GetCoproductValue<T2>());
                case 3: return ifThird(GetCoproductValue<T3>());
                case 4: return ifFourth(GetCoproductValue<T4>());
                default: return default(R);
            }
        }

        public void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null)
        {
            switch (CoproductDiscriminator)
            {
                case 1: if (ifFirst != null) { ifFirst(GetCoproductValue<T1>()); } break;
                case 2: if (ifSecond != null) { ifSecond(GetCoproductValue<T2>()); } break;
                case 3: if (ifThird != null) { ifThird(GetCoproductValue<T3>()); } break;
                case 4: if (ifFourth != null) { ifFourth(GetCoproductValue<T4>()); } break;
            }
        }
    }

    /// <summary>
    /// A 5-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct5<T1, T2, T3, T4, T5> : Coproduct, ICoproduct5<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Creates a new 5-dimensional coproduct with the specified value on the first position.
        /// </summary>
        public Coproduct5(T1 firstValue)
            : this(1, firstValue)
        {
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct with the specified value on the second position.
        /// </summary>
        public Coproduct5(T2 secondValue)
            : this(2, secondValue)
        {
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct with the specified value on the third position.
        /// </summary>
        public Coproduct5(T3 thirdValue)
            : this(3, thirdValue)
        {
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct with the specified value on the fourth position.
        /// </summary>
        public Coproduct5(T4 fourthValue)
            : this(4, fourthValue)
        {
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct with the specified value on the fifth position.
        /// </summary>
        public Coproduct5(T5 fifthValue)
            : this(5, fifthValue)
        {
        }


        /// <summary>
        /// Creates a new 5-dimensional coproduct based on the specified source.
        /// </summary>
        public Coproduct5(ICoproduct5<T1, T2, T3, T4, T5> source)
            : this(source.CoproductDiscriminator, source.CoproductValue)
        {
        }

        /// <summary>
        /// Creates a new 5-dimensional coproduct.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the coproduct on the position defined by the discriminator.</param>
        protected Coproduct5(int discriminator, object value)
            : base(5, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return CoproductDiscriminator == 1; }
        }
        public bool IsSecond
        {
            get { return CoproductDiscriminator == 2; }
        }
        public bool IsThird
        {
            get { return CoproductDiscriminator == 3; }
        }
        public bool IsFourth
        {
            get { return CoproductDiscriminator == 4; }
        }
        public bool IsFifth
        {
            get { return CoproductDiscriminator == 5; }
        }

        public IOption<T1> First
        {
            get { return IsFirst ? Option.Valued(GetCoproductValue<T1>()) : Option.Empty<T1>(); }
        }
        public IOption<T2> Second
        {
            get { return IsSecond ? Option.Valued(GetCoproductValue<T2>()) : Option.Empty<T2>(); }
        }
        public IOption<T3> Third
        {
            get { return IsThird ? Option.Valued(GetCoproductValue<T3>()) : Option.Empty<T3>(); }
        }
        public IOption<T4> Fourth
        {
            get { return IsFourth ? Option.Valued(GetCoproductValue<T4>()) : Option.Empty<T4>(); }
        }
        public IOption<T5> Fifth
        {
            get { return IsFifth ? Option.Valued(GetCoproductValue<T5>()) : Option.Empty<T5>(); }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth)
        {
            switch (CoproductDiscriminator)
            {
                case 1: return ifFirst(GetCoproductValue<T1>());
                case 2: return ifSecond(GetCoproductValue<T2>());
                case 3: return ifThird(GetCoproductValue<T3>());
                case 4: return ifFourth(GetCoproductValue<T4>());
                case 5: return ifFifth(GetCoproductValue<T5>());
                default: return default(R);
            }
        }

        public void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null)
        {
            switch (CoproductDiscriminator)
            {
                case 1: if (ifFirst != null) { ifFirst(GetCoproductValue<T1>()); } break;
                case 2: if (ifSecond != null) { ifSecond(GetCoproductValue<T2>()); } break;
                case 3: if (ifThird != null) { ifThird(GetCoproductValue<T3>()); } break;
                case 4: if (ifFourth != null) { ifFourth(GetCoproductValue<T4>()); } break;
                case 5: if (ifFifth != null) { ifFifth(GetCoproductValue<T5>()); } break;
            }
        }
    }

    /// <summary>
    /// A 6-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct6<T1, T2, T3, T4, T5, T6> : Coproduct, ICoproduct6<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// Creates a new 6-dimensional coproduct with the specified value on the first position.
        /// </summary>
        public Coproduct6(T1 firstValue)
            : this(1, firstValue)
        {
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the specified value on the second position.
        /// </summary>
        public Coproduct6(T2 secondValue)
            : this(2, secondValue)
        {
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the specified value on the third position.
        /// </summary>
        public Coproduct6(T3 thirdValue)
            : this(3, thirdValue)
        {
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the specified value on the fourth position.
        /// </summary>
        public Coproduct6(T4 fourthValue)
            : this(4, fourthValue)
        {
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the specified value on the fifth position.
        /// </summary>
        public Coproduct6(T5 fifthValue)
            : this(5, fifthValue)
        {
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct with the specified value on the sixth position.
        /// </summary>
        public Coproduct6(T6 sixthValue)
            : this(6, sixthValue)
        {
        }


        /// <summary>
        /// Creates a new 6-dimensional coproduct based on the specified source.
        /// </summary>
        public Coproduct6(ICoproduct6<T1, T2, T3, T4, T5, T6> source)
            : this(source.CoproductDiscriminator, source.CoproductValue)
        {
        }

        /// <summary>
        /// Creates a new 6-dimensional coproduct.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the coproduct on the position defined by the discriminator.</param>
        protected Coproduct6(int discriminator, object value)
            : base(6, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return CoproductDiscriminator == 1; }
        }
        public bool IsSecond
        {
            get { return CoproductDiscriminator == 2; }
        }
        public bool IsThird
        {
            get { return CoproductDiscriminator == 3; }
        }
        public bool IsFourth
        {
            get { return CoproductDiscriminator == 4; }
        }
        public bool IsFifth
        {
            get { return CoproductDiscriminator == 5; }
        }
        public bool IsSixth
        {
            get { return CoproductDiscriminator == 6; }
        }

        public IOption<T1> First
        {
            get { return IsFirst ? Option.Valued(GetCoproductValue<T1>()) : Option.Empty<T1>(); }
        }
        public IOption<T2> Second
        {
            get { return IsSecond ? Option.Valued(GetCoproductValue<T2>()) : Option.Empty<T2>(); }
        }
        public IOption<T3> Third
        {
            get { return IsThird ? Option.Valued(GetCoproductValue<T3>()) : Option.Empty<T3>(); }
        }
        public IOption<T4> Fourth
        {
            get { return IsFourth ? Option.Valued(GetCoproductValue<T4>()) : Option.Empty<T4>(); }
        }
        public IOption<T5> Fifth
        {
            get { return IsFifth ? Option.Valued(GetCoproductValue<T5>()) : Option.Empty<T5>(); }
        }
        public IOption<T6> Sixth
        {
            get { return IsSixth ? Option.Valued(GetCoproductValue<T6>()) : Option.Empty<T6>(); }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth)
        {
            switch (CoproductDiscriminator)
            {
                case 1: return ifFirst(GetCoproductValue<T1>());
                case 2: return ifSecond(GetCoproductValue<T2>());
                case 3: return ifThird(GetCoproductValue<T3>());
                case 4: return ifFourth(GetCoproductValue<T4>());
                case 5: return ifFifth(GetCoproductValue<T5>());
                case 6: return ifSixth(GetCoproductValue<T6>());
                default: return default(R);
            }
        }

        public void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null)
        {
            switch (CoproductDiscriminator)
            {
                case 1: if (ifFirst != null) { ifFirst(GetCoproductValue<T1>()); } break;
                case 2: if (ifSecond != null) { ifSecond(GetCoproductValue<T2>()); } break;
                case 3: if (ifThird != null) { ifThird(GetCoproductValue<T3>()); } break;
                case 4: if (ifFourth != null) { ifFourth(GetCoproductValue<T4>()); } break;
                case 5: if (ifFifth != null) { ifFifth(GetCoproductValue<T5>()); } break;
                case 6: if (ifSixth != null) { ifSixth(GetCoproductValue<T6>()); } break;
            }
        }
    }

    /// <summary>
    /// A 7-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct7<T1, T2, T3, T4, T5, T6, T7> : Coproduct, ICoproduct7<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        /// Creates a new 7-dimensional coproduct with the specified value on the first position.
        /// </summary>
        public Coproduct7(T1 firstValue)
            : this(1, firstValue)
        {
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the specified value on the second position.
        /// </summary>
        public Coproduct7(T2 secondValue)
            : this(2, secondValue)
        {
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the specified value on the third position.
        /// </summary>
        public Coproduct7(T3 thirdValue)
            : this(3, thirdValue)
        {
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the specified value on the fourth position.
        /// </summary>
        public Coproduct7(T4 fourthValue)
            : this(4, fourthValue)
        {
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the specified value on the fifth position.
        /// </summary>
        public Coproduct7(T5 fifthValue)
            : this(5, fifthValue)
        {
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the specified value on the sixth position.
        /// </summary>
        public Coproduct7(T6 sixthValue)
            : this(6, sixthValue)
        {
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct with the specified value on the seventh position.
        /// </summary>
        public Coproduct7(T7 seventhValue)
            : this(7, seventhValue)
        {
        }


        /// <summary>
        /// Creates a new 7-dimensional coproduct based on the specified source.
        /// </summary>
        public Coproduct7(ICoproduct7<T1, T2, T3, T4, T5, T6, T7> source)
            : this(source.CoproductDiscriminator, source.CoproductValue)
        {
        }

        /// <summary>
        /// Creates a new 7-dimensional coproduct.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the coproduct on the position defined by the discriminator.</param>
        protected Coproduct7(int discriminator, object value)
            : base(7, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return CoproductDiscriminator == 1; }
        }
        public bool IsSecond
        {
            get { return CoproductDiscriminator == 2; }
        }
        public bool IsThird
        {
            get { return CoproductDiscriminator == 3; }
        }
        public bool IsFourth
        {
            get { return CoproductDiscriminator == 4; }
        }
        public bool IsFifth
        {
            get { return CoproductDiscriminator == 5; }
        }
        public bool IsSixth
        {
            get { return CoproductDiscriminator == 6; }
        }
        public bool IsSeventh
        {
            get { return CoproductDiscriminator == 7; }
        }

        public IOption<T1> First
        {
            get { return IsFirst ? Option.Valued(GetCoproductValue<T1>()) : Option.Empty<T1>(); }
        }
        public IOption<T2> Second
        {
            get { return IsSecond ? Option.Valued(GetCoproductValue<T2>()) : Option.Empty<T2>(); }
        }
        public IOption<T3> Third
        {
            get { return IsThird ? Option.Valued(GetCoproductValue<T3>()) : Option.Empty<T3>(); }
        }
        public IOption<T4> Fourth
        {
            get { return IsFourth ? Option.Valued(GetCoproductValue<T4>()) : Option.Empty<T4>(); }
        }
        public IOption<T5> Fifth
        {
            get { return IsFifth ? Option.Valued(GetCoproductValue<T5>()) : Option.Empty<T5>(); }
        }
        public IOption<T6> Sixth
        {
            get { return IsSixth ? Option.Valued(GetCoproductValue<T6>()) : Option.Empty<T6>(); }
        }
        public IOption<T7> Seventh
        {
            get { return IsSeventh ? Option.Valued(GetCoproductValue<T7>()) : Option.Empty<T7>(); }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh)
        {
            switch (CoproductDiscriminator)
            {
                case 1: return ifFirst(GetCoproductValue<T1>());
                case 2: return ifSecond(GetCoproductValue<T2>());
                case 3: return ifThird(GetCoproductValue<T3>());
                case 4: return ifFourth(GetCoproductValue<T4>());
                case 5: return ifFifth(GetCoproductValue<T5>());
                case 6: return ifSixth(GetCoproductValue<T6>());
                case 7: return ifSeventh(GetCoproductValue<T7>());
                default: return default(R);
            }
        }

        public void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null)
        {
            switch (CoproductDiscriminator)
            {
                case 1: if (ifFirst != null) { ifFirst(GetCoproductValue<T1>()); } break;
                case 2: if (ifSecond != null) { ifSecond(GetCoproductValue<T2>()); } break;
                case 3: if (ifThird != null) { ifThird(GetCoproductValue<T3>()); } break;
                case 4: if (ifFourth != null) { ifFourth(GetCoproductValue<T4>()); } break;
                case 5: if (ifFifth != null) { ifFifth(GetCoproductValue<T5>()); } break;
                case 6: if (ifSixth != null) { ifSixth(GetCoproductValue<T6>()); } break;
                case 7: if (ifSeventh != null) { ifSeventh(GetCoproductValue<T7>()); } break;
            }
        }
    }

    /// <summary>
    /// A 8-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct8<T1, T2, T3, T4, T5, T6, T7, T8> : Coproduct, ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        /// Creates a new 8-dimensional coproduct with the specified value on the first position.
        /// </summary>
        public Coproduct8(T1 firstValue)
            : this(1, firstValue)
        {
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the specified value on the second position.
        /// </summary>
        public Coproduct8(T2 secondValue)
            : this(2, secondValue)
        {
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the specified value on the third position.
        /// </summary>
        public Coproduct8(T3 thirdValue)
            : this(3, thirdValue)
        {
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the specified value on the fourth position.
        /// </summary>
        public Coproduct8(T4 fourthValue)
            : this(4, fourthValue)
        {
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the specified value on the fifth position.
        /// </summary>
        public Coproduct8(T5 fifthValue)
            : this(5, fifthValue)
        {
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the specified value on the sixth position.
        /// </summary>
        public Coproduct8(T6 sixthValue)
            : this(6, sixthValue)
        {
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the specified value on the seventh position.
        /// </summary>
        public Coproduct8(T7 seventhValue)
            : this(7, seventhValue)
        {
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct with the specified value on the eighth position.
        /// </summary>
        public Coproduct8(T8 eighthValue)
            : this(8, eighthValue)
        {
        }


        /// <summary>
        /// Creates a new 8-dimensional coproduct based on the specified source.
        /// </summary>
        public Coproduct8(ICoproduct8<T1, T2, T3, T4, T5, T6, T7, T8> source)
            : this(source.CoproductDiscriminator, source.CoproductValue)
        {
        }

        /// <summary>
        /// Creates a new 8-dimensional coproduct.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the coproduct on the position defined by the discriminator.</param>
        protected Coproduct8(int discriminator, object value)
            : base(8, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return CoproductDiscriminator == 1; }
        }
        public bool IsSecond
        {
            get { return CoproductDiscriminator == 2; }
        }
        public bool IsThird
        {
            get { return CoproductDiscriminator == 3; }
        }
        public bool IsFourth
        {
            get { return CoproductDiscriminator == 4; }
        }
        public bool IsFifth
        {
            get { return CoproductDiscriminator == 5; }
        }
        public bool IsSixth
        {
            get { return CoproductDiscriminator == 6; }
        }
        public bool IsSeventh
        {
            get { return CoproductDiscriminator == 7; }
        }
        public bool IsEighth
        {
            get { return CoproductDiscriminator == 8; }
        }

        public IOption<T1> First
        {
            get { return IsFirst ? Option.Valued(GetCoproductValue<T1>()) : Option.Empty<T1>(); }
        }
        public IOption<T2> Second
        {
            get { return IsSecond ? Option.Valued(GetCoproductValue<T2>()) : Option.Empty<T2>(); }
        }
        public IOption<T3> Third
        {
            get { return IsThird ? Option.Valued(GetCoproductValue<T3>()) : Option.Empty<T3>(); }
        }
        public IOption<T4> Fourth
        {
            get { return IsFourth ? Option.Valued(GetCoproductValue<T4>()) : Option.Empty<T4>(); }
        }
        public IOption<T5> Fifth
        {
            get { return IsFifth ? Option.Valued(GetCoproductValue<T5>()) : Option.Empty<T5>(); }
        }
        public IOption<T6> Sixth
        {
            get { return IsSixth ? Option.Valued(GetCoproductValue<T6>()) : Option.Empty<T6>(); }
        }
        public IOption<T7> Seventh
        {
            get { return IsSeventh ? Option.Valued(GetCoproductValue<T7>()) : Option.Empty<T7>(); }
        }
        public IOption<T8> Eighth
        {
            get { return IsEighth ? Option.Valued(GetCoproductValue<T8>()) : Option.Empty<T8>(); }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth)
        {
            switch (CoproductDiscriminator)
            {
                case 1: return ifFirst(GetCoproductValue<T1>());
                case 2: return ifSecond(GetCoproductValue<T2>());
                case 3: return ifThird(GetCoproductValue<T3>());
                case 4: return ifFourth(GetCoproductValue<T4>());
                case 5: return ifFifth(GetCoproductValue<T5>());
                case 6: return ifSixth(GetCoproductValue<T6>());
                case 7: return ifSeventh(GetCoproductValue<T7>());
                case 8: return ifEighth(GetCoproductValue<T8>());
                default: return default(R);
            }
        }

        public void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null)
        {
            switch (CoproductDiscriminator)
            {
                case 1: if (ifFirst != null) { ifFirst(GetCoproductValue<T1>()); } break;
                case 2: if (ifSecond != null) { ifSecond(GetCoproductValue<T2>()); } break;
                case 3: if (ifThird != null) { ifThird(GetCoproductValue<T3>()); } break;
                case 4: if (ifFourth != null) { ifFourth(GetCoproductValue<T4>()); } break;
                case 5: if (ifFifth != null) { ifFifth(GetCoproductValue<T5>()); } break;
                case 6: if (ifSixth != null) { ifSixth(GetCoproductValue<T6>()); } break;
                case 7: if (ifSeventh != null) { ifSeventh(GetCoproductValue<T7>()); } break;
                case 8: if (ifEighth != null) { ifEighth(GetCoproductValue<T8>()); } break;
            }
        }
    }

    /// <summary>
    /// A 9-dimensional immutable coproduct.
    /// </summary> 
    public class Coproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Coproduct, ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        /// <summary>
        /// Creates a new 9-dimensional coproduct with the specified value on the first position.
        /// </summary>
        public Coproduct9(T1 firstValue)
            : this(1, firstValue)
        {
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the specified value on the second position.
        /// </summary>
        public Coproduct9(T2 secondValue)
            : this(2, secondValue)
        {
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the specified value on the third position.
        /// </summary>
        public Coproduct9(T3 thirdValue)
            : this(3, thirdValue)
        {
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the specified value on the fourth position.
        /// </summary>
        public Coproduct9(T4 fourthValue)
            : this(4, fourthValue)
        {
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the specified value on the fifth position.
        /// </summary>
        public Coproduct9(T5 fifthValue)
            : this(5, fifthValue)
        {
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the specified value on the sixth position.
        /// </summary>
        public Coproduct9(T6 sixthValue)
            : this(6, sixthValue)
        {
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the specified value on the seventh position.
        /// </summary>
        public Coproduct9(T7 seventhValue)
            : this(7, seventhValue)
        {
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the specified value on the eighth position.
        /// </summary>
        public Coproduct9(T8 eighthValue)
            : this(8, eighthValue)
        {
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct with the specified value on the ninth position.
        /// </summary>
        public Coproduct9(T9 ninthValue)
            : this(9, ninthValue)
        {
        }


        /// <summary>
        /// Creates a new 9-dimensional coproduct based on the specified source.
        /// </summary>
        public Coproduct9(ICoproduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> source)
            : this(source.CoproductDiscriminator, source.CoproductValue)
        {
        }

        /// <summary>
        /// Creates a new 9-dimensional coproduct.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the coproduct on the position defined by the discriminator.</param>
        protected Coproduct9(int discriminator, object value)
            : base(9, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return CoproductDiscriminator == 1; }
        }
        public bool IsSecond
        {
            get { return CoproductDiscriminator == 2; }
        }
        public bool IsThird
        {
            get { return CoproductDiscriminator == 3; }
        }
        public bool IsFourth
        {
            get { return CoproductDiscriminator == 4; }
        }
        public bool IsFifth
        {
            get { return CoproductDiscriminator == 5; }
        }
        public bool IsSixth
        {
            get { return CoproductDiscriminator == 6; }
        }
        public bool IsSeventh
        {
            get { return CoproductDiscriminator == 7; }
        }
        public bool IsEighth
        {
            get { return CoproductDiscriminator == 8; }
        }
        public bool IsNinth
        {
            get { return CoproductDiscriminator == 9; }
        }

        public IOption<T1> First
        {
            get { return IsFirst ? Option.Valued(GetCoproductValue<T1>()) : Option.Empty<T1>(); }
        }
        public IOption<T2> Second
        {
            get { return IsSecond ? Option.Valued(GetCoproductValue<T2>()) : Option.Empty<T2>(); }
        }
        public IOption<T3> Third
        {
            get { return IsThird ? Option.Valued(GetCoproductValue<T3>()) : Option.Empty<T3>(); }
        }
        public IOption<T4> Fourth
        {
            get { return IsFourth ? Option.Valued(GetCoproductValue<T4>()) : Option.Empty<T4>(); }
        }
        public IOption<T5> Fifth
        {
            get { return IsFifth ? Option.Valued(GetCoproductValue<T5>()) : Option.Empty<T5>(); }
        }
        public IOption<T6> Sixth
        {
            get { return IsSixth ? Option.Valued(GetCoproductValue<T6>()) : Option.Empty<T6>(); }
        }
        public IOption<T7> Seventh
        {
            get { return IsSeventh ? Option.Valued(GetCoproductValue<T7>()) : Option.Empty<T7>(); }
        }
        public IOption<T8> Eighth
        {
            get { return IsEighth ? Option.Valued(GetCoproductValue<T8>()) : Option.Empty<T8>(); }
        }
        public IOption<T9> Ninth
        {
            get { return IsNinth ? Option.Valued(GetCoproductValue<T9>()) : Option.Empty<T9>(); }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth)
        {
            switch (CoproductDiscriminator)
            {
                case 1: return ifFirst(GetCoproductValue<T1>());
                case 2: return ifSecond(GetCoproductValue<T2>());
                case 3: return ifThird(GetCoproductValue<T3>());
                case 4: return ifFourth(GetCoproductValue<T4>());
                case 5: return ifFifth(GetCoproductValue<T5>());
                case 6: return ifSixth(GetCoproductValue<T6>());
                case 7: return ifSeventh(GetCoproductValue<T7>());
                case 8: return ifEighth(GetCoproductValue<T8>());
                case 9: return ifNinth(GetCoproductValue<T9>());
                default: return default(R);
            }
        }

        public void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null)
        {
            switch (CoproductDiscriminator)
            {
                case 1: if (ifFirst != null) { ifFirst(GetCoproductValue<T1>()); } break;
                case 2: if (ifSecond != null) { ifSecond(GetCoproductValue<T2>()); } break;
                case 3: if (ifThird != null) { ifThird(GetCoproductValue<T3>()); } break;
                case 4: if (ifFourth != null) { ifFourth(GetCoproductValue<T4>()); } break;
                case 5: if (ifFifth != null) { ifFifth(GetCoproductValue<T5>()); } break;
                case 6: if (ifSixth != null) { ifSixth(GetCoproductValue<T6>()); } break;
                case 7: if (ifSeventh != null) { ifSeventh(GetCoproductValue<T7>()); } break;
                case 8: if (ifEighth != null) { ifEighth(GetCoproductValue<T8>()); } break;
                case 9: if (ifNinth != null) { ifNinth(GetCoproductValue<T9>()); } break;
            }
        }
    }

}
