using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public partial class Product
    {
        /// <summary>
        /// Creates a new 0-dimensional product.
        /// </summary>
        public static Product0 Create()
        {
            return new Product0();
        }

        /// <summary>
        /// Creates a new 1-dimensional product.
        /// </summary>
        public static Product1<T1> Create<T1>(T1 t1)
        {
            return new Product1<T1>(t1);
        }

        /// <summary>
        /// Creates a new 2-dimensional product.
        /// </summary>
        public static Product2<T1, T2> Create<T1, T2>(T1 t1, T2 t2)
        {
            return new Product2<T1, T2>(t1, t2);
        }

        /// <summary>
        /// Creates a new 3-dimensional product.
        /// </summary>
        public static Product3<T1, T2, T3> Create<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            return new Product3<T1, T2, T3>(t1, t2, t3);
        }

        /// <summary>
        /// Creates a new 4-dimensional product.
        /// </summary>
        public static Product4<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return new Product4<T1, T2, T3, T4>(t1, t2, t3, t4);
        }

        /// <summary>
        /// Creates a new 5-dimensional product.
        /// </summary>
        public static Product5<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return new Product5<T1, T2, T3, T4, T5>(t1, t2, t3, t4, t5);
        }

        /// <summary>
        /// Creates a new 6-dimensional product.
        /// </summary>
        public static Product6<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return new Product6<T1, T2, T3, T4, T5, T6>(t1, t2, t3, t4, t5, t6);
        }

        /// <summary>
        /// Creates a new 7-dimensional product.
        /// </summary>
        public static Product7<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            return new Product7<T1, T2, T3, T4, T5, T6, T7>(t1, t2, t3, t4, t5, t6, t7);
        }

        /// <summary>
        /// Creates a new 8-dimensional product.
        /// </summary>
        public static Product8<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            return new Product8<T1, T2, T3, T4, T5, T6, T7, T8>(t1, t2, t3, t4, t5, t6, t7, t8);
        }

        /// <summary>
        /// Creates a new 9-dimensional product.
        /// </summary>
        public static Product9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            return new Product9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }

    }

    /// <summary>
    /// A 0-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product0 : Product
    {
        /// <summary>
        /// Creates a new 0-dimensional product.
        /// </summary>
        internal Product0()
        {
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                return Enumerable.Empty<object>();
            }
        }
    }

    /// <summary>
    /// A 1-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product1<T1> : Product
    {
        /// <summary>
        /// Creates a new 1-dimensional product.
        /// </summary>
        internal Product1(T1 t1)
        {
            Value1 = t1;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 Value1 { get; private set; }

        /// <summary>
        /// The same product with Value1 omitted.
        /// </summary>
        public Product0 ExceptValue1
        {
            get { return Product.Create(); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                yield return Value1;
            }
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public Tuple<T1> ToTuple()
        {
            return Tuple.Create(Value1);
        }
    }

    /// <summary>
    /// A 2-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product2<T1, T2> : Product
    {
        /// <summary>
        /// Creates a new 2-dimensional product.
        /// </summary>
        internal Product2(T1 t1, T2 t2)
        {
            Value1 = t1;
            Value2 = t2;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 Value1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 Value2 { get; private set; }

        /// <summary>
        /// The same product with Value1 omitted.
        /// </summary>
        public Product1<T2> ExceptValue1
        {
            get { return Product.Create(Value2); }
        }

        /// <summary>
        /// The same product with Value2 omitted.
        /// </summary>
        public Product1<T1> ExceptValue2
        {
            get { return Product.Create(Value1); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                yield return Value1;
                yield return Value2;
            }
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public Tuple<T1, T2> ToTuple()
        {
            return Tuple.Create(Value1, Value2);
        }
    }

    /// <summary>
    /// A 3-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product3<T1, T2, T3> : Product
    {
        /// <summary>
        /// Creates a new 3-dimensional product.
        /// </summary>
        internal Product3(T1 t1, T2 t2, T3 t3)
        {
            Value1 = t1;
            Value2 = t2;
            Value3 = t3;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 Value1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 Value2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 Value3 { get; private set; }

        /// <summary>
        /// The same product with Value1 omitted.
        /// </summary>
        public Product2<T2, T3> ExceptValue1
        {
            get { return Product.Create(Value2, Value3); }
        }

        /// <summary>
        /// The same product with Value2 omitted.
        /// </summary>
        public Product2<T1, T3> ExceptValue2
        {
            get { return Product.Create(Value1, Value3); }
        }

        /// <summary>
        /// The same product with Value3 omitted.
        /// </summary>
        public Product2<T1, T2> ExceptValue3
        {
            get { return Product.Create(Value1, Value2); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                yield return Value1;
                yield return Value2;
                yield return Value3;
            }
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public Tuple<T1, T2, T3> ToTuple()
        {
            return Tuple.Create(Value1, Value2, Value3);
        }
    }

    /// <summary>
    /// A 4-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product4<T1, T2, T3, T4> : Product
    {
        /// <summary>
        /// Creates a new 4-dimensional product.
        /// </summary>
        internal Product4(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            Value1 = t1;
            Value2 = t2;
            Value3 = t3;
            Value4 = t4;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 Value1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 Value2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 Value3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 Value4 { get; private set; }

        /// <summary>
        /// The same product with Value1 omitted.
        /// </summary>
        public Product3<T2, T3, T4> ExceptValue1
        {
            get { return Product.Create(Value2, Value3, Value4); }
        }

        /// <summary>
        /// The same product with Value2 omitted.
        /// </summary>
        public Product3<T1, T3, T4> ExceptValue2
        {
            get { return Product.Create(Value1, Value3, Value4); }
        }

        /// <summary>
        /// The same product with Value3 omitted.
        /// </summary>
        public Product3<T1, T2, T4> ExceptValue3
        {
            get { return Product.Create(Value1, Value2, Value4); }
        }

        /// <summary>
        /// The same product with Value4 omitted.
        /// </summary>
        public Product3<T1, T2, T3> ExceptValue4
        {
            get { return Product.Create(Value1, Value2, Value3); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                yield return Value1;
                yield return Value2;
                yield return Value3;
                yield return Value4;
            }
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public Tuple<T1, T2, T3, T4> ToTuple()
        {
            return Tuple.Create(Value1, Value2, Value3, Value4);
        }
    }

    /// <summary>
    /// A 5-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product5<T1, T2, T3, T4, T5> : Product
    {
        /// <summary>
        /// Creates a new 5-dimensional product.
        /// </summary>
        internal Product5(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            Value1 = t1;
            Value2 = t2;
            Value3 = t3;
            Value4 = t4;
            Value5 = t5;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 Value1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 Value2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 Value3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 Value4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 Value5 { get; private set; }

        /// <summary>
        /// The same product with Value1 omitted.
        /// </summary>
        public Product4<T2, T3, T4, T5> ExceptValue1
        {
            get { return Product.Create(Value2, Value3, Value4, Value5); }
        }

        /// <summary>
        /// The same product with Value2 omitted.
        /// </summary>
        public Product4<T1, T3, T4, T5> ExceptValue2
        {
            get { return Product.Create(Value1, Value3, Value4, Value5); }
        }

        /// <summary>
        /// The same product with Value3 omitted.
        /// </summary>
        public Product4<T1, T2, T4, T5> ExceptValue3
        {
            get { return Product.Create(Value1, Value2, Value4, Value5); }
        }

        /// <summary>
        /// The same product with Value4 omitted.
        /// </summary>
        public Product4<T1, T2, T3, T5> ExceptValue4
        {
            get { return Product.Create(Value1, Value2, Value3, Value5); }
        }

        /// <summary>
        /// The same product with Value5 omitted.
        /// </summary>
        public Product4<T1, T2, T3, T4> ExceptValue5
        {
            get { return Product.Create(Value1, Value2, Value3, Value4); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                yield return Value1;
                yield return Value2;
                yield return Value3;
                yield return Value4;
                yield return Value5;
            }
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public Tuple<T1, T2, T3, T4, T5> ToTuple()
        {
            return Tuple.Create(Value1, Value2, Value3, Value4, Value5);
        }
    }

    /// <summary>
    /// A 6-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product6<T1, T2, T3, T4, T5, T6> : Product
    {
        /// <summary>
        /// Creates a new 6-dimensional product.
        /// </summary>
        internal Product6(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            Value1 = t1;
            Value2 = t2;
            Value3 = t3;
            Value4 = t4;
            Value5 = t5;
            Value6 = t6;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 Value1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 Value2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 Value3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 Value4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 Value5 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 Value6 { get; private set; }

        /// <summary>
        /// The same product with Value1 omitted.
        /// </summary>
        public Product5<T2, T3, T4, T5, T6> ExceptValue1
        {
            get { return Product.Create(Value2, Value3, Value4, Value5, Value6); }
        }

        /// <summary>
        /// The same product with Value2 omitted.
        /// </summary>
        public Product5<T1, T3, T4, T5, T6> ExceptValue2
        {
            get { return Product.Create(Value1, Value3, Value4, Value5, Value6); }
        }

        /// <summary>
        /// The same product with Value3 omitted.
        /// </summary>
        public Product5<T1, T2, T4, T5, T6> ExceptValue3
        {
            get { return Product.Create(Value1, Value2, Value4, Value5, Value6); }
        }

        /// <summary>
        /// The same product with Value4 omitted.
        /// </summary>
        public Product5<T1, T2, T3, T5, T6> ExceptValue4
        {
            get { return Product.Create(Value1, Value2, Value3, Value5, Value6); }
        }

        /// <summary>
        /// The same product with Value5 omitted.
        /// </summary>
        public Product5<T1, T2, T3, T4, T6> ExceptValue5
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value6); }
        }

        /// <summary>
        /// The same product with Value6 omitted.
        /// </summary>
        public Product5<T1, T2, T3, T4, T5> ExceptValue6
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                yield return Value1;
                yield return Value2;
                yield return Value3;
                yield return Value4;
                yield return Value5;
                yield return Value6;
            }
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public Tuple<T1, T2, T3, T4, T5, T6> ToTuple()
        {
            return Tuple.Create(Value1, Value2, Value3, Value4, Value5, Value6);
        }
    }

    /// <summary>
    /// A 7-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product7<T1, T2, T3, T4, T5, T6, T7> : Product
    {
        /// <summary>
        /// Creates a new 7-dimensional product.
        /// </summary>
        internal Product7(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            Value1 = t1;
            Value2 = t2;
            Value3 = t3;
            Value4 = t4;
            Value5 = t5;
            Value6 = t6;
            Value7 = t7;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 Value1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 Value2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 Value3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 Value4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 Value5 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 Value6 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        public T7 Value7 { get; private set; }

        /// <summary>
        /// The same product with Value1 omitted.
        /// </summary>
        public Product6<T2, T3, T4, T5, T6, T7> ExceptValue1
        {
            get { return Product.Create(Value2, Value3, Value4, Value5, Value6, Value7); }
        }

        /// <summary>
        /// The same product with Value2 omitted.
        /// </summary>
        public Product6<T1, T3, T4, T5, T6, T7> ExceptValue2
        {
            get { return Product.Create(Value1, Value3, Value4, Value5, Value6, Value7); }
        }

        /// <summary>
        /// The same product with Value3 omitted.
        /// </summary>
        public Product6<T1, T2, T4, T5, T6, T7> ExceptValue3
        {
            get { return Product.Create(Value1, Value2, Value4, Value5, Value6, Value7); }
        }

        /// <summary>
        /// The same product with Value4 omitted.
        /// </summary>
        public Product6<T1, T2, T3, T5, T6, T7> ExceptValue4
        {
            get { return Product.Create(Value1, Value2, Value3, Value5, Value6, Value7); }
        }

        /// <summary>
        /// The same product with Value5 omitted.
        /// </summary>
        public Product6<T1, T2, T3, T4, T6, T7> ExceptValue5
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value6, Value7); }
        }

        /// <summary>
        /// The same product with Value6 omitted.
        /// </summary>
        public Product6<T1, T2, T3, T4, T5, T7> ExceptValue6
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5, Value7); }
        }

        /// <summary>
        /// The same product with Value7 omitted.
        /// </summary>
        public Product6<T1, T2, T3, T4, T5, T6> ExceptValue7
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5, Value6); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                yield return Value1;
                yield return Value2;
                yield return Value3;
                yield return Value4;
                yield return Value5;
                yield return Value6;
                yield return Value7;
            }
        }

        /// <summary>
        /// Converts the product into a tuple.
        /// </summary>
        public Tuple<T1, T2, T3, T4, T5, T6, T7> ToTuple()
        {
            return Tuple.Create(Value1, Value2, Value3, Value4, Value5, Value6, Value7);
        }
    }

    /// <summary>
    /// A 8-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product8<T1, T2, T3, T4, T5, T6, T7, T8> : Product
    {
        /// <summary>
        /// Creates a new 8-dimensional product.
        /// </summary>
        internal Product8(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            Value1 = t1;
            Value2 = t2;
            Value3 = t3;
            Value4 = t4;
            Value5 = t5;
            Value6 = t6;
            Value7 = t7;
            Value8 = t8;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 Value1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 Value2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 Value3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 Value4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 Value5 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 Value6 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        public T7 Value7 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 8.
        /// </summary>
        public T8 Value8 { get; private set; }

        /// <summary>
        /// The same product with Value1 omitted.
        /// </summary>
        public Product7<T2, T3, T4, T5, T6, T7, T8> ExceptValue1
        {
            get { return Product.Create(Value2, Value3, Value4, Value5, Value6, Value7, Value8); }
        }

        /// <summary>
        /// The same product with Value2 omitted.
        /// </summary>
        public Product7<T1, T3, T4, T5, T6, T7, T8> ExceptValue2
        {
            get { return Product.Create(Value1, Value3, Value4, Value5, Value6, Value7, Value8); }
        }

        /// <summary>
        /// The same product with Value3 omitted.
        /// </summary>
        public Product7<T1, T2, T4, T5, T6, T7, T8> ExceptValue3
        {
            get { return Product.Create(Value1, Value2, Value4, Value5, Value6, Value7, Value8); }
        }

        /// <summary>
        /// The same product with Value4 omitted.
        /// </summary>
        public Product7<T1, T2, T3, T5, T6, T7, T8> ExceptValue4
        {
            get { return Product.Create(Value1, Value2, Value3, Value5, Value6, Value7, Value8); }
        }

        /// <summary>
        /// The same product with Value5 omitted.
        /// </summary>
        public Product7<T1, T2, T3, T4, T6, T7, T8> ExceptValue5
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value6, Value7, Value8); }
        }

        /// <summary>
        /// The same product with Value6 omitted.
        /// </summary>
        public Product7<T1, T2, T3, T4, T5, T7, T8> ExceptValue6
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5, Value7, Value8); }
        }

        /// <summary>
        /// The same product with Value7 omitted.
        /// </summary>
        public Product7<T1, T2, T3, T4, T5, T6, T8> ExceptValue7
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5, Value6, Value8); }
        }

        /// <summary>
        /// The same product with Value8 omitted.
        /// </summary>
        public Product7<T1, T2, T3, T4, T5, T6, T7> ExceptValue8
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5, Value6, Value7); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                yield return Value1;
                yield return Value2;
                yield return Value3;
                yield return Value4;
                yield return Value5;
                yield return Value6;
                yield return Value7;
                yield return Value8;
            }
        }
    }

    /// <summary>
    /// A 9-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product9<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Product
    {
        /// <summary>
        /// Creates a new 9-dimensional product.
        /// </summary>
        internal Product9(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            Value1 = t1;
            Value2 = t2;
            Value3 = t3;
            Value4 = t4;
            Value5 = t5;
            Value6 = t6;
            Value7 = t7;
            Value8 = t8;
            Value9 = t9;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 Value1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 Value2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 Value3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 Value4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 Value5 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 Value6 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        public T7 Value7 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 8.
        /// </summary>
        public T8 Value8 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 9.
        /// </summary>
        public T9 Value9 { get; private set; }

        /// <summary>
        /// The same product with Value1 omitted.
        /// </summary>
        public Product8<T2, T3, T4, T5, T6, T7, T8, T9> ExceptValue1
        {
            get { return Product.Create(Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9); }
        }

        /// <summary>
        /// The same product with Value2 omitted.
        /// </summary>
        public Product8<T1, T3, T4, T5, T6, T7, T8, T9> ExceptValue2
        {
            get { return Product.Create(Value1, Value3, Value4, Value5, Value6, Value7, Value8, Value9); }
        }

        /// <summary>
        /// The same product with Value3 omitted.
        /// </summary>
        public Product8<T1, T2, T4, T5, T6, T7, T8, T9> ExceptValue3
        {
            get { return Product.Create(Value1, Value2, Value4, Value5, Value6, Value7, Value8, Value9); }
        }

        /// <summary>
        /// The same product with Value4 omitted.
        /// </summary>
        public Product8<T1, T2, T3, T5, T6, T7, T8, T9> ExceptValue4
        {
            get { return Product.Create(Value1, Value2, Value3, Value5, Value6, Value7, Value8, Value9); }
        }

        /// <summary>
        /// The same product with Value5 omitted.
        /// </summary>
        public Product8<T1, T2, T3, T4, T6, T7, T8, T9> ExceptValue5
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value6, Value7, Value8, Value9); }
        }

        /// <summary>
        /// The same product with Value6 omitted.
        /// </summary>
        public Product8<T1, T2, T3, T4, T5, T7, T8, T9> ExceptValue6
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5, Value7, Value8, Value9); }
        }

        /// <summary>
        /// The same product with Value7 omitted.
        /// </summary>
        public Product8<T1, T2, T3, T4, T5, T6, T8, T9> ExceptValue7
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5, Value6, Value8, Value9); }
        }

        /// <summary>
        /// The same product with Value8 omitted.
        /// </summary>
        public Product8<T1, T2, T3, T4, T5, T6, T7, T9> ExceptValue8
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value9); }
        }

        /// <summary>
        /// The same product with Value9 omitted.
        /// </summary>
        public Product8<T1, T2, T3, T4, T5, T6, T7, T8> ExceptValue9
        {
            get { return Product.Create(Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> Values
        {
            get
            {
                yield return Value1;
                yield return Value2;
                yield return Value3;
                yield return Value4;
                yield return Value5;
                yield return Value6;
                yield return Value7;
                yield return Value8;
                yield return Value9;
            }
        }
    }

}
