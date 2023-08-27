using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

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

        OptionAssert.IsEmpty(Option.Empty<Option<int>>().Flatten());
        OptionAssert.IsEmpty(Option.Empty<Option<ReferenceType>>().Flatten());
    }

    [Property]
    internal void Flatten_int(Option<int> first, Option<int> second)
    {
        AssertFlatten(first, second);
    }

    [Property]
    internal void Flatten_decimal(Option<decimal> first, Option<decimal> second)
    {
        AssertFlatten(first, second);
    }

    [Property]
    internal void Flatten_double(Option<double> first, Option<double> second)
    {
        AssertFlatten(first, second);
    }

    [Property]
    internal void Flatten_bool(Option<bool> first, Option<bool> second)
    {
        AssertFlatten(first, second);
    }

    [Property]
    internal void Flatten_ReferenceType(Option<ReferenceType> first, Option<ReferenceType> second)
    {
        AssertFlatten(first, second);
    }

    private void AssertFlatten<T>(Option<T> first, Option<T> second)
    {
        var result = first.Map(f => second.Map(s => (f, s))).Flatten();
        Assert.Equal(first.NonEmpty && second.NonEmpty, result.NonEmpty);

        if (result.NonEmpty)
        {
            Assert.Equal((first.Get(), second.Get()), result.Get());
        }
    }
}