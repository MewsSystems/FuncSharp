using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class OptionValuedTests
    {
        public OptionValuedTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void Valued()
        {
            OptionAssert.NonEmptyWithValue(3, Option.Valued(3));
            OptionAssert.NonEmptyWithValue(0, Option.Valued(0));
            OptionAssert.NonEmptyWithValue(2, Option.Valued<int?>(2));
            OptionAssert.NonEmptyWithValue(null, Option.Valued<int?>(null));
            OptionAssert.NonEmptyWithValue(new ReferenceType(14), Option.Valued(new ReferenceType(14)));
            OptionAssert.NonEmptyWithValue(null, Option.Valued<ReferenceType>(null));
            OptionAssert.NonEmptyWithValue(Unit.Value, Option.Valued(Unit.Value));
            OptionAssert.NonEmptyWithValue(null, Option.Valued<Unit>(null));
        }

        [Property]
        internal void ToOption_int(int i)
        {
            AssertValued(i);
        }

        [Property]
        internal void ToOption_nullableint(int? i)
        {
            AssertValued(i);
        }

        [Property]
        internal void ToOption_decimal(decimal option)
        {
            AssertValued(option);
        }

        [Property]
        internal void ToOption_nullabledecimal(decimal? option)
        {
            AssertValued(option);
        }

        [Property]
        internal void ToOption_double(double option)
        {
            AssertValued(option);
        }

        [Property]
        internal void ToOption_nullabledouble(double? option)
        {
            AssertValued(option);
        }

        [Property]
        internal void ToOption_bool(bool option)
        {
            AssertValued(option);
        }

        [Property]
        internal void ToOption_nullablebool(bool? option)
        {
            AssertValued(option);
        }

        [Property]
        internal void ToOption_ReferenceType(ReferenceType option)
        {
            AssertValued(option);
        }

        private void AssertValued<T>(T value)
        {
            var option = Option.Valued(value);
            Assert.True(option.NonEmpty);
            Assert.Equal(value, option.Get());
        }
    }
}
