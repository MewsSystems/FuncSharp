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
        AssertAreEqual(Option.Valued(14), Option.Valued(14));
        AssertAreEqual(Option.Valued(-6), Option.Valued(-6));
        AssertAreEqual(Option.Valued(Unit.Value), Option.Valued(Unit.Value));
        AssertAreEqual(Option.Valued(new ReferenceType(28167)), Option.Valued(new ReferenceType(28167)));
        AssertAreEqual(Option.Valued("ASDF123Q"), Option.Valued("ASDF123Q"));

        // Empty option of same type
        AssertAreEqual(Option.Empty<int>(), Option.Empty<int>());
        AssertAreEqual(Option.Empty<ReferenceType>(), Option.Empty<ReferenceType>());

        // When using covariance, the type of the option is actually different, therefore equality is false.
        AssertAreNotEqual(Option.Empty<ReferenceType>(), Option.Empty<ReferenceTypeBase>());

        // Different type.
        AssertAreNotEqual(Option.Valued<int>(1), Option.Valued<long>(1));
        AssertAreNotEqual(Option.Empty<int>(), Option.Empty<decimal>());
        AssertAreNotEqual(Option.Empty<decimal>(), Option.Empty<ReferenceType>());
        AssertAreNotEqual(Option.Empty<ReferenceType>(), Option.Empty<string>());

        // Empty and non-empty
        AssertAreNotEqual(Option.Empty<int?>(), Option.Valued((int?)null));
        AssertAreNotEqual(Option.Empty<int>(), Option.Valued(0));
        AssertAreNotEqual(Option.Empty<int>(), Option.Valued(1));
        AssertAreNotEqual(Option.Empty<string>(), Option.Valued<string>(null));
        AssertAreNotEqual(Option.Empty<string>(), Option.Valued("ASDF"));
        AssertAreNotEqual(Option.Empty<ReferenceType>(), Option.Valued(new ReferenceType(14)));
        AssertAreNotEqual(Option.Empty<ReferenceType>(), Option.Valued<ReferenceTypeBase>(null));

        // Empty option and non-empty of different type
        AssertAreNotEqual(Option.Empty<int>(), Option.Valued<ReferenceTypeBase>(null));
        AssertAreNotEqual(Option.Empty<ReferenceType>(), Option.Valued(1));
        AssertAreNotEqual(Option.Empty<ReferenceType>(), Option.Valued("ASDF"));

        // Both non-empty, but different values.
        AssertAreNotEqual(Option.Valued(14), Option.Valued(-6));
        AssertAreNotEqual(Option.Valued(-6), Option.Valued(0));
        AssertAreNotEqual(Option.Valued(new ReferenceType(28167)), Option.Valued(new ReferenceType(-5)));
        AssertAreNotEqual(Option.Valued(new ReferenceType(28167)), Option.Valued<ReferenceType>(null));
        AssertAreNotEqual(Option.Valued("ASDF123Q"), Option.Valued("Other string"));
        AssertAreNotEqual(Option.Valued("ASDF123Q"), Option.Valued<string>(null));
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
        AssertAreEqual(first, first);
        AssertAreEqual(second, second);

        var shouldBeEqual = first.NonEmpty == second.NonEmpty && Equals(first.GetOrDefault(), second.GetOrDefault());
        Assert.Equal(shouldBeEqual, first.Equals(second));
        Assert.Equal(shouldBeEqual, first == second);
        Assert.Equal(!shouldBeEqual, first != second);
    }

    private void AssertAreEqual<T>(Option<T> first, Option<T> second)
    {
        Assert.Equal(first, second);
        Assert.True(first == second);
        Assert.False(first != second);
    }

    private void AssertAreNotEqual(object first, object second)
    {
        Assert.NotEqual(first, second);
        Assert.False(first == second);
        Assert.True(first != second);
    }
}