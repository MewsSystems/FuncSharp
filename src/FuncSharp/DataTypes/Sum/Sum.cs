using System;

namespace FuncSharp
{
    /// <summary>
    /// Base class and factory of canonical sum types.
    /// </summary>
    public abstract class Sum : ISum
    {
        public Sum(int arity, int discriminator, object value)
        {
            if (arity <= 0)
            {
                throw new ArgumentException("The arity must be a positive number.");
            }
            if (discriminator < 1 || arity < discriminator)
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

        /// <summary>
        /// Creates a new 1-dimensional sum with the first value.
        /// </summary>
        public static ISum1<T1> CreateFirst<T1>(T1 t1)
        {
            return new Sum1<T1>(1, t1);
        }

        /// <summary>
        /// Creates a new 2-dimensional sum with the second value.
        /// </summary>
        public static ISum2<T1, T2> CreateFirst<T1, T2>(T1 t1)
        {
            return new Sum2<T1, T2>(1, t1);
        }

        /// <summary>
        /// Creates a new 2-dimensional sum with the second value.
        /// </summary>
        public static ISum2<T1, T2> CreateSecond<T1, T2>(T2 t2)
        {
            return new Sum2<T1, T2>(2, t2);
        }

        /// <summary>
        /// Creates a new 3-dimensional sum with the third value.
        /// </summary>
        public static ISum3<T1, T2, T3> CreateFirst<T1, T2, T3>(T1 t1)
        {
            return new Sum3<T1, T2, T3>(1, t1);
        }

        /// <summary>
        /// Creates a new 3-dimensional sum with the third value.
        /// </summary>
        public static ISum3<T1, T2, T3> CreateSecond<T1, T2, T3>(T2 t2)
        {
            return new Sum3<T1, T2, T3>(2, t2);
        }

        /// <summary>
        /// Creates a new 3-dimensional sum with the third value.
        /// </summary>
        public static ISum3<T1, T2, T3> CreateThird<T1, T2, T3>(T3 t3)
        {
            return new Sum3<T1, T2, T3>(3, t3);
        }

        /// <summary>
        /// Creates a new 4-dimensional sum with the fourth value.
        /// </summary>
        public static ISum4<T1, T2, T3, T4> CreateFirst<T1, T2, T3, T4>(T1 t1)
        {
            return new Sum4<T1, T2, T3, T4>(1, t1);
        }

        /// <summary>
        /// Creates a new 4-dimensional sum with the fourth value.
        /// </summary>
        public static ISum4<T1, T2, T3, T4> CreateSecond<T1, T2, T3, T4>(T2 t2)
        {
            return new Sum4<T1, T2, T3, T4>(2, t2);
        }

        /// <summary>
        /// Creates a new 4-dimensional sum with the fourth value.
        /// </summary>
        public static ISum4<T1, T2, T3, T4> CreateThird<T1, T2, T3, T4>(T3 t3)
        {
            return new Sum4<T1, T2, T3, T4>(3, t3);
        }

        /// <summary>
        /// Creates a new 4-dimensional sum with the fourth value.
        /// </summary>
        public static ISum4<T1, T2, T3, T4> CreateFourth<T1, T2, T3, T4>(T4 t4)
        {
            return new Sum4<T1, T2, T3, T4>(4, t4);
        }

        /// <summary>
        /// Creates a new 5-dimensional sum with the fifth value.
        /// </summary>
        public static ISum5<T1, T2, T3, T4, T5> CreateFirst<T1, T2, T3, T4, T5>(T1 t1)
        {
            return new Sum5<T1, T2, T3, T4, T5>(1, t1);
        }

        /// <summary>
        /// Creates a new 5-dimensional sum with the fifth value.
        /// </summary>
        public static ISum5<T1, T2, T3, T4, T5> CreateSecond<T1, T2, T3, T4, T5>(T2 t2)
        {
            return new Sum5<T1, T2, T3, T4, T5>(2, t2);
        }

        /// <summary>
        /// Creates a new 5-dimensional sum with the fifth value.
        /// </summary>
        public static ISum5<T1, T2, T3, T4, T5> CreateThird<T1, T2, T3, T4, T5>(T3 t3)
        {
            return new Sum5<T1, T2, T3, T4, T5>(3, t3);
        }

        /// <summary>
        /// Creates a new 5-dimensional sum with the fifth value.
        /// </summary>
        public static ISum5<T1, T2, T3, T4, T5> CreateFourth<T1, T2, T3, T4, T5>(T4 t4)
        {
            return new Sum5<T1, T2, T3, T4, T5>(4, t4);
        }

        /// <summary>
        /// Creates a new 5-dimensional sum with the fifth value.
        /// </summary>
        public static ISum5<T1, T2, T3, T4, T5> CreateFifth<T1, T2, T3, T4, T5>(T5 t5)
        {
            return new Sum5<T1, T2, T3, T4, T5>(5, t5);
        }

        /// <summary>
        /// Creates a new 6-dimensional sum with the sixth value.
        /// </summary>
        public static ISum6<T1, T2, T3, T4, T5, T6> CreateFirst<T1, T2, T3, T4, T5, T6>(T1 t1)
        {
            return new Sum6<T1, T2, T3, T4, T5, T6>(1, t1);
        }

        /// <summary>
        /// Creates a new 6-dimensional sum with the sixth value.
        /// </summary>
        public static ISum6<T1, T2, T3, T4, T5, T6> CreateSecond<T1, T2, T3, T4, T5, T6>(T2 t2)
        {
            return new Sum6<T1, T2, T3, T4, T5, T6>(2, t2);
        }

        /// <summary>
        /// Creates a new 6-dimensional sum with the sixth value.
        /// </summary>
        public static ISum6<T1, T2, T3, T4, T5, T6> CreateThird<T1, T2, T3, T4, T5, T6>(T3 t3)
        {
            return new Sum6<T1, T2, T3, T4, T5, T6>(3, t3);
        }

        /// <summary>
        /// Creates a new 6-dimensional sum with the sixth value.
        /// </summary>
        public static ISum6<T1, T2, T3, T4, T5, T6> CreateFourth<T1, T2, T3, T4, T5, T6>(T4 t4)
        {
            return new Sum6<T1, T2, T3, T4, T5, T6>(4, t4);
        }

        /// <summary>
        /// Creates a new 6-dimensional sum with the sixth value.
        /// </summary>
        public static ISum6<T1, T2, T3, T4, T5, T6> CreateFifth<T1, T2, T3, T4, T5, T6>(T5 t5)
        {
            return new Sum6<T1, T2, T3, T4, T5, T6>(5, t5);
        }

        /// <summary>
        /// Creates a new 6-dimensional sum with the sixth value.
        /// </summary>
        public static ISum6<T1, T2, T3, T4, T5, T6> CreateSixth<T1, T2, T3, T4, T5, T6>(T6 t6)
        {
            return new Sum6<T1, T2, T3, T4, T5, T6>(6, t6);
        }

        /// <summary>
        /// Creates a new 7-dimensional sum with the seventh value.
        /// </summary>
        public static ISum7<T1, T2, T3, T4, T5, T6, T7> CreateFirst<T1, T2, T3, T4, T5, T6, T7>(T1 t1)
        {
            return new Sum7<T1, T2, T3, T4, T5, T6, T7>(1, t1);
        }

        /// <summary>
        /// Creates a new 7-dimensional sum with the seventh value.
        /// </summary>
        public static ISum7<T1, T2, T3, T4, T5, T6, T7> CreateSecond<T1, T2, T3, T4, T5, T6, T7>(T2 t2)
        {
            return new Sum7<T1, T2, T3, T4, T5, T6, T7>(2, t2);
        }

        /// <summary>
        /// Creates a new 7-dimensional sum with the seventh value.
        /// </summary>
        public static ISum7<T1, T2, T3, T4, T5, T6, T7> CreateThird<T1, T2, T3, T4, T5, T6, T7>(T3 t3)
        {
            return new Sum7<T1, T2, T3, T4, T5, T6, T7>(3, t3);
        }

        /// <summary>
        /// Creates a new 7-dimensional sum with the seventh value.
        /// </summary>
        public static ISum7<T1, T2, T3, T4, T5, T6, T7> CreateFourth<T1, T2, T3, T4, T5, T6, T7>(T4 t4)
        {
            return new Sum7<T1, T2, T3, T4, T5, T6, T7>(4, t4);
        }

        /// <summary>
        /// Creates a new 7-dimensional sum with the seventh value.
        /// </summary>
        public static ISum7<T1, T2, T3, T4, T5, T6, T7> CreateFifth<T1, T2, T3, T4, T5, T6, T7>(T5 t5)
        {
            return new Sum7<T1, T2, T3, T4, T5, T6, T7>(5, t5);
        }

        /// <summary>
        /// Creates a new 7-dimensional sum with the seventh value.
        /// </summary>
        public static ISum7<T1, T2, T3, T4, T5, T6, T7> CreateSixth<T1, T2, T3, T4, T5, T6, T7>(T6 t6)
        {
            return new Sum7<T1, T2, T3, T4, T5, T6, T7>(6, t6);
        }

        /// <summary>
        /// Creates a new 7-dimensional sum with the seventh value.
        /// </summary>
        public static ISum7<T1, T2, T3, T4, T5, T6, T7> CreateSeventh<T1, T2, T3, T4, T5, T6, T7>(T7 t7)
        {
            return new Sum7<T1, T2, T3, T4, T5, T6, T7>(7, t7);
        }

        /// <summary>
        /// Creates a new 8-dimensional sum with the eighth value.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, T8> CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1)
        {
            return new Sum8<T1, T2, T3, T4, T5, T6, T7, T8>(1, t1);
        }

        /// <summary>
        /// Creates a new 8-dimensional sum with the eighth value.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, T8> CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8>(T2 t2)
        {
            return new Sum8<T1, T2, T3, T4, T5, T6, T7, T8>(2, t2);
        }

        /// <summary>
        /// Creates a new 8-dimensional sum with the eighth value.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, T8> CreateThird<T1, T2, T3, T4, T5, T6, T7, T8>(T3 t3)
        {
            return new Sum8<T1, T2, T3, T4, T5, T6, T7, T8>(3, t3);
        }

        /// <summary>
        /// Creates a new 8-dimensional sum with the eighth value.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, T8> CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8>(T4 t4)
        {
            return new Sum8<T1, T2, T3, T4, T5, T6, T7, T8>(4, t4);
        }

        /// <summary>
        /// Creates a new 8-dimensional sum with the eighth value.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, T8> CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8>(T5 t5)
        {
            return new Sum8<T1, T2, T3, T4, T5, T6, T7, T8>(5, t5);
        }

        /// <summary>
        /// Creates a new 8-dimensional sum with the eighth value.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, T8> CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8>(T6 t6)
        {
            return new Sum8<T1, T2, T3, T4, T5, T6, T7, T8>(6, t6);
        }

        /// <summary>
        /// Creates a new 8-dimensional sum with the eighth value.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, T8> CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8>(T7 t7)
        {
            return new Sum8<T1, T2, T3, T4, T5, T6, T7, T8>(7, t7);
        }

        /// <summary>
        /// Creates a new 8-dimensional sum with the eighth value.
        /// </summary>
        public static ISum8<T1, T2, T3, T4, T5, T6, T7, T8> CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8>(T8 t8)
        {
            return new Sum8<T1, T2, T3, T4, T5, T6, T7, T8>(8, t8);
        }

        /// <summary>
        /// Creates a new 9-dimensional sum with the ninth value.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateFirst<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1)
        {
            return new Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(1, t1);
        }

        /// <summary>
        /// Creates a new 9-dimensional sum with the ninth value.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateSecond<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 t2)
        {
            return new Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(2, t2);
        }

        /// <summary>
        /// Creates a new 9-dimensional sum with the ninth value.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateThird<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 t3)
        {
            return new Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(3, t3);
        }

        /// <summary>
        /// Creates a new 9-dimensional sum with the ninth value.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateFourth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 t4)
        {
            return new Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(4, t4);
        }

        /// <summary>
        /// Creates a new 9-dimensional sum with the ninth value.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateFifth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 t5)
        {
            return new Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(5, t5);
        }

        /// <summary>
        /// Creates a new 9-dimensional sum with the ninth value.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateSixth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 t6)
        {
            return new Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(6, t6);
        }

        /// <summary>
        /// Creates a new 9-dimensional sum with the ninth value.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateSeventh<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 t7)
        {
            return new Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(7, t7);
        }

        /// <summary>
        /// Creates a new 9-dimensional sum with the ninth value.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateEighth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 t8)
        {
            return new Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(8, t8);
        }

        /// <summary>
        /// Creates a new 9-dimensional sum with the ninth value.
        /// </summary>
        public static ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateNinth<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 t9)
        {
            return new Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(9, t9);
        }

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

    /// <summary>
    /// A 0-dimensional immutable sum.
    /// </summary> 
    public class Sum0 : Sum, ISum0
    {
        /// <summary>
        /// Creates a new 0-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum0(int discriminator, object value)
            : base(0, discriminator, value)
        {
        }

    }

    /// <summary>
    /// A 1-dimensional immutable sum.
    /// </summary> 
    public class Sum1<T1> : Sum, ISum1<T1>
    {
        /// <summary>
        /// Creates a new 1-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum1(int discriminator, object value)
            : base(1, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get
            {
                return PartialMatch(
                    ifFirst: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T1>()
                );
            }
        }

        public R Match<R>(
            Func<T1, R> ifFirst)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                default: return default(R); // Never happens.
            }
        }

        public void Match(
            Action<T1> ifFirst)
        {
            Match(
                ifFirst.ToFunc()
            );
        }

        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v)
            );
        }

        public void PartialMatch(
            Action<T1> ifFirst = null,
            Action<object> otherwise = null)
        {
            PartialMatch(
                ifFirst.ToFunc(),
                otherwise.ToFunc()
            );
        }
    }

    /// <summary>
    /// A 2-dimensional immutable sum.
    /// </summary> 
    public class Sum2<T1, T2> : Sum, ISum2<T1, T2>
    {
        /// <summary>
        /// Creates a new 2-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum2(int discriminator, object value)
            : base(2, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get
            {
                return PartialMatch(
                    ifFirst: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T1>()
                );
            }
        }

        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        public IOption<T2> Second
        {
            get
            {
                return PartialMatch(
                    ifSecond: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T2>()
                );
            }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                default: return default(R); // Never happens.
            }
        }

        public void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond)
        {
            Match(
                ifFirst.ToFunc(),
                ifSecond.ToFunc()
            );
        }

        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v)
            );
        }

        public void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<object> otherwise = null)
        {
            PartialMatch(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                otherwise.ToFunc()
            );
        }
    }

    /// <summary>
    /// A 3-dimensional immutable sum.
    /// </summary> 
    public class Sum3<T1, T2, T3> : Sum, ISum3<T1, T2, T3>
    {
        /// <summary>
        /// Creates a new 3-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum3(int discriminator, object value)
            : base(3, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get
            {
                return PartialMatch(
                    ifFirst: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T1>()
                );
            }
        }

        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        public IOption<T2> Second
        {
            get
            {
                return PartialMatch(
                    ifSecond: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T2>()
                );
            }
        }

        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        public IOption<T3> Third
        {
            get
            {
                return PartialMatch(
                    ifThird: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T3>()
                );
            }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                default: return default(R); // Never happens.
            }
        }

        public void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird)
        {
            Match(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc()
            );
        }

        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v)
            );
        }

        public void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<object> otherwise = null)
        {
            PartialMatch(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                otherwise.ToFunc()
            );
        }
    }

    /// <summary>
    /// A 4-dimensional immutable sum.
    /// </summary> 
    public class Sum4<T1, T2, T3, T4> : Sum, ISum4<T1, T2, T3, T4>
    {
        /// <summary>
        /// Creates a new 4-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum4(int discriminator, object value)
            : base(4, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get
            {
                return PartialMatch(
                    ifFirst: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T1>()
                );
            }
        }

        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        public IOption<T2> Second
        {
            get
            {
                return PartialMatch(
                    ifSecond: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T2>()
                );
            }
        }

        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        public IOption<T3> Third
        {
            get
            {
                return PartialMatch(
                    ifThird: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T3>()
                );
            }
        }

        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        public IOption<T4> Fourth
        {
            get
            {
                return PartialMatch(
                    ifFourth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T4>()
                );
            }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                default: return default(R); // Never happens.
            }
        }

        public void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth)
        {
            Match(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc()
            );
        }

        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v)
            );
        }

        public void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<object> otherwise = null)
        {
            PartialMatch(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                otherwise.ToFunc()
            );
        }
    }

    /// <summary>
    /// A 5-dimensional immutable sum.
    /// </summary> 
    public class Sum5<T1, T2, T3, T4, T5> : Sum, ISum5<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Creates a new 5-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum5(int discriminator, object value)
            : base(5, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get
            {
                return PartialMatch(
                    ifFirst: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T1>()
                );
            }
        }

        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        public IOption<T2> Second
        {
            get
            {
                return PartialMatch(
                    ifSecond: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T2>()
                );
            }
        }

        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        public IOption<T3> Third
        {
            get
            {
                return PartialMatch(
                    ifThird: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T3>()
                );
            }
        }

        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        public IOption<T4> Fourth
        {
            get
            {
                return PartialMatch(
                    ifFourth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T4>()
                );
            }
        }

        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        public IOption<T5> Fifth
        {
            get
            {
                return PartialMatch(
                    ifFifth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T5>()
                );
            }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                default: return default(R); // Never happens.
            }
        }

        public void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth)
        {
            Match(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc()
            );
        }

        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v)
            );
        }

        public void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<object> otherwise = null)
        {
            PartialMatch(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc(),
                otherwise.ToFunc()
            );
        }
    }

    /// <summary>
    /// A 6-dimensional immutable sum.
    /// </summary> 
    public class Sum6<T1, T2, T3, T4, T5, T6> : Sum, ISum6<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// Creates a new 6-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum6(int discriminator, object value)
            : base(6, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get
            {
                return PartialMatch(
                    ifFirst: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T1>()
                );
            }
        }

        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        public IOption<T2> Second
        {
            get
            {
                return PartialMatch(
                    ifSecond: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T2>()
                );
            }
        }

        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        public IOption<T3> Third
        {
            get
            {
                return PartialMatch(
                    ifThird: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T3>()
                );
            }
        }

        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        public IOption<T4> Fourth
        {
            get
            {
                return PartialMatch(
                    ifFourth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T4>()
                );
            }
        }

        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        public IOption<T5> Fifth
        {
            get
            {
                return PartialMatch(
                    ifFifth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T5>()
                );
            }
        }

        public bool IsSixth
        {
            get { return SumDiscriminator == 6; }
        }

        public IOption<T6> Sixth
        {
            get
            {
                return PartialMatch(
                    ifSixth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T6>()
                );
            }
        }

        public R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth)
        {
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                case 6: return ifSixth(GetSumValue<T6>());
                default: return default(R); // Never happens.
            }
        }

        public void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth,
            Action<T6> ifSixth)
        {
            Match(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc(),
                ifSixth.ToFunc()
            );
        }

        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v),
                v => ifSixth == null ? otherwise(v) : ifSixth(v)
            );
        }

        public void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<object> otherwise = null)
        {
            PartialMatch(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc(),
                ifSixth.ToFunc(),
                otherwise.ToFunc()
            );
        }
    }

    /// <summary>
    /// A 7-dimensional immutable sum.
    /// </summary> 
    public class Sum7<T1, T2, T3, T4, T5, T6, T7> : Sum, ISum7<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        /// Creates a new 7-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum7(int discriminator, object value)
            : base(7, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get
            {
                return PartialMatch(
                    ifFirst: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T1>()
                );
            }
        }

        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        public IOption<T2> Second
        {
            get
            {
                return PartialMatch(
                    ifSecond: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T2>()
                );
            }
        }

        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        public IOption<T3> Third
        {
            get
            {
                return PartialMatch(
                    ifThird: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T3>()
                );
            }
        }

        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        public IOption<T4> Fourth
        {
            get
            {
                return PartialMatch(
                    ifFourth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T4>()
                );
            }
        }

        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        public IOption<T5> Fifth
        {
            get
            {
                return PartialMatch(
                    ifFifth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T5>()
                );
            }
        }

        public bool IsSixth
        {
            get { return SumDiscriminator == 6; }
        }

        public IOption<T6> Sixth
        {
            get
            {
                return PartialMatch(
                    ifSixth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T6>()
                );
            }
        }

        public bool IsSeventh
        {
            get { return SumDiscriminator == 7; }
        }

        public IOption<T7> Seventh
        {
            get
            {
                return PartialMatch(
                    ifSeventh: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T7>()
                );
            }
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
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                case 6: return ifSixth(GetSumValue<T6>());
                case 7: return ifSeventh(GetSumValue<T7>());
                default: return default(R); // Never happens.
            }
        }

        public void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth,
            Action<T6> ifSixth,
            Action<T7> ifSeventh)
        {
            Match(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc(),
                ifSixth.ToFunc(),
                ifSeventh.ToFunc()
            );
        }

        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<T7, R> ifSeventh = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v),
                v => ifSixth == null ? otherwise(v) : ifSixth(v),
                v => ifSeventh == null ? otherwise(v) : ifSeventh(v)
            );
        }

        public void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<object> otherwise = null)
        {
            PartialMatch(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc(),
                ifSixth.ToFunc(),
                ifSeventh.ToFunc(),
                otherwise.ToFunc()
            );
        }
    }

    /// <summary>
    /// A 8-dimensional immutable sum.
    /// </summary> 
    public class Sum8<T1, T2, T3, T4, T5, T6, T7, T8> : Sum, ISum8<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        /// Creates a new 8-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum8(int discriminator, object value)
            : base(8, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get
            {
                return PartialMatch(
                    ifFirst: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T1>()
                );
            }
        }

        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        public IOption<T2> Second
        {
            get
            {
                return PartialMatch(
                    ifSecond: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T2>()
                );
            }
        }

        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        public IOption<T3> Third
        {
            get
            {
                return PartialMatch(
                    ifThird: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T3>()
                );
            }
        }

        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        public IOption<T4> Fourth
        {
            get
            {
                return PartialMatch(
                    ifFourth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T4>()
                );
            }
        }

        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        public IOption<T5> Fifth
        {
            get
            {
                return PartialMatch(
                    ifFifth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T5>()
                );
            }
        }

        public bool IsSixth
        {
            get { return SumDiscriminator == 6; }
        }

        public IOption<T6> Sixth
        {
            get
            {
                return PartialMatch(
                    ifSixth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T6>()
                );
            }
        }

        public bool IsSeventh
        {
            get { return SumDiscriminator == 7; }
        }

        public IOption<T7> Seventh
        {
            get
            {
                return PartialMatch(
                    ifSeventh: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T7>()
                );
            }
        }

        public bool IsEighth
        {
            get { return SumDiscriminator == 8; }
        }

        public IOption<T8> Eighth
        {
            get
            {
                return PartialMatch(
                    ifEighth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T8>()
                );
            }
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
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                case 6: return ifSixth(GetSumValue<T6>());
                case 7: return ifSeventh(GetSumValue<T7>());
                case 8: return ifEighth(GetSumValue<T8>());
                default: return default(R); // Never happens.
            }
        }

        public void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth,
            Action<T6> ifSixth,
            Action<T7> ifSeventh,
            Action<T8> ifEighth)
        {
            Match(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc(),
                ifSixth.ToFunc(),
                ifSeventh.ToFunc(),
                ifEighth.ToFunc()
            );
        }

        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<T7, R> ifSeventh = null,
            Func<T8, R> ifEighth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v),
                v => ifSixth == null ? otherwise(v) : ifSixth(v),
                v => ifSeventh == null ? otherwise(v) : ifSeventh(v),
                v => ifEighth == null ? otherwise(v) : ifEighth(v)
            );
        }

        public void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<object> otherwise = null)
        {
            PartialMatch(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc(),
                ifSixth.ToFunc(),
                ifSeventh.ToFunc(),
                ifEighth.ToFunc(),
                otherwise.ToFunc()
            );
        }
    }

    /// <summary>
    /// A 9-dimensional immutable sum.
    /// </summary> 
    public class Sum9<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Sum, ISum9<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        /// <summary>
        /// Creates a new 9-dimensional sum.
        /// </summary>
        /// <param name="discriminator">Discriminator of the value from interval [1, arity].</param>
        /// <param name="value">Value of the sum on the position defined by the discriminator.</param>
        public Sum9(int discriminator, object value)
            : base(9, discriminator, value)
        {
        }

        public bool IsFirst
        {
            get { return SumDiscriminator == 1; }
        }

        public IOption<T1> First
        {
            get
            {
                return PartialMatch(
                    ifFirst: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T1>()
                );
            }
        }

        public bool IsSecond
        {
            get { return SumDiscriminator == 2; }
        }

        public IOption<T2> Second
        {
            get
            {
                return PartialMatch(
                    ifSecond: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T2>()
                );
            }
        }

        public bool IsThird
        {
            get { return SumDiscriminator == 3; }
        }

        public IOption<T3> Third
        {
            get
            {
                return PartialMatch(
                    ifThird: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T3>()
                );
            }
        }

        public bool IsFourth
        {
            get { return SumDiscriminator == 4; }
        }

        public IOption<T4> Fourth
        {
            get
            {
                return PartialMatch(
                    ifFourth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T4>()
                );
            }
        }

        public bool IsFifth
        {
            get { return SumDiscriminator == 5; }
        }

        public IOption<T5> Fifth
        {
            get
            {
                return PartialMatch(
                    ifFifth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T5>()
                );
            }
        }

        public bool IsSixth
        {
            get { return SumDiscriminator == 6; }
        }

        public IOption<T6> Sixth
        {
            get
            {
                return PartialMatch(
                    ifSixth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T6>()
                );
            }
        }

        public bool IsSeventh
        {
            get { return SumDiscriminator == 7; }
        }

        public IOption<T7> Seventh
        {
            get
            {
                return PartialMatch(
                    ifSeventh: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T7>()
                );
            }
        }

        public bool IsEighth
        {
            get { return SumDiscriminator == 8; }
        }

        public IOption<T8> Eighth
        {
            get
            {
                return PartialMatch(
                    ifEighth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T8>()
                );
            }
        }

        public bool IsNinth
        {
            get { return SumDiscriminator == 9; }
        }

        public IOption<T9> Ninth
        {
            get
            {
                return PartialMatch(
                    ifNinth: v => Option.Valued(v),
                    otherwise: _ => Option.Empty<T9>()
                );
            }
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
            switch (SumDiscriminator)
            {
                case 1: return ifFirst(GetSumValue<T1>());
                case 2: return ifSecond(GetSumValue<T2>());
                case 3: return ifThird(GetSumValue<T3>());
                case 4: return ifFourth(GetSumValue<T4>());
                case 5: return ifFifth(GetSumValue<T5>());
                case 6: return ifSixth(GetSumValue<T6>());
                case 7: return ifSeventh(GetSumValue<T7>());
                case 8: return ifEighth(GetSumValue<T8>());
                case 9: return ifNinth(GetSumValue<T9>());
                default: return default(R); // Never happens.
            }
        }

        public void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth,
            Action<T6> ifSixth,
            Action<T7> ifSeventh,
            Action<T8> ifEighth,
            Action<T9> ifNinth)
        {
            Match(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc(),
                ifSixth.ToFunc(),
                ifSeventh.ToFunc(),
                ifEighth.ToFunc(),
                ifNinth.ToFunc()
            );
        }

        public R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<T7, R> ifSeventh = null,
            Func<T8, R> ifEighth = null,
            Func<T9, R> ifNinth = null,
            Func<object, R> otherwise = null)
        {
            otherwise = otherwise ?? (_ => default(R));
            return Match(
                v => ifFirst == null ? otherwise(v) : ifFirst(v),
                v => ifSecond == null ? otherwise(v) : ifSecond(v),
                v => ifThird == null ? otherwise(v) : ifThird(v),
                v => ifFourth == null ? otherwise(v) : ifFourth(v),
                v => ifFifth == null ? otherwise(v) : ifFifth(v),
                v => ifSixth == null ? otherwise(v) : ifSixth(v),
                v => ifSeventh == null ? otherwise(v) : ifSeventh(v),
                v => ifEighth == null ? otherwise(v) : ifEighth(v),
                v => ifNinth == null ? otherwise(v) : ifNinth(v)
            );
        }

        public void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<object> otherwise = null)
        {
            PartialMatch(
                ifFirst.ToFunc(),
                ifSecond.ToFunc(),
                ifThird.ToFunc(),
                ifFourth.ToFunc(),
                ifFifth.ToFunc(),
                ifSixth.ToFunc(),
                ifSeventh.ToFunc(),
                ifEighth.ToFunc(),
                ifNinth.ToFunc(),
                otherwise.ToFunc()
            );
        }
    }

}
