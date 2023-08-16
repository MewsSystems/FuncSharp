using System;
using System.Linq;
using FuncSharp;

namespace FuncSharp;

public struct NonPositiveDecimal
{
    public static readonly NonPositiveDecimal Zero = new(0m);

    private NonPositiveDecimal(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }

    public static implicit operator decimal(NonPositiveDecimal d)
    {
        return d.Value;
    }

    public static NonPositiveDecimal operator +(NonPositiveDecimal d1, NonPositiveDecimal d2)
    {
        return new(d1.Value + d2.Value);
    }

    public static IOption<NonPositiveDecimal> Create(decimal value)
    {
        return CreateNullable(value).ToOption();
    }

    public static NonPositiveDecimal CreateUnsafe(decimal value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a non-positive decimal.");
    }

    public static NonPositiveDecimal? CreateNullable(decimal value)
    {
        return value <= 0 ? new(value) : null;
    }

    public NonPositiveDecimal Sum(params NonPositiveDecimal[] values)
    {
        return new(values.Aggregate(Value, (d1, d2) => d1 + d2));
    }

    public NonPositiveDecimal Min(NonPositiveDecimal other)
    {
        return new(Math.Min(Value, other.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
