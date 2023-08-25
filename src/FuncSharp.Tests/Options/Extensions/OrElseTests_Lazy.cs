using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class OrElseTests_Lazy
    {
        public OrElseTests_Lazy()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void OrElse()
        {
            Assert.Equivalent(1.ToOption(), 1.ToOption().OrElse(_ => 2.ToOption()));
            Assert.Equivalent(2.ToOption(), Option.Empty<int>().OrElse(_ => 2.ToOption()));

            Assert.Equivalent("asd".ToOption(), "asd".ToOption().OrElse(_ => "123".ToOption()));
            Assert.Equivalent("123".ToOption(), Option.Empty<string>().OrElse(_ => "123".ToOption()));

            Assert.Equivalent(new ReferenceType(3).ToOption(), Option.Empty<ReferenceType>().OrElse(_ => new ReferenceType(3).ToOption()));
            Assert.Equivalent(new ReferenceTypeBase(4).ToOption(), Option.Empty<ReferenceType>().OrElse(_ => new ReferenceTypeBase(4).ToOption()));
            Assert.Equivalent(new ReferenceTypeBase(5).ToOption(), Option.Empty<ReferenceTypeBase>().OrElse(_ => new ReferenceTypeBase(5).ToOption()));
        }

        [Property]
        internal void OrElse_int(IOption<int> option)
        {
            AssertOrElse(option, _ => (-14).ToOption());
        }

        [Property]
        internal void OrElse_decimal(IOption<decimal> option)
        {
            AssertOrElse(option, _ => 2156.384m.ToOption());
        }

        [Property]
        internal void OrElse_double(IOption<double> option)
        {
            AssertOrElse(option, _ => 2842.456.ToOption());
        }

        [Property]
        internal void OrElse_bool(IOption<bool> option)
        {
            AssertOrElse(option, _ => true.ToOption());
        }

        [Property]
        internal void OrElse_ReferenceType(IOption<ReferenceType> option)
        {
            AssertOrElse(option, _ => new ReferenceType(7).ToOption());
            AssertOrElse(option, _ => new ReferenceTypeBase(11).ToOption());
        }

        [Property]
        internal void OrElse_ReferenceTypeBase(IOption<ReferenceTypeBase> option)
        {
            AssertOrElse(option, _ => new ReferenceType(13).ToOption());
            AssertOrElse(option, _ => new ReferenceTypeBase(17).ToOption());
        }

        private void AssertOrElse<T>(IOption<T> option, Func<Unit, IOption<T>> otherwise)
        {
            var result = option.OrElse(otherwise);
            if (option.NonEmpty)
            {
                Assert.Equivalent(option, result);
            }
            else
            {
                Assert.Equivalent(otherwise(Unit.Value), result);
            }
        }
    }
}
