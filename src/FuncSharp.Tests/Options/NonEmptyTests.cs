using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class NonEmptyTests
    {
        public NonEmptyTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void NonEmpty()
        {
            Assert.True(42.ToOption().NonEmpty);
            Assert.True((42 as int?).ToOption().NonEmpty);
            Assert.False((null as int?).ToOption().NonEmpty);

            Assert.True(new object().ToOption().NonEmpty);
            Assert.False((null as object).ToOption().NonEmpty);

            Assert.True("foo".ToOption().NonEmpty);
            Assert.False((null as string).ToOption().NonEmpty);
        }

        [Property]
        internal void GetOrDefault_int(int i)
        {
            AssertNonEmpty(i);
        }

        [Property]
        internal void GetOrDefault_decimal(decimal option)
        {
            AssertNonEmpty(option);
        }

        [Property]
        internal void GetOrDefault_double(double option)
        {
            AssertNonEmpty(option);
        }

        [Property]
        internal void GetOrDefault_bool(bool option)
        {
            AssertNonEmpty(option);
        }

        [Property]
        internal void GetOrDefault_ReferenceType(ReferenceType option)
        {
            AssertNonEmpty(option);
        }

        private void AssertNonEmpty<T>(T value)
        {
            Assert.True(Option.Valued(value).NonEmpty);
            Assert.False(Option.Empty<T>().NonEmpty);
        }
    }
}
