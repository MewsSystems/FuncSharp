using System;
using System.Linq;

namespace FuncSharp;

public struct PositiveLong : IEquatable<PositiveLong>
{
    public static readonly PositiveLong One = new(1);

    private PositiveLong(long value)
    {
        Value = value;
    }

    public long Value { get; }

    public static implicit operator long(PositiveLong i)
    {
        return i.Value;
    }

    public static implicit operator NonNegativeLong(PositiveLong i)
    {
        return NonNegativeLong.CreateUnsafe(i.Value);
    }

    public static PositiveLong operator +(PositiveLong a, NonNegativeLong b)
    {
        return a.Sum(b);
    }

    public static PositiveLong operator *(PositiveLong a, PositiveLong b)
    {
        return a.Multiply(b);
    }

    public static Option<PositiveLong> Create(long value)
    {
        return CreateNullable(value).ToOption();
    }

    public static PositiveLong CreateUnsafe(long value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a positive long.");
    }

    public static PositiveLong? CreateNullable(long value)
    {
        return value > 0 ? new PositiveLong(value) : null;
    }

    public PositiveLong Sum(params NonNegativeLong[] values)
    {
        return new PositiveLong(values.Aggregate(Value, (a, b) => a + b));
    }

    public PositiveLong Multiply(params PositiveLong[] values)
    {
        return new PositiveLong(values.Aggregate(Value, (a, b) => a * b));
    }

    public PositiveLong Min(PositiveLong other)
    {
        return new PositiveLong(Math.Min(Value, other.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
    
    public static bool operator ==(PositiveLong left, PositiveLong right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(PositiveLong left, PositiveLong right)
    {
        return !left.Equals(right);
    }

    public bool Equals(PositiveLong other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is PositiveLong other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}