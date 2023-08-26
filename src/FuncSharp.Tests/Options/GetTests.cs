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
            Arb.Register<OptionGenerators>();
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
        internal void Get_int(Option<int> option)
        {
            AssertGet<int, InvalidOperationException>(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        [Property]
        internal void Get_decimal(Option<decimal> option)
        {
            AssertGet(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        [Property]
        internal void Get_double(Option<double> option)
        {
            AssertGet(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        [Property]
        internal void Get_bool(Option<bool> option)
        {
            AssertGet(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        [Property]
        internal void Get_ReferenceType(Option<ReferenceType> option)
        {
            AssertGet(option);
            AssertGet(option, _ => new OutOfMemoryException());
        }

        private void AssertGet<T>(Option<T> option)
        {
            AssertGet<T, InvalidOperationException>(option);
        }

        private void AssertGet<T, TException>(Option<T> option, Func<Unit, TException> otherwise = null)
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
