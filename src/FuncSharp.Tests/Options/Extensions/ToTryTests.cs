using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class ToTryTests
    {
        public ToTryTests()
        {
            Arb.Register<Generators>();
        }

        [Fact]
        public void ToTry()
        {
            var success1 = 42.ToOption().ToTry(_ => "Error");
            Assert.True(success1.IsSuccess);
            Assert.Equal(Option.Valued(42), success1.Success);
            Assert.Equal(Option.Empty<string>(), success1.Error);

            var error1 = Option.Empty<int>().ToTry(_ => "Error");
            Assert.True(error1.IsError);
            Assert.Equal(Option.Empty<int>(), error1.Success);
            Assert.Equal(Option.Valued("Error"), error1.Error);

            var success2 = new ReferenceType(2).ToOption().ToTry(_ => "Error");
            Assert.True(success2.IsSuccess);
            Assert.Equal(Option.Valued(new ReferenceType(2)), success2.Success);
            Assert.Equal(Option.Empty<string>(), success2.Error);

            var error2 = Option.Empty<ReferenceType>().ToTry(_ => "Error 2");
            Assert.True(error2.IsError);
            Assert.Equal(Option.Empty<ReferenceType>(), error2.Success);
            Assert.Equal(Option.Valued("Error 2"), error2.Error);
        }

        [Property]
        internal void FlatMap_int(IOption<int> option)
        {
            AssertToTry(option);
        }

        [Property]
        internal void FlatMap_decimal(IOption<decimal> option)
        {
            AssertToTry(option);
        }

        [Property]
        internal void FlatMap_double(IOption<double> option)
        {
            AssertToTry(option);
        }

        [Property]
        internal void FlatMap_bool(IOption<bool> option)
        {
            AssertToTry(option);
        }

        [Property]
        internal void FlatMap_ReferenceType(IOption<ReferenceType> option)
        {
            AssertToTry(option);
        }

        private void AssertToTry<T>(IOption<T> option)
        {
            const string errorMessage = "Error message";
            var result = option.ToTry(_ => errorMessage);

            Assert.Equal(option.NonEmpty, result.IsSuccess);
            Assert.Equal(option.IsEmpty, result.IsError);
            Assert.Equal(option, result.Success);

            if (option.NonEmpty)
            {
                OptionAssert.IsEmpty(result.Error);
            }
            else
            {
                OptionAssert.NonEmptyWithValue(errorMessage, result.Error);
            }
        }
    }
}
