using FsCheck;

namespace FuncSharp.Tests.Generative;

public record class ReferenceType (int Value);

public class Generators
{
    static Generators()
    {
        BoolOptions = Arb.From(DefaultOptionGenerator<bool>()); // No shrinker needed for booleans
        IntOptions = Arb.From(DefaultOptionGenerator<int>(), Shrinkers.IntOption);
        DecimalOptions = Arb.From(DefaultOptionGenerator<decimal>(), Shrinkers.DecimalOption);
        DoubleOptions = Arb.From(DefaultOptionGenerator<double>(), Shrinkers.DoubleOption);

        UnitOptions = Arb.From(Gen.Constant(Unit.Value).SometimesEmpty()); // No shrinker needed for Unit

        var referenceTypeOptionGenerator = Arb.From<int>().Generator.Select(i => new ReferenceType(i)).SometimesEmpty();
        ReferenceTypeOptions = Arb.From(referenceTypeOptionGenerator, Shrinkers.ReferenceTypeOption);
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
}
