using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class TotalOrderTests
    {
        private static readonly TotalOrder<int> T = new TotalOrder<int>((a, b) => a < b);

        [Fact]
        public void Min()
        {
            Assert.Equal(5, T.Min(new[] { 5 }));
            Assert.Equal(1, T.Min(new[] { 7, 11, 3, 5, 1 }));
            Assert.Throws<InvalidOperationException>(() => T.Min(new int[0]));
        }

        [Fact]
        public void Max()
        {
            Assert.Equal(5, T.Max(new[] { 5 }));
            Assert.Equal(11, T.Max(new[] { 7, 11, 3, 5, 1 }));
            Assert.Throws<InvalidOperationException>(() => T.Max(new int[0]));
        }

        [Fact]
        public void Intervals()
        {
            Assert.Equal("Ø", T.EmptyInterval.ToString());
            Assert.Equal("Ø", T.OpenInterval(2, 1).ToString());
            Assert.Equal("Ø", T.OpenInterval(1, 1).ToString());
            Assert.Equal("Ø", T.OpenClosedInterval(1, 1).ToString());
            Assert.Equal("Ø", T.ClosedInterval(2, 1).ToString());
            Assert.Equal("[42]", T.SingleValueInterval(42).ToString());
            Assert.Equal("(23, 42)", T.OpenInterval(23, 42).ToString());
            Assert.Equal("[23, 42)", T.ClosedOpenInterval(23, 42).ToString());
            Assert.Equal("(23, 42]", T.OpenClosedInterval(23, 42).ToString());
            Assert.Equal("[23, 42]", T.ClosedInterval(23, 42).ToString());
            Assert.Equal("(42, ∞)", T.OpenUnboundedInterval(42).ToString());
            Assert.Equal("[42, ∞)", T.ClosedUnboundedInterval(42).ToString());
            Assert.Equal("(-∞, 42)", T.UnboundedOpenInterval(42).ToString());
            Assert.Equal("(-∞, 42]", T.UnboundedClosedInterval(42).ToString());
            Assert.Equal("(-∞, ∞)", T.UnboundedInterval.ToString());
        }

        [Fact]
        public void IntervalIsBounded()
        {
            Assert.True(T.EmptyInterval.IsBounded);
            Assert.True(T.SingleValueInterval(42).IsBounded);
            Assert.True(T.OpenInterval(23, 42).IsBounded);
            Assert.True(T.ClosedOpenInterval(23, 42).IsBounded);
            Assert.True(T.OpenClosedInterval(23, 42).IsBounded);
            Assert.True(T.ClosedInterval(23, 42).IsBounded);
            Assert.False(T.OpenUnboundedInterval(42).IsBounded);
            Assert.False(T.ClosedUnboundedInterval(42).IsBounded);
            Assert.False(T.UnboundedOpenInterval(42).IsBounded);
            Assert.False(T.UnboundedClosedInterval(42).IsBounded);
            Assert.False(T.UnboundedInterval.IsBounded);
        }

        [Fact]
        public void OrderIntervals()
        {
            var intervals = new[]
            {
                T.EmptyInterval,
                T.SingleValueInterval(2),
                T.OpenInterval(1, 3),
                T.ClosedInterval(1, 3),
                T.ClosedOpenInterval(1, 3),
                T.OpenClosedInterval(1, 3),
                T.OpenInterval(1, 2),
                T.ClosedInterval(1, 2),
                T.ClosedOpenInterval(1, 2),
                T.OpenClosedInterval(1, 2),
                T.OpenInterval(2, 3),
                T.ClosedInterval(2, 3),
                T.ClosedOpenInterval(2, 3),
                T.OpenClosedInterval(2, 3),
                T.OpenUnboundedInterval(1),
                T.ClosedUnboundedInterval(1),
                T.UnboundedOpenInterval(3),
                T.UnboundedClosedInterval(3),
                T.UnboundedInterval
            };

            Assert.Equal(
                "Ø, (-∞, 3), (-∞, 3], (-∞, ∞), [1, 2), [1, 2], [1, 3), [1, 3], [1, ∞), (1, 2), (1, 2], (1, 3), (1, 3], (1, ∞), [2], [2, 3), [2, 3], (2, 3), (2, 3]",
                String.Join(", ", T.Order(intervals, Ordering.Ascending))
            );
            Assert.Equal(
                "(2, 3], (2, 3), [2, 3], [2, 3), [2], (1, ∞), (1, 3], (1, 3), (1, 2], (1, 2), [1, ∞), [1, 3], [1, 3), [1, 2], [1, 2), (-∞, ∞), (-∞, 3], (-∞, 3), Ø",
                String.Join(", ", T.Order(intervals, Ordering.Descending))
            );
        }

        [Fact]
        public void IntersectIntervals()
        {
            var e = T.EmptyInterval;
            var s = T.SingleValueInterval(20);
            var o1 = T.OpenInterval(10, 30);
            var o2 = T.OpenInterval(20, 40);
            var o3 = T.OpenInterval(30, 50);
            var c1 = T.ClosedInterval(10, 30);
            var c2 = T.ClosedInterval(20, 40);
            var c3 = T.ClosedInterval(30, 50);
            var u = T.UnboundedInterval;

            Assert.Equal(e, T.Intersect(e, e));
            Assert.Equal(e, T.Intersect(e, s));
            Assert.Equal(e, T.Intersect(e, o1));
            Assert.Equal(e, T.Intersect(e, c1));
            Assert.Equal(e, T.Intersect(e, u));

            Assert.Equal(s, T.Intersect(s, s));
            Assert.Equal(s, T.Intersect(s, o1));
            Assert.Equal(e, T.Intersect(e, o2));
            Assert.Equal(s, T.Intersect(s, c1));
            Assert.Equal(s, T.Intersect(s, c2));
            Assert.Equal(s, T.Intersect(s, u));

            Assert.Equal(s, T.Intersect(o1, s));
            Assert.Equal(o1, T.Intersect(o1, o1));
            Assert.Equal(o1, T.Intersect(o1, T.OpenInterval(0, 100)));
            Assert.Equal(o1, T.Intersect(o1, u));
            Assert.Equal(T.OpenInterval(20, 30), T.Intersect(o1, o2));
            Assert.Equal(e, T.Intersect(o1, o3));
            Assert.Equal(o1, T.Intersect(o1, c1));
            Assert.Equal(T.ClosedOpenInterval(20, 30), T.Intersect(o1, c2));
            Assert.Equal(e, T.Intersect(o1, c3));

            Assert.Equal(s, T.Intersect(c1, s));
            Assert.Equal(c1, T.Intersect(c1, c1));
            Assert.Equal(c1, T.Intersect(c1, T.ClosedInterval(0, 100)));
            Assert.Equal(c1, T.Intersect(c1, u));
            Assert.Equal(T.ClosedInterval(20, 30), T.Intersect(c1, c2));
            Assert.Equal(T.SingleValueInterval(30), T.Intersect(c1, c3));
            Assert.Equal(o1, T.Intersect(c1, o1));
            Assert.Equal(T.OpenClosedInterval(20, 30), T.Intersect(c1, o2));
            Assert.Equal(e, T.Intersect(c1, o3));
        }

        [Fact]
        public void IntervalSets()
        {
            AssertEqual("{}", T.EmptyIntervalSet);
            AssertEqual("{}", T.IntervalSet(T.EmptyInterval, T.EmptyInterval));
            AssertEqual("{[1]}", T.IntervalSet(T.SingleValueInterval(1)));
            AssertEqual("{[1], [2]}", T.IntervalSet(T.SingleValueInterval(1), T.SingleValueInterval(2)));
            AssertEqual("{[1], [2]}", T.IntervalSet(T.SingleValueInterval(2), T.SingleValueInterval(1)));
            AssertEqual("{[1, 2]}", T.IntervalSet(T.ClosedInterval(1, 2)));
            AssertEqual("{[1, 2]}", T.IntervalSet(T.ClosedInterval(1, 2), T.ClosedInterval(1, 2)));
            AssertEqual("{[1, 2], [3, 4]}", T.IntervalSet(T.ClosedInterval(1, 2), T.ClosedInterval(3, 4)));
            AssertEqual("{[1, 2], [3, 4]}", T.IntervalSet(T.ClosedInterval(3, 4), T.ClosedInterval(1, 2)));
            AssertEqual("{(-∞, 2), (3, ∞)}", T.IntervalSet(T.UnboundedOpenInterval(2), T.OpenUnboundedInterval(3)));
            AssertEqual("{(-∞, 2), (3, ∞)}", T.IntervalSet(T.OpenUnboundedInterval(3), T.UnboundedOpenInterval(2)));
            AssertEqual("{(-∞, ∞)}", T.IntervalSet(T.UnboundedInterval));
        }

        [Fact]
        public void Intersect()
        {
            AssertEqual("{(2, 3]}", T.Intersect(
                T.IntervalSet(T.OpenClosedInterval(1, 3)),
                T.IntervalSet(T.OpenClosedInterval(2, 4))
            ));
            AssertEqual("{(2, 3], [4, 5)}", T.Intersect(
                T.IntervalSet(T.ClosedInterval(1, 3), T.ClosedInterval(4, 6)),
                T.IntervalSet(T.OpenInterval(2, 5))
            ));
            AssertEqual("{(3, 4], [5, 6), (7, 8]}", T.Intersect(
                T.IntervalSet(T.ClosedInterval(1, 4), T.ClosedInterval(5, 8)),
                T.IntervalSet(T.OpenInterval(3, 6), T.OpenInterval(7, 9))
            ));
            AssertEqual("{[0, 2), (3, 6]}", T.Intersect(
                T.IntervalSet(T.UnboundedOpenInterval(2), T.OpenUnboundedInterval(3)),
                T.IntervalSet(T.ClosedInterval(0, 6))
            ));
            AssertEqual("{}", T.Intersect(
                T.IntervalSet(T.UnboundedOpenInterval(2), T.OpenUnboundedInterval(3)),
                T.IntervalSet(T.OpenInterval(2, 3))
            ));
            AssertEqual("{}", T.Intersect(
                T.IntervalSet(T.UnboundedOpenInterval(2), T.OpenUnboundedInterval(3)),
                T.IntervalSet(T.ClosedInterval(2, 3))
            ));
            AssertEqual("{}", T.Intersect(
                T.IntervalSet(T.UnboundedClosedInterval(2), T.ClosedUnboundedInterval(3)),
                T.IntervalSet(T.OpenInterval(2, 3))
            ));
            AssertEqual("{[2], [3]}", T.Intersect(
                T.IntervalSet(T.UnboundedClosedInterval(2), T.ClosedUnboundedInterval(3)),
                T.IntervalSet(T.ClosedInterval(2, 3))
            ));
            AssertEqual("{(-∞, 1], [4, ∞)}", T.Intersect(
                T.IntervalSet(T.UnboundedOpenInterval(2), T.OpenUnboundedInterval(3)),
                T.IntervalSet(T.UnboundedClosedInterval(1), T.ClosedUnboundedInterval(4))
            ));
        }

        [Fact]
        public void Union()
        {
            AssertEqual("{(1, 4]}", T.Union(
                T.IntervalSet(T.OpenClosedInterval(1, 3)),
                T.IntervalSet(T.OpenClosedInterval(2, 4))
            ));
            AssertEqual("{[1, 6]}", T.Union(
                T.IntervalSet(T.ClosedInterval(1, 3), T.ClosedInterval(4, 6)),
                T.IntervalSet(T.OpenInterval(2, 5))
            ));
            AssertEqual("{[1, 9)}", T.Union(
                T.IntervalSet(T.ClosedInterval(1, 4), T.ClosedInterval(5, 8)),
                T.IntervalSet(T.OpenInterval(3, 6), T.OpenInterval(7, 9))
            ));
            AssertEqual("{(-∞, ∞)}", T.Union(
                T.IntervalSet(T.UnboundedOpenInterval(2), T.OpenUnboundedInterval(3)),
                T.IntervalSet(T.ClosedInterval(0, 6))
            ));
            AssertEqual("{(-∞, 2), (2, 3), (3, ∞)}", T.Union(
                T.IntervalSet(T.UnboundedOpenInterval(2), T.OpenUnboundedInterval(3)),
                T.IntervalSet(T.OpenInterval(2, 3))
            ));
            AssertEqual("{(-∞, ∞)}", T.Union(
                T.IntervalSet(T.UnboundedOpenInterval(2), T.OpenUnboundedInterval(3)),
                T.IntervalSet(T.ClosedInterval(2, 3))
            ));
            AssertEqual("{(-∞, ∞)}", T.Union(
                T.IntervalSet(T.UnboundedClosedInterval(2), T.ClosedUnboundedInterval(3)),
                T.IntervalSet(T.OpenInterval(2, 3))
            ));
            AssertEqual("{(-∞, ∞)}", T.Union(
                T.IntervalSet(T.UnboundedClosedInterval(2), T.ClosedUnboundedInterval(3)),
                T.IntervalSet(T.ClosedInterval(2, 3))
            ));
            AssertEqual("{(-∞, 2), (3, ∞)}", T.Union(
                T.IntervalSet(T.UnboundedOpenInterval(2), T.OpenUnboundedInterval(3)),
                T.IntervalSet(T.UnboundedClosedInterval(1), T.ClosedUnboundedInterval(4))
            ));
        }

        private void AssertEqual(string expected, IntervalSet<int> intervalSet)
        {
            Assert.Equal(expected, intervalSet.ToString());
        }
    }
}
