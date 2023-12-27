using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections;

public class ExceptTests
{
    [Fact]
    public void Except()
    {
        var list = new List<string> { "1 potato", "2 potatoes", "1 potato", "3 potatoes" };
        var result = list.Except("1 potato").ToArray();

        Assert.Equal(2, result.Length);
        Assert.Equal(new [] { "2 potatoes", "3 potatoes" }, result);
    }
}