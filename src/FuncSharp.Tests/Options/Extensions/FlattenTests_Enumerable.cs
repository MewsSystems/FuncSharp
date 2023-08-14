using System.Collections.Generic;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class FlattenTests_Enumerable
    {
        public FlattenTests_Enumerable()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void Flatten()
        {
            Assert.Empty(Option.Empty<List<int>>().Flatten());
            Assert.Empty(Option.Empty<Stack<ReferenceType>>().Flatten());

            Assert.Empty(Option.Valued(new int[]{}).Flatten());
            Assert.Empty(Option.Valued(new List<ReferenceType>()).Flatten());

            Assert.Single(Option.Valued(new [] { 42 }).Flatten(), 42);
            Assert.Single(Option.Valued(new [] { new ReferenceType(3) }).Flatten(), new ReferenceType(3));

            Assert.Equal(
                Option.Valued(new [] { 42, 12, 3, 16, 49, 78 }).Flatten(),
                new List<int> { 42, 12, 3, 16, 49, 78 }
            );
        }

        [Property]
        internal void Flatten_int(IOption<int?> option)
        {
            AssertFlatten(option);
        }

        [Property]
        internal void Flatten_decimal(IOption<decimal?> option)
        {
            AssertFlatten(option);
        }

        [Property]
        internal void Flatten_double(IOption<double?> option)
        {
            AssertFlatten(option);
        }

        [Property]
        internal void Flatten_bool(IOption<bool?> option)
        {
            AssertFlatten(option);
        }

        private void AssertFlatten<T>(IOption<T?> option)
            where T : struct
        {
            var result = option.Flatten();
            Assert.Equal(option.NonEmpty && option.Get() is not null, result.NonEmpty);

            if (option.NonEmpty)
            {
                Assert.Equal(option.Get(), result.Get());
            }
        }
    }
}
