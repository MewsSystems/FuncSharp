﻿using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class MapEmptyTests
    {
        public MapEmptyTests()
        {
            Arb.Register<Generators>();
        }

        [Fact]
        internal void MapEmpty()
        {
            // A non-empty option is always empty when mapped with MapEmpty
            OptionAssert.IsEmpty(Option.Valued(2).MapEmpty(_ => 14));
            OptionAssert.IsEmpty("asd".ToOption().MapEmpty(_ => (int?)null));
            OptionAssert.IsEmpty(Option.Valued("").MapEmpty(_ => "asd"));

            // Empty option will always have value when mapped with MapEmpty
            OptionAssert.HasValue(14, Option.Empty<int>().MapEmpty(_ => 14));
            OptionAssert.HasValue(28, Option.Empty<string>().MapEmpty(_ => (int?)28));
            OptionAssert.HasValue(null, Option.Empty<int>().MapEmpty(_ => (string)null));
            OptionAssert.HasValue("xxxxx", Option.Empty<string>().MapEmpty(v => "xxxxx"));
        }

        [Property]
        internal void Map_int(IOption<int> option)
        {
            AssertMapEmpty(option);
        }

        [Property]
        internal void Map_decimal(IOption<decimal> option)
        {
            AssertMapEmpty(option);
        }

        [Property]
        internal void Map_double(IOption<double> option)
        {
            AssertMapEmpty(option);
        }

        [Property]
        internal void Map_bool(IOption<bool> option)
        {
            AssertMapEmpty(option);
        }

        [Property]
        internal void Map_ReferenceType(IOption<ReferenceType> option)
        {
            AssertMapEmpty(option);
        }

        private void AssertMapEmpty<T>(IOption<T> option)
        {
            AssertMapEmpty(option, _ => (ReferenceType)null);
            AssertMapEmpty(option, _ => new ReferenceType(6));
            AssertMapEmpty(option, _ => 14);
            AssertMapEmpty(option, _ => (int?)14);
            AssertMapEmpty(option, _ => (int?)null);
        }

        private void AssertMapEmpty<T, TResult>(IOption<T> option, Func<Unit, TResult> map)
        {
            var result = option.MapEmpty(map);
            Assert.Equal(option.NonEmpty, result.IsEmpty);
            if (option.IsEmpty)
            {
                OptionAssert.HasValue(map(Unit.Value), result);
            }
        }
    }
}
