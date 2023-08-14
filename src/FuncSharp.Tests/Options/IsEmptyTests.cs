using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class IsEmptyTests
    {
        public IsEmptyTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.False(42.ToOption().IsEmpty);
            Assert.False((42 as int?).ToOption().IsEmpty);
            Assert.True((null as int?).ToOption().IsEmpty);

            Assert.False(new object().ToOption().IsEmpty);
            Assert.True((null as object).ToOption().IsEmpty);

            Assert.False("foo".ToOption().IsEmpty);
            Assert.True((null as string).ToOption().IsEmpty);
        }

        [Property]
        internal void GetOrDefault_int(int i)
        {
            AssertIsEmpty(i);
        }

        [Property]
        internal void GetOrDefault_decimal(decimal option)
        {
            AssertIsEmpty(option);
        }

        [Property]
        internal void GetOrDefault_double(double option)
        {
            AssertIsEmpty(option);
        }

        [Property]
        internal void GetOrDefault_bool(bool option)
        {
            AssertIsEmpty(option);
        }

        [Property]
        internal void GetOrDefault_ReferenceType(ReferenceType option)
        {
            AssertIsEmpty(option);
        }

        private void AssertIsEmpty<T>(T value)
        {
            Assert.False(Option.Valued(value).IsEmpty);
            Assert.True(Option.Empty<T>().IsEmpty);
        }
    }
}
