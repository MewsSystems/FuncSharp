using System;

namespace FuncSharp;

public sealed class NonEmptyString : IEquatable<string>
{
    private NonEmptyString(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public int Length => Value.Length;

    public static implicit operator string(NonEmptyString s)
    {
        return s.MapRef(v => v.Value);
    }

    public static NonEmptyString CreateUnsafe(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("You cannot create NonEmptyString from whitespace, empty string or null.");
        }

        return new NonEmptyString(value);
    }

    public static IOption<NonEmptyString> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Option.Empty<NonEmptyString>();
        }

        return Option.Valued(new NonEmptyString(value));
    }
    
    public bool Contains(string text)
    {
        return Value.Contains(text);
    }

    public bool Contains(string text, StringComparison comparisonType)
    {
        return Value.Contains(text, comparisonType);
    }

    public bool Contains(char c)
    {
        return Value.Contains(c);
    }

    public bool Contains(char c, StringComparison comparisonType)
    {
        return Value.Contains(c, comparisonType);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return (obj as NonEmptyString).MatchRef(e => Value.Equals(e.Value));
    }

    public bool Equals(string other)
    {
        return Value.Equals(other);
    }

    public override string ToString()
    {
        return Value;
    }
}
