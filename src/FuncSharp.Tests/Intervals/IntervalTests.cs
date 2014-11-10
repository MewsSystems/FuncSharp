using System;
using FuncSharp;
using Xunit;

namespace FuncSharp.Tests.Intervals
{
    public class IntervalTests
    {
        [Fact]
        public void CreationTest()
        {
            Assert.True(Interval.Open(2, 1).IsEmpty);
            Assert.True(Interval.Open(1, 1).IsEmpty);
            Assert.True(Interval.OpenClosed(1, 1).IsEmpty);
            Assert.True(Interval.Closed(2, 1).IsEmpty);
            Assert.True(Interval.Empty<int>().IsEmpty);

            Assert.False(Interval.Single(42).IsEmpty);
            Assert.False(Interval.Open(23, 42).IsEmpty);
            Assert.False(Interval.ClosedOpen(23, 42).IsEmpty);
            Assert.False(Interval.OpenClosed(23, 42).IsEmpty);
            Assert.False(Interval.Closed(23, 42).IsEmpty);
            Assert.False(Interval.LowerOpen(42).IsEmpty);
            Assert.False(Interval.LowerClosed(42).IsEmpty);
            Assert.False(Interval.UpperOpen(42).IsEmpty);
            Assert.False(Interval.UpperClosed(42).IsEmpty);
            Assert.False(Interval.Unbounded<int>().IsEmpty);
        }

        [Fact]
        public void ToStringTest()
        {
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

        [Fact]
        public void ContainsTest()
        {
            Assert.False(Interval.Empty<int>().Contains(-10));
            Assert.False(Interval.Empty<int>().Contains(0));
            Assert.False(Interval.Empty<int>().Contains(10));

            Assert.False(Interval.Single(42).Contains(0));
            Assert.False(Interval.Single(42).Contains(50));
            Assert.True(Interval.Single(42).Contains(42));

            Assert.False(Interval.Open(23, 42).Contains(10));
            Assert.False(Interval.Open(23, 42).Contains(23));
            Assert.False(Interval.Open(23, 42).Contains(42));
            Assert.False(Interval.Open(23, 42).Contains(50));
            Assert.True(Interval.Open(23, 42).Contains(30));

            Assert.False(Interval.ClosedOpen(23, 42).Contains(10));
            Assert.False(Interval.ClosedOpen(23, 42).Contains(42));
            Assert.False(Interval.ClosedOpen(23, 42).Contains(50));
            Assert.True(Interval.ClosedOpen(23, 42).Contains(23));
            Assert.True(Interval.ClosedOpen(23, 42).Contains(30));

            Assert.False(Interval.OpenClosed(23, 42).Contains(10));
            Assert.False(Interval.OpenClosed(23, 42).Contains(23));
            Assert.False(Interval.OpenClosed(23, 42).Contains(50));
            Assert.True(Interval.OpenClosed(23, 42).Contains(30));
            Assert.True(Interval.OpenClosed(23, 42).Contains(42));

            Assert.False(Interval.Closed(23, 42).Contains(10));
            Assert.False(Interval.Closed(23, 42).Contains(50));
            Assert.True(Interval.Closed(23, 42).Contains(23));
            Assert.True(Interval.Closed(23, 42).Contains(30));
            Assert.True(Interval.Closed(23, 42).Contains(42));

            Assert.False(Interval.LowerOpen(42).Contains(10));
            Assert.False(Interval.LowerOpen(42).Contains(42));
            Assert.True(Interval.LowerOpen(42).Contains(50));
            Assert.True(Interval.LowerOpen(42).Contains(Int32.MaxValue));

            Assert.False(Interval.LowerClosed(42).Contains(10));
            Assert.True(Interval.LowerClosed(42).Contains(42));
            Assert.True(Interval.LowerClosed(42).Contains(50));
            Assert.True(Interval.LowerClosed(42).Contains(Int32.MaxValue));

            Assert.False(Interval.UpperOpen(42).Contains(50));
            Assert.False(Interval.UpperOpen(42).Contains(42));
            Assert.True(Interval.UpperOpen(42).Contains(20));
            Assert.True(Interval.UpperOpen(42).Contains(Int32.MinValue));

            Assert.False(Interval.UpperClosed(42).Contains(50));
            Assert.True(Interval.UpperClosed(42).Contains(42));
            Assert.True(Interval.UpperClosed(42).Contains(20));
            Assert.True(Interval.UpperClosed(42).Contains(Int32.MinValue));

            Assert.True(Interval.Unbounded<int>().Contains(-10));
            Assert.True(Interval.Unbounded<int>().Contains(0));
            Assert.True(Interval.Unbounded<int>().Contains(10));
            Assert.True(Interval.Unbounded<int>().Contains(Int32.MinValue));
            Assert.True(Interval.Unbounded<int>().Contains(Int32.MaxValue));
        }

        [Fact]
        public void IntersectTest()
        {
            var e = Interval.Empty<int>();
            var s = Interval.Single(20);
            var o1 = Interval.Open(10, 30);
            var o2 = Interval.Open(20, 40);
            var o3 = Interval.Open(30, 50);
            var c1 = Interval.Closed(10, 30);
            var c2 = Interval.Closed(20, 40);
            var c3 = Interval.Closed(30, 50);
            var u = Interval.Unbounded<int>();

            Assert.Equal(e, e.Intersect(e));
            Assert.Equal(e, e.Intersect(s));
            Assert.Equal(e, e.Intersect(o1));
            Assert.Equal(e, e.Intersect(c1));
            Assert.Equal(e, e.Intersect(u));

            Assert.Equal(s, s.Intersect(s));
            Assert.Equal(s, s.Intersect(o1));
            Assert.Equal(e, e.Intersect(o2));
            Assert.Equal(s, s.Intersect(c1));
            Assert.Equal(s, s.Intersect(c2));
            Assert.Equal(s, s.Intersect(u));

            Assert.Equal(s, o1.Intersect(s));
            Assert.Equal(o1, o1.Intersect(o1));
            Assert.Equal(o1, o1.Intersect(Interval.Open(0, 100)));
            Assert.Equal(o1, o1.Intersect(u));
            Assert.Equal(Interval.Open(20, 30), o1.Intersect(o2));
            Assert.Equal(e, o1.Intersect(o3));
            Assert.Equal(o1, o1.Intersect(c1));
            Assert.Equal(Interval.ClosedOpen(20, 30), o1.Intersect(c2));
            Assert.Equal(e, o1.Intersect(c3));

            Assert.Equal(s, c1.Intersect(s));
            Assert.Equal(c1, c1.Intersect(c1));
            Assert.Equal(c1, c1.Intersect(Interval.Closed(0, 100)));
            Assert.Equal(c1, c1.Intersect(u));
            Assert.Equal(Interval.Closed(20, 30), c1.Intersect(c2));
            Assert.Equal(Interval.Single(30), c1.Intersect(c3));
            Assert.Equal(o1, c1.Intersect(o1));
            Assert.Equal(Interval.OpenClosed(20, 30), c1.Intersect(o2));
            Assert.Equal(e, c1.Intersect(o3));
        }
    }
}
