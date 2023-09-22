using System;
using System.Linq;

namespace FuncSharp;

public struct NonPositiveShort
{
    public static readonly NonPositiveShort Zero = new(0);

    private NonPositiveShort(short value)
    {
        Value = value;
    }

    public short Value { get; }

    public static implicit operator short(NonPositiveShort i)
    {
        return i.Value;
    }

    public static NonPositiveShort operator +(NonPositiveShort a, NonPositiveShort b)
    {
        return a.Sum(b);
    }

    public static Option<NonPositiveShort> Create(short value)
    {
        return CreateNullable(value).ToOption();
    }

    public static NonPositiveShort CreateUnsafe(short value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a non-positive short.");
    }

    public static NonPositiveShort? CreateNullable(short value)
    {
        return value <= 0 ? new NonPositiveShort(value) : null;
    }

    public NonPositiveShort Sum(params NonPositiveShort[] values)
    {
        return new NonPositiveShort(values.Aggregate(Value, (a, b) => (short)(a + b)));
    }

    public NonPositiveShort Min(NonPositiveShort other)
    {
        return new(Math.Min(Value, other.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}