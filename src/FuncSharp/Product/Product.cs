using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuncSharp
{
    /// <summary>
    /// A type that is a compound of other types. Can be understood as a cartesian product of types, e.g. T1 × T2 × T3.
    /// Therefore instances of a product type consist of values of the compound types, e.g. T1 value1, T2 value2 and T3 value3.
    /// This interface represents the most abstract definition of a product type with unknown compound types and unknown arity.
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Values of the product.
        /// </summary>
        public abstract IEnumerable<object> ProductValues { get; }

        private int? HashCode { get; set; }

        public override int GetHashCode()
        {
            return HashCode ?? (HashCode = ProductHashCode()).Value;
        }

        public override bool Equals(object obj)
        {
            return ProductEquals(obj);
        }

        public override string ToString()
        {
            var b = new StringBuilder(GetType().SimpleName() + "(");

            var prefix = "";
            foreach (var value in ProductValues)
            {
                b.Append(prefix);
                b.Append(value.SafeToString());
                prefix = ", ";
            }

            b.Append(")");
            return b.ToString();
        }

        protected abstract int ProductHashCode();

        protected abstract bool ProductEquals(object obj);
    }

    /// <summary>
    /// A 0-dimensional strongly-typed immutable product.
    /// </summary>
    public class Product0 : Product
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
        public static Product0 Create()
        {
            return new Product0();
        }

        /// <summary>
        /// Creates a new 0-dimensional canonical product.
        /// </summary>
        public static Product0 Create(Product0 p)
        {
            if (Equals(p.GetType(), typeof(Product0)))
            {
                return p;
            }

            return Create();
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        public R Match<R>(Func<R> f)
        {
            return f();
        }

        protected override int ProductHashCode()
        {
            return ValueTuple.Create().GetHashCode();
        }

        protected override bool ProductEquals(object obj)
        {
            return
                obj is Product0 p &&
                Equals(GetType(), p.GetType());
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
        public static Product1<T1> Create<T1>(T1 t1)
        {
            return new Product1<T1>(t1);
        }

        /// <summary>
        /// Creates a new 1-dimensional canonical product.
        /// </summary>
        public static Product1<T1> Create<T1>(Product1<T1> p)
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
    public class Product1<T1> : Product
    {
        public Product1(T1 t1)
        {
            ProductValue1 = t1;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; }

        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
            }
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        public R Match<R>(Func<T1, R> f)
        {
            return f(ProductValue1);
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters.
        /// </summary>
        public void Match(Action<T1> f)
        {
            f(ProductValue1);
        }

        protected override int ProductHashCode()
        {
            return ValueTuple.Create(ProductValue1).GetHashCode();
        }

        protected override bool ProductEquals(object obj)
        {
            return
                obj is Product1<T1> p &&
                Equals(ProductValue1, p.ProductValue1) &&
                Equals(GetType(), p.GetType());
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
        public static Product2<T1, T2> Create<T1, T2>(T1 t1, T2 t2)
        {
            return new Product2<T1, T2>(t1, t2);
        }

        /// <summary>
        /// Creates a new 2-dimensional canonical product.
        /// </summary>
        public static Product2<T1, T2> Create<T1, T2>(Product2<T1, T2> p)
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
    public class Product2<T1, T2> : Product
    {
        public Product2(T1 t1, T2 t2)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; }

        public override IEnumerable<object> ProductValues
        {
            get
            {
                yield return ProductValue1;
                yield return ProductValue2;
            }
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        public R Match<R>(Func<T1, T2, R> f)
        {
            return f(ProductValue1, ProductValue2);
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters.
        /// </summary>
        public void Match(Action<T1, T2> f)
        {
            f(ProductValue1, ProductValue2);
        }

        protected override int ProductHashCode()
        {
            return ValueTuple.Create(ProductValue1, ProductValue2).GetHashCode();
        }

        protected override bool ProductEquals(object obj)
        {
            return
                obj is Product2<T1, T2> p &&
                Equals(ProductValue1, p.ProductValue1) &&
                Equals(ProductValue2, p.ProductValue2) &&
                Equals(GetType(), p.GetType());
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
        public static Product3<T1, T2, T3> Create<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            return new Product3<T1, T2, T3>(t1, t2, t3);
        }

        /// <summary>
        /// Creates a new 3-dimensional canonical product.
        /// </summary>
        public static Product3<T1, T2, T3> Create<T1, T2, T3>(Product3<T1, T2, T3> p)
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
    public class Product3<T1, T2, T3> : Product
    {
        public Product3(T1 t1, T2 t2, T3 t3)
        {
            ProductValue1 = t1;
            ProductValue2 = t2;
            ProductValue3 = t3;
        }

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
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

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        public R Match<R>(Func<T1, T2, T3, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3);
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters.
        /// </summary>
        public void Match(Action<T1, T2, T3> f)
        {
            f(ProductValue1, ProductValue2, ProductValue3);
        }

        protected override int ProductHashCode()
        {
            return ValueTuple.Create(ProductValue1, ProductValue2, ProductValue3).GetHashCode();
        }

        protected override bool ProductEquals(object obj)
        {
            return
                obj is Product3<T1, T2, T3> p &&
                Equals(ProductValue1, p.ProductValue1) &&
                Equals(ProductValue2, p.ProductValue2) &&
                Equals(ProductValue3, p.ProductValue3) &&
                Equals(GetType(), p.GetType());
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
        public static Product4<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return new Product4<T1, T2, T3, T4>(t1, t2, t3, t4);
        }

        /// <summary>
        /// Creates a new 4-dimensional canonical product.
        /// </summary>
        public static Product4<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Product4<T1, T2, T3, T4> p)
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
    public class Product4<T1, T2, T3, T4> : Product
    {
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
        public T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
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

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        public R Match<R>(Func<T1, T2, T3, T4, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3, ProductValue4);
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters.
        /// </summary>
        public void Match(Action<T1, T2, T3, T4> f)
        {
            f(ProductValue1, ProductValue2, ProductValue3, ProductValue4);
        }

        protected override int ProductHashCode()
        {
            return ValueTuple.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4).GetHashCode();
        }

        protected override bool ProductEquals(object obj)
        {
            return
                obj is Product4<T1, T2, T3, T4> p &&
                Equals(ProductValue1, p.ProductValue1) &&
                Equals(ProductValue2, p.ProductValue2) &&
                Equals(ProductValue3, p.ProductValue3) &&
                Equals(ProductValue4, p.ProductValue4) &&
                Equals(GetType(), p.GetType());
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
        public static Product5<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return new Product5<T1, T2, T3, T4, T5>(t1, t2, t3, t4, t5);
        }

        /// <summary>
        /// Creates a new 5-dimensional canonical product.
        /// </summary>
        public static Product5<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(Product5<T1, T2, T3, T4, T5> p)
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
    public class Product5<T1, T2, T3, T4, T5> : Product
    {
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
        public T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
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

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        public R Match<R>(Func<T1, T2, T3, T4, T5, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5);
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters.
        /// </summary>
        public void Match(Action<T1, T2, T3, T4, T5> f)
        {
            f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5);
        }

        protected override int ProductHashCode()
        {
            return ValueTuple.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5).GetHashCode();
        }

        protected override bool ProductEquals(object obj)
        {
            return
                obj is Product5<T1, T2, T3, T4, T5> p &&
                Equals(ProductValue1, p.ProductValue1) &&
                Equals(ProductValue2, p.ProductValue2) &&
                Equals(ProductValue3, p.ProductValue3) &&
                Equals(ProductValue4, p.ProductValue4) &&
                Equals(ProductValue5, p.ProductValue5) &&
                Equals(GetType(), p.GetType());
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
        public static Product6<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return new Product6<T1, T2, T3, T4, T5, T6>(t1, t2, t3, t4, t5, t6);
        }

        /// <summary>
        /// Creates a new 6-dimensional canonical product.
        /// </summary>
        public static Product6<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(Product6<T1, T2, T3, T4, T5, T6> p)
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
    public class Product6<T1, T2, T3, T4, T5, T6> : Product
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

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 ProductValue5 { get; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
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

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        public R Match<R>(Func<T1, T2, T3, T4, T5, T6, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6);
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters.
        /// </summary>
        public void Match(Action<T1, T2, T3, T4, T5, T6> f)
        {
            f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6);
        }

        protected override int ProductHashCode()
        {
            return ValueTuple.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6).GetHashCode();
        }

        protected override bool ProductEquals(object obj)
        {
            return
                obj is Product6<T1, T2, T3, T4, T5, T6> p &&
                Equals(ProductValue1, p.ProductValue1) &&
                Equals(ProductValue2, p.ProductValue2) &&
                Equals(ProductValue3, p.ProductValue3) &&
                Equals(ProductValue4, p.ProductValue4) &&
                Equals(ProductValue5, p.ProductValue5) &&
                Equals(ProductValue6, p.ProductValue6) &&
                Equals(GetType(), p.GetType());
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
        public static Product7<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            return new Product7<T1, T2, T3, T4, T5, T6, T7>(t1, t2, t3, t4, t5, t6, t7);
        }

        /// <summary>
        /// Creates a new 7-dimensional canonical product.
        /// </summary>
        public static Product7<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(Product7<T1, T2, T3, T4, T5, T6, T7> p)
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
    public class Product7<T1, T2, T3, T4, T5, T6, T7> : Product
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

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 ProductValue5 { get; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 ProductValue6 { get; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
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

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        public R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7);
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters.
        /// </summary>
        public void Match(Action<T1, T2, T3, T4, T5, T6, T7> f)
        {
            f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7);
        }

        protected override int ProductHashCode()
        {
            return ValueTuple.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7).GetHashCode();
        }

        protected override bool ProductEquals(object obj)
        {
            return
                obj is Product7<T1, T2, T3, T4, T5, T6, T7> p &&
                Equals(ProductValue1, p.ProductValue1) &&
                Equals(ProductValue2, p.ProductValue2) &&
                Equals(ProductValue3, p.ProductValue3) &&
                Equals(ProductValue4, p.ProductValue4) &&
                Equals(ProductValue5, p.ProductValue5) &&
                Equals(ProductValue6, p.ProductValue6) &&
                Equals(ProductValue7, p.ProductValue7) &&
                Equals(GetType(), p.GetType());
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
        public static Product8<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            return new Product8<T1, T2, T3, T4, T5, T6, T7, T8>(t1, t2, t3, t4, t5, t6, t7, t8);
        }

        /// <summary>
        /// Creates a new 8-dimensional canonical product.
        /// </summary>
        public static Product8<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(Product8<T1, T2, T3, T4, T5, T6, T7, T8> p)
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
    public class Product8<T1, T2, T3, T4, T5, T6, T7, T8> : Product
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

        /// <summary>
        /// Value of the product in the dimension 1.
        /// </summary>
        public T1 ProductValue1 { get; }

        /// <summary>
        /// Value of the product in the dimension 2.
        /// </summary>
        public T2 ProductValue2 { get; }

        /// <summary>
        /// Value of the product in the dimension 3.
        /// </summary>
        public T3 ProductValue3 { get; }

        /// <summary>
        /// Value of the product in the dimension 4.
        /// </summary>
        public T4 ProductValue4 { get; }

        /// <summary>
        /// Value of the product in the dimension 5.
        /// </summary>
        public T5 ProductValue5 { get; }

        /// <summary>
        /// Value of the product in the dimension 6.
        /// </summary>
        public T6 ProductValue6 { get; }

        /// <summary>
        /// Value of the product in the dimension 7.
        /// </summary>
        public T7 ProductValue7 { get; }

        /// <summary>
        /// Value of the product in the dimension 8.
        /// </summary>
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

        /// <summary>
        /// Invokes the specified function with the product values as its parameters and returns its result.
        /// </summary>
        public R Match<R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, R> f)
        {
            return f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8);
        }

        /// <summary>
        /// Invokes the specified function with the product values as its parameters.
        /// </summary>
        public void Match(Action<T1, T2, T3, T4, T5, T6, T7, T8> f)
        {
            f(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8);
        }

        protected override int ProductHashCode()
        {
            return ValueTuple.Create(ProductValue1, ProductValue2, ProductValue3, ProductValue4, ProductValue5, ProductValue6, ProductValue7, ProductValue8).GetHashCode();
        }

        protected override bool ProductEquals(object obj)
        {
            return
                obj is Product8<T1, T2, T3, T4, T5, T6, T7, T8> p &&
                Equals(ProductValue1, p.ProductValue1) &&
                Equals(ProductValue2, p.ProductValue2) &&
                Equals(ProductValue3, p.ProductValue3) &&
                Equals(ProductValue4, p.ProductValue4) &&
                Equals(ProductValue5, p.ProductValue5) &&
                Equals(ProductValue6, p.ProductValue6) &&
                Equals(ProductValue7, p.ProductValue7) &&
                Equals(ProductValue8, p.ProductValue8) &&
                Equals(GetType(), p.GetType());
        }
    }

}
