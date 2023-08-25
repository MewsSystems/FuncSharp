using Xunit;

namespace FuncSharp.Tests.Collections;

public class OrderTests
{
    [Fact]
    public void Order()
    {
        Assert.Equal(new[] { 1, 3, 5, 7, 11 }, new[] { 7, 11, 3, 5, 1 }.Order((x, y) => x < y));
        Assert.Equal(new[] { 11, 7, 5, 3, 1 }, new[] { 7, 11, 3, 5, 1 }.Order((x, y) => x < y, Ordering.Descending));
    }
}