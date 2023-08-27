using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

public class GetOrElseTests_Lazy
{
    public GetOrElseTests_Lazy()
    {
        Arb.Register<OptionGenerators>();
    }

    [Fact]
    public void GetOrElseLazy()
    {
        Assert.Equal(1, 1.ToOption().GetOrElse(_ => 2));
        Assert.Equal(2, Option.Empty<int>().GetOrElse(_ => 2));

        Assert.Equal("asd", "asd".ToOption().GetOrElse(_ => "123"));
        Assert.Equal("123", Option.Empty<string>().GetOrElse(_ => "123"));

        Assert.Equal(new ReferenceType(3), Option.Empty<ReferenceType>().GetOrElse(_ => new ReferenceType(3)));
        Assert.Equal(new ReferenceTypeBase(4), Option.Empty<ReferenceType>().GetOrElse(_ => new ReferenceTypeBase(4)));
        Assert.Equal(new ReferenceTypeBase(5), Option.Empty<ReferenceTypeBase>().GetOrElse(_ => new ReferenceTypeBase(5)));
    }

    [Property]
    internal void GetOrElseLazy_int(Option<int> option)
    {
        AssertGetOrElseLazy(option, _ => -14);
    }

    [Property]
    internal void GetOrElseLazy_decimal(Option<decimal> option)
    {
        AssertGetOrElseLazy(option, _ => 2156.384m);
    }

    [Property]
    internal void GetOrElseLazy_double(Option<double> option)
    {
        AssertGetOrElseLazy(option, _ => 2842.456);
    }

    [Property]
    internal void GetOrElseLazy_bool(Option<bool> option)
    {
        AssertGetOrElseLazy(option, _ => true);
    }

    [Property]
    internal void GetOrElseLazy_ReferenceType(Option<ReferenceType> option)
    {
        AssertGetOrElseLazy(option, _ => new ReferenceType(7));
    }

    [Property]
    internal void GetOrElseLazy_ReferenceTypeBase(Option<ReferenceTypeBase> option)
    {
        AssertGetOrElseLazy(option, _ => new ReferenceType(13));
        AssertGetOrElseLazy(option, _ => new ReferenceTypeBase(17));
    }

    private void AssertGetOrElseLazy<T>(Option<T> option, Func<Unit, T> otherwise)
    {
        var result = option.GetOrElse(otherwise);
        if (option.NonEmpty)
        {
            Assert.Equal(option.Get(), result);
        }
        else
        {
            Assert.Equal(otherwise(Unit.Value), result);
        }
    }
}