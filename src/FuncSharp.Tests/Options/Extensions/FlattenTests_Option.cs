using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class FlattenTests_Option
    {
        public FlattenTests_Option()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void Flatten()
        {
            OptionAssert.NonEmptyWithValue(42, Option.Valued(Option.Valued(42)).Flatten());
            OptionAssert.NonEmptyWithValue(new ReferenceType(12), Option.Valued(Option.Valued(new ReferenceType(12))).Flatten());

            OptionAssert.IsEmpty(Option.Valued(Option.Empty<int>()).Flatten());
            OptionAssert.IsEmpty(Option.Valued(Option.Empty<ReferenceType>()).Flatten());

            OptionAssert.IsEmpty(Option.Empty<IOption<int>>().Flatten());
            OptionAssert.IsEmpty(Option.Empty<IOption<ReferenceType>>().Flatten());
        }

        [Property]
        internal void Flatten_int(IOption<int> first, IOption<int> second)
        {
            AssertFlatten(first, second);
        }

        [Property]
        internal void Flatten_decimal(IOption<decimal> first, IOption<decimal> second)
        {
            AssertFlatten(first, second);
        }

        [Property]
        internal void Flatten_double(IOption<double> first, IOption<double> second)
        {
            AssertFlatten(first, second);
        }

        [Property]
        internal void Flatten_bool(IOption<bool> first, IOption<bool> second)
        {
            AssertFlatten(first, second);
        }

        [Property]
        internal void Flatten_ReferenceType(IOption<ReferenceType> first, IOption<ReferenceType> second)
        {
            AssertFlatten(first, second);
        }

        private void AssertFlatten<T>(IOption<T> first, IOption<T> second)
        {
            var result = first.Map(f => second).Flatten();
            Assert.Equivalent(first.NonEmpty && second.NonEmpty, result.NonEmpty);

            if (result.NonEmpty)
            {
                Assert.Equivalent(second.Get(), result.Get());
            }
        }
    }
}
