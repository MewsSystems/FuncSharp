using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable;

public class IsSingleTests
{
    [Fact]
    public void IsSingle_null()
    {
        IEnumerable<string> enumerableNull = null;
        string[] arrayNull = null;

        Assert.False(enumerableNull.IsSingle());
        Assert.False(arrayNull.IsSingle());
    }

    [Fact]
    public void IsSingle_Empty()
    {
        IEnumerable<string> enumerableEmpty = Enumerable.Empty<string>();
        string[] arrayEmpty = new string[]{};

        Assert.False(enumerableEmpty.IsSingle());
        Assert.False(arrayEmpty.IsSingle());
    }

    [Fact]
    public void IsSingle_Single()
    {
        IEnumerable<string> enumerableSingle = Enumerable.Repeat("A potato", 1);
        string[] arraySingle = new []{"A potato"};

        Assert.True(enumerableSingle.IsSingle());
        Assert.True(arraySingle.IsSingle());
    }

    [Fact]
    public void IsSingle_Multiple()
    {
        IEnumerable<string> enumerableMultiple = Enumerable.Range(0, 10).Select(i => $"{i} potatoes");
        string[] arrayMultiple = Enumerable.Range(0, 10).Select(i => $"{i} potatoes").ToArray();

        Assert.False(enumerableMultiple.IsSingle());
        Assert.False(arrayMultiple.IsSingle());
    }
}