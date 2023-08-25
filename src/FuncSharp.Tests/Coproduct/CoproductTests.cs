using System.Threading.Tasks;
using Xunit;

namespace FuncSharp.Tests
{
    public class CoproductTests
    {
        [Fact]
        public void Create()
        {
            var c1 = Coproduct2.CreateFirst<string, int>("foo");
            var c2 = Coproduct2.CreateSecond<string, int>(42);
            var c3 = Coproduct2.CreateSecond<string, string>("bar");

            Assert.Equivalent(2, c1.CoproductArity);
            Assert.Equivalent(2, c2.CoproductArity);
            Assert.Equivalent(2, c3.CoproductArity);

            Assert.Equivalent(1, c1.CoproductDiscriminator);
            Assert.Equivalent(2, c2.CoproductDiscriminator);
            Assert.Equivalent(2, c2.CoproductDiscriminator);

            Assert.Equivalent("foo", c1.CoproductValue);
            Assert.Equivalent(42, c2.CoproductValue);
            Assert.Equivalent("bar", c3.CoproductValue);

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

            Assert.Equivalent(Option.Valued("foo"), u1.First);
            Assert.Equivalent(Option.Empty<int>(), u1.Second);

            Assert.Equivalent(Option.Empty<string>(), u2.First);
            Assert.Equivalent(Option.Valued(42), u2.Second);
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
}
