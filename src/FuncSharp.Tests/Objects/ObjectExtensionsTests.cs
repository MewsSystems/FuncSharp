using Xunit;

namespace FuncSharp.Tests.Objects
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void MatchRefToBool()
        {
            Assert.False(((string)null).MatchRef(t =>
            {
                Assert.Fail("This shouldn't be called.");
                return true;
            }));
            Assert.True("Some text".MatchRef(t =>
            {
                Assert.Equal("Some text", t);
                return true;
            }));
            Assert.False("Some text".MatchRef(e => false));
        }

        [Fact]
        public void MapRefToVal()
        {
            Assert.Null(((string)null).MapRefToVal(t =>
            {
                Assert.Fail("This shouldn't be called.");
                return 14;
            }));
            Assert.Equal(14, "Some text".MapRefToVal(t =>
            {
                Assert.Equal("Some text", t);
                return 14;
            }));
        }

        [Fact]
        public void MapRefToValToNullable()
        {
            Assert.Null(((string)null).MapRefToVal(e =>
            {
                Assert.Fail("This shouldn't be called.");
                return (int?)14;
            }));
            Assert.Equal(14, "Some text".MapRefToVal(t =>
            {
                Assert.Equal("Some text", t);
                return (int?)14;
            }));
        }

        [Fact]
        public void MatchValToBool()
        {
            Assert.False(((int?)null).MatchVal(e =>
            {
                Assert.Fail("This shouldn't be called.");
                return true;
            }));
            Assert.True(((int?)14).MatchVal(i =>
            {
                Assert.Equal(14, i);
                return true;
            }));
            Assert.False(((int?)14).MatchVal(i => false));
        }

        [Fact]
        public void MatchVal()
        {
            Assert.Equal(22, ((int?)null).MatchVal(
                i =>
                {
                    Assert.Fail("This shouldn't be called.");
                    return 21;
                },
                _ => 22
            ));
            Assert.Equal(21, ((int?)14).MatchVal(
                i =>
                {
                    Assert.Equal(14, i);
                    return 21;
                },
                _ =>
                {
                    Assert.Fail("This shouldn't be called.");
                    return 22;
                }
            ));
        }

        [Fact]
        public void MapVal()
        {
            Assert.Null(((int?)null).MapVal(i =>
            {
                Assert.Fail("This shouldn't be called.");
                return 14;
            }));
            Assert.Equal(21, ((int?)14).MapVal(i =>
            {
                Assert.Equal(14, i);
                return 21;
            }));
        }

        [Fact]
        public void MapValToNullable()
        {
            Assert.Null(((int?)null).MapVal(i =>
            {
                Assert.Fail("This shouldn't be called.");
                return (int?)14;
            }));
            Assert.Equal(21, ((int?)14).MapVal(i =>
            {
                Assert.Equal(14, i);
                return (int?)21;
            }));
        }

        [Fact]
        public void MapValToRef()
        {
            Assert.Null(((int?)null).MapValToRef(i =>
            {
                Assert.Fail("This shouldn't be called.");
                return "Some text";
            }));
            Assert.Equal("Some text", ((int?)14).MapValToRef(i =>
            {
                Assert.Equal(14, i);
                return "Some text";
            }));
        }
    }
}
