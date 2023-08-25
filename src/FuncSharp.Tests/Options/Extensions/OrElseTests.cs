using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class OrElseTests
    {
        public OrElseTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void OrElse()
        {
            Assert.Equivalent(1.ToOption(), 1.ToOption().OrElse(2.ToOption()));
            Assert.Equivalent(2.ToOption(), Option.Empty<int>().OrElse(2.ToOption()));

            Assert.Equivalent("asd".ToOption(), "asd".ToOption().OrElse("123".ToOption()));
            Assert.Equivalent("123".ToOption(), Option.Empty<string>().OrElse("123".ToOption()));

            Assert.Equivalent(new ReferenceType(3).ToOption(), Option.Empty<ReferenceType>().OrElse(new ReferenceType(3).ToOption()));
            Assert.Equivalent(new ReferenceTypeBase(4).ToOption(), Option.Empty<ReferenceType>().OrElse(new ReferenceTypeBase(4).ToOption()));
            Assert.Equivalent(new ReferenceTypeBase(5).ToOption(), Option.Empty<ReferenceTypeBase>().OrElse(new ReferenceTypeBase(5).ToOption()));
        }

        [Property]
        internal void OrElse_int(IOption<int> option)
        {
            AssertOrElse(option, (-14).ToOption());
        }

        [Property]
        internal void OrElse_decimal(IOption<decimal> option)
        {
            AssertOrElse(option, 2156.384m.ToOption());
        }

        [Property]
        internal void OrElse_double(IOption<double> option)
        {
            AssertOrElse(option, 2842.456.ToOption());
        }

        [Property]
        internal void OrElse_bool(IOption<bool> option)
        {
            AssertOrElse(option, true.ToOption());
        }

        [Property]
        internal void OrElse_ReferenceType(IOption<ReferenceType> option)
        {
            AssertOrElse(option, new ReferenceType(7).ToOption());
            AssertOrElse(option, new ReferenceTypeBase(11).ToOption());
        }

        [Property]
        internal void OrElse_ReferenceTypeBase(IOption<ReferenceTypeBase> option)
        {
            AssertOrElse(option, new ReferenceType(13).ToOption());
            AssertOrElse(option, new ReferenceTypeBase(17).ToOption());
        }

        private void AssertOrElse<T>(IOption<T> option, IOption<T> otherwise)
        {
            var result = option.OrElse(otherwise);
            if (option.NonEmpty)
            {
                Assert.Equivalent(option, result);
            }
            else
            {
                Assert.Equivalent(otherwise, result);
            }
        }
    }
}
