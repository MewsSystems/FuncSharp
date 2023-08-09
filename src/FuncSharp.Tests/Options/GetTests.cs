using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetTests
    {
        public GetTests()
        {
            Arb.Register<Generators>();
        }

        [Fact]
        public void Get()
        {
            Assert.Equal(42, 42.ToOption().Get());
            Assert.Equal(42, (42 as int?).ToOption().Get());
            Assert.Throws<InvalidOperationException>(() => Option.Empty<int>().Get());
            Assert.Throws<NullReferenceException>(() => Option.Empty<int>().Get(otherwise: _ => new NullReferenceException()));
        }

        [Property]
        internal void Get_int(IOption<int> option)
        {
            AssertGet<int, InvalidOperationException>(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        [Property]
        internal void Get_decimal(IOption<decimal> option)
        {
            AssertGet(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        [Property]
        internal void Get_double(IOption<double> option)
        {
            AssertGet(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        [Property]
        internal void Get_bool(IOption<bool> option)
        {
            AssertGet(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        [Property]
        internal void Get_ReferenceType(IOption<ReferenceType> option)
        {
            AssertGet(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        private void AssertGet<T>(IOption<T> option)
        {
            AssertGet<T, InvalidOperationException>(option);
        }

        private void AssertGet<T, TException>(IOption<T> option, Func<Unit, TException> otherwise = null)
            where TException : Exception
        {
            if(option.NonEmpty)
            {
                var result = option.Get(otherwise);
                Assert.NotNull(result);
                Assert.Equal(option.GetOrDefault(), result);
            }
            else
            {
                Assert.Throws<TException>(() => option.Get(otherwise));
            }
        }
    }
}
