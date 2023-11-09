using System.Threading.Tasks;
using Xunit;

namespace FuncSharp.Tests;

public class CoproductTests
{
    [Fact]
    public void Create()
    {
        var c1 = Coproduct2.CreateFirst<string, int>("foo");
        var c2 = Coproduct2.CreateSecond<string, int>(42);
        var c3 = Coproduct2.CreateSecond<string, string>("bar");

        Assert.Equal(2, c1.CoproductArity);
        Assert.Equal(2, c2.CoproductArity);
        Assert.Equal(2, c3.CoproductArity);

        Assert.Equal(1, c1.CoproductDiscriminator);
        Assert.Equal(2, c2.CoproductDiscriminator);
        Assert.Equal(2, c2.CoproductDiscriminator);

        Assert.Equal("foo", c1.CoproductValue);
        Assert.Equal(42, c2.CoproductValue);
        Assert.Equal("bar", c3.CoproductValue);

        Assert.True(c1.IsFirst);
        Assert.False(c1.IsSecond);

        Assert.False(c2.IsFirst);
        Assert.True(c2.IsSecond);

        Assert.False(c3.IsFirst);
        Assert.True(c3.IsSecond);
    }

    [Fact]
    public void Projections()
    {
        var u1 = Coproduct2.CreateFirst<string, int>("foo");
        var u2 = Coproduct2.CreateSecond<string, int>(42);

        Assert.Equal(Option.Valued("foo"), u1.First);
        Assert.Equal(Option.Empty<int>(), u1.Second);

        Assert.Equal(Option.Empty<string>(), u2.First);
        Assert.Equal(Option.Valued(42), u2.Second);
    }

    [Fact]
    public void Map()
    {
        var u1 = Coproduct2.CreateFirst<string, int>("foo");
        var u2 = Coproduct2.CreateSecond<string, int>(42);
        var u3 = "foo".AsSafeCoproduct<double, int>();

        Coproduct2<bool, int> result1 = u1.Map(v => v == "foo", v => v + 2);
        Assert.True(result1.IsFirst);
        Assert.True((bool)result1.CoproductValue);

        Coproduct2<bool, int> result2 = u2.Map(v => v == "foo", v => v + 2);
        Assert.True(result2.IsSecond);
        Assert.Equal(44, (int)result2.CoproductValue);

        Coproduct3<double, int, object> result3 = u3.Map(d => d + 1, i => i + 3, o => o);
        Assert.True(result3.IsThird);
        Assert.Equal("foo", result3.CoproductValue);
    }

    [Fact]
    public void Match()
    {
        var u1 = Coproduct2.CreateFirst<string, int>("foo");
        var u2 = Coproduct2.CreateSecond<string, int>(42);
        var u3 = 42.AsSafeCoproduct<string, double>();

        Assert.True(u1.Match(v => v == "foo", v => false));
        Assert.True(u2.Match(v => false, v => v == 42));
        Assert.True(u3.Match(s => false, d => false, _ => true));
    }
        
    [Fact]
    public async Task MatchAsync()
    {
        var u1 = Coproduct2.CreateFirst<string, int>("foo");
        var u2 = Coproduct2.CreateSecond<string, int>(42);
        var u3 = 42.AsSafeCoproduct<string, double>();

        Assert.True(await u1.MatchAsync(v => Task.FromResult(v == "foo"), v => Task.FromResult(false)));
        Assert.True(await u2.MatchAsync(v => Task.FromResult(false), v => Task.FromResult(v == 42)));
        Assert.True(await u3.MatchAsync(s => Task.FromResult(false), d => Task.FromResult(false), _ => Task.FromResult(true)));
    }
}