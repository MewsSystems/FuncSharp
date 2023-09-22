using System;
using System.Linq;

namespace FuncSharp;

public struct NonPositiveLong
{
    public static readonly NonPositiveLong Zero = new(0);

    private NonPositiveLong(long value)
    {
        Value = value;
    }

    public long Value { get; }

    public static implicit operator long(NonPositiveLong i)
    {
        return i.Value;
    }

    public static NonPositiveLong operator +(NonPositiveLong a, NonPositiveLong b)
    {
        return a.Sum(b);
    }

    public static Option<NonPositiveLong> Create(long value)
    {
        return CreateNullable(value).ToOption();
    }

    public static NonPositiveLong CreateUnsafe(long value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a non-positive long.");
    }

    public static NonPositiveLong? CreateNullable(long value)
    {
        return value <= 0 ? new NonPositiveLong(value) : null;
    }

    public NonPositiveLong Sum(params NonPositiveLong[] values)
    {
        return new NonPositiveLong(values.Aggregate(Value, (a, b) => a + b));
    }

    public NonPositiveLong Min(NonPositiveLong other)
    {
        return new(Math.Min(Value, other.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}