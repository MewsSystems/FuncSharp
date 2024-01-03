using System;
using System.Linq;

namespace FuncSharp;

public struct PositiveInt : IEquatable<PositiveInt>
{
    public static readonly PositiveInt One = new(1);

    private PositiveInt(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(PositiveInt i)
    {
        return i.Value;
    }

    public static implicit operator NonNegativeInt(PositiveInt i)
    {
        return NonNegativeInt.CreateUnsafe(i.Value);
    }

    public static PositiveInt operator +(PositiveInt a, NonNegativeInt b)
    {
        return a.Sum(b);
    }

    public static PositiveInt operator *(PositiveInt a, PositiveInt b)
    {
        return a.Multiply(b);
    }

    public static Option<PositiveInt> Create(int value)
    {
        return CreateNullable(value).ToOption();
    }

    public static PositiveInt CreateUnsafe(int value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a positive integer.");
    }

    public static PositiveInt? CreateNullable(int value)
    {
        return value > 0 ? new PositiveInt(value) : null;
    }

    public PositiveInt Sum(params NonNegativeInt[] values)
    {
        return new PositiveInt(values.Aggregate(Value, (a, b) => a + b));
    }

    public PositiveInt Multiply(params PositiveInt[] values)
    {
        return new PositiveInt(values.Aggregate(Value, (a, b) => a * b));
    }

    public PositiveInt Min(PositiveInt other)
    {
        return new PositiveInt(Math.Min(Value, other.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static bool operator ==(PositiveInt left, PositiveInt right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(PositiveInt left, PositiveInt right)
    {
        return !left.Equals(right);
    }

    public bool Equals(PositiveInt other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is PositiveInt other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value;
    }
}