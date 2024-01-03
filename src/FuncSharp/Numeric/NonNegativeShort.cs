using System;
using System.Linq;

namespace FuncSharp;

public struct NonNegativeShort : IEquatable<NonNegativeShort>
{
    public static readonly NonNegativeShort Zero = new(0);

    private NonNegativeShort(short value)
    {
        Value = value;
    }

    public short Value { get; }

    public static implicit operator short(NonNegativeShort i)
    {
        return i.Value;
    }

    public static NonNegativeShort operator +(NonNegativeShort a, NonNegativeShort b)
    {
        return a.Sum(b);
    }

    public static Option<NonNegativeShort> Create(short value)
    {
        return CreateNullable(value).ToOption();
    }

    public static NonNegativeShort CreateUnsafe(short value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a non-negative short.");
    }

    public static NonNegativeShort? CreateNullable(short value)
    {
        return value >= 0 ? new NonNegativeShort(value) : null;
    }

    public static NonNegativeShort? CreateNullable(short? value)
    {
        if (value is >= 0)
        {
            return new NonNegativeShort(value.Value);
        }
        return null;
    }

    public NonNegativeShort Sum(params NonNegativeShort[] values)
    {
        return new NonNegativeShort(values.Aggregate(Value, (a, b) => (short)(a + b)));
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static bool operator ==(NonNegativeShort left, NonNegativeShort right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NonNegativeShort left, NonNegativeShort right)
    {
        return !left.Equals(right);
    }

    public bool Equals(NonNegativeShort other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is NonNegativeShort other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}