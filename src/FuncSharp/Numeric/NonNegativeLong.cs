using System;
using System.Linq;

namespace FuncSharp;

public struct NonNegativeLong
{
    public static readonly NonNegativeLong Zero = new(0);

    private NonNegativeLong(long value)
    {
        Value = value;
    }

    public long Value { get; }

    public static implicit operator long(NonNegativeLong i)
    {
        return i.Value;
    }

    public static NonNegativeLong operator +(NonNegativeLong a, NonNegativeLong b)
    {
        return a.Sum(b);
    }

    public static Option<NonNegativeLong> Create(long value)
    {
        return CreateNullable(value).ToOption();
    }

    public static NonNegativeLong CreateUnsafe(long value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a non-negative long.");
    }

    public static NonNegativeLong? CreateNullable(long value)
    {
        return value >= 0 ? new NonNegativeLong(value) : null;
    }

    public static NonNegativeLong? CreateNullable(long? value)
    {
        if (value is >= 0)
        {
            return new NonNegativeLong(value.Value);
        }
        return null;
    }

    public NonNegativeLong Sum(params NonNegativeLong[] values)
    {
        return new NonNegativeLong(values.Aggregate(Value, (a, b) => a + b));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}