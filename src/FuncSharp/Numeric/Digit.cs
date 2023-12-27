using System;

namespace FuncSharp;

public readonly struct Digit
{
    private Digit(byte value)
    {
        Value = value;
    }

    public byte Value { get; }
    public static implicit operator byte(Digit i) => i.Value;
    public static implicit operator int(Digit i) => i.Value;

    public static bool operator ==(Digit left, Digit right) => left.Equals(right);

    public static bool operator !=(Digit left, Digit right) => !left.Equals(right);

    public static Option<Digit> Create(char value)
    {
        return CreateNullable(value).ToOption();
    }

    public static Digit CreateUnsafe(char value)
    {
        var result = CreateNullable(value);
        ArgumentNullException.ThrowIfNull(result, nameof(Digit));
        return result.Value;
    }

    public static Digit? CreateNullable(char value)
    {
        return char.IsDigit(value)
            ? new Digit(byte.Parse(value.ToString()))
            : null;
    }

    public override bool Equals(object obj) => obj is Digit other && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString()
    {
        return Value.ToString();
    }
}
