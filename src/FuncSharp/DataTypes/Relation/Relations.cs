namespace FuncSharp
{
    /// <summary>
    /// A 0-dimensional relation.
    /// </summary>
    public class Relation0 : Relation<IProduct0, DataCube0<Unit>>
    {
        /// <summary>
        /// Creates an empty 0-dimensional relation.
        /// </summary>
        public Relation0()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified product.
        /// </summary>
        public bool Contains()
        {
            return Contains(Product0.Create());
        }

        /// <summary>
        /// Adds the specified product to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set()
        {
            return Set(Product0.Create());
        }
    }

    /// <summary>
    /// A 1-dimensional relation.
    /// </summary>
    public class Relation1<T1> : Relation<IProduct1<T1>, DataCube1<T1, Unit>>
    {
        /// <summary>
        /// Creates an empty 1-dimensional relation.
        /// </summary>
        public Relation1()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified product.
        /// </summary>
        public bool Contains(T1 t1)
        {
            return Contains(Product1.Create(t1));
        }

        /// <summary>
        /// Adds the specified product to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(T1 t1)
        {
            return Set(Product1.Create(t1));
        }
    }

    /// <summary>
    /// A 2-dimensional relation.
    /// </summary>
    public class Relation2<T1, T2> : Relation<IProduct2<T1, T2>, DataCube2<T1, T2, Unit>>
    {
        /// <summary>
        /// Creates an empty 2-dimensional relation.
        /// </summary>
        public Relation2()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified product.
        /// </summary>
        public bool Contains(T1 t1, T2 t2)
        {
            return Contains(Product2.Create(t1, t2));
        }

        /// <summary>
        /// Adds the specified product to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(T1 t1, T2 t2)
        {
            return Set(Product2.Create(t1, t2));
        }
    }

    /// <summary>
    /// A 3-dimensional relation.
    /// </summary>
    public class Relation3<T1, T2, T3> : Relation<IProduct3<T1, T2, T3>, DataCube3<T1, T2, T3, Unit>>
    {
        /// <summary>
        /// Creates an empty 3-dimensional relation.
        /// </summary>
        public Relation3()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified product.
        /// </summary>
        public bool Contains(T1 t1, T2 t2, T3 t3)
        {
            return Contains(Product3.Create(t1, t2, t3));
        }

        /// <summary>
        /// Adds the specified product to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(T1 t1, T2 t2, T3 t3)
        {
            return Set(Product3.Create(t1, t2, t3));
        }
    }

    /// <summary>
    /// A 4-dimensional relation.
    /// </summary>
    public class Relation4<T1, T2, T3, T4> : Relation<IProduct4<T1, T2, T3, T4>, DataCube4<T1, T2, T3, T4, Unit>>
    {
        /// <summary>
        /// Creates an empty 4-dimensional relation.
        /// </summary>
        public Relation4()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified product.
        /// </summary>
        public bool Contains(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return Contains(Product4.Create(t1, t2, t3, t4));
        }

        /// <summary>
        /// Adds the specified product to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return Set(Product4.Create(t1, t2, t3, t4));
        }
    }

    /// <summary>
    /// A 5-dimensional relation.
    /// </summary>
    public class Relation5<T1, T2, T3, T4, T5> : Relation<IProduct5<T1, T2, T3, T4, T5>, DataCube5<T1, T2, T3, T4, T5, Unit>>
    {
        /// <summary>
        /// Creates an empty 5-dimensional relation.
        /// </summary>
        public Relation5()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified product.
        /// </summary>
        public bool Contains(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return Contains(Product5.Create(t1, t2, t3, t4, t5));
        }

        /// <summary>
        /// Adds the specified product to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return Set(Product5.Create(t1, t2, t3, t4, t5));
        }
    }

    /// <summary>
    /// A 6-dimensional relation.
    /// </summary>
    public class Relation6<T1, T2, T3, T4, T5, T6> : Relation<IProduct6<T1, T2, T3, T4, T5, T6>, DataCube6<T1, T2, T3, T4, T5, T6, Unit>>
    {
        /// <summary>
        /// Creates an empty 6-dimensional relation.
        /// </summary>
        public Relation6()
            : base()
        {
        }

        /// <summary>
        /// Returns whether the relation contains the specified product.
        /// </summary>
        public bool Contains(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return Contains(Product6.Create(t1, t2, t3, t4, t5, t6));
        }

        /// <summary>
        /// Adds the specified product to the relation. Returns true if it was added, false if it was already present.
        /// </summary>
        public bool Set(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return Set(Product6.Create(t1, t2, t3, t4, t5, t6));
        }
    }

}
