using System;
using FuncSharp.Intervals;
using Xunit;

namespace FuncSharp.Tests.Intervals
{
    public class IntervalTests
    {
        [Fact]
        public void CreationTest()
        {
            Assert.Throws<ArgumentException>(() => Interval.Open(2, 1));
            Assert.Throws<ArgumentException>(() => Interval.ClosedOpen(2, 1));
            Assert.Throws<ArgumentException>(() => Interval.OpenClosed(2, 1));
            Assert.Throws<ArgumentException>(() => Interval.Closed(2, 1));

            Assert.Equal("Ø", Interval.Empty<int>().ToString());
            Assert.Equal("[42, 42]", Interval.Single(42).ToString());
            Assert.Equal("(23, 42)", Interval.Open(23, 42).ToString());
            Assert.Equal("[23, 42)", Interval.ClosedOpen(23, 42).ToString());
            Assert.Equal("(23, 42]", Interval.OpenClosed(23, 42).ToString());
            Assert.Equal("[23, 42]", Interval.Closed(23, 42).ToString());
            Assert.Equal("(42, ∞)", Interval.LowerOpen(42).ToString());
            Assert.Equal("[42, ∞)", Interval.LowerClosed(42).ToString());
            Assert.Equal("(-∞, 42)", Interval.UpperOpen(42).ToString());
            Assert.Equal("(-∞, 42]", Interval.UpperClosed(42).ToString());
            Assert.Equal("(-∞, ∞)", Interval.Unbounded<int>().ToString());
        }

        [Fact]
        public void IsLowerBoundedTest()
        {
            Assert.True(Interval.Empty<int>().IsLowerBounded);
            Assert.True(Interval.Single(42).IsLowerBounded);
            Assert.True(Interval.Open(23, 42).IsLowerBounded);
            Assert.True(Interval.ClosedOpen(23, 42).IsLowerBounded);
            Assert.True(Interval.OpenClosed(23, 42).IsLowerBounded);
            Assert.True(Interval.Closed(23, 42).IsLowerBounded);
            Assert.True(Interval.LowerOpen(42).IsLowerBounded);
            Assert.True(Interval.LowerClosed(42).IsLowerBounded);
            Assert.False(Interval.UpperOpen(42).IsLowerBounded);
            Assert.False(Interval.UpperClosed(42).IsLowerBounded);
            Assert.False(Interval.Unbounded<int>().IsLowerBounded);
        }

        [Fact]
        public void IsUpperBoundedTest()
        {
            Assert.True(Interval.Empty<int>().IsUpperBounded);
            Assert.True(Interval.Single(42).IsUpperBounded);
            Assert.True(Interval.Open(23, 42).IsUpperBounded);
            Assert.True(Interval.ClosedOpen(23, 42).IsUpperBounded);
            Assert.True(Interval.OpenClosed(23, 42).IsUpperBounded);
            Assert.True(Interval.Closed(23, 42).IsUpperBounded);
            Assert.False(Interval.LowerOpen(42).IsUpperBounded);
            Assert.False(Interval.LowerClosed(42).IsUpperBounded);
            Assert.True(Interval.UpperOpen(42).IsUpperBounded);
            Assert.True(Interval.UpperClosed(42).IsUpperBounded);
            Assert.False(Interval.Unbounded<int>().IsUpperBounded);
        }

        [Fact]
        public void IsBoundedTest()
        {
            Assert.True(Interval.Empty<int>().IsBounded);
            Assert.True(Interval.Single(42).IsBounded);
            Assert.True(Interval.Open(23, 42).IsBounded);
            Assert.True(Interval.ClosedOpen(23, 42).IsBounded);
            Assert.True(Interval.OpenClosed(23, 42).IsBounded);
            Assert.True(Interval.Closed(23, 42).IsBounded);
            Assert.False(Interval.LowerOpen(42).IsBounded);
            Assert.False(Interval.LowerClosed(42).IsBounded);
            Assert.False(Interval.UpperOpen(42).IsBounded);
            Assert.False(Interval.UpperClosed(42).IsBounded);
            Assert.False(Interval.Unbounded<int>().IsBounded);
        }

        [Fact]
        public void IsUnboundedTest()
        {
            Assert.False(Interval.Empty<int>().IsUnbounded);
            Assert.False(Interval.Single(42).IsUnbounded);
            Assert.False(Interval.Open(23, 42).IsUnbounded);
            Assert.False(Interval.ClosedOpen(23, 42).IsUnbounded);
            Assert.False(Interval.OpenClosed(23, 42).IsUnbounded);
            Assert.False(Interval.Closed(23, 42).IsUnbounded);
            Assert.True(Interval.LowerOpen(42).IsUnbounded);
            Assert.True(Interval.LowerClosed(42).IsUnbounded);
            Assert.True(Interval.UpperOpen(42).IsUnbounded);
            Assert.True(Interval.UpperClosed(42).IsUnbounded);
            Assert.True(Interval.Unbounded<int>().IsUnbounded);
        }
    }
}
