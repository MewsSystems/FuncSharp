using System;

namespace FuncSharp;

public readonly struct Digit
{
    private readonly int value;

    private Digit(int value)
    {
        this.value = value;
    }

    public static implicit operator int(Digit i) => i.value;

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
        if (char.IsDigit(value))
        {
            return new Digit(int.Parse(value.ToString()));
        }
        else
        {
            return null;
        }
    }

    public override bool Equals(object obj) => obj is Digit other && value.SafeEquals(other.value);

    public override int GetHashCode() => value.GetHashCode();

    public override string ToString()
    {
        return value.ToString();
    }
}
