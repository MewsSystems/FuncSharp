using System;
using System.Linq;

namespace FuncSharp;

public struct NonNegativeDecimal : IEquatable<NonNegativeDecimal>
{
    public static readonly NonNegativeDecimal Zero = new(0m);
    public static readonly NonNegativeDecimal One = new(1m);

    private NonNegativeDecimal(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }

    public static implicit operator decimal(NonNegativeDecimal d)
    {
        return d.Value;
    }

    public static NonNegativeDecimal operator +(NonNegativeDecimal d1, NonNegativeDecimal d2)
    {
        return new(d1.Value + d2.Value);
    }

    public static NonNegativeDecimal operator +(NonNegativeDecimal d1, PositiveDecimal d2)
    {
        return new(d1.Value + d2.Value);
    }

    public static NonNegativeDecimal operator *(NonNegativeDecimal d1, NonNegativeDecimal d2)
    {
        return new(d1.Value * d2.Value);
    }

    public static Option<NonNegativeDecimal> Create(decimal value)
    {
        return CreateNullable(value).ToOption();
    }

    public static NonNegativeDecimal CreateUnsafe(decimal value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a non-negative decimal.");
    }

    public static NonNegativeDecimal? CreateNullable(decimal value)
    {
        return value >= 0 ? new(value) : null;
    }

    public NonNegativeDecimal Sum(params NonNegativeDecimal[] values)
    {
        return new(values.Aggregate(Value, (d1, d2) => d1 + d2));
    }

    public NonNegativeDecimal Multiply(params NonNegativeDecimal[] values)
    {
        return new(values.Aggregate(Value, (d1, d2) => d1 * d2));
    }

    public NonNegativeDecimal Min(NonNegativeDecimal other)
    {
        return new(Math.Min(Value, other.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static bool operator ==(NonNegativeDecimal left, NonNegativeDecimal right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NonNegativeDecimal left, NonNegativeDecimal right)
    {
        return !left.Equals(right);
    }

    public bool Equals(NonNegativeDecimal other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is NonNegativeDecimal other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}