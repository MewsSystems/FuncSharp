using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class FlatMapTests
    {
        public FlatMapTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void FlatMap()
        {
            // Flatmap to a valued option should have the value.
            OptionAssert.NonEmptyWithValue(84, 42.ToOption().FlatMap(v => (v * 2).ToOption()));

            // Flatmap to Empty option should be empty.
            OptionAssert.IsEmpty(42.ToOption().FlatMap(v => Option.Empty<int>()));

            // Flatmap on empty option is always empty.
            OptionAssert.IsEmpty(Option.Empty<int>().FlatMap(v => (v * 2).ToOption()));
            OptionAssert.IsEmpty(Option.Empty<int>().FlatMap(v => Option.Empty<int>()));
        }

        [Property]
        internal void FlatMapOrder_int(Option<int> first, Option<int> second)
        {
            Assert.Equal(first.FlatMap(f => second.Map(s => (f, s))), second.FlatMap(s => first.Map(f => (f, s))));
        }

        [Property]
        internal void FlatMapOrder_ReferenceType(Option<ReferenceType> first, Option<ReferenceType> second)
        {
            Assert.Equal(first.FlatMap(f => second.Map(s => (f, s))), second.FlatMap(s => first.Map(f => (f, s))));
        }

        [Property]
        internal void FlatMap_int(Option<int> option)
        {
            AssertFlatMapResult(option, i => i * 2);

            // Also mapping to a reference type.
            AssertFlatMapResult(option, i => new ReferenceType(i * 2));
        }

        [Property]
        internal void FlatMap_decimal(Option<decimal> option)
        {
            AssertFlatMapResult(option, d => d * 2);
        }

        [Property]
        internal void FlatMap_double(Option<double> option)
        {
            AssertFlatMapResult(option, d => d * 2);
        }

        [Property]
        internal void FlatMap_bool(Option<bool> option)
        {
            AssertFlatMapResult(option, b => !b);
        }

        [Property]
        internal void FlatMap_ReferenceType(Option<ReferenceType> option)
        {
            AssertFlatMapResult(option, d => new ReferenceType(d.Value * 2));

            // Also mapping to a struct
            AssertFlatMapResult(option, d => d.Value * 2);
        }

        private void AssertFlatMapResult<T, TResult>(Option<T> option, Func<T, TResult> map)
        {
            var flatMapToEmptyResult = option.FlatMap(x => Option.Empty<T>());
            OptionAssert.IsEmpty(flatMapToEmptyResult);

            var flatMapResult = option.FlatMap(x => Option.Valued(map(x)));
            Assert.Equal(option.IsEmpty, flatMapResult.IsEmpty);

            if (option.NonEmpty)
            {
                Assert.Equal(map(option.GetOrDefault()), flatMapResult.GetOrDefault());
            }
        }
    }
}
