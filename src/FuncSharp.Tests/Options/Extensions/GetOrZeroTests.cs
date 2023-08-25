using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetOrZeroTests
    {
        public GetOrZeroTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void GetOrZero()
        {
            Assert.Equal(1, 1.ToOption().GetOrZero());
            Assert.Equal(0, Option.Empty<int>().GetOrZero());
        }

        [Property]
        internal void GetOrZero_short(IOption<short> option)
        {
            Assert.Equal(option.GetOrDefault(), option.GetOrZero());
        }

        [Property]
        internal void GetOrZero_int(IOption<int> option)
        {
            Assert.Equal(option.GetOrDefault(), option.GetOrZero());
        }

        [Property]
        internal void GetOrZero_long(IOption<long> option)
        {
            Assert.Equal(option.GetOrDefault(), option.GetOrZero());
        }

        [Property]
        internal void GetOrZero_decimal(IOption<decimal> option)
        {
            Assert.Equal(option.GetOrDefault(), option.GetOrZero());
        }

        [Property]
        internal void GetOrZero_double(IOption<double> option)
        {
            Assert.Equal(option.GetOrDefault(), option.GetOrZero());
        }
    }
}
