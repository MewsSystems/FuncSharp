using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

public class EqualityTests
{
    public EqualityTests()
    {
        Arb.Register<OptionGenerators>();
    }

    [Fact]
    internal void Equality()
    {
        // Equal value of same type
        Assert.Equal(Option.Valued(14), Option.Valued(14));
        Assert.Equal(Option.Valued(-6), Option.Valued(-6));
        Assert.Equal(Option.Valued(Unit.Value), Option.Valued(Unit.Value));
        Assert.Equal(Option.Valued(new ReferenceType(28167)), Option.Valued(new ReferenceType(28167)));
        Assert.Equal(Option.Valued("ASDF123Q"), Option.Valued("ASDF123Q"));

        // Empty option of same type
        Assert.Equal(Option.Empty<int>(), Option.Empty<int>());
        Assert.Equal(Option.Empty<ReferenceType>(), Option.Empty<ReferenceType>());

        // When using covariance, the type of the option is actually different, therefore equality is false.
        Assert.NotEqual<object>(Option.Empty<ReferenceType>(), Option.Empty<ReferenceTypeBase>());

        // Different type.
        Assert.NotEqual<object>(Option.Valued<int>(1), Option.Valued<long>(1));
        Assert.NotEqual<object>(Option.Empty<int>(), Option.Empty<decimal>());
        Assert.NotEqual<object>(Option.Empty<decimal>(), Option.Empty<ReferenceType>());
        Assert.NotEqual<object>(Option.Empty<ReferenceType>(), Option.Empty<string>());

        // Empty and non-empty
        Assert.NotEqual(Option.Empty<int?>(), Option.Valued((int?)null));
        Assert.NotEqual(Option.Empty<int>(), Option.Valued(0));
        Assert.NotEqual(Option.Empty<int>(), Option.Valued(1));
        Assert.NotEqual(Option.Empty<string>(), Option.Valued<string>(null));
        Assert.NotEqual(Option.Empty<string>(), Option.Valued("ASDF"));
        Assert.NotEqual(Option.Empty<ReferenceType>(), Option.Valued(new ReferenceType(14)));
        Assert.NotEqual<object>(Option.Empty<ReferenceType>(), Option.Valued<ReferenceTypeBase>(null));

        // Empty option and non-empty of different type
        Assert.NotEqual<object>(Option.Empty<int>(), Option.Valued<ReferenceTypeBase>(null));
        Assert.NotEqual<object>(Option.Empty<ReferenceType>(), Option.Valued(1));
        Assert.NotEqual<object>(Option.Empty<ReferenceType>(), Option.Valued("ASDF"));

        // Both non-empty, but different values.
        Assert.NotEqual(Option.Valued(14), Option.Valued(-6));
        Assert.NotEqual(Option.Valued(-6), Option.Valued(0));
        Assert.NotEqual(Option.Valued(new ReferenceType(28167)), Option.Valued(new ReferenceType(-5)));
        Assert.NotEqual(Option.Valued(new ReferenceType(28167)), Option.Valued<ReferenceType>(null));
        Assert.NotEqual(Option.Valued("ASDF123Q"), Option.Valued("Other string"));
        Assert.NotEqual(Option.Valued("ASDF123Q"), Option.Valued<string>(null));
    }

    [Property]
    internal void Equality_int(Option<int> first, Option<int> second)
    {
        AssertEquality(first, second);
    }

    [Property]
    internal void Equality_decimal(Option<decimal> first, Option<decimal> second)
    {
        AssertEquality(first, second);
    }

    [Property]
    internal void Equality_double(Option<double> first, Option<double> second)
    {
        AssertEquality(first, second);
    }

    [Property]
    internal void Equality_bool(Option<bool> first, Option<bool> second)
    {
        AssertEquality(first, second);
    }

    [Property]
    internal void Equality_ReferenceType(Option<ReferenceType> first, Option<ReferenceType> second)
    {
        AssertEquality(first, second);
    }

    private void AssertEquality<T>(Option<T> first, Option<T> second)
    {
        Assert.Equal(first, first);
        Assert.Equal(second, second);

        var shouldBeEqual = first.NonEmpty == second.NonEmpty && Equals(first.GetOrDefault(), second.GetOrDefault());
        Assert.Equal(shouldBeEqual, first.Equals(second));
    }
}