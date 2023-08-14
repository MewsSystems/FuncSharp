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
        internal void FlatMapOrder_int(IOption<int> first, IOption<int> second, IOption<int> third)
        {
            Assert.Equal(first.FlatMap(f => second.FlatMap(s => third)), second.FlatMap(s => first.FlatMap(f => third)));
        }

        [Property]
        internal void FlatMapOrder_ReferenceType(IOption<ReferenceType> first, IOption<ReferenceType> second, IOption<ReferenceType> third)
        {
            Assert.Equal(first.FlatMap(f => second.FlatMap(s => third)), second.FlatMap(s => first.FlatMap(f => third)));
        }

        [Property]
        internal void FlatMap_int(IOption<int> option)
        {
            AssertFlatMapResult(option, i => i * 2);

            // Also mapping to a reference type.
            AssertFlatMapResult(option, i => new ReferenceType(i * 2));
        }

        [Property]
        internal void FlatMap_decimal(IOption<decimal> option)
        {
            AssertFlatMapResult(option, d => d * 2);
        }

        [Property]
        internal void FlatMap_double(IOption<double> option)
        {
            AssertFlatMapResult(option, d => d * 2);
        }

        [Property]
        internal void FlatMap_bool(IOption<bool> option)
        {
            AssertFlatMapResult(option, b => !b);
        }

        [Property]
        internal void FlatMap_ReferenceType(IOption<ReferenceType> option)
        {
            AssertFlatMapResult(option, d => new ReferenceType(d.Value * 2));

            // Also mapping to a struct
            AssertFlatMapResult(option, d => d.Value * 2);
        }

        private void AssertFlatMapResult<T, TResult>(IOption<T> option, Func<T, TResult> map)
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
