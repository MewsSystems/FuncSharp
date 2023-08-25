﻿using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class FlattenTests_Nullable
    {
        public FlattenTests_Nullable()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void Flatten()
        {
            OptionAssert.NonEmptyWithValue(42, Option.Valued<int?>(42).Flatten());
            OptionAssert.NonEmptyWithValue(true, Option.Valued<bool?>(true).Flatten());

            OptionAssert.IsEmpty(Option.Empty<int?>().Flatten());
            OptionAssert.IsEmpty(Option.Empty<bool?>().Flatten());

            OptionAssert.IsEmpty(Option.Valued<int?>(null).Flatten());
            OptionAssert.IsEmpty(Option.Valued<bool?>(null).Flatten());
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
            Assert.Equivalent(option.NonEmpty && option.Get() is not null, result.NonEmpty);

            if (option.NonEmpty)
            {
                Assert.Equivalent(option.Get(), result.Get());
            }
        }
    }
}
