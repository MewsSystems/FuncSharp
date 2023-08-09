using System;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class MapTests
    {
        [Fact]
        public void Map()
        {
            // Empty option mapped is always empty
            OptionAssert.IsEmpty(Option.Empty<int>().Map(v => v * 2));
            OptionAssert.IsEmpty(Option.Empty<string>().Map(v => (int?)null));

            // Valued option mapped will always have value
            OptionAssert.HasValue(84, 42.ToOption().Map(v => v * 2));
            OptionAssert.HasValue(84, 42.ToOption().Map(v => v * 2 as int?));
            OptionAssert.HasValue("xxxxx", 5.ToOption().Map(v => new String('x', v)));

            // Even if you map to null, the option is still valued
            OptionAssert.NonEmpty(5.ToOption().Map(v => null as int?));
            OptionAssert.NonEmpty(5.ToOption().Map(v => (string)null));
        }

        [Property]
        public void Map_int(int x)
        {
            Assert.Equal(4 / x, 4 / x);
        }

        [Fact]
        public void Map_Generative()
        {
            Generators.AssertInvariant(Generators.DecimalOptions, option =>
            {
                var result = option.Map(d => d * 2);
                Assert.Equal(option.IsEmpty, result.IsEmpty);
                Assert.Equal(option.GetOrDefault() * 2, result.GetOrDefault());
            });
            Generators.AssertInvariant(Generators.IntOptions, option =>
            {
                var result = option.Map(d => d * 2);
                Assert.Equal(option.IsEmpty, result.IsEmpty);
                Assert.Equal(option.GetOrDefault() * 2, result.GetOrDefault());
            });
            Generators.AssertInvariant(Generators.BoolOptions, option =>
            {
                var result = option.Map(d => !d);
                Assert.Equal(option.IsEmpty, result.IsEmpty);
                Assert.Equal(!option.GetOrDefault(), result.GetOrDefault());
            });
            var referenceTypeGenerator = Arb.From<IOption<ReferenceType>>();
            Generators.AssertInvariant(referenceTypeGenerator, option =>
            {
                var result = option.Map(d =>
                {
                    if (d is not null)
                    {
                        return new ReferenceType(d.Value * 2);
                    }
                    return null;
                });
                Assert.Equal(option.IsEmpty, result.IsEmpty);
                Assert.Equal(option.GetOrDefault()?.Value * 2, result.GetOrDefault()?.Value);
            });
        }

        private record class ReferenceType (int Value);
    }
}
