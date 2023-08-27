using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

public class GetOrDefaultTests
{
    public GetOrDefaultTests()
    {
        Arb.Register<OptionGenerators>();
    }

    [Fact]
    public void GetOrDefault()
    {
        Assert.Equal("asd", Option.Create("asd").GetOrDefault());
        Assert.Equal(42, 42.ToOption().GetOrDefault());

        Assert.Equal(0, Option.Empty<int>().GetOrDefault());
        Assert.Null(Option.Empty<int?>().GetOrDefault());
        Assert.Null(Option.Empty<string>().GetOrDefault());
    }

    [Property]
    internal void GetOrDefault_int(int i)
    {
        AssertGetOrDefault(i);
    }

    [Property]
    internal void GetOrDefault_decimal(decimal option)
    {
        AssertGetOrDefault(option);
    }

    [Property]
    internal void GetOrDefault_double(double option)
    {
        AssertGetOrDefault(option);
    }

    [Property]
    internal void GetOrDefault_bool(bool option)
    {
        AssertGetOrDefault(option);
    }

    [Property]
    internal void GetOrDefault_ReferenceType(ReferenceType option)
    {
        AssertGetOrDefault(option);
    }

    private void AssertGetOrDefault<T>(T value)
    {
        var option = Option.Valued(value);
        Assert.Equal(value, option.GetOrDefault());

        Assert.Equal(default(T), Option.Empty<T>().GetOrDefault());
    }
}