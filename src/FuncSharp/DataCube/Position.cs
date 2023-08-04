
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

}
