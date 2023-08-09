using System.Collections.Generic;
using FsCheck;

namespace FuncSharp.Tests;

public record class ReferenceType (int Value);

public class Generators
{
    static Generators()
    {
        BoolOptions = Arb.From(DefaultOptionGenerator<bool>()); // No shrinker needed for booleans
        IntOptions = Arb.From(DefaultOptionGenerator<int>(), IntOptionShrinker);
        DecimalOptions = Arb.From(DefaultOptionGenerator<decimal>(), DecimalOptionShrinker);
        DoubleOptions = Arb.From(DefaultOptionGenerator<double>(), DoubleOptionShrinker);

        UnitOptions = Arb.From(Gen.Constant(Unit.Value).SometimesEmpty()); // No shrinker needed for Unit

        var referenceTypeOptionGenerator = Arb.From<int>().Generator.Select(i => new ReferenceType(i)).SometimesEmpty();
        ReferenceTypeOptions = Arb.From(referenceTypeOptionGenerator, ReferenceTypeOptionShrinker);
    }

    public static Arbitrary<IOption<bool>> BoolOptions { get; }

    public static Arbitrary<IOption<int>> IntOptions { get; }

    public static Arbitrary<IOption<decimal>> DecimalOptions { get; }

    public static Arbitrary<IOption<double>> DoubleOptions { get; }

    public static Arbitrary<IOption<Unit>> UnitOptions { get; }

    public static Arbitrary<IOption<ReferenceType>> ReferenceTypeOptions { get; }

    private static Gen<IOption<T>> DefaultOptionGenerator<T>()
    {
        return Arb.From<T>().Generator.SometimesEmpty();
    }

    private static IEnumerable<IOption<int>> IntOptionShrinker(IOption<int> option)
    {
        if(option.NonEmpty)
            yield return Option.Valued(option.GetOrDefault() - 1);
    }

    private static IEnumerable<IOption<decimal>> DecimalOptionShrinker(IOption<decimal> option)
    {
        if(option.NonEmpty)
            yield return Option.Valued(option.GetOrDefault() - 0.1m);
    }

    private static IEnumerable<IOption<double>> DoubleOptionShrinker(IOption<double> option)
    {
        if(option.NonEmpty)
            yield return Option.Valued(option.GetOrDefault() - 0.1d);
    }

    private static IEnumerable<IOption<ReferenceType>> ReferenceTypeOptionShrinker(IOption<ReferenceType> option)
    {
        if(option.NonEmpty)
            yield return Option.Valued(new ReferenceType(option.GetOrDefault().Value - 1));
    }
}
