namespace FuncSharp
{
    /// <summary>
    /// A 0-dimensional data cube position.
    /// </summary>
    public sealed class Position0 : Product0
    {
        public Position0()
            : base()
        {
        }


        /// <summary>
        /// Creates a new 0-dimensional data cube position.
        /// </summary>
        public static new Position0 Create()
        {
            return new Position0();
        }
    }

    /// <summary>
    /// A factory for 1-dimensional data cube positions.
    /// </summary>
    public static class Position1
    {
        /// <summary>
        /// Creates a new 1-dimensional data cube position.
        /// </summary>
        public static Position1<P1> Create<P1>(P1 p1)
        {
            return new Position1<P1>(p1);
        }

        /// <summary>
        /// Creates a new 1-dimensional canonical product.
        /// </summary>
        public static Position1<P1> Create<P1>(IProduct1<P1> p)
        {
            return Create(p.ProductValue1);
        }
    }

    /// <summary>
    /// A 1-dimensional data cube position.
    /// </summary>
    public sealed class Position1<P1> : Product1<P1>
    {
        public Position1(P1 p1)
            : base(p1)
        {
        }


        public Position0 ExceptValue1
        {
            get { return Position0.Create(); }
        }
    }

    /// <summary>
    /// A factory for 2-dimensional data cube positions.
    /// </summary>
    public static class Position2
    {
        /// <summary>
        /// Creates a new 2-dimensional data cube position.
        /// </summary>
        public static Position2<P1, P2> Create<P1, P2>(P1 p1, P2 p2)
        {
            return new Position2<P1, P2>(p1, p2);
        }

        /// <summary>
        /// Creates a new 2-dimensional canonical product.
        /// </summary>
        public static Position2<P1, P2> Create<P1, P2>(IProduct2<P1, P2> p)
        {
            return Create(p.ProductValue1, p.ProductValue2);
        }
    }

    /// <summary>
    /// A 2-dimensional data cube position.
    /// </summary>
    public sealed class Position2<P1, P2> : Product2<P1, P2>
    {
        public Position2(P1 p1, P2 p2)
            : base(p1, p2)
        {
        }


        public Position1<P2> ExceptValue1
        {
            get { return Position1.Create(ProductValue2); }
        }

        public Position1<P1> ExceptValue2
        {
            get { return Position1.Create(ProductValue1); }
        }
    }

    /// <summary>
    /// A factory for 3-dimensional data cube positions.
    /// </summary>
    public static class Position3
    {
        /// <summary>
        /// Creates a new 3-dimensional data cube position.
        /// </summary>
        public static Position3<P1, P2, P3> Create<P1, P2, P3>(P1 p1, P2 p2, P3 p3)
        {
            return new Position3<P1, P2, P3>(p1, p2, p3);
        }

        /// <summary>
        /// Creates a new 3-dimensional canonical product.
        /// </summary>
        public static Position3<P1, P2, P3> Create<P1, P2, P3>(IProduct3<P1, P2, P3> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3);
        }
    }

    /// <summary>
    /// A 3-dimensional data cube position.
    /// </summary>
    public sealed class Position3<P1, P2, P3> : Product3<P1, P2, P3>
    {
        public Position3(P1 p1, P2 p2, P3 p3)
            : base(p1, p2, p3)
        {
        }


        public Position2<P2, P3> ExceptValue1
        {
            get { return Position2.Create(ProductValue2, ProductValue3); }
        }

        public Position2<P1, P3> ExceptValue2
        {
            get { return Position2.Create(ProductValue1, ProductValue3); }
        }

        public Position2<P1, P2> ExceptValue3
        {
            get { return Position2.Create(ProductValue1, ProductValue2); }
        }
    }

    /// <summary>
    /// A factory for 4-dimensional data cube positions.
    /// </summary>
    public static class Position4
    {
        /// <summary>
        /// Creates a new 4-dimensional data cube position.
        /// </summary>
        public static Position4<P1, P2, P3, P4> Create<P1, P2, P3, P4>(P1 p1, P2 p2, P3 p3, P4 p4)
        {
            return new Position4<P1, P2, P3, P4>(p1, p2, p3, p4);
        }

        /// <summary>
        /// Creates a new 4-dimensional canonical product.
        /// </summary>
        public static Position4<P1, P2, P3, P4> Create<P1, P2, P3, P4>(IProduct4<P1, P2, P3, P4> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4);
        }
    }

    /// <summary>
    /// A 4-dimensional data cube position.
    /// </summary>
    public sealed class Position4<P1, P2, P3, P4> : Product4<P1, P2, P3, P4>
    {
        public Position4(P1 p1, P2 p2, P3 p3, P4 p4)
            : base(p1, p2, p3, p4)
        {
        }


        public Position3<P2, P3, P4> ExceptValue1
        {
            get { return Position3.Create(ProductValue2, ProductValue3, ProductValue4); }
        }

        public Position3<P1, P3, P4> ExceptValue2
        {
            get { return Position3.Create(ProductValue1, ProductValue3, ProductValue4); }
        }

        public Position3<P1, P2, P4> ExceptValue3
        {
            get { return Position3.Create(ProductValue1, ProductValue2, ProductValue4); }
        }

        public Position3<P1, P2, P3> ExceptValue4
        {
            get { return Position3.Create(ProductValue1, ProductValue2, ProductValue3); }
        }
    }

    /// <summary>
    /// A factory for 5-dimensional data cube positions.
    /// </summary>
    public static class Position5
    {
        /// <summary>
        /// Creates a new 5-dimensional data cube position.
        /// </summary>
        public static Position5<P1, P2, P3, P4, P5> Create<P1, P2, P3, P4, P5>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            return new Position5<P1, P2, P3, P4, P5>(p1, p2, p3, p4, p5);
        }

        /// <summary>
        /// Creates a new 5-dimensional canonical product.
        /// </summary>
        public static Position5<P1, P2, P3, P4, P5> Create<P1, P2, P3, P4, P5>(IProduct5<P1, P2, P3, P4, P5> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5);
        }
    }

    /// <summary>
    /// A 5-dimensional data cube position.
    /// </summary>
    public sealed class Position5<P1, P2, P3, P4, P5> : Product5<P1, P2, P3, P4, P5>
    {
        public Position5(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
            : base(p1, p2, p3, p4, p5)
        {
        }


        public Position4<P2, P3, P4, P5> ExceptValue1
        {
            get { return Position4.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5); }
        }

        public Position4<P1, P3, P4, P5> ExceptValue2
        {
            get { return Position4.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5); }
        }

        public Position4<P1, P2, P4, P5> ExceptValue3
        {
            get { return Position4.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5); }
        }

        public Position4<P1, P2, P3, P5> ExceptValue4
        {
            get { return Position4.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5); }
        }

        public Position4<P1, P2, P3, P4> ExceptValue5
        {
            get { return Position4.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4); }
        }
    }

    /// <summary>
    /// A factory for 6-dimensional data cube positions.
    /// </summary>
    public static class Position6
    {
        /// <summary>
        /// Creates a new 6-dimensional data cube position.
        /// </summary>
        public static Position6<P1, P2, P3, P4, P5, P6> Create<P1, P2, P3, P4, P5, P6>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            return new Position6<P1, P2, P3, P4, P5, P6>(p1, p2, p3, p4, p5, p6);
        }

        /// <summary>
        /// Creates a new 6-dimensional canonical product.
        /// </summary>
        public static Position6<P1, P2, P3, P4, P5, P6> Create<P1, P2, P3, P4, P5, P6>(IProduct6<P1, P2, P3, P4, P5, P6> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6);
        }
    }

    /// <summary>
    /// A 6-dimensional data cube position.
    /// </summary>
    public sealed class Position6<P1, P2, P3, P4, P5, P6> : Product6<P1, P2, P3, P4, P5, P6>
    {
        public Position6(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
            : base(p1, p2, p3, p4, p5, p6)
        {
        }


        public Position5<P2, P3, P4, P5, P6> ExceptValue1
        {
            get { return Position5.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6); }
        }

        public Position5<P1, P3, P4, P5, P6> ExceptValue2
        {
            get { return Position5.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6); }
        }

        public Position5<P1, P2, P4, P5, P6> ExceptValue3
        {
            get { return Position5.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6); }
        }

        public Position5<P1, P2, P3, P5, P6> ExceptValue4
        {
            get { return Position5.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6); }
        }

        public Position5<P1, P2, P3, P4, P6> ExceptValue5
        {
            get { return Position5.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6); }
        }

        public Position5<P1, P2, P3, P4, P5> ExceptValue6
        {
            get { return Position5.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5); }
        }
    }

    /// <summary>
    /// A factory for 7-dimensional data cube positions.
    /// </summary>
    public static class Position7
    {
        /// <summary>
        /// Creates a new 7-dimensional data cube position.
        /// </summary>
        public static Position7<P1, P2, P3, P4, P5, P6, P7> Create<P1, P2, P3, P4, P5, P6, P7>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
        {
            return new Position7<P1, P2, P3, P4, P5, P6, P7>(p1, p2, p3, p4, p5, p6, p7);
        }

        /// <summary>
        /// Creates a new 7-dimensional canonical product.
        /// </summary>
        public static Position7<P1, P2, P3, P4, P5, P6, P7> Create<P1, P2, P3, P4, P5, P6, P7>(IProduct7<P1, P2, P3, P4, P5, P6, P7> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7);
        }
    }

    /// <summary>
    /// A 7-dimensional data cube position.
    /// </summary>
    public sealed class Position7<P1, P2, P3, P4, P5, P6, P7> : Product7<P1, P2, P3, P4, P5, P6, P7>
    {
        public Position7(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7)
            : base(p1, p2, p3, p4, p5, p6, p7)
        {
        }


        public Position6<P2, P3, P4, P5, P6, P7> ExceptValue1
        {
            get { return Position6.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7); }
        }

        public Position6<P1, P3, P4, P5, P6, P7> ExceptValue2
        {
            get { return Position6.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7); }
        }

        public Position6<P1, P2, P4, P5, P6, P7> ExceptValue3
        {
            get { return Position6.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7); }
        }

        public Position6<P1, P2, P3, P5, P6, P7> ExceptValue4
        {
            get { return Position6.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7); }
        }

        public Position6<P1, P2, P3, P4, P6, P7> ExceptValue5
        {
            get { return Position6.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7); }
        }

        public Position6<P1, P2, P3, P4, P5, P7> ExceptValue6
        {
            get { return Position6.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7); }
        }

        public Position6<P1, P2, P3, P4, P5, P6> ExceptValue7
        {
            get { return Position6.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6); }
        }
    }

    /// <summary>
    /// A factory for 8-dimensional data cube positions.
    /// </summary>
    public static class Position8
    {
        /// <summary>
        /// Creates a new 8-dimensional data cube position.
        /// </summary>
        public static Position8<P1, P2, P3, P4, P5, P6, P7, P8> Create<P1, P2, P3, P4, P5, P6, P7, P8>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
        {
            return new Position8<P1, P2, P3, P4, P5, P6, P7, P8>(p1, p2, p3, p4, p5, p6, p7, p8);
        }

        /// <summary>
        /// Creates a new 8-dimensional canonical product.
        /// </summary>
        public static Position8<P1, P2, P3, P4, P5, P6, P7, P8> Create<P1, P2, P3, P4, P5, P6, P7, P8>(IProduct8<P1, P2, P3, P4, P5, P6, P7, P8> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8);
        }
    }

    /// <summary>
    /// A 8-dimensional data cube position.
    /// </summary>
    public sealed class Position8<P1, P2, P3, P4, P5, P6, P7, P8> : Product8<P1, P2, P3, P4, P5, P6, P7, P8>
    {
        public Position8(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8)
            : base(p1, p2, p3, p4, p5, p6, p7, p8)
        {
        }


        public Position7<P2, P3, P4, P5, P6, P7, P8> ExceptValue1
        {
            get { return Position7.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }

        public Position7<P1, P3, P4, P5, P6, P7, P8> ExceptValue2
        {
            get { return Position7.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }

        public Position7<P1, P2, P4, P5, P6, P7, P8> ExceptValue3
        {
            get { return Position7.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }

        public Position7<P1, P2, P3, P5, P6, P7, P8> ExceptValue4
        {
            get { return Position7.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }

        public Position7<P1, P2, P3, P4, P6, P7, P8> ExceptValue5
        {
            get { return Position7.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8); }
        }

        public Position7<P1, P2, P3, P4, P5, P7, P8> ExceptValue6
        {
            get { return Position7.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8); }
        }

        public Position7<P1, P2, P3, P4, P5, P6, P8> ExceptValue7
        {
            get { return Position7.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8); }
        }

        public Position7<P1, P2, P3, P4, P5, P6, P7> ExceptValue8
        {
            get { return Position7.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7); }
        }
    }

    /// <summary>
    /// A factory for 9-dimensional data cube positions.
    /// </summary>
    public static class Position9
    {
        /// <summary>
        /// Creates a new 9-dimensional data cube position.
        /// </summary>
        public static Position9<P1, P2, P3, P4, P5, P6, P7, P8, P9> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
        {
            return new Position9<P1, P2, P3, P4, P5, P6, P7, P8, P9>(p1, p2, p3, p4, p5, p6, p7, p8, p9);
        }

        /// <summary>
        /// Creates a new 9-dimensional canonical product.
        /// </summary>
        public static Position9<P1, P2, P3, P4, P5, P6, P7, P8, P9> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9>(IProduct9<P1, P2, P3, P4, P5, P6, P7, P8, P9> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9);
        }
    }

    /// <summary>
    /// A 9-dimensional data cube position.
    /// </summary>
    public sealed class Position9<P1, P2, P3, P4, P5, P6, P7, P8, P9> : Product9<P1, P2, P3, P4, P5, P6, P7, P8, P9>
    {
        public Position9(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9)
        {
        }


        public Position8<P2, P3, P4, P5, P6, P7, P8, P9> ExceptValue1
        {
            get { return Position8.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        public Position8<P1, P3, P4, P5, P6, P7, P8, P9> ExceptValue2
        {
            get { return Position8.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        public Position8<P1, P2, P4, P5, P6, P7, P8, P9> ExceptValue3
        {
            get { return Position8.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        public Position8<P1, P2, P3, P5, P6, P7, P8, P9> ExceptValue4
        {
            get { return Position8.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        public Position8<P1, P2, P3, P4, P6, P7, P8, P9> ExceptValue5
        {
            get { return Position8.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        public Position8<P1, P2, P3, P4, P5, P7, P8, P9> ExceptValue6
        {
            get { return Position8.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9); }
        }

        public Position8<P1, P2, P3, P4, P5, P6, P8, P9> ExceptValue7
        {
            get { return Position8.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9); }
        }

        public Position8<P1, P2, P3, P4, P5, P6, P7, P9> ExceptValue8
        {
            get { return Position8.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9); }
        }

        public Position8<P1, P2, P3, P4, P5, P6, P7, P8> ExceptValue9
        {
            get { return Position8.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }
    }

    /// <summary>
    /// A factory for 10-dimensional data cube positions.
    /// </summary>
    public static class Position10
    {
        /// <summary>
        /// Creates a new 10-dimensional data cube position.
        /// </summary>
        public static Position10<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
        {
            return new Position10<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
        }

        /// <summary>
        /// Creates a new 10-dimensional canonical product.
        /// </summary>
        public static Position10<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(IProduct10<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10);
        }
    }

    /// <summary>
    /// A 10-dimensional data cube position.
    /// </summary>
    public sealed class Position10<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10> : Product10<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>
    {
        public Position10(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10)
        {
        }


        public Position9<P2, P3, P4, P5, P6, P7, P8, P9, P10> ExceptValue1
        {
            get { return Position9.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10); }
        }

        public Position9<P1, P3, P4, P5, P6, P7, P8, P9, P10> ExceptValue2
        {
            get { return Position9.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10); }
        }

        public Position9<P1, P2, P4, P5, P6, P7, P8, P9, P10> ExceptValue3
        {
            get { return Position9.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10); }
        }

        public Position9<P1, P2, P3, P5, P6, P7, P8, P9, P10> ExceptValue4
        {
            get { return Position9.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10); }
        }

        public Position9<P1, P2, P3, P4, P6, P7, P8, P9, P10> ExceptValue5
        {
            get { return Position9.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10); }
        }

        public Position9<P1, P2, P3, P4, P5, P7, P8, P9, P10> ExceptValue6
        {
            get { return Position9.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10); }
        }

        public Position9<P1, P2, P3, P4, P5, P6, P8, P9, P10> ExceptValue7
        {
            get { return Position9.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10); }
        }

        public Position9<P1, P2, P3, P4, P5, P6, P7, P9, P10> ExceptValue8
        {
            get { return Position9.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10); }
        }

        public Position9<P1, P2, P3, P4, P5, P6, P7, P8, P10> ExceptValue9
        {
            get { return Position9.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10); }
        }

        public Position9<P1, P2, P3, P4, P5, P6, P7, P8, P9> ExceptValue10
        {
            get { return Position9.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }
    }

    /// <summary>
    /// A factory for 11-dimensional data cube positions.
    /// </summary>
    public static class Position11
    {
        /// <summary>
        /// Creates a new 11-dimensional data cube position.
        /// </summary>
        public static Position11<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
        {
            return new Position11<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
        }

        /// <summary>
        /// Creates a new 11-dimensional canonical product.
        /// </summary>
        public static Position11<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(IProduct11<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11);
        }
    }

    /// <summary>
    /// A 11-dimensional data cube position.
    /// </summary>
    public sealed class Position11<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> : Product11<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>
    {
        public Position11(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11)
        {
        }


        public Position10<P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> ExceptValue1
        {
            get { return Position10.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11); }
        }

        public Position10<P1, P3, P4, P5, P6, P7, P8, P9, P10, P11> ExceptValue2
        {
            get { return Position10.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11); }
        }

        public Position10<P1, P2, P4, P5, P6, P7, P8, P9, P10, P11> ExceptValue3
        {
            get { return Position10.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11); }
        }

        public Position10<P1, P2, P3, P5, P6, P7, P8, P9, P10, P11> ExceptValue4
        {
            get { return Position10.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11); }
        }

        public Position10<P1, P2, P3, P4, P6, P7, P8, P9, P10, P11> ExceptValue5
        {
            get { return Position10.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11); }
        }

        public Position10<P1, P2, P3, P4, P5, P7, P8, P9, P10, P11> ExceptValue6
        {
            get { return Position10.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11); }
        }

        public Position10<P1, P2, P3, P4, P5, P6, P8, P9, P10, P11> ExceptValue7
        {
            get { return Position10.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10, ProductValue11); }
        }

        public Position10<P1, P2, P3, P4, P5, P6, P7, P9, P10, P11> ExceptValue8
        {
            get { return Position10.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10, ProductValue11); }
        }

        public Position10<P1, P2, P3, P4, P5, P6, P7, P8, P10, P11> ExceptValue9
        {
            get { return Position10.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10, ProductValue11); }
        }

        public Position10<P1, P2, P3, P4, P5, P6, P7, P8, P9, P11> ExceptValue10
        {
            get { return Position10.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue11); }
        }

        public Position10<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10> ExceptValue11
        {
            get { return Position10.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10); }
        }
    }

    /// <summary>
    /// A factory for 12-dimensional data cube positions.
    /// </summary>
    public static class Position12
    {
        /// <summary>
        /// Creates a new 12-dimensional data cube position.
        /// </summary>
        public static Position12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12)
        {
            return new Position12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
        }

        /// <summary>
        /// Creates a new 12-dimensional canonical product.
        /// </summary>
        public static Position12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>(IProduct12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12);
        }
    }

    /// <summary>
    /// A 12-dimensional data cube position.
    /// </summary>
    public sealed class Position12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> : Product12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>
    {
        public Position12(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12)
        {
        }


        public Position11<P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> ExceptValue1
        {
            get { return Position11.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> ExceptValue2
        {
            get { return Position11.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P2, P4, P5, P6, P7, P8, P9, P10, P11, P12> ExceptValue3
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P2, P3, P5, P6, P7, P8, P9, P10, P11, P12> ExceptValue4
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P2, P3, P4, P6, P7, P8, P9, P10, P11, P12> ExceptValue5
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P2, P3, P4, P5, P7, P8, P9, P10, P11, P12> ExceptValue6
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P2, P3, P4, P5, P6, P8, P9, P10, P11, P12> ExceptValue7
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P2, P3, P4, P5, P6, P7, P9, P10, P11, P12> ExceptValue8
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P2, P3, P4, P5, P6, P7, P8, P10, P11, P12> ExceptValue9
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P2, P3, P4, P5, P6, P7, P8, P9, P11, P12> ExceptValue10
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue11, ProductValue12); }
        }

        public Position11<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P12> ExceptValue11
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue12); }
        }

        public Position11<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> ExceptValue12
        {
            get { return Position11.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11); }
        }
    }

    /// <summary>
    /// A factory for 13-dimensional data cube positions.
    /// </summary>
    public static class Position13
    {
        /// <summary>
        /// Creates a new 13-dimensional data cube position.
        /// </summary>
        public static Position13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13)
        {
            return new Position13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
        }

        /// <summary>
        /// Creates a new 13-dimensional canonical product.
        /// </summary>
        public static Position13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>(IProduct13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13);
        }
    }

    /// <summary>
    /// A 13-dimensional data cube position.
    /// </summary>
    public sealed class Position13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> : Product13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>
    {
        public Position13(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13)
        {
        }


        public Position12<P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> ExceptValue1
        {
            get { return Position12.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> ExceptValue2
        {
            get { return Position12.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> ExceptValue3
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P3, P5, P6, P7, P8, P9, P10, P11, P12, P13> ExceptValue4
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P3, P4, P6, P7, P8, P9, P10, P11, P12, P13> ExceptValue5
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P3, P4, P5, P7, P8, P9, P10, P11, P12, P13> ExceptValue6
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P3, P4, P5, P6, P8, P9, P10, P11, P12, P13> ExceptValue7
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P3, P4, P5, P6, P7, P9, P10, P11, P12, P13> ExceptValue8
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P3, P4, P5, P6, P7, P8, P10, P11, P12, P13> ExceptValue9
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P11, P12, P13> ExceptValue10
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue11, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P12, P13> ExceptValue11
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue12, ProductValue13); }
        }

        public Position12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P13> ExceptValue12
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue13); }
        }

        public Position12<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> ExceptValue13
        {
            get { return Position12.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12); }
        }
    }

    /// <summary>
    /// A factory for 14-dimensional data cube positions.
    /// </summary>
    public static class Position14
    {
        /// <summary>
        /// Creates a new 14-dimensional data cube position.
        /// </summary>
        public static Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14)
        {
            return new Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);
        }

        /// <summary>
        /// Creates a new 14-dimensional canonical product.
        /// </summary>
        public static Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14>(IProduct14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14);
        }
    }

    /// <summary>
    /// A 14-dimensional data cube position.
    /// </summary>
    public sealed class Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14> : Product14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14>
    {
        public Position14(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14)
        {
        }


        public Position13<P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14> ExceptValue1
        {
            get { return Position13.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14> ExceptValue2
        {
            get { return Position13.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14> ExceptValue3
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14> ExceptValue4
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P6, P7, P8, P9, P10, P11, P12, P13, P14> ExceptValue5
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P5, P7, P8, P9, P10, P11, P12, P13, P14> ExceptValue6
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P5, P6, P8, P9, P10, P11, P12, P13, P14> ExceptValue7
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P5, P6, P7, P9, P10, P11, P12, P13, P14> ExceptValue8
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P5, P6, P7, P8, P10, P11, P12, P13, P14> ExceptValue9
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P11, P12, P13, P14> ExceptValue10
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P12, P13, P14> ExceptValue11
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue12, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P13, P14> ExceptValue12
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue13, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P14> ExceptValue13
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue14); }
        }

        public Position13<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> ExceptValue14
        {
            get { return Position13.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13); }
        }
    }

    /// <summary>
    /// A factory for 15-dimensional data cube positions.
    /// </summary>
    public static class Position15
    {
        /// <summary>
        /// Creates a new 15-dimensional data cube position.
        /// </summary>
        public static Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15)
        {
            return new Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
        }

        /// <summary>
        /// Creates a new 15-dimensional canonical product.
        /// </summary>
        public static Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15>(IProduct15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15);
        }
    }

    /// <summary>
    /// A 15-dimensional data cube position.
    /// </summary>
    public sealed class Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> : Product15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15>
    {
        public Position15(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15)
        {
        }


        public Position14<P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> ExceptValue1
        {
            get { return Position14.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> ExceptValue2
        {
            get { return Position14.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> ExceptValue3
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> ExceptValue4
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> ExceptValue5
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P7, P8, P9, P10, P11, P12, P13, P14, P15> ExceptValue6
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P6, P8, P9, P10, P11, P12, P13, P14, P15> ExceptValue7
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P6, P7, P9, P10, P11, P12, P13, P14, P15> ExceptValue8
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P6, P7, P8, P10, P11, P12, P13, P14, P15> ExceptValue9
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P11, P12, P13, P14, P15> ExceptValue10
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P12, P13, P14, P15> ExceptValue11
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P13, P14, P15> ExceptValue12
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue13, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P14, P15> ExceptValue13
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue14, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P15> ExceptValue14
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue15); }
        }

        public Position14<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14> ExceptValue15
        {
            get { return Position14.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14); }
        }
    }

    /// <summary>
    /// A factory for 16-dimensional data cube positions.
    /// </summary>
    public static class Position16
    {
        /// <summary>
        /// Creates a new 16-dimensional data cube position.
        /// </summary>
        public static Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16)
        {
            return new Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);
        }

        /// <summary>
        /// Creates a new 16-dimensional canonical product.
        /// </summary>
        public static Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16>(IProduct16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15, p.ProductValue16);
        }
    }

    /// <summary>
    /// A 16-dimensional data cube position.
    /// </summary>
    public sealed class Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> : Product16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16>
    {
        public Position16(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16)
        {
        }


        public Position15<P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> ExceptValue1
        {
            get { return Position15.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> ExceptValue2
        {
            get { return Position15.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> ExceptValue3
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> ExceptValue4
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> ExceptValue5
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> ExceptValue6
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P8, P9, P10, P11, P12, P13, P14, P15, P16> ExceptValue7
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P7, P9, P10, P11, P12, P13, P14, P15, P16> ExceptValue8
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P7, P8, P10, P11, P12, P13, P14, P15, P16> ExceptValue9
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P11, P12, P13, P14, P15, P16> ExceptValue10
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P12, P13, P14, P15, P16> ExceptValue11
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P13, P14, P15, P16> ExceptValue12
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P14, P15, P16> ExceptValue13
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue14, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P15, P16> ExceptValue14
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue15, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P16> ExceptValue15
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue16); }
        }

        public Position15<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15> ExceptValue16
        {
            get { return Position15.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15); }
        }
    }

    /// <summary>
    /// A factory for 17-dimensional data cube positions.
    /// </summary>
    public static class Position17
    {
        /// <summary>
        /// Creates a new 17-dimensional data cube position.
        /// </summary>
        public static Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17)
        {
            return new Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17);
        }

        /// <summary>
        /// Creates a new 17-dimensional canonical product.
        /// </summary>
        public static Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17>(IProduct17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15, p.ProductValue16, p.ProductValue17);
        }
    }

    /// <summary>
    /// A 17-dimensional data cube position.
    /// </summary>
    public sealed class Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> : Product17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17>
    {
        public Position17(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17)
        {
        }


        public Position16<P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue1
        {
            get { return Position16.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue2
        {
            get { return Position16.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue3
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue4
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue5
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue6
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue7
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P9, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue8
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P8, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue9
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P11, P12, P13, P14, P15, P16, P17> ExceptValue10
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P12, P13, P14, P15, P16, P17> ExceptValue11
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P13, P14, P15, P16, P17> ExceptValue12
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P14, P15, P16, P17> ExceptValue13
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P15, P16, P17> ExceptValue14
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue15, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P16, P17> ExceptValue15
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue16, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P17> ExceptValue16
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue17); }
        }

        public Position16<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16> ExceptValue17
        {
            get { return Position16.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16); }
        }
    }

    /// <summary>
    /// A factory for 18-dimensional data cube positions.
    /// </summary>
    public static class Position18
    {
        /// <summary>
        /// Creates a new 18-dimensional data cube position.
        /// </summary>
        public static Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18)
        {
            return new Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18);
        }

        /// <summary>
        /// Creates a new 18-dimensional canonical product.
        /// </summary>
        public static Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18>(IProduct18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15, p.ProductValue16, p.ProductValue17, p.ProductValue18);
        }
    }

    /// <summary>
    /// A 18-dimensional data cube position.
    /// </summary>
    public sealed class Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> : Product18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18>
    {
        public Position18(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18)
        {
        }


        public Position17<P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue1
        {
            get { return Position17.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue2
        {
            get { return Position17.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue3
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue4
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue5
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue6
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue7
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue8
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue9
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue10
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P12, P13, P14, P15, P16, P17, P18> ExceptValue11
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P13, P14, P15, P16, P17, P18> ExceptValue12
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P14, P15, P16, P17, P18> ExceptValue13
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P15, P16, P17, P18> ExceptValue14
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P16, P17, P18> ExceptValue15
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue16, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P17, P18> ExceptValue16
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue17, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P18> ExceptValue17
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue18); }
        }

        public Position17<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17> ExceptValue18
        {
            get { return Position17.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17); }
        }
    }

    /// <summary>
    /// A factory for 19-dimensional data cube positions.
    /// </summary>
    public static class Position19
    {
        /// <summary>
        /// Creates a new 19-dimensional data cube position.
        /// </summary>
        public static Position19<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19)
        {
            return new Position19<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19);
        }

        /// <summary>
        /// Creates a new 19-dimensional canonical product.
        /// </summary>
        public static Position19<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> Create<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19>(IProduct19<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> p)
        {
            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15, p.ProductValue16, p.ProductValue17, p.ProductValue18, p.ProductValue19);
        }
    }

    /// <summary>
    /// A 19-dimensional data cube position.
    /// </summary>
    public sealed class Position19<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> : Product19<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19>
    {
        public Position19(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19)
        {
        }


        public Position18<P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue1
        {
            get { return Position18.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue2
        {
            get { return Position18.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue3
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue4
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue5
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue6
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue7
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue8
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue9
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P11, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue10
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P12, P13, P14, P15, P16, P17, P18, P19> ExceptValue11
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P13, P14, P15, P16, P17, P18, P19> ExceptValue12
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P14, P15, P16, P17, P18, P19> ExceptValue13
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P15, P16, P17, P18, P19> ExceptValue14
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue15, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P16, P17, P18, P19> ExceptValue15
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue16, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P17, P18, P19> ExceptValue16
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue17, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P18, P19> ExceptValue17
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue18, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P19> ExceptValue18
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue19); }
        }

        public Position18<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18> ExceptValue19
        {
            get { return Position18.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9, ProductValue10, ProductValue11, ProductValue12, ProductValue13, ProductValue14, ProductValue15, ProductValue16, ProductValue17, ProductValue18); }
        }
    }

}
