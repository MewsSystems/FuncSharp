using Xunit;

namespace FuncSharp.Tests.Numeric;

public class DivideTests
{
    [Fact]
    internal void SafeDivide_int()
    {
        Assert.Equal(0.5m, 1.SafeDivide(2));
        Assert.Equal(1.5m, 3.SafeDivide(2));
        Assert.Equal(14.33m, 1.SafeDivide(0, 14.33m));
        Assert.Equal(12.12m, 3489.SafeDivide(0, 12.12m));
    }

    [Fact]
    internal void SafeDivide_decimal()
    {
        Assert.Equal(0.5m, 1m.SafeDivide(2));
        Assert.Equal(1.5m, 3m.SafeDivide(2));
        Assert.Equal(14.33m, 1m.SafeDivide(0, 14.33m));
        Assert.Equal(12.12m, 3489m.SafeDivide(0, 12.12m));
    }

    [Fact]
    internal void Divide_int()
    {
        Assert.Equal(0.5m.ToOption(), 1.Divide(2));
        Assert.Equal(1.5m.ToOption(), 3.Divide(2));
        Assert.Equal(Option.Empty<decimal>(), 1.Divide(0));
        Assert.Equal(Option.Empty<decimal>(), 3489.Divide(0));
    }

    [Fact]
    internal void Divide_decimal()
    {
        Assert.Equal(0.5m.ToOption(), 1m.Divide(2));
        Assert.Equal(1.5m.ToOption(), 3m.Divide(2));
        Assert.Equal(Option.Empty<decimal>(), 1m.Divide(0));
        Assert.Equal(Option.Empty<decimal>(), 3489m.Divide(0));
    }
}