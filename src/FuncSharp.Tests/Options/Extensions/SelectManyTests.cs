using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class SelectManyTests
    {
        public SelectManyTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void SelectMany()
        {
            // SelectMany to a valued option should have the value.
            OptionAssert.NonEmptyWithValue(84, 42.ToOption().SelectMany(v => (v * 2).ToOption()));

            // SelectMany to Empty option should be empty.
            OptionAssert.IsEmpty(42.ToOption().SelectMany(v => Option.Empty<int>()));

            // SelectMany on empty option is always empty.
            OptionAssert.IsEmpty(Option.Empty<int>().SelectMany(v => (v * 2).ToOption()));
            OptionAssert.IsEmpty(Option.Empty<int>().SelectMany(v => Option.Empty<int>()));
        }

        [Fact]
        public void Linq()
        {
            var sum =
                from x in 1.ToOption()
                from y in 2.ToOption()
                from z in 3.ToOption()
                select x + y + z;

            Assert.Equal(6.ToOption(), sum);

            var emptySum =
                from x in 1.ToOption()
                from y in Option.Empty<int>()
                select x + y;

            Assert.Equal(Option.Empty<int>(), emptySum);

            var filteredSum =
                from x in 1.ToOption()
                from y in 2.ToOption()
                where x > 100
                select x + y;

            Assert.Equal(Option.Empty<int>(), filteredSum);
        }

        [Property]
        internal void SelectManyOrder_int(IOption<int> first, IOption<int> second)
        {
            Assert.Equal(first.SelectMany(f => second.Select(s => (f, s))), second.SelectMany(s => first.Select(f => (f, s))));
        }

        [Property]
        internal void SelectManyOrder_ReferenceType(IOption<ReferenceType> first, IOption<ReferenceType> second)
        {
            Assert.Equal(first.SelectMany(f => second.Select(s => (f, s))), second.SelectMany(s => first.Select(f => (f, s))));
        }

        [Property]
        internal void SelectMany_int(IOption<int> option)
        {
            AssertSelectManyResult(option, i => i * 2);

            // Also mapping to a reference type.
            AssertSelectManyResult(option, i => new ReferenceType(i * 2));
        }

        [Property]
        internal void SelectMany_decimal(IOption<decimal> option)
        {
            AssertSelectManyResult(option, d => d * 2);
        }

        [Property]
        internal void SelectMany_double(IOption<double> option)
        {
            AssertSelectManyResult(option, d => d * 2);
        }

        [Property]
        internal void SelectMany_bool(IOption<bool> option)
        {
            AssertSelectManyResult(option, b => !b);
        }

        [Property]
        internal void SelectMany_ReferenceType(IOption<ReferenceType> option)
        {
            AssertSelectManyResult(option, d => new ReferenceType(d.Value * 2));

            // Also mapping to a struct
            AssertSelectManyResult(option, d => d.Value * 2);
        }

        private void AssertSelectManyResult<T, TResult>(IOption<T> option, Func<T, TResult> map)
        {
            // SelectMany should always be the same as FlatMap.
            Assert.Equal(option.FlatMap(x => Option.Valued(map(x))), option.SelectMany(x => Option.Valued(map(x))));

            var selectManyToEmptyResult = option.SelectMany(x => Option.Empty<T>());
            OptionAssert.IsEmpty(selectManyToEmptyResult);

            var selectManyResult = option.SelectMany(x => Option.Valued(map(x)));
            Assert.Equal(option.IsEmpty, selectManyResult.IsEmpty);

            if (option.NonEmpty)
            {
                Assert.Equal(map(option.GetOrDefault()), selectManyResult.GetOrDefault());
            }

            var linqResult =
                from x in option
                from y in Option.Valued(map(x))
                select y;
            Assert.Equal(selectManyResult, linqResult);

            var emptyLinqResult =
                from x in option
                from y in Option.Empty<T>()
                select y;
            Assert.Equal(selectManyToEmptyResult, emptyLinqResult);
        }
    }
}
