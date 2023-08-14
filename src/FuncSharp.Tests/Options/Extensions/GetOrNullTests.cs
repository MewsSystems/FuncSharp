using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetOrNullTests
    {
        public GetOrNullTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void GetOrNull()
        {
            Assert.Equal(new ReferenceType(14), new ReferenceType(14).ToOption().GetOrNull());
            Assert.Null(Option.Valued<ReferenceType>(null).GetOrNull());
            Assert.Null(Option.Empty<ReferenceType>().GetOrNull());
        }

        [Property]
        internal void GetOrNull_bool(IOption<ReferenceType> option)
        {
            AssertGetOrNull(option);
        }

        private void AssertGetOrNull<T>(IOption<T> option)
            where T: class
        {
            var result = option.GetOrNull();
            if (option.NonEmpty)
            {
                Assert.NotNull(result);
                Assert.Equal(option.GetOrDefault(), result);
            }
            else
            {
                Assert.Null(result);
            }
        }
    }
}
