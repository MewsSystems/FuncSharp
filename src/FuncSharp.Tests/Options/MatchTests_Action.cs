using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class MatchTests_Action
    {
        public MatchTests_Action()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        internal void Match()
        {
            bool wasCalled = false;
            Option.Valued(14).Match(
                v =>
                {
                    Assert.Equal(14, v);
                    wasCalled = true;
                },
                _ => Assert.Fail("Shouldn't be called.")
            );
            Assert.True(wasCalled);
            wasCalled = false;

            Option.Empty<int>().Match(
                v => Assert.Fail("Shouldn't be called."),
                _ => wasCalled = true
            );
            Assert.True(wasCalled);
        }

        [Property]
        internal void Match_int(Option<int> option)
        {
            AssertMatch(option);
        }

        [Property]
        internal void Match_decimal(Option<decimal> option)
        {
            AssertMatch(option);
        }

        [Property]
        internal void Match_double(Option<double> option)
        {
            AssertMatch(option);
        }

        [Property]
        internal void Match_bool(Option<bool> option)
        {
            AssertMatch(option);
        }

        [Property]
        internal void Match_ReferenceType(Option<ReferenceType> option)
        {
            AssertMatch(option);
        }

        private void AssertMatch<T>(Option<T> option)
        {
            int? flag1 = null;
            int? flag2 = null;
            option.Match(
                v =>
                {
                    Assert.NotNull(v);
                    Assert.Equal(option.GetOrDefault(), v);
                    flag1 = 14;
                },
                _ => flag2 = 2
            );

            if (option.IsEmpty)
            {
                Assert.Equal(2, flag2);
                Assert.Null(flag1);
            }
            else
            {
                Assert.Equal(14, flag1);
                Assert.Null(flag2);
            }
        }
    }
}
