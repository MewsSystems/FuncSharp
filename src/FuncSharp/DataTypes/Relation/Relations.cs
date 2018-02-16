using System;

namespace FuncSharp
{
    /// <summary>
    /// A 0-dimensional relation.
    /// </summary>
    public class Relation0 : Relation<Position0, DataCube0<Unit>>
    {
        /// <summary>
        /// Creates an empty 0-dimensional relation.
        /// </summary>
        public Relation0()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified position.
        /// </summary>
        public bool Contains()
        {
            return Contains(Position0.Create());
        }

        /// <summary>
        /// Adds the specified position to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set()
        {
            return Set(Position0.Create());
        }
    }

    /// <summary>
    /// A 1-dimensional relation.
    /// </summary>
    public class Relation1<P1> : Relation<Position1<P1>, DataCube1<P1, Unit>>
    {
        /// <summary>
        /// Creates an empty 1-dimensional relation.
        /// </summary>
        public Relation1()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified position.
        /// </summary>
        public bool Contains(P1 p1)
        {
            return Contains(Position1.Create(p1));
        }

        /// <summary>
        /// Adds the specified position to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(P1 p1)
        {
            return Set(Position1.Create(p1));
        }

        /// <summary>
        /// For each relation, invokes the specified function.
        /// </summary>
        public void ForEach(Action<P1> a)
        {
            ForEach(p => a(p.ProductValue1));
        }
    }

    /// <summary>
    /// A 2-dimensional relation.
    /// </summary>
    public class Relation2<P1, P2> : Relation<Position2<P1, P2>, DataCube2<P1, P2, Unit>>
    {
        /// <summary>
        /// Creates an empty 2-dimensional relation.
        /// </summary>
        public Relation2()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified position.
        /// </summary>
        public bool Contains(P1 p1, P2 p2)
        {
            return Contains(Position2.Create(p1, p2));
        }

        /// <summary>
        /// Adds the specified position to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(P1 p1, P2 p2)
        {
            return Set(Position2.Create(p1, p2));
        }

        /// <summary>
        /// For each relation, invokes the specified function.
        /// </summary>
        public void ForEach(Action<P1, P2> a)
        {
            ForEach(p => a(p.ProductValue1, p.ProductValue2));
        }
    }

    /// <summary>
    /// A 3-dimensional relation.
    /// </summary>
    public class Relation3<P1, P2, P3> : Relation<Position3<P1, P2, P3>, DataCube3<P1, P2, P3, Unit>>
    {
        /// <summary>
        /// Creates an empty 3-dimensional relation.
        /// </summary>
        public Relation3()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified position.
        /// </summary>
        public bool Contains(P1 p1, P2 p2, P3 p3)
        {
            return Contains(Position3.Create(p1, p2, p3));
        }

        /// <summary>
        /// Adds the specified position to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(P1 p1, P2 p2, P3 p3)
        {
            return Set(Position3.Create(p1, p2, p3));
        }

        /// <summary>
        /// For each relation, invokes the specified function.
        /// </summary>
        public void ForEach(Action<P1, P2, P3> a)
        {
            ForEach(p => a(p.ProductValue1, p.ProductValue2, p.ProductValue3));
        }
    }

    /// <summary>
    /// A 4-dimensional relation.
    /// </summary>
    public class Relation4<P1, P2, P3, P4> : Relation<Position4<P1, P2, P3, P4>, DataCube4<P1, P2, P3, P4, Unit>>
    {
        /// <summary>
        /// Creates an empty 4-dimensional relation.
        /// </summary>
        public Relation4()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified position.
        /// </summary>
        public bool Contains(P1 p1, P2 p2, P3 p3, P4 p4)
        {
            return Contains(Position4.Create(p1, p2, p3, p4));
        }

        /// <summary>
        /// Adds the specified position to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(P1 p1, P2 p2, P3 p3, P4 p4)
        {
            return Set(Position4.Create(p1, p2, p3, p4));
        }

        /// <summary>
        /// For each relation, invokes the specified function.
        /// </summary>
        public void ForEach(Action<P1, P2, P3, P4> a)
        {
            ForEach(p => a(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4));
        }
    }

    /// <summary>
    /// A 5-dimensional relation.
    /// </summary>
    public class Relation5<P1, P2, P3, P4, P5> : Relation<Position5<P1, P2, P3, P4, P5>, DataCube5<P1, P2, P3, P4, P5, Unit>>
    {
        /// <summary>
        /// Creates an empty 5-dimensional relation.
        /// </summary>
        public Relation5()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified position.
        /// </summary>
        public bool Contains(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            return Contains(Position5.Create(p1, p2, p3, p4, p5));
        }

        /// <summary>
        /// Adds the specified position to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5)
        {
            return Set(Position5.Create(p1, p2, p3, p4, p5));
        }

        /// <summary>
        /// For each relation, invokes the specified function.
        /// </summary>
        public void ForEach(Action<P1, P2, P3, P4, P5> a)
        {
            ForEach(p => a(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5));
        }
    }

    /// <summary>
    /// A 6-dimensional relation.
    /// </summary>
    public class Relation6<P1, P2, P3, P4, P5, P6> : Relation<Position6<P1, P2, P3, P4, P5, P6>, DataCube6<P1, P2, P3, P4, P5, P6, Unit>>
    {
        /// <summary>
        /// Creates an empty 6-dimensional relation.
        /// </summary>
        public Relation6()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified position.
        /// </summary>
        public bool Contains(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            return Contains(Position6.Create(p1, p2, p3, p4, p5, p6));
        }

        /// <summary>
        /// Adds the specified position to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6)
        {
            return Set(Position6.Create(p1, p2, p3, p4, p5, p6));
        }

        /// <summary>
        /// For each relation, invokes the specified function.
        /// </summary>
        public void ForEach(Action<P1, P2, P3, P4, P5, P6> a)
        {
            ForEach(p => a(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6));
        }
    }

}
