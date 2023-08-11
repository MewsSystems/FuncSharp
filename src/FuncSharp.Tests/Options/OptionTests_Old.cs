using Xunit;

namespace FuncSharp.Tests.Options
{
    /// <summary>
    /// Will be replaced by individual class per method. Each method should be tested with both manual unit tests and generative tests.
    /// </summary>
    public class OptionTests_Old
    {
        [Fact]
        public void Linq()
        {
            var sum =
                from x in 1.ToOption()
                from y in 2.ToOption()
                from z in 3.ToOption()
                select x + y + z;

            Assert.Equal(6.ToOption(), sum);

            var emptySum =
                from x in 1.ToOption()
                from y in Option.Empty<int>()
                select x + y;

            Assert.Equal(Option.Empty<int>(), emptySum);

            var filteredSum =
                from x in 1.ToOption()
                from y in 2.ToOption()
                where x > 100
                select x + y;

            Assert.Equal(Option.Empty<int>(), filteredSum);
        }
    }
}
