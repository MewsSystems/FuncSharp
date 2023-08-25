using Xunit;

namespace FuncSharp.Tests
{
    public class PositionTests
    {
        [Fact]
        public void ExceptValueExcludesCorrectValue()
        {
            var p = Position3.Create("foo", "bar", "baz");

            var p1 = p.ExceptValue1;
            Assert.Equivalent("bar", p1.ProductValue1);
            Assert.Equivalent("baz", p1.ProductValue2);

            var p2 = p.ExceptValue2;
            Assert.Equivalent("foo", p2.ProductValue1);
            Assert.Equivalent("baz", p2.ProductValue2);
        }
    }
}
