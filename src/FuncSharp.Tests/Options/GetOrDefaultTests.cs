using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetOrDefaultTests
    {
        public GetOrDefaultTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void GetOrDefault()
        {
            Assert.Equivalent("asd", Option.Create("asd").GetOrDefault());
            Assert.Equivalent(42, 42.ToOption().GetOrDefault());

            Assert.Equivalent(0, Option.Empty<int>().GetOrDefault());
            Assert.Null(Option.Empty<int?>().GetOrDefault());
            Assert.Null(Option.Empty<string>().GetOrDefault());
        }

        [Property]
        internal void GetOrDefault_int(int i)
        {
            AssertGetOrDefault(i);
        }

        [Property]
        internal void GetOrDefault_decimal(decimal option)
        {
            AssertGetOrDefault(option);
        }

        [Property]
        internal void GetOrDefault_double(double option)
        {
            AssertGetOrDefault(option);
        }

        [Property]
        internal void GetOrDefault_bool(bool option)
        {
            AssertGetOrDefault(option);
        }

        [Property]
        internal void GetOrDefault_ReferenceType(ReferenceType option)
        {
            AssertGetOrDefault(option);
        }

        private void AssertGetOrDefault<T>(T value)
        {
            var option = Option.Valued(value);
            Assert.Equivalent(value, option.GetOrDefault());

            Assert.Equivalent(default(T), Option.Empty<T>().GetOrDefault());
        }
    }
}
