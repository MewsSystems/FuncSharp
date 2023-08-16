namespace FuncSharp;

public static class NumberExtensions
{
    public static IOption<PositiveInt> AsPositive(this int value)
    {
        return PositiveInt.Create(value);
    }

    public static PositiveInt AsUnsafePositive(this int value)
    {
        return PositiveInt.CreateUnsafe(value);
    }

    public static IOption<NonNegativeInt> AsNonNegative(this int value)
    {
        return NonNegativeInt.Create(value);
    }

    public static NonNegativeInt AsUnsafeNonNegative(this int value)
    {
        return NonNegativeInt.CreateUnsafe(value);
    }

    public static IOption<NonPositiveInt> AsNonPositive(this int value)
    {
        return NonPositiveInt.Create(value);
    }

    public static NonPositiveInt AsUnsafeNonPositive(this int value)
    {
        return NonPositiveInt.CreateUnsafe(value);
    }

    public static IOption<PositiveDecimal> AsPositive(this decimal value)
    {
        return PositiveDecimal.Create(value);
    }

    public static PositiveDecimal AsUnsafePositive(this decimal value)
    {
        return PositiveDecimal.CreateUnsafe(value);
    }

    public static IOption<NonNegativeDecimal> AsNonNegative(this decimal value)
    {
        return NonNegativeDecimal.Create(value);
    }

    public static NonNegativeDecimal AsUnsafeNonNegative(this decimal value)
    {
        return NonNegativeDecimal.CreateUnsafe(value);
    }

    public static IOption<NonPositiveDecimal> AsNonPositive(this decimal value)
    {
        return NonPositiveDecimal.Create(value);
    }

    public static NonPositiveDecimal AsUnsafeNonPositive(this decimal value)
    {
        return NonPositiveDecimal.CreateUnsafe(value);
    }
}