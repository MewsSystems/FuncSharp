using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    /// <summary>
    /// Base class and factory of canonical product types.
    /// </summary>
    public abstract class ProductBase : IProduct
    {
        public abstract IEnumerable<object> ProductValues { get; }

        private int? HashCode { get; set; }

        public override int GetHashCode()
        {
            return HashCode ?? (HashCode = Structural.HashCode(ProductValues)).Value;
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
    public class Product0 : ProductBase, IProduct0
    {
        public Product0()
        {
        }

        public override IEnumerable<object> ProductValues
        {
            get
            {
                return Enumerable.Empty<object>();
            }
        }

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

        public R Match<R>(Func<R> f)
        {
            return f();
        }
    }

    /// <summary>
    /// A factory for 1-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product1
    {
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
    }

    /// <summary>
    /// A 1-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product1<T1> : ProductBase, IProduct1<T1>
    {
        public Product1(T1 t1)
        {
            ProductValue1 = t1;
        }

        public T1 ProductValue1 { get; }

        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
            }
        }

        public R Match<R>(Func<T1, R> f)
        {
            return f(ProductValue1);
        }
    }

    /// <summary>
    /// A factory for 2-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product2
    {
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
    }

    /// <summary>
    /// A 2-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product2<T1, T2> : ProductBase, IProduct2<T1, T2>
    {
        public Product2(T1 t1, T2 t2)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
            }
        }

        public R Match<R>(Func<T1, T2, R> f)
        {
            return f(ProductValue1, ProductValue2);
        }
    }

    /// <summary>
    /// A factory for 3-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product3
    {
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
    }

    /// <summary>
    /// A 3-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product3<T1, T2, T3> : ProductBase, IProduct3<T1, T2, T3>
    {
        public Product3(T1 t1, T2 t2, T3 t3)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
                yield return ProductValue3;
            }
        }

        public R Match<R>(Func<T1, T2, T3, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3);
        }
    }

    /// <summary>
    /// A factory for 4-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product4
    {
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
    }

    /// <summary>
    /// A 4-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product4<T1, T2, T3, T4> : ProductBase, IProduct4<T1, T2, T3, T4>
    {
        public Product4(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
            ProductValue4 = t4;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

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

        public R Match<R>(Func<T1, T2, T3, T4, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3, ProductValue4);
        }
    }

    /// <summary>
    /// A factory for 5-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product5
    {
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
    }

    /// <summary>
    /// A 5-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product5<T1, T2, T3, T4, T5> : ProductBase, IProduct5<T1, T2, T3, T4, T5>
    {
        public Product5(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
            ProductValue4 = t4;
            ProductValue5 = t5;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

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

        public R Match<R>(Func<T1, T2, T3, T4, T5, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5);
        }
    }

    /// <summary>
    /// A factory for 6-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product6
    {
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
    }

    /// <summary>
    /// A 6-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product6<T1, T2, T3, T4, T5, T6> : ProductBase, IProduct6<T1, T2, T3, T4, T5, T6>
    {
        public Product6(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
            ProductValue4 = t4;
            ProductValue5 = t5;
            ProductValue6 = t6;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

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

        public R Match<R>(Func<T1, T2, T3, T4, T5, T6, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6);
        }
    }

    /// <summary>
    /// A factory for 7-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product7
    {
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
    }

    /// <summary>
    /// A 7-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product7<T1, T2, T3, T4, T5, T6, T7> : ProductBase, IProduct7<T1, T2, T3, T4, T5, T6, T7>
    {
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

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

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
    /// A factory for 8-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product8
    {
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
    }

    /// <summary>
    /// A 8-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product8<T1, T2, T3, T4, T5, T6, T7, T8> : ProductBase, IProduct8<T1, T2, T3, T4, T5, T6, T7, T8>
    {
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

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

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
    /// A factory for 9-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product9
    {
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
    }

    /// <summary>
    /// A 9-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product9<T1, T2, T3, T4, T5, T6, T7, T8, T9> : ProductBase, IProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
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

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

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

    /// <summary>
    /// A factory for 10-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product10
    {
        /// <summary>
        /// Creates a new 10-dimensional canonical product.
        /// </summary>
        public static IProduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            return new Product10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        }

        /// <summary>
        /// Creates a new 10-dimensional canonical product.
        /// </summary>
        public static IProduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(IProduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> p)
        {
            if (Equals(p.GetType(), typeof(Product10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10);
        }
    }

    /// <summary>
    /// A 10-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : ProductBase, IProduct10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        public Product10(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
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
            ProductValue10 = t10;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

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
                yield return ProductValue10;
            }
        }
    }

    /// <summary>
    /// A factory for 11-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product11
    {
        /// <summary>
        /// Creates a new 11-dimensional canonical product.
        /// </summary>
        public static IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            return new Product11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        }

        /// <summary>
        /// Creates a new 11-dimensional canonical product.
        /// </summary>
        public static IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> p)
        {
            if (Equals(p.GetType(), typeof(Product11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11);
        }
    }

    /// <summary>
    /// A 11-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : ProductBase, IProduct11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        public Product11(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
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
            ProductValue10 = t10;
            ProductValue11 = t11;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

        public T11 ProductValue11 { get; }

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
                yield return ProductValue10;
                yield return ProductValue11;
            }
        }
    }

    /// <summary>
    /// A factory for 12-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product12
    {
        /// <summary>
        /// Creates a new 12-dimensional canonical product.
        /// </summary>
        public static IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            return new Product12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        }

        /// <summary>
        /// Creates a new 12-dimensional canonical product.
        /// </summary>
        public static IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> p)
        {
            if (Equals(p.GetType(), typeof(Product12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12);
        }
    }

    /// <summary>
    /// A 12-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : ProductBase, IProduct12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        public Product12(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
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
            ProductValue10 = t10;
            ProductValue11 = t11;
            ProductValue12 = t12;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

        public T11 ProductValue11 { get; }

        public T12 ProductValue12 { get; }

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
                yield return ProductValue10;
                yield return ProductValue11;
                yield return ProductValue12;
            }
        }
    }

    /// <summary>
    /// A factory for 13-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product13
    {
        /// <summary>
        /// Creates a new 13-dimensional canonical product.
        /// </summary>
        public static IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            return new Product13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
        }

        /// <summary>
        /// Creates a new 13-dimensional canonical product.
        /// </summary>
        public static IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> p)
        {
            if (Equals(p.GetType(), typeof(Product13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13);
        }
    }

    /// <summary>
    /// A 13-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : ProductBase, IProduct13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        public Product13(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
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
            ProductValue10 = t10;
            ProductValue11 = t11;
            ProductValue12 = t12;
            ProductValue13 = t13;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

        public T11 ProductValue11 { get; }

        public T12 ProductValue12 { get; }

        public T13 ProductValue13 { get; }

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
                yield return ProductValue10;
                yield return ProductValue11;
                yield return ProductValue12;
                yield return ProductValue13;
            }
        }
    }

    /// <summary>
    /// A factory for 14-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product14
    {
        /// <summary>
        /// Creates a new 14-dimensional canonical product.
        /// </summary>
        public static IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            return new Product14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
        }

        /// <summary>
        /// Creates a new 14-dimensional canonical product.
        /// </summary>
        public static IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> p)
        {
            if (Equals(p.GetType(), typeof(Product14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14);
        }
    }

    /// <summary>
    /// A 14-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : ProductBase, IProduct14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        public Product14(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
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
            ProductValue10 = t10;
            ProductValue11 = t11;
            ProductValue12 = t12;
            ProductValue13 = t13;
            ProductValue14 = t14;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

        public T11 ProductValue11 { get; }

        public T12 ProductValue12 { get; }

        public T13 ProductValue13 { get; }

        public T14 ProductValue14 { get; }

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
                yield return ProductValue10;
                yield return ProductValue11;
                yield return ProductValue12;
                yield return ProductValue13;
                yield return ProductValue14;
            }
        }
    }

    /// <summary>
    /// A factory for 15-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product15
    {
        /// <summary>
        /// Creates a new 15-dimensional canonical product.
        /// </summary>
        public static IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            return new Product15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
        }

        /// <summary>
        /// Creates a new 15-dimensional canonical product.
        /// </summary>
        public static IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> p)
        {
            if (Equals(p.GetType(), typeof(Product15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15);
        }
    }

    /// <summary>
    /// A 15-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : ProductBase, IProduct15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        public Product15(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
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
            ProductValue10 = t10;
            ProductValue11 = t11;
            ProductValue12 = t12;
            ProductValue13 = t13;
            ProductValue14 = t14;
            ProductValue15 = t15;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

        public T11 ProductValue11 { get; }

        public T12 ProductValue12 { get; }

        public T13 ProductValue13 { get; }

        public T14 ProductValue14 { get; }

        public T15 ProductValue15 { get; }

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
                yield return ProductValue10;
                yield return ProductValue11;
                yield return ProductValue12;
                yield return ProductValue13;
                yield return ProductValue14;
                yield return ProductValue15;
            }
        }
    }

    /// <summary>
    /// A factory for 16-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product16
    {
        /// <summary>
        /// Creates a new 16-dimensional canonical product.
        /// </summary>
        public static IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            return new Product16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
        }

        /// <summary>
        /// Creates a new 16-dimensional canonical product.
        /// </summary>
        public static IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> p)
        {
            if (Equals(p.GetType(), typeof(Product16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15, p.ProductValue16);
        }
    }

    /// <summary>
    /// A 16-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : ProductBase, IProduct16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        public Product16(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
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
            ProductValue10 = t10;
            ProductValue11 = t11;
            ProductValue12 = t12;
            ProductValue13 = t13;
            ProductValue14 = t14;
            ProductValue15 = t15;
            ProductValue16 = t16;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

        public T11 ProductValue11 { get; }

        public T12 ProductValue12 { get; }

        public T13 ProductValue13 { get; }

        public T14 ProductValue14 { get; }

        public T15 ProductValue15 { get; }

        public T16 ProductValue16 { get; }

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
                yield return ProductValue10;
                yield return ProductValue11;
                yield return ProductValue12;
                yield return ProductValue13;
                yield return ProductValue14;
                yield return ProductValue15;
                yield return ProductValue16;
            }
        }
    }

    /// <summary>
    /// A factory for 17-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product17
    {
        /// <summary>
        /// Creates a new 17-dimensional canonical product.
        /// </summary>
        public static IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17)
        {
            return new Product17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
        }

        /// <summary>
        /// Creates a new 17-dimensional canonical product.
        /// </summary>
        public static IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> p)
        {
            if (Equals(p.GetType(), typeof(Product17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15, p.ProductValue16, p.ProductValue17);
        }
    }

    /// <summary>
    /// A 17-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : ProductBase, IProduct17<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>
    {
        public Product17(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17)
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
            ProductValue10 = t10;
            ProductValue11 = t11;
            ProductValue12 = t12;
            ProductValue13 = t13;
            ProductValue14 = t14;
            ProductValue15 = t15;
            ProductValue16 = t16;
            ProductValue17 = t17;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

        public T11 ProductValue11 { get; }

        public T12 ProductValue12 { get; }

        public T13 ProductValue13 { get; }

        public T14 ProductValue14 { get; }

        public T15 ProductValue15 { get; }

        public T16 ProductValue16 { get; }

        public T17 ProductValue17 { get; }

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
                yield return ProductValue10;
                yield return ProductValue11;
                yield return ProductValue12;
                yield return ProductValue13;
                yield return ProductValue14;
                yield return ProductValue15;
                yield return ProductValue16;
                yield return ProductValue17;
            }
        }
    }

    /// <summary>
    /// A factory for 18-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product18
    {
        /// <summary>
        /// Creates a new 18-dimensional canonical product.
        /// </summary>
        public static IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18)
        {
            return new Product18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
        }

        /// <summary>
        /// Creates a new 18-dimensional canonical product.
        /// </summary>
        public static IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> p)
        {
            if (Equals(p.GetType(), typeof(Product18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15, p.ProductValue16, p.ProductValue17, p.ProductValue18);
        }
    }

    /// <summary>
    /// A 18-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> : ProductBase, IProduct18<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>
    {
        public Product18(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18)
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
            ProductValue10 = t10;
            ProductValue11 = t11;
            ProductValue12 = t12;
            ProductValue13 = t13;
            ProductValue14 = t14;
            ProductValue15 = t15;
            ProductValue16 = t16;
            ProductValue17 = t17;
            ProductValue18 = t18;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

        public T11 ProductValue11 { get; }

        public T12 ProductValue12 { get; }

        public T13 ProductValue13 { get; }

        public T14 ProductValue14 { get; }

        public T15 ProductValue15 { get; }

        public T16 ProductValue16 { get; }

        public T17 ProductValue17 { get; }

        public T18 ProductValue18 { get; }

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
                yield return ProductValue10;
                yield return ProductValue11;
                yield return ProductValue12;
                yield return ProductValue13;
                yield return ProductValue14;
                yield return ProductValue15;
                yield return ProductValue16;
                yield return ProductValue17;
                yield return ProductValue18;
            }
        }
    }

    /// <summary>
    /// A factory for 19-dimensional strongly-typed immutable products.
    /// </summary>
    public static class Product19
    {
        /// <summary>
        /// Creates a new 19-dimensional canonical product.
        /// </summary>
        public static IProduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19)
        {
            return new Product19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
        }

        /// <summary>
        /// Creates a new 19-dimensional canonical product.
        /// </summary>
        public static IProduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(IProduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> p)
        {
            if (Equals(p.GetType(), typeof(Product19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>)))
            {
                return p;
            }

            return Create(p.ProductValue1, p.ProductValue2, p.ProductValue3, p.ProductValue4, p.ProductValue5, p.ProductValue6, p.ProductValue7, p.ProductValue8, p.ProductValue9, p.ProductValue10, p.ProductValue11, p.ProductValue12, p.ProductValue13, p.ProductValue14, p.ProductValue15, p.ProductValue16, p.ProductValue17, p.ProductValue18, p.ProductValue19);
        }
    }

    /// <summary>
    /// A 19-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> : ProductBase, IProduct19<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>
    {
        public Product19(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19)
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
            ProductValue10 = t10;
            ProductValue11 = t11;
            ProductValue12 = t12;
            ProductValue13 = t13;
            ProductValue14 = t14;
            ProductValue15 = t15;
            ProductValue16 = t16;
            ProductValue17 = t17;
            ProductValue18 = t18;
            ProductValue19 = t19;
        }

        public T1 ProductValue1 { get; }

        public T2 ProductValue2 { get; }

        public T3 ProductValue3 { get; }

        public T4 ProductValue4 { get; }

        public T5 ProductValue5 { get; }

        public T6 ProductValue6 { get; }

        public T7 ProductValue7 { get; }

        public T8 ProductValue8 { get; }

        public T9 ProductValue9 { get; }

        public T10 ProductValue10 { get; }

        public T11 ProductValue11 { get; }

        public T12 ProductValue12 { get; }

        public T13 ProductValue13 { get; }

        public T14 ProductValue14 { get; }

        public T15 ProductValue15 { get; }

        public T16 ProductValue16 { get; }

        public T17 ProductValue17 { get; }

        public T18 ProductValue18 { get; }

        public T19 ProductValue19 { get; }

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
                yield return ProductValue10;
                yield return ProductValue11;
                yield return ProductValue12;
                yield return ProductValue13;
                yield return ProductValue14;
                yield return ProductValue15;
                yield return ProductValue16;
                yield return ProductValue17;
                yield return ProductValue18;
                yield return ProductValue19;
            }
        }
    }

}
