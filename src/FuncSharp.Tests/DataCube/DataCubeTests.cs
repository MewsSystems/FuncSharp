﻿using System.Linq;
using Xunit;

namespace FuncSharp.Tests
{
    public class DataCubeTests
    {
        [Fact]
        public void Create()
        {
            var c1 = new DataCube2<int, string, int>();
            Assert.True(c1.IsEmpty);

            var c2 = DataCube.Create(Enumerable.Range(1, 3),
                i => i,
                i => -i,
                i => i.ToString()
            );

            Assert.Equal(3, c2.Values.Count());
            Assert.Equal("1", c2.Get(1, -1).Get());
            Assert.Equal("2", c2.Get(2, -2).Get());
            Assert.Equal("3", c2.Get(3, -3).Get());
        }

        [Fact]
        public void Set()
        {
            var c1 = new DataCube2<int, string, int>();

            c1.Set(1, "foo", 42);
            c1.Set(2, "bar", 123);

            Assert.False(c1.IsEmpty);
            Assert.Equal(42, c1.Get(1, "foo").Get());
            Assert.Equal(123, c1.Get(2, "bar").Get());

            var c2 = new DataCube2<object, object, int>();
            var o1 = new object();
            var o2 = new object();

            c2.Set(o1, o2, 42);
            c2.Set(o2, o1, 123);

            Assert.False(c2.IsEmpty);
            Assert.Equal(42, c2.Get(o1, o2).Get());
            Assert.Equal(123, c2.Get(o2, o1).Get());
        }

        [Fact]
        public void Positions()
        {
            var c = new DataCube2<int, string, int>();
            Assert.Empty(c.Positions);

            c.Set(1, "foo", 42);
            Assert.Single(c.Positions);
            Assert.Contains(Position2.Create(1, "foo"), c.Positions);

            c.Set(1, "foo", 43);
            Assert.Single(c.Positions);
            Assert.Contains(Position2.Create(1, "foo"), c.Positions);

            c.Set(2, "bar", 123);
            Assert.Equal(2, c.Positions.Count());
            Assert.Contains(Position2.Create(1, "foo"), c.Positions);
            Assert.Contains(Position2.Create(2, "bar"), c.Positions);
        }

        [Fact]
        public void Values()
        {
            var c = new DataCube2<int, string, int>();
            Assert.Empty(c.Values);

            c.Set(1, "foo", 42);
            Assert.Single(c.Values);
            Assert.Contains(42, c.Values);

            c.Set(1, "foo", 43);
            Assert.Single(c.Values);
            Assert.Contains(43, c.Values);

            c.Set(2, "bar", 123);
            Assert.Equal(2, c.Values.Count());
            Assert.Contains(43, c.Values);
            Assert.Contains(123, c.Values);
        }

        [Fact]
        public void Domains()
        {
            var c = new DataCube2<int, string, int>();
            Assert.Empty(c.Domain1);
            Assert.Empty(c.Domain2);

            c.Set(1, "foo", 42);
            Assert.Single(c.Domain1);
            Assert.Contains(1, c.Domain1);
            Assert.Single(c.Domain2);
            Assert.Contains("foo", c.Domain2);

            c.Set(2, "bar", 123);
            Assert.Equal(2, c.Domain1.Count());
            Assert.Contains(1, c.Domain1);
            Assert.Contains(2, c.Domain1);
            Assert.Equal(2, c.Domain2.Count());
            Assert.Contains("foo", c.Domain2);
            Assert.Contains("bar", c.Domain2);

            c.Set(1, "bar", -42);
            Assert.Equal(2, c.Domain1.Count());
            Assert.Contains(1, c.Domain1);
            Assert.Contains(2, c.Domain1);
            Assert.Equal(2, c.Domain2.Count());
            Assert.Contains("foo", c.Domain2);
            Assert.Contains("bar", c.Domain2);
        }

        [Fact]
        public void Contains()
        {
            var c = new DataCube2<int, string, int>();

            c.Set(1, "foo", 42);
            Assert.True(c.Contains(Position2.Create(1, "foo")));
            Assert.True(c.Contains(1, "foo"));

            c.Set(2, "bar", 123);
            Assert.True(c.Contains(Position2.Create(2, "bar")));
            Assert.True(c.Contains(2, "bar"));

            Assert.False(c.Contains(Position2.Create(1, "bar")));
            Assert.False(c.Contains(1, "bar"));
        }

        [Fact]
        public void GetOrElseSet()
        {
            var c = new DataCube2<int, string, int>();
            c.Set(1, "foo", 42);

            Assert.Equal(42, c.GetOrElseSet(Position2.Create(1, "foo"), _ => 123));
            Assert.Equal(42, c.Get(1, "foo").Get());
            Assert.Equal(42, c.GetOrElseSet(1, "foo", _ => 123));
            Assert.Equal(42, c.Get(1, "foo").Get());

            Assert.Equal(123, c.GetOrElseSet(Position2.Create(2, "bar"), _ => 123));
            Assert.Equal(123, c.Get(2, "bar").Get());
            Assert.Equal(456, c.GetOrElseSet(3, "baz", _ => 456));
            Assert.Equal(456, c.Get(3, "baz").Get());
        }

        [Fact]
        public void SetOrElseUpdate()
        {
            var c = new DataCube2<int, string, int>();

            c.SetOrElseUpdate(2, "bar", 123, (a, b) =>
            {
                Assert.True(false);
                return 0;
            });
            Assert.Equal(123, c.Get(2, "bar").Get());

            var updateInvoked = false;
            c.Set(1, "foo", 42);
            c.SetOrElseUpdate(1, "foo", 123, (a, b) =>
            {
                updateInvoked = true;
                return a + b;
            });
            Assert.True(updateInvoked);
            Assert.Equal(42 + 123, c.Get(1, "foo").Get());
        }

        [Fact]
        public void Transform()
        {
            var c = new DataCube3<int, int, int, int>();
            c.Set(0, 0, 0, 1);
            c.Set(0, 0, 1, 2);
            c.Set(0, 1, 0, 3);
            c.Set(0, 1, 1, 4);
            c.Set(1, 0, 0, 10);
            c.Set(1, 0, 1, 20);
            c.Set(1, 1, 0, 30);
            c.Set(1, 1, 1, 40);

            var sum = c.Transform(_ => Position0.Create(), (a, b) => a + b);
            Assert.Equal(1 + 2 + 3 + 4 + 10 + 20 + 30 + 40, sum.Value.Get());

            var Position = c.Transform(_ => Position0.Create(), (a, b) => a * b);
            Assert.Equal(1 * 2 * 3 * 4 * 10 * 20 * 30 * 40, Position.Value.Get());

            var firstDimensionSums = c.Transform(p => Position1.Create(p.ProductValue1), (a, b) => a + b);
            Assert.Equal(2, firstDimensionSums.Values.Count());
            Assert.Equal(1 + 2 + 3 + 4, firstDimensionSums.Get(0).Get());
            Assert.Equal(10 + 20 + 30 + 40, firstDimensionSums.Get(1).Get());
        }

        [Fact]
        public void MultiTransform()
        {
            var c = new DataCube2<int, int, int>();
            c.Set(0, 0, 1);
            c.Set(0, 1, 10);
            c.Set(1, 0, 100);
            c.Set(1, 1, 1000);

            // Transforms each position to all "lower" positions.
            var transformed = c.MultiTransform(
                p =>
                {
                    var range1 = Enumerable.Range(0, p.ProductValue1 + 1);
                    var range2 = Enumerable.Range(0, p.ProductValue2 + 1);
                    return range1.SelectMany(r1 => range2.Select(r2 => Position2.Create(r1, r2)));
                },
                (a, b) => a + b
            );

            Assert.Equal(1111, transformed.Get(0, 0).Get());
            Assert.Equal(1010, transformed.Get(0, 1).Get());
            Assert.Equal(1100, transformed.Get(1, 0).Get());
            Assert.Equal(1000, transformed.Get(1, 1).Get());
        }

        [Fact]
        public void RollUpDimension()
        {
            var c = new DataCube3<int, int, int, int>();
            c.Set(0, 0, 0, 1);
            c.Set(0, 0, 1, 2);
            c.Set(0, 1, 0, 3);
            c.Set(0, 1, 1, 4);
            c.Set(1, 0, 0, 10);
            c.Set(1, 0, 1, 20);
            c.Set(1, 1, 0, 30);
            c.Set(1, 1, 1, 40);

            var withoutFirstDimension = c.RollUpDimension1((a, b) => a + b);
            Assert.Equal(4, withoutFirstDimension.Values.Count());
            Assert.Equal(1 + 10, withoutFirstDimension.Get(0, 0).Get());
            Assert.Equal(2 + 20, withoutFirstDimension.Get(0, 1).Get());
            Assert.Equal(3 + 30, withoutFirstDimension.Get(1, 0).Get());
            Assert.Equal(4 + 40, withoutFirstDimension.Get(1, 1).Get());

            var thirdDimension = withoutFirstDimension.RollUpDimension1((a, b) => a + b);
            Assert.Equal(2, thirdDimension.Values.Count());
            Assert.Equal(1 + 10 + 3 + 30, thirdDimension.Get(0).Get());
            Assert.Equal(2 + 20 + 4 + 40, thirdDimension.Get(1).Get());
        }

        [Fact]
        public void SliceDimension()
        {
            var c = new DataCube3<int, int, int, int>();
            c.Set(0, 0, 0, 1);
            c.Set(0, 0, 1, 2);
            c.Set(0, 1, 0, 3);
            c.Set(0, 1, 1, 4);
            c.Set(1, 0, 0, 10);
            c.Set(1, 0, 1, 20);
            c.Set(1, 1, 0, 30);
            c.Set(1, 1, 1, 40);

            var firstDimensionSlices = c.SliceDimension1();
            Assert.Equal(2, firstDimensionSlices.Values.Count());

            var zeroSlice = firstDimensionSlices.Get(0).Get();
            Assert.Equal(4, zeroSlice.Values.Count());
            Assert.Equal(1, zeroSlice.Get(0, 0).Get());
            Assert.Equal(2, zeroSlice.Get(0, 1).Get());
            Assert.Equal(3, zeroSlice.Get(1, 0).Get());
            Assert.Equal(4, zeroSlice.Get(1, 1).Get());

            var oneSlice = firstDimensionSlices.Get(1).Get();
            Assert.Equal(4, oneSlice.Values.Count());
            Assert.Equal(10, oneSlice.Get(0, 0).Get());
            Assert.Equal(20, oneSlice.Get(0, 1).Get());
            Assert.Equal(30, oneSlice.Get(1, 0).Get());
            Assert.Equal(40, oneSlice.Get(1, 1).Get());
        }
    }
}
