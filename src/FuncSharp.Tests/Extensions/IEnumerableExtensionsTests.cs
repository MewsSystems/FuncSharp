using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests;

public class IEnumerableExtensionsTests
{
    [Fact]
    [Obsolete]
    public void FirstOption()
    {
        Assert.True(new List<int>().FirstOption().IsEmpty);
        Assert.True(new List<int>().LastOption().IsEmpty);
        Assert.Equal(1.ToOption(), new List<int> { 1, 2, 3 }.FirstOption());
        Assert.Equal(3.ToOption(), new List<int> { 1, 2, 3 }.LastOption());
    }

    [Fact]
    public void ToCollectionDataCube()
    {
        var source = new List<IProduct3<string, string, string>>
        {
            Product3.Create("A", "B", "C"),
            Product3.Create("A", "B", "D")
        };

        var collectionDataCube = source.ToCollectionDataCube(s => s.ProductValue1, s => s.ProductValue2, s => s.ProductValue3);
        Assert.Equal(new List<string> { "C", "D" }, collectionDataCube.Get("A", "B").Get());
    }

    [Fact]
    public void ToDataCube()
    {
        var source = new List<IProduct3<string, string, string>>
        {
            Product3.Create("A", "B", "D"),
            Product3.Create("A", "C", "E")
        };

        var dataCube = source.ToDataCube(s => s.ProductValue2, s => s.ProductValue3);
        Assert.Equal(new List<string> { "B", "C" }, dataCube.Domain1);
        Assert.Equal(new List<string> { "D", "E" }, dataCube.Values);

        // A duplicit key throws exception.
        Assert.Throws<ArgumentException>(() => source.ToDataCube(s => s.ProductValue1, s => s.ProductValue3));
    }

    [Fact]
    public void PartitionMatch()
    {
        var source = new[]
        {
            Coproduct3.CreateFirst<string, int, bool>("foo"),
            Coproduct3.CreateSecond<string, int, bool>(42),
            Coproduct3.CreateFirst<string, int, bool>("bar"),
            Coproduct3.CreateSecond<string, int, bool>(21)
        };

        source.PartitionMatch(
            f => Assert.True(f.SequenceEqual(new[] { "foo", "bar" })),
            s => Assert.True(s.SequenceEqual(new[] { 42, 21 })),
            t => Assert.True(t.SequenceEqual(new bool[0]))
        );

        var lengths = source.PartitionMatch(
            texts => texts.Select(t => t.Length),
            ints => ints,
            bools => bools.Select(b => b ? 1 : 0)
        );

        Assert.True(lengths.SequenceEqual(new[] { 3, 3, 42, 21 }));
    }

    [Fact]
    public void Aggregate()
    {
        var e = new Exception();

        Assert.Equal(Option.Empty<Exception>(), new List<Exception>().Aggregate());
        Assert.Equal(e.ToOption(), new[] { e }.Aggregate());
        Assert.True(new[] { e, e, e }.Aggregate().Get() is AggregateException);
    }
}