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
        var result = CreateNullable(value);
        if (result is null)
            throw new ArgumentException("You cannot create NonEmptyString from whitespace, empty string or null.");
        return result;
    }

    public static IOption<NonEmptyString> Create(string value)
    {
        return CreateNullable(value).ToOption();
    }

    public static NonEmptyString CreateNullable(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return new NonEmptyString(value);
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
