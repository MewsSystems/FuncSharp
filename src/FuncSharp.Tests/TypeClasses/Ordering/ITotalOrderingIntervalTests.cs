using Xunit;

namespace FuncSharp.Tests
{
    public class ITotalOrderingIntervalTests
    {
        private static readonly ITotalOrdering<int> to = Integers.Ordering;

        [Fact]
        public void CreationTest()
        {
            Assert.True(to.OpenInterval(2, 1).IsEmpty);
            Assert.True(to.OpenInterval(1, 1).IsEmpty);
            Assert.True(to.OpenClosedInterval(1, 1).IsEmpty);
            Assert.True(to.ClosedInterval(2, 1).IsEmpty);
            Assert.True(to.EmptyInterval().IsEmpty);

            Assert.False(to.SingleValueInterval(42).IsEmpty);
            Assert.False(to.OpenInterval(23, 42).IsEmpty);
            Assert.False(to.ClosedOpenInterval(23, 42).IsEmpty);
            Assert.False(to.OpenClosedInterval(23, 42).IsEmpty);
            Assert.False(to.ClosedInterval(23, 42).IsEmpty);
            Assert.False(to.OpenUnboundedInterval(42).IsEmpty);
            Assert.False(to.ClosedUnboundedInterval(42).IsEmpty);
            Assert.False(to.UnboundedOpenInterval(42).IsEmpty);
            Assert.False(to.UnboundedClosedInterval(42).IsEmpty);
            Assert.False(to.UnboundedInterval().IsEmpty);
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("Ø", to.EmptyInterval().ToString());
            Assert.Equal("[42]", to.SingleValueInterval(42).ToString());
            Assert.Equal("(23, 42)", to.OpenInterval(23, 42).ToString());
            Assert.Equal("[23, 42)", to.ClosedOpenInterval(23, 42).ToString());
            Assert.Equal("(23, 42]", to.OpenClosedInterval(23, 42).ToString());
            Assert.Equal("[23, 42]", to.ClosedInterval(23, 42).ToString());
            Assert.Equal("(42, ∞)", to.OpenUnboundedInterval(42).ToString());
            Assert.Equal("[42, ∞)", to.ClosedUnboundedInterval(42).ToString());
            Assert.Equal("(-∞, 42)", to.UnboundedOpenInterval(42).ToString());
            Assert.Equal("(-∞, 42]", to.UnboundedClosedInterval(42).ToString());
            Assert.Equal("(-∞, ∞)", to.UnboundedInterval().ToString());
        }

        [Fact]
        public void IsLowerBoundedTest()
        {
            Assert.True(to.EmptyInterval().IsLowerBounded);
            Assert.True(to.SingleValueInterval(42).IsLowerBounded);
            Assert.True(to.OpenInterval(23, 42).IsLowerBounded);
            Assert.True(to.ClosedOpenInterval(23, 42).IsLowerBounded);
            Assert.True(to.OpenClosedInterval(23, 42).IsLowerBounded);
            Assert.True(to.ClosedInterval(23, 42).IsLowerBounded);
            Assert.True(to.OpenUnboundedInterval(42).IsLowerBounded);
            Assert.True(to.ClosedUnboundedInterval(42).IsLowerBounded);
            Assert.False(to.UnboundedOpenInterval(42).IsLowerBounded);
            Assert.False(to.UnboundedClosedInterval(42).IsLowerBounded);
            Assert.False(to.UnboundedInterval().IsLowerBounded);
        }

        [Fact]
        public void IsUnboundedBoundedTest()
        {
            Assert.True(to.EmptyInterval().IsUpperBounded);
            Assert.True(to.SingleValueInterval(42).IsUpperBounded);
            Assert.True(to.OpenInterval(23, 42).IsUpperBounded);
            Assert.True(to.ClosedOpenInterval(23, 42).IsUpperBounded);
            Assert.True(to.OpenClosedInterval(23, 42).IsUpperBounded);
            Assert.True(to.ClosedInterval(23, 42).IsUpperBounded);
            Assert.False(to.OpenUnboundedInterval(42).IsUpperBounded);
            Assert.False(to.ClosedUnboundedInterval(42).IsUpperBounded);
            Assert.True(to.UnboundedOpenInterval(42).IsUpperBounded);
            Assert.True(to.UnboundedClosedInterval(42).IsUpperBounded);
            Assert.False(to.UnboundedInterval().IsUpperBounded);
        }

        [Fact]
        public void IsBoundedTest()
        {
            Assert.True(to.EmptyInterval().IsBounded);
            Assert.True(to.SingleValueInterval(42).IsBounded);
            Assert.True(to.OpenInterval(23, 42).IsBounded);
            Assert.True(to.ClosedOpenInterval(23, 42).IsBounded);
            Assert.True(to.OpenClosedInterval(23, 42).IsBounded);
            Assert.True(to.ClosedInterval(23, 42).IsBounded);
            Assert.False(to.OpenUnboundedInterval(42).IsBounded);
            Assert.False(to.ClosedUnboundedInterval(42).IsBounded);
            Assert.False(to.UnboundedOpenInterval(42).IsBounded);
            Assert.False(to.UnboundedClosedInterval(42).IsBounded);
            Assert.False(to.UnboundedInterval().IsBounded);
        }

        [Fact]
        public void IsUnboundedTest()
        {
            Assert.False(to.EmptyInterval().IsUnbounded);
            Assert.False(to.SingleValueInterval(42).IsUnbounded);
            Assert.False(to.OpenInterval(23, 42).IsUnbounded);
            Assert.False(to.ClosedOpenInterval(23, 42).IsUnbounded);
            Assert.False(to.OpenClosedInterval(23, 42).IsUnbounded);
            Assert.False(to.ClosedInterval(23, 42).IsUnbounded);
            Assert.True(to.OpenUnboundedInterval(42).IsUnbounded);
            Assert.True(to.ClosedUnboundedInterval(42).IsUnbounded);
            Assert.True(to.UnboundedOpenInterval(42).IsUnbounded);
            Assert.True(to.UnboundedClosedInterval(42).IsUnbounded);
            Assert.True(to.UnboundedInterval().IsUnbounded);
        }

        [Fact]
        public void IntersectTest()
        {
            var e = to.EmptyInterval();
            var s = to.SingleValueInterval(20);
            var o1 = to.OpenInterval(10, 30);
            var o2 = to.OpenInterval(20, 40);
            var o3 = to.OpenInterval(30, 50);
            var c1 = to.ClosedInterval(10, 30);
            var c2 = to.ClosedInterval(20, 40);
            var c3 = to.ClosedInterval(30, 50);
            var u = to.UnboundedInterval();

            Assert.Equal(e, to.Intersect(e, e));
            Assert.Equal(e, to.Intersect(e, s));
            Assert.Equal(e, to.Intersect(e, o1));
            Assert.Equal(e, to.Intersect(e, c1));
            Assert.Equal(e, to.Intersect(e, u));

            Assert.Equal(s, to.Intersect(s, s));
            Assert.Equal(s, to.Intersect(s, o1));
            Assert.Equal(e, to.Intersect(e, o2));
            Assert.Equal(s, to.Intersect(s, c1));
            Assert.Equal(s, to.Intersect(s, c2));
            Assert.Equal(s, to.Intersect(s, u));

            Assert.Equal(s, to.Intersect(o1, s));
            Assert.Equal(o1, to.Intersect(o1, o1));
            Assert.Equal(o1, to.Intersect(o1, to.OpenInterval(0, 100)));
            Assert.Equal(o1, to.Intersect(o1, u));
            Assert.Equal(to.OpenInterval(20, 30), to.Intersect(o1, o2));
            Assert.Equal(e, to.Intersect(o1, o3));
            Assert.Equal(o1, to.Intersect(o1, c1));
            Assert.Equal(to.ClosedOpenInterval(20, 30), to.Intersect(o1, c2));
            Assert.Equal(e, to.Intersect(o1, c3));

            Assert.Equal(s, to.Intersect(c1, s));
            Assert.Equal(c1, to.Intersect(c1, c1));
            Assert.Equal(c1, to.Intersect(c1, to.ClosedInterval(0, 100)));
            Assert.Equal(c1, to.Intersect(c1, u));
            Assert.Equal(to.ClosedInterval(20, 30), to.Intersect(c1, c2));
            Assert.Equal(to.SingleValueInterval(30), to.Intersect(c1, c3));
            Assert.Equal(o1, to.Intersect(c1, o1));
            Assert.Equal(to.OpenClosedInterval(20, 30), to.Intersect(c1, o2));
            Assert.Equal(e, to.Intersect(c1, o3));
        }
    }
}
