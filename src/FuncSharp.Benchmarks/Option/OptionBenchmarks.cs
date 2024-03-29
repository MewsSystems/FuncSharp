using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks;

public class ReferenceType
{
    public string Text { get; set; }
}

[MemoryDiagnoser]
public class OptionBenchmarks
{
    private static readonly object Object;
    private static readonly string StringValue;
    private static readonly Option<string> NonEmptyOption;
    private static readonly Option<string> EmptyOption;
    private static readonly Option<ReferenceType> ReferenceTypeNonEmptyOption;
    private static readonly Option<ReferenceType> ReferenceTypeEmptyOption;

    static OptionBenchmarks()
    {
        Object = new object();
        StringValue = "Some String";
        NonEmptyOption = "non-empty".ToOption();
        ReferenceTypeNonEmptyOption = Option.Valued(new ReferenceType { Text= "non-empty" });
        ReferenceTypeEmptyOption = Option.Empty<ReferenceType>();
    }

    // Last Result - 22.8.2023 - 11.6 ns - 80 B
    [Benchmark]
    public void Creation_AllCases()
    {
        Option.Create(42);
        Option.Create(42 as int?);
        Option.Create(null as int?);

        Option.Create(Object);
        Option.Create(null as object);
    }

    // Last Result - 22.8.2023 - 4.7 ns - 0 B
    [Benchmark]
    public void IsEmptyOrNonEmpty_AllCases()
    {
        var a = NonEmptyOption.NonEmpty;
        var b = EmptyOption.NonEmpty;
        var c = NonEmptyOption.IsEmpty;
        var d = EmptyOption.IsEmpty;
    }

    // Last Result - 22.8.2023 - 1.2 ns - 0 B
    [Benchmark]
    public void Get()
    {
        NonEmptyOption.Get();
    }

    // Last Result - 22.8.2023 - 2.4 ns - 0 B
    [Benchmark]
    public void GetOrElse_NonEmpty()
    {
        NonEmptyOption.GetOrElse(StringValue);
    }

    // Last Result - 22.8.2023 - 1.6 ns - 0 B
    [Benchmark]
    public void GetOrElse_Empty()
    {
        EmptyOption.GetOrElse(StringValue);
    }

    // Last Result - 22.8.2023 - 3.0 ns - 0 B
    [Benchmark]
    public void Lazy_GetOrElse_NonEmpty()
    {
        NonEmptyOption.GetOrElse(_ => StringValue);
    }

    // Last Result - 22.8.2023 - 2.6 ns - 0 B
    [Benchmark]
    public void Lazy_GetOrElse_Empty()
    {
        EmptyOption.GetOrElse(_ => StringValue);
    }

    // Last Result - 22.8.2023 - 3.9 ns - 0 B
    [Benchmark]
    public void OrElse_NonEmpty_ToNonEmpty()
    {
        NonEmptyOption.OrElse(_ => NonEmptyOption);
    }

    // Last Result - 22.8.2023 - 3.4 ns - 0 B
    [Benchmark]
    public void OrElse_NonEmpty_ToEmpty()
    {
        NonEmptyOption.OrElse(_ => EmptyOption);
    }

    // Last Result - 22.8.2023 - 2.7 ns - 0 B
    [Benchmark]
    public void OrElse_Empty_ToNonEmpty()
    {
        EmptyOption.OrElse(_ => NonEmptyOption);
    }

    // Last Result - 22.8.2023 - 2.7 ns - 0 B
    [Benchmark]
    public void OrElse_Empty_ToEmpty()
    {
        EmptyOption.OrElse(_ => EmptyOption);
    }

    // Last Result - 22.8.2023 - 7.4 ns - 32 B
    [Benchmark]
    public void Map_NonEmpty()
    {
        NonEmptyOption.Map(o => StringValue);
    }

    // Last Result - 22.8.2023 - 5.9 ns - 0 B
    [Benchmark]
    public void Map_Empty()
    {
        EmptyOption.Map(o => StringValue);
    }

    // Last Result - 22.8.2023 - 4.6 ns - 0 B
    [Benchmark]
    public void FlatMap_NonEmpty_ToNonEmpty()
    {
        NonEmptyOption.FlatMap(o => NonEmptyOption);
    }

    // Last Result - 22.8.2023 - 4.6 ns - 0 B
    [Benchmark]
    public void FlatMap_NonEmpty_ToEmpty()
    {
        NonEmptyOption.FlatMap(o => EmptyOption);
    }

    // Last Result - 22.8.2023 - 6.0 ns - 0 B
    [Benchmark]
    public void FlatMap_Empty_ToNonEmpty()
    {
        EmptyOption.FlatMap(o => NonEmptyOption);
    }

    // Last Result - 22.8.2023 - 6.0 ns - 0 B
    [Benchmark]
    public void FlatMap_Empty_ToEmpty()
    {
        EmptyOption.FlatMap(o => EmptyOption);
    }

    // Last Result - 22.8.2023 - 5.2 ns - 0 B
    [Benchmark]
    public void Matching_NonEmpty()
    {
        NonEmptyOption.Match(_ => true, _ => false);
    }

    // Last Result - 22.8.2023 - 5.3 ns - 0 B
    [Benchmark]
    public void Matching_Empty()
    {
        EmptyOption.Match(_ => true, _ => false);
    }

    // Last Result - 27.8.2023 - 3.1 ns - 32 B
    [Benchmark]
    public void AsReadOnlyList_NonEmpty()
    {
        NonEmptyOption.AsReadOnlyList();
    }

    // Last Result - 27.8.2023 - 0.3 ns - 0 B
    [Benchmark]
    public void AsReadOnlyList_Empty()
    {
        EmptyOption.AsReadOnlyList();
    }

    // Last Result - 11.10.2023 - 1.82 ns - 0 B
    [Benchmark]
    public void MapPlusGetOrNull_WithFunc_NonEmpty()
    {
        var text = ReferenceTypeNonEmptyOption.Map(value => value.Text).GetOrNull();
    }

    // Last Result - 11.10.2023 - 3.61 ns - 0 B
    [Benchmark]
    public void MapPlusGetOrNull_WithFunc_Empty()
    {
        var text = ReferenceTypeEmptyOption.Map(value => value.Text).GetOrNull();
    }

    // Last Result - 11.10.2023 - 1.66 ns - 0 B
    [Benchmark]
    public void GetOrNull_WithFunc_NonEmpty()
    {
        var text = ReferenceTypeNonEmptyOption.GetOrNull(value => value.Text);
    }

    // Last Result - 11.10.2023 - 0.60 ns - 0 B
    [Benchmark]
    public void GetOrNull_WithFunc_Empty()
    {
        var text = ReferenceTypeEmptyOption.GetOrNull(value => value.Text);
    }

    // Last Result - 11.10.2023 - 0.08 ns - 0 B
    [Benchmark]
    public void GetOrNull_WithFunc_VanillaCsharp_NonEmpty()
    {
        var text = ReferenceTypeNonEmptyOption.GetOrNull()?.Text;
    }

    // Last Result - 11.10.2023 - 0.07 ns - 0 B
    [Benchmark]
    public void GetOrNull_WithFunc_VanillaCsharp_Empty()
    {
        var text = ReferenceTypeEmptyOption.GetOrNull()?.Text;
    }
}