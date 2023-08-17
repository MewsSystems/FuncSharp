using System;
using System.Linq;

namespace FuncSharp;

public struct NonNegativeInt
{
    public static readonly NonNegativeInt Zero = new(0);

    private NonNegativeInt(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(NonNegativeInt i)
    {
        return i.Value;
    }

    public static NonNegativeInt operator +(NonNegativeInt a, NonNegativeInt b)
    {
        return a.Sum(b);
    }

    public static IOption<NonNegativeInt> Create(int value)
    {
        return CreateNullable(value).ToOption();
    }

    public static NonNegativeInt CreateUnsafe(int value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a non-negative integer.");
    }

    public static NonNegativeInt? CreateNullable(int value)
    {
        return value >= 0 ? new NonNegativeInt(value) : null;
    }

    public static NonNegativeInt? CreateNullable(int? value)
    {
        if (value is >= 0)
        {
            return new NonNegativeInt(value.Value);
        }
        return null;
    }

    public NonNegativeInt Sum(params NonNegativeInt[] values)
    {
        return new NonNegativeInt(values.Aggregate(Value, (a, b) => a + b));
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}