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
            Assert.Empty(Option.Empty<IEnumerable<ReferenceType>>().Flatten());

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
        internal void Flatten_int(Option<List<int>> option)
        {
            AssertFlatten(option);
        }

        [Property]
        internal void Flatten_decimal(Option<List<decimal>> option)
        {
            AssertFlatten(option);
        }

        [Property]
        internal void Flatten_double(Option<List<double>> option)
        {
            AssertFlatten(option);
        }

        [Property]
        internal void Flatten_bool(Option<List<bool>> option)
        {
            AssertFlatten(option);
        }

        [Property]
        internal void Flatten_referenceType(Option<List<ReferenceType>> option)
        {
            AssertFlatten(option);
        }

        private void AssertFlatten<T>(Option<List<T>> option)
        {
            var result = option.Flatten();

            if (option.IsEmpty)
            {
                Assert.Empty(result);
            }
            else
            {
                Assert.Equal(option.Get(), result);
            }
        }
    }
}
