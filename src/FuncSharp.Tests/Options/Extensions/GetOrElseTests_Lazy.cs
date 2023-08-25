using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetOrElseTests_Lazy
    {
        public GetOrElseTests_Lazy()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void GetOrElseLazy()
        {
            Assert.Equivalent(1, 1.ToOption().GetOrElse(_ => 2));
            Assert.Equivalent(2, Option.Empty<int>().GetOrElse(_ => 2));

            Assert.Equivalent("asd", "asd".ToOption().GetOrElse(_ => "123"));
            Assert.Equivalent("123", Option.Empty<string>().GetOrElse(_ => "123"));

            Assert.Equivalent(new ReferenceType(3), Option.Empty<ReferenceType>().GetOrElse(_ => new ReferenceType(3)));
            Assert.Equivalent(new ReferenceTypeBase(4), Option.Empty<ReferenceType>().GetOrElse(_ => new ReferenceTypeBase(4)));
            Assert.Equivalent(new ReferenceTypeBase(5), Option.Empty<ReferenceTypeBase>().GetOrElse(_ => new ReferenceTypeBase(5)));
        }

        [Property]
        internal void GetOrElseLazy_int(IOption<int> option)
        {
            AssertGetOrElseLazy(option, _ => -14);
        }

        [Property]
        internal void GetOrElseLazy_decimal(IOption<decimal> option)
        {
            AssertGetOrElseLazy(option, _ => 2156.384m);
        }

        [Property]
        internal void GetOrElseLazy_double(IOption<double> option)
        {
            AssertGetOrElseLazy(option, _ => 2842.456);
        }

        [Property]
        internal void GetOrElseLazy_bool(IOption<bool> option)
        {
            AssertGetOrElseLazy(option, _ => true);
        }

        [Property]
        internal void GetOrElseLazy_ReferenceType(IOption<ReferenceType> option)
        {
            AssertGetOrElseLazy(option, _ => new ReferenceType(7));
            AssertGetOrElseLazy(option, _ => new ReferenceTypeBase(11));
        }

        [Property]
        internal void GetOrElseLazy_ReferenceTypeBase(IOption<ReferenceTypeBase> option)
        {
            AssertGetOrElseLazy(option, _ => new ReferenceType(13));
            AssertGetOrElseLazy(option, _ => new ReferenceTypeBase(17));
        }

        private void AssertGetOrElseLazy<T>(IOption<T> option, Func<Unit, T> otherwise)
        {
            var result = option.GetOrElse(otherwise);
            if (option.NonEmpty)
            {
                Assert.Equivalent(option.Get(), result);
            }
            else
            {
                Assert.Equivalent(otherwise(Unit.Value), result);
            }
        }
    }
}
