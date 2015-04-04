using Xunit;

namespace FuncSharp.Tests
{
    public class SumTests
    {
        [Fact]
        public void ConstructionPreservesValues()
        {
            var u1 = Sum.CreateFirst<string, int>("foo");
            var u2 = Sum.CreateSecond<string, int>(42);

            Assert.Equal(2, u1.SumArity);
            Assert.Equal(2, u2.SumArity);

            Assert.Equal(1, u1.SumDiscriminator);
            Assert.Equal(2, u2.SumDiscriminator);

            Assert.Equal("foo", u1.SumValue);
            Assert.Equal(42, u2.SumValue);

            Assert.True(u1.IsFirst);
            Assert.False(u1.IsSecond);

            Assert.False(u2.IsFirst);
            Assert.True(u2.IsSecond);
        }

        [Fact]
        public void OptionProjectionIsCorrect()
        {
            var u1 = Sum.CreateFirst<string, int>("foo");
            var u2 = Sum.CreateSecond<string, int>(42);

            Assert.Equal(Option.Some("foo"), u1.First);
            Assert.Equal(Option.None<int>(), u1.Second);

            Assert.Equal(Option.None<string>(), u2.First);
            Assert.Equal(Option.Some(42), u2.Second);
        }

        [Fact]
        public void MatchWorks()
        {
            var u1 = Sum.CreateFirst<string, int>("foo");
            var u2 = Sum.CreateSecond<string, int>(42);

            Assert.True(u1.Match(v => v == "foo", v => false));
            Assert.True(u2.Match(v => false, v => v == 42));
        }

        [Fact]
        public void PartialMatchWorks()
        {
            var u1 = Sum.CreateFirst<string, int>("foo");
            var u2 = Sum.CreateSecond<string, int>(42);

            Assert.False(u1.PartialMatch<bool>());
            Assert.False(u2.PartialMatch<bool>());

            Assert.True(u1.PartialMatch(otherwise: _ => true));
            Assert.True(u2.PartialMatch(otherwise: _ => true));

            Assert.True(u1.PartialMatch(ifFirst: v => v == "foo"));
            Assert.False(u1.PartialMatch(ifSecond: v => true));

            Assert.False(u2.PartialMatch(ifFirst: v => true));
            Assert.True(u2.PartialMatch(ifSecond: v => v == 42));

            Assert.True(u1.PartialMatch(ifSecond: v => true, otherwise: _ => true));
            Assert.True(u2.PartialMatch(ifFirst: v => true, otherwise: _ => true));
        }
    }
}
