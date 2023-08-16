using System;
using System.Linq;
using FuncSharp;

namespace FuncSharp;

public struct PositiveDecimal
{
    public static readonly PositiveDecimal One = new(1m);

    private PositiveDecimal(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }

    public static implicit operator decimal(PositiveDecimal d)
    {
        return d.Value;
    }

    public static implicit operator NonNegativeDecimal(PositiveDecimal d)
    {
        return NonNegativeDecimal.CreateUnsafe(d.Value);
    }

    public static PositiveDecimal operator +(PositiveDecimal d1, PositiveDecimal d2)
    {
        return new(d1.Value + d2.Value);
    }

    public static PositiveDecimal operator +(PositiveDecimal d1, NonNegativeDecimal d2)
    {
        return new(d1.Value + d2.Value);
    }

    public static PositiveDecimal operator *(PositiveDecimal d1, PositiveDecimal d2)
    {
        return new(d1.Value * d2.Value);
    }

    public static IOption<PositiveDecimal> Create(decimal value)
    {
        return CreateNullable(value).ToOption();
    }

    public static PositiveDecimal CreateUnsafe(decimal value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a positive decimal.");
    }

    public static PositiveDecimal? CreateNullable(decimal value)
    {
        return value > 0 ? new(value) : null;
    }

    public PositiveDecimal Sum(params PositiveDecimal[] values)
    {
        return new(values.Aggregate(Value, (d1, d2) => d1 + d2));
    }

    public PositiveDecimal Multiply(params PositiveDecimal[] values)
    {
        return new(values.Aggregate(Value, (d1, d2) => d1 * d2));
    }

    public PositiveDecimal Min(PositiveDecimal other)
    {
        return new(Math.Min(Value, other.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
