using System;

namespace FuncSharp;

public sealed class NonEmptyString : IEquatable<string>
{
    private NonEmptyString(string value)
    {
        Value = value;
    }

    public string Value { get; }

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
