using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class TotalOrderingTests
    {
        private static readonly TotalOrdering<int> Ordering = new TotalOrdering<int>((a, b) => a == b, (a, b) => a < b);

        [Fact]
        public void Min()
        {
            Assert.Equal(5, Ordering.Min(new[] { 5 }));
            Assert.Equal(1, Ordering.Min(new[] { 7, 11, 3, 5, 1 }));
            Assert.Throws<InvalidOperationException>(() => Ordering.Min(new int[0]));
        }

        [Fact]
        public void Max()
        {
            Assert.Equal(5, Ordering.Max(new[] { 5 }));
            Assert.Equal(11, Ordering.Max(new[] { 7, 11, 3, 5, 1 }));
            Assert.Throws<InvalidOperationException>(() => Ordering.Max(new int[0]));
        }

        [Fact]
        public void Intervals()
        {
            Assert.Equal("Ø", Ordering.EmptyInterval.ToString());
            Assert.Equal("Ø", Ordering.OpenInterval(2, 1).ToString());
            Assert.Equal("Ø", Ordering.OpenInterval(1, 1).ToString());
            Assert.Equal("Ø", Ordering.OpenClosedInterval(1, 1).ToString());
            Assert.Equal("Ø", Ordering.ClosedInterval(2, 1).ToString());
            Assert.Equal("[42]", Ordering.SingleValueInterval(42).ToString());
            Assert.Equal("(23, 42)", Ordering.OpenInterval(23, 42).ToString());
            Assert.Equal("[23, 42)", Ordering.ClosedOpenInterval(23, 42).ToString());
            Assert.Equal("(23, 42]", Ordering.OpenClosedInterval(23, 42).ToString());
            Assert.Equal("[23, 42]", Ordering.ClosedInterval(23, 42).ToString());
            Assert.Equal("(42, ∞)", Ordering.OpenUnboundedInterval(42).ToString());
            Assert.Equal("[42, ∞)", Ordering.ClosedUnboundedInterval(42).ToString());
            Assert.Equal("(-∞, 42)", Ordering.UnboundedOpenInterval(42).ToString());
            Assert.Equal("(-∞, 42]", Ordering.UnboundedClosedInterval(42).ToString());
            Assert.Equal("(-∞, ∞)", Ordering.UnboundedInterval.ToString());
        }

        [Fact]
        public void IntervalIsBounded()
        {
            Assert.True(Ordering.EmptyInterval.IsBounded);
            Assert.True(Ordering.SingleValueInterval(42).IsBounded);
            Assert.True(Ordering.OpenInterval(23, 42).IsBounded);
            Assert.True(Ordering.ClosedOpenInterval(23, 42).IsBounded);
            Assert.True(Ordering.OpenClosedInterval(23, 42).IsBounded);
            Assert.True(Ordering.ClosedInterval(23, 42).IsBounded);
            Assert.False(Ordering.OpenUnboundedInterval(42).IsBounded);
            Assert.False(Ordering.ClosedUnboundedInterval(42).IsBounded);
            Assert.False(Ordering.UnboundedOpenInterval(42).IsBounded);
            Assert.False(Ordering.UnboundedClosedInterval(42).IsBounded);
            Assert.False(Ordering.UnboundedInterval.IsBounded);
        }

        [Fact]
        public void Intersect()
        {
            var e = Ordering.EmptyInterval;
            var s = Ordering.SingleValueInterval(20);
            var o1 = Ordering.OpenInterval(10, 30);
            var o2 = Ordering.OpenInterval(20, 40);
            var o3 = Ordering.OpenInterval(30, 50);
            var c1 = Ordering.ClosedInterval(10, 30);
            var c2 = Ordering.ClosedInterval(20, 40);
            var c3 = Ordering.ClosedInterval(30, 50);
            var u = Ordering.UnboundedInterval;

            Assert.Equal(e, Ordering.Intersect(e, e));
            Assert.Equal(e, Ordering.Intersect(e, s));
            Assert.Equal(e, Ordering.Intersect(e, o1));
            Assert.Equal(e, Ordering.Intersect(e, c1));
            Assert.Equal(e, Ordering.Intersect(e, u));

            Assert.Equal(s, Ordering.Intersect(s, s));
            Assert.Equal(s, Ordering.Intersect(s, o1));
            Assert.Equal(e, Ordering.Intersect(e, o2));
            Assert.Equal(s, Ordering.Intersect(s, c1));
            Assert.Equal(s, Ordering.Intersect(s, c2));
            Assert.Equal(s, Ordering.Intersect(s, u));

            Assert.Equal(s, Ordering.Intersect(o1, s));
            Assert.Equal(o1, Ordering.Intersect(o1, o1));
            Assert.Equal(o1, Ordering.Intersect(o1, Ordering.OpenInterval(0, 100)));
            Assert.Equal(o1, Ordering.Intersect(o1, u));
            Assert.Equal(Ordering.OpenInterval(20, 30), Ordering.Intersect(o1, o2));
            Assert.Equal(e, Ordering.Intersect(o1, o3));
            Assert.Equal(o1, Ordering.Intersect(o1, c1));
            Assert.Equal(Ordering.ClosedOpenInterval(20, 30), Ordering.Intersect(o1, c2));
            Assert.Equal(e, Ordering.Intersect(o1, c3));

            Assert.Equal(s, Ordering.Intersect(c1, s));
            Assert.Equal(c1, Ordering.Intersect(c1, c1));
            Assert.Equal(c1, Ordering.Intersect(c1, Ordering.ClosedInterval(0, 100)));
            Assert.Equal(c1, Ordering.Intersect(c1, u));
            Assert.Equal(Ordering.ClosedInterval(20, 30), Ordering.Intersect(c1, c2));
            Assert.Equal(Ordering.SingleValueInterval(30), Ordering.Intersect(c1, c3));
            Assert.Equal(o1, Ordering.Intersect(c1, o1));
            Assert.Equal(Ordering.OpenClosedInterval(20, 30), Ordering.Intersect(c1, o2));
            Assert.Equal(e, Ordering.Intersect(c1, o3));
        }
    }
}
