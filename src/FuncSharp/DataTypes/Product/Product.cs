using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    /// <summary>
    /// Base class and factory of canonical product types.
    /// </summary>
    public abstract class Product : IProduct
    {
        public abstract IEnumerable<object> ProductValues { get; }

        /// <summary>
        /// Creates a new 0-dimensional canonical product.
        /// </summary>
        public static IProduct0 Create()
        {
            return new Product0();
        }

        /// <summary>
        /// Creates a new 0-dimensional canonical product.
        /// </summary>
        public static IProduct0 Create(IProduct0 p)
        {
            if (Equals(p.GetType(), typeof(Product0)))
            {
                return p;
            }

            return Create();
        }

        /// <summary>
        /// Creates a new 1-dimensional canonical product.
        /// </summary>
        public static IProduct1<T1> Create<T1>(T1 t1)
        {
            return new Product1<T1>(t1);
        }

        /// <summary>
        /// Creates a new 1-dimensional canonical product.
        /// </summary>
        public static IProduct1<T1> Create<T1>(IProduct1<T1> p)
        {
            if (Equals(p.GetType(), typeof(Product1<T1>)))
            {
                return p;
            }

            return Create(p.ProductValue1);
        }

        /// <summary>
        /// Creates a new 2-dimensional canonical product.
        /// </summary>
        public static IProduct2<T1, T2> Create<T1, T2>(T1 t1, T2 t2)
        {
            return new Product2<T1, T2>(t1, t2);
        }

        /// <summary>
        /// Creates a new 2-dimensional canonical product.
        /// </summary>
        public static IProduct2<T1, T2> Create<T1, T2>(IProduct2<T1, T2> p)
        {
            if (Equals(p.GetType(), typeof(Product2<T1, T2>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2);
        }

        /// <summary>
        /// Creates a new 3-dimensional canonical product.
        /// </summary>
        public static IProduct3<T1, T2, T3> Create<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            return new Product3<T1, T2, T3>(t1, t2, t3);
        }

        /// <summary>
        /// Creates a new 3-dimensional canonical product.
        /// </summary>
        public static IProduct3<T1, T2, T3> Create<T1, T2, T3>(IProduct3<T1, T2, T3> p)
        {
            if (Equals(p.GetType(), typeof(Product3<T1, T2, T3>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3);
        }

        /// <summary>
        /// Creates a new 4-dimensional canonical product.
        /// </summary>
        public static IProduct4<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return new Product4<T1, T2, T3, T4>(t1, t2, t3, t4);
        }

        /// <summary>
        /// Creates a new 4-dimensional canonical product.
        /// </summary>
        public static IProduct4<T1, T2, T3, T4> Create<T1, T2, T3, T4>(IProduct4<T1, T2, T3, T4> p)
        {
            if (Equals(p.GetType(), typeof(Product4<T1, T2, T3, T4>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4);
        }

        /// <summary>
        /// Creates a new 5-dimensional canonical product.
        /// </summary>
        public static IProduct5<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return new Product5<T1, T2, T3, T4, T5>(t1, t2, t3, t4, t5);
        }

        /// <summary>
        /// Creates a new 5-dimensional canonical product.
        /// </summary>
        public static IProduct5<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(IProduct5<T1, T2, T3, T4, T5> p)
        {
            if (Equals(p.GetType(), typeof(Product5<T1, T2, T3, T4, T5>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5);
        }

        /// <summary>
        /// Creates a new 6-dimensional canonical product.
        /// </summary>
        public static IProduct6<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return new Product6<T1, T2, T3, T4, T5, T6>(t1, t2, t3, t4, t5, t6);
        }

        /// <summary>
        /// Creates a new 6-dimensional canonical product.
        /// </summary>
        public static IProduct6<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(IProduct6<T1, T2, T3, T4, T5, T6> p)
        {
            if (Equals(p.GetType(), typeof(Product6<T1, T2, T3, T4, T5, T6>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6);
        }

        /// <summary>
        /// Creates a new 7-dimensional canonical product.
        /// </summary>
        public static IProduct7<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            return new Product7<T1, T2, T3, T4, T5, T6, T7>(t1, t2, t3, t4, t5, t6, t7);
        }

        /// <summary>
        /// Creates a new 7-dimensional canonical product.
        /// </summary>
        public static IProduct7<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(IProduct7<T1, T2, T3, T4, T5, T6, T7> p)
        {
            if (Equals(p.GetType(), typeof(Product7<T1, T2, T3, T4, T5, T6, T7>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7);
        }

        /// <summary>
        /// Creates a new 8-dimensional canonical product.
        /// </summary>
        public static IProduct8<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            return new Product8<T1, T2, T3, T4, T5, T6, T7, T8>(t1, t2, t3, t4, t5, t6, t7, t8);
        }

        /// <summary>
        /// Creates a new 8-dimensional canonical product.
        /// </summary>
        public static IProduct8<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(IProduct8<T1, T2, T3, T4, T5, T6, T7, T8> p)
        {
            if (Equals(p.GetType(), typeof(Product8<T1, T2, T3, T4, T5, T6, T7, T8>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8);
        }

        /// <summary>
        /// Creates a new 9-dimensional canonical product.
        /// </summary>
        public static IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            return new Product9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }

        /// <summary>
        /// Creates a new 9-dimensional canonical product.
        /// </summary>
        public static IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9> p)
        {
            if (Equals(p.GetType(), typeof(Product9<T1, T2, T3, T4, T5, T6, T7, T8, T9>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9);
        }

        public override int GetHashCode()
        {
            return this.ProductHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.ProductEquals(obj);
        }

        public override string ToString()
        {
            return this.ProductToString();
        }
    }

    /// <summary>
    /// A 0-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product0 : Product, IProduct0
    {
        /// <summary>
        /// Creates a new 0-dimensional product.
        /// </summary>
        public Product0()
        {
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
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
    public class Product1<T1> : Product, IProduct1<T1>
    {
        /// <summary>
        /// Creates a new 1-dimensional product.
        /// </summary>
        public Product1(T1 t1)
        {
            ProductValue1 = t1;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; private set; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        public IProduct0 ExceptValue1
        {
            get { return Product.Create(); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
            }
        }
    }

    /// <summary>
    /// A 2-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product2<T1, T2> : Product, IProduct2<T1, T2>
    {
        /// <summary>
        /// Creates a new 2-dimensional product.
        /// </summary>
        public Product2(T1 t1, T2 t2)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; private set; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        public IProduct1<T2> ExceptValue1
        {
            get { return Product.Create(ProductValue2); }
        }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        public IProduct1<T1> ExceptValue2
        {
            get { return Product.Create(ProductValue1); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
            }
        }
    }

    /// <summary>
    /// A 3-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product3<T1, T2, T3> : Product, IProduct3<T1, T2, T3>
    {
        /// <summary>
        /// Creates a new 3-dimensional product.
        /// </summary>
        public Product3(T1 t1, T2 t2, T3 t3)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; private set; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        public IProduct2<T2, T3> ExceptValue1
        {
            get { return Product.Create(ProductValue2, ProductValue3); }
        }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        public IProduct2<T1, T3> ExceptValue2
        {
            get { return Product.Create(ProductValue1, ProductValue3); }
        }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        public IProduct2<T1, T2> ExceptValue3
        {
            get { return Product.Create(ProductValue1, ProductValue2); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
                yield return ProductValue3;
            }
        }
    }

    /// <summary>
    /// A 4-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product4<T1, T2, T3, T4> : Product, IProduct4<T1, T2, T3, T4>
    {
        /// <summary>
        /// Creates a new 4-dimensional product.
        /// </summary>
        public Product4(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
            ProductValue4 = t4;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; private set; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        public IProduct3<T2, T3, T4> ExceptValue1
        {
            get { return Product.Create(ProductValue2, ProductValue3, ProductValue4); }
        }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        public IProduct3<T1, T3, T4> ExceptValue2
        {
            get { return Product.Create(ProductValue1, ProductValue3, ProductValue4); }
        }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        public IProduct3<T1, T2, T4> ExceptValue3
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue4); }
        }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        public IProduct3<T1, T2, T3> ExceptValue4
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
                yield return ProductValue3;
                yield return ProductValue4;
            }
        }
    }

    /// <summary>
    /// A 5-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product5<T1, T2, T3, T4, T5> : Product, IProduct5<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Creates a new 5-dimensional product.
        /// </summary>
        public Product5(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
            ProductValue4 = t4;
            ProductValue5 = t5;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 ProductValue5 { get; private set; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        public IProduct4<T2, T3, T4, T5> ExceptValue1
        {
            get { return Product.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5); }
        }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        public IProduct4<T1, T3, T4, T5> ExceptValue2
        {
            get { return Product.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5); }
        }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        public IProduct4<T1, T2, T4, T5> ExceptValue3
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5); }
        }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        public IProduct4<T1, T2, T3, T5> ExceptValue4
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5); }
        }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        public IProduct4<T1, T2, T3, T4> ExceptValue5
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
                yield return ProductValue3;
                yield return ProductValue4;
                yield return ProductValue5;
            }
        }
    }

    /// <summary>
    /// A 6-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product6<T1, T2, T3, T4, T5, T6> : Product, IProduct6<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// Creates a new 6-dimensional product.
        /// </summary>
        public Product6(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
            ProductValue4 = t4;
            ProductValue5 = t5;
            ProductValue6 = t6;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 ProductValue5 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 ProductValue6 { get; private set; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        public IProduct5<T2, T3, T4, T5, T6> ExceptValue1
        {
            get { return Product.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6); }
        }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        public IProduct5<T1, T3, T4, T5, T6> ExceptValue2
        {
            get { return Product.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6); }
        }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        public IProduct5<T1, T2, T4, T5, T6> ExceptValue3
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6); }
        }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        public IProduct5<T1, T2, T3, T5, T6> ExceptValue4
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6); }
        }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        public IProduct5<T1, T2, T3, T4, T6> ExceptValue5
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6); }
        }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        public IProduct5<T1, T2, T3, T4, T5> ExceptValue6
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
                yield return ProductValue3;
                yield return ProductValue4;
                yield return ProductValue5;
                yield return ProductValue6;
            }
        }
    }

    /// <summary>
    /// A 7-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product7<T1, T2, T3, T4, T5, T6, T7> : Product, IProduct7<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        /// Creates a new 7-dimensional product.
        /// </summary>
        public Product7(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
            ProductValue4 = t4;
            ProductValue5 = t5;
            ProductValue6 = t6;
            ProductValue7 = t7;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 ProductValue5 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 ProductValue6 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        public T7 ProductValue7 { get; private set; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        public IProduct6<T2, T3, T4, T5, T6, T7> ExceptValue1
        {
            get { return Product.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7); }
        }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        public IProduct6<T1, T3, T4, T5, T6, T7> ExceptValue2
        {
            get { return Product.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7); }
        }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        public IProduct6<T1, T2, T4, T5, T6, T7> ExceptValue3
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7); }
        }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        public IProduct6<T1, T2, T3, T5, T6, T7> ExceptValue4
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7); }
        }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        public IProduct6<T1, T2, T3, T4, T6, T7> ExceptValue5
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7); }
        }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        public IProduct6<T1, T2, T3, T4, T5, T7> ExceptValue6
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7); }
        }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        public IProduct6<T1, T2, T3, T4, T5, T6> ExceptValue7
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
                yield return ProductValue3;
                yield return ProductValue4;
                yield return ProductValue5;
                yield return ProductValue6;
                yield return ProductValue7;
            }
        }
    }

    /// <summary>
    /// A 8-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product8<T1, T2, T3, T4, T5, T6, T7, T8> : Product, IProduct8<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        /// Creates a new 8-dimensional product.
        /// </summary>
        public Product8(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
            ProductValue4 = t4;
            ProductValue5 = t5;
            ProductValue6 = t6;
            ProductValue7 = t7;
            ProductValue8 = t8;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 ProductValue5 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 ProductValue6 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        public T7 ProductValue7 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 8.
        /// </summary>
        public T8 ProductValue8 { get; private set; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        public IProduct7<T2, T3, T4, T5, T6, T7, T8> ExceptValue1
        {
            get { return Product.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        public IProduct7<T1, T3, T4, T5, T6, T7, T8> ExceptValue2
        {
            get { return Product.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        public IProduct7<T1, T2, T4, T5, T6, T7, T8> ExceptValue3
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        public IProduct7<T1, T2, T3, T5, T6, T7, T8> ExceptValue4
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        public IProduct7<T1, T2, T3, T4, T6, T7, T8> ExceptValue5
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8); }
        }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        public IProduct7<T1, T2, T3, T4, T5, T7, T8> ExceptValue6
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8); }
        }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        public IProduct7<T1, T2, T3, T4, T5, T6, T8> ExceptValue7
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8); }
        }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        public IProduct7<T1, T2, T3, T4, T5, T6, T7> ExceptValue8
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
                yield return ProductValue3;
                yield return ProductValue4;
                yield return ProductValue5;
                yield return ProductValue6;
                yield return ProductValue7;
                yield return ProductValue8;
            }
        }
    }

    /// <summary>
    /// A 9-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product9<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Product, IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        /// <summary>
        /// Creates a new 9-dimensional product.
        /// </summary>
        public Product9(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
            ProductValue4 = t4;
            ProductValue5 = t5;
            ProductValue6 = t6;
            ProductValue7 = t7;
            ProductValue8 = t8;
            ProductValue9 = t9;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 ProductValue5 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 ProductValue6 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        public T7 ProductValue7 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 8.
        /// </summary>
        public T8 ProductValue8 { get; private set; }

        /// <summary>
        /// Value of the product in the dimension 9.
        /// </summary>
        public T9 ProductValue9 { get; private set; }

        /// <summary>
        /// The same product with ProductValue1 omitted.
        /// </summary>
        public IProduct8<T2, T3, T4, T5, T6, T7, T8, T9> ExceptValue1
        {
            get { return Product.Create(ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        /// <summary>
        /// The same product with ProductValue2 omitted.
        /// </summary>
        public IProduct8<T1, T3, T4, T5, T6, T7, T8, T9> ExceptValue2
        {
            get { return Product.Create(ProductValue1, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        /// <summary>
        /// The same product with ProductValue3 omitted.
        /// </summary>
        public IProduct8<T1, T2, T4, T5, T6, T7, T8, T9> ExceptValue3
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        /// <summary>
        /// The same product with ProductValue4 omitted.
        /// </summary>
        public IProduct8<T1, T2, T3, T5, T6, T7, T8, T9> ExceptValue4
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue5, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        /// <summary>
        /// The same product with ProductValue5 omitted.
        /// </summary>
        public IProduct8<T1, T2, T3, T4, T6, T7, T8, T9> ExceptValue5
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue6, ProductValue7, ProductValue8, ProductValue9); }
        }

        /// <summary>
        /// The same product with ProductValue6 omitted.
        /// </summary>
        public IProduct8<T1, T2, T3, T4, T5, T7, T8, T9> ExceptValue6
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue7, ProductValue8, ProductValue9); }
        }

        /// <summary>
        /// The same product with ProductValue7 omitted.
        /// </summary>
        public IProduct8<T1, T2, T3, T4, T5, T6, T8, T9> ExceptValue7
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue8, ProductValue9); }
        }

        /// <summary>
        /// The same product with ProductValue8 omitted.
        /// </summary>
        public IProduct8<T1, T2, T3, T4, T5, T6, T7, T9> ExceptValue8
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue9); }
        }

        /// <summary>
        /// The same product with ProductValue9 omitted.
        /// </summary>
        public IProduct8<T1, T2, T3, T4, T5, T6, T7, T8> ExceptValue9
        {
            get { return Product.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8); }
        }

        /// <summary>
        /// Values of the product in order of the dimensions.
        /// </summary>
        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
                yield return ProductValue3;
                yield return ProductValue4;
                yield return ProductValue5;
                yield return ProductValue6;
                yield return ProductValue7;
                yield return ProductValue8;
                yield return ProductValue9;
            }
        }
    }

}
