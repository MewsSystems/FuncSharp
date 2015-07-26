using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class IEnumerationTests
    {
        [Fact]
        public void ValuesTest()
        {
            Assert.Equal(new int[0], Integers.Enumeration.Values(Integers.Ordering.EmptyInterval()));
            Assert.Equal(new[] { 2 }, Integers.Enumeration.Values(Integers.Ordering.SingleValueInterval(2)));
            Assert.Equal(new[] { 2, }, Integers.Enumeration.Values(Integers.Ordering.OpenInterval(1, 3)));
            Assert.Equal(new[] { 1, 2 }, Integers.Enumeration.Values(Integers.Ordering.ClosedOpenInterval(1, 3)));
            Assert.Equal(new[] { 2, 3 }, Integers.Enumeration.Values(Integers.Ordering.OpenClosedInterval(1, 3)));
            Assert.Equal(new[] { 1, 2, 3 }, Integers.Enumeration.Values(Integers.Ordering.ClosedInterval(1, 3)));

            Assert.Throws<ArgumentException>(() => Integers.Enumeration.Values(Integers.Ordering.OpenUnboundedInterval(42)));
            Assert.Throws<ArgumentException>(() => Integers.Enumeration.Values(Integers.Ordering.ClosedUnboundedInterval(42)));
            Assert.Throws<ArgumentException>(() => Integers.Enumeration.Values(Integers.Ordering.UnboundedOpenInterval(42)));
            Assert.Throws<ArgumentException>(() => Integers.Enumeration.Values(Integers.Ordering.UnboundedClosedInterval(42)));
            Assert.Throws<ArgumentException>(() => Integers.Enumeration.Values(Integers.Ordering.UnboundedInterval()));
        }
    }
}
