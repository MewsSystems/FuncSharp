using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

public class GetOrZeroTests
{
    public GetOrZeroTests()
    {
        Arb.Register<OptionGenerators>();
    }

    [Fact]
    public void GetOrZero()
    {
        Assert.Equal(1, 1.ToOption().GetOrZero());
        Assert.Equal(0, Option.Empty<int>().GetOrZero());
    }

    [Property]
    internal void GetOrZero_short(Option<short> option)
    {
        Assert.Equal(option.GetOrDefault(), option.GetOrZero());
    }

    [Property]
    internal void GetOrZero_int(Option<int> option)
    {
        Assert.Equal(option.GetOrDefault(), option.GetOrZero());
    }

    [Property]
    internal void GetOrZero_long(Option<long> option)
    {
        Assert.Equal(option.GetOrDefault(), option.GetOrZero());
    }

    [Property]
    internal void GetOrZero_decimal(Option<decimal> option)
    {
        Assert.Equal(option.GetOrDefault(), option.GetOrZero());
    }

    [Property]
    internal void GetOrZero_double(Option<double> option)
    {
        Assert.Equal(option.GetOrDefault(), option.GetOrZero());
    }
}