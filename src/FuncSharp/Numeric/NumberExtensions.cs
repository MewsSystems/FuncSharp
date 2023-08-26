namespace FuncSharp;

public static class NumberExtensions
{
    public static Option<PositiveInt> AsPositive(this int value)
    {
        return PositiveInt.Create(value);
    }

    public static PositiveInt AsUnsafePositive(this int value)
    {
        return PositiveInt.CreateUnsafe(value);
    }

    public static Option<NonNegativeInt> AsNonNegative(this int value)
    {
        return NonNegativeInt.Create(value);
    }

    public static NonNegativeInt AsUnsafeNonNegative(this int value)
    {
        return NonNegativeInt.CreateUnsafe(value);
    }

    public static Option<NonPositiveInt> AsNonPositive(this int value)
    {
        return NonPositiveInt.Create(value);
    }

    public static NonPositiveInt AsUnsafeNonPositive(this int value)
    {
        return NonPositiveInt.CreateUnsafe(value);
    }

    public static Option<PositiveDecimal> AsPositive(this decimal value)
    {
        return PositiveDecimal.Create(value);
    }

    public static PositiveDecimal AsUnsafePositive(this decimal value)
    {
        return PositiveDecimal.CreateUnsafe(value);
    }

    public static Option<NonNegativeDecimal> AsNonNegative(this decimal value)
    {
        return NonNegativeDecimal.Create(value);
    }

    public static NonNegativeDecimal AsUnsafeNonNegative(this decimal value)
    {
        return NonNegativeDecimal.CreateUnsafe(value);
    }

    public static Option<NonPositiveDecimal> AsNonPositive(this decimal value)
    {
        return NonPositiveDecimal.Create(value);
    }

    public static NonPositiveDecimal AsUnsafeNonPositive(this decimal value)
    {
        return NonPositiveDecimal.CreateUnsafe(value);
    }

    public static decimal SafeDivide(this int a, decimal b, decimal otherwise = 0)
    {
        return Divide(a, b).GetOrElse(otherwise);
    }

    public static decimal SafeDivide(this decimal a, decimal b, decimal otherwise = 0)
    {
        return Divide(a, b).GetOrElse(otherwise);
    }

    public static Option<decimal> Divide(this int a, decimal b)
    {
        return Divide((decimal)a, b);
    }

    public static Option<decimal> Divide(this decimal a, decimal b)
    {
        return b.SafeNotEquals(0).MapTrue(_ => a / b);
    }
}