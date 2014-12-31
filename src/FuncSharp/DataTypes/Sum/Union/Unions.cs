using System;

namespace FuncSharp
{
    public partial class Union
    {
        /// <summary>
        /// Creates a new 1-dimensional union with the 1-th value.
        /// </summary>
        public static Union1<T1> Create1of1<T1>(T1 t1)
        {
            return new Union1<T1>(1, t1);
        }

        /// <summary>
        /// Creates a new 2-dimensional union with the 1-th value.
        /// </summary>
        public static Union2<T1, T2> Create1of2<T1, T2>(T1 t1)
        {
            return new Union2<T1, T2>(1, t1);
        }

        /// <summary>
        /// Creates a new 2-dimensional union with the 2-th value.
        /// </summary>
        public static Union2<T1, T2> Create2of2<T1, T2>(T2 t2)
        {
            return new Union2<T1, T2>(2, t2);
        }

        /// <summary>
        /// Creates a new 3-dimensional union with the 1-th value.
        /// </summary>
        public static Union3<T1, T2, T3> Create1of3<T1, T2, T3>(T1 t1)
        {
            return new Union3<T1, T2, T3>(1, t1);
        }

        /// <summary>
        /// Creates a new 3-dimensional union with the 2-th value.
        /// </summary>
        public static Union3<T1, T2, T3> Create2of3<T1, T2, T3>(T2 t2)
        {
            return new Union3<T1, T2, T3>(2, t2);
        }

        /// <summary>
        /// Creates a new 3-dimensional union with the 3-th value.
        /// </summary>
        public static Union3<T1, T2, T3> Create3of3<T1, T2, T3>(T3 t3)
        {
            return new Union3<T1, T2, T3>(3, t3);
        }

        /// <summary>
        /// Creates a new 4-dimensional union with the 1-th value.
        /// </summary>
        public static Union4<T1, T2, T3, T4> Create1of4<T1, T2, T3, T4>(T1 t1)
        {
            return new Union4<T1, T2, T3, T4>(1, t1);
        }

        /// <summary>
        /// Creates a new 4-dimensional union with the 2-th value.
        /// </summary>
        public static Union4<T1, T2, T3, T4> Create2of4<T1, T2, T3, T4>(T2 t2)
        {
            return new Union4<T1, T2, T3, T4>(2, t2);
        }

        /// <summary>
        /// Creates a new 4-dimensional union with the 3-th value.
        /// </summary>
        public static Union4<T1, T2, T3, T4> Create3of4<T1, T2, T3, T4>(T3 t3)
        {
            return new Union4<T1, T2, T3, T4>(3, t3);
        }

        /// <summary>
        /// Creates a new 4-dimensional union with the 4-th value.
        /// </summary>
        public static Union4<T1, T2, T3, T4> Create4of4<T1, T2, T3, T4>(T4 t4)
        {
            return new Union4<T1, T2, T3, T4>(4, t4);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the 1-th value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> Create1of5<T1, T2, T3, T4, T5>(T1 t1)
        {
            return new Union5<T1, T2, T3, T4, T5>(1, t1);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the 2-th value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> Create2of5<T1, T2, T3, T4, T5>(T2 t2)
        {
            return new Union5<T1, T2, T3, T4, T5>(2, t2);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the 3-th value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> Create3of5<T1, T2, T3, T4, T5>(T3 t3)
        {
            return new Union5<T1, T2, T3, T4, T5>(3, t3);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the 4-th value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> Create4of5<T1, T2, T3, T4, T5>(T4 t4)
        {
            return new Union5<T1, T2, T3, T4, T5>(4, t4);
        }

        /// <summary>
        /// Creates a new 5-dimensional union with the 5-th value.
        /// </summary>
        public static Union5<T1, T2, T3, T4, T5> Create5of5<T1, T2, T3, T4, T5>(T5 t5)
        {
            return new Union5<T1, T2, T3, T4, T5>(5, t5);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the 1-th value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> Create1of6<T1, T2, T3, T4, T5, T6>(T1 t1)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(1, t1);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the 2-th value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> Create2of6<T1, T2, T3, T4, T5, T6>(T2 t2)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(2, t2);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the 3-th value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> Create3of6<T1, T2, T3, T4, T5, T6>(T3 t3)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(3, t3);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the 4-th value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> Create4of6<T1, T2, T3, T4, T5, T6>(T4 t4)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(4, t4);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the 5-th value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> Create5of6<T1, T2, T3, T4, T5, T6>(T5 t5)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(5, t5);
        }

        /// <summary>
        /// Creates a new 6-dimensional union with the 6-th value.
        /// </summary>
        public static Union6<T1, T2, T3, T4, T5, T6> Create6of6<T1, T2, T3, T4, T5, T6>(T6 t6)
        {
            return new Union6<T1, T2, T3, T4, T5, T6>(6, t6);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the 1-th value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> Create1of7<T1, T2, T3, T4, T5, T6, T7>(T1 t1)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(1, t1);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the 2-th value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> Create2of7<T1, T2, T3, T4, T5, T6, T7>(T2 t2)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(2, t2);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the 3-th value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> Create3of7<T1, T2, T3, T4, T5, T6, T7>(T3 t3)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(3, t3);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the 4-th value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> Create4of7<T1, T2, T3, T4, T5, T6, T7>(T4 t4)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(4, t4);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the 5-th value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> Create5of7<T1, T2, T3, T4, T5, T6, T7>(T5 t5)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(5, t5);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the 6-th value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> Create6of7<T1, T2, T3, T4, T5, T6, T7>(T6 t6)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(6, t6);
        }

        /// <summary>
        /// Creates a new 7-dimensional union with the 7-th value.
        /// </summary>
        public static Union7<T1, T2, T3, T4, T5, T6, T7> Create7of7<T1, T2, T3, T4, T5, T6, T7>(T7 t7)
        {
            return new Union7<T1, T2, T3, T4, T5, T6, T7>(7, t7);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the 1-th value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Create1of8<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(1, t1);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the 2-th value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Create2of8<T1, T2, T3, T4, T5, T6, T7, T8>(T2 t2)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(2, t2);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the 3-th value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Create3of8<T1, T2, T3, T4, T5, T6, T7, T8>(T3 t3)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(3, t3);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the 4-th value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Create4of8<T1, T2, T3, T4, T5, T6, T7, T8>(T4 t4)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(4, t4);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the 5-th value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Create5of8<T1, T2, T3, T4, T5, T6, T7, T8>(T5 t5)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(5, t5);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the 6-th value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Create6of8<T1, T2, T3, T4, T5, T6, T7, T8>(T6 t6)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(6, t6);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the 7-th value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Create7of8<T1, T2, T3, T4, T5, T6, T7, T8>(T7 t7)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(7, t7);
        }

        /// <summary>
        /// Creates a new 8-dimensional union with the 8-th value.
        /// </summary>
        public static Union8<T1, T2, T3, T4, T5, T6, T7, T8> Create8of8<T1, T2, T3, T4, T5, T6, T7, T8>(T8 t8)
        {
            return new Union8<T1, T2, T3, T4, T5, T6, T7, T8>(8, t8);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the 1-th value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create1of9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(1, t1);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the 2-th value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create2of9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 t2)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(2, t2);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the 3-th value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create3of9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 t3)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(3, t3);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the 4-th value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create4of9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 t4)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(4, t4);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the 5-th value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create5of9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 t5)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(5, t5);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the 6-th value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create6of9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 t6)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(6, t6);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the 7-th value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create7of9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 t7)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(7, t7);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the 8-th value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create8of9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 t8)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(8, t8);
        }

        /// <summary>
        /// Creates a new 9-dimensional union with the 9-th value.
        /// </summary>
        public static Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create9of9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 t9)
        {
            return new Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(9, t9);
        }

    }

    /// <summary>
    /// A 0-dimensional union.
    /// </summary> 
    public class Union0 : Union
    {
        /// <summary>
        /// Creates a new 0-dimensional union.
        /// </summary>
        internal Union0(int discriminator, object value)
            : base(0, discriminator, value)
        {
        }
    }

    /// <summary>
    /// A 1-dimensional union.
    /// </summary> 
    public class Union1<T1> : Union
    {
        /// <summary>
        /// Creates a new 1-dimensional union.
        /// </summary>
        internal Union1(int discriminator, object value)
            : base(1, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the 1-th value.
        /// </summary>
        public bool Is1
        {
            get { return SumDiscriminator == 1; }
        }

        public R Match<R>(
            Func<T1, R> if1)
        {
            switch (SumDiscriminator)
            {
                case 1: return if1(GetSumValue<T1>());
                default: return default(R); // Never happens.
            }
        }
    }

    /// <summary>
    /// A 2-dimensional union.
    /// </summary> 
    public class Union2<T1, T2> : Union
    {
        /// <summary>
        /// Creates a new 2-dimensional union.
        /// </summary>
        internal Union2(int discriminator, object value)
            : base(2, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the 1-th value.
        /// </summary>
        public bool Is1
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns whether the union contains the 2-th value.
        /// </summary>
        public bool Is2
        {
            get { return SumDiscriminator == 2; }
        }

        public R Match<R>(
            Func<T1, R> if1,
            Func<T2, R> if2)
        {
            switch (SumDiscriminator)
            {
                case 1: return if1(GetSumValue<T1>());
                case 2: return if2(GetSumValue<T2>());
                default: return default(R); // Never happens.
            }
        }
    }

    /// <summary>
    /// A 3-dimensional union.
    /// </summary> 
    public class Union3<T1, T2, T3> : Union
    {
        /// <summary>
        /// Creates a new 3-dimensional union.
        /// </summary>
        internal Union3(int discriminator, object value)
            : base(3, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the 1-th value.
        /// </summary>
        public bool Is1
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns whether the union contains the 2-th value.
        /// </summary>
        public bool Is2
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns whether the union contains the 3-th value.
        /// </summary>
        public bool Is3
        {
            get { return SumDiscriminator == 3; }
        }

        public R Match<R>(
            Func<T1, R> if1,
            Func<T2, R> if2,
            Func<T3, R> if3)
        {
            switch (SumDiscriminator)
            {
                case 1: return if1(GetSumValue<T1>());
                case 2: return if2(GetSumValue<T2>());
                case 3: return if3(GetSumValue<T3>());
                default: return default(R); // Never happens.
            }
        }
    }

    /// <summary>
    /// A 4-dimensional union.
    /// </summary> 
    public class Union4<T1, T2, T3, T4> : Union
    {
        /// <summary>
        /// Creates a new 4-dimensional union.
        /// </summary>
        internal Union4(int discriminator, object value)
            : base(4, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the 1-th value.
        /// </summary>
        public bool Is1
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns whether the union contains the 2-th value.
        /// </summary>
        public bool Is2
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns whether the union contains the 3-th value.
        /// </summary>
        public bool Is3
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns whether the union contains the 4-th value.
        /// </summary>
        public bool Is4
        {
            get { return SumDiscriminator == 4; }
        }

        public R Match<R>(
            Func<T1, R> if1,
            Func<T2, R> if2,
            Func<T3, R> if3,
            Func<T4, R> if4)
        {
            switch (SumDiscriminator)
            {
                case 1: return if1(GetSumValue<T1>());
                case 2: return if2(GetSumValue<T2>());
                case 3: return if3(GetSumValue<T3>());
                case 4: return if4(GetSumValue<T4>());
                default: return default(R); // Never happens.
            }
        }
    }

    /// <summary>
    /// A 5-dimensional union.
    /// </summary> 
    public class Union5<T1, T2, T3, T4, T5> : Union
    {
        /// <summary>
        /// Creates a new 5-dimensional union.
        /// </summary>
        internal Union5(int discriminator, object value)
            : base(5, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the 1-th value.
        /// </summary>
        public bool Is1
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns whether the union contains the 2-th value.
        /// </summary>
        public bool Is2
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns whether the union contains the 3-th value.
        /// </summary>
        public bool Is3
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns whether the union contains the 4-th value.
        /// </summary>
        public bool Is4
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns whether the union contains the 5-th value.
        /// </summary>
        public bool Is5
        {
            get { return SumDiscriminator == 5; }
        }

        public R Match<R>(
            Func<T1, R> if1,
            Func<T2, R> if2,
            Func<T3, R> if3,
            Func<T4, R> if4,
            Func<T5, R> if5)
        {
            switch (SumDiscriminator)
            {
                case 1: return if1(GetSumValue<T1>());
                case 2: return if2(GetSumValue<T2>());
                case 3: return if3(GetSumValue<T3>());
                case 4: return if4(GetSumValue<T4>());
                case 5: return if5(GetSumValue<T5>());
                default: return default(R); // Never happens.
            }
        }
    }

    /// <summary>
    /// A 6-dimensional union.
    /// </summary> 
    public class Union6<T1, T2, T3, T4, T5, T6> : Union
    {
        /// <summary>
        /// Creates a new 6-dimensional union.
        /// </summary>
        internal Union6(int discriminator, object value)
            : base(6, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the 1-th value.
        /// </summary>
        public bool Is1
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns whether the union contains the 2-th value.
        /// </summary>
        public bool Is2
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns whether the union contains the 3-th value.
        /// </summary>
        public bool Is3
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns whether the union contains the 4-th value.
        /// </summary>
        public bool Is4
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns whether the union contains the 5-th value.
        /// </summary>
        public bool Is5
        {
            get { return SumDiscriminator == 5; }
        }

        /// <summary>
        /// Returns whether the union contains the 6-th value.
        /// </summary>
        public bool Is6
        {
            get { return SumDiscriminator == 6; }
        }

        public R Match<R>(
            Func<T1, R> if1,
            Func<T2, R> if2,
            Func<T3, R> if3,
            Func<T4, R> if4,
            Func<T5, R> if5,
            Func<T6, R> if6)
        {
            switch (SumDiscriminator)
            {
                case 1: return if1(GetSumValue<T1>());
                case 2: return if2(GetSumValue<T2>());
                case 3: return if3(GetSumValue<T3>());
                case 4: return if4(GetSumValue<T4>());
                case 5: return if5(GetSumValue<T5>());
                case 6: return if6(GetSumValue<T6>());
                default: return default(R); // Never happens.
            }
        }
    }

    /// <summary>
    /// A 7-dimensional union.
    /// </summary> 
    public class Union7<T1, T2, T3, T4, T5, T6, T7> : Union
    {
        /// <summary>
        /// Creates a new 7-dimensional union.
        /// </summary>
        internal Union7(int discriminator, object value)
            : base(7, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the 1-th value.
        /// </summary>
        public bool Is1
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns whether the union contains the 2-th value.
        /// </summary>
        public bool Is2
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns whether the union contains the 3-th value.
        /// </summary>
        public bool Is3
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns whether the union contains the 4-th value.
        /// </summary>
        public bool Is4
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns whether the union contains the 5-th value.
        /// </summary>
        public bool Is5
        {
            get { return SumDiscriminator == 5; }
        }

        /// <summary>
        /// Returns whether the union contains the 6-th value.
        /// </summary>
        public bool Is6
        {
            get { return SumDiscriminator == 6; }
        }

        /// <summary>
        /// Returns whether the union contains the 7-th value.
        /// </summary>
        public bool Is7
        {
            get { return SumDiscriminator == 7; }
        }

        public R Match<R>(
            Func<T1, R> if1,
            Func<T2, R> if2,
            Func<T3, R> if3,
            Func<T4, R> if4,
            Func<T5, R> if5,
            Func<T6, R> if6,
            Func<T7, R> if7)
        {
            switch (SumDiscriminator)
            {
                case 1: return if1(GetSumValue<T1>());
                case 2: return if2(GetSumValue<T2>());
                case 3: return if3(GetSumValue<T3>());
                case 4: return if4(GetSumValue<T4>());
                case 5: return if5(GetSumValue<T5>());
                case 6: return if6(GetSumValue<T6>());
                case 7: return if7(GetSumValue<T7>());
                default: return default(R); // Never happens.
            }
        }
    }

    /// <summary>
    /// A 8-dimensional union.
    /// </summary> 
    public class Union8<T1, T2, T3, T4, T5, T6, T7, T8> : Union
    {
        /// <summary>
        /// Creates a new 8-dimensional union.
        /// </summary>
        internal Union8(int discriminator, object value)
            : base(8, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the 1-th value.
        /// </summary>
        public bool Is1
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns whether the union contains the 2-th value.
        /// </summary>
        public bool Is2
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns whether the union contains the 3-th value.
        /// </summary>
        public bool Is3
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns whether the union contains the 4-th value.
        /// </summary>
        public bool Is4
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns whether the union contains the 5-th value.
        /// </summary>
        public bool Is5
        {
            get { return SumDiscriminator == 5; }
        }

        /// <summary>
        /// Returns whether the union contains the 6-th value.
        /// </summary>
        public bool Is6
        {
            get { return SumDiscriminator == 6; }
        }

        /// <summary>
        /// Returns whether the union contains the 7-th value.
        /// </summary>
        public bool Is7
        {
            get { return SumDiscriminator == 7; }
        }

        /// <summary>
        /// Returns whether the union contains the 8-th value.
        /// </summary>
        public bool Is8
        {
            get { return SumDiscriminator == 8; }
        }

        public R Match<R>(
            Func<T1, R> if1,
            Func<T2, R> if2,
            Func<T3, R> if3,
            Func<T4, R> if4,
            Func<T5, R> if5,
            Func<T6, R> if6,
            Func<T7, R> if7,
            Func<T8, R> if8)
        {
            switch (SumDiscriminator)
            {
                case 1: return if1(GetSumValue<T1>());
                case 2: return if2(GetSumValue<T2>());
                case 3: return if3(GetSumValue<T3>());
                case 4: return if4(GetSumValue<T4>());
                case 5: return if5(GetSumValue<T5>());
                case 6: return if6(GetSumValue<T6>());
                case 7: return if7(GetSumValue<T7>());
                case 8: return if8(GetSumValue<T8>());
                default: return default(R); // Never happens.
            }
        }
    }

    /// <summary>
    /// A 9-dimensional union.
    /// </summary> 
    public class Union9<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Union
    {
        /// <summary>
        /// Creates a new 9-dimensional union.
        /// </summary>
        internal Union9(int discriminator, object value)
            : base(9, discriminator, value)
        {
        }

        /// <summary>
        /// Returns whether the union contains the 1-th value.
        /// </summary>
        public bool Is1
        {
            get { return SumDiscriminator == 1; }
        }

        /// <summary>
        /// Returns whether the union contains the 2-th value.
        /// </summary>
        public bool Is2
        {
            get { return SumDiscriminator == 2; }
        }

        /// <summary>
        /// Returns whether the union contains the 3-th value.
        /// </summary>
        public bool Is3
        {
            get { return SumDiscriminator == 3; }
        }

        /// <summary>
        /// Returns whether the union contains the 4-th value.
        /// </summary>
        public bool Is4
        {
            get { return SumDiscriminator == 4; }
        }

        /// <summary>
        /// Returns whether the union contains the 5-th value.
        /// </summary>
        public bool Is5
        {
            get { return SumDiscriminator == 5; }
        }

        /// <summary>
        /// Returns whether the union contains the 6-th value.
        /// </summary>
        public bool Is6
        {
            get { return SumDiscriminator == 6; }
        }

        /// <summary>
        /// Returns whether the union contains the 7-th value.
        /// </summary>
        public bool Is7
        {
            get { return SumDiscriminator == 7; }
        }

        /// <summary>
        /// Returns whether the union contains the 8-th value.
        /// </summary>
        public bool Is8
        {
            get { return SumDiscriminator == 8; }
        }

        /// <summary>
        /// Returns whether the union contains the 9-th value.
        /// </summary>
        public bool Is9
        {
            get { return SumDiscriminator == 9; }
        }

        public R Match<R>(
            Func<T1, R> if1,
            Func<T2, R> if2,
            Func<T3, R> if3,
            Func<T4, R> if4,
            Func<T5, R> if5,
            Func<T6, R> if6,
            Func<T7, R> if7,
            Func<T8, R> if8,
            Func<T9, R> if9)
        {
            switch (SumDiscriminator)
            {
                case 1: return if1(GetSumValue<T1>());
                case 2: return if2(GetSumValue<T2>());
                case 3: return if3(GetSumValue<T3>());
                case 4: return if4(GetSumValue<T4>());
                case 5: return if5(GetSumValue<T5>());
                case 6: return if6(GetSumValue<T6>());
                case 7: return if7(GetSumValue<T7>());
                case 8: return if8(GetSumValue<T8>());
                case 9: return if9(GetSumValue<T9>());
                default: return default(R); // Never happens.
            }
        }
    }

}
