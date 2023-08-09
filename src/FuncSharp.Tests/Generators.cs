using System;
using FsCheck;

namespace FuncSharp.Tests;

internal static class Generators
{
    static Generators()
    {
        Bools = Arb.From<bool>();
        BoolOptions = Arb.From<IOption<bool>>();
        Ints = Arb.From<int>();
        IntOptions = Arb.From<IOption<int>>();
        Decimals = Arb.From<decimal>();
        DecimalOptions = Arb.From<IOption<decimal>>();
        UnitOptions = Arb.From<IOption<Unit>>();
    }

    internal static Arbitrary<bool> Bools { get; }

    internal static Arbitrary<IOption<bool>> BoolOptions { get; }

    internal static Arbitrary<int> Ints { get; }

    internal static Arbitrary<IOption<int>> IntOptions { get; }

    internal static Arbitrary<decimal> Decimals { get; }

    internal static Arbitrary<IOption<decimal>> DecimalOptions { get; }

    internal static Arbitrary<IOption<Unit>> UnitOptions { get; }

    /// <summary>
    /// Runs a test that succeeds if no exception is thrown inside the function.
    /// </summary>
    internal static void AssertInvariant<T>(Arbitrary<T> generator, Action<T> assert)
    {
        Prop.ForAll(generator, assert).Check(new Configuration
        {
            Runner = Config.QuickThrowOnFailure.Runner,
            MaxNbOfTest = 1000
        });
    }
}
