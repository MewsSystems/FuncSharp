using FsCheck;

namespace FuncSharp.Tests.Generative;

public record class ReferenceTypeBase (int BaseValue);
public record class ReferenceType (int Value) : ReferenceTypeBase(Value);

public class Generators
{
    static Generators()
    {
        BoolOptions = Arb.From(DefaultOptionGenerator<bool>()); // No shrinker needed for booleans
        NullableBoolOptions = Arb.From(DefaultOptionGenerator<bool?>()); // No shrinker needed for booleans
        ShortOptions = Arb.From(DefaultOptionGenerator<short>(), Shrinkers.ShortOption);
        NullableShortOptions = Arb.From(DefaultOptionGenerator<short?>(), Shrinkers.NullableShortOption);
        IntOptions = Arb.From(DefaultOptionGenerator<int>(), Shrinkers.IntOption);
        NullableIntOptions = Arb.From(DefaultOptionGenerator<int?>(), Shrinkers.NullableIntOption);
        LongOptions = Arb.From(DefaultOptionGenerator<long>(), Shrinkers.LongOption);
        NullableLongOptions = Arb.From(DefaultOptionGenerator<long?>(), Shrinkers.NullableLongOption);
        DecimalOptions = Arb.From(DefaultOptionGenerator<decimal>(), Shrinkers.DecimalOption);
        NullableDecimalOptions = Arb.From(DefaultOptionGenerator<decimal?>(), Shrinkers.NullableDecimalOption);
        DoubleOptions = Arb.From(DefaultOptionGenerator<double>(), Shrinkers.DoubleOption);
        NullableDoubleOptions = Arb.From(DefaultOptionGenerator<double?>(), Shrinkers.NullableDoubleOption);

        UnitOptions = Arb.From(Gen.Constant(Unit.Value).SometimesEmpty()); // No shrinker needed for Unit

        var referenceTypeOptionGenerator = Arb.From<int>().Generator.Select(i => new ReferenceType(i)).SometimesEmpty();
        ReferenceTypeOptions = Arb.From(referenceTypeOptionGenerator, Shrinkers.ReferenceTypeOption);
        var referenceTypeBaseOptionGenerator = Arb.From<int>().Generator.Select(i => new ReferenceTypeBase(i)).SometimesEmpty();
        ReferenceTypeBaseOptions = Arb.From(referenceTypeBaseOptionGenerator, Shrinkers.ReferenceTypeBaseOption);
    }

    public static Arbitrary<IOption<bool>> BoolOptions { get; }

    public static Arbitrary<IOption<bool?>> NullableBoolOptions { get; }

    public static Arbitrary<IOption<short>> ShortOptions { get; }

    public static Arbitrary<IOption<short?>> NullableShortOptions { get; }

    public static Arbitrary<IOption<int>> IntOptions { get; }

    public static Arbitrary<IOption<int?>> NullableIntOptions { get; }

    public static Arbitrary<IOption<long>> LongOptions { get; }

    public static Arbitrary<IOption<long?>> NullableLongOptions { get; }

    public static Arbitrary<IOption<decimal>> DecimalOptions { get; }

    public static Arbitrary<IOption<decimal?>> NullableDecimalOptions { get; }

    public static Arbitrary<IOption<double>> DoubleOptions { get; }

    public static Arbitrary<IOption<double?>> NullableDoubleOptions { get; }

    public static Arbitrary<IOption<Unit>> UnitOptions { get; }

    public static Arbitrary<IOption<ReferenceType>> ReferenceTypeOptions { get; }

    public static Arbitrary<IOption<ReferenceTypeBase>> ReferenceTypeBaseOptions { get; }

    private static Gen<IOption<T>> DefaultOptionGenerator<T>()
    {
        return Arb.From<T>().Generator.SometimesEmpty();
    }
}
