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
            Assert.Equal(1, 1.ToOption().GetOrElse(2));
            Assert.Equal(2, Option.Empty<int>().GetOrElse(2));

            Assert.Equal("asd", "asd".ToOption().GetOrElse("123"));
            Assert.Equal("123", Option.Empty<string>().GetOrElse("123"));

            Assert.Equal(new ReferenceType(3), Option.Empty<ReferenceType>().GetOrElse(new ReferenceType(3)));
            Assert.Equal(new ReferenceTypeBase(4), Option.Empty<ReferenceType>().GetOrElse(new ReferenceTypeBase(4)));
            Assert.Equal(new ReferenceTypeBase(5), Option.Empty<ReferenceTypeBase>().GetOrElse(new ReferenceTypeBase(5)));
        }

        [Property]
        internal void GetOrElse_int(Option<int> value)
        {
            AssertGetOrElse(value, -14);
        }

        [Property]
        internal void GetOrElse_decimal(Option<decimal> value)
        {
            AssertGetOrElse(value, 2156.384m);
        }

        [Property]
        internal void GetOrElse_double(Option<double> value)
        {
            AssertGetOrElse(value, 2842.456);
        }

        [Property]
        internal void GetOrElse_bool(Option<bool> value)
        {
            AssertGetOrElse(value, true);
        }

        [Property]
        internal void GetOrElse_ReferenceType(Option<ReferenceType> option)
        {
            AssertGetOrElse(option, new ReferenceType(7));
        }

        [Property]
        internal void GetOrElse_ReferenceTypeBase(Option<ReferenceTypeBase> option)
        {
            AssertGetOrElse(option, new ReferenceType(13));
            AssertGetOrElse(option, new ReferenceTypeBase(17));
        }

        private void AssertGetOrElse<T>(Option<T> option, T otherwise)
        {
            var result = option.GetOrElse(otherwise);
            if (option.NonEmpty)
            {
                Assert.Equal(option.Get(), result);
            }
            else
            {
                Assert.Equal(otherwise, result);
            }
        }
    }
}
