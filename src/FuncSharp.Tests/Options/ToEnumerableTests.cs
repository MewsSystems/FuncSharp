using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class ToEnumerableTests
    {
        public ToEnumerableTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void ToEnumerable()
        {
            Assert.NotEmpty(42.ToOption().ToList());
            Assert.NotEmpty((42 as int?).ToOption().ToList());
            Assert.Empty((null as int?).ToOption().ToList());

            Assert.NotEmpty(new object().ToOption().ToList());
            Assert.Empty((null as object).ToOption().ToList());

            Assert.NotEmpty("foo".ToOption().ToList());
            Assert.Empty((null as string).ToOption().ToList());
        }

        [Property]
        internal void ToEnumerable_int(int i)
        {
            AssertToEnumerable(i);
        }

        [Property]
        internal void ToEnumerable_decimal(decimal option)
        {
            AssertToEnumerable(option);
        }

        [Property]
        internal void ToEnumerable_double(double option)
        {
            AssertToEnumerable(option);
        }

        [Property]
        internal void ToEnumerable_bool(bool option)
        {
            AssertToEnumerable(option);
        }

        [Property]
        internal void ToEnumerable_ReferenceType(ReferenceType option)
        {
            AssertToEnumerable(option);
        }

        private void AssertToEnumerable<T>(T value)
        {
            Assert.NotEmpty(Option.Valued(value).ToList());
            Assert.Empty(Option.Empty<T>().ToList());
        }
    }
}
