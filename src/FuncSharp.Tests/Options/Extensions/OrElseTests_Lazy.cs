﻿using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

public class OrElseTests_Lazy
{
    public OrElseTests_Lazy()
    {
        Arb.Register<OptionGenerators>();
    }

    [Fact]
    public void OrElse()
    {
        Assert.Equal(1.ToOption(), 1.ToOption().OrElse(_ => 2.ToOption()));
        Assert.Equal(2.ToOption(), Option.Empty<int>().OrElse(_ => 2.ToOption()));

        Assert.Equal("asd".ToOption(), "asd".ToOption().OrElse(_ => "123".ToOption()));
        Assert.Equal("123".ToOption(), Option.Empty<string>().OrElse(_ => "123".ToOption()));

        Assert.Equal(new ReferenceType(3).ToOption(), Option.Empty<ReferenceType>().OrElse(_ => new ReferenceType(3).ToOption()));
        Assert.Equal(new ReferenceTypeBase(4).ToOption(), Option.Empty<ReferenceType>().OrElse(_ => new ReferenceTypeBase(4).ToOption()));
        Assert.Equal(new ReferenceTypeBase(5).ToOption(), Option.Empty<ReferenceTypeBase>().OrElse(_ => new ReferenceTypeBase(5).ToOption()));
    }

    [Property]
    internal void OrElse_int(Option<int> option)
    {
        AssertOrElse(option, _ => (-14).ToOption());
    }

    [Property]
    internal void OrElse_decimal(Option<decimal> option)
    {
        AssertOrElse(option, _ => 2156.384m.ToOption());
    }

    [Property]
    internal void OrElse_double(Option<double> option)
    {
        AssertOrElse(option, _ => 2842.456.ToOption());
    }

    [Property]
    internal void OrElse_bool(Option<bool> option)
    {
        AssertOrElse(option, _ => true.ToOption());
    }

    [Property]
    internal void OrElse_ReferenceType(Option<ReferenceType> option)
    {
        AssertOrElse(option, _ => new ReferenceType(7).ToOption());
    }

    [Property]
    internal void OrElse_ReferenceTypeBase(Option<ReferenceTypeBase> option)
    {
        AssertOrElse(option, _ => new ReferenceType(13).ToOption<ReferenceTypeBase>());
        AssertOrElse(option, _ => new ReferenceTypeBase(17).ToOption());
    }

    private void AssertOrElse<T>(Option<T> option, Func<Unit, Option<T>> otherwise)
    {
        var result = option.OrElse(otherwise);
        if (option.NonEmpty)
        {
            Assert.Equal(option, result);
        }
        else
        {
            Assert.Equal(otherwise(Unit.Value), result);
        }
    }
}