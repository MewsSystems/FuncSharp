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
            Arb.Register<Generators>();
        }

        [Fact]
        public void ToEnumerable()
        {
            Assert.NotEmpty(42.ToOption().ToEnumerable());
            Assert.NotEmpty((42 as int?).ToOption().ToEnumerable());
            Assert.Empty((null as int?).ToOption().ToEnumerable());

            Assert.NotEmpty(new object().ToOption().ToEnumerable());
            Assert.Empty((null as object).ToOption().ToEnumerable());

            Assert.NotEmpty("foo".ToOption().ToEnumerable());
            Assert.Empty((null as string).ToOption().ToEnumerable());
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
            Assert.NotEmpty(Option.Valued(value).ToEnumerable());
            Assert.Empty(Option.Empty<T>().ToEnumerable());
        }
    }
}
