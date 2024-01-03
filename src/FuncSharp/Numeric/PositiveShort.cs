using System;
using System.Linq;

namespace FuncSharp;

public struct PositiveShort : IEquatable<PositiveShort>
{
    public static readonly PositiveShort One = new(1);

    private PositiveShort(short value)
    {
        Value = value;
    }

    public short Value { get; }

    public static implicit operator short(PositiveShort i)
    {
        return i.Value;
    }

    public static implicit operator NonNegativeShort(PositiveShort i)
    {
        return NonNegativeShort.CreateUnsafe(i.Value);
    }

    public static PositiveShort operator +(PositiveShort a, NonNegativeShort b)
    {
        return a.Sum(b);
    }

    public static PositiveShort operator *(PositiveShort a, PositiveShort b)
    {
        return a.Multiply(b);
    }

    public static Option<PositiveShort> Create(short value)
    {
        return CreateNullable(value).ToOption();
    }

    public static PositiveShort CreateUnsafe(short value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a positive short.");
    }

    public static PositiveShort? CreateNullable(short value)
    {
        return value > 0 ? new PositiveShort(value) : null;
    }

    public PositiveShort Sum(params NonNegativeShort[] values)
    {
        return new PositiveShort(values.Aggregate(Value, (a, b) => (short)(a + b)));
    }

    public PositiveShort Multiply(params PositiveShort[] values)
    {
        return new PositiveShort(values.Aggregate(Value, (a, b) => (short)(a * b)));
    }

    public PositiveShort Min(PositiveShort other)
    {
        return new PositiveShort(Math.Min(Value, other.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static bool operator ==(PositiveShort left, PositiveShort right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(PositiveShort left, PositiveShort right)
    {
        return !left.Equals(right);
    }

    public bool Equals(PositiveShort other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is PositiveShort other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}