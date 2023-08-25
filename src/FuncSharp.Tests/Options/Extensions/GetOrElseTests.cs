using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetOrElseTests
    {
        public GetOrElseTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void GetOrElse()
        {
            Assert.Equivalent(1, 1.ToOption().GetOrElse(2));
            Assert.Equivalent(2, Option.Empty<int>().GetOrElse(2));

            Assert.Equivalent("asd", "asd".ToOption().GetOrElse("123"));
            Assert.Equivalent("123", Option.Empty<string>().GetOrElse("123"));

            Assert.Equivalent(new ReferenceType(3), Option.Empty<ReferenceType>().GetOrElse(new ReferenceType(3)));
            Assert.Equivalent(new ReferenceTypeBase(4), Option.Empty<ReferenceType>().GetOrElse(new ReferenceTypeBase(4)));
            Assert.Equivalent(new ReferenceTypeBase(5), Option.Empty<ReferenceTypeBase>().GetOrElse(new ReferenceTypeBase(5)));
        }

        [Property]
        internal void GetOrElse_int(IOption<int> value)
        {
            AssertGetOrElse(value, -14);
        }

        [Property]
        internal void GetOrElse_decimal(IOption<decimal> value)
        {
            AssertGetOrElse(value, 2156.384m);
        }

        [Property]
        internal void GetOrElse_double(IOption<double> value)
        {
            AssertGetOrElse(value, 2842.456);
        }

        [Property]
        internal void GetOrElse_bool(IOption<bool> value)
        {
            AssertGetOrElse(value, true);
        }

        [Property]
        internal void GetOrElse_ReferenceType(IOption<ReferenceType> option)
        {
            AssertGetOrElse(option, new ReferenceType(7));
            AssertGetOrElse(option, new ReferenceTypeBase(11));
        }

        [Property]
        internal void GetOrElse_ReferenceTypeBase(IOption<ReferenceTypeBase> option)
        {
            AssertGetOrElse(option, new ReferenceType(13));
            AssertGetOrElse(option, new ReferenceTypeBase(17));
        }

        private void AssertGetOrElse<T>(IOption<T> option, T otherwise)
        {
            var result = option.GetOrElse(otherwise);
            if (option.NonEmpty)
            {
                Assert.Equivalent(option.Get(), result);
            }
            else
            {
                Assert.Equivalent(otherwise, result);
            }
        }
    }
}
