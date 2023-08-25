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
                    Assert.Equivalent(14, v);
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
        internal void Match_int(IOption<int> option)
        {
            AssertMatch(option);
        }

        [Property]
        internal void Match_decimal(IOption<decimal> option)
        {
            AssertMatch(option);
        }

        [Property]
        internal void Match_double(IOption<double> option)
        {
            AssertMatch(option);
        }

        [Property]
        internal void Match_bool(IOption<bool> option)
        {
            AssertMatch(option);
        }

        [Property]
        internal void Match_ReferenceType(IOption<ReferenceType> option)
        {
            AssertMatch(option);
        }

        private void AssertMatch<T>(IOption<T> option)
        {
            int? flag1 = null;
            int? flag2 = null;
            option.Match(
                v =>
                {
                    Assert.NotNull(v);
                    Assert.Equivalent(option.GetOrDefault(), v);
                    flag1 = 14;
                },
                _ => flag2 = 2
            );

            if (option.IsEmpty)
            {
                Assert.Equivalent(2, flag2);
                Assert.Null(flag1);
            }
            else
            {
                Assert.Equivalent(14, flag1);
                Assert.Null(flag2);
            }
        }
    }
}
