namespace FuncSharp;

public static class NumberExtensions
{
    #region Positive numeric types

    public static Option<PositiveShort> AsPositive(this short value)
    {
        return PositiveShort.Create(value);
    }

    public static PositiveShort AsUnsafePositive(this short value)
    {
        return PositiveShort.CreateUnsafe(value);
    }

    public static Option<PositiveInt> AsPositive(this int value)
    {
        return PositiveInt.Create(value);
    }

    public static PositiveInt AsUnsafePositive(this int value)
    {
        return PositiveInt.CreateUnsafe(value);
    }

    public static Option<PositiveLong> AsPositive(this long value)
    {
        return PositiveLong.Create(value);
    }

    public static PositiveLong AsUnsafePositive(this long value)
    {
        return PositiveLong.CreateUnsafe(value);
    }

    public static Option<PositiveDecimal> AsPositive(this decimal value)
    {
        return PositiveDecimal.Create(value);
    }

    public static PositiveDecimal AsUnsafePositive(this decimal value)
    {
        return PositiveDecimal.CreateUnsafe(value);
    }

    #endregion

    #region NonNegative numeric types

    public static Option<NonNegativeShort> AsNonNegative(this short value)
    {
        return NonNegativeShort.Create(value);
    }

    public static NonNegativeShort AsUnsafeNonNegative(this short value)
    {
        return NonNegativeShort.CreateUnsafe(value);
    }

    public static Option<NonNegativeInt> AsNonNegative(this int value)
    {
        return NonNegativeInt.Create(value);
    }

    public static NonNegativeInt AsUnsafeNonNegative(this int value)
    {
        return NonNegativeInt.CreateUnsafe(value);
    }

    public static Option<NonNegativeLong> AsNonNegative(this long value)
    {
        return NonNegativeLong.Create(value);
    }

    public static NonNegativeLong AsUnsafeNonNegative(this long value)
    {
        return NonNegativeLong.CreateUnsafe(value);
    }

    public static Option<NonNegativeDecimal> AsNonNegative(this decimal value)
    {
        return NonNegativeDecimal.Create(value);
    }

    public static NonNegativeDecimal AsUnsafeNonNegative(this decimal value)
    {
        return NonNegativeDecimal.CreateUnsafe(value);
    }

    #endregion

    #region NonPositive numeric types

    public static Option<NonPositiveShort> AsNonPositive(this short value)
    {
        return NonPositiveShort.Create(value);
    }

    public static NonPositiveShort AsUnsafeNonPositive(this short value)
    {
        return NonPositiveShort.CreateUnsafe(value);
    }

    public static Option<NonPositiveInt> AsNonPositive(this int value)
    {
        return NonPositiveInt.Create(value);
    }

    public static NonPositiveInt AsUnsafeNonPositive(this int value)
    {
        return NonPositiveInt.CreateUnsafe(value);
    }

    public static Option<NonPositiveLong> AsNonPositive(this long value)
    {
        return NonPositiveLong.Create(value);
    }

    public static NonPositiveLong AsUnsafeNonPositive(this long value)
    {
        return NonPositiveLong.CreateUnsafe(value);
    }

    public static Option<NonPositiveDecimal> AsNonPositive(this decimal value)
    {
        return NonPositiveDecimal.Create(value);
    }

    public static NonPositiveDecimal AsUnsafeNonPositive(this decimal value)
    {
        return NonPositiveDecimal.CreateUnsafe(value);
    }

    #endregion







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