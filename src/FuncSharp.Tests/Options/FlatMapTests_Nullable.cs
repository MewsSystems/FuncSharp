using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class FlatMapTests_Nullable
    {
        public FlatMapTests_Nullable()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void FlatMap()
        {
            // Flatmap to a not-null nullable should have the value.
            OptionAssert.NonEmptyWithValue(84, 42.ToOption().FlatMap(v => (int?)(v * 2)));

            // Flatmap to null nullable should be empty.
            OptionAssert.IsEmpty(42.ToOption().FlatMap(v => (int?)null));

            // Flatmap on empty option is always empty.
            OptionAssert.IsEmpty(Option.Empty<int>().FlatMap(v => (int?)(v * 2)));
            OptionAssert.IsEmpty(Option.Empty<int?>().FlatMap(v => (int?) null));
        }

        [Property]
        internal void FlatMap_int(Option<int> option)
        {
            AssertFlatMapResult(option, i => (int?)i * 2);
        }

        [Property]
        internal void FlatMap_decimal(Option<decimal> option)
        {
            AssertFlatMapResult(option, d => (decimal?)d * 2);
        }

        [Property]
        internal void FlatMap_double(Option<double> option)
        {
            AssertFlatMapResult(option, d => (double?)d * 2);
        }

        [Property]
        internal void FlatMap_bool(Option<bool> option)
        {
            AssertFlatMapResult(option, b => (bool?)!b);
        }

        [Property]
        internal void FlatMap_ReferenceType(Option<ReferenceType> option)
        {
            // Also mapping from a revference type  to a nullable struct
            AssertFlatMapResult(option, d => (int?)d.Value * 2);
        }

        private void AssertFlatMapResult<T, TResult>(Option<T> option, Func<T, TResult?> map)
            where TResult : struct
        {
            var flatMapToNull = option.FlatMap(x => (TResult?)null);
            OptionAssert.IsEmpty(flatMapToNull);

            var flatMapResult = option.FlatMap(x => map(x));
            Assert.Equal(option.IsEmpty, flatMapResult.IsEmpty);

            if (option.NonEmpty)
            {
                Assert.Equal(map(option.GetOrDefault()).Value, flatMapResult.GetOrDefault());
            }
        }
    }
}
