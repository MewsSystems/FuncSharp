using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class OptionCreateTests
    {
        public OptionCreateTests()
        {
            Arb.Register<Generators>();
        }

        [Fact]
        public void Create()
        {
            OptionAssert.NonEmptyWithValue(3, Option.Create(3));
            OptionAssert.NonEmptyWithValue(0, Option.Create(0));
            OptionAssert.NonEmptyWithValue(2, Option.Create<int?>(2));
            OptionAssert.NonEmptyWithValue(new ReferenceType(14), Option.Create(new ReferenceType(14)));
            OptionAssert.NonEmptyWithValue(Unit.Value, Option.Create(Unit.Value));

            OptionAssert.IsEmpty(Option.Create<int?>(null));
            OptionAssert.IsEmpty(Option.Create<ReferenceType>(null));
            OptionAssert.IsEmpty(Option.Create<Unit>(null));
        }

        [Property]
        internal void OptionCreate_int(int i)
        {
            AssertCreate(i);
        }

        [Property]
        internal void OptionCreate_nullableint(int? i)
        {
            AssertCreate(i);
        }

        [Property]
        internal void OptionCreate_decimal(decimal option)
        {
            AssertCreate(option);
        }

        [Property]
        internal void OptionCreate_nullabledecimal(decimal? option)
        {
            AssertCreate(option);
        }

        [Property]
        internal void OptionCreate_double(double option)
        {
            AssertCreate(option);
        }

        [Property]
        internal void OptionCreate_nullabledouble(double? option)
        {
            AssertCreate(option);
        }

        [Property]
        internal void OptionCreate_bool(bool option)
        {
            AssertCreate(option);
        }

        [Property]
        internal void OptionCreate_nullablebool(bool? option)
        {
            AssertCreate(option);
        }

        [Property]
        internal void OptionCreate_ReferenceType(ReferenceType option)
        {
            AssertCreate(option);
        }

        private void AssertCreate<T>(T value)
        {
            var option = Option.Create(value);
            Assert.Equal(value is null, option.IsEmpty);

            if (value is not null)
            {
                Assert.Equal(value, option.Get());
            }
        }
    }
}
