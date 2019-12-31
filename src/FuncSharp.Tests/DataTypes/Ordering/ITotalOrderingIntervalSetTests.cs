using Xunit;

namespace FuncSharp.Tests
{
    /*public class ITotalOrderingIntervalSetTests
    {
        private static readonly ITotalOrdering<int> to = Integers.Ordering;

        [Fact]
        public void Creation()
        {
            Assert.Equal("{}", to.EmptyIntervalSet().ToString());
            Assert.Equal("{}", to.IntervalSet(to.EmptyInterval(), to.EmptyInterval()).ToString());
            Assert.Equal("{[1]}", to.IntervalSet(to.SingleValueInterval(1)).ToString());
            Assert.Equal("{[1], [2]}", to.IntervalSet(to.SingleValueInterval(1), to.SingleValueInterval(2)).ToString());
            Assert.Equal("{[1], [2]}", to.IntervalSet(to.SingleValueInterval(2), to.SingleValueInterval(1)).ToString());
            Assert.Equal("{[1, 2]}", to.IntervalSet(to.ClosedInterval(1, 2)).ToString());
            Assert.Equal("{[1, 2]}", to.IntervalSet(to.ClosedInterval(1, 2), to.ClosedInterval(1, 2)).ToString());
            Assert.Equal("{[1, 2], [3, 4]}", to.IntervalSet(to.ClosedInterval(1, 2), to.ClosedInterval(3, 4)).ToString());
            Assert.Equal("{[1, 2], [3, 4]}", to.IntervalSet(to.ClosedInterval(3, 4), to.ClosedInterval(1, 2)).ToString());
            Assert.Equal("{(-∞, 2), (3, ∞)}", to.IntervalSet(to.UnboundedOpenInterval(2), to.OpenUnboundedInterval(3)).ToString());
            Assert.Equal("{(-∞, 2), (3, ∞)}", to.IntervalSet(to.OpenUnboundedInterval(3), to.UnboundedOpenInterval(2)).ToString());
            Assert.Equal("{(-∞, ∞)}", to.IntervalSet(to.UnboundedInterval()).ToString());
        }

        [Fact]
        public void Intersect()
        {
            Assert.Equal("{(2, 3]}", to.Intersect(
                to.IntervalSet(to.OpenClosedInterval(1, 3)),
                to.IntervalSet(to.OpenClosedInterval(2, 4))).ToString());
            Assert.Equal("{(2, 3], [4, 5)}", to.Intersect(
                to.IntervalSet(to.ClosedInterval(1, 3), to.ClosedInterval(4, 6)),
                to.IntervalSet(to.OpenInterval(2, 5))).ToString());
            Assert.Equal("{(3, 4], [5, 6), (7, 8]}", to.Intersect(
                to.IntervalSet(to.ClosedInterval(1, 4), to.ClosedInterval(5, 8)),
                to.IntervalSet(to.OpenInterval(3, 6), to.OpenInterval(7, 9))).ToString());
            Assert.Equal("{[0, 2), (3, 6]}", to.Intersect(
                to.IntervalSet(to.UnboundedOpenInterval(2), to.OpenUnboundedInterval(3)),
                to.IntervalSet(to.ClosedInterval(0, 6))).ToString());
            Assert.Equal("{}", to.Intersect(
                to.IntervalSet(to.UnboundedOpenInterval(2), to.OpenUnboundedInterval(3)),
                to.IntervalSet(to.OpenInterval(2, 3))).ToString());
            Assert.Equal("{}", to.Intersect(
                to.IntervalSet(to.UnboundedOpenInterval(2), to.OpenUnboundedInterval(3)),
                to.IntervalSet(to.ClosedInterval(2, 3))).ToString());
            Assert.Equal("{}", to.Intersect(
                to.IntervalSet(to.UnboundedClosedInterval(2), to.ClosedUnboundedInterval(3)),
                to.IntervalSet(to.OpenInterval(2, 3))).ToString());
            Assert.Equal("{[2], [3]}", to.Intersect(
                to.IntervalSet(to.UnboundedClosedInterval(2), to.ClosedUnboundedInterval(3)),
                to.IntervalSet(to.ClosedInterval(2, 3))).ToString());
            Assert.Equal("{(-∞, 1], [4, ∞)}", to.Intersect(
                to.IntervalSet(to.UnboundedOpenInterval(2), to.OpenUnboundedInterval(3)),
                to.IntervalSet(to.UnboundedClosedInterval(1), to.ClosedUnboundedInterval(4))).ToString());
        }

        [Fact]
        public void Union()
        {
            Assert.Equal("{(1, 4]}", to.Union(
                to.IntervalSet(to.OpenClosedInterval(1, 3)),
                to.IntervalSet(to.OpenClosedInterval(2, 4))).ToString());
            Assert.Equal("{[1, 6]}", to.Union(
                to.IntervalSet(to.ClosedInterval(1, 3), to.ClosedInterval(4, 6)),
                to.IntervalSet(to.OpenInterval(2, 5))).ToString());
            Assert.Equal("{[1, 9)}", to.Union(
                to.IntervalSet(to.ClosedInterval(1, 4), to.ClosedInterval(5, 8)),
                to.IntervalSet(to.OpenInterval(3, 6), to.OpenInterval(7, 9))).ToString());
            Assert.Equal("{(-∞, ∞)}", to.Union(
                to.IntervalSet(to.UnboundedOpenInterval(2), to.OpenUnboundedInterval(3)),
                to.IntervalSet(to.ClosedInterval(0, 6))).ToString());
            Assert.Equal("{(-∞, 2), (2, 3), (3, ∞)}", to.Union(
                to.IntervalSet(to.UnboundedOpenInterval(2), to.OpenUnboundedInterval(3)),
                to.IntervalSet(to.OpenInterval(2, 3))).ToString());
            Assert.Equal("{(-∞, ∞)}", to.Union(
                to.IntervalSet(to.UnboundedOpenInterval(2), to.OpenUnboundedInterval(3)),
                to.IntervalSet(to.ClosedInterval(2, 3))).ToString());
            Assert.Equal("{(-∞, ∞)}", to.Union(
                to.IntervalSet(to.UnboundedClosedInterval(2), to.ClosedUnboundedInterval(3)),
                to.IntervalSet(to.OpenInterval(2, 3))).ToString());
            Assert.Equal("{(-∞, ∞)}", to.Union(
                to.IntervalSet(to.UnboundedClosedInterval(2), to.ClosedUnboundedInterval(3)),
                to.IntervalSet(to.ClosedInterval(2, 3))).ToString());
            Assert.Equal("{(-∞, 2), (3, ∞)}", to.Union(
                to.IntervalSet(to.UnboundedOpenInterval(2), to.OpenUnboundedInterval(3)),
                to.IntervalSet(to.UnboundedClosedInterval(1), to.ClosedUnboundedInterval(4))).ToString());
        }
    }*/
}
