﻿using System;
using System.Linq;

namespace FuncSharp;

public struct NonPositiveInt : IEquatable<NonPositiveInt>
{
    public static readonly NonPositiveInt Zero = new(0);

    private NonPositiveInt(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(NonPositiveInt i)
    {
        return i.Value;
    }

    public static NonPositiveInt operator +(NonPositiveInt a, NonPositiveInt b)
    {
        return a.Sum(b);
    }

    public static Option<NonPositiveInt> Create(int value)
    {
        return CreateNullable(value).ToOption();
    }

    public static NonPositiveInt CreateUnsafe(int value)
    {
        return CreateNullable(value) ?? throw new ArgumentException($"'{value}' is not a non-positive integer.");
    }

    public static NonPositiveInt? CreateNullable(int value)
    {
        return value <= 0 ? new NonPositiveInt(value) : null;
    }

    public NonPositiveInt Sum(params NonPositiveInt[] values)
    {
        return new NonPositiveInt(values.Aggregate(Value, (a, b) => a + b));
    }

    public NonPositiveInt Min(NonPositiveInt other)
    {
        return new(Math.Min(Value, other.Value));
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static bool operator ==(NonPositiveInt left, NonPositiveInt right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NonPositiveInt left, NonPositiveInt right)
    {
        return !left.Equals(right);
    }

    public bool Equals(NonPositiveInt other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is NonPositiveInt other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value;
    }
}