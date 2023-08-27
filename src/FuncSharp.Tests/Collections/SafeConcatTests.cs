using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable;

public class SafeSafeConcatTests
{
    private static readonly IEnumerable<string> NullEnumerable = null;

    [Fact]
    public void SafeConcat_ParamsOfItems()
    {
        var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes" };
        var result = "1 potato".ToEnumerable().SafeConcat("2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes").ToArray();

        Assert.Equal(5, result.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SafeConcat_ParamsOfItems_Nulls()
    {
        var expected = new List<string> { "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes" };
        var result = NullEnumerable.SafeConcat("2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes").ToArray();

        Assert.Equal(4, result.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SafeConcat_ParamsOfEnumerables()
    {
        var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes" };
        var nonEmpty = "1 potato".ToEnumerable().SafeConcat(new List<string> { "2 potatoes", "3 potatoes" }, new List<string> { "4 potatoes", "5 potatoes" }).ToArray();

        Assert.Equal(5, nonEmpty.Length);
        Assert.Equal(expected, nonEmpty);
    }

    [Fact]
    public void SafeConcat_ParamsOfEnumerables_Nulls()
    {
        var expected = new List<string> { "4 potatoes", "5 potatoes" };
        var nonEmpty = NullEnumerable.SafeConcat(NullEnumerable, new List<string> { "4 potatoes", "5 potatoes" }, NullEnumerable).ToArray();

        Assert.Equal(2, nonEmpty.Length);
        Assert.Equal(expected, nonEmpty);
    }
}