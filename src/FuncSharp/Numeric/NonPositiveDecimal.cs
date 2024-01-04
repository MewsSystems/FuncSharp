using System;
using System.Linq;

namespace FuncSharp;

public struct NonPositiveDecimal : IEquatable<NonPositiveDecimal>
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

    public static Option<NonPositiveDecimal> Create(decimal value)
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

    public static bool operator ==(NonPositiveDecimal left, NonPositiveDecimal right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NonPositiveDecimal left, NonPositiveDecimal right)
    {
        return !left.Equals(right);
    }

    public bool Equals(NonPositiveDecimal other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is NonPositiveDecimal other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}