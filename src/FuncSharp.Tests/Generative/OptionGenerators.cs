using System.Collections.Generic;
using FsCheck;

namespace FuncSharp.Tests.Generative;

public class OptionGenerators
{
    static OptionGenerators()
    {
        Bool = Arb.From(DefaultOptionGenerator<bool>()); // No shrinker needed for booleans
        Bools = Arb.From(DefaultOptionListGenerator<bool>()); // No shrinker needed for booleans
        NullableBool = Arb.From(DefaultOptionGenerator<bool?>()); // No shrinker needed for booleans
        Short = Arb.From(DefaultOptionGenerator<short>(), Shrinkers.Options.Short);
        Shorts = Arb.From(DefaultOptionListGenerator<short>(), Shrinkers.Options.ShortList);
        NullableShort = Arb.From(DefaultOptionGenerator<short?>(), Shrinkers.Options.NullableShort);
        Int = Arb.From(DefaultOptionGenerator<int>(), Shrinkers.Options.Int);
        Ints = Arb.From(DefaultOptionListGenerator<int>(), Shrinkers.Options.IntList);
        NullableInt = Arb.From(DefaultOptionGenerator<int?>(), Shrinkers.Options.NullableInt);
        Long = Arb.From(DefaultOptionGenerator<long>(), Shrinkers.Options.Long);
        Longs = Arb.From(DefaultOptionListGenerator<long>(), Shrinkers.Options.LongList);
        NullableLong = Arb.From(DefaultOptionGenerator<long?>(), Shrinkers.Options.NullableLong);
        Decimal = Arb.From(DefaultOptionGenerator<decimal>(), Shrinkers.Options.Decimal);
        Decimals = Arb.From(DefaultOptionListGenerator<decimal>(), Shrinkers.Options.DecimalList);
        NullableDecimal = Arb.From(DefaultOptionGenerator<decimal?>(), Shrinkers.Options.NullableDecimal);
        Double = Arb.From(DefaultOptionGenerator<double>(), Shrinkers.Options.Double);
        Doubles = Arb.From(DefaultOptionListGenerator<double>(), Shrinkers.Options.DoubleList);
        NullableDouble = Arb.From(DefaultOptionGenerator<double?>(), Shrinkers.Options.NullableDouble);

        Unit = Arb.From(Gen.Constant(FuncSharp.Unit.Value).SometimesEmpty()); // No shrinker needed for Unit

        var referenceTypeGenerator = Arb.From<int>().Generator.Select(i => new ReferenceType(i));
        ReferenceType = Arb.From(referenceTypeGenerator.SometimesEmpty(), Shrinkers.Options.ReferenceType);
        ReferenceTypes = Arb.From(referenceTypeGenerator.ToList().SometimesEmpty(), Shrinkers.Options.ReferenceTypeList);
        var referenceTypeBaseGenerator = Arb.From<int>().Generator.Select(i => new ReferenceTypeBase(i));
        ReferenceTypeBase = Arb.From(referenceTypeBaseGenerator.SometimesEmpty(), Shrinkers.Options.ReferenceTypeBase);
        ReferenceTypeBases = Arb.From(referenceTypeBaseGenerator.ToList().SometimesEmpty(), Shrinkers.Options.ReferenceTypeBaseList);
    }

    public static Arbitrary<Option<bool>> Bool { get; }

    public static Arbitrary<Option<bool?>> NullableBool { get; }

    public static Arbitrary<Option<List<bool>>> Bools { get; }

    public static Arbitrary<Option<short>> Short { get; }

    public static Arbitrary<Option<short?>> NullableShort { get; }

    public static Arbitrary<Option<List<short>>> Shorts { get; }

    public static Arbitrary<Option<int>> Int { get; }

    public static Arbitrary<Option<int?>> NullableInt { get; }

    public static Arbitrary<Option<List<int>>> Ints { get; }

    public static Arbitrary<Option<long>> Long { get; }

    public static Arbitrary<Option<long?>> NullableLong { get; }

    public static Arbitrary<Option<List<long>>> Longs { get; }

    public static Arbitrary<Option<decimal>> Decimal { get; }

    public static Arbitrary<Option<decimal?>> NullableDecimal { get; }

    public static Arbitrary<Option<List<decimal>>> Decimals { get; }

    public static Arbitrary<Option<double>> Double { get; }

    public static Arbitrary<Option<double?>> NullableDouble { get; }

    public static Arbitrary<Option<List<double>>> Doubles { get; }

    public static Arbitrary<Option<Unit>> Unit { get; }

    public static Arbitrary<Option<List<Unit>>> Units { get; }

    public static Arbitrary<Option<ReferenceType>> ReferenceType { get; }

    public static Arbitrary<Option<List<ReferenceType>>> ReferenceTypes { get; }

    public static Arbitrary<Option<ReferenceTypeBase>> ReferenceTypeBase { get; }

    public static Arbitrary<Option<List<ReferenceTypeBase>>> ReferenceTypeBases { get; }

    private static Gen<Option<T>> DefaultOptionGenerator<T>()
    {
        return Arb.From<T>().Generator.SometimesEmpty();
    }

    private static Gen<Option<List<T>>> DefaultOptionListGenerator<T>()
    {
        return Arb.From<T>().Generator.ToList().SometimesEmpty();
    }
}
