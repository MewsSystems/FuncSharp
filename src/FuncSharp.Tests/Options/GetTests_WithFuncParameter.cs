using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetTests_WithFuncParameter
    {
        public GetTests_WithFuncParameter()
        {
            Arb.Register<Generators>();
        }

        [Fact]
        public void GetWithFunc()
        {
            Assert.Equal(8, 4.ToOption().Get(i => i * 2));
            Assert.Equal(18, (6 as int?).ToOption().Get(i => i * 3));
            Assert.Throws<InvalidOperationException>(() => Option.Empty<int>().Get(i => i * 4));
            Assert.Throws<NullReferenceException>(() => Option.Empty<int>().Get(i => i * 4, _ => new NullReferenceException()));
        }

        [Property]
        internal void GetWithFunc_int(IOption<int> option)
        {
            AssertGetWithFunc(option, i => i * 2);
            AssertGetWithFunc(option, i => i * 2, _ => new OutOfMemoryException());
            AssertGetWithFunc(option, i => new ReferenceType(i * 2));
            AssertGetWithFunc(option, i => new ReferenceType(i * 2), _ => new OutOfMemoryException());
        }

        [Property]
        internal void GetWithFunc_decimal(IOption<decimal> option)
        {
            AssertGetWithFunc(option, i => i * 2);
            AssertGetWithFunc(option, i => i * 2, _ => new OutOfMemoryException());
        }

        [Property]
        internal void GetWithFunc_double(IOption<double> option)
        {
            AssertGetWithFunc(option, i => i * 2);
            AssertGetWithFunc(option, i => i * 2, _ => new OutOfMemoryException());
        }

        [Property]
        internal void GetWithFunc_bool(IOption<bool> option)
        {
            AssertGetWithFunc(option, b => !b);
            AssertGetWithFunc(option, b => !b, _ => new OutOfMemoryException());
        }

        [Property]
        internal void GetWithFunc_ReferenceType(IOption<ReferenceType> option)
        {
            AssertGetWithFunc(option, d => new ReferenceType(d.Value * 2));
            AssertGetWithFunc(option, d => new ReferenceType(d.Value * 2), _ => new OutOfMemoryException());
        }

       private void AssertGetWithFunc<T, TResult>(IOption<T> option, Func<T, TResult> map)
        {
            AssertGetWithFunc<T, TResult, InvalidOperationException>(option, map);
        }

        private void AssertGetWithFunc<T, TResult, TException>(IOption<T> option, Func<T, TResult> map, Func<Unit, TException> otherwise = null)
            where TException : Exception
        {
            if(option.NonEmpty)
            {
                var result = option.Get(map, otherwise);
                Assert.NotNull(result);
                Assert.Equal(map(option.GetOrDefault()), result);
            }
            else
            {
                Assert.Throws<TException>(() => option.Get(map, otherwise));
            }
        }
    }
}
