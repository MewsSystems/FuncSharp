using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

public class MatchTests_Func
{
    public MatchTests_Func()
    {
        Arb.Register<OptionGenerators>();
    }

    [Fact]
    internal void Match()
    {
        var result1 = Option.Valued(14).Match(
            v => v * 2,
            _ =>
            {
                Assert.Fail("Shouldn't be called.");
                return 2;
            }
        );
        Assert.Equal(28, result1);

        var result2 = Option.Empty<int>().Match(
            v =>
            {
                Assert.Fail("Shouldn't be called.");
                return 3;
            },
            _ => 4
        );
        Assert.Equal(4, result2);
    }

    [Property]
    internal void Match_int(Option<int> option)
    {
        AssertMatch(option, t => t * 7, otherwise: 5);
    }

    [Property]
    internal void Match_decimal(Option<decimal> option)
    {
        AssertMatch(option, t => t * 5, otherwise: 7);
    }

    [Property]
    internal void Match_double(Option<double> option)
    {
        AssertMatch(option, t => t * 3, otherwise: 11);
    }

    [Property]
    internal void Match_bool(Option<bool> option)
    {
        AssertMatch(option, b => !b, otherwise: (bool?)null);
    }

    [Property]
    internal void Match_ReferenceType(Option<ReferenceType> option)
    {
        AssertMatch(option, t => t.Value * 2, otherwise: 17);
    }

    private void AssertMatch<T, TResult>(Option<T> option, Func<T, TResult> map, TResult otherwise)
    {
        var result = option.Match(
            v =>
            {
                if (option.IsEmpty)
                {
                    Assert.Fail("Shouldn't be called when the option is empty.");
                }
                return map(v);
            },
            _ =>
            {
                if (option.NonEmpty)
                {
                    Assert.Fail("Shouldn't be called.");
                }
                return otherwise;
            }
        );

        if (option.IsEmpty)
        {
            Assert.Equal(otherwise, result);
        }
        else
        {
            Assert.Equal(map(option.GetOrDefault()), result);
        }
    }
}